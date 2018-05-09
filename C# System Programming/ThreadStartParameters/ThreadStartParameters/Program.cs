using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ThreadStartParameters
{
	class Program
	{
		static void Main(string[] args)
		{
			ThreadTwo TT1 = new ThreadTwo("Hello, World!", 10, 1000);
			ThreadTwo TT2 = new ThreadTwo("Android Forever", 20, 750);

			Thread T1 = new Thread(TT1.RunMethod);
			Thread T2 = new Thread(TT2.RunMethod);

			T1.Start();
			T2.Start();
		}
	}

	class ThreadTwo
	{
		private String msg; // Сообщение, которое будет выводить поток
		private int cnt; // Количество раз повтора
		private int delay; // Задержка между вызовами

		public ThreadTwo(string msg, int cnt, int delay)
		{
			this.msg = msg;
			this.cnt = cnt;
			this.delay = delay;
		}

		public void RunMethod()
		{
			for (int i = 0; i < this.cnt; i++)
			{
				Console.WriteLine(this.msg);
				Thread.Sleep(this.delay);
			}
		}
	}
}
