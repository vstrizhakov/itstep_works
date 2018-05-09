using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ArraySyncSemaphore_
{
	class Program
	{
		static void Main(string[] args)
		{
			Semaphore S = new Semaphore(2, 2);
			int[] A = new int[1000];
			ThreadWriter TW = new ThreadWriter(S, A);
			ThreadReaderSum TRS = new ThreadReaderSum(S, A);
			ThreadMinMax TMM = new ThreadMinMax(S, A);

			Thread T1 = new Thread(TW.RunMethod);
			T1.IsBackground = true;
			Thread T2 = new Thread(TRS.RunMethod);
			T2.IsBackground = true;
			Thread T3 = new Thread(TMM.RunMethod);
			T3.IsBackground = true;

			T1.Start();
			T2.Start();
			T3.Start();

			Console.ReadKey(false);
		}
	}

	class ThreadWriter
	{
		private Semaphore S;
		private int[] A;

		public ThreadWriter(Semaphore S, int[] A)
		{
			this.S = S;
			this.A = A;
		}

		public void RunMethod()
		{
			Random R = new Random();
			while (true)
			{
				try
				{
					Monitor.Enter(this.S);
					this.S.WaitOne();
					this.S.WaitOne();
				}
				catch { }
				finally
				{
					Monitor.Exit(this.S);
				}
				Console.WriteLine("Генератор случайных чисел начал свою работу");
				for (int i = 0; i < this.A.Length; i++)
				{
					this.A[i] = R.Next(0, 1000);
					Thread.Sleep(10);
				}
				Console.WriteLine("Генератор случайных чисел закончил свою работу");
				this.S.Release();
				this.S.Release();
				Thread.Sleep(10);
			}
		}
	}

	class ThreadReaderSum
	{
		private Semaphore S;
		private int[] A;

		public ThreadReaderSum(Semaphore S, int[] A)
		{
			this.S = S;
			this.A = A;
		}

		public void RunMethod()
		{
			while (true)
			{
				try
				{
					Monitor.Enter(this.S);
					this.S.WaitOne();
				}
				catch { }
				finally
				{
					Monitor.Exit(this.S);
				}
				Console.WriteLine("Читатель суммы начал свою работу");
				int sum = 0;
				foreach (int i in this.A)
				{
					sum += i;
					Thread.Sleep(10);
				}
				Console.WriteLine("Читатель суммы закончил свою работу: " + sum);
				this.S.Release();
				Thread.Sleep(10);
			}
		}
	}

	class ThreadMinMax
	{
		private Semaphore S;
		private int[] A;

		public ThreadMinMax(Semaphore S, int[] A)
		{
			this.S = S;
			this.A = A;
		}

		public void RunMethod()
		{
			while (true)
			{
				try
				{
					Monitor.Enter(this.S);
					this.S.WaitOne();
				}
				catch { }
				finally
				{
					Monitor.Exit(this.S);
				}
				Console.WriteLine("Читатель minmax начал свою работу");
				int min = A[0], max = A[0];
				foreach (int i in this.A)
				{
					if (i > max)
						max = i;
					if (i < min)
						min = i;
					Thread.Sleep(10);
				}
				Console.WriteLine("Читатель minmax завершил свою работу: " + min + " - " + max);
				this.S.Release();
				Thread.Sleep(10);
			}
		}
	}
}
