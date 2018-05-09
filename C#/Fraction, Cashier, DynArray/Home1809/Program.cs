using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home1809
{
	class Fraction : IComparable
	{
		private double numerator;
		private double denominator;

		public double Numerator
		{
			set
			{
				this.numerator = value;
			}
			get
			{
				return this.numerator;
			}
		}

		public double Denominator
		{
			set
			{
				if (value != 0)
					this.denominator = value;
				else
				{
					this.denominator = 1;
					Console.WriteLine("Знаменатель не может быть равен 0, знаменатель был установлен как 1");
				}
			}
			get
			{
				return this.denominator;
			}
		}

		public Fraction(double numerator = 0, double denominator = 1)
		{
			this.Numerator = numerator;
			this.Denominator = denominator;
		}

		public static Fraction operator +(Fraction f1, Fraction f2)
		{
			Fraction tmp = new Fraction();
			tmp.Denominator = f1.denominator * f2.denominator;
			tmp.Numerator = f1.numerator * (tmp.denominator / f1.denominator) + f2.numerator * (tmp.denominator / f2.denominator);
			return tmp;
		}

		public static Fraction operator -(Fraction f1, Fraction f2)
		{
			Fraction tmp = new Fraction();
			tmp.Denominator = f1.denominator * f2.denominator;
			tmp.Numerator = f1.numerator * (tmp.denominator / f1.denominator) - f2.numerator * (tmp.denominator / f2.denominator);
			return tmp;
		}

		public static Fraction operator *(Fraction f1, Fraction f2)
		{
			Fraction tmp = new Fraction();
			tmp.Denominator = f1.denominator * f2.denominator;
			tmp.Numerator = f1.numerator * f2.numerator;
			return tmp;
		}

		public static Fraction operator /(Fraction f1, Fraction f2)
		{
			Fraction tmp = new Fraction();
			tmp.Denominator = f1.denominator * f2.numerator;
			tmp.Numerator = f1.numerator * f2.denominator;
			return tmp;
		}

		public static bool operator !=(Fraction f1, Fraction f2)
		{
			return f1.numerator / f1.denominator != f2.numerator / f2.denominator;
		}

		public static bool operator ==(Fraction f1, Fraction f2)
		{
			return f1.numerator / f1.denominator == f2.numerator / f2.denominator;
		}

		public static bool operator >(Fraction f1, Fraction f2)
		{
			return f1.numerator / f1.denominator > f2.numerator / f2.denominator;
		}

		public static bool operator <(Fraction f1, Fraction f2)
		{
			return f1.numerator / f1.denominator < f2.numerator / f2.denominator;
		}

		public override string ToString()
		{
			return String.Format("{0} / {1} = {2}", this.numerator, this.denominator, this.numerator / this.denominator);
		}

		public override bool Equals(object obj)
		{
			return base.Equals(obj);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		public int CompareTo(object obj)
		{
			if (obj == null)
				return 1;
			if (obj is Fraction)
			{
				Fraction tmp = (Fraction)obj;
				return (int)((tmp.numerator / tmp.denominator - this.numerator / this.denominator) * 1000);
			}
			else
				throw new IsNotFractionException("Object не является экземпляром класса Fraction");
		}
	}

	class IsNotFractionException : Exception
	{
		public IsNotFractionException(String message) : base(message) { }
	}

	class CreditCard
	{
		private String owner;
		private int bank;

		public CreditCard(String owner, int bank)
		{
			this.owner = owner;
			this.bank = bank;
		}

		public String Owner {
			get
			{
				return this.owner;
			}
			set
			{
				this.owner = value;
			}
		}
		public int Bank {
			get
			{
				return this.bank;
			}
			set
			{
				this.bank = value;
			}
		}
	}

	interface ICashOut
	{
		int GetAmount(CreditCard cc);
		String Greeting(CreditCard cc);
		String GoodBye(CreditCard cc);
		bool CashOut(CreditCard cc, int sum);
	}

	class ATM : ICashOut
	{
		public int GetAmount(CreditCard cc)
		{
			return cc.Bank;
		}
		public String Greeting(CreditCard cc)
		{
			return String.Format("Добро пожаловать, {0}", cc.Owner);
		}
		public String GoodBye(CreditCard cc)
		{
			return String.Format("Спасибо за использование нашего сервиса, {0}", cc.Owner);
		}
		public bool CashOut(CreditCard cc, int sum)
		{
			if (cc.Bank >= sum)
			{
				cc.Bank -= sum;
				Console.WriteLine("{0}, с Вашего счета было снято {1} грн. Остаток на счете равен {2} грн.", cc.Owner, sum, cc.Bank);
				return false;
			}
			return true;
		}
	}

	class Cashier : ICashOut
	{
		public int GetAmount(CreditCard cc)
		{
			return cc.Bank;
		}
		public String Greeting(CreditCard cc)
		{
			return String.Format("Добро пожаловать, {0}", cc.Owner);
		}
		public String GoodBye(CreditCard cc)
		{
			return String.Format("Спасибо за использование нашего сервиса, {0}", cc.Owner);
		}
		public bool CashOut(CreditCard cc, int sum)
		{
			if (cc.Bank >= sum)
			{
				cc.Bank -= sum;
				Console.WriteLine("{0}, с Вашего счета было снято {1} грн. Остаток на счете равен {2} грн.");
				return false;
			}
			return true;
		}
	}

	class DArray : IDisposable
	{
		private int[] array;
		private int length;

		public void Add(int value)
		{
			int[] tmp;
			int i = 0;
			this.length++;
			tmp = new int[this.length];
			if (this.array != null)
				foreach (int elem in this.array)
					tmp[i++] = elem;
			tmp[i] = value;
			this.array = tmp;
		}

		public void Remove(int index)
		{
			if (index < 1)
				index = 1;
			int[] tmp;
			this.length--;
			int i = 0;
			tmp = new int[this.length];
			if (this.array != null)
				for (int j = 0; j < this.length + 1; j++)
				{
					if (j == index - 1)
						continue;
					tmp[i++] = this.array[j];
				}
			this.array = tmp;
		}

		public void Insert(int value, int index)
		{
			if (index < 1)
				index = 1;
			int[] tmp;
			int i = 0;
			this.length += 1;
			tmp = new int[this.length];
			if (this.array != null)
				foreach (int elem in this.array)
				{
					if (i < index)
						tmp[i++] = elem;
					else if (i > index)
						tmp[i++ + 1] = elem;
					else
					{
						tmp[i++] = value;
						tmp[i] = elem;
					}
				}
			this.array = tmp;
		}

		public override String ToString()
		{
			if (array == null)
				return String.Format("В массиве нет элементов");
			String tmp = String.Format("Массив ({0} елементов): ", this.array.Length);
			foreach (int elem in this.array)
			{
				tmp += String.Format("{0} ", elem);
			}
			return tmp;
		}

		public int GetSize()
		{
			if (array == null)
				return 0;
			return this.array.Length;
		}

		public void Dispose()
		{
			this.array = null;
		}

		public int this[int index]
		{
			get
			{
				return this.array[index];
			}
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			// Задание 1
			Random R = new Random();
			//Fraction[] fracts = new Fraction[20];
			//for (int i = 0; i < fracts.Length; i++)
			//{
			//	fracts[i] = new Fraction(R.Next(-10, 11), R.Next(-10, 11));
			//}
			//Array.Sort(fracts);
			//foreach (Fraction elem in fracts)
			//{
			//	Console.WriteLine(elem);
			//}
			// Задание 2
			//using (DArray d = new DArray())
			//{
			//	d.Add(23);
			//	d.Add(9);
			//	d.Add(12);
			//	d.Add(233);
			//	d.Add(232);
			//	d.Remove(0);

			//	Console.WriteLine(d[0]);
			//}
			// Задание 3
			//CreditCard c = new CreditCard("Владимир Стрижаков", R.Next(1000, 99999));
			//Console.WriteLine(c.Bank);
			//ICashOut cashout = (R.Next(0,2) == 0) ? (ICashOut)(new ATM()) : (ICashOut)(new Cashier());
			//cashout = new ATM();
			//cashout.Greeting(c);
			//cashout.GetAmount(c);
			//cashout.CashOut(c, R.Next(1, (int)c.Bank));
			//cashout.GoodBye(c);
		}
	}
}
