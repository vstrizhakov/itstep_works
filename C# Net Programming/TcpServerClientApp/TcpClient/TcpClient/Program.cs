using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace MyTcpClient
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				TcpClient client = new TcpClient("10.3.60.35", 5000);
				Console.WriteLine("Соединение с сервером установлено");
				NetworkStream NS = client.GetStream();
				byte[] buf = new byte[1024];
				MemoryStream MS = new MemoryStream();
				while (true)
				{
					Console.Write("Введите строку. Пустая строка - выход: ");
					String str = Console.ReadLine();
					if (str.Length == 0)
						break;
					Console.Write("Команды:\nU - перевод в верхний регистр\nL - перевод в нижний регистр\nR - смена порядка следования в строке на обратный\nПустая строка - выход\nВыберите команду: ");
					String cmd = Console.ReadLine();
					if (cmd.Length == 0)
						break;
					try
					{
						bool j = true;
						switch (cmd.ToLower())
						{
							case "u":
								str = "UPPER|" + str;
								cmd = "UPPER";
								break;
							case "l":
								str = "LOWER|" + str;
								cmd = "LOWER";
								break;
							case "r":
								str = "REVERSE|" + str;
								cmd = "REVERSE";
								break;
							default:
								j = false;
								break;
								
						}
						if (!j)
						{
							Console.WriteLine("Введенной команды не существует, попробуйте еще раз");
							continue;
						}
						byte[] a = Encoding.UTF8.GetBytes(str);
						NS.Write(a, 0, a.Length);

						do
						{
							int cnt = NS.Read(buf, 0, buf.Length);
							if (cnt == 0)
								throw new Exception("0 bytes received");
							MS.Write(buf, 0, cnt);
						}
						while (NS.DataAvailable);

						String result = Encoding.UTF8.GetString(MS.GetBuffer(), 0, (int)MS.Position);
						String[] ss = result.Split(new String[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
						if (ss[0] != cmd + "OK")
						{
							Console.WriteLine("Ошибка при получении ответа от сервера");
							break;
						}
						result = "";
						for (int i = 1; i < ss.Length; i++)
							result += ss[i];
						MS.SetLength(0);
						Console.WriteLine("Получено от сервера: {0}", result);

					}
					catch (Exception e)
					{
						Console.WriteLine(e.Message);
						break;
					}
				}
				NS.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine("Ошибка: {0}", e.Message);
			}
		}
	}
}
