using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ButtonSemaphore
{
	public partial class Form1 : Form
	{
		private Semaphore S = new Semaphore(2, 2);
		private Thread T1;
		private Thread T2;
		private Thread T3;
		private Thread T4;
		public Form1()
		{
			InitializeComponent();
			this.Load += Form1_Load;
			this.FormClosing += Form1_FormClosing;
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			this.T1.Abort();
			this.T2.Abort();
			this.T3.Abort();
			this.T4.Abort();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			this.T1 = new Thread(this.MoveDown);
			this.T1.IsBackground = true;
			this.T1.Start();

			this.T2 = new Thread(this.MoveLeft);
			this.T2.IsBackground = true;
			this.T2.Start();

			this.T3 = new Thread(this.MoveUp);
			this.T3.IsBackground = true;
			this.T3.Start();

			this.T4 = new Thread(this.MoveRight);
			this.T4.IsBackground = true;
			this.T4.Start();
		}

		private void MoveUp()
		{
			while (true)
			{
				this.S.WaitOne();
				for (int i = 0; i < 100; i++)
				{
					this.button1.Invoke(
						new Action(
							() =>
							{
								this.button1.Top--;
							}
							)
						);
					Thread.Sleep(10);
				}
				this.S.Release();
				Thread.Sleep(10);
			}
		}

		private void MoveDown()
		{
			while (true)
			{
				this.S.WaitOne();
				for (int i = 0; i < 100; i++)
				{
					this.button1.Invoke(
						new Action(
							() =>
							{
								this.button1.Top++;
							}
							)
						);
					Thread.Sleep(10);
				}
				this.S.Release();
				Thread.Sleep(10);
			}
		}

		private void MoveLeft()
		{
			while (true)
			{
				this.S.WaitOne();
				for (int i = 0; i < 100; i++)
				{
					this.button1.Invoke(
						new Action(
							() =>
							{
								this.button1.Left--;
							}
							)
						);
					Thread.Sleep(10);
				}
				this.S.Release();
				Thread.Sleep(10);
			}
		}

		private void MoveRight()
		{
			while (true)
			{
				this.S.WaitOne();
				for (int i = 0; i < 100; i++)
				{
					this.button1.Invoke(
						new Action(
							() =>
							{
								this.button1.Left++;
							}
							)
						);
					Thread.Sleep(10);
				}
				this.S.Release();
				Thread.Sleep(10);
			}
		}
	}
}
