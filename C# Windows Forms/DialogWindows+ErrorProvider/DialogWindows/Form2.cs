using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DialogWindows
{
	public partial class Form2 : Form
	{
		public Form2()
		{
			InitializeComponent();
			this.FormClosing += Form2_FormClosing;
		}

		private void Form2_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (this.DialogResult == DialogResult.OK)
			{
				if (this.lastName.Text == "")
				{
					//MessageBox.Show("Заполните все данные!");
					this.errorProvider1.SetError(this.lastName, "Не введена фамилия");
					e.Cancel = true;
				}
				else
					this.errorProvider1.SetError(this.lastName, "");
				if (this.firstName.Text == "")
				{
					//MessageBox.Show("Заполните все данные!");
					this.errorProvider1.SetError(this.firstName, "Не введено имя");
					e.Cancel = true;
				}
				else
					this.errorProvider1.SetError(this.firstName, "");
			}
		}

		private void Form2_Load(object sender, EventArgs e)
		{

		}

		private void lastName_Leave(object sender, EventArgs e)
		{
			if (sender == this.lastName)
			{
				if (this.lastName.Text == "")
					this.errorProvider1.SetError(this.lastName, "Не введена фамилия");
				else
					this.errorProvider1.SetError(this.lastName, "");
			}
			if (sender == this.firstName)
			{
				if (this.firstName.Text == "")
					this.errorProvider1.SetError(this.firstName, "Не введено имя");
				else
					this.errorProvider1.SetError(this.firstName, "");
			}
		}
	}
}
