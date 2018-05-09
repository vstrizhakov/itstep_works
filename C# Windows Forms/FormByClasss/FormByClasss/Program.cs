using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace FormByClasss
{
	class Form1 : Form
	{
		private Button B1;
		private Button B2;
		private TextBox TB1;
		private TextBox TB2;

		private void InitializeComponent()
		{
			this.B1 = new Button();
			this.B1.Text = "First Button";
			this.B1.Size = new Size(100, 26);
			this.B1.Top = 20;
			this.B1.Left = 20;
			this.Controls.Add(B1);

			this.B2 = new Button();
			this.B2.Text = "Second Button";
			this.B2.Size = new Size(100, 26);
			this.B2.Top = 20;
			this.B2.Left = 120;
			this.Controls.Add(B2);

			this.TB1 = new TextBox();
			this.TB1.Text = "Sergey";
			this.TB1.Size = new Size(100, 26);
			this.TB1.Top = 46;
			this.TB1.Left = 20;
			this.Controls.Add(TB1);

			this.TB2 = new TextBox();
			this.TB2.Text = "Pidor";
			this.TB2.Size = new Size(100, 26);
			this.TB2.Top = 46;
			this.TB2.Left = 120;
			this.Controls.Add(TB2);

			this.B1.Click += Button_Click;
			this.B2.Click += Button_Click;

		}

		private void Button_Click(object sender, EventArgs arg)
		{
			if (sender == this.B1)
			{
				MessageBox.Show("В текстовое поле 1 введено: " + this.TB1.Text);
			}
			else if (sender == this.B2)
			{
				MessageBox.Show("В текстовое поле 2 введено: " + this.TB2.Text);
			}
		}

		public Form1()
		{
			this.InitializeComponent();
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			Form F = new Form1();
			F.ShowDialog();
		}
	}
}