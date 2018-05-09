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
	public partial class Film : Form
	{
		public int id_genre { get; set; }
		public Film(bool isEditing = false)
		{
			InitializeComponent();

			if (isEditing)
			{
				this.Text = "Редактирование фильма";
				this.button1.Text = "Редактировать";
			}
			else
			{
				this.Text = "Добавление фильма";
				this.button1.Text = "Добавить";
			}

			this.FormClosing += Film_FormClosing;
		}

		private void Film_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (this.DialogResult == DialogResult.OK)
			{
				if (this.genres.Text.Trim() == "" || this.name.Text.Trim() == "" || this.duration.Text.Trim() == "")
				{
					MessageBox.Show("Заполните все поля!");
					e.Cancel = true;
					return;
				}
				try
				{
					Int32.Parse(this.duration.Text);
				}
				catch (Exception)
				{
					MessageBox.Show("Длительность фильма введена в неправильном виде");
					e.Cancel = true;
					return;
				}
			}
		}

		private void genres_KeyUp(object sender, KeyEventArgs e)
		{
			e.Handled = false;
		}
	}
}
