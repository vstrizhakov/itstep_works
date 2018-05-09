using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayInterface
{
	class Money : IComparable
	{
		private int grn;
		private int kop;

		public int Grn
		{
			set
			{
				this.grn = value;
			}
			get
			{
				return this.grn;
			}
		}

		public int Kop
		{
			set
			{
				this.kop = value;
			}
			get
			{
				return this.kop;
			}
		}

		public Money(int grn, int kop)
		{
			this.Grn = grn;
			this.Kop = kop;
		}

		public void ShowMoney()
		{
			Console.WriteLine("{0}.{1}грн.", this.grn, this.kop);
		}

		public static Money operator +(Money a, Money b)
		{
			return new Money(a.grn + b.grn, a.kop + b.kop);
		}

		public static explicit operator Money(int k)
		{
			Console.WriteLine("Явное преобразование int к Money");
			return new Money(0, k);
		}

		public static implicit operator Money(double k)
		{
			Console.WriteLine("Явное преобразование int к Money");
			int g = (int)k;
			return new Money(g, (int)((k - g) * 100));
		}

		public override bool Equals(object obj)
		{
			if (obj is Money)
			{
				Money m = (Money)obj;
				return this.grn * 100 + this.kop == m.grn * 100 + m.kop;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		public int CompareTo(Object obj)
		{
			if (obj is Money)
			{
				Money m = (Money)obj;
				return (this.grn * 100 + this.kop) - (m.grn * 100 + m.kop);
			}
			return -1;
		}
	}

	class Test : IDisposable
	{
		private int[] A = new int[700000000];

		~Test()
		{
			Console.WriteLine("Test destructor");
		}

		public void Dispose()
		{

		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			//Money[] arrM =
			//{
			//	new Money(2,50),
			//	new Money(1,34),
			//	new Money(657,0),
			//	new Money(6,4),
			//	new Money(7,88),
			//	new Money(98,7),
			//	new Money(3,50),
			//	new Money(26,4),
			//	new Money(9,56),
			//	new Money(0,87),
			//	new Money(76,45),
			//	new Money(57,85),
			//};
			//Array.Sort(arrM);

			//for(int i = 0; i < arrM.Length; i++)
			//{
			//	arrM[i].ShowMoney();
			//}
			Test t;
			using (t = new Test()) { }

			Console.ReadLine();
		}
	}
}
