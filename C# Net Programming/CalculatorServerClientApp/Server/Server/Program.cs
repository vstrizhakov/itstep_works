using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Sockets;
using System.IO;
using System.Net;

namespace Server
{
	class Program
	{
		static void Main(string[] args)
		{
			ServerThread ST = new ServerThread("10.3.60.158", 5555);
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
				TcpListener server = new TcpListener(IPAddress.Parse(this.host), this.port);
				server.Start();
				while (true)
				{
					TcpClient client = server.AcceptTcpClient();
					Console.WriteLine("Подключение: {0}", client.Client.RemoteEndPoint);

					CalculateThread CT = new CalculateThread(client);
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

	class CalculateThread
	{
		private TcpClient client;

		public CalculateThread(TcpClient client)
		{
			this.client = client;
		}

		public void Run()
		{
			String clientIp = this.client.Client.RemoteEndPoint.ToString();
			MemoryStream MS = new MemoryStream();
			NetworkStream NS = null;
			try
			{
				byte[] buf = new byte[2048];
				NS = this.client.GetStream();
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

					byte[] inputBytes = MS.GetBuffer();
					String inputData = Encoding.UTF8.GetString(inputBytes, 0, (int)MS.Position);
					MS.SetLength(0);
					Console.WriteLine(inputData);
					String[] ss = inputData.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
					String operation = ss[0];
					String[] numbers = ss[1].Split(new char[] { '&' }, StringSplitOptions.RemoveEmptyEntries);

					if (numbers.Length != 2)
					{
						// INVALID_DATA
						continue;
					}

					double x = 0, y = 0;
					try
					{
						x = Double.Parse(numbers[0]);
						y = Double.Parse(numbers[1]);
					}
					catch
					{
						// INVALID_NUMBERS
						return;
					}

					String answer = "";
					double result = 0;
					switch (operation)
					{
						case "PLUS":
							{
								result = x + y;
								answer = operation + "OK";
							}
							break;
						case "MINUS":
							{
								result = x - y;
								answer = operation + "OK";
							}
							break;
						case "MULTIPLE":
							{
								result = x * y;
								answer = operation + "OK";
							}
							break;
						case "DIVIDE":
							{
								try
								{
									result = x / y;
									answer = operation + "OK";
								}
								catch
								{
									answer = operation + "ERROR";
								}
							}
							break;
					}
					answer += "|" + result.ToString();
					Console.WriteLine(answer);
					byte[] outputData = Encoding.UTF8.GetBytes(answer);
					NS.Write(outputData, 0, outputData.Length);
				}
			}
			catch
			{
				Console.WriteLine("Разрыв соединения: " + clientIp);
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
