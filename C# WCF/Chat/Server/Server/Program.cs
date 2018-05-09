using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Threading;

namespace Server
{
	class Program
	{
		static void Main(string[] args)
		{
			ServiceHost serviceHost = new ServiceHost(typeof(ChatService));
			serviceHost.Open();
			Thread T = new Thread(ChatService.CheckUserActivity);
			T.IsBackground = true;
			T.Start();
			Console.ReadKey(true);
			serviceHost.Close();
		}
	}

	[ServiceContract]
	public class ChatService
	{
		static private Semaphore S = new Semaphore(1, 10000);
		static private EventWaitHandle AllEWH = new EventWaitHandle(true, EventResetMode.ManualReset);
		static private EventWaitHandle WritersEWH = new EventWaitHandle(true, EventResetMode.AutoReset);
		static private List<KeyValuePair<String, String>> messages = new List<KeyValuePair<String, String>>();
		static private Dictionary<String, DateTime> users = new Dictionary<String, DateTime>();

		static public void CheckUserActivity()
		{
			while (true)
			{
				ChatService.AllEWH.WaitOne();
				ChatService.S.WaitOne();

				DateTime DT = DateTime.Now;
				List<String> users = ChatService.users.Keys.ToList();
				for (int i = 0; i < users.Count; i++)
					if (DT.TimeOfDay.TotalSeconds > ChatService.users[users[i]].TimeOfDay.TotalSeconds + 30)
					{
						ChatService.users.Remove(users[i]);
						ChatService.S.WaitOne();
					}

				ChatService.S.Release();
				Thread.Sleep(5000);
			}
		}

		[OperationContract]
		public String Login(String login)
		{
			String tLogin = login.Trim();
			if (tLogin.Length == 0)
				return "LOGINERROR|Пожалуйста, введите логин";
			else if (tLogin.Length > 24)
				return "LOGINERROR|Логин не может быть длиннее 24 символов";
			else
			{
				ChatService.AllEWH.WaitOne();
				ChatService.S.WaitOne();

				bool contains = ChatService.users.ContainsKey(tLogin);

				ChatService.S.Release();

				if (contains == true)
					return "LOGINERROR|Пользователь с таким логином уже существует";
				else
				{
					ChatService.WritersEWH.WaitOne();
					ChatService.AllEWH.Reset();
					for (int i = 0; i < ChatService.users.Count; i++)
						ChatService.S.WaitOne();
					ChatService.AllEWH.Set();
					ChatService.WritersEWH.Set();

					ChatService.users.Add(tLogin, DateTime.Now);
					ChatService.S.Release();

					for (int i = 0; i < ChatService.users.Count; i++)
						ChatService.S.Release();

					Console.WriteLine("LOGINOK|" + tLogin);
					return "LOGINOK|" + tLogin;
				}
			}
		}

		[OperationContract]
		public String GetUsers(String login)
		{
			ChatService.AllEWH.WaitOne();
			ChatService.S.WaitOne();

			String answer = "USERLISTOK|";
			ICollection<String> users = ChatService.users.Keys;
			foreach (String user in users)
				answer += user + "&";
			ChatService.users[login] = DateTime.Now;

			ChatService.S.Release();

			Console.WriteLine(answer);
			return answer;
		}

		[OperationContract]
		public String GetMessages(String lastMessageId, String login)
		{
			String answer = "MSGLISTOK|";
			int fromId = Int32.Parse(lastMessageId);
			if (ChatService.messages.Count != 0)
			{
				String messagesList = "";
				while (fromId++ < ChatService.messages.Count - 1)
					messagesList += fromId.ToString() + "^" + ChatService.messages[fromId].Key + ":" + ChatService.messages[fromId].Value + "&";
				answer += messagesList;
			}
			else
				answer += "null";
			ChatService.users[login] = DateTime.Now;
			Console.WriteLine(answer);
			return answer;
		}

		[OperationContract]
		public String SendMessage(String message, String login)
		{
			String answer = "NEWMSGOK|";

			ChatService.AllEWH.WaitOne();
			ChatService.S.WaitOne();

			bool contains = message.Contains("редиска") || message.Contains("волан-де-морт");

			ChatService.S.Release();

			if (contains == true)
			{
				answer = "NEWMSGERROR|Ошибка при отправке сообщения. Сообщение содержит недопустимое слово.";
			}
			else if (message == "")
			{
				answer = "NEWMSGERROR|Ошибка при отправке сообщения. Нельзя отправить пустое сообщение.";
			}
			else if (message.Length > 256)
			{
				answer = "NEWMSGERROR|Ошибка при отправке сообщения. Сообщение должно быть короче 256 символов.";
			}
			else
			{
				ChatService.WritersEWH.WaitOne();
				ChatService.AllEWH.Reset();
				for (int i = 0; i < ChatService.users.Count; i++)
					ChatService.S.WaitOne();
				ChatService.AllEWH.Set();
				ChatService.WritersEWH.Set();

				ChatService.messages.Add(new KeyValuePair<String, String>(login, message));

				for (int i = 0; i < ChatService.users.Count; i++)
					ChatService.S.Release();
				answer += ChatService.messages.Count - 1;
			}
			ChatService.users[login] = DateTime.Now;
			Console.WriteLine(answer);
			return answer;
		}
	}
}
