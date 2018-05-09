using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Threads
{
	class Program
	{
		static void MyMethod()
		{
			for (int i = 0; i < 10; i++)
			{
				Console.WriteLine("Hello World " + i);
				Thread.Sleep(500);
			}
		}
		static void MyMethodWithParam(object obj)
		{
			for (int i = 0; i < 10; i++)
			{
				Console.WriteLine(obj.ToString());
				Thread.Sleep(1000);
			}
		}
		
		static void runOne()
		{
			try
			{
				for (int i = 0; i < 20; i ++)
				{
					Console.WriteLine("Поток {0} работает ({1})", Thread.CurrentThread.Name, i);
					Thread.Sleep(1000);
				}
			}
			catch (ThreadAbortException)
			{
				Console.WriteLine("Поток {0} прерван", Thread.CurrentThread.Name);
			}
		}

		static void runTwo()
		{
			for (int i = 0; i < 20; i++)
			{
				try
				{
					Console.WriteLine("Поток {0} работает ({1})", Thread.CurrentThread.Name, i);
					Thread.Sleep(1000);
				}
				catch (ThreadAbortException)
				{
					Console.WriteLine("Поток {0}: не дождетесь!", Thread.CurrentThread.Name);
					Thread.ResetAbort();
					continue;
				}
			}
		}
		static void Main(string[] args)
		{
			//Thread T = new Thread(MyMethodWithParam);
			//T.IsBackground = true;
			//T.Start("Hello, World");
			//Thread T2 = new Thread(MyMethodWithParam);
			//T2.IsBackground = true;
			//Console.ReadKey();
			//T2.Start("Android forever");
			//Console.ReadKey();
			Thread T1 = new Thread(runOne);
			T1.Name = "First";
			T1.Start();

			Thread T2 = new Thread(runTwo);
			T2.Name = "Second";
			T2.Start();

			Thread.Sleep(1000);
			T1.Abort();
			T2.Abort();
		}
	}
}
