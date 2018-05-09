using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace WcfServerEx
{
	[ServiceContract]
	interface UpperLowerCaseService
	{
		[OperationContract]
		String toLowerCase(String str);

		[OperationContract]
		String toUpperCase(String str);

		[OperationContract]
		String reverse(String str);
	}
}

namespace Client
{
	class Program
	{
		static void Main(string[] args)
		{
			ChannelFactory<WcfServerEx.UpperLowerCaseService> factory = new ChannelFactory<WcfServerEx.UpperLowerCaseService>(new NetTcpBinding(), new EndpointAddress("net.tcp://10.3.60.193:7000/WcfServerEx"));
			WcfServerEx.UpperLowerCaseService wcfClient = factory.CreateChannel();

			String str = "Hello world";
			Console.WriteLine("Upper: {0}", wcfClient.toUpperCase(str));
			Console.WriteLine("Lower: {0}", wcfClient.toLowerCase(str));
			Console.WriteLine("Reverse: {0}", wcfClient.reverse(str));
		}
	}
}
