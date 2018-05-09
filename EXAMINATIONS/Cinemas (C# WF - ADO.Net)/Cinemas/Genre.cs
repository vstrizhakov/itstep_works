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
	public partial class Genre : Form
	{
		public Genre(bool isEditing = false)
		{
			InitializeComponent();

			if (isEditing)
			{
				this.Text = "Редактирование жанра";
				this.button1.Text = "Редактировать";
			}
			else
			{
				this.Text = "Добавление жанра";
				this.button1.Text = "Добавить";
			}

			this.FormClosing += Genre_FormClosing;
		}

		private void Genre_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (this.DialogResult == DialogResult.OK)
			{
				if (this.name.Text.Trim() == "")
				{
					MessageBox.Show("Заполните все поля!");
					e.Cancel = true;
					return;
				}
			}
		}
	}
}
