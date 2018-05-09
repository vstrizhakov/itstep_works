using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace HttpPOST
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				String strUrl = "http://10.3.11.10/test.php";
				HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(strUrl);
				webRequest.Method = "POST";
				String postData = "firstname=bill&lastname=gates";
				byte[] arrPostData = Encoding.UTF8.GetBytes(postData);
				webRequest.ContentLength = arrPostData.Length;
				webRequest.ContentType = "application/x-www-form-urlencoded";
				Stream stream = webRequest.GetRequestStream();
				stream.Write(arrPostData, 0, arrPostData.Length);
				stream.Close();
				HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
				if (webResponse.StatusCode == HttpStatusCode.OK)
				{
					Stream receiveStream = webResponse.GetResponseStream();
					StreamReader SR = new StreamReader(receiveStream, Encoding.UTF8);
					String content = SR.ReadToEnd();
					receiveStream.Close();
					Console.WriteLine(content);
				}
				else
				{
					Console.WriteLine(webResponse.StatusCode);
				}
				webResponse.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}
	}
}
