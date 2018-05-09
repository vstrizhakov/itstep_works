using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace UdpReceiver
{
	class Program
	{
		static void Main(string[] args)
		{
			UdpClient udpReceiver = new UdpClient(9000);
			IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Parse("0.0.0.0"), 9000);
			while (!Console.KeyAvailable)
			{
				byte[] receiveBytes = udpReceiver.Receive(ref RemoteIpEndPoint);
				string receiveData = Encoding.UTF8.GetString(receiveBytes);
				Console.WriteLine("Получено от {0} : {1}", RemoteIpEndPoint.ToString(), receiveData);
			}
		}
	}
}
