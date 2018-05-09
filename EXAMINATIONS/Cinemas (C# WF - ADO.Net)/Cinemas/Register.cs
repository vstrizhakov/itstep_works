using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinemas
{
	public partial class Register : Form
	{
		public Register()
		{
			InitializeComponent();
			this.FormClosing += Register_FormClosing;
		}

		private void Register_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (this.DialogResult == DialogResult.OK)
			{
				if (this.login.Text.Trim() == "" || this.pswd.Text.Trim() == "" || this.phone.Text.Trim() == "" || this.email.Text.Trim() == "")
				{
					MessageBox.Show("Заполните все поля", "Ошибка");
					e.Cancel = true;
					return;
				}
				if (!this.email.Text.Contains("@") || !this.email.Text.Contains("."))
				{
					MessageBox.Show("Введен неверный формат E-mail", "Ошибка", MessageBoxButtons.OK);
					e.Cancel = true;
					return;
				}
			}
		}

		private void login_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (int)Keys.Space)
			{
				e.Handled = true;
			}
		}
	}
}
