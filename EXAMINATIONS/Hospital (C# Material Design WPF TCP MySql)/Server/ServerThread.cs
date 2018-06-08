using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;
using System.Net;

namespace Server
{
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
			TcpListener listener = new TcpListener(IPAddress.Parse(this.host), this.port);
			listener.Start();
			while (true)
			{
				TcpClient client = listener.AcceptTcpClient();
				ServerThread.Log("{0} connected", client.Client.RemoteEndPoint.ToString());

				ClientThread CT = new ClientThread(client);
				Thread T = new Thread(CT.Run);
				T.IsBackground = true;
				T.Start();
			}
		}

		static public void Log(String message, params String[] prms)
		{
				Console.WriteLine(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + ": " + message, prms);
		}
	}
}
