using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace home1309
{
	class Fraction
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
			tmp.Numerator = f1.numerator *  f2.numerator;
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
			return String.Format("{0} / {1}", this.numerator, this.denominator);
		}

		public override bool Equals(object obj)
		{
			return base.Equals(obj);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

	}
	class Program
	{
		static void Main(string[] args)
		{
			String sentence;
			// Задание 1
			//Console.Write("Введите строку: ");
			//sentence = Console.ReadLine();
			//String[] words = sentence.Split((string[])null, StringSplitOptions.RemoveEmptyEntries);
			//Console.WriteLine(words.Length);
			// Задание 2
			//int count = 0, index = 0;
			//Console.Write("Введите строку: ");
			//sentence = Console.ReadLine();
			//Console.Write("Введите подстроку: ");
			//String subsentence = Console.ReadLine();
			//do
			//{
			//	index = sentence.IndexOf(subsentence, index);
			//	if (index != -1)
			//	{
			//		count++;
			//		index += subsentence.Length;
			//	}				
			//} while (index != -1);
			//Console.WriteLine("Количество вхождений подстроки \"{0}\"в строку \"{1}\": {2}", subsentence, sentence, count);
			// Задание 3
			Fraction f1 = new Fraction(5, 3);
			Fraction f2 = new Fraction(7, 4);
			Fraction f3 = f1 / f2;
			Console.WriteLine(f3);
		}
	}
}
