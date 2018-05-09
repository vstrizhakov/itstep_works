using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INdexator
{
	class Program
	{
		static void Main(string[] args)
		{
			Array arr = new Array();
			arr.ShowArray();
		}
	}

	class Array
	{
		private int[] arr = new int[20];

		public int this[int index]
		{
			set
			{
				this.arr[index] = value;
			}
			get
			{
				return this.arr[index];
			}
		}

		public void ShowArray()
		{
			for (int i = 0; i < this.arr.Length; i++)
			{
				Console.WriteLine("[{0}] = {1}", i, this.arr[i]);
			}
		}
	}
}
