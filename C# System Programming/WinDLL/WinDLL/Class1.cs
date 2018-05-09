using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinDLL
{
	public class Auto
	{
		private String marka;
		private String model;
		private int year;

		public Auto(String marka, String model, int year)
		{
			this.marka = marka;
			this.model = model;
			this.year = year;
		}

		public override string ToString()
		{
			return String.Format("Марка: {0}, Модель: {1}, Год: {2}", this.marka, this.model, this.year);
		}
	}

	public class MyForm : Form
	{
		private TextBox textBox1;
		private Button button1;

		public MyForm()
		{
			this.textBox1 = new TextBox();
			this.textBox1.Left = 20;
			this.textBox1.Top = 30;
			this.textBox1.Width = 180;
			this.textBox1.Height = 26;
			this.Controls.Add(this.textBox1);

			this.button1 = new Button();
			this.button1.Text = "Click";
			this.button1.Left = 220;
			this.button1.Top = 30;
			this.button1.Width = 120;
			this.button1.Height = 26;
			this.Controls.Add(this.button1);
			this.button1.Click += Button1_Click;
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			MessageBox.Show(this.textBox1.Text);
		}
	}

}
