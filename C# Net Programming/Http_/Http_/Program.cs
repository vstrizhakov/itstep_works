using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Http_
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				String strURL = "https://rozetka.com.ua/search/?text=elf";
				DateTime DT1 = DateTime.Now;
				HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(strURL);
				webRequest.Method = "GET";
				HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
				if (webResponse.StatusCode == HttpStatusCode.OK)
				{
					Stream receiveStream = webResponse.GetResponseStream();
					StreamReader readStream = new StreamReader(receiveStream, Encoding.Default);
					String content = readStream.ReadToEnd();
					receiveStream.Close();
				//	Console.WriteLine(content);
				}
				else
					Console.WriteLine("Получен ответ: {0}", webResponse.StatusCode);
				webResponse.Close();
				DateTime DT2 = DateTime.Now;
				TimeSpan DT = DT2 - DT1;
				Console.WriteLine(DT.ToString());
			}
			catch (Exception e)
			{
				Console.WriteLine("Error: {0}", e.Message);
			}
		}
	}
}
