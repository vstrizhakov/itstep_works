using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Sockets;
using System.Net;

namespace Receiver
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				TcpListener server = new TcpListener(IPAddress.Parse("10.3.60.100"), 7000);
				server.Start();
				while (true)
				{
					TcpClient client = server.AcceptTcpClient();
					MemoryStream MS = new MemoryStream();
					byte[] buf = new byte[2048];
					NetworkStream NS = client.GetStream();

					BinaryReader BR = new BinaryReader(NS);
					long allCnt = BR.ReadInt64();
					Console.WriteLine(allCnt);
					int curCnt = 0;

					while (curCnt < allCnt)
					{
						
						int cnt = NS.Read(buf, 0, buf.Length);
						if (cnt == 0)
							break;
						MS.Write(buf, 0, cnt);
						curCnt += cnt;
					}
					byte[] a = new byte[MS.Length];
					Array.Copy(MS.GetBuffer(), a, a.Length);
					MS.Close();
					File.WriteAllBytes("file.dat", a);
					a = Encoding.UTF8.GetBytes(String.Format("Получено с сервера {0}/{1}", curCnt, allCnt));
					NS.Write(a, 0, a.Length);
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("Ошибка: {0}", e.Message);
			}
		}
	}
}
