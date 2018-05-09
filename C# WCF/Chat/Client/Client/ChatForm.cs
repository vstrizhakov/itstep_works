using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace Client
{
	public partial class ChatForm : Form
	{
		private Thread UsersThread;
		private Thread MessagesThread;
		public ChatForm()
		{
			InitializeComponent();
			this.Shown += ChatForm_Load;
			this.messages.HeaderStyle = ColumnHeaderStyle.None;
			this.FormClosing += ChatForm_FormClosing;
		}

		private void ChatForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			UsersThread.Abort();
			MessagesThread.Abort();
		}

		private void ChatForm_Load(object sender, EventArgs e)
		{
			UsersThread = new Thread(this.GetUsersList);
			UsersThread.IsBackground = true;
			UsersThread.Start();

			MessagesThread = new Thread(this.GetMessagesList);
			MessagesThread.IsBackground = true;
			MessagesThread.Start();
		}

		private void GetUsersList()
		{
			while (true)
			{
				try
				{
					List<String> usersList = ChatController.GetUsers();
					this.users.Invoke(new Action(() =>
					{
						this.users.Items.Clear();
						if (usersList != null)
						{
							foreach (String user in usersList)
							{
								this.users.Items.Add(user);
							}
						}
					}));
				}
				catch (ThreadAbortException) { }
				catch (Exception e)
				{
					MessagesThread.Abort();
					MessageBox.Show(e.Message);
					this.Invoke(new Action(() => { this.Close(); }));
				}
				Thread.Sleep(3000);
			}
		}

		private void GetMessagesList()
		{
			while (true)
			{
				try
				{
					Dictionary<String, String> messagesList = ChatController.GetMessages(this.messages.Tag.ToString());
					this.messages.Invoke(new Action(() =>
					{
						if (messagesList != null)
						{
							ICollection<String> msgIds = messagesList.Keys;
							foreach (String id in msgIds)
							{
								ListViewItem LVI = new ListViewItem(messagesList[id]);
								this.messages.Items.Add(LVI);
								this.messages.Tag = id;
							}
							this.messages.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
						}
					}));
				}
				catch (ThreadAbortException) { }
				catch (Exception e)
				{
					UsersThread.Abort();
					MessageBox.Show(e.Message);
					this.Invoke(new Action(() => { this.Close(); }));
				}
				Thread.Sleep(5000);
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				ChatController.SendMessage(this.message.Text);
				this.message.Text = "";
			}
			catch (Exception a)
			{
				MessagesThread.Abort();
				UsersThread.Abort();
				MessageBox.Show(a.Message);				
				this.Close();
			}
		}

		private void message_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
				this.button1_Click(null, null);
		}
	}
}
