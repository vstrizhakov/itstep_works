using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;
using Server;
using System.Net;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;

namespace Client
{
	class Program
	{
		static void Main(string[] args)
		{
			ChannelFactory<ServerService> channelFactory = new ChannelFactory<ServerService>("MyConfig");
			ServerService client = channelFactory.CreateChannel();

			IPEndPoint[] endPoints;
			List<int> portArray = new List<int>();

			int startingPort = 5000;
			IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
			TcpConnectionInformation[] connections = properties.GetActiveTcpConnections();
			portArray.AddRange(from n in connections where n.LocalEndPoint.Port >= startingPort select n.LocalEndPoint.Port);
			endPoints = properties.GetActiveTcpListeners();
			portArray.AddRange(from n in endPoints where n.Port >= startingPort select n.Port);
			endPoints = properties.GetActiveUdpListeners();
			portArray.AddRange(from n in endPoints where n.Port >= startingPort select n.Port);
			portArray.Sort();
			int port = 0;
			for (int i = startingPort; i < short.MaxValue; i++)
				if (!portArray.Contains(i))
				{
					port = i;
					break;
				}

			String strHostName = Dns.GetHostName();
			IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);
			IPAddress[] addr = ipEntry.AddressList;
			IPAddress ip = null;
			Regex regEx = new Regex(@"[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}");
			for (int i = 0; i < addr.Length; i++)
			{
				Console.WriteLine(addr[i]);
				if (regEx.IsMatch(addr[i].ToString()) == true)
				{
					ip = addr[i];
					break;
				}
			}
			String uri = String.Format("net.tcp://{0}:{1}/ClientService", ip, port);
			Console.WriteLine(uri);
			ServiceHost serviceHost = new ServiceHost(typeof(ClientService), new Uri(uri));
			serviceHost.AddServiceEndpoint(typeof(ClientService), new NetTcpBinding(), "");
			serviceHost.Open();

			client.LogIn(uri);

			String line;
			while ((line = Console.ReadLine()) != "")
			{
				client.Hello(line);
			}
		}
	}

	[ServiceContract]
	class ClientService
	{
		[OperationContract]
		public String Send(String msg)
		{
			Console.WriteLine(msg);
			return msg;
		}
	}
}

namespace Server
{
	[ServiceContract]
	interface ServerService
	{
		[OperationContract]
		String Hello(String name);

		[OperationContract]
		void LogIn(String address);
	}
}
