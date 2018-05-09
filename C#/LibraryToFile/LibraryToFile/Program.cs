using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Library_
{
	class Author : IComparable
	{
		private bool sex;
		private String lastName;
		private String firstName;
		private DateTime birthday;

		static public Author Read(BinaryReader BR)
		{
			return new Author(BR.ReadString(), BR.ReadString(), BR.ReadBoolean(), new DateTime(BR.ReadInt32(), BR.ReadInt32(), BR.ReadInt32()));
		}

		public void Write(BinaryWriter BW)
		{
			BW.Write(firstName);
			BW.Write(lastName);
			BW.Write(Sex);
			BW.Write(birthday.Year);
			BW.Write(birthday.Month);
			BW.Write(birthday.Day);
		}

		public bool Sex
		{
			get
			{
				return this.sex;
			}
			set
			{
				this.sex = value;
			}
		}

		public String LastName
		{
			get
			{
				return this.lastName;
			}
			set
			{
				this.lastName = value;
			}
		}

		public String FirstName
		{
			get
			{
				return this.firstName;
			}
			set
			{
				this.firstName = value;
			}
		}

		public DateTime Birthday
		{
			get
			{
				return this.birthday;
			}
			set
			{
				this.birthday = value;
			}
		}

		public Author(String firstName, String lastName, bool sex, DateTime birthday)
		{
			this.FirstName = firstName;
			this.LastName = lastName;
			this.Sex = sex;
			this.Birthday = birthday;
		}

		public override String ToString()
		{
			return String.Format("Фамилия, имя: {0} {1} | Пол: {2} | День рождения: {3}", this.LastName, this.FirstName, (this.Sex == false) ? "Мужчина" : "Женщина", this.Birthday);
		}

		public int CompareTo(object obj)
		{
			if (obj is Author)
			{
				Author tmp = (Author)obj;
				return String.Compare(this.LastName, tmp.LastName) & String.Compare(this.FirstName, tmp.FirstName);
			}
			return 0;
		}
	}

	class Book
	{
		private String name;
		private String theme;
		private DateTime date;

		static public Book Read(BinaryReader BR)
		{
			return new Book(BR.ReadString(), BR.ReadString(), new DateTime(BR.ReadInt32(), BR.ReadInt32(), BR.ReadInt32()));
		}

		public void Write(BinaryWriter BW)
		{
			BW.Write(this.name);
			BW.Write(this.theme);
			BW.Write(this.date.Year);
			BW.Write(this.date.Month);
			BW.Write(this.date.Day);
		}

		public String Name
		{
			get
			{
				return this.name;
			}
			set
			{
				this.name = value;
			}
		}

		public String Theme
		{
			get
			{
				return this.theme;
			}
			set
			{
				this.theme = value;
			}
		}

		public DateTime Date
		{
			get
			{
				return this.date;
			}
			set
			{
				this.date = value;
			}
		}

		public override string ToString()
		{
			return String.Format("Название: {0} | Тематика: {1} | Год издания: {2}", this.Name, this.Theme, this.Date);
		}

		public Book(String name = "unknown", String theme = "unknown", DateTime date = new DateTime())
		{
			this.Name = name;
			this.Theme = theme;
			this.Date = date;
		}
	}

	class Library
	{
		private SortedDictionary<Author, List<Book>> library = new SortedDictionary<Author, List<Book>>();

		public void AddAuthor(Author a)
		{
			this.library.Add(a, new List<Book>());
		}

		public void Add(Author a, List<Book> b)
		{
			this.library.Add(a, b);
		}

		public void ShowAll()
		{
			ICollection<Author> Authors = this.library.Keys;
			if (Authors.Count == 0)
				Console.WriteLine("На данный момент книги в нашей библиотеке отсутствуют");
			foreach (Author a in Authors)
			{
				Console.WriteLine("Автор: {0}, книги:", a);
				ICollection<Book> Books = this.library[a];
				if (Books.Count == 0)
				{
					Console.WriteLine(" * К сожалению, нам неизвестны книги данного автора :с");
					Console.WriteLine("--------------------------------------------------------------------------------");
					continue;
				}
				foreach (Book b in Books)
				{
					Console.WriteLine(b);
				}
				Console.WriteLine("--------------------------------------------------------------------------------");
			}
		}

		public void DeleteAuthor(int index)
		{
			ICollection<Author> Authors = this.library.Keys;
			int i = 0;
			foreach (Author a in Authors)
			{
				if (i++ == index - 1)
				{
					this.library.Remove(a);
					break;
				}
			}
		}

		public void AddBook(int index, Book b)
		{
			ICollection<Author> Authors = this.library.Keys;
			int i = 0;
			foreach (Author a in Authors)
			{
				if (i++ == index - 1)
				{
					this.library[a].Add(b);
					break;
				}
			}
		}

		public void DeleteBook(int index, int indexBook)
		{
			ICollection<Author> Authors = this.library.Keys;
			int i = 0;
			foreach (Author a in Authors)
			{
				if (i++ == index - 1)
				{
					ICollection<Book> Books = this.library[a];
					int j = 0;
					foreach (Book b in Books)
					{
						if (j++ != indexBook - 1)
							continue;
						this.library[a].Remove(b);
						break;
					}
					break;
				}
			}
		}

		public int ShowAuthors()
		{
			ICollection<Author> Authors = library.Keys;
			int i = 1;
			foreach (Author a in Authors)
				Console.WriteLine("{0} - {1}", i++, a);
			return i;
		}

		public int ShowByAuthor(int index)
		{
			ICollection<Author> Authors = this.library.Keys;
			int i = 0;
			foreach (Author a in Authors)
			{
				if (i++ == index - 1)
				{
					Console.WriteLine("Автор: {0}, книги:", a);
					ICollection<Book> Books = this.library[a];
					int j = 1;
					foreach (Book b in Books)
					{
						Console.WriteLine("{0} - {1}", j++, b);
					}
					Console.WriteLine("--------------------------------------------------------------------------------");
					return Books.Count;
				}
			}
			return 0;
		}

		public void ShowByTheme(String t)
		{
			ICollection<Author> Authors = this.library.Keys;
			foreach (Author a in Authors)
			{
				ICollection<Book> Books = this.library[a];
				foreach (Book b in Books)
				{
					if (b.Theme == t)
						Console.WriteLine("{0} - ({1} {2})", b, a.FirstName, a.LastName);
				}
			}
		}

		public void WriteToFile(String path)
		{
			FileStream FS = File.Open(path, FileMode.Create, FileAccess.Write);
			using (BinaryWriter BW = new BinaryWriter(FS))
			{
				ICollection<Author> Authors = this.library.Keys;
				foreach (Author a in Authors)
				{
					a.Write(BW);
					BW.Write(this.library[a].Count);
					ICollection<Book> Books = this.library[a];
					foreach (Book b in Books)
						b.Write(BW);
				}
				BW.Close();
			}
		}

		static public Library ReadFromFile(String path)
		{
			Library l = new Library();
			FileStream FS = new FileStream(Program.FilePath, FileMode.Open, FileAccess.Read);
			using (BinaryReader BR = new BinaryReader(FS))
			{
				Author tmpAuthor;
				List<Book> tmpBookList;
				int bookCount;
				while (FS.Position < FS.Length)
				{
					tmpAuthor = Author.Read(BR);
					tmpBookList = new List<Book>();
					bookCount = BR.ReadInt32();
					for (int i = 0; i < bookCount; i++)
						tmpBookList.Add(Book.Read(BR));
					l.Add(tmpAuthor, tmpBookList);
				}
				BR.Close();
			}
			return l;
		}
	}

	class Program
	{
		static String filePath = "library.dat";

		static public String FilePath
		{
			get
			{
				return filePath;
			}
		}

		static void Main(string[] args)
		{
			Library l;
			if (File.Exists(Program.FilePath))
				l = Library.ReadFromFile(Program.FilePath);
			else
				l = new Library();

			char[] seps = { '-' };
			bool flag = true;
			String select;
			do
			{
				Console.Clear();
				Console.WriteLine("1 - Добавить автора");
				Console.WriteLine("2 - Удалить автора");
				Console.WriteLine("3 - Добавить книгу");
				Console.WriteLine("4 - Удалить книгу");
				Console.WriteLine("5 - Вывести полную информацию по библиотеке");
				Console.WriteLine("6 - Вывести книги конкретного автора");
				Console.WriteLine("7 - Вывести книги конкретной тематики");
				Console.WriteLine("Любой другой символ - Выход");
				Console.Write("Выберите пункт меню: ");
				select = Console.ReadLine();
				switch (select)
				{
					case "1":
						{
							int i = 0;
							while (true)
							{
								if (i != 0)
									Console.WriteLine("Такой автор уже существует, введите другого");
								Console.Clear();
								String firstName, lastName;
								bool sex;
								DateTime birthday;

								while (true)
								{
									Console.Write("Введите имя автора: ");
									firstName = Console.ReadLine();
									if (firstName.Length == 0)
										continue;
									break;
								}
								while (true)
								{
									Console.Write("Введите фамилию автора: ");
									lastName = Console.ReadLine();
									if (firstName.Length == 0)
										continue;
									break;
								}
								while (true)
								{
									Console.Write("Введите имя автора ( м / ж ): ");
									select = Console.ReadLine();
									if (select.ToLower() == "м")
										sex = false;
									else if (select.ToLower() == "ж")
										sex = true;
									else
										continue;
									break;
								}
								while (true)
								{
									Console.Write("Введите дату рождения автора (гггг-мм-дд): ");
									select = Console.ReadLine();
									String[] tmpDate = select.Split(seps, StringSplitOptions.RemoveEmptyEntries);
									if (tmpDate.Length != 3)
										continue;
									try
									{
										birthday = new DateTime(Int32.Parse(tmpDate[0]), Int32.Parse(tmpDate[1]), Int32.Parse(tmpDate[2]));
									}
									catch { continue; }
									break;
								}

								try
								{
									l.AddAuthor(new Author(firstName, lastName, sex, birthday));
								}
								catch { continue; i++; }
								break;
							}
							Console.WriteLine("Нажмите enter, чтобы продолжить...");
							Console.ReadLine();
							break;
						}
					case "2":
						{
							Console.Clear();
							int count = l.ShowAuthors();
							while (true)
							{
								Console.Write("Введите номер автора, которого хотите удалить: ");
								select = Console.ReadLine();
								try
								{
									if (Int32.Parse(select) > count || Int32.Parse(select) <= 0)
										continue;
								}
								catch { continue; }
								break;
							}
							l.DeleteAuthor(Int32.Parse(select));
							Console.WriteLine("Нажмите enter, чтобы продолжить...");
							Console.ReadLine();
							break;
						}
					case "3":
						{
							Console.Clear();
							int count = l.ShowAuthors();
							while (true)
							{
								Console.Write("Введите номер автора, которому хотите добавить книгу: ");
								select = Console.ReadLine();
								try
								{
									if (Int32.Parse(select) > count || Int32.Parse(select) <= 0)
										continue;
								}
								catch { continue; }
								break;
							}

							String name, theme;
							DateTime dt;

							while (true)
							{
								Console.Write("Введите название книги: ");
								name = Console.ReadLine();
								if (name.Length == 0)
									continue;
								break;
							}

							while (true)
							{
								Console.Write("Введите тематику книги: ");
								theme = Console.ReadLine();
								if (theme.Length == 0)
									continue;
								break;
							}

							while (true)
							{
								Console.Write("Введите год издания книги (гггг-мм-дд): ");
								String tmp = Console.ReadLine();
								String[] tmpDate = tmp.Split(seps, StringSplitOptions.RemoveEmptyEntries);
								if (tmpDate.Length != 3)
									continue;
								try
								{
									dt = new DateTime(Int32.Parse(tmpDate[0]), Int32.Parse(tmpDate[1]), Int32.Parse(tmpDate[2]));
								}
								catch { continue; }
								break;
							}

							Book b = new Book(name, theme, dt);
							l.AddBook(Int32.Parse(select), b);
							Console.WriteLine("Нажмите enter, чтобы продолжить...");
							Console.ReadLine();
							break;
						}
					case "4":
						{
							Console.Clear();
							int count = l.ShowAuthors();
							while (true)
							{
								Console.Write("Введите номер автора, книгу которого хотите удалить: ");
								select = Console.ReadLine();
								try
								{
									if (Int32.Parse(select) > count || Int32.Parse(select) <= 0)
										continue;
								}
								catch { continue; }
								break;
							}
							Console.Clear();
							int countBooks = l.ShowByAuthor(Int32.Parse(select));
							String selectBook;
							while (true)
							{
								Console.Write("Введите номер книги, которого хотите удалить: ");
								selectBook = Console.ReadLine();
								try
								{
									if (Int32.Parse(selectBook) > countBooks || Int32.Parse(selectBook) <= 0)
										continue;
								}
								catch { continue; }
								break;
							}
							l.DeleteBook(Int32.Parse(select), Int32.Parse(selectBook));
							Console.WriteLine("Нажмите enter, чтобы продолжить...");
							Console.ReadLine();
							break;
						}
					case "5":
						{
							Console.Clear();
							l.ShowAll();
							Console.WriteLine("Нажмите enter, чтобы продолжить...");
							Console.ReadLine();
							break;
						}
					case "6":
						{
							Console.Clear();
							int count = l.ShowAuthors();
							while (true)
							{
								Console.Write("Введите номер автора, книги которого хотите вывести: ");
								select = Console.ReadLine();
								try
								{
									if (Int32.Parse(select) > count || Int32.Parse(select) <= 0)
										continue;
								}
								catch { continue; }
								break;
							}
							Console.Clear();
							l.ShowByAuthor(Int32.Parse(select));
							Console.WriteLine("Нажмите enter, чтобы продолжить...");
							Console.ReadLine();
							break;
						}
					case "7":
						{
							Console.Clear();
							while (true)
							{
								Console.Write("Введите тематику, по которой хотите найти книги: ");
								select = Console.ReadLine();
								if (select.Length == 0)
									continue;
								break;
							}
							l.ShowByTheme(select);
							Console.WriteLine("Нажмите enter, чтобы продолжить...");
							Console.ReadLine();
							break;
						}
					default:
						flag = false;
						break;
				}
			} while (flag);

			l.WriteToFile(Program.FilePath);
		}
	}
}
