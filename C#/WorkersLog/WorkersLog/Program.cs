using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Workers
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
		static String filePath = "log.dat";
		static String separator = "====================================================================================================";

		static public String FilePath
		{
			get
			{
				return filePath;
			}
		}

		static public String Separator
		{
			get
			{
				return separator;
			}
		}

		static void Main(string[] args)
		{
			FileStream FS;
			StreamWriter SW;
			DateTime DT;
			if (!File.Exists(Program.FilePath))
			{
				FS = File.Open(Program.FilePath, FileMode.Create, FileAccess.Write);
				DT = DateTime.Now;
				SW = new StreamWriter(FS);
				SW.WriteLine(Program.Separator);
				SW.WriteLine("Лог-файл создан {0}.{1}.{2} {3}:{4}:{5}", DT.Day, DT.Month, DT.Year, DT.Hour, DT.Minute, DT.Second);
				SW.WriteLine(Program.Separator);
			}
			else
			{
				FS = File.Open(Program.FilePath, FileMode.Append, FileAccess.Write);
				SW = new StreamWriter(FS);
			}
			List<Worker> Workers = new List<Worker>();
			Workers.Add(new Worker("Имя 1", "Помидор", "Должность 5", 18));
			Workers.Add(new Worker("Имя 4", "Абрикос", "Должность 8", 14));
			Workers.Add(new Worker("Имя 2", "Банан", "Должность 6", 17));
			Workers.Add(new Worker("Имя 3", "Финик", "Должность 7", 15));

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

							Worker w = new Worker(firstName, lastName, position, age);
							Workers.Add(w);

							Console.Write("Нажмите любую клавишу, чтобы продолжить...");
							Console.ReadKey();

							// Запись действия
							DT = DateTime.Now;
							SW.WriteLine(Program.Separator);
							SW.WriteLine("{0}.{1}.{2} {3}:{4}:{5}\t-\tДобавление сотрудника", DT.Day, DT.Month, DT.Year, DT.Hour, DT.Minute, DT.Second);
							SW.WriteLine(w);
							SW.WriteLine(Program.Separator);
									SW.Flush();
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
									// Запись действия
									DT = DateTime.Now;
									SW.WriteLine(Program.Separator);
									SW.WriteLine("{0}.{1}.{2} {3}:{4}:{5}\t-\tУдаление сотрудника", DT.Day, DT.Month, DT.Year, DT.Hour, DT.Minute, DT.Second);
									SW.WriteLine(a);
									SW.WriteLine(Program.Separator);
									SW.Flush();
									break;
								}
							}

							break;
						}
					case "3":
						{
							Console.Clear();

							// Запись действия
							DT = DateTime.Now;
							SW.WriteLine(Program.Separator);
							SW.WriteLine("{0}.{1}.{2} {3}:{4}:{5}\t-\tВывод списка всех сотрудников", DT.Day, DT.Month, DT.Year, DT.Hour, DT.Minute, DT.Second);
							foreach (Worker w in Workers)
							{
								Console.WriteLine(w);
								SW.WriteLine(w);
							}
							SW.WriteLine(Program.Separator);

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

							int count = 0;
							// Запись действия
							DT = DateTime.Now;
							SW.WriteLine(Program.Separator);
							SW.WriteLine("{0}.{1}.{2} {3}:{4}:{5}\t-\tПоиск сотрудников по запросу \"{6}\"", DT.Day, DT.Month, DT.Year, DT.Hour, DT.Minute, DT.Second, select);
							foreach (Worker w in Workers)
							{
								if (w.LastName.ToLower().Contains(select.ToLower()) == true)
								{
									Console.WriteLine(w);
									SW.WriteLine(w);
									count++;
								}
							}
							if (count == 0)
							{
								SW.WriteLine("Сотрудников по запросу \"{0}\" не найдено", select);
								Console.WriteLine("Сотрудников по запросу \"{0}\" не найдено", select);
							}
							SW.WriteLine(Program.Separator);

							Console.Write("Нажмите любую клавишу, чтобы продолжить...");
							Console.ReadKey();
									SW.Flush();
							break;
						}
					case "5":
						{
							Console.Clear();
							Worker.SortMethod = false;
							Workers.Sort();

							// Запись действия
							DT = DateTime.Now;
							SW.WriteLine(Program.Separator);
							SW.WriteLine("{0}.{1}.{2} {3}:{4}:{5}\t-\tСортировка списка сотрудников по фамилии", DT.Day, DT.Month, DT.Year, DT.Hour, DT.Minute, DT.Second);
							SW.WriteLine(Program.Separator);
							break;
						}
					case "6":
						{
							Console.Clear();
							Worker.SortMethod = true;
							Workers.Sort();

							// Запись действия
							DT = DateTime.Now;
							SW.WriteLine(Program.Separator);
							SW.WriteLine("{0}.{1}.{2} {3}:{4}:{5}\t-\tСортировка списка сотрудников по возрасту", DT.Day, DT.Month, DT.Year, DT.Hour, DT.Minute, DT.Second);
							SW.WriteLine(Program.Separator);
							break;
						}
					default:
						iFlag = false;
						SW.Close();
						break;
				}
			}
		}
	}
}
