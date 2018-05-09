using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Directories
{
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

		static void GetDirs(String path, String word)
		{
			String[] directories;
			String[] files;
			try
			{
				directories = Directory.GetDirectories(path);
				files = Directory.GetFiles(path);
			}
			catch { return; }
			foreach (String dir in directories)
			{
				if (dir.ToLower().Contains(word.ToLower()))
					Console.WriteLine(dir);
				GetDirs(dir, word);
			}
			foreach (String file in files)
			{
				if (file.ToLower().Contains(word.ToLower()))
					Console.WriteLine(file);
			}
		}

		static void Main(string[] args)
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
			GetDirs(path, word);

		}
	}
}
