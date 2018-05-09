using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.Threading;
using Client;
using System.ServiceModel.Channels;

namespace Server
{
	class Program
	{
		static void Main(string[] args)
		{
			ServiceHost serviceHost = new ServiceHost(typeof(ServerService));
			serviceHost.Open();
			Console.ReadKey(true);
			serviceHost.Close();
		}
	}

	[ServiceContract(SessionMode = SessionMode.Required)]
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
	class ServerService
	{
		private ClientService Client;
		static private List<ClientService> AllClients = new List<ClientService>();

		[OperationContract]
		public void LogIn(String address)
		{
			try
			{
				ChannelFactory<ClientService> channelFactory = new ChannelFactory<ClientService>(new NetTcpBinding(), new EndpointAddress(address));
				Console.WriteLine(address);
				this.Client = channelFactory.CreateChannel();
				ServerService.AllClients.Add(this.Client);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}

		[OperationContract]
		public String Hello(String name)
		{
			try
			{
				foreach (ClientService CS in ServerService.AllClients)
					CS.Send(name);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
			return "OK";
		}
	}
}

namespace Client
{
	[ServiceContract]
	interface ClientService
	{
		[OperationContract]
		String Send(String msg);
	}
}
