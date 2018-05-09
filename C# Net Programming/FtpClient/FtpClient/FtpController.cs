using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Windows.Forms;

namespace FtpClient
{
	class FtpController
	{
		private String host;
		private String username;
		private String password;
		private RichTextBox LogBox;
		public List<DirectoryItem> Items { get; set; } = new List<DirectoryItem>();
		public String CurrentPath { get; set; } = "/";
		public FtpController(String host, String port, String username, String password, RichTextBox rtb)
		{
			this.host = host + ":" + ((port == "") ? "21" : port);
			this.username = username;
			this.password = password;
			this.LogBox = rtb;
		}

		private bool IsSuccessed(FtpStatusCode msg)
		{
			return (msg == FtpStatusCode.ClosingData || msg == FtpStatusCode.CommandOK || msg == FtpStatusCode.FileActionOK);
		}

		private void Log(String msg)
		{
			this.LogBox.AppendText("Статус: " + msg + "\r\n");
			this.LogBox.ScrollToCaret();
		}

		public List<DirectoryItem> GetListing(String itemPath = "")
		{
			String[] list;
			String totalPath = this.CurrentPath + itemPath + "/";
			if (itemPath == "/")
			{
				totalPath = this.CurrentPath;
			}
			else if (itemPath == "..")
			{
				String[] ss = this.CurrentPath.Remove(0, 1).Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
				totalPath = "/";
				for (int j = 0; j < ss.Length - 1; j++)
					totalPath += ss[j] + "/";
			}
			else if (itemPath[0] == '*')
			{
				String[] ss = itemPath.Remove(0, 1).Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
				totalPath = "/";
				foreach (String s in ss)
					totalPath += s + "/";
			}
			this.Log("Подключение к " + this.host + "...");
			FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://" + this.host + totalPath);
			request.Credentials = new NetworkCredential(this.username, this.password);
			request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
			this.Log("Получение списка каталогов...");
			FtpWebResponse response = (FtpWebResponse)request.GetResponse();
			Stream stream = response.GetResponseStream();
			StreamReader SR = new StreamReader(stream, Encoding.Default);
			list = SR.ReadToEnd().Split(new String[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
			this.Log("Список каталогов \"" + totalPath + "\" извлечен");
			this.CurrentPath = totalPath;
			this.Log("Закрытие соединения...");
			SR.Close();
			stream.Close();
			response.Close();
			this.Items.Clear();
			int i = 0;
			foreach (String item in list)
			{
				if (i++ < 2)
					continue;
				String tmp = item;

				bool isDirectory = (tmp[0] == 'd');
				tmp = tmp.Remove(0, 21);

				String size;
				try
				{
					Double s = Double.Parse(tmp.Substring(0, 17));
					size = s.ToString() + " Б";
					if (isDirectory == true && s == 0)
						size = "";
					else if ((s / 1024 / 1024) >= 1024)
						size = String.Format("{0:0.00} ГБ", s / 1024 / 1024 / 1024);
					else if ((s / 1024) >= 1024)
						size = String.Format("{0:0.00} МБ", s / 1024 / 1024);
					else if (s >= 1024)
						size = String.Format("{0:0.00} КБ", s / 1024);
				}
				catch
				{
					size = tmp.Substring(0, 17);
				}
				tmp = tmp.Remove(0, 17);

				String datetime = tmp.Substring(0, 13);
				tmp = tmp.Remove(0, 13);

				String name = tmp;

				this.Items.Add(new DirectoryItem(name, datetime, size, isDirectory));
			}
			return this.Items;
		}

		public void DownloadFile(String from, String to)
		{
			this.Log("Подключение к " + this.host + "...");
			FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://" + this.host + this.CurrentPath + from);
			request.Credentials = new NetworkCredential(this.username, this.password);
			request.Method = WebRequestMethods.Ftp.DownloadFile;
			this.Log("Скачивание файла \"" + this.CurrentPath + from + "\"...");
			FtpWebResponse response = (FtpWebResponse)request.GetResponse();
			Stream stream = response.GetResponseStream();
			FileStream FS = new FileStream(to + from, FileMode.Create, FileAccess.Write);
			stream.CopyTo(FS);
			FS.Close();
			this.Log("Файл \"" + this.CurrentPath + from + "\" успешно скачан");
			this.Log("Закрытие соединения...");
			stream.Close();
			response.Close();
		}

		public void DownloadDirectory(String from, String to)
		{
			this.Log("Скачивание каталога \"" + this.CurrentPath + from + "\"...");
			Directory.CreateDirectory(to + from);
			String[] dfs = this.LoadDirectoryList(this.host + this.CurrentPath + from);
			int i = 0;
			foreach (String df in dfs)
			{
				if (i++ < 2)
					continue;
				bool isDirectory = false;
				if (df[0] == 'd')
					isDirectory = true;
				String name = df.Remove(0, 51);
				if (isDirectory == true)
					this.DownloadDirectory(from + name + "/", to);
				else
					this.DownloadFile(from + name, to);
			}
		}

		public void DeleteFile(String item)
		{
			this.Log("Подключение к " + this.host + "...");
			FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://" + this.host + this.CurrentPath + item);
			request.Credentials = new NetworkCredential(this.username, this.password);
			request.Method = WebRequestMethods.Ftp.DeleteFile;
			this.Log("Удаление файла \"" + this.CurrentPath + item + "\"...");
			request.GetResponse();
			this.Log("Файл \"" + this.CurrentPath + item + "\" успешно удален");
			this.Log("Закрытие соединения...");
			this.Log("Обновление списка каталогов...");
		}

		public void DeleteDirectory(String item)
		{
			String[] dfs = this.LoadDirectoryList(this.host + this.CurrentPath + item + "/");
			int i = 0;
			foreach (String df in dfs)
			{
				if (i++ < 2)
					continue;
				bool isDirectory = false;
				if (df[0] == 'd')
					isDirectory = true;
				String name = df.Remove(0, 51);
				if (isDirectory == true)
					this.DeleteDirectory(item + "/" + name);
				else
					this.DeleteFile(item + "/" + name);
			}
			this.Log("Подключение к " + this.host + "...");
			FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://" + this.host + this.CurrentPath + item);
			request.Credentials = new NetworkCredential(this.username, this.password);
			request.Method = WebRequestMethods.Ftp.RemoveDirectory;
			this.Log("Удаление каталога \"" + this.CurrentPath + item + "/\"...");
			request.GetResponse();
			this.Log("Каталог \"" + this.CurrentPath + item + "\" успешно удален");
			this.Log("Закрытие соединения...");
		}

		private String[] LoadDirectoryList(String path)
		{
			FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://" + path);
			request.Credentials = new NetworkCredential(this.username, this.password);
			request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
			FtpWebResponse response = (FtpWebResponse)request.GetResponse();
			Stream stream = response.GetResponseStream();
			StreamReader SR = new StreamReader(stream, Encoding.Default);
			String[] list = SR.ReadToEnd().Split(new String[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
			SR.Close();
			stream.Close();
			response.Close();
			return list;
		}

		public void Rename(String path, String newName)
		{
			this.Log("Подключение к " + this.host + "...");
			FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://" + this.host + this.CurrentPath + path);
			request.Credentials = new NetworkCredential(this.username, this.password);
			request.Method = WebRequestMethods.Ftp.Rename;
			this.Log("Переименование \"" + this.CurrentPath + path + "\" на \"" + this.CurrentPath + newName + "\"...");
			request.RenameTo = newName;
			request.GetResponse();
			this.Log("\"" + this.CurrentPath + newName + "\" успешно переименован");
			this.Log("Закрытие соединения...");
		}

		public void CreateDirectory(String name)
		{
			this.Log("Подключение к " + this.host + "...");
			FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://" + this.host + this.CurrentPath + name);
			request.Credentials = new NetworkCredential(this.username, this.password);
			request.Method = WebRequestMethods.Ftp.MakeDirectory;
			this.Log("Создание каталога \"" + this.CurrentPath + name + "/\"...");
			request.GetResponse();
			this.Log("Каталог \"" + this.CurrentPath + name + "/\" успешно создан");
			this.Log("Закрытие соединения...");
		}

		public void UploadFile(FileStream FS, String to)
		{
			this.Log("Подключение к " + this.host + "...");
			FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://" + this.host +"/"+ this.CurrentPath + to);
			request.Credentials = new NetworkCredential(this.username, this.password);
			request.Method = WebRequestMethods.Ftp.UploadFile;
			this.Log("Закачивание файла  \"" + Path.GetFileName(to) + "\"...");
			Stream stream = request.GetRequestStream();
			FS.CopyTo(stream);
			stream.Close();
			this.Log("Файл \"" + Path.GetFileName(FS.Name) + "\" успешно закачан");
			this.Log("Закрытие соединения...");

			//FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://192.168.0.106//123.png");  //закачиваем файл по пути/с именем
			//request.Credentials = new NetworkCredential(user, pass);
			//request.Method = WebRequestMethods.Ftp.UploadFile;

			//Console.WriteLine(OPD.FileName);
			//Stream outStream = request.GetRequestStream();
			//FileStream FS = new FileStream(@"D:\ftp\111.png", FileMode.Open, FileAccess.Read); //откуда беремфайл для загрузки на сервер
			//FS.CopyTo(outStream);
			//FS.Close();
			//outStream.Close();

			//FtpWebResponse response = (FtpWebResponse)request.GetResponse();

			//Console.WriteLine("Request status: {0}", response.StatusDescription);
			//response.Close();
		}
	}
}
