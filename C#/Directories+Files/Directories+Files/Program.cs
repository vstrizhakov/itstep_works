using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Directories_Files
{
	class Program
	{
		static String word;

		static String[] GetFiles(String dir)
		{
			return Directory.GetFiles(dir, "*.txt");
		}

		static List<String> GetAllFilesFromDir(String path)
		{
			List<String> filesForReturn = new List<String>();
			String[] directories;
			try
			{
				directories = Directory.GetDirectories(path);
			}
			catch { return null; }

			foreach (String file in GetFiles(path))
			{
				filesForReturn.Add(file);
			}

			foreach (String dir in directories)
			{
				List<String> tmp = GetAllFilesFromDir(dir);
				if (tmp != null)
					foreach (String s in tmp)
						filesForReturn.Add(s);
			}
			return filesForReturn;
		}

		static bool SearchWordInFile(String path)
		{
			StreamReader SR;
			try
			{
				SR = new StreamReader(path, Encoding.Default);
			}
			catch { return false; }
			String file = SR.ReadToEnd();
			if (file.Contains(Program.word))
				return true;
			return false;
		}

		static void Main(string[] args)
		{
			String dir;
			List<String> files;
			DirectoryInfo di;
			while (true)
			{
				Console.Write("Введите каталог, в котором нужно искать: ");
				dir = Console.ReadLine();
				if (dir.Length == 0)
					continue;
				di = new DirectoryInfo(dir);
				if (!di.Exists)
				{
					Console.WriteLine("Ошибка при открытии данной директории, введите другую");
					continue;
				}
				Console.WriteLine("Получаем каталоги и подкаталоги, находящиеся в каталоге \"{0}\"...", dir);
				files = GetAllFilesFromDir(dir);
				break;
			}

			Console.Write("Введите слово, файлы с которым нужно найти: ");
			Program.word = Console.ReadLine();

			List<String> FinalPaths = new List<String>();
			Console.WriteLine("Ищем слово \"{0}\" в файлах...", Program.word);
			FileStream FS = File.Open("found_files.txt", FileMode.Create, FileAccess.Write);
			StreamWriter SW = new StreamWriter(FS);
			foreach (String f in files)
				if (SearchWordInFile(f) == true)
				{
					FinalPaths.Add(f);
					SW.WriteLine(f);
				}
			SW.Close();

			foreach (String f in FinalPaths)
				Console.WriteLine(f);
		}
	}
}
