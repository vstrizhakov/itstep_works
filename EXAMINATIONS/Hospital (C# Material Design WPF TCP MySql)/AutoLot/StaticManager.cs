using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.ComponentModel;
using System.Windows.Controls;
using System.Configuration;
using Hospital.Models;
using Hospital.Views;
using System.Collections.ObjectModel;
using System.Windows;
using Hospital.ViewModels;
using System.Net.Sockets;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Hospital
{
	public delegate void CommonHandler();
	public delegate void ErrorHandler(String s);
	static class StaticManager
	{
		static public DbConnection DatabaseConnection { get; set; }
		static public UserModel User { get; set; }
		static public TcpClient Client { get; set; }
		static public NetworkStream NS { get; set; }
		static private MemoryStream MS { get; set; } = new MemoryStream();
		static public byte[] Buf { get; set; } = new byte[2048];
		static public MainWindowViewModel MWVL { get; set; }

		static public void ChangeInterfaceToLoged()
		{
			if (StaticManager.User.IsDoctor == 0)
				StaticManager.MWVL.MenuItems = new ObservableCollection<MenuItemModel>
			{
				new MenuItemModel("Главная", new Results(StaticManager.User)),
				new MenuItemModel("Настройки", null)
			};
			else
				StaticManager.MWVL.MenuItems = new ObservableCollection<MenuItemModel>
			{
				new MenuItemModel("Главная", new Patients(StaticManager.User)),
				new MenuItemModel("Настройки", null)
			};
		}

		static public String SendRequest(String str, params String[] prms)
		{
			try
			{
				byte[] output = Encoding.UTF8.GetBytes(String.Format(str, prms));
				StaticManager.NS.Write(output, 0, output.Length);

				do
				{
					int cnt = StaticManager.NS.Read(StaticManager.Buf, 0, StaticManager.Buf.Length);
					if (cnt == 0)
						throw new Exception("0 bytes received");
					StaticManager.MS.Write(StaticManager.Buf, 0, cnt);
				} while (StaticManager.NS.DataAvailable);

				String result = Encoding.UTF8.GetString(MS.GetBuffer(), 0, (int)MS.Position);
				MS.SetLength(0);
				return result;
			}
			catch
			{
				System.Windows.Forms.MessageBox.Show("Соединение с сервером разорвано. Приложение будет закрыто.");
				StaticManager.MWVL.Close();
				return String.Empty;
			}
		}

		static public String ErrorMessage
		{
			set
			{
				StaticManager.MWVL.Message = value;
				StaticManager.MWVL.IsOpen = true;
			}
		}

		static public void Start()
		{
			String host = ConfigurationManager.AppSettings["host"];
			int port = 0;
			try
			{
				port = Int32.Parse(ConfigurationManager.AppSettings["port"]);
			}
			catch (FormatException e)
			{
				System.Windows.Forms.MessageBox.Show("Ошибка в файле конфигурации");
				StaticManager.MWVL.Close();
				return;
			}

			try
			{
				StaticManager.Client = new TcpClient(host, port);
				StaticManager.NS = StaticManager.Client.GetStream();
			}
			catch
			{
				System.Windows.Forms.MessageBox.Show("Не удалось подключиться к серверу. Приложение будет закрыто.");
				StaticManager.MWVL.Close();
				return;
			}

			StaticManager.MWVL.MenuItems = new ObservableCollection<MenuItemModel>()
			{
				new MenuItemModel("Вход", new Login()),
				new MenuItemModel("Регистрация", new Register())
			};
		}

		static public String Serialize(object obj)
		{
			DataContractJsonSerializer JS = new DataContractJsonSerializer(obj.GetType());
			MemoryStream MS = new MemoryStream();
			JS.WriteObject(MS, obj);
			MS.Position = 0;
			StreamReader SR = new StreamReader(MS);
			String result = SR.ReadToEnd();
			SR.Close();
			MS.Close();
			return result;
		}

		static public object Deserialize(String str, Type type)
		{
			DataContractJsonSerializer JS = new DataContractJsonSerializer(type);
			MemoryStream MS = new MemoryStream();
			StreamWriter SW = new StreamWriter(MS);
			SW.Write(str);
			SW.Flush();
			MS.Position = 0;
			object result = JS.ReadObject(MS);
			MS.Close();
			return result;
		}
	}
}
