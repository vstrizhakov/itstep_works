using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace IEnumerable_
{
	class TestArray : IEnumerable
	{
		private int[] arr = new int[20];
		public int this[int index]
		{
			get
			{
				return this.arr[index];
			}
			set
			{
				this.arr[index] = value;
			}
		}
		
		public int GetSize()
		{
			return this.arr.Length;
		}

		public IEnumerator GetEnumerator()
		{
			return this.arr.GetEnumerator();
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			TestArray TA = new TestArray();
			Random R = new Random();
			for (int i = 0; i < TA.GetSize(); i++)
			{
				TA[i] = R.Next(0, 100);
			}
			foreach(int a in TA)
			{
				Console.WriteLine(a);
			}
		}
	}
}
