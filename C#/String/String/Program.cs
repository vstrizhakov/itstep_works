using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringProgram
{
	class Money
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

		public static Money operator + (Money a, Money b)
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

		~Money()
		{
			Console.WriteLine("Money Destructor");
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			Money M1 = (int)345;
			M1 = null;
			Console.ReadLine();

		}
	}
}
