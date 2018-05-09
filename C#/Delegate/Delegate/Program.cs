using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Delegate
{
	public delegate int calc(int a, int b);
	public delegate void greeting(string name);

	class Program
	{
		static void Hello(string msg)
		{
			for (int i = 0; i < 10; i++)
			{
				Console.WriteLine("Метод Hello() работает: {0}", msg);
				Thread.Sleep(750);
			}
		}
		static void Main(string[] args)
		{
			greeting g = new greeting(Hello);
			int i = 0;
			g.BeginInvoke(i++.ToString(), null, null);
			while (Console.KeyAvailable != true)
			{
				Console.WriteLine("Работает первичный поток");
				Thread.Sleep(1000);
			}
		}
	}
}
