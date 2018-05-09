using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace WcfServerEx
{
	class Program
	{
		static void Main(string[] args)
		{
			ServiceHost serviceHost = new ServiceHost(typeof(UpperLowerCaseService), new Uri("net.tcp://10.3.60.193:7000/WcfServerEx"));
			serviceHost.AddServiceEndpoint(typeof(UpperLowerCaseService), new NetTcpBinding(), "");
			serviceHost.Open();

			Console.WriteLine("Для завершения работы сервера нажмите любую клавишу");
			Console.ReadKey(false);
			serviceHost.Close();
		}
	}

	[ServiceContract]
	public class UpperLowerCaseService
	{
		[OperationContract]
		public String toLowerCase(String str)
		{
			return str.ToLower();
		}

		[OperationContract]
		public String toUpperCase(String str)
		{
			return str.ToUpper();
		}

		[OperationContract]
		public String reverse(String str)
		{
			char[] c = str.ToCharArray();
			Array.Reverse(c);
			return new string(c);
		}
	}
}
