using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace ThreadsFunctions
{
	class Program
	{
		static void runThread (object obj)
		{
			for (int i = 0; i < 10; i++)
			{
				Console.WriteLine(obj.ToString());
				Thread.Sleep(750);
			}
		}
		static void Main(string[] args)
		{
			//Thread T = new Thread(runThread);
			//T.Start("Hello World");
			//Console.WriteLine("Ждем завершения работы потока Т");
			////T.Join();
			//Console.WriteLine("Главный поток дождался и работает дальше");

			ThreadOne TO = new ThreadOne();
			Thread T = new Thread(TO.Run);
			T.Start();

			while (true)
			{
				Console.ReadKey(true);
				Console.WriteLine("!!! STOPPED !!!");
				TO.SuspendWork();

				Console.ReadKey(true);
				Console.WriteLine("!!! WORKING !!!");
				TO.ResumeWork();
			}
		}
	}

	class ThreadOne
	{
		private bool isPause = false; // признак приостановки работі потока
		private EventWaitHandle e = new EventWaitHandle(true, EventResetMode.AutoReset);

		public void Run()
		{
			Console.WriteLine("1. Пекарь месит тесто");
			Thread.Sleep(1000);
			this.CheckPause();

			Console.WriteLine("2. Пекарь открывает дверь духовки");
			Thread.Sleep(1000);
			this.CheckPause();

			Console.WriteLine("3. Пекарь открывает наз");
			Thread.Sleep(1000);

			Console.WriteLine("4. Пекарь зажигает газ");
			Thread.Sleep(1000);
			this.CheckPause();

			Console.WriteLine("5. Пекарь ставит тесто в духовку");
			Thread.Sleep(1000);

			Console.WriteLine("6. Пекарь закрывает дверь духовки");
			Thread.Sleep(1000);
			this.CheckPause();

		}

		public void SuspendWork()
		{
			this.e.Reset();
			this.isPause = true;
		}

		public void ResumeWork()
		{
			this.e.Set();
			this.isPause = false;
		}

		private void CheckPause()
		{
			while (this.isPause)
			{
				this.e.WaitOne();
			}
		}
	}
}
