using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Configuration;

namespace Delegate2
{
	public delegate int calc(int a, int b);

	public delegate void MakeMove(int dX, int dY);

	class Rectangle
	{
		private int x, y, width, height;

		public Rectangle(int x, int y, int width, int height)
		{
			this.x = x;
			this.y = y;
			this.width = width;
			this.height = height;
		}

		public void Hide()
		{
			for (int i = 0; i < this.height; i++)
			{
				Console.CursorLeft = this.x;
				Console.CursorTop = this.y + i;
				for (int j = 0; j < this.width; j++)
				{
					Console.Write(" ");
				}
			}
		}

		public void Show()
		{
			for (int i = 0; i < this.height; i++)
			{
				Console.CursorLeft = this.x;
				Console.CursorTop = this.y + i;
				for (int j = 0; j < this.width; j++)
				{
					Console.Write("█");
				}
			}
		}

		public void Move(int deltaX, int deltaY)
		{
			int newX = this.x + deltaX;
			int newY = this.y + deltaY;
			if (newX >= 0 && newX + this.width <= 80 && newY >= 0 && newY + this.height <= 80)
			{
				this.Hide();
				this.x = newX;
				this.y = newY;
				this.Show();
			}
		}
	}

	class Mover
	{
		public MakeMove MM;

		public void run()
		{
			bool isRun = true;
			while (isRun)
			{
				ConsoleKeyInfo CKI = Console.ReadKey();
				switch (CKI.Key)
				{
					case ConsoleKey.Escape:
						isRun = false;
						break;
					case ConsoleKey.UpArrow:
						this.MM(0, -1);
						break;
					case ConsoleKey.DownArrow:
						this.MM(0, 1);
						break;
					case ConsoleKey.LeftArrow:
						this.MM(-1, 0);
						break;
					case ConsoleKey.RightArrow:
						this.MM(1, 0);
						break;
				}
			}
		}
	}

	class Program
	{
		static int summa(int a, int b)
		{
			for (int i = 0; i < 10; i++)
			{
				Console.Write("Вычисляю...");
				Thread.Sleep(750);
			}
			return a + b;
		}

		static void GetResult(IAsyncResult A)
		{
			Console.WriteLine("Можно забирать результат");
			calc C = (calc)A.AsyncState;
			int res = C.EndInvoke(A);
			Console.WriteLine(res);
		}

		static void MoveWindow(int dX, int dY)
		{
			Console.WindowWidth += dX;
			Console.WindowHeight += dY;
		}

		static void Main(string[] args)
		{
			//calc C = summa;
			//IAsyncResult A = C.BeginInvoke(7, 8, null, null);
			//while (A.IsCompleted == false)
			//{
			//	Console.Write(".");
			//	Thread.Sleep(400);
			//}
			//int res = C.EndInvoke(A);
			//Console.WriteLine(res);

			//calc C = summa;
			//IAsyncResult A = C.BeginInvoke(7, 8, null, null);
			//A.AsyncWaitHandle.WaitOne();
			//Console.WriteLine("Готово!");
			//int res = C.EndInvoke(A);
			//Console.WriteLine(res);

			//calc C = summa;
			//IAsyncResult A = C.BeginInvoke(7, 8, new AsyncCallback(Program.GetResult), C);
			//while (Console.KeyAvailable == false)
			//{
			//	Console.WriteLine("первичный поток работает и не ждет ответа");
			//	Thread.Sleep(1000);
			//}

			//Rectangle r = new Rectangle(0, 0, 17, 5);
			//r.Show();
			//r.Hide();
			//for (int i = 0; i < 10; i++)
			//{
			//	r.Move(1, 1);
			//	Thread.Sleep(500);
			//}

			//Rectangle r = new Rectangle(0, 0, 17, 5);
			//r.Show();

			//Rectangle r2 = new Rectangle(18, 6, 17, 5);
			//r2.Show();

			//Rectangle r3 = new Rectangle(36, 12, 17, 5);
			//r3.Show();

			//Mover M = new Mover();
			//M.MM = r.Move;
			//M.MM += r2.Move;
			//M.MM += r3.Move;
			//M.run();

			String textColor = ConfigurationManager.AppSettings["textColor"];
			String backgroundColor = ConfigurationManager.AppSettings["backgroundColor"];

			Console.ForegroundColor = (ConsoleColor)14;

		}
	}
}
