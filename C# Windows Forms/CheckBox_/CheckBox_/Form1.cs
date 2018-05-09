using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckBox_
{
	public partial class Form1 : Form
	{
		//private CheckBox CB;
		//private bool isTest = true;
		private int Red, Green, Blue;
		public Form1()
		{
			InitializeComponent();
			//this.CB = new CheckBox();
			//this.CB.Location = new Point(20, 20);
			//this.CB.Size = new Size(100, 26);
			//this.CB.Text = "Зеленый";
			//this.Controls.Add(CB);

			////this.CB.AutoCheck = false;
			////this.CB.Click += CB_Click;
			//this.CB.ThreeState = true;
		}

		//private void CB_Click(object sender, EventArgs e)
		//{
		//	this.CB.Checked = this.isTest;
		//	this.isTest = !this.isTest;
		//}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			Red = (this.checkBox1.Checked) ? 255 : 0;
			Green = (this.checkBox2.Checked) ? 255 : 0;
			Blue = (this.checkBox3.Checked) ? 255 : 0;
			this.BackColor = Color.FromArgb(this.Red, this.Green, this.Blue);
			this.ForeColor = Color.FromArgb((Red == 255) ? 0 : 255, (Green == 255) ? 0 : 255, (Blue == 255) ? 0 : 255);
		}
	}
}
