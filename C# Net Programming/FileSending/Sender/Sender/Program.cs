using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Sockets;

namespace Sender
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				Console.Write("Введите имя файла: ");
				byte[] buf = File.ReadAllBytes(Console.ReadLine());
				TcpClient client = new TcpClient("10.3.60.100", 7000);
				NetworkStream NS = client.GetStream();
				
				BinaryWriter BW = new BinaryWriter(NS);
				BW.Write(buf.LongLength);

				NS.Write(buf, 0, buf.Length);

				byte[] a = new byte[128];
				int cnt = NS.Read(a, 0, a.Length);
				String str = Encoding.UTF8.GetString(a, 0, cnt);
				Console.WriteLine("Получено от сервера: {0}", str);
				NS.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine("Ошибка: {0}", e.Message);
			}
		}
	}
}
