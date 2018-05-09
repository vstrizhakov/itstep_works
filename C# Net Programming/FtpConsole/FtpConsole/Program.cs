using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace FtpConsole
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://10.3.11.10/");
				request.Credentials = new NetworkCredential("sp2822user", "sp2822pswd");
				request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
				FtpWebResponse response = (FtpWebResponse)request.GetResponse();
				Console.WriteLine("Delete status: {0}", response.StatusDescription);
				Stream stream = response.GetResponseStream();
				StreamReader SR = new StreamReader(stream, Encoding.Default);
				String content = SR.ReadToEnd();
				stream.Close();
				Console.WriteLine(content);
				response.Close();
				Console.Read();

				//FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://10.3.11.10/Koala_09358.png");
				//request.Credentials = new NetworkCredential("sp2822user", "sp2822pswd");
				//request.Method = WebRequestMethods.Ftp.DownloadFile;
				//FtpWebResponse response = (FtpWebResponse)request.GetResponse();
				//Console.WriteLine(response.StatusCode + ": " + response.StatusDescription);
				//Stream stream = response.GetResponseStream();
				//FileStream FS = new FileStream("Koala.jpg", FileMode.Create, FileAccess.Write);
				//stream.CopyTo(FS);
				//FS.Close();
				//stream.Close();
				//response.Close();

				//FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://10.3.11.10/Koala_09358.png");
				//request.Credentials = new NetworkCredential("sp2822user", "sp2822pswd");
				//request.Method = WebRequestMethods.Ftp.UploadFile;

				//Stream outStream = request.GetRequestStream();
				//FileStream FS = new FileStream("Koala.png", FileMode.Open, FileAccess.Read);
				//FS.CopyTo(outStream);
				//FS.Close();
				//outStream.Close();

				//FtpWebResponse response = (FtpWebResponse)request.GetResponse();
				//Console.WriteLine(response.StatusCode + ": " + response.StatusDescription);
				//FS.Close();
				//response.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine("Error: {0}", e.Message);
			}
		}
	}
}
