using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace EventWaitHandle___
{
	class Program
	{
		static void Main(string[] args)
		{
			EventWaitHandle e = new EventWaitHandle(false, EventResetMode.AutoReset);

			ThreadEvent TE1 = new ThreadEvent("One", e);
			ThreadEvent TE2 = new ThreadEvent("Two", e);
			ThreadEvent TE3 = new ThreadEvent("Three", e);
			ThreadEvent TE4 = new ThreadEvent("Four", e);
			ThreadEvent TE5 = new ThreadEvent("Five", e);

			ThreadEvent[] arr = { TE2, TE1, TE3, TE4, TE5 };
			foreach (ThreadEvent TE in arr)
			{
				Thread T = new Thread(TE.RunMethod);
				T.Start();
			}

			while (true)
			{
				Console.ReadKey(false);
				e.Set(); // Переводим объект в состояние "свободен"
				Console.ReadKey(false);
				e.Reset(); // Переводим объект в состояние "занят"
			}
		}
	}

	class ThreadEvent
	{
		private EventWaitHandle e;
		private string msg;

		public ThreadEvent(String msg, EventWaitHandle e)
		{
			this.msg = msg;
			this.e = e;
		}

		public void RunMethod()
		{
			while(true)
			{
				this.e.WaitOne();
				Console.WriteLine(msg);
				Thread.Sleep(500);
				this.e.Set();
				Thread.Sleep(10);
			}
		}
	}
}
