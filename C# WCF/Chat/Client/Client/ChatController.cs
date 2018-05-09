using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Windows.Forms;
using System.ServiceModel;

namespace Client
{
	static class ChatController
	{
		static Server.ChatService client;
		static String login;

		static public void Initialize()
		{
			ChannelFactory<Server.ChatService> channelFactory = new ChannelFactory<Server.ChatService>("MyConfig");
			ChatController.client = channelFactory.CreateChannel();
		}

		static public bool Login(String login)
		{
			String answer;
			lock (ChatController.client)
			{
				answer = ChatController.client.Login(login);
			}
			String[] ss = answer.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
			String cmd = ss[0];
			String data = "";
			for (int i = 1; i < ss.Length; i++)
				data += ss[i];
			bool result = false;
			switch (cmd)
			{
				case "LOGINOK":
					login = data;
					ChatController.login = login;
					result = true;
					break;
				case "LOGINERROR":
					MessageBox.Show(data);
					break;
				default:
					throw new Exception("Ошибка при получении ответа от сервера. Приложение будет закрыто.");
			}
			return result;
		}

		static public List<String> GetUsers()
		{
			String answer;
			lock (ChatController.client)
			{
				answer = ChatController.client.GetUsers(ChatController.login);
			}
			String[] ss = answer.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
			String cmd = ss[0];
			String data = "";
			for (int i = 1; i < ss.Length; i++)
				data += ss[i];

			List<String> UsersList = null;
			switch (cmd)
			{
				case "USERLISTOK":
					{
						UsersList = data.Split(new char[] { '&' }, StringSplitOptions.RemoveEmptyEntries).ToList();
					}
					break;
				default:
					throw new Exception("Ошибка при получении ответа от сервера. Приложение будет закрыто.");
			}
			return UsersList;
		}

		static public Dictionary<String, String> GetMessages(String lastMessageId)
		{
			String answer;
			lock (ChatController.client)
			{
				answer = ChatController.client.GetMessages(lastMessageId, ChatController.login);
			}
			String[] ss = answer.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
			String cmd = ss[0];
			String data = "";
			for (int i = 1; i < ss.Length; i++)
				data += ss[i];

			Dictionary<String, String> messagesList = new Dictionary<String, String>();
			switch (cmd)
			{
				case "MSGLISTOK":
					{
						if (data != "null")
						{
							String[] MessagesAndIds = data.Split(new char[] { '&' }, StringSplitOptions.RemoveEmptyEntries);
							foreach (String messageAndId in MessagesAndIds)
							{
								String[] MsgId = messageAndId.Split(new char[] { '^' }, StringSplitOptions.RemoveEmptyEntries);
								messagesList.Add(MsgId[0], MsgId[1]);
							}
						}
					}
					break;
				default:
					throw new Exception("Ошибка при получении ответа от сервера. Приложение будет закрыто.");
			}
			return messagesList;
		}

		static public void SendMessage(String message)
		{
			String answer;
			lock (ChatController.client)
			{
				answer = ChatController.client.SendMessage(message, ChatController.login);
			}
			String[] ss = answer.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
			String cmd = ss[0];
			String data = ss[1];

			switch (cmd)
			{
				case "NEWMSGOK":
					break;
				case "NEWMSGERROR":
					{
						MessageBox.Show(data);
					}
					break;
				default:
					throw new Exception("Ошибка при получении ответа от сервера. Приложение будет закрыто.");
			}
		}
	}
}

namespace Server
{
	[ServiceContract]
	public interface ChatService
	{
		[OperationContract]
		String Login(String login);

		[OperationContract]
		String GetUsers(String login);

		[OperationContract]
		String GetMessages(String lastMessageId, String login);

		[OperationContract]
		String SendMessage(String message, String login);
	}
}
