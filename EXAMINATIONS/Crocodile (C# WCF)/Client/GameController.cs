using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;
using CrocodileServer;
using System.Net;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace Client
{
	public delegate void manager();
	static class GameController
	{
		static public event manager OnPlayersCountChanged;
		static public event manager OnChatChanged;
		static private ServerService Client;
		static private ServiceHost Server;
		static public String Username { get; set; } = "Пользователь #";
		static private int playersCount = 0;
		static public int PlayersCount
		{
			set
			{
				GameController.playersCount = value;				
				GameController.OnPlayersCountChanged();
			}
			get
			{
				return GameController.playersCount;
			}
		}
		static public List<String> Chat;

		static public int Connect(String username)
		{
			try
			{
				ChannelFactory<ServerService> channelFactory = new ChannelFactory<ServerService>("MyConfig");
				GameController.Client = channelFactory.CreateChannel();

				short port = GameController.GetAvailablePort();
				String ip = GameController.GetThisIP();
				String uri = String.Format("net.tcp://{0}:{1}/ServerService", ip, port);

				GameController.Server = new ServiceHost(typeof(ClientService), new Uri(uri));
				GameController.Server.AddServiceEndpoint(typeof(ClientService), new NetTcpBinding(SecurityMode.None), "");
				GameController.Server.Open();

				String answer = GameController.Client.Connect(uri, username);
				if (answer == "ERROR")
					return -1;
				String[] ss = answer.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
				GameController.Username = ss[0];
				GameController.PlayersCount = Int32.Parse(ss[1]);
				return 0;
			}
			catch
			{
				return -1;
			}
		}

		static public void Disconnect()
		{
			try
			{
				GameController.Client.Disconnect();
			}
			catch { }
			try
			{
				GameController.Server.Close();
			}
			catch { }
		}

		static public int ChangeNickName(String name)
		{
			try
			{
				String answer = GameController.Client.ChangeNickName(name);
				String[] ss = answer.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
				switch (ss[0])
				{
					case "OK":
						GameController.Username = ss[1];
						break;
					case "ERROR":
						System.Windows.Forms.MessageBox.Show(ss[1]);
						break;
				}
				return 0;
			}
			catch
			{
				return -1;
			}
		}

		static public Room EnterRoom(int type)
		{
			try
			{
				Room R = GameController.Client.FindRoom(type);
				GameController.Chat = GameController.Client.GetChat();
				GameController.OnChatChanged();
				return R;
			}
			catch
			{
				return null;
			}
		}

		static public String GetWord()
		{
			try
			{
				return GameController.Client.GetWord();
			}
			catch
			{
				return "-1";
			}
		}
		
		static public bool SetWord(String word)
		{
			try
			{
				GameController.Client.SetWord(word);
				return false;
			}
			catch
			{
				return true;
			}
		}

		static public int LeaveRoom()
		{
			try
			{
				GameController.Client.LeaveRoom();
				return 0;
			}
			catch
			{
				return -1;
			}
		}

		static public String SendMessage(String message)
		{
			return GameController.Client.SendMessage(message);
		}

		static public void AddMessage(String message)
		{
			GameController.Chat.Add(message);
			GameController.OnChatChanged();
		}

		static private short GetAvailablePort()
		{
			IPEndPoint[] IPs;
			List<int> occupiedPorts = new List<int>();
			int startPort = 5000;

			IPGlobalProperties IPGP = IPGlobalProperties.GetIPGlobalProperties();
			TcpConnectionInformation[] tcpConnections = IPGP.GetActiveTcpConnections();
			occupiedPorts.AddRange(from t in tcpConnections where t.LocalEndPoint.Port >= startPort select t.LocalEndPoint.Port);
			IPs = IPGP.GetActiveTcpListeners();
			occupiedPorts.AddRange(from t in IPs where t.Port >= startPort select t.Port);
			IPs = IPGP.GetActiveUdpListeners();
			occupiedPorts.AddRange(from t in IPs where t.Port >= startPort select t.Port);
			occupiedPorts.Sort();

			int availablePort = 5000;

			for (int i = startPort; i < short.MaxValue; i++)
				if (!occupiedPorts.Contains(i))
				{
					availablePort = i;
					break;
				}

			return (short)availablePort;
		}

		static private String GetThisIP()
		{
			String host = Dns.GetHostName();
			IPHostEntry ipEnrty = Dns.GetHostEntry(host);
			IPAddress[] IPs = ipEnrty.AddressList;
			IPAddress thisIP = null;
			Regex regEx = new Regex(@"([0-9]{1,3}\.){3}[0-9]{1,3}");
			foreach (IPAddress ip in IPs)
				if (regEx.IsMatch(ip.ToString()))
					thisIP = ip;
			return thisIP.ToString();
		}
	}

	[ServiceContract]
	class ClientService
	{
		[OperationContract]
		public void SendPlayersCount(int count)
		{
			GameController.PlayersCount = count;
		}

		[OperationContract]
		void SendMessage(String message)
		{
			GameController.AddMessage(message);
		}
	}	
}

namespace CrocodileServer
{
	[ServiceContract]
	interface ServerService
	{
		[OperationContract]
		String Connect(String address, String username);

		[OperationContract]
		void Disconnect();

		[OperationContract]
		String ChangeNickName(String nickname);

		[OperationContract]
		Room FindRoom(int type);

		[OperationContract]
		String GetWord();

		[OperationContract]
		void SetWord(String word);

		[OperationContract]
		bool CheckWord(String word);

		[OperationContract]
		void LeaveRoom();

		[OperationContract]
		List<String> GetChat();

		[OperationContract]
		String SendMessage(String message);
	}

	[DataContract]
	public class Room
	{
		[DataMember]
		public List<String> Users { get; set; }
		[DataMember]
		public String PainterName { get; set; }
		[DataMember]
		public Image Image { get; set; }
	}
}