using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
	public delegate void manager();

	class Aeroplan
	{
		public event manager M;
		//private manager M;

		//public void AddManager(manager M)
		//{
		//	this.M += M;
		//}

		//public void RemoveManager(manager M)
		//{
		//	this.M -= M;
		//}

		public void Fly()
		{
			ConsoleKeyInfo CKI;
			do
			{
				CKI = Console.ReadKey(true);
				if (M != null)
				{
					M();
				}
			} while (CKI.Key != ConsoleKey.Escape);
		}
	}

	class Terrorist
	{
		public void TerrorAction()
		{
			Console.WriteLine("Немедленно лететь в ИГ! Аллах акбар бабах");
		}
	}

	class Manager
	{
		private String city;
		private String name;

		public Manager(String city, String name)
		{
			this.city = city;
			this.name = name;
		}

		public void WorkMessage()
		{
			Console.WriteLine("Город: {0}, Диспетчер: {1}", this.city, this.name);
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			Manager m1 = new Manager("Киев", "Петров");
			Manager m2 = new Manager("Черкассы", "Черновцы");
			Manager m3 = new Manager("Одесса", "Запорожье");
			Aeroplan A = new Aeroplan();
			A.M += m1.WorkMessage;
			A.M += m2.WorkMessage;
			A.M += m3.WorkMessage;

			Terrorist BenLaden = new Terrorist();
			A.M += BenLaden.TerrorAction;
			A.Fly();
		}
	}
}
