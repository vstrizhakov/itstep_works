using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace WcfServerTwo
{
	[ServiceContract]
	public interface CalcService
	{
		[OperationContract]
		double plus(double a, double b);

		[OperationContract]
		double minus(double a, double b);

		[OperationContract]
		double multiply(double a, double b);

		[OperationContract]
		double division(double a, double b);
	}
}

namespace WcfClientTwo
{
	class Program
	{
		static void Main(string[] args)
		{
			//ChannelFactory<WcfServerTwo.CalcService> channelFactory = new ChannelFactory<WcfServerTwo.CalcService>(new NetTcpBinding(), new EndpointAddress("net.tcp://10.3.60.42:5000/WcfServerTwo"));
			//WcfServerTwo.CalcService wcfClient = channelFactory.CreateChannel();

			ChannelFactory<WcfServerTwo.CalcService> channelFactory = new ChannelFactory<WcfServerTwo.CalcService>("MyConfig");
			WcfServerTwo.CalcService wcfClient = channelFactory.CreateChannel();

			Console.WriteLine("4 + 7 = {0}", wcfClient.plus(4, 7));
			Console.WriteLine("4 - 7 = {0}", wcfClient.minus(4, 7));
			Console.WriteLine("4 * 7 = {0}", wcfClient.multiply(4, 7));
			Console.WriteLine("4 / 7 = {0}", wcfClient.division(4, 7));
		}
	}
}
