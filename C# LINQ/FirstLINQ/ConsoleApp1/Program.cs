using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	class Program
	{
		delegate bool abc (int a);

		static bool exampleForTakeWhile(int a)
		{
			return a <= 4;
		}

		static void ShowSum(int a, int b)
		{
			Console.WriteLine("Сумма: {0}", a + b);
		}

		static int ReturnSum(int a, int b)
		{
			return a + b;
		}

		static void Main(string[] args)
		{
			int[] ar = { 1,2,3,4,5,6,7,8,9,10 };
			foreach (var value in ar)
				Console.WriteLine(value);
			Console.WriteLine("===============");
			var arr2 = from a in ar where a > 3 && a < 8 select a;
			Console.WriteLine(arr2.GetType());
			foreach(var value in arr2)
				Console.WriteLine(value + ":" + value.GetType());
			Console.WriteLine("===============");
			Action<int, int> A1 = ShowSum;
			A1(7, 8);
			Console.WriteLine("===============");
			Func<int, int, int> F1 = ReturnSum;
			int result = F1(5, 8);
			Console.WriteLine("result = {0}", result); ;
			Console.WriteLine("===============");

			Func<int, bool> A = exampleForTakeWhile;
			int[] arr = { 1,2,3,4,5,6,7,8,9,10, 0, 1, 2, 3 };
			var arr3 = arr.TakeWhile(A);

			foreach (var value in arr3)
				Console.WriteLine(value);

			//или
			Console.WriteLine("===============");

			int[] arr4 = { 1,2,3,4,5,6,7,8,10,1,2,3 };
			var ar5 = arr.TakeWhile(
					delegate(int a)
					{
						return a <= 4;
					}
				);
			foreach (var value in ar5)
				Console.WriteLine(value);
			Console.WriteLine("===============");
			// Лямбда выражения
			int[] ar1 = { 1,2,3,4,5,6,7,8,9,10,1,2,3 };
			var ar2 = arr.TakeWhile(
				(int a) =>
				{
					return a <= 4;
				}
				);
			foreach (var value in arr3)
				Console.WriteLine(ar5);
			Console.WriteLine("===============");

			int[] arr8 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 1, 2, 3 };
			var ar3 = arr.TakeWhile(a => a <= 4);
			foreach (var value in arr8)
				Console.WriteLine(ar3);
			Console.WriteLine("===============");
			() =>
			{

			}
		}
	}
}
