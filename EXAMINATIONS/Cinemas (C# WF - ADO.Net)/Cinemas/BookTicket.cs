using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinemas
{
	public partial class BookTicket : Form
	{
		public List<int[]> places = new List<int[]>();
		public String unique_id_hash;
		public Bitmap bmp;
		private int? user_id;
		private int Id;
		public BookTicket(Ticket ticket, Dictionary<int, Dictionary<int, int?>> bookedPlaces)
		{
			InitializeComponent();
			this.bmp = new Bitmap(this.ticket_info.Width, this.ticket_info.Height);
			this.Id = ticket.Id;
			this.user_id = (ticket.User_ == null) ? null : ticket.User_.Id;
			this.film.Text = ticket.Film;
			this.genre.Text = ticket.Genre;
			this.cinema.Text = ticket.Cinema;
			this.starttime.Text = ticket.StartTime.ToString();
			this.duration.Text = ticket.Duration.ToString();
			this.date.Text = ticket.Date.ToShortDateString();
			this.Text += " \"" + ticket.Film + "\"";
			if (ticket.User_ == null)
			{
				this.user.Text = "Гость";
			}
			else
			{
				this.user.Text = ticket.User_.Login;
				this.email.Enabled = false;
				this.phone.Enabled = false;
				this.email.Text = ticket.User_.Email;
				this.phone.Text = ticket.User_.Phone;
			}

			int rows = ticket.Rows;
			int cols = ticket.Columns;
			this.tableLayoutPanel7.RowCount = rows;
			this.tableLayoutPanel7.ColumnCount = cols + 1;
			this.tableLayoutPanel7.RowStyles.Clear();
			this.tableLayoutPanel7.ColumnStyles.Clear();
			ColumnStyle CS = new ColumnStyle(SizeType.Absolute, 60);
			this.tableLayoutPanel7.ColumnStyles.Add(CS);
			for (int i = 0; i < rows; i++)
			{
				RowStyle RS = new RowStyle(SizeType.Percent, 100 / rows);
				this.tableLayoutPanel7.RowStyles.Add(RS);
			}
			for (int i = 0; i < cols; i++)
			{
				CS = new ColumnStyle(SizeType.Percent, (100 / (cols + 1)));
				this.tableLayoutPanel7.ColumnStyles.Add(CS);
			}

			for (int i = 0; i < rows; i++)
			{
				Label p = new Label();
				p.Text = "Ряд " + (i + 1);
				p.Anchor = AnchorStyles.Bottom | AnchorStyles.Top;
				p.TextAlign = ContentAlignment.MiddleCenter;
				this.tableLayoutPanel7.Controls.Add(p, 0, i);
				for (int j = 0; j < cols; j++)
				{
					Label l = new Label();
					l.Margin = new Padding(5);
					l.Text = (j + 1).ToString();
					l.Anchor = AnchorStyles.Bottom | AnchorStyles.Top;
					l.TextAlign = ContentAlignment.MiddleCenter;
					l.Size = this.tableLayoutPanel7.ClientSize;
					Dictionary<int, int?> r;
					int? id;
					if (bookedPlaces != null && bookedPlaces.TryGetValue(i, out r) && r.TryGetValue(j, out id))
					{
						if (id != null && id == this.user_id)
						{
							l.BackColor = Color.Red;
							l.ForeColor = Color.LightGray;
							l.Cursor = Cursors.Hand;
							this.places.Add(new int[] { i, j });
						}
						else
						{
							l.BackColor = Color.Lime;
							l.ForeColor = Color.Black;
						}
					}
					else
					{
						l.ForeColor = Color.LightGray;
						l.BackColor = Color.Gray;
						l.Cursor = Cursors.Hand;
					}
					l.Tag = i + ";" + j;
					l.Click += (sender, e) =>
					{
						Label tmp = (Label)sender;
						String[] xy = tmp.Tag.ToString().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
						int x = Int32.Parse(xy[0]);
						int y = Int32.Parse(xy[1]);
						if (tmp.BackColor != Color.Lime && tmp.BackColor != Color.Red)
						{
							tmp.BackColor = Color.Red;
							this.places.Add(new int[] { x, y });
							this.WritePlaces();
						}
						else if (tmp.BackColor == Color.Red)
						{
							tmp.BackColor = Color.Gray;
							this.places.Remove(this.places.Find(t => t[0] == x && t[1] == y));
							this.WritePlaces();
						}
					};
					this.tableLayoutPanel7.Controls.Add(l, j + 1, i);
				}
			}
			this.WritePlaces();
			this.FormClosing += BookTicket_FormClosing;
		}

		private void BookTicket_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (this.DialogResult == DialogResult.OK)
			{
				if (this.email.Text.Trim() == "" || this.phone.Text.Trim() == "")
				{
					MessageBox.Show("Пожалуйста, введите Ваш E-mail и номер телефона", "Ошибка", MessageBoxButtons.OK);
					e.Cancel = true;
					return;
				}
				if (!this.email.Text.Contains("@") || !this.email.Text.Contains("."))
				{
					MessageBox.Show("Введен неверный формат E-mail", "Ошибка", MessageBoxButtons.OK);
					e.Cancel = true;
					return;
				}
				int count = 0;
				foreach (char c in this.phone.Text)
					if (c == ' ')
						count++;
				if (count > 2)
				{
					MessageBox.Show("Введен неверный формат номера телефона", "Ошибка", MessageBoxButtons.OK);
					e.Cancel = true;
					return;
				}
				this.unique_id_hash = Id.ToString() + ":";
				foreach (int[] place in this.places)
					unique_id_hash += place[1].ToString() + "," + place[0].ToString();
				this.unique_id_hash = Main.Md5Hash(this.unique_id_hash);
				this.id.Text = this.unique_id_hash;
				this.button3.Visible = false;
				this.ticket_info.DrawToBitmap(bmp, ticket_info.Bounds);
			}
		}

		private void WritePlaces()
		{
			if (this.places.Count != 0)
			{
				this.rc.Text = "";
				foreach (int[] xy in this.places)
				{
					this.rc.Text += String.Format("Ряд {0}, Место {1}\n", xy[0] + 1, xy[1] + 1);
				}
				this.button1.Enabled = true;
			}
			else
			{
				this.rc.Text = "Не выбрано";
				this.button1.Enabled = false;
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			foreach (int[] xy in this.places)
			{
				Label l = (Label)this.tableLayoutPanel7.GetControlFromPosition(xy[1] + 1, xy[0]);
				l.BackColor = Color.Gray;
			}
			this.places.Clear();
			this.rc.Text = "Не выбрано";
		}

		private void email_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (int)Keys.Space)
			{
				e.Handled = true;
			}
		}
	}
}
