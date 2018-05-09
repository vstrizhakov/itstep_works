using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynArrayHome1409
{
	class DArray
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
			DArray d = new DArray();
			d.Add(23);
			d.Add(9);
			d.Add(12);
			d.Add(233);
			d.Add(232);
			d.Remove(0);

			Console.WriteLine(d[0]);
		}
	}
}
