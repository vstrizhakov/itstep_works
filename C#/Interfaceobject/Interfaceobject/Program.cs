using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaceobject
{
	interface Test
	{
		void TestMethod();
	}

	class ClassOne : Test
	{
		public void MethodOne()
		{
			Console.WriteLine("Method One");
		}

		public void TestMethod()
		{
			Console.WriteLine("ClassOne Test Method");
		}
	}

	class ClassTwo
	{
		public void MethodTwo()
		{
			Console.WriteLine("ClassTwo Method Two");
		}
	}

	interface IOne
	{
		void Show();
	}

	interface ITwo
	{
		void Show();
	}

	class SomeClass : IOne, ITwo
	{
		public void Show() // неявно
		{
			Console.WriteLine("Method Show(); from IOne");
		}

		void ITwo.Show() // явно
		{
			Console.WriteLine("Method Show(); from ITwo");
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			ClassOne CO = new ClassOne();
			if (CO is Test)
			{
				Console.WriteLine("ClassOne do the interface");
			}
			else
			{
				Console.WriteLine("ClassOne don`t do the interface");
			}
			ClassTwo CT = new ClassTwo();
			if (CT is Test)
			{
				Console.WriteLine("ClassTwo do the interface");
			}
			else
			{
				Console.WriteLine("ClassTwo don`t do the interface");
			}
		}
	}
}
