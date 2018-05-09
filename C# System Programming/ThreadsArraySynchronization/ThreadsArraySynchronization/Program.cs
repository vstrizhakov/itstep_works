using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadsArraySynchronization
{
	class Program
	{
		static void Main(string[] args)
		{
			MyArray MA = new MyArray();
			Thread T1 = new Thread(MA.FillArray);
			Thread T2 = new Thread(MA.GetSum);
			Thread T3 = new Thread(MA.GetMinAndMax);
			T1.Start();
			T2.Start();
			T3.Start();


		}
	}

	class MyArray
	{
		private List<int> A = new List<int>();
		public void FillArray()
		{
			while (true)
			{
				lock (this)
				{
					Random R = new Random();
					int cnt = R.Next(1, 50);
					for (int i = 0; i < cnt; i++)
					{
						this.A.Add(R.Next(0, 10000));
						Thread.Sleep(10);
					}
				}
			}
		}

		public void GetSum()
		{
			while (true)
			{
				lock (this)
				{
					int sum = 0;
					foreach (int num in this.A)
					{
						sum += num;
					}
					Console.WriteLine("Сумма всех элементов массива: {0}", sum);
				}
			}
		}

		public void GetMinAndMax()
		{
			while (true)
			{
				lock (this)
				{
					int max = this.A[0], min = this.A[0];
					foreach (int num in this.A)
					{
						if (num > max)
							max = num;
						if (num < min)
							min = num;
						Thread.Sleep(10);
					}
					Console.WriteLine("Максимальное - {0}, минимальное - {1}", max, min);
				}
			}
		}
	}
}
