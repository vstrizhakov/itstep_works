using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecondWF
{
	public partial class Form1 : Form
	{
		private Label L;
		public Form1()
		{
			InitializeComponent();
			this.MouseClick += Form1_MouseClick;
			this.MouseDoubleClick += Form1_MouseClick;

			Panel P = new Panel();
			P.Width = 100;
			P.Height = 100;
			P.Top = 20;
			P.Left = 20;
			P.BackColor = Color.Red;
			this.Controls.Add(P);

			P.MouseMove += P_MouseMove;
			this.L = new Label();
			L.Size = new Size(80, 26);
			L.Location = new Point(10, 10);
			P.Controls.Add(L);
		}

		private void P_MouseMove(object sender, MouseEventArgs e)
		{
			this.L.Text = "X Y";
		}

		private void Form1_MouseClick(object sender, MouseEventArgs e)
		{
			String str = "Клик: " + e.Button + ", кол-во: " + e.Clicks + ", X: " + e.X + ", Y: " + e.Y;
			this.Text = str;
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}
	}
}
