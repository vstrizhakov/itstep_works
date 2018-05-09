using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TcpServer
{
	class Program
	{
		static void Main(string[] args)
		{
			ServerThread ST = new ServerThread("10.3.60.35", 5000);
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
		int port;

		public ServerThread(String host, int port)
		{
			this.host = host;
			this.port = port;
		}

		public void Run()
		{
			try
			{
				TcpListener server = new TcpListener(IPAddress.Parse(this.host), this.port);
				server.Start();
				while (true)
				{
					TcpClient client = server.AcceptTcpClient();
					Console.WriteLine("Подключение: {0}", client.Client.RemoteEndPoint);

					ReadWriteThread RWT = new ReadWriteThread(client);
					Thread T = new Thread(RWT.Run);
					T.IsBackground = true;
					T.Start();
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("Ошибка: " + e.Message);
			}
		}
	}

	class ReadWriteThread
	{
		TcpClient client;

		public ReadWriteThread(TcpClient client)
		{
			this.client = client;
		}

		public void Run()
		{
			String strInfo = client.Client.RemoteEndPoint.ToString();
			try
			{
				MemoryStream MS = new MemoryStream();
				byte[] buf = new byte[1024];

				NetworkStream NS = client.GetStream();
				while (true)
				{
					do
					{
						int cnt = NS.Read(buf, 0, buf.Length);
						if (cnt == 0)
							throw new Exception("0 bytes received");
						MS.Write(buf, 0, cnt);
					}
					while (NS.DataAvailable);

					byte[] R = MS.GetBuffer();
					String str = Encoding.UTF8.GetString(MS.GetBuffer(), 0, (int)MS.Position);
					Console.WriteLine("Получено от клиента: {0}", str);
					MS.SetLength(0);

					String[] ss = str.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
					str = "";
					for (int i = 1; i < ss.Length; i++)
						str += ss[i];
					String cmd = ss[0];
					//	String answer = "HTTP/1.1 200 OK\r\nContent-Type: text/html\r\nContent-Length: 20\r\n\r\n<h1>Hello, World!</h1>";
					String answer = "";
					switch (cmd)
					{
						case "UPPER":
							answer = "UPPEROK|" + str.ToUpper();
							break;
						case "LOWER":
							answer = "LOWEROK|" + str.ToLower();
							break;
						case "REVERSE":
							answer = "REVERSEOK|";
							for (int i = str.Length - 1; i >= 0; i--)
								answer += str[i];
							break;
					}
					byte[] a = Encoding.UTF8.GetBytes(answer);
					NS.Write(a, 0, a.Length);
				}

			}
			catch (Exception a)
			{
				Console.WriteLine("Разрыв соединения: {0}", strInfo);
			}
		}
	}
}
