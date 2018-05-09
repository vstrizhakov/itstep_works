using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WorkersToFIle
{
	class Worker : IComparable
	{
		static bool sortMethod = false;
		private String firstName;
		private String lastName;
		private String position;
		private short age;

		static public bool SortMethod
		{
			set
			{
				sortMethod = value;
			}
			get
			{
				return sortMethod;
			}
		}

		public Worker(String firstName = "unknown", String lastName = "unknown", String position = "unknown", short age = 0)
		{
			this.FirstName = firstName;
			this.LastName = lastName;
			this.Position = position;
			this.Age = age;
		}

		public int CompareTo(object obj)
		{
			if (obj is Worker)
			{
				Worker tmp = (Worker)obj;
				if (Worker.sortMethod == false)
					return String.Compare(this.LastName, tmp.LastName);
				else
					return this.Age - tmp.age;
			}
			return 0;
		}

		public override string ToString()
		{
			return String.Format("Фамилия Имя: {0} {1}, Должность: {2}, Возраст: {3}", this.firstName, this.lastName, this.position, this.age);
		}

		public void Write(BinaryWriter BW)
		{
			BW.Write(this.FirstName);
			BW.Write(this.LastName);
			BW.Write(this.Position);
			BW.Write(this.Age);
		}

		static public Worker Read(BinaryReader BR)
		{
			return new Worker(BR.ReadString(), BR.ReadString(), BR.ReadString(), BR.ReadInt16());
		}

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

		public String Position
		{
			set
			{
				this.position = value;
			}
			get
			{
				return this.position;
			}
		}

		public short Age
		{
			set
			{
				this.age = value;
			}
			get
			{
				return this.age;
			}
		}
	}

	class Program
	{
		static String filePath = "workers.dat";

		static String FilePath
		{
			get
			{
				return filePath;
			}
		}

		static void Main(string[] args)
		{
			List<Worker> Workers = new List<Worker>();
			FileStream FS;
		
			if (File.Exists(filePath))
			{
				FS = File.Open(Program.FilePath, FileMode.Open, FileAccess.Read);
				BinaryReader BR = new BinaryReader(FS);
				while (FS.Position < FS.Length)
					Workers.Add(Worker.Read(BR));
				BR.Close();
			}
				
			bool iFlag = true;
			String select;
			while (iFlag)
			{
				Console.Clear();
				Console.WriteLine("1 - Добавить сотрудника");
				Console.WriteLine("2 - Удалить сотрудника по индексу");
				Console.WriteLine("3 - Вывести всех сотрудников");
				Console.WriteLine("4 - Вывести сотрудников, у которых в фамилии есть введенные символы");
				Console.WriteLine("5 - Отсортировать сотрудников по фамилии");
				Console.WriteLine("6 - Отсортировать сотрудников по возрасту");
				Console.WriteLine("Любой другой символ - Выход");
				Console.Write("Выберите действие: ");
				select = Console.ReadLine();

				switch (select)
				{
					case "1":
						{
							Console.Clear();

							String firstName, lastName, position;
							short age;
							while (true)
							{
								Console.Write("Введите имя сотрудника: ");
								select = Console.ReadLine();
								if (select.Length == 0)
									continue;
								firstName = select;
								break;
							}

							while (true)
							{
								Console.Write("Введите фамилию сотрудника: ");
								select = Console.ReadLine();
								if (select.Length == 0)
									continue;
								lastName = select;
								break;
							}

							while (true)
							{
								Console.Write("Введите должность сотрудника: ");
								select = Console.ReadLine();
								if (select.Length == 0)
									continue;
								position = select;
								break;
							}

							while (true)
							{
								Console.Write("Введите возраст сотрудника: ");
								select = Console.ReadLine();
								try
								{
									if (Int16.Parse(select) < 18)
										continue;
								}
								catch { continue; }
								age = Int16.Parse(select);
								break;
							}

							Workers.Add(new Worker(firstName, lastName, position, age));

							Console.Write("Нажмите любую клавишу, чтобы продолжить...");
							Console.ReadKey();
							break;
						}
					case "2":
						{
							Console.Clear();

							int i = 1;
							foreach (Worker w in Workers)
								Console.WriteLine("{0} - {1}", i++, w);

							while (true)
							{
								Console.Write("Введите индекс сотрудника, которого хотите удалить: ");
								select = Console.ReadLine();
								try
								{
									if (Int32.Parse(select) < 1 || Int32.Parse(select) > Workers.Count)
										continue;
								}
								catch { continue; }
								break;
							}

							i = 1;
							foreach (Worker a in Workers)
							{
								if (i++ == Int32.Parse(select))
								{
									Workers.Remove(a);
									break;
								}
							}

							break;
						}
					case "3":
						{
							Console.Clear();							

							foreach (Worker w in Workers)
								Console.WriteLine(w);

							if (Workers.Count == 0)
								Console.WriteLine("Нет сотрудников");

							Console.Write("Нажмите любую клавишу, чтобы продолжить...");
							Console.ReadKey();
							break;
						}
					case "4":
						{
							Console.Clear();

							Console.Write("Введите символы, которые нужно найти в фамилии сотрудника: ");
							select = Console.ReadLine();

							foreach (Worker w in Workers)
								if (w.LastName.ToLower().Contains(select.ToLower()) == true)
									Console.WriteLine(w);

							Console.Write("Нажмите любую клавишу, чтобы продолжить...");
							Console.ReadKey();
							break;
						}
					case "5":
						{
							Console.Clear();
							Worker.SortMethod = false;
							Workers.Sort();
							break;
						}
					case "6":
						{
							Console.Clear();
							Worker.SortMethod = true;
							Workers.Sort();
							break;
						}
					default:
						iFlag = false;
						break;
				}
			}

			FS = File.Open(Program.FilePath, FileMode.Create, FileAccess.Write);
			BinaryWriter BW = new BinaryWriter(FS);
			foreach (Worker w in Workers)
				w.Write(BW);
			BW.Close();
		}
	}
}
