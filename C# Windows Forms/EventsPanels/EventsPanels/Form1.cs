using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventsPanels
{
	public partial class Form1 : Form
	{
		private Button btnOne, btnTwo;
		private bool isDisabled = false;
		private Panel P;
		public Form1()
		{
			InitializeComponent();
			this.P = new Panel();
			this.P.Size = new Size(100, 100);
			this.P.Location = new Point(10, 10);
			this.P.BackColor = Color.Red;
			this.Controls.Add(P);

			this.btnOne = new Button();
			this.btnOne.Text = "Button One";
			this.btnOne.Size = new Size(80, 26);
			this.btnOne.Location = new Point(10, 10);
			this.P.Controls.Add(btnOne);

			this.btnTwo = new Button();
			this.btnTwo.Text = "Button Two";
			this.btnTwo.Size = new Size(80, 26);
			this.btnTwo.Location = new Point(10, 46);
			this.P.Controls.Add(btnTwo);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.isDisabled = !this.isDisabled;
			this.P.Enabled = !this.isDisabled;
			this.button1.Text = (this.isDisabled) ? "Вклчюить панель" : "Отключить панель";
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (this.P.Left + this.P.Width < this.Width)
				this.P.Left += 5;
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}
	}
}
