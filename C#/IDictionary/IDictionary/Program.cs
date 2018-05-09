using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDictionary
{
	class Length : IComparable<Length>
	{
		private int m;
		private int cm;

		public Length(int m, int cm)
		{
			this.m = m + cm / 100;
			this.cm = cm % 100;
		}

		public override bool Equals(object obj)
		{
			if (obj is Length)
			{
				Length L = (Length)obj;
				return (this.m * 100 + this.cm == L.m * 100 + L.cm);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		public int CompareTo(Length L)
		{
			return (this.m * 100 + this.cm) - (L.m * 100 + L.cm);
		}

		public override String ToString()
		{
			return String.Format("{0}.{1}m", this.m, this.cm);
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			//Dictionary<Length, String> D = new Dictionary<Length, String>();
			SortedList<Length, String> D = new SortedList<Length, String>();
			D.Add(new Length(2, 650), "Высота здания");
			D.Add(new Length(5, 20), "Высота двери");
			Length L1 = new Length(3, 2);
			D.Add(L1, "Высота двери");
			D.Add(new Length(3, 20), "3 двери");
			ICollection<Length> keys = D.Keys;
			foreach (Length l in keys)
			{
				Console.WriteLine("key[{0}]: {1}", l, D[l]);
			}
		}
	}
}
