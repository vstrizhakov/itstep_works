using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Films
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
				if (this.genres.Text.Trim() == "" || this.name.Text.Trim() == "")
				{
					MessageBox.Show("Заполните все поля!");
					e.Cancel = true;
					return;
				}
				using (var ctx = new masterEntities())
				{
					String genre = this.genres.Text;
					List<Genres> GS = (from t in ctx.Genres where t.name == genre select t).ToList();
					if (GS.Count == 0)
					{
						MessageBox.Show("Введенного жанра не существует", "Ошибка");
						e.Cancel = true;
					}
					else
					{
						this.id_genre = GS[0].id;
					}
				}
			}
		}
	}
}
