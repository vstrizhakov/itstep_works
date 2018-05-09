using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClass
{
	abstract class Transport
	{
		protected int speed;
		protected int distance;

		public Transport(int speed = 0, int distance = 0)
		{
			this.speed = speed;
			this.distance = distance;
		}

		public abstract string Move();
	}

	class Auto : Transport
	{
		public Auto(int speed, int distance) : base(speed, distance) { }

		public override String Move()
		{
			return String.Format("Автомобиль. Мчится по шоссе со скоростью {0}км/ч на расстояние {1}км", this.speed, this.distance);
		}
	}

	class Boat : Transport
	{
		public Boat(int speed, int distance) : base(speed, distance) { }

		public override String Move()
		{
			return String.Format("Лодка. Плывет по морю со скоростью {0}км/ч на расстояние {1}км", this.speed, this.distance);
		}
	}

	class Plan : Transport
	{
		public Plan(int speed, int distance) : base(speed, distance) { }

		public override String Move()
		{
			return String.Format("Самолет. Летит по небу со скоростью {0}км/ч на расстояние {1}км", this.speed, this.distance);
		}
	}

	class JamesBond
	{
		private String number;
		private Transport transport;
		
		public JamesBond(String number)
		{
			this.number = number;
		}

		public void SetTransport(Transport T)
		{
			this.transport = T;
		}

		public void Action()
		{
			Console.WriteLine("Агент {0} выполняет миссию. В его распоряжении: {1}", this.number, this.transport.Move());
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			Transport t = new Plan(34, 100);
			JamesBond jb = new JamesBond("007");
			jb.SetTransport(t);
			jb.Action();

		}
	}
}
