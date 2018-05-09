using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace UdpSender
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				UdpClient udpSender = new UdpClient();
				byte[] sendBytes = Encoding.UTF8.GetBytes("                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      ");
				while (!Console.KeyAvailable)
				{
					Thread.Sleep(750);
					udpSender.Send(sendBytes, sendBytes.Length, "10.3.255.255", 9000);
					Console.WriteLine("Sending Message...");
				}
				udpSender.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine("Error: {0}", e.Message);
			}
		}
	}
}
