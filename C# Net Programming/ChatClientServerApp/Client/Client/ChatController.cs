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

namespace Client
{
	static class ChatController
	{
		static private TcpClient client;
		static private NetworkStream NS;
		static private MemoryStream MS;
		static private byte[] buf = new byte[2048];

		static public void Initialize(TcpClient client)
		{
			ChatController.client = client;
			ChatController.NS = ChatController.client.GetStream();
			ChatController.MS = new MemoryStream();
		}

		static public void Close()
		{
			if (MS != null)
				ChatController.MS.Close();
			if (ChatController.NS != null)
				ChatController.NS.Close();
			if (ChatController.client != null)
				ChatController.client.Close();
		}

		static private String[] SendCommand(String cmd, String data = "null")
		{
			String outputCmd = cmd + "|" + data;
			byte[] outputData = Encoding.UTF8.GetBytes(outputCmd);
			NS.Write(outputData, 0, outputData.Length);

			do
			{
				int cnt = ChatController.NS.Read(ChatController.buf, 0, ChatController.buf.Length);
				if (cnt == 0)
					throw new Exception("Ошибка при получении ответа от сервера. Приложение будет закрыто.");
				ChatController.MS.Write(ChatController.buf, 0, cnt);
			}
			while (ChatController.NS.DataAvailable);

			String inputData = Encoding.UTF8.GetString(ChatController.MS.GetBuffer(), 0, (int)ChatController.MS.Position);
			ChatController.MS.SetLength(0);
			String[] ss = inputData.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

			// Если данные получены в виде, отличном от протокола, разрываем соединение
			if (ss.Length != 2)
				throw new Exception("Ошибка при получении ответа от сервера. Приложение будет закрыто.");

			return ss;
		}

		static public bool Login(String login)
		{
			String[] ss = ChatController.SendCommand("LOGIN", login);

			String cmd = ss[0];
			String data = ss[1];

			bool result = false;
			switch (cmd)
			{
				case "LOGINOK":
					{
						result = true;
					}
					break;
				case "LOGINERROR":
					{
						MessageBox.Show(data);
					}
					break;
				default:
					throw new Exception("Ошибка при получении ответа от сервера. Приложение будет закрыто.");
			}
			return result;
		}

		static public List<String> GetUsers()
		{
			String[] ss = ChatController.SendCommand("USERLIST");
			String cmd = ss[0];
			String data = ss[1];

			List<String> UsersList = null;
			switch (cmd)
			{
				case "USERLISTOK":
					{
						UsersList = data.Split(new char[] { '^' }, StringSplitOptions.RemoveEmptyEntries).ToList();
					}
					break;
				default:
					throw new Exception("Ошибка при получении ответа от сервера. Приложение будет закрыто.");
			}
			return UsersList;
		}

		static public Dictionary<String, String> GetMessages(String id)
		{
			String[] ss = ChatController.SendCommand("MSGLIST", id);
			String cmd = ss[0];
			String data = ss[1];

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
			String[] ss = ChatController.SendCommand("NEWMSG", message);
			String cmd = ss[0];
			String data = ss[1];

			switch (cmd)
			{
				case "NEWMSGOK":
					{
						//
					}
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
