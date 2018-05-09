using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace MutexThreradsByOrder
{
	class Program
	{
		static void Main(string[] args)
		{
			Mutex m = new Mutex();
			NumericThread NT1 = new NumericThread(m);
			NumericThread NT2 = new NumericThread(m);
			NumericThread NT3 = new NumericThread(m);
			Thread T1 = new Thread(NT1.Run);
			T1.Name = "One";
			T1.IsBackground = true;
			Thread T2 = new Thread(NT1.Run);
			T2.Name = "Two";
			T1.IsBackground = true;
			Thread T3 = new Thread(NT1.Run);
			T3.Name = "Three";
			T1.IsBackground = true;

			T1.Start(1);
			T3.Start(3);
			T2.Start(2);
		}
	}

	class NumericThread
	{
		private int ThreadsCount = Process.GetCurrentProcess().Threads.Count;
		private Mutex m;
		public NumericThread(Mutex m)
		{
			this.m = m;
		}

		public void Run(object n)
		{
			for (int i = 0; i < (int)n; i++)
			{
				this.m.WaitOne();
				this.m.ReleaseMutex();
				Thread.Sleep(10);
			}
			Console.WriteLine(((int)n).ToString());
		}
	}
}
