using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace Directories
{
	class Program
	{
		static void Main(string[] args)
		{
			Dictionary<Thread, SearchThread> ThreadsList = new Dictionary<Thread, SearchThread>();
			while (true)
			{
				String path, word;
				while (true)
				{
					Console.Write("Введите каталог: ");
					path = Console.ReadLine();
					if (path.Length == 0)
						continue;
					if (!Directory.Exists(path))
						continue;
					break;
				}
				Console.Write("Введите слово: ");
				word = Console.ReadLine();
				SearchThread ST = new SearchThread(path, word);
				Thread T = new Thread(ST.RunSearch);
				T.IsBackground = true;
				T.Start();
				ThreadsList.Add(T, ST);
				Console.WriteLine("Еще раз? Y - Да | Другой символ - Нет");
				Console.Write("Ответ: ");
				if (Console.ReadLine() == "Y")
					continue;
				break;
			}
			while (ThreadsList.Count > 0)
			{
				ICollection<Thread> Threads = ThreadsList.Keys;
				foreach (Thread T in Threads)
				{
					if (T.ThreadState != ThreadState.Stopped)
						continue;
					ThreadsList[T].ShowResults();
					ThreadsList.Remove(T);
					break;
				}
			}
		}
	}

	class SearchThread
	{
		private List<String> result;
		private String path;
		private String word;

		public SearchThread(String path, String word)
		{
			this.path = path;
			this.word = word;
		}

		public void RunSearch()
		{
			this.result = this.GetDirs(this.path);
		}

		public List<String> GetDirs(String path)
		{
			String[] directories;
			String[] files;
			List<String> found = new List<String>();
			try
			{
				directories = Directory.GetDirectories(path);
				files = Directory.GetFiles(path);
			}
			catch { return null; }
			foreach (String file in files)
				if (file.ToLower().Contains(this.word.ToLower()))
					found.Add(file);
			foreach (String dir in directories)
			{
				if (dir.ToLower().Contains(this.word.ToLower()))
					found.Add(dir);
				List<String> tmp = GetDirs(dir);
				if (tmp != null)
					found = found.Concat(tmp).ToList();
			}
			return found;
		}

		public void ShowResults()
		{
			if (this.result.Count == 0)
				Console.WriteLine("Поиск в каталоге \"{0}\" по лову \"{1}\" не дал результатов", this.path, this.word);
			else
			{
				Console.WriteLine("Готовы результаты по запросу \"{0}\" в каталоге \"{1}\". Выводить ? Y - Да | Другой символ - нет", this.word, this.path);
				if (Console.ReadLine() == "Y")
					foreach (String p in this.result)
						Console.WriteLine(p);
			}
		}
	}
}
