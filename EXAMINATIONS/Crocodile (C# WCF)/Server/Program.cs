using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;
using Client;
using System.Threading;
using System.Drawing;
using System.IO;
using System.ServiceModel.Channels;
using System.Net;

namespace CrocodileServer
{
	class Program
	{
		static void Main(string[] args)
		{
			ServiceHost Server = new ServiceHost(typeof(ServerService));
			Server.Open();
			ServerService.LoadDictionary("word_rus.txt");

			Thread T = new Thread(ServerService.CheckUsersOnline);
			T.IsBackground = true;
			T.Start();

			T = new Thread(ServerService.TimerTick);
			T.IsBackground = true;
			T.Start();

			Console.WriteLine("Сервер успешно запущен!\nДля того, чтобы остановить сервер, нажмите любую клавишу...");
			Console.ReadKey(true);
			Server.Close();
		}
	}

	[ServiceContract(SessionMode = SessionMode.Required)]
	[ServiceBehavior(AddressFilterMode = AddressFilterMode.Any, ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.PerSession, AutomaticSessionShutdown = false, IncludeExceptionDetailInFaults = true)]
	class ServerService
	{
		private ClientService Client;
		static private Dictionary<ClientService, String> Users = new Dictionary<ClientService, String>();
		static private Dictionary<String, ClientService> UsersIP = new Dictionary<String, ClientService>();
		static private Dictionary<Room, List<String>> Chats = new Dictionary<Room, List<String>>();
		static private List<Room> Rooms = new List<Room>();
		static private List<String> Dictionary;
		static private Random R = new Random();
		static private uint RoomsNumber = 0;

		static private Semaphore Sem = new Semaphore(1, 1000000);
		static private EventWaitHandle AllEWH = new EventWaitHandle(true, EventResetMode.ManualReset);
		static private EventWaitHandle WritersEWH = new EventWaitHandle(true, EventResetMode.AutoReset);

		static private void SendTimer(object obj)
		{
			object[] p = (object[])obj;
			int seconds = (int)p[1];
			ClientService CS = (ClientService)p[0];
			try { CS.SendTimer(seconds); }
			catch { }

		}

		static public void TimerTick()
		{
			List<Room> roomsToRemove = new List<Room>();
			while (true)
			{
				ServerService.AllEWH.WaitOne();
				ServerService.Sem.WaitOne();

				foreach (Room R in ServerService.Rooms)
				{
					if (R.SecondsLeft == -1)
						continue;
					foreach (ClientService CS in R.Clients)
					{
						object[] p = new object[] { CS, R.SecondsLeft };
						Thread T = new Thread(ServerService.SendTimer);
						T.IsBackground = true;
						T.Start(p);
					}
					if (R.SecondsLeft >= 0)
						R.SecondsLeft--;
					if (R.SecondsLeft < 0)
						roomsToRemove.Add(R);
				}

				ServerService.Sem.Release();

				ServerService.WritersEWH.WaitOne();
				ServerService.AllEWH.Reset();
				for (int i = 0; i <= ServerService.Users.Count; i++)
					ServerService.Sem.WaitOne();

				foreach (Room R in roomsToRemove)
				{
					Console.WriteLine("Комната #{0} закрыта", R.Id);
					ServerService.Rooms.Remove(R);
					ServerService.Chats.Remove(R);
				}
				roomsToRemove.Clear();

				for (int i = 0; i <= ServerService.Users.Count; i++)
					ServerService.Sem.Release();
				ServerService.AllEWH.Set();
				ServerService.WritersEWH.Set();
				Thread.Sleep(1000);
			}
		}

		static public void LoadDictionary(String filename)
		{
			FileStream FS = new FileStream(filename, FileMode.Open, FileAccess.Read);
			StreamReader SR = new StreamReader(FS);
			String dict = SR.ReadToEnd();
			SR.Close();
			ServerService.Dictionary = dict.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries).ToList();
			Console.WriteLine("Загружено {0} слов", ServerService.Dictionary.Count);
		}

		static public void CheckUsersOnline()
		{
			while (true)
			{
				List<ClientService> clientsToRemove = new List<ClientService>();

				ServerService.AllEWH.WaitOne();
				ServerService.Sem.WaitOne();

				ICollection<ClientService> Clients = ServerService.Users.Keys;
				foreach (ClientService CS in Clients)
				{
					try { CS.CheckOnline(); }
					catch { clientsToRemove.Add(CS); }

				}

				ServerService.Sem.Release();

				foreach (ClientService CS in clientsToRemove)
					ServerService.RemoveUserFromServer(CS);

				Thread.Sleep(1000);
			}
		}

		[OperationContract]
		public String Connect(String address, String username)
		{
			List<ClientService> clientsToRemove = new List<ClientService>();
			try
			{
				ServerService.WritersEWH.WaitOne();
				ServerService.AllEWH.Reset();
				for (int i = 0; i <= ServerService.Users.Count; i++)
					ServerService.Sem.WaitOne();

				ChannelFactory<ClientService> channelFactory = new ChannelFactory<ClientService>(new NetTcpBinding("MyBinding"), new EndpointAddress(address));
				this.Client = channelFactory.CreateChannel();
				String name = "Пользователь #";
				if (name == username)
				{
					if (!ServerService.Users.ContainsKey(this.Client))
					{
						int i = 0;
						foreach (KeyValuePair<ClientService, String> user in ServerService.Users)
						{
							if (Int32.Parse(user.Value.Remove(0, 14)) != i)
							{
								name += i;
								break;
							}
							i++;
						}
						if (name == "Пользователь #")
							name += i;
					}
				}
				else
					name = username;

				Console.WriteLine("Подключен клиент: {0} ({1})", address, name);
				String ip = ServerService.GetClientIP(OperationContext.Current);

				ICollection<String> ips = ServerService.UsersIP.Keys;
				foreach (String i in ips)
				{
					if (i.Contains(ip))
					{
						try { ServerService.UsersIP[i].CheckOnline(); }
						catch (Exception e) { Console.WriteLine(e.Message); clientsToRemove.Add(ServerService.UsersIP[i]); }
					}
				}

				ServerService.Users.Add(this.Client, name);
				ServerService.UsersIP.Add(address, this.Client);
				return name + "|" + ServerService.Users.Count;
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				return "ERROR|" + e.Message;
			}
			finally
			{
				for (int i = 0; i <= ServerService.Users.Count; i++)
					ServerService.Sem.Release();
				ServerService.AllEWH.Set();
				ServerService.WritersEWH.Set();

				Thread T = new Thread(ServerService.InformClientsPlayersCount);
				T.IsBackground = true;
				T.Start(this.Client);

				foreach (ClientService CS in clientsToRemove)
					ServerService.RemoveUserFromServer(CS);
			}
		}

		[OperationContract]
		public void LeaveRoom()
		{
			ServerService.RemoveUserFromRooms(this.Client);
		}

		[OperationContract]
		public void Disconnect()
		{
			ServerService.RemoveUserFromServer(this.Client);
		}

		static private string GetClientIP(OperationContext context)
		{
			MessageProperties prop = context.IncomingMessageProperties;
			RemoteEndpointMessageProperty endpoint = prop[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
			return endpoint.Address;
		}

		static private void RemoveUserFromServer(ClientService CS)
		{
			try
			{
				List<String> ipsToRemove = new List<string>();

				ServerService.RemoveUserFromRooms(CS);

				ServerService.WritersEWH.WaitOne();
				ServerService.AllEWH.Reset();
				for (int i = 0; i <= ServerService.Users.Count; i++)
					ServerService.Sem.WaitOne();

				if (!ServerService.Users.ContainsKey(CS))
					return;

				Console.WriteLine("\"{0}\" отключился", ServerService.Users[CS]);

				ServerService.Users.Remove(CS);

				ICollection<String> ips = ServerService.UsersIP.Keys;
				foreach (String ip in ips)
					if (ServerService.UsersIP[ip] == CS)
						ipsToRemove.Add(ip);

				foreach (String ip in ipsToRemove)
					ServerService.UsersIP.Remove(ip);
			}
			catch (Exception a)
			{
				Console.WriteLine(a.Message);
			}
			finally
			{
				for (int i = 0; i <= ServerService.Users.Count; i++)
					ServerService.Sem.Release();
				ServerService.AllEWH.Set();
				ServerService.WritersEWH.Set();

				Thread T = new Thread(ServerService.InformClientsPlayersCount);
				T.IsBackground = true;
				T.Start();
			}
		}

		static private void RemoveUserFromRooms(ClientService CS)
		{
			List<KeyValuePair<Room, String>> messages = new List<KeyValuePair<Room, String>>();

			ServerService.WritersEWH.WaitOne();
			ServerService.AllEWH.Reset();
			for (int i = 0; i <= ServerService.Users.Count; i++)
				ServerService.Sem.WaitOne();

			foreach (Room R in ServerService.Rooms)
			{
				if (R.Clients.Contains(CS))
				{
					Console.WriteLine("\"{0}\" покинул комнату #{1}", ServerService.Users[CS], R.Id);
					String msg = String.Format("{0} покинул комнату", ServerService.Users[CS]);
					messages.Add(new KeyValuePair<Room, String>(R, msg));
					ServerService.Chats[R].Add(msg);
					R.Clients.Remove(CS);
					R.Users.Remove(ServerService.Users[CS]);
					if (R.Clients.Count == 0)
						R.SecondsLeft = 0;
					if (R.ClientPainter == CS)
						// Вышел игрок, который рисует, закрытие комнаты
						R.SecondsLeft = -3;
				}
			}

			for (int i = 0; i <= ServerService.Users.Count; i++)
				ServerService.Sem.Release();
			ServerService.AllEWH.Set();
			ServerService.WritersEWH.Set();

			foreach (KeyValuePair<Room, String> p in messages)
			{
				Thread T = new Thread(ServerService.InformClientsMessage);
				T.IsBackground = true;
				T.Start(p);
			}
		}

		[OperationContract]
		public String ChangeNickName(String nickname)
		{
			String returnMsg = "";

			ServerService.WritersEWH.WaitOne();
			ServerService.AllEWH.Reset();
			for (int i = 0; i <= ServerService.Users.Count; i++)
				ServerService.Sem.WaitOne();

			Console.WriteLine("Игрок \"{0}\" пытается изменить ник на \"{1}\"", ServerService.Users[this.Client], nickname);
			if (nickname.Trim() == "")
				returnMsg = "ERROR|Нельзя сделать ник пустым!";
			else if (!ServerService.Users.ContainsValue(nickname) || ServerService.Users[this.Client] == nickname)
			{
				Console.WriteLine("Игрок \"{0}\" изменил ник на \"{1}\"", ServerService.Users[this.Client], nickname);
				ServerService.Users[this.Client] = nickname;
				returnMsg = "OK|" + nickname;
			}
			else
				returnMsg = "ERROR|Игрок с таким именем уже существует";

			for (int i = 0; i <= ServerService.Users.Count; i++)
				ServerService.Sem.Release();
			ServerService.AllEWH.Set();
			ServerService.WritersEWH.Set();

			return returnMsg;
		}

		static private void InformClientsPlayersCount(object Client)
		{
			List<ClientService> clientsToRemove = new List<ClientService>();

			ServerService.AllEWH.WaitOne();
			ServerService.Sem.WaitOne();

			ClientService thisClient = (ClientService)Client;
			foreach (KeyValuePair<ClientService, String> CS in ServerService.Users)
			{
				lock (CS.Key)
				{
					if (CS.Key != thisClient)
					{
						try
						{
							CS.Key.SendPlayersCount(ServerService.Users.Count);
						}
						catch (Exception e)
						{
							Console.WriteLine(e.Message);
							clientsToRemove.Add(CS.Key);
						}
					}
				}
			}

			ServerService.Sem.Release();

			foreach (ClientService CS in clientsToRemove)
				ServerService.RemoveUserFromServer(CS);
		}

		static private void InformClientsMessage(object obj)
		{
			KeyValuePair<Room, String> p = (KeyValuePair<Room, String>)obj;
			List<ClientService> clientsToRemove = new List<ClientService>();

			ServerService.AllEWH.WaitOne();
			ServerService.Sem.WaitOne();

			Room room = p.Key;
			String message = p.Value;
			foreach (ClientService CS in room.Clients)
			{
				try
				{
					CS.SendMessage(message);
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
					clientsToRemove.Add(CS);
				}
			}

			ServerService.Sem.Release();

			foreach (ClientService CS in clientsToRemove)
				ServerService.RemoveUserFromServer(CS);
		}

		static private void InformClientsImage(object obj)
		{
			KeyValuePair<Room, MyData> p = (KeyValuePair<Room, MyData>)obj;
			List<ClientService> clientsToRemove = new List<ClientService>();

			ServerService.AllEWH.WaitOne();
			ServerService.Sem.WaitOne();

			Room room = p.Key;
			MyData img = p.Value;
			foreach (ClientService CS in room.Clients)
			{
				if (CS == room.ClientPainter)
					continue;
				try
				{
					CS.SendImage(img);
					//Console.WriteLine("Клиенту {0} отправлено {1} байт", ServerService.Users[CS], img.img.Length);
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
					clientsToRemove.Add(CS);
				}
			}

			ServerService.Sem.Release();

			foreach (ClientService CS in clientsToRemove)
				ServerService.RemoveUserFromServer(CS);
		}

		[OperationContract]
		public int SendImage(MyData img)
		{
			List<KeyValuePair<Room, MyData>> clientsToNotify = new List<KeyValuePair<Room, MyData>>();

			if (ServerService.AllEWH.WaitOne(100) == false)
				return 0;
			ServerService.Sem.WaitOne();

			int r = 1;

			//Console.WriteLine("От {0} получено {1} байт", ServerService.Users[this.Client], img.img.Length);

			foreach (Room R in ServerService.Rooms)
			{
				r = 0;
				if (R.ClientPainter == this.Client)
				{
					clientsToNotify.Add(new KeyValuePair<Room, MyData>(R, img));
					R.Image = img.img;
				}
			}

			ServerService.Sem.Release();

			foreach (KeyValuePair<Room, MyData> p in clientsToNotify)
			{
				Thread T = new Thread(ServerService.InformClientsImage);
				T.IsBackground = true;
				T.Start(p);
			}

			return r;
		}

		[OperationContract]
		public Room FindRoom(int type)
		{
			int freeRoom = -1;

			ServerService.WritersEWH.WaitOne();
			ServerService.AllEWH.Reset();
			for (int j = 0; j <= ServerService.Users.Count; j++)
				ServerService.Sem.WaitOne();

			for (int i = 0; i < ServerService.Rooms.Count; i++)
			{
				String username = ServerService.Users[this.Client];
				Room room = ServerService.Rooms[i];
				if (room.Clients.Contains(this.Client))
				{
					Console.WriteLine("\"{0}\" покинул комнату #{1}", username, room.Id);
					ServerService.RemoveUserFromRooms(this.Client);
				}
				if (room.Clients.Count < 5 && room.Clients.Count > 0)
					freeRoom = i;
			}

			Room R = null;

			if (freeRoom == -1 || type == 2 || (type == 1 && freeRoom != -1 && ServerService.Rooms[freeRoom].Clients.Count == 3 && ServerService.Rooms[freeRoom].ClientPainter is null))
			{
				R = new Room(ServerService.RoomsNumber++);
				Console.WriteLine("Создана комната #{0}", R.Id);
				if (type != 1)
				{
					R.ClientPainter = this.Client;
					R.PainterName = ServerService.Users[this.Client];
				}
				else
					R.AddUser(this.Client, ServerService.Users[this.Client]);
				ServerService.Rooms.Add(R);
				ServerService.Chats.Add(R, new List<String>());
			}
			else
			{
				R = ServerService.Rooms[freeRoom];
				if (R.ClientPainter == null && type != 1)
				{
					R.ClientPainter = this.Client;
					R.PainterName = ServerService.Users[this.Client];
				}
				R.AddUser(this.Client, ServerService.Users[this.Client]);
			}
			if (R.Clients.Count > 1 && R.SecondsLeft == -1)
				R.SecondsLeft = 300;
			Console.WriteLine("\"{0}\" зашел в комнату #{1}", ServerService.Users[this.Client], R.Id);
			String msg = String.Format("В комнату зашел {0}", ServerService.Users[this.Client] + ((this.Client == R.ClientPainter) ? " (рисует)" : ""));
			ServerService.Chats[R].Add(msg);
			KeyValuePair<Room, String> p = new KeyValuePair<Room, String>(R, msg);

			for (int i = 0; i <= ServerService.Users.Count; i++)
				ServerService.Sem.Release();
			ServerService.AllEWH.Set();
			ServerService.WritersEWH.Set();

			Thread T = new Thread(ServerService.InformClientsMessage);
			T.IsBackground = true;
			T.Start(p);
			return R;
		}

		[OperationContract]
		public String GetWord()
		{
			String word = null;
			ServerService.AllEWH.WaitOne();
			ServerService.Sem.WaitOne();
			foreach (Room R in ServerService.Rooms)
				if (R.ClientPainter == this.Client)
				{
					word = ServerService.Dictionary[ServerService.R.Next(0, ServerService.Dictionary.Count - 1)];
					Console.WriteLine("Комнате #{0} предложено слово {1}", R.Id, word);
					break;
				}
			ServerService.Sem.Release();
			return word;
		}

		[OperationContract]
		public void SetWord(String word)
		{
			ServerService.WritersEWH.WaitOne();
			ServerService.AllEWH.Reset();
			for (int i = 0; i <= ServerService.Users.Count; i++)
				ServerService.Sem.WaitOne();

			foreach (Room R in ServerService.Rooms)
				if (R.ClientPainter == this.Client)
				{
					Console.WriteLine("В комнате #{0} пользователь \"{1}\" выбрал слово {2}", R.Id, ServerService.Users[this.Client], word);
					R.Word = word;
					break;
				}

			for (int i = 0; i <= ServerService.Users.Count; i++)
				ServerService.Sem.Release();
			ServerService.AllEWH.Set();
			ServerService.WritersEWH.Set();
		}

		[OperationContract]
		public String SendMessage(String message)
		{
			if (message.Trim() == "")
				return "ERROR|Нельзя отправлять пустые сообщения!";
			if (message.Trim().Length > 120)
				return "ERROR|Слишком длинное сообщение!";
			List<KeyValuePair<Room, String>> roomsToNotify = new List<KeyValuePair<Room, string>>();
			List<Room> roomsToRemove = new List<Room>();

			ServerService.AllEWH.WaitOne();
			ServerService.Sem.WaitOne();

			String r = "NOTOK|";

			foreach (Room R in ServerService.Rooms)
			{
				r = "OK|";
				if (R.ClientPainter == this.Client)
					break;
				if (R.Clients.Contains(this.Client))
				{
					ServerService.Chats[R].Add(message.Trim());
					KeyValuePair<Room, String> p = new KeyValuePair<Room, String>(R, ServerService.Users[this.Client] + ": " + message.Trim());
					roomsToNotify.Add(p);
					Console.WriteLine("\"{0}\" в комнате #{1} отправил сообщение: {2}", ServerService.Users[this.Client], R.Id, message.Trim());

					if (message.Trim().ToUpper().Contains(R.Word) == true)
					{
						p = new KeyValuePair<Room, String>(R, String.Format("{0} угадал слово: {1}", ServerService.Users[this.Client], R.Word));
						roomsToNotify.Add(p);
						Console.WriteLine("\"{0}\" в комнате #{1} угадал слово: {2}", ServerService.Users[this.Client], R.Id, R.Word);
						roomsToRemove.Add(R);
					}
					break;
				}
			}

			ServerService.Sem.Release();

			ServerService.WritersEWH.WaitOne();
			ServerService.AllEWH.Reset();
			for (int i = 0; i <= ServerService.Users.Count; i++)
				ServerService.Sem.WaitOne();

			foreach (Room R in roomsToRemove)
				// Слово угадано, определен победитель
				R.SecondsLeft = -2;

			for (int i = 0; i <= ServerService.Users.Count; i++)
				ServerService.Sem.Release();
			ServerService.AllEWH.Set();
			ServerService.WritersEWH.Set();

			foreach (KeyValuePair<Room, String> p in roomsToNotify)
			{
				Thread T = new Thread(ServerService.InformClientsMessage);
				T.IsBackground = true;
				T.Start(p);
			}
			return r;
		}

		[OperationContract]
		public List<String> GetChat()
		{
			List<String> chat = null;

			ServerService.AllEWH.WaitOne();
			ServerService.Sem.WaitOne();

			foreach (Room R in ServerService.Rooms)
				if (R.Clients.Contains(this.Client))
					chat = ServerService.Chats[R];

			ServerService.Sem.Release();

			return chat;
		}
	}

	[DataContract]
	public class MyData
	{
		[DataMember]
		public byte[] img;
	}

	[DataContract]
	public class Room
	{
		[DataMember]
		public uint Id { get; set; }
		public List<String> Users { get; set; } = new List<String>();
		private String painterName;
		[DataMember]
		public byte[] Image { get; set; }
		[DataMember]
		public String PainterName
		{
			get
			{
				return this.painterName;
			}
			set
			{
				this.painterName = value;
				this.Users.Add(value);
			}
		}
		public List<ClientService> Clients { get; set; } = new List<ClientService>();
		public String Word { get; set; }
		private ClientService clientPainter;
		public ClientService ClientPainter
		{
			get
			{
				return this.clientPainter;
			}
			set
			{
				this.clientPainter = value;
				this.Clients.Add(value);
			}
		}
		public int SecondsLeft { get; set; } = -1;

		public void AddUser(ClientService CS, String username)
		{
			this.Clients.Add(CS);
			this.Users.Add(username);
		}

		public Room(uint id)
		{
			this.Id = id;
		}
	}
}

namespace Client
{
	[ServiceContract]
	public interface ClientService
	{
		[OperationContract]
		void SendPlayersCount(int count);

		[OperationContract]
		void SendMessage(String message);

		[OperationContract]
		bool CheckOnline();

		[OperationContract]
		int SendImage(CrocodileServer.MyData img);

		[OperationContract]
		void SendTimer(int seconds);
	}
}