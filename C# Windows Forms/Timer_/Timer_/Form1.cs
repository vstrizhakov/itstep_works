using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Timer_
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			this.timer1.Interval = 1000;
			this.timer1.Tick += Timer1_Tick;
		}

		private void Timer1_Tick(object sender, EventArgs e)
		{
			DateTime DT = DateTime.Now;
			this.timer.Text = String.Format("{0:D2}:{1:D2}:{2:D2}", DT.Hour, DT.Minute, DT.Second);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.timer1.Enabled = true;
			this.stop.Enabled = true;
			this.start.Enabled = false;
		}

		private void stop_Click(object sender, EventArgs e)
		{
			this.timer1.Enabled = false;
			this.stop.Enabled = false;
			this.start.Enabled = true;
		}
	}
}
