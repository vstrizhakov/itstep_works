using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Common;
using System.Data.SqlClient;

namespace Films
{
	public partial class Main : Form
	{
		public Main()
		{
			InitializeComponent();

			this.genres.Columns.Add("Название жанра", 200);
			this.films.Columns.Add("Название фильма", 200);
			this.films.Columns.Add("Жанр", 200);

			using (var ctx = new masterEntities())
			{
				var genres = from T in ctx.Genres select T;
				foreach (Genres G in genres)
				{
					ListViewItem LVI = new ListViewItem(G.name);
					LVI.SubItems.Add(G.id.ToString());
					this.genres.Items.Add(LVI);
				}

				var films = from T in ctx.Films select T;
				foreach (Films F in films)
				{
					ListViewItem LVI = new ListViewItem(F.name);
					LVI.SubItems.Add(F.Genres.name);
					LVI.SubItems.Add(F.id.ToString());
					this.films.Items.Add(LVI);
				}
			}
		}

		private void deleteBtn_Click(object sender, EventArgs e)
		{
			if (this.tabControl1.SelectedTab == this.tab1)
			{
				if (this.genres.SelectedItems.Count == 0)
				{
					MessageBox.Show("Выберите хотя бы один жанр для удаления");
					return;
				}
				String s = (this.genres.SelectedItems.Count < 2) ? "выбранный жанр" : "выбранные жанры";
				if (MessageBox.Show(String.Format("Вы уверенны, что хотите удалить {0}?", s), "Удаление", MessageBoxButtons.YesNo) == DialogResult.No)
					return;
				using (var ctx = new masterEntities())
				{
					foreach (ListViewItem LVI in this.genres.SelectedItems)
					{
						int id = Int32.Parse(LVI.SubItems[1].Text);
						Genres G = (from t in ctx.Genres where t.id == id select t).ToList()[0];

						foreach (Films F in G.Films)
							foreach (ListViewItem lvi in this.films.Items)
								if (lvi.SubItems[2].Text == F.id.ToString())
									this.films.Items.Remove(lvi);

						ctx.Genres.Remove(G);
						ctx.SaveChanges();
						this.genres.Items.RemoveAt(LVI.Index);
					}
				}
			}
			else if (this.tabControl1.SelectedTab == this.tab2)
			{
				using (var ctx = new masterEntities())
				{
					if (this.films.SelectedItems.Count == 0)
					{
						MessageBox.Show("Выберите хотя бы один фильм для удаления");
						return;
					}
					String s = (this.films.SelectedItems.Count < 2) ? "выбранный фильм" : "выбранные фильмы";
					if (MessageBox.Show(String.Format("Вы уверенны, что хотите удалить {0}?", s), "Удаление", MessageBoxButtons.YesNo) == DialogResult.No)
						return;
					foreach (ListViewItem LVI in this.films.SelectedItems)
					{
						int id = Int32.Parse(LVI.SubItems[2].Text);
						Films G = (from t in ctx.Films select t).ToList()[0];
						ctx.Films.Remove(G);
						ctx.SaveChanges();
						this.films.Items.RemoveAt(LVI.Index);
					}
				}
			}
		}

		private void addBtn_Click(object sender, EventArgs e)
		{
			if (this.tabControl1.SelectedTab == this.tab1)
			{
				using (var ctx = new masterEntities())
				{
					Genre GF = new Genre();
					if (GF.ShowDialog() == DialogResult.OK)
					{
						Genres G = new Genres() { name = GF.name.Text };
						ctx.Genres.Add(G);
						ctx.SaveChanges();
						ListViewItem LVI = new ListViewItem(G.name);
						LVI.SubItems.Add(G.id.ToString());
						this.genres.Items.Add(LVI);
					}
				}
			}
			else if (this.tabControl1.SelectedTab == this.tab2)
			{
				using (var ctx = new masterEntities())
				{
					Film FF = new Film();
					List<Genres> G = (from t in ctx.Genres select t).ToList();
					foreach (Genres g in G)
						FF.genres.Items.Add(g.name);
					if (FF.ShowDialog() == DialogResult.OK)
					{
						Films F = new Films() { name = FF.name.Text, id_genre = FF.id_genre };
						ctx.Films.Add(F);
						ctx.SaveChanges();
						ListViewItem LVI = new ListViewItem(F.name);
						LVI.SubItems.Add(FF.genres.Text);
						LVI.SubItems.Add(F.id.ToString());
						this.films.Items.Add(LVI);
					}
				}
			}
		}

		private void editBtn_Click(object sender, EventArgs e)
		{
			if (this.tabControl1.SelectedTab == this.tab1)
			{
				if (this.genres.SelectedItems.Count == 0)
				{
					MessageBox.Show("Выберите жанр для редактирования");
					return;
				}
				using (var ctx = new masterEntities())
				{
					Genre GF = new Genre();

					ListViewItem LVI = this.genres.SelectedItems[0];
					GF.name.Text = LVI.Text;
					int index = LVI.Index;

					if (GF.ShowDialog() == DialogResult.OK)
					{
						int id = Int32.Parse(LVI.SubItems[1].Text);
						Genres G = ctx.Genres.SingleOrDefault(t => t.id == id);
						G.name = GF.name.Text;
						ctx.SaveChanges();
						LVI.Text = G.name;

						foreach (Films F in G.Films)
							foreach (ListViewItem lvi in this.films.Items)
								if (lvi.SubItems[2].Text == F.id.ToString())
									lvi.SubItems[1].Text = G.name;

					}
				}
			}
			else if (this.tabControl1.SelectedTab == this.tab2)
			{
				if (this.films.SelectedItems.Count == 0)
				{
					MessageBox.Show("Выберите фильм для редактирования");
					return;
				}
				using (var ctx = new masterEntities())
				{
					Film FF = new Film();
					List<Genres> G = (from t in ctx.Genres select t).ToList();
					foreach (Genres g in G)
						FF.genres.Items.Add(g.name);

					ListViewItem LVI = this.films.SelectedItems[0];
					FF.genres.SelectedIndex = FF.genres.Items.IndexOf(LVI.SubItems[1].Text);
					FF.name.Text = LVI.Text;
					int index = LVI.Index;

					if (FF.ShowDialog() == DialogResult.OK)
					{
						int id = Int32.Parse(LVI.SubItems[2].Text);
						Films F = ctx.Films.SingleOrDefault(t => t.id == id);
						F.name = FF.name.Text;
						F.id_genre = FF.id_genre;
						ctx.SaveChanges();
						LVI.Text = F.name;
						LVI.SubItems[1].Text = FF.genres.Text;
					}
				}
			}
		}
	}
}
