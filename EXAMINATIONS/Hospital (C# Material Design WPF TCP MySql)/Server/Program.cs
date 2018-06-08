using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Configuration;
using System.Threading;
using System.Net.Sockets;
using System.IO;
using System.Runtime.Serialization;
using MySql.Data.MySqlClient;

namespace Server
{
	class Program
	{
		static void Main(string[] args)
		{
			String host = ConfigurationManager.AppSettings["host"];
			int port = 0;
			try
			{
				port = Int32.Parse(ConfigurationManager.AppSettings["port"]);
			}
			catch (FormatException)
			{
				Console.WriteLine("Wrong port for starting a server");
				return;
			}

			String connectionString = ConfigurationManager.AppSettings["connectionString"];
			ClientThread.Connection = new MySqlConnection(connectionString);
			ClientThread.Connection.Open();
			ClientThread.Salt = ConfigurationManager.AppSettings["salt"];

			ServerThread ST = new ServerThread(host, port);
			Thread T = new Thread(ST.Run);
			T.IsBackground = true;
			T.Start();

			ServerThread.Log("Server was started on {0}:{1}", host, port.ToString());

			while (!Console.KeyAvailable)
				Thread.Sleep(500);

			ClientThread.Connection.Close();

			ServerThread.Log("Server was stopped");
		}
	}
}
