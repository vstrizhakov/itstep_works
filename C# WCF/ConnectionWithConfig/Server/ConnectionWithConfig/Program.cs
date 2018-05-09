using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace WcfServerTwo
{
	class Program
	{
		static void Main(string[] args)
		{
			ServiceHost service = new ServiceHost(typeof(CalcService));
			service.Open();
			Console.WriteLine("Для остановки работы сервера нажминет любую клавишу...");
			Console.ReadKey(false);
			service.Close();
		}
	}

	[ServiceContract]
	public class CalcService
	{
		[OperationContract]
		public double plus(double a, double b)
		{
			return a + b;
		}

		[OperationContract]
		public double minus(double a, double b)
		{
			return a - b;
		}

		[OperationContract]
		public double multiply(double a, double b)
		{
			return a * b;
		}

		[OperationContract]
		public double division(double a, double b)
		{
			return a / b;
		}
	}
}
