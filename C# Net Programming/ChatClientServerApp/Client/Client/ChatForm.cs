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
		private String username;
		public ChatForm(String username)
		{
			InitializeComponent();
			this.username = username;
			this.Shown += ChatForm_Load;
			this.messages.HeaderStyle = ColumnHeaderStyle.None;
			this.FormClosing += ChatForm_FormClosing;
		}

		private void ChatForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			UsersThread.Abort();
			MessagesThread.Abort();
			ChatController.Close();
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
				lock (this)
				{
					try
					{
						List<String> usersList = ChatController.GetUsers();
						if (usersList != null)
						{
							this.users.Invoke(new Action(() =>
							{
								this.users.Items.Clear();
								foreach (String user in usersList)
								{
									this.users.Items.Add(user);
								}
							}));
						}
					}
					catch (Exception e)
					{
						MessageBox.Show(e.Message);
						this.Invoke(new Action(() => { this.Close(); }));
					}
				}
				Thread.Sleep(3000);
			}
		}

		private void GetMessagesList()
		{
			while (true)
			{
				lock (this)
				{
					try
					{
						Dictionary<String, String> messagesList = ChatController.GetMessages(this.messages.Tag.ToString());
						if (messagesList != null)
						{
							this.messages.Invoke(new Action(() =>
							{
								ICollection<String> msgIds = messagesList.Keys;
								foreach (String id in msgIds)
								{
									ListViewItem LVI = new ListViewItem(messagesList[id]);
									this.messages.Items.Add(LVI);
									this.messages.Tag = id;
								}
								this.messages.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
							}));
						}
					}
					catch (Exception e)
					{
						MessageBox.Show(e.Message);
						this.Invoke(new Action(() => { this.Close(); }));
					}
				}
				Thread.Sleep(5000);
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			lock (this)
			{
				try
				{
					ChatController.SendMessage(this.username + ": " + this.message.Text);
					this.message.Text = "";
				}
				catch (Exception a)
				{
					MessageBox.Show(a.Message);
					this.Close();
				}
			}
		}

		private void message_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
				this.button1_Click(null, null);
		}
	}
}
