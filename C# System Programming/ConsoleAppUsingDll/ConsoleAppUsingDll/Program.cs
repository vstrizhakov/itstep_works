using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinDLL;

namespace ConsoleAppUsingDll
{
	class Program
	{
		static void Main(string[] args)
		{
			Auto A = new Auto("Daewoo", "Lanos", 2000);
			Console.WriteLine(A);

			MyForm F = new MyForm();
			F.ShowDialog();
		}
	}
}
