using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Directories
{
	public delegate List<String> Search(String path, String word);
	class Program
	{
		static void GetDirs(String path)
		{
			String[] directories;
			try
			{
				directories = Directory.GetDirectories(path);
			}
			catch { return; }
			foreach (String dir in directories)
			{
				Console.WriteLine(dir);
				GetDirs(dir);
			}
		}

		static List<String> GetDirs(String path, String word)
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
			{
				if (file.ToLower().Contains(word.ToLower()))
					found.Add(file);
			}
			foreach (String dir in directories)
			{
				if (dir.ToLower().Contains(word.ToLower()))
					found.Add(dir);
				List<String> tmp = GetDirs(dir, word);
				if (tmp != null)
					foreach (String s in tmp)
					{
						found.Add(s);
					}
			}
			return found;
		}

		static void ShowResults(IAsyncResult IAR)
		{
			Search S = (Search)IAR.AsyncState;

			Console.WriteLine("Готовы результаты по Вашему запросу. Выводить ? 1 - Да | Другой символ - нет");
			if (Console.ReadLine() == "1")
			{
				List<String> paths = S.EndInvoke(IAR);
				if (paths == null)
				{
					Console.WriteLine("Ошибка при выполнении операции");
					return;
				}
				foreach (String p in paths)
					Console.WriteLine(p);
			}
		}

		static void Main(string[] args)
		{
			List<IAsyncResult> IARS = new List<IAsyncResult>();
			while (true)
			{
				String path, word;
				while (true)
				{
					Console.Write("Введите каталог: ");
					path = Console.ReadLine();
					if (path.Length == 0)
						continue;
					break;
				}
				Console.Write("Введите слово: ");
				word = Console.ReadLine();
				Search S = GetDirs;
				IARS.Add(S.BeginInvoke(path, word, null, S));

				Console.WriteLine("Еще раз? 1 - Да | Другой символ - Нет");
				Console.Write("Ответ: ");
				if (Console.ReadLine() == "1")
					continue;
				break;
			}
			foreach (IAsyncResult IAR in IARS)
			{
				IAR.AsyncWaitHandle.WaitOne();
				Program.ShowResults(IAR);
			}
		}
	}
}
