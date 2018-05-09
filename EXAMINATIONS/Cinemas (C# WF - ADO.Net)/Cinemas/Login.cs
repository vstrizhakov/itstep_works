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
	public partial class Login : Form
	{
		public Login()
		{
			InitializeComponent();

			this.FormClosing += Login_FormClosing;
		}

		private void Login_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (this.DialogResult == DialogResult.OK)
			{
				if (this.log.Text.Trim() == "" || this.password.Text.Trim() == "")
				{
					MessageBox.Show("Заполните все поля");
					e.Cancel = true;
					return;
				}
			}
		}

		private void log_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (int)Keys.Space)
			{
				e.Handled = true;
			}
		}
	}
}
