using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace les8
{
	interface ICalculator
	{
		int plus(int a, int b);
		int minus(int a, int b);
		int mult(int a, int b);
		int div(int a, int b);
	}

	class MyPoint2D : ICalculator
	{
		private int x;
		private int y;

		public MyPoint2D(int x, int y)
		{
			this.x = x;
			this.y = y;
		}

		public int div(int a, int b)
		{
			return a / b;
		}

		public int minus(int a, int b)
		{
			return a - b;
		}

		public int mult(int a, int b)
		{
			return a * b;
		}

		public int plus(int a, int b)
		{
			return a - b;
		}

		public override string ToString()
		{
			return base.ToString();
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			//MyPoint2D P = new MyPoint2D(12, 15);
			//int res = P.plus(2,6);
			//Console.WriteLine(res);

			Backpack B = new Backpack();

			B.addThing(new Book("Язык программирования", true));
			B.addThing(new Lighter(80));
			B.addThing(new Bread(300, "Александровский батон"));
			B.addThing(new Book("Сказки пушкина", false));

			String[] info = B.getAllInformation();
			Console.WriteLine("Вещи в рюкзаке:");
			for (int i = 0; i < info.Length; i++)
			{
				Console.WriteLine(info[i]);
			}
			Random r = new Random();
			for (int i = 0; i < 5; i++)
			{
				B.useThingByIndex(r.Next(0, 10));
			}
		}
	}
	interface IUsable
	{
		void use();
		String getInformation();
	}
	class Book : IUsable
	{
		private String title;
		private bool isHard;

		public Book(String title, bool isHard)
		{
			this.title = title;
		}
		public String getInformation()
		{
			return String.Format("Книга '{0}' в {1} переплете", this.title, ((this.isHard) ? "твердом" : "мягком"));
		}
		public void use()
		{
			Console.WriteLine("Читается книга '{0}'", this.title);
		}
	}
	class Lighter : IUsable
	{
		private int charge;//Заряд батареи
		private bool isOn;
		public Lighter(int charge)
		{
			this.charge = charge;
			this.isOn = false;
		}
		public String getInformation()
		{
			return String.Format("Фонарик с емкостью батареии {0}% {1}", this.charge, ((this.isOn) ? "включен" : "выключен"));
		}
		public void use()
		{
			if (this.charge <= 0)
			{
				Console.WriteLine("Фонарь разряжен");
				return;
			}
			if (this.isOn)
				Console.WriteLine("Фонарь включен. Емкость {0}%", this.charge);
			else
			{
				this.charge -= 10;
				Console.WriteLine("Фонарь включен. Емкость {0}%", this.charge);
			}
			this.isOn = !this.isOn;
		}
	}
	class Bread : IUsable
	{
		private int weight;
		private String name;

		public Bread(int weight, String name)
		{
			this.weight = weight;
			this.name = name;
		}
		public String getInformation()
		{
			return String.Format("Хлеб '{0}' массой {1}г.", this.name, this.weight);
		}
		public void use()
		{
			if (weight <= 0)
			{
				Console.WriteLine("Хлеба больше нет");
				return;
			}
			this.weight -= 100;
			Console.WriteLine("Часть хлеба съедается. Осталось : {0}г", this.weight);
		}
	}
	class Backpack
	{
		private IUsable[] things = new IUsable[10];
		private int count = 0;
		public void addThing(IUsable thing)
		{
			if (this.count < this.things.Length)
				this.things[this.count++] = thing;
		}
		public String[] getAllInformation()
		{
			String[] info = new String[this.count];
			for (int i = 0; i < info.Length; i++)
			{
				info[i] = this.things[i].getInformation();
			}
			return info;
		}
		public void useThingByIndex(int index)
		{
			if (index >= 0 && index < this.count)
				this.things[index].use();
			else
				Console.WriteLine("Нет такой вещи в рюкзаке");
		}
	}
}
