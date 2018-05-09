using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTaskManages
{
	class Program
	{
		static void Main(string[] args)
		{
			Process[] processes = Process.GetProcesses();
			foreach (Process p in processes)
			{
				String id = "", name = "", starttime = "";
				int count = 0;
				try
				{
					starttime = p.StartTime.ToString();
				}
				catch { }
				try
				{
					id = p.Id.ToString();
				}
				catch { }
				try
				{
					name = p.ProcessName;
				}
				catch { }
				try
				{
					count = p.Threads.Count;
				}
				catch { }
				Console.WriteLine(String.Format("{0}: {1}, {2}, {3} threads", name, id, starttime, count));
			}
			Console.Write("Введите ID процесса: ");
			int i = Int32.Parse(Console.ReadLine());
			try
			{
				Process p = Process.GetProcessById(i);
				p.Kill();
			}
			catch (Exception e) { Console.WriteLine("Ошибка: {0}", e.Message); }
		}
	}
}
