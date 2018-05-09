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

namespace RunningButtons
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			EventWaitHandle e12 = new EventWaitHandle(true, EventResetMode.AutoReset);
			EventWaitHandle e23 = new EventWaitHandle(false, EventResetMode.AutoReset);
			EventWaitHandle e31 = new EventWaitHandle(false, EventResetMode.AutoReset);
			ThreadButton TB1 = new ThreadButton(this, e12, e23, this.button1);
			ThreadButton TB2 = new ThreadButton(this, e23, e31, this.button3);
			ThreadButton TB3 = new ThreadButton(this, e31, e12, this.button2);

			Thread T1 = new Thread(TB1.PushButton);
			Thread T2 = new Thread(TB2.PushButton);
			Thread T3 = new Thread(TB3.PushButton);

			T1.IsBackground = true;
			T2.IsBackground = true;
			T3.IsBackground = true;

			T2.Start();
			T1.Start();
			T3.Start();
		}
	}

	class ThreadButton
	{
		private EventWaitHandle e1;
		private EventWaitHandle e2;
		private Button b;
		private bool Route = false;
		private Form1 f;

		public ThreadButton(Form1 f, EventWaitHandle e1, EventWaitHandle e2, Button b)
		{
			this.f = f;
			this.e1 = e1;
			this.e2 = e2;
			this.b = b;
		}

		public void PushButton()
		{
			while (true)
			{
				this.e1.WaitOne();
				while (true)
				{
					if (this.Route == false)
					{
						this.b.Left++;						
						if (this.f.ClientSize.Width - (this.b.Left + this.b.Width) <= 12)
							break;
					}
					else
					{
						this.b.Left--;
						if (this.b.Left <= 12)
							break;
					}
				}
				this.Route = !this.Route;
				this.e2.Set();
				Thread.Sleep(10);
			}
		}
	}
}
