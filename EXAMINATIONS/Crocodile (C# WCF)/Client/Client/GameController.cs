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
using System.IO;

namespace Client
{
	public delegate void manager();
	static class GameController
	{
		static public event manager OnPlayersCountChanged;
		static public event manager OnChatChanged;
		static public event manager OnImageChanged;
		static public event manager OnSecondsLeftChanged;
		static public event manager OnPainterChanged;
		static private ServerService Client;
		static private ServiceHost Server;
		static public String Username { get; set; } = "Пользователь #";
		static private Bitmap img;
		static private ImageConverter IC = new ImageConverter();
		static public Bitmap Img
		{
			get
			{
				return GameController.img;
			}
			set
			{
				GameController.img = value;
				if (GameController.OnImageChanged != null)
					GameController.OnImageChanged();
			}
		}
		static private int playersCount = 0;
		static public int PlayersCount
		{
			set
			{
				GameController.playersCount = value;
				if (GameController.OnPlayersCountChanged != null)
					GameController.OnPlayersCountChanged();
			}
			get
			{
				return GameController.playersCount;
			}
		}
		static public List<String> Chat = new List<String>();
		static private int secondsLeft = 300;
		static public int SecondsLeft
		{
			get
			{
				return GameController.secondsLeft;
			}
			set
			{
				GameController.secondsLeft = value;
				if (GameController.OnSecondsLeftChanged != null)
					GameController.OnSecondsLeftChanged();
			}
		}
		static private String painter;
		static public String Painter
		{
			get
			{
				return GameController.painter;
			}
			set
			{
				GameController.painter = "Рисует: " + value;
				if (GameController.OnPainterChanged != null)
					GameController.OnPainterChanged();
			}
		}
		static private Regex enteredRoom = new Regex(@"В комнату зашел ([^:]*) \(рисует\)", RegexOptions.Singleline);

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
				GameController.Server.AddServiceEndpoint(typeof(ClientService), new NetTcpBinding("netTcpBinding_Crocodile"), "");
				GameController.Server.Open();

				String answer = GameController.Client.Connect(uri, username);
				if (answer == "ERROR|")
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
				if (R.Image != null)
				{
					Image i = (Image)GameController.IC.ConvertFrom(R.Image);
					GameController.Img = new Bitmap(i);
				}
				else
					GameController.Img = null;
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
				GameController.Painter = null;
				GameController.SecondsLeft = 300;
				GameController.Img = null;
				return 0;
			}
			catch
			{
				return -1;
			}
		}

		static public String SendMessage(String message)
		{
			try
			{
				String res = GameController.Client.SendMessage(message);
				if (res == "NOTOK|")
					throw new Exception("");
				return res;
			}
			catch
			{
				return "-1";
			}
		}

		static public void AddMessage(String message)
		{
			if (GameController.Chat != null)
			{
				GameController.Chat.Add(message);
				Match M = GameController.enteredRoom.Match(message);
				if (M.Success == true)
					GameController.Painter = M.Groups[1].Value;
			}
			if (GameController.OnChatChanged != null)
				GameController.OnChatChanged();
		}

		static public int SendImage(Bitmap img)
		{
			try
			{
				byte[] a = (byte[])GameController.IC.ConvertTo(img, typeof(byte[]));
				MyData MD = new MyData() { img = a };
				if (GameController.Client.SendImage(MD) == 1)
					throw new Exception("");
				return 0;
			}
			catch
			{
				return -1;
			}
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
	[ServiceBehavior(IncludeExceptionDetailInFaults = true, ConcurrencyMode = ConcurrencyMode.Multiple, AutomaticSessionShutdown = false)]
	public class ClientService
	{
		static private ImageConverter IC = new ImageConverter();

		[OperationContract]
		public void SendPlayersCount(int count)
		{
			GameController.PlayersCount = count;
		}

		[OperationContract]
		public void SendMessage(String message)
		{
			GameController.AddMessage(message);
		}

		[OperationContract]
		public bool CheckOnline()
		{
			return true;
		}

		[OperationContract]
		public void SendImage(MyData img)
		{
			Image i = (Image)ClientService.IC.ConvertFrom(img.img);
			GameController.Img = new Bitmap(i);
			i.Dispose();
		}

		[OperationContract]
		public void SendTimer(int seconds)
		{
			GameController.SecondsLeft = seconds;
		}
	}
}

namespace CrocodileServer
{
	[DataContract]
	public class MyData
	{
		[DataMember]
		public byte[] img;
	}

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
		void LeaveRoom();

		[OperationContract]
		List<String> GetChat();

		[OperationContract]
		String SendMessage(String message);

		[OperationContract]
		int SendImage(MyData img);
	}

	[DataContract]
	public class Room
	{
		[DataMember]
		public uint Id { get; set; }
		[DataMember]
		public String PainterName { get; set; }
		[DataMember]
		public byte[] Image { get; set; }
	}
}