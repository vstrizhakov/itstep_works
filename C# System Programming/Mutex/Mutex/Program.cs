using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MutexSync
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] B = new int[1000];
			Mutex M = new Mutex();
			ThreadMutex TM1 = new ThreadMutex(M, B, 1, 750);
			ThreadMutex TM2 = new ThreadMutex(M, B, 2, 500);

			Thread T1 = new Thread(TM1.Run);
			Thread T2 = new Thread(TM2.Run);

			T1.Start();
			T2.Start();

			T1.Join();
			T2.Join();

			for (int i = 0; i < B.Length; i++)
			{
				Console.Write(B[i]);
				if (i != 0 && i % 50 == 0)
					Console.WriteLine();
			}
		}
	}

	class ThreadMutex
	{
		private Mutex mutex;
		private int[] A;
		private int value;
		private int cnt;

		public ThreadMutex(Mutex m, int[] A, int value, int cnt)
		{
			this.mutex = m;
			this.A = A;
			this.value = value;
			this.cnt = cnt;
		}

		public void Run()
		{
			this.mutex.WaitOne();
			Console.WriteLine("Поток {0} начал работу с массивом", Thread.CurrentThread.Name);
			for (int i = 0; i < cnt; i++)
			{
				this.A[i] = value;
				Thread.Sleep(10);
			}
			Console.WriteLine("Поток {0} завершил работу с массивом", Thread.CurrentThread.Name);
			this.mutex.ReleaseMutex();
		}
	}
}
