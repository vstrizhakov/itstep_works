using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workers
{
	public delegate void Popup();
	class Worker : IComparable
	{
		static bool sortMethod = false;
		private String firstName;
		private String lastName;
		private String position;
		private int age;

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

		public Worker(String firstName = "unknown", String lastName = "unknown", String position = "unknown", int age = 0)
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

		public int Age
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

	class WorkersState
	{
		private List<Worker> Workers = new List<Worker>();
		private event Popup P;

		public void ShowPopups()
		{
			if (P != null)
				P();
			else
				Console.WriteLine("Нет данных про выполнение каких-либо операций");
		}

		public void Add(String firstName, String lastName, String position, int age)
		{
			Workers.Add(new Worker(firstName, lastName, position, age));
			this.AddPopup(String.Format("Добавлен сотрудник {0} {1} на должности {2} возрастом {3}", firstName, lastName, position, age));
		}

		public void AddPopup(String msg)
		{
			this.P += (new Popuper(msg)).ShowMessage;
		}

		public void RemovePopup(Popup popuper)
		{
			this.P -= popuper;
		}

		public void ClearPopup()
		{
			this.P = null;
		}

		public int Count
		{
			get
			{
				return this.Workers.Count;
			}
		}

		public void Show()
		{
			int i = 1;
			foreach (Worker w in this.Workers)
				Console.WriteLine("{0} - {1}", i++, w);
			if (Workers.Count == 0)
				Console.WriteLine("Нет сотрудников");
			this.AddPopup("вывести список сотрудников");
		}

		public void Remove(int index)
		{
			int i = 1;
			foreach (Worker a in Workers)
			{
				if (i++ == index)
				{
					this.AddPopup(String.Format("удалить сотрудника {0} {1} на должности {2} возрастом {3}", a.FirstName, a.LastName, a.Position, a.Age));
					Workers.Remove(a);
					break;
				}
			}
		}

		public void FindByLastname(String lastname)
		{
			this.AddPopup(String.Format("поиск сотрудников по фамилии \"{0}\"", lastname));
			int i = 0;
			foreach (Worker w in this.Workers)
				if (w.LastName.ToLower().Contains(lastname) == true)
				{
					Console.WriteLine(w);
					i++;
				}
			if (i == 0)
				Console.WriteLine("Сотрудников с заданной фамилией не найдено");
		}

		public void SortByLastname()
		{
			this.AddPopup("сортировка сотрудников по фамилии");
			Worker.SortMethod = false;
			Workers.Sort();
		}

		public void SortByAge()
		{
			this.AddPopup("сортировка сотрудников по возрасту");
			Worker.SortMethod = true;
			Workers.Sort();
		}
	}

	class Popuper
	{
		private String message;

		public Popuper(String message)
		{
			this.message = message;
		}

		public void ShowMessage()
		{
			Console.WriteLine("Выполнена операция: {0}", this.message);
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			WorkersState Workers = new WorkersState();
			Workers.Add("Имя 1", "Помидор", "Должность 5", 18);
			Workers.Add("Имя 4", "Абрикос", "Должность 8", 14);
			Workers.Add("Имя 2", "Банан", "Должность 6", 17);
			Workers.Add("Имя 3", "Финик", "Должность 7", 15);
			Workers.ClearPopup();
			bool iFlag = true;
			String select;
			while (iFlag)
			{
				Console.Clear();
				Console.WriteLine("====================================================================================================");
				Workers.ShowPopups();
				Console.WriteLine("====================================================================================================");
				Console.WriteLine("1 - Добавить сотрудника");
				Console.WriteLine("2 - Удалить сотрудника по индексу");
				Console.WriteLine("3 - Вывести всех сотрудников");
				Console.WriteLine("4 - Вывести сотрудников, у которых в фамилии есть введенные символы");
				Console.WriteLine("5 - Отсортировать сотрудников по фамилии");
				Console.WriteLine("6 - Отсортировать сотрудников по возрасту");
				Console.WriteLine("7 - Очистить уведомления");
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

							Workers.Add(firstName, lastName, position, age);

							Console.Write("Нажмите любую клавишу, чтобы продолжить...");
							Console.ReadKey();
							break;
						}
					case "2":
						{
							Console.Clear();

							Workers.Show();

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
							Workers.Remove(Int32.Parse(select));
							break;
						}
					case "3":
						{
							Console.Clear();

							Workers.Show();

							Console.Write("Нажмите любую клавишу, чтобы продолжить...");
							Console.ReadKey();
							break;
						}
					case "4":
						{
							Console.Clear();

							Console.Write("Введите символы, которые нужно найти в фамилии сотрудника: ");
							select = Console.ReadLine();

							Workers.FindByLastname(select.ToLower());

							Console.Write("Нажмите любую клавишу, чтобы продолжить...");
							Console.ReadKey();
							break;
						}
					case "5":
						{
							Console.Clear();
							Workers.SortByLastname();
							break;
						}
					case "6":
						{
							Console.Clear();
							Worker.SortMethod = true;
							Workers.SortByAge();
							break;
						}
					case "7":
						{
							Workers.ClearPopup();
							break;
						}
					default:
						iFlag = false;
						break;
				}
			}
		}
	}
}
