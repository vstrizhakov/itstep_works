using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICloneable_
{
	class Student : ICloneable
	{
		protected String firstName;
		protected String lastName;
		protected int age;
		protected bool sex;

		public String FirstName
		{
			set
			{
				this.firstName = value;
			}
			get
			{
				return this.firstName;
			}
		}

		public String LastName
		{
			set
			{
				this.lastName = value;
			}
			get
			{
				return this.lastName;
			}
		}

		public int Age
		{
			set
			{
				if (value >= 16)
					this.age = value;
				else
					this.age = 16;
			}
			get
			{
				return this.age;
			}
		}

		public bool Sex
		{
			set
			{
				this.sex = value;
			}
			get
			{
				return this.sex;
			}
		}

		public Student(String firstName = "unknown", String lastName = "unknown", int age = 16, bool sex = false)
		{
			this.FirstName = firstName;
			this.LastName = lastName;
			this.Age = age;
			this.Sex = sex;
		}

		public override string ToString()
		{
			return String.Format("{0}: {1} {2}, {3} лет", (this.Sex) ? "Женщина" : "Мужчина", this.FirstName, this.LastName, this.Age);
		}

		public object Clone()
		{
			Student tmp = (Student)this.MemberwiseClone();
			tmp.FirstName = (String)this.FirstName.Clone();
			tmp.LastName = (String)this.LastName.Clone();
			return tmp;
		}
	}

	class StudentGroup : ICloneable
	{
		private Student[] group = new Student[10];
		private short i = 0;

		public void AddStudent(Student s)
		{
			if (i == group.Length - 1)
				throw new GroupOverflowException("В группе студентов находится максимальное количество студентов. Добавление невозможно!");
			this.group[i++] = s;
		}

		public void DeleteStudent(int index)
		{
			this.group[index - 1] = null;
		}

		public void ShowStudents()
		{/* 1 */
			foreach (Student s in this.group)
			{
				if (s != null)
					Console.WriteLine(s);
			}
		}

		public object Clone()
		{
			StudentGroup tmp = (StudentGroup)this.MemberwiseClone();
			tmp.group = (Student[])this.group.Clone();
			int i = 0;
			foreach (Student s in this.group)
			{
				tmp.group[i++] = (Student)s.Clone();
			}
			return tmp;
		}
	}

	class GroupOverflowException : Exception
	{
		public GroupOverflowException(String message) : base(message) { }
	}

	class DArray : ICloneable
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

		public object Clone()
		{
			DArray tmp = (DArray)this.MemberwiseClone();
			tmp.array = (int[])this.array.Clone();
			return tmp;
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
			Student s = new Student("name", "lname", 15, false);
			Student s2 = (Student)s.Clone();
			s2.FirstName = "n2";
			Console.WriteLine(s);
			Console.WriteLine(s2);
		}
	}
}
