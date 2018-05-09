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

namespace Client
{
	public partial class Form1 : Form
	{
		private TcpClient client;
		private NetworkStream NS;
		private MemoryStream MS = new MemoryStream();
		private byte[] buf = new byte[2048];
		public Form1()
		{
			InitializeComponent();

			this.Load += Form1_Load;
			this.FormClosing += Form1_FormClosing;
			this.button1.Enabled = false;
			this.button2.Enabled = false;
			this.button3.Enabled = false;
			this.button4.Enabled = false;
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			this.MS.Close();
			if (this.NS != null)
				this.NS.Close();
			if (this.client != null)
				this.client.Close();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			try
			{
				this.client = new TcpClient("10.3.60.158", 5555);
				this.NS = this.client.GetStream();
			}
			catch (Exception a)
			{
				MessageBox.Show(a.Message);
				this.Close();
			}
		}

		private void firstNumber_TextChanged(object sender, EventArgs e)
		{
			double x = 0, y = 0;
			bool isValidated = false;
			try
			{
				x = Double.Parse(this.firstNumber.Text);
				y = Double.Parse(this.secondNumber.Text);
				isValidated = true;
			}
			catch { }
			if (this.firstNumber.Text.Trim() != "" && this.secondNumber.Text.Trim() != "" && isValidated == true)
			{
				this.button1.Enabled = true;
				this.button2.Enabled = true;
				this.button3.Enabled = true;
				this.button4.Enabled = (y != 0) ? true : false;
			}
			else
			{
				this.button1.Enabled = false;
				this.button2.Enabled = false;
				this.button3.Enabled = false;
				this.button4.Enabled = false;
			}
		}

		private void SendToServer(object sender, EventArgs e)
		{
			Button btn = (Button)sender;
			String operation = btn.Tag.ToString();

			try
			{
				String cmd = operation + "|" + this.firstNumber.Text + "&" + this.secondNumber.Text;
				byte[] to = Encoding.UTF8.GetBytes(cmd);
				NS.Write(to, 0, to.Length);

				do
				{
					int cnt = NS.Read(this.buf, 0, this.buf.Length);
					if (cnt == 0)
						throw new Exception("0 bytes received");
					this.MS.Write(this.buf, 0, cnt);
				}
				while (this.NS.DataAvailable);

				String result = Encoding.UTF8.GetString(MS.GetBuffer(), 0, (int)MS.Position);
				MS.SetLength(0);
				String[] ss = result.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
				if (ss[0] == operation + "OK")
				{
					this.result.Text = ss[1];
				}
				else
				{
					if (ss[0] == "DIVIDEERROR")
					{
						MessageBox.Show("Делить на ноль нельзя!");
					}
					else
					{
						MessageBox.Show("Ошибка при получении ответа от сервера. Приложение будет закрыто.");
						this.Close();
					}
				}
			}
			catch
			{
				MessageBox.Show("Соединение с сервером разорвано. Приложение будет закрыто");
				this.Close();
			}
		}
	}
}
