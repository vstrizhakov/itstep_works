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
	public partial class Cinema : Form
	{
		public Cinema(bool isEditing = false)
		{
			InitializeComponent();

			if (isEditing)
			{
				this.Text = "Редактирование кинотеатра";
				this.button1.Text = "Редактировать";
			}
			else
			{
				this.Text = "Добавление кинотеатра";
				this.button1.Text = "Добавить";
			}

			this.FormClosing += Film_FormClosing;
		}

		private void Film_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (this.DialogResult == DialogResult.OK)
			{
				if (this.name.Text.Trim() == "" || this.rows.Text.Trim() == "" || this.cols.Text.Trim() == "")
				{
					MessageBox.Show("Заполните все поля!");
					e.Cancel = true;
					return;
				}
			}
		}
	}
}
