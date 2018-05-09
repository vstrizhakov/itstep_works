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

namespace ThreadsWithListBox
{
	public partial class Form1 : Form
	{
		Thread T;
		private delegate void abc(String str);
		private void HelloMethod(String str)
		{
			this.listBox1.Items.Add(str);
		}
		public Form1()
		{
			InitializeComponent();

			this.Load += Form1_Load;
			this.FormClosing += Form1_FormClosing;
		}

		private void Run()
		{
			int cnt = 0;
			abc A = new abc(HelloMethod);
			while (true)
			{
				Thread.Sleep(1000);
				this.listBox1.Invoke(A, "Item " + (cnt++)); // Вторичный поток останавливается, пока в первичном потоке
															// не отработает метод HelloMethod
			}
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			this.T.Interrupt();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			this.T = new Thread(this.Run);
			this.T.IsBackground = true;
			this.T.Start();
		}
	}
}
