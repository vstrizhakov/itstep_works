using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Configuration;

namespace Server
{
	class Program
	{
		static void Main(string[] args)
		{
			ServerThread ST = new ServerThread("192.168.0.155", 6555);
			Thread T = new Thread(ST.Run);
			T.IsBackground = true;
			T.Start();

			while (!Console.KeyAvailable)
				Thread.Sleep(500);
		}
	}

	class ServerThread
	{
		private String host;
		private int port;

		public ServerThread(String host, int port)
		{
			this.host = host;
			this.port = port;
		}

		public void Run()
		{
			try
			{
				TcpListener server = new TcpListener(IPAddress.Parse(this.host), port);
				server.Start();
				while (true)
				{
					TcpClient client = server.AcceptTcpClient();
					Console.WriteLine("Подключение: {0}", client.Client.RemoteEndPoint);

					ChatThread CT = new ChatThread(client);
					Thread T = new Thread(CT.Run);
					T.IsBackground = true;
					T.Start();
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}
	}

	class ChatThread
	{
		private TcpClient client;
		static private List<String> users = new List<String>();
		static private Dictionary<int, String> messages = new Dictionary<int, String>();
		static int lastId = -1;
		private String userName;

		public ChatThread(TcpClient client)
		{
			this.client = client;
		}

		public void Run()
		{
			String clientIP = this.client.Client.RemoteEndPoint.ToString();
			NetworkStream NS = null;
			MemoryStream MS = new MemoryStream();
			try
			{
				NS = this.client.GetStream();
				byte[] buf = new byte[2048];
				while (true)
				{
					/* Ждем пакетов от пользователя
					 Если идут пакеты, то записываем их в ОЗУ для дальнейшего преобразования в строку
					 Если происходит исключительная ситуация, то разрываем соединение
					 */
					do
					{
						// Метод Read - приостанавливает поток
						int cnt = NS.Read(buf, 0, buf.Length);
						if (cnt == 0)
							throw new Exception("Получено 0 байт");
						MS.Write(buf, 0, cnt);
					}
					while (NS.DataAvailable);

					// Конвертируем полученный байты в строку
					String inputCmd = Encoding.UTF8.GetString(MS.GetBuffer(), 0, (int)MS.Position);
					MS.SetLength(0);
					Console.WriteLine("От {0} получена команда: {1}", clientIP, inputCmd);

					String[] ss = inputCmd.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

					// Если данные получены в виде, отличном от протокола, разрываем соединение
					if (ss.Length != 2)
						break;

					String cmd = ss[0];
					String data = ss[1];

					String answer = cmd + "OK|";
					try
					{
						switch (cmd)
						{
							case "LOGIN":
								{
									if (ChatThread.users.Contains(data))
										answer = "LOGINERROR|Такой логин уже существует";
									else
									{
										this.userName = data;
										ChatThread.users.Add(data);
										answer += data;
									}
								}
								break;
							case "USERLIST":
								{
									String usersList = "";
									foreach (String user in ChatThread.users)
										usersList += user + "^";
									answer += usersList;
								}
								break;
							case "MSGLIST":
								{
									int fromId = Int32.Parse(data);
									if (ChatThread.messages.Count != 0 && fromId < lastId)
									{
										String messagesList = "";
										while (fromId++ < ChatThread.lastId)
											messagesList += fromId.ToString() + "^" + ChatThread.messages[fromId] + "&";
										answer += messagesList;
									}
									else
										answer += "null";
								}
								break;
							case "NEWMSG":
								{
									if (data.Contains("редиска") || data.Contains("волан-де-морт"))
									{
										answer = "NEWMSGERROR|Ошибка при отправке сообщения. Сообщение содержит недопустимое слово.";
									}
									else if (data.Trim() == this.userName + ":")
									{
										answer = "NEWMSGERROR|Ошибка при отправке сообщения. Нельзя отправить пустое сообщение.";
									}
									else if (data.Length - this.userName.Length - 1 > 256)
									{
										answer = "NEWMSGERROR|Ошибка при отправке сообщения. Слишком длинное сообщение.";
									}
									else
									{
										ChatThread.messages.Add(ChatThread.lastId++ + 1, data);
										answer += lastId;
									}
								}
								break;
						}
					}
					catch (Exception e)
					{
						Console.WriteLine(e.Message);
					}

					byte[] outputData = Encoding.UTF8.GetBytes(answer);
					NS.Write(outputData, 0, outputData.Length);
					Console.WriteLine("Клиенту {0} отправлен ответ: {1}", clientIP, answer);
				}
			}
			catch (Exception)
			{
				Console.WriteLine("Отключение: {0}", clientIP);
				ChatThread.users.Remove(userName);
			}
			finally
			{
				MS.Close();
				if (NS != null)
					NS.Close();
				this.client.Close();
			}
		}
	}
}
