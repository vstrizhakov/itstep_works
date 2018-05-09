using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Semaphore_Sync_Threads
{
	class Program
	{
		private static int curAvailable = 3;
		private static readonly int maxAvailable = 10;
		private static Semaphore S = new Semaphore(curAvailable, maxAvailable);
		static void Main(string[] args)
		{
			for (int i = 0; i < Program.maxAvailable; i++)
			{
				Thread T = new Thread(Program.ThreadMethod);
				T.IsBackground = true;
				T.Start(String.Format("{0}", i));
			}

			bool isRun = true;
			while (isRun)
			{
				ConsoleKeyInfo CK = Console.ReadKey(false);
				switch (CK.Key)
				{
					case ConsoleKey.UpArrow:
						if (Program.curAvailable < Program.maxAvailable)
						{
							Program.curAvailable++;
							Program.S.Release();
							Console.Write("#");
						}
						break;
					case ConsoleKey.DownArrow:
						if (Program.curAvailable > 0)
						{
							Console.Write("@");
							Program.S.WaitOne();
							Program.curAvailable--;
							Console.Write("#");
						}
						break;
					case ConsoleKey.Escape:
						isRun = false;
						break;
				}
			}
		}

		private static void ThreadMethod(object obj)
		{
			while (true)
			{
				Program.S.WaitOne();
				for (int i = 0; i < 3; i++)
				{
					Console.WriteLine("-{0}", obj.ToString());
					Thread.Sleep(1000);
				}
				Program.S.Release();
				Thread.Sleep(10);
			}
		}
	}
}
