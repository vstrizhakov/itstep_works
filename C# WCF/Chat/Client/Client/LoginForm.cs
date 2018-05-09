using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.IO;
using System.Configuration;

namespace Client
{
	public partial class LoginForm : Form
	{
		public LoginForm()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				ChatController.Initialize();
				if (ChatController.Login(this.login.Text) == true)
				{
					this.Hide();
					ChatForm CF = new ChatForm();
					CF.ShowDialog();
					this.Show();
				}
			}
			catch (Exception a)
			{
				if (MessageBox.Show(a.Message + " Хотите попробовать еще раз?", "Ошибка", MessageBoxButtons.YesNo) != DialogResult.Yes)
					this.Close();
			}
		}

		private void login_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
				this.button1_Click(sender, null);
		}
	}
}
