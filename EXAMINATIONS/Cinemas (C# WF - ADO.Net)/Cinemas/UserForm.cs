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
	public partial class UserForm : Form
	{
		public UserForm(bool isEditing = false)
		{
			InitializeComponent();

			if (isEditing)
			{
				this.Text = "Редактирование аккаунта пользователя";
				this.label2.Text = "Новый пароль";
				this.button1.Text = "Редактировать";
				this.login.Enabled = false;
			}
			else
			{
				this.Text = "Добавление аккаунта пользователя";
				this.label2.Text = "Пароль";
				this.button1.Text = "Добавить";
				this.comboBox1.SelectedIndex = 1;
			}
			this.login.ShortcutsEnabled = false;
			this.password.ShortcutsEnabled = false;
			this.FormClosing += UserForm_FormClosing;
		}

		private void UserForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (this.DialogResult == DialogResult.OK)
			{
				if (this.login.Text.Trim() == "" || this.password.Text.Trim() == "")
				{
					MessageBox.Show("Заполните все поля!");
					e.Cancel = true;
					return;
				}
			}
		}

		private void password_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (int)Keys.Space)
			{
				e.Handled = true;
			}
		}
	}
}
