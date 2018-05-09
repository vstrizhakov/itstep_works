using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadSynchronization
{
	class Program
	{
		static void Main(string[] args)
		{
			MyArray MA = new MyArray();
			ThreadThree TT1 = new ThreadThree(1, 500, MA);
			ThreadThree TT2 = new ThreadThree(2, 500, MA);

			Thread T1 = new Thread(TT1.Run);
			Thread T2 = new Thread(TT2.Run);

			T1.Start();
			T2.Start();

			T1.Join();
			T2.Join();

			MA.ShowArray();
		}
	}

	class MyArray
	{
		private int[] A = new int[1000];
		private int index = 0;

		public void FillArray(int value, int cnt)
		{
			for (int i = 0; i < cnt; i++)
			{
				this.A[this.index++] = value;
				Thread.Sleep(10);
			}
		}

		public void ShowArray()
		{
			for (int i = 0; i < this.A.Length; i++)
			{
				Console.Write(this.A[i]);
				if (i % 49 == 0)
					Console.WriteLine();
			}
		}
	}

	class ThreadThree
	{
		private int value; // Значение, которое должен записать поток в массив
		private int count; // Сколько раз необходимо записать значение value
		private MyArray MA; // Массив, куда необходимо записать значения

		public ThreadThree(int value, int count, MyArray MA)
		{
			this.value = value;
			this.count = count;
			this.MA = MA;
		}

		public void Run()
		{
			//try
			//{
			//	Monitor.Enter(this.MA);

			//	Console.WriteLine("Поток {0} начал работу", Thread.CurrentThread.Name);
			//	this.MA.FillArray(this.value, this.count);
			//	Console.WriteLine("Поток {0} закончил работу", Thread.CurrentThread.Name);
			//}
			//catch { }
			//finally
			//{
			//	Monitor.Exit(this.MA);
			//}

			lock(this.MA)
			{
				Console.WriteLine("Поток {0} начал работу", Thread.CurrentThread.Name);
				this.MA.FillArray(this.value, this.count);
				Console.WriteLine("Поток {0} закончил работу", Thread.CurrentThread.Name);
			}
		}
	}
}
