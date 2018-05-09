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
using System.Configuration;
using System.IO;
using System.Security.Cryptography;
using System.Drawing.Imaging;
using System.Threading;

namespace Cinemas
{
	public partial class Main : Form
	{
		private DbConnection cn;
		private String SearchInput = "";
		private String SearchFilter;
		private String CurrentPage = "По всему";
		private AutoCompleteStringCollection AutoCompleteList = new AutoCompleteStringCollection();
		private Dictionary<String, String> FilterToTableName = new Dictionary<String, String>();
		private Dictionary<String, Button> PageToMenuButton = new Dictionary<String, Button>();
		private DbCommand cmd;
		private String SelectedDateFrom;
		private String SelectedDateTo;
		private Button SelectedMenuItem;
		static private String Salt1 = @"edQKQ49zEv0UY2SHX3x44mw7W1NHu68C";
		static private byte[] Salt2 = Encoding.UTF8.GetBytes(@"TG57jXyU36UDLu6dg4cd5cUp347OWt2e");
		private byte[] AesKey = Encoding.UTF8.GetBytes(@"f50HLJic3GtzVRlmOjueVp02jc64V7KD");
		private byte[] AesIV = Encoding.UTF8.GetBytes(@"Ge119N2vandU832v");
		private String userTokenFile = "user.dat";
		private ListViewGroup LVGFilms = new ListViewGroup();
		private ListViewGroup LVGGenres = new ListViewGroup();
		private User user;
		private Calendar CalendarForm = new Calendar();
		private TabPage PrevTP;
		private String CinemaIdFilter;
		private String CinemaNameFilter;
		private String GenreIdFilter;
		private String GenreNameFilter;
		private ContextMenu CM;
		public Main()
		{
			InitializeComponent();

			/* Настройки и соединение с БД */
			String provider = ConfigurationManager.AppSettings["provider"];
			String connectionString = ConfigurationManager.AppSettings["connectionString"];
			DbProviderFactory DFP = DbProviderFactories.GetFactory(provider);
			this.cn = DFP.CreateConnection();
			this.cn.ConnectionString = connectionString;
			this.cmd = DFP.CreateCommand();
			this.cmd.Connection = this.cn;
			this.cn.Open();
			/* --------------- */

			/* Идентификация пользователя */
			if (File.Exists(userTokenFile))
			{
				String UserToken = null;
				try
				{
					UserToken = DecryptAesToken(new FileStream(userTokenFile, FileMode.Open, FileAccess.Read));
				}
				catch (Exception) { }
				if (UserToken != null)
				{
					String[] UserData = UserToken.Split(new String[] { Main.Salt1 }, StringSplitOptions.RemoveEmptyEntries);
					this.user = this.Login(UserData);
				}
			}
			/* -------------------------- */

			/* Инициализация словаря соответствий фильтра к названию таблицы */
			this.FilterToTableName.Add("По всему", "Films;Genres;Cinemas");
			this.FilterToTableName.Add("По фильмам", "Films");
			this.FilterToTableName.Add("По жанрам", "Genres");
			this.FilterToTableName.Add("По кинотеатрам", "Cinemas");
			this.FilterToTableName.Add("Tickets", "Tickets");
			this.FilterToTableName.Add("ПУ", "ПУ");
			/* ------------------------------------------------------------- */

			/* Инициализация словаря соответствий страниц к кнопке меню */
			this.PageToMenuButton.Add("По всему", this.button5);
			this.PageToMenuButton.Add("По фильмам", this.button1);
			this.PageToMenuButton.Add("По жанрам", this.button3);
			this.PageToMenuButton.Add("По кинотеатрам", this.button2);
			this.PageToMenuButton.Add("Tickets", this.button6);
			this.PageToMenuButton.Add("ПУ", this.button4);
			/* -------------------------------------------------------- */

			/* Заполняем TabControl датами */
			DateTime date = DateTime.Now;
			for (int i = 0; i < 14; i++)
			{
				this.tabControl1.TabPages.Add(date.Date.ToShortDateString());
				this.tabControl1.TabPages[i].BackColor = Color.White;
				this.tabControl1.TabPages[i].Anchor = AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
				this.tabControl1.TabPages[i].AutoScroll = true;
				this.tabControl1.TabPages[i].Tag = date.Date.ToShortDateString();
				date = date.AddDays(1);
			}
			/* -------------------------- */

			/* Настройка свойств, событий формы */
			this.search_filter.SelectedIndex = 0;
			this.tabControl1_Selected(this.tabControl1, null);
			this.FormClosing += (sender, e) =>
			{
				this.cn.Close();
			};
			this.search_input.AutoCompleteCustomSource = this.AutoCompleteList;
			this.genres_result_table.DoubleClick += this.ResultItemClick;
			this.cinemas_result_table.DoubleClick += this.ResultItemClick;
			this.films_result_table.DoubleClick += this.BookATicket;
			this.result_table.DoubleClick += this.ResultItemClick;
			this.tableLayoutPanel2.Controls.Add(this.tabControl1, 0, 1);
			this.tableLayoutPanel2.Controls.Add(this.tabControl2, 0, 1);
			this.tabControl2.SelectedIndexChanged += TabControl2_SelectedIndexChanged;
			this.tabControl2.SelectedIndex = 0;
			this.TabControl2_SelectedIndexChanged(this.tabControl2, null);
			this.tabControl2.Visible = false;
			this.tableLayoutPanel6.Controls.Add(this.tabControl3, 0, 0);
			this.tabControl3.Visible = false;
			this.button4.Click += ChangeResults;
			this.button6.Click += ChangeResults;
			this.listView1.Anchor = AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.listView1.View = View.Details;
			this.listView1.BorderStyle = BorderStyle.None;
			this.tabControl3.Anchor = AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.tabControl3.SelectedIndexChanged += TabControl3_SelectedIndexChanged;
			this.listView1.FullRowSelect = true;
			this.listView1.GridLines = true;
			this.result_table.MultiSelect = false;
			this.films_result_table.MultiSelect = false;
			this.genres_result_table.MultiSelect = false;
			this.cinemas_result_table.MultiSelect = false;
			this.listView1.HideSelection = false;
			this.result_table.HideSelection = false;
			this.films_result_table.HideSelection = false;
			this.genres_result_table.HideSelection = false;
			this.cinemas_result_table.HideSelection = false;
			this.button7.Click += Add;
			this.button8.Click += Delete;
			this.button9.Click += Edit;
			this.Size = new Size(1000, 600);
			this.listView1.KeyDown += ListView1_KeyDown;
			this.CM = new ContextMenu();
			MenuItem menuItem = new MenuItem("Отменить бронь");
			menuItem.Click += MenuOpen_Click;
			this.CM.MenuItems.Add(menuItem);
			this.result_table.SelectedIndexChanged += Result_table_SelectedIndexChanged;
			this.linkLabel1.Click += LinkLabel1_Click;
			/* -------------------------------- */
		}

		private void LinkLabel1_Click(object sender, EventArgs e)
		{
			this.ChangeResults(this.button5, null);
			this.tableLayoutPanel5.Controls.Remove(this.button6);
			this.loginButton.Visible = true;
			this.registerButton.Visible = true;
			this.tableLayoutPanel5.Controls.Remove(this.button4);
			this.tableLayoutPanel7.Controls.Remove(this.linkLabel1);
			if (File.Exists(this.userTokenFile))
			{
				File.Delete(this.userTokenFile);
			}
			this.user = null;
		}

		private void Result_table_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.CurrentPage == "Tickets")
			{
				this.CM.MenuItems[0].Enabled = (this.result_table.SelectedItems.Count == 0) ? false : true;
				this.result_table.ContextMenu = (this.result_table.SelectedItems.Count == 0) ? null : this.CM;
			}
		}

		private void MenuOpen_Click(object sender, EventArgs e)
		{
			if (this.result_table.SelectedItems.Count != 0)
			{
				foreach (ListViewItem LVI in this.result_table.SelectedItems)
				{
					cmd.CommandText = String.Format("DELETE FROM Tickets WHERE id = {0}", LVI.Tag);
					cmd.ExecuteNonQuery();
				}
			}
			this.LoadResults(null);
		}

		private void ListView1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.A && e.Modifiers == Keys.Control)
			{
				foreach (ListViewItem LVI in this.listView1.Items)
					LVI.Selected = true;
			}
		}

		private void TabControl3_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.TabControl2_SelectedIndexChanged(null, null);
			this.button7.Text = (this.tabControl3.SelectedIndex == 1) ? "Возобновить" : "Добавить";
		}

		private void Edit(object sender, EventArgs e)
		{
			if (this.listView1.SelectedItems.Count == 0)
			{
				MessageBox.Show("Выберите элемент, который хотите отредактировать", "Ошибка", MessageBoxButtons.OK);
				return;
			}
			ListViewItem LVI = this.listView1.SelectedItems[0];
			switch (this.tabControl2.SelectedTab.Text)
			{
				case "Фильмы":
					{
						Film FilmForm = new Film(true);
						cmd.CommandText = "SELECT name FROM Genres";
						DbDataReader DR = cmd.ExecuteReader();
						int i = 0;
						while (DR.Read())
						{
							FilmForm.genres.Items.Add(DR.GetString(0));
							if (DR.GetString(0) == LVI.SubItems[1].Text)
								FilmForm.genres.SelectedIndex = i;
							i++;
						}
						DR.Close();
						FilmForm.name.Text = LVI.Text;
						FilmForm.duration.Text = LVI.SubItems[2].Text;
						if (FilmForm.ShowDialog() == DialogResult.OK)
						{
							cmd.CommandText = "SELECT id FROM Genres WHERE name = '" + FilmForm.genres.SelectedItem.ToString() + "'";
							DR = cmd.ExecuteReader();
							int id_genre;
							if (DR.HasRows)
							{
								DR.Read();
								id_genre = DR.GetInt32(0);
								DR.Close();
							}
							else
							{
								MessageBox.Show("Такого жанра не существует");
								DR.Close();
								return;
							}
							cmd.CommandText = String.Format("UPDATE Films SET name = '{0}', id_genre = {1}, duration = {2} WHERE id = {3}", FilmForm.name.Text, id_genre, FilmForm.duration.Text, LVI.Tag);
							cmd.ExecuteNonQuery();
						}
					}
					break;
				case "Жанры":
					{
						Genre GenreForm = new Genre(true);
						GenreForm.name.Text = LVI.Text;
						if (GenreForm.ShowDialog() == DialogResult.OK)
						{
							cmd.CommandText = String.Format("UPDATE Genres SET name = '{0}' WHERE id = {1}", GenreForm.name.Text, LVI.Tag);
							cmd.ExecuteNonQuery();
						}
					}
					break;
				case "Кинотеатры":
					{
						Cinema CinemaForm = new Cinema();
						CinemaForm.name.Text = LVI.Text;
						CinemaForm.rows.Text = LVI.SubItems[1].Text;
						CinemaForm.cols.Text = LVI.SubItems[2].Text;
						if (CinemaForm.ShowDialog() == DialogResult.OK)
						{
							cmd.CommandText = String.Format("UPDATE Cinemas SET name = '{0}', rows = {1}, columns = {2} WHERE id = {3}", CinemaForm.name.Text, CinemaForm.rows.Text, CinemaForm.cols.Text, LVI.Tag);
							cmd.ExecuteNonQuery();
						}
					}
					break;
				case "Сеансы":
					{
						Session SessionForm = new Session(true);
						cmd.CommandText = String.Format("SELECT name FROM Films");
						DbDataReader DR = cmd.ExecuteReader();
						for (int i = 0; DR.Read(); i++)
						{
							SessionForm.films.Items.Add(DR.GetString(0));
							if (LVI.Text == DR.GetString(0))
								SessionForm.films.SelectedIndex = i;
						}
						DR.Close();

						cmd.CommandText = String.Format("SELECT name FROM Cinemas");
						DR = cmd.ExecuteReader();
						for (int i = 0; DR.Read(); i++)
						{
							SessionForm.cinemas.Items.Add(DR.GetString(0));
							if (LVI.SubItems[3].Text == DR.GetString(0))
								SessionForm.cinemas.SelectedIndex = i;
						}
						DR.Close();

						DateTime DT = DateTime.Now;
						for (int i = 0; i < 30; i++)
						{
							SessionForm.dateFrom.Items.Add(DT.ToShortDateString());
							SessionForm.dateTo.Items.Add(DT.ToShortDateString());
							if (DT.Date == DateTime.Parse(LVI.SubItems[4].Text).Date)
							{
								SessionForm.dateFrom.SelectedIndex = i;
								SessionForm.dateTo.SelectedIndex = i;
							}
							DT = DT.AddDays(1);
						}

						SessionForm.time.Text = LVI.SubItems[5].Text;

						if (SessionForm.ShowDialog() == DialogResult.OK)
						{
							DateTime DateFrom = DateTime.Parse(SessionForm.dateFrom.Text);
							cmd.CommandText = String.Format("SELECT id FROM Films WHERE name = '{0}'", SessionForm.films.SelectedItem.ToString());
							int id_film = Int32.Parse(cmd.ExecuteScalar().ToString());
							cmd.CommandText = String.Format("SELECT id FROM Cinemas WHERE name = '{0}'", SessionForm.cinemas.SelectedItem.ToString());
							int id_cinema = Int32.Parse(cmd.ExecuteScalar().ToString());
							TimeSpan time = DateTime.Parse(SessionForm.time.Text).TimeOfDay;

							cmd.CommandText = String.Format("SELECT Films.name, Cinemas.name, Sessions.time, Films.duration FROM Sessions, Films, Cinemas WHERE Sessions.id != {2} AND Sessions.id_film = Films.id AND Sessions.is_cancelled = 0 AND Sessions.id_cinema = Cinemas.id AND Sessions.id_cinema = {0} AND Sessions.date = convert(datetime, '{1}', 104)", id_cinema, DateFrom.ToShortDateString(), LVI.Tag);
							DR = cmd.ExecuteReader();
							bool exists = false;
							if (DR.HasRows)
							{
								while (DR.Read())
								{
									object t = DR.GetValue(2);
									TimeSpan t2 = (TimeSpan)t;
									if ((t2 < time && t2.TotalMinutes + DR.GetInt32(3) > time.TotalMinutes)
										|| t2 > time && t2.TotalMinutes < time.TotalMinutes + DR.GetInt32(3))
									{
										DateTime tmp = DateTime.Parse("00:00").AddMinutes(DR.GetInt32(3));
										TimeSpan t3 = (t2 < time) ? t2.Add(tmp.TimeOfDay) : time.Add(tmp.TimeOfDay);
										String msg = (t2 < time)
											? String.Format("Вы не можете перенести сеанс на {3} {0}, т.к. в это время в кинотеатре {2} еще будет идти сеанс показа \"{1}\"", time.ToString(), DR.GetString(0), DR.GetString(1), DateFrom.ToShortDateString())
											: String.Format("Вы не можете перенести сеанс на {5} {0}, т.к. в {1} в кинотеатре {2} должен начатся следующий сеанс показа \"{3}\", а предлагаемый Вами сеанс закончится в {4}", time.ToString(), t2.ToString(), DR.GetString(1), DR.GetString(0), t3.ToString(), DateFrom.ToShortDateString());
										MessageBox.Show(msg, "Ошибка", MessageBoxButtons.OK);
										exists = true;
										break;
									}
									else if (t2 == time)
									{
										MessageBox.Show(String.Format("Вы не можете перенести сеанс на {3} {0}, т.к. в это же время в кинотеатре {1} начинается другой сеанс показа \"{2}\"", time.ToString(), DR.GetString(1), DR.GetString(0), DateFrom.ToShortDateString()), "Ошибка", MessageBoxButtons.OK);
										exists = true;
										break;
									}
								}
							}
							DR.Close();
							if (exists == false)
							{
								cmd.CommandText = String.Format("UPDATE Sessions SET is_cancelled = 0, id_film = {0}, id_cinema = {1}, date = convert(datetime, '{2}', 104), time = convert(datetime, '{3}', 104) WHERE id = {4}", id_film, id_cinema, DateFrom.ToShortDateString(), time.ToString(), LVI.Tag);
								cmd.ExecuteNonQuery();
							}
						}
					}
					break;
				case "Пользователи":
					{
						UserForm userForm = new UserForm(true);
						userForm.login.Text = this.user.Login;
						userForm.comboBox1.SelectedIndex = (this.user.IsAdmin) ? 0 : 1;
						if (userForm.ShowDialog() == DialogResult.OK)
						{
							cmd.CommandText = String.Format("UPDATE users SET password = {1}, is_admin = {2}, email = '{3}', phone = '{4}' WHERE id = {5}", Main.Md5Hash(userForm.password.Text), (userForm.comboBox1.SelectedItem.ToString() == "Да") ? 1 : 0);
							cmd.ExecuteNonQuery();
						}
					}
					break;
			}
			this.TabControl2_SelectedIndexChanged(null, null);
		}

		private void Delete(object sender, EventArgs e)
		{
			if (this.listView1.SelectedItems.Count == 0)
			{
				MessageBox.Show("Выберите элемент, который хотите удалить", "Ошибка", MessageBoxButtons.OK);
				return;
			}
			foreach (ListViewItem LVI in this.listView1.SelectedItems)
			{
				switch (this.tabControl2.SelectedTab.Text)
				{
					case "Фильмы":
						{
							cmd.CommandText = "DELETE FROM Films WHERE id = " + LVI.Tag;
							try
							{
								cmd.ExecuteNonQuery();
								this.listView1.Items.Remove(LVI);
							}
							catch (Exception)
							{
								MessageBox.Show("Вы не можете удалить данный фильм, т.к. будет проводится его показ. Чтобы удалить данный фильм, удалите сначала сеанс, связанный с этим фильмом", "Ошибка", MessageBoxButtons.OK);
								return;
							}
						}
						break;
					case "Жанры":
						{
							cmd.CommandText = "DELETE FROM Genres WHERE id = " + LVI.Tag;
							try
							{
								cmd.ExecuteNonQuery();
								this.listView1.Items.Remove(LVI);
							}
							catch (Exception)
							{
								MessageBox.Show("Вы не можете удалить данный жанр, т.к. существуют фильмы, связанные с этим жанром. Чтобы удалить данный жанр, удалите сначала фильмы из этого жанра", "Ошибка", MessageBoxButtons.OK);
								return;
							}
						}
						break;
					case "Кинотеатры":
						{
							cmd.CommandText = "DELETE FROM Cinemas WHERE id = " + LVI.Tag;
							try
							{
								cmd.ExecuteNonQuery();
								this.listView1.Items.Remove(LVI);
							}
							catch (Exception)
							{
								MessageBox.Show("Вы не можете удалить данный кинотеатр, т.к. в нем будет проводится сеанс. Чтобы удалить данный кинотеатр, удалите сначала сеанс, связанный с этим кинотеатром", "Ошибка", MessageBoxButtons.OK);
								return;
							}
						}
						break;
					case "Сеансы":
						{
							//cmd.CommandText = "DELETE FROM Sessions WHERE is_cancelled = 0 AND id = " + LVI.Tag;
							cmd.CommandText = "DELETE FROM Sessions WHERE id = " + LVI.Tag;
							cmd.ExecuteNonQuery();
							this.listView1.Items.Remove(LVI);
						}
						break;
					case "Пользователи":
						{
							if (this.user.Id == Int32.Parse(LVI.Tag.ToString()))
								MessageBox.Show("Вы не можете удалить свой аккаунт", "Ошибка", MessageBoxButtons.OK);
							else
							{
								cmd.CommandText = "DELETE FROM users WHERE id = " + LVI.Tag;
								cmd.ExecuteNonQuery();
								this.listView1.Items.Remove(LVI);
							}
						}
						break;
				}
			}
		}
		private void Add(object sender, EventArgs e)
		{
			switch (this.tabControl2.SelectedTab.Text)
			{
				case "Фильмы":
					{
						Film FilmForm = new Film();
						cmd.CommandText = "SELECT name FROM Genres";
						DbDataReader DR = cmd.ExecuteReader();
						while (DR.Read())
						{
							FilmForm.genres.Items.Add(DR.GetString(0));
						}
						DR.Close();
						if (FilmForm.ShowDialog() == DialogResult.OK)
						{
							cmd.CommandText = "SELECT id FROM Genres WHERE name = '" + FilmForm.genres.SelectedItem.ToString() + "'";
							DR = cmd.ExecuteReader();
							int id_genre;
							if (DR.HasRows)
							{
								DR.Read();
								id_genre = DR.GetInt32(0);
								DR.Close();
							}
							else
							{
								MessageBox.Show("Такого жанра не существует");
								DR.Close();
								return;
							}
							cmd.CommandText = String.Format("INSERT INTO Films (name, id_genre, duration) VALUES ('{0}', {1}, {2})", FilmForm.name.Text, id_genre, FilmForm.duration.Text);
							cmd.ExecuteNonQuery();
						}
					}
					break;
				case "Жанры":
					{
						Genre GenreForm = new Genre();
						if (GenreForm.ShowDialog() == DialogResult.OK)
						{
							cmd.CommandText = String.Format("INSERT INTO Genres (name) VALUES ('{0}')", GenreForm.name.Text);
							cmd.ExecuteNonQuery();
						}
					}
					break;
				case "Кинотеатры":
					{
						Cinema CinemaForm = new Cinema();
						if (CinemaForm.ShowDialog() == DialogResult.OK)
						{
							cmd.CommandText = String.Format("INSERT INTO Cinemas (name, rows, columns) VALUES ('{0}', {1}, {2})", CinemaForm.name.Text, CinemaForm.rows.Text, CinemaForm.cols.Text);
							cmd.ExecuteNonQuery();
						}
					}
					break;
				case "Сеансы":
					{
						DbDataReader DR;
						if (tabControl3.SelectedIndex == 0)
						{
							Session SessionForm = new Session();
							cmd.CommandText = String.Format("SELECT name FROM Films");
							DR = cmd.ExecuteReader();
							while (DR.Read())
								SessionForm.films.Items.Add(DR.GetString(0));
							DR.Close();
							SessionForm.films.SelectedIndex = 0;

							cmd.CommandText = String.Format("SELECT name FROM Cinemas");
							DR = cmd.ExecuteReader();
							while (DR.Read())
								SessionForm.cinemas.Items.Add(DR.GetString(0));
							DR.Close();
							SessionForm.cinemas.SelectedIndex = 0;

							DateTime DT = DateTime.Now;
							for (int i = 0; i < 30; i++)
							{
								SessionForm.dateFrom.Items.Add(DT.ToShortDateString());
								SessionForm.dateTo.Items.Add(DT.ToShortDateString());
								DT = DT.AddDays(1);
							}
							SessionForm.dateFrom.SelectedIndex = 0;
							SessionForm.dateTo.SelectedIndex = 0;

							SessionForm.time.Text = DT.ToShortTimeString();

							if (SessionForm.ShowDialog() == DialogResult.OK)
							{
								DateTime DateFrom = DateTime.Parse(SessionForm.dateFrom.Text);
								DateTime DateTo = DateTime.Parse(SessionForm.dateTo.Text);
								cmd.CommandText = String.Format("SELECT id FROM Films WHERE name = '{0}'", SessionForm.films.SelectedItem.ToString());
								DR = cmd.ExecuteReader();
								int id_film;
								if (DR.HasRows)
								{
									DR.Read();
									id_film = DR.GetInt32(0);
									DR.Close();
								}
								else
								{
									MessageBox.Show("Данного фильма не существует или он был удален");
									DR.Close();
									return;
								}
								cmd.CommandText = String.Format("SELECT id FROM Cinemas WHERE name = '{0}'", SessionForm.cinemas.SelectedItem.ToString());
								DR = cmd.ExecuteReader();
								int id_cinema;
								if (DR.HasRows)
								{
									DR.Read();
									id_cinema = DR.GetInt32(0);
									DR.Close();
								}
								else
								{
									MessageBox.Show("Данного кинотеатра не существует или он был удален");
									DR.Close();
									return;
								}
								TimeSpan time = DateTime.Parse(SessionForm.time.Text).TimeOfDay;
								while (DateFrom <= DateTo)
								{
									cmd.CommandText = String.Format("SELECT Films.name, Cinemas.name, Sessions.time, Films.duration FROM Sessions, Films, Cinemas WHERE Sessions.id_film = Films.id AND Sessions.is_cancelled = 0 AND Sessions.id_cinema = Cinemas.id AND Sessions.id_cinema = {0} AND Sessions.date = convert(datetime, '{1}', 104)", id_cinema, DateFrom.ToShortDateString());
									DR = cmd.ExecuteReader();
									bool exists = false;
									if (DR.HasRows)
									{
										while (DR.Read())
										{
											object t = DR.GetValue(2);
											TimeSpan t2 = (TimeSpan)t;
											if ((t2 < time && t2.TotalMinutes + DR.GetInt32(3) > time.TotalMinutes)
												|| t2 > time && t2.TotalMinutes < time.TotalMinutes + DR.GetInt32(3))
											{
												DateTime tmp = DateTime.Parse("00:00").AddMinutes(DR.GetInt32(3));
												TimeSpan t3 = (t2 < time) ? t2.Add(tmp.TimeOfDay) : time.Add(tmp.TimeOfDay);
												String msg = (t2 < time)
													? String.Format("Вы не можете добавить новый сеанс на {4} {0}, т.к. в это время в кинотеатре {1} еще будет идти сеанс показа \"{2}\", который закончится в {3}", time.ToString(), DR.GetString(1), DR.GetString(0), t3.ToString(), DateFrom.ToShortDateString())
													: String.Format("Вы не можете добавить новый сеанс на {5} {0}, т.к. в {1} в кинотеатре {2} должен начатся следующий сеанс показа \"{3}\", а предлагаемый Вами сеанс закончится в {4}", time.ToString(), t2.ToString(), DR.GetString(1), DR.GetString(0), t3.ToString(), DateFrom.ToShortDateString());
												MessageBox.Show(msg, "Ошибка", MessageBoxButtons.OK);
												exists = true;
												break;
											}
											else if (t2 == time)
											{
												MessageBox.Show(String.Format("Вы не можете добавить новый сеанс на {3} {0}, т.к. в это же время в кинотеатре {1} начинается другой сеанс показа \"{2}\"", time.ToString(), DR.GetString(1), DR.GetString(0), DateFrom.ToShortDateString()), "Ошибка", MessageBoxButtons.OK);
												exists = true;
												break;
											}
										}
									}
									DR.Close();
									cmd.CommandText = String.Format("INSERT INTO Sessions (id_film, id_cinema, date, time) VALUES ({0}, {1}, convert(datetime, '{2}', 104), convert(datetime, '{3}', 104))", id_film, id_cinema, DateFrom.ToShortDateString(), time.ToString());
									DateFrom = DateFrom.AddDays(1);
									if (exists == true)
										continue;
									cmd.ExecuteNonQuery();
								}
							}
						}
						else
						{
							if (this.listView1.SelectedItems.Count == 0)
							{
								MessageBox.Show("Выберите сеанс, который хотите возобновить", "ошибка", MessageBoxButtons.OK);
								return;
							}
							foreach (ListViewItem LVI in this.listView1.SelectedItems)
							{
								cmd.CommandText = String.Format("SELECT id FROM Cinemas WHERE name = '{0}'", LVI.SubItems[3].Text);
								DR = cmd.ExecuteReader();
								int id_cinema;
								if (DR.HasRows)
								{
									DR.Read();
									id_cinema = DR.GetInt32(0);
									DR.Close();
								}
								else
								{
									MessageBox.Show("Данного кинотеатра не существует или он был удален");
									DR.Close();
									return;
								}
								TimeSpan time = TimeSpan.Parse(LVI.SubItems[5].Text);
								DateTime date = DateTime.Parse(LVI.SubItems[4].Text);
								cmd.CommandText = String.Format("SELECT Films.name, Cinemas.name, Sessions.time, Films.duration FROM Sessions, Films, Cinemas WHERE Sessions.id_film = Films.id AND Sessions.is_cancelled = 0 AND Sessions.id_cinema = Cinemas.id AND Sessions.id_cinema = {0} AND Sessions.date = convert(datetime, '{1}', 104)", id_cinema, date.ToShortDateString());
								DR = cmd.ExecuteReader();
								bool exists = false;
								if (DR.HasRows)
								{
									while (DR.Read())
									{
										object t = DR.GetValue(2);
										TimeSpan t2 = (TimeSpan)t;
										if ((t2 < time && t2.TotalMinutes + DR.GetInt32(3) > time.TotalMinutes)
											|| t2 > time && t2.TotalMinutes < time.TotalMinutes + DR.GetInt32(3))
										{
											DateTime tmp = DateTime.Parse("00:00").AddMinutes(DR.GetInt32(3));
											TimeSpan t3 = (t2 < time) ? t2.Add(tmp.TimeOfDay) : time.Add(tmp.TimeOfDay);
											String msg = (t2 < time)
												? String.Format("Вы не можете заново добавить сеанс на {4} {0}, т.к. в это время в кинотеатре {1} еще будет идти сеанс показа \"{2}\", который закончится в {3}", time.ToString(), DR.GetString(1), DR.GetString(0), t3.ToString(), date.ToShortDateString())
												: String.Format("Вы не можете заново добавить новый сеанс на {5} {0}, т.к. в {1} в кинотеатре {2} должен начатся следующий сеанс показа \"{3}\", а предлагаемый Вами сеанс закончится в {4}", time.ToString(), t2.ToString(), DR.GetString(1), DR.GetString(0), t3.ToString(), date.ToShortDateString());
											MessageBox.Show(msg, "Ошибка", MessageBoxButtons.OK);
											exists = true;
											break;
										}
										else if (t2 == time)
										{
											MessageBox.Show(String.Format("Вы не можете заново добавить новый сеанс на {3} {0}, т.к. в это же время в кинотеатре {1} начинается другой сеанс показа \"{2}\"", time.ToString(), DR.GetString(1), DR.GetString(0), date.ToShortDateString()), "Ошибка", MessageBoxButtons.OK);
											exists = true;
											break;
										}
									}
								}
								DR.Close();
								cmd.CommandText = String.Format("UPDATE Sessions SET is_cancelled = 0 WHERE id = {0}", LVI.Tag);
								if (exists == false)
									cmd.ExecuteNonQuery();
							}
						}
						this.tabControl3.SelectedIndex = 0;
					}
					break;
				case "Пользователи":
					{
						UserForm userForm = new UserForm();
						if (userForm.ShowDialog() == DialogResult.OK)
						{
							cmd.CommandText = String.Format("INSERT INTO users (login, password, is_admin) VALUES ('{0}', '{1}', '{2}')", userForm.login.Text, Main.Md5Hash(userForm.password.Text), (userForm.comboBox1.SelectedItem.ToString() == "Да") ? 1 : 0);
							try
							{
								cmd.ExecuteNonQuery();
							}
							catch (Exception)
							{
								MessageBox.Show("Такой пользователь уже существует", "Ошибка", MessageBoxButtons.OK);
							}
						}
					}
					break;
			}
			this.TabControl2_SelectedIndexChanged(null, null);
		}

		private void TabControl2_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.tableLayoutPanel6.Parent = this.tabControl2.SelectedTab;
			this.listView1.Items.Clear();
			this.listView1.Columns.Clear();
			switch (this.tabControl2.SelectedTab.Text)
			{
				case "Фильмы":
					{
						cmd.CommandText = "SELECT Films.id, Films.name, Genres.name, Films.duration FROM Films, Genres WHERE Genres.id = Films.id_genre ORDER BY Films.name ASC";
						DbDataReader DR = cmd.ExecuteReader();
						this.listView1.Columns.Add("Название фильма", 300);
						this.listView1.Columns.Add("Название жанра", 120);
						this.listView1.Columns.Add("Длительность, мин", 120);
						while (DR.Read())
						{
							ListViewItem LVI = new ListViewItem(DR.GetString(1));
							LVI.SubItems.Add(DR.GetString(2));
							LVI.SubItems.Add(DR.GetInt32(3).ToString());
							LVI.Tag = DR.GetInt32(0);
							this.listView1.Items.Add(LVI);
						}
						DR.Close();
					}
					break;
				case "Жанры":
					{
						cmd.CommandText = "SELECT * FROM Genres ORDER BY name ASC";
						DbDataReader DR = cmd.ExecuteReader();
						this.listView1.Columns.Add("Название жанра", 300);
						while (DR.Read())
						{
							ListViewItem LVI = new ListViewItem(DR.GetString(1));
							LVI.Tag = DR.GetInt32(0);
							this.listView1.Items.Add(LVI);
						}
						DR.Close();
					}
					break;
				case "Кинотеатры":
					{
						cmd.CommandText = "SELECT * FROM Cinemas ORDER BY name ASC";
						DbDataReader DR = cmd.ExecuteReader();
						this.listView1.Columns.Add("Название кинотеатра", 300);
						this.listView1.Columns.Add("Кол-во рядов", 120);
						this.listView1.Columns.Add("Кол-во столбцов", 120);
						while (DR.Read())
						{
							ListViewItem LVI = new ListViewItem(DR.GetString(1));
							LVI.SubItems.Add(DR.GetInt32(2).ToString());
							LVI.SubItems.Add(DR.GetInt32(3).ToString());
							LVI.Tag = DR.GetInt32(0);
							this.listView1.Items.Add(LVI);
						}
						DR.Close();
					}
					break;
				case "Сеансы":
					{
						int is_cancelled;
						if (this.tabControl3.SelectedIndex == 0)
						{
							is_cancelled = 0;
							this.button8.Enabled = true;
						}
						else
						{
							is_cancelled = 1;
							//this.button8.Enabled = false;
						}
						cmd.CommandText = "SELECT Sessions.id, Films.name, Genres.name, Films.duration, Cinemas.name, Sessions.date, Sessions.time FROM Sessions, Films, Genres, Cinemas WHERE Sessions.id_film = Films.id AND Films.id_genre = Genres.id AND Sessions.id_cinema = Cinemas.id AND Sessions.is_cancelled = " + is_cancelled + " ORDER BY Sessions.date, Sessions.time ASC";
						DbDataReader DR = cmd.ExecuteReader();
						this.listView1.Columns.Add("Название фильма", 120);
						this.listView1.Columns.Add("Жанр", 120);
						this.listView1.Columns.Add("Длительность, мин", 120);
						this.listView1.Columns.Add("Название кинотеатра", 130);
						this.listView1.Columns.Add("Дата сеанса", 100);
						this.listView1.Columns.Add("Время начала сеанса", 130);
						while (DR.Read())
						{
							ListViewItem LVI = new ListViewItem(DR.GetString(1));
							LVI.SubItems.Add(DR.GetString(2));
							LVI.SubItems.Add(DR.GetInt32(3).ToString());
							LVI.SubItems.Add(DR.GetString(4));
							LVI.SubItems.Add(DR.GetDateTime(5).ToShortDateString());
							object t = DR.GetValue(6);
							TimeSpan TS = (TimeSpan)t;
							LVI.SubItems.Add(TS.ToString());
							LVI.Tag = DR.GetInt32(0);
							this.listView1.Items.Add(LVI);
						}
						DR.Close();
					}
					break;
				case "Пользователи":
					{
						cmd.CommandText = "SELECT id, login, is_admin FROM users";
						DbDataReader DR = cmd.ExecuteReader();
						this.listView1.Columns.Add("Логин", 200);
						this.listView1.Columns.Add("Администратор", 100);
						while (DR.Read())
						{
							ListViewItem LVI = new ListViewItem(DR.GetString(1));
							LVI.SubItems.Add((DR.GetBoolean(2) == true) ? "Да" : "Нет");
							LVI.Tag = DR.GetInt32(0);
							this.listView1.Items.Add(LVI);
						}
						DR.Close();
					}
					break;
			}
			if (this.tabControl2.SelectedTab.Text == "Сеансы")
			{
				this.tabControl3.Visible = true;
				this.tabControl3.SelectedTab.Controls.Add(this.listView1);
				this.listView1.Location = new Point(0, 0);
				this.listView1.Size = this.tabControl3.TabPages[0].ClientSize;
			}
			else
			{
				this.tabControl3.Visible = false;
				this.listView1.Parent = this.tableLayoutPanel6;
				this.button8.Enabled = true;
				this.button7.Text = "Добавление";
			}
		}

		private User Login(String[] data)
		{
			User user = null;
			this.cmd.CommandText = "SELECT * FROM users WHERE login = '" + data[0] + "'";
			DbDataReader DR = cmd.ExecuteReader();
			if (DR.HasRows)
			{
				DR.Read();
				if (DR.GetString(2) == data[1])
				{
					user = new User(DR.GetInt32(0), DR.GetString(1), DR.GetBoolean(5), (DR.IsDBNull(3)) ? "" : DR.GetString(3), (DR.IsDBNull(4)) ? "" : DR.GetString(4));
				}
			}
			DR.Close();
			if (user != null)
			{
				this.cmd.CommandText = String.Format("UPDATE Tickets SET id_user = {0} WHERE (email = '{1}' OR phone = '{2}') AND id_user IS NULL", user.Id, user.Email, user.Phone);
				this.cmd.ExecuteNonQuery();
				this.tableLayoutPanel5.Controls.Add(this.button6);
				this.loginButton.Visible = false;
				this.registerButton.Visible = false;
				if (user.IsAdmin == true)
					this.tableLayoutPanel5.Controls.Add(this.button4);
				this.tableLayoutPanel7.Controls.Add(this.linkLabel1, 0, 0);
			}
			return user;
		}

		private String EncryptString(String str)
		{
			String Encrypted;
			using (Aes aesAlg = Aes.Create())
			{
				aesAlg.Key = Main.Salt2;
				aesAlg.IV = this.AesIV;
				ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
				using (MemoryStream MS = new MemoryStream())
				{
					using (CryptoStream CS = new CryptoStream(MS, encryptor, CryptoStreamMode.Write))
					{
						using (StreamWriter SW = new StreamWriter(CS))
						{
							SW.Write(str);
						}
						Encrypted = Encoding.UTF8.GetString(MS.ToArray());
					}
				}
			}
			return Encrypted;
		}

		private String EncryptAesToken(FileStream FS, String token)
		{
			String EncryptedUserToken;
			using (Aes aesAlg = Aes.Create())
			{
				aesAlg.Key = this.AesKey;
				aesAlg.IV = this.AesIV;
				ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
				using (CryptoStream CS = new CryptoStream(FS, encryptor, CryptoStreamMode.Write))
				{
					using (StreamWriter SW = new StreamWriter(CS))
					{
						SW.Write(token);
					}
					EncryptedUserToken = FS.ToString();
				}
			}
			return EncryptedUserToken;
		}

		private String DecryptAesToken(FileStream FS)
		{
			String DecryptedUserToken;
			using (Aes aesAlg = Aes.Create())
			{
				aesAlg.Key = this.AesKey;
				aesAlg.IV = this.AesIV;
				ICryptoTransform Decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
				using (CryptoStream CS = new CryptoStream(FS, Decryptor, CryptoStreamMode.Read))
				{
					using (StreamReader SR = new StreamReader(CS))
					{
						DecryptedUserToken = SR.ReadToEnd();
					}
				}
			}
			return DecryptedUserToken;
		}

		private void LoadFilms(ListView LV)
		{
			cmd.CommandText = "SELECT Films.name, Genres.name, Films.duration, Sessions.time, Sessions.id, Cinemas.name, Sessions.date " +
				"FROM Films, Cinemas, Genres, Sessions WHERE Films.id = Sessions.id_film AND Cinemas.id = Sessions.id_cinema ";
			if (this.CinemaIdFilter != null)
			{
				cmd.CommandText += "AND Cinemas.id = " + this.CinemaIdFilter + " ";
				this.CinemaIdFilter = null;
			}
			cmd.CommandText += "AND Sessions.date >= convert(datetime, '" + this.SelectedDateFrom + "', 104) " +
				"AND Sessions.date <= convert(datetime, '" + this.SelectedDateTo + "', 104) AND Genres.id = Films.id_genre ";
			if (this.GenreIdFilter != null)
			{
				cmd.CommandText += "AND Genres.id = " + this.GenreIdFilter + " ";
				this.GenreIdFilter = null;
			}
			cmd.CommandText += "AND Films.name LIKE '%" + this.SearchInput + "%' AND Genres.id = Films.id_genre " +
				"AND Sessions.is_cancelled = 0 ORDER BY Sessions.time ASC";
			DbDataReader DR = cmd.ExecuteReader();
			LV.Items.Clear();
			if (DR.HasRows)
			{
				LV.Columns.Clear();
				LV.Columns.Add("Название фильма", 300);
				LV.Columns.Add("Жанр", 110);
				LV.Columns.Add("Кинотеатр", 110);
				LV.Columns.Add("Длительность, мин", 120);
				LV.Columns.Add("Начало сеанса", 100);
				while (DR.Read())
				{
					ListViewItem LVI = new ListViewItem();
					LVI.Text = DR.GetString(0);
					LVI.SubItems.Add(DR.GetString(1));
					LVI.SubItems.Add(DR.GetString(5));
					LVI.SubItems.Add(DR.GetInt32(2).ToString());
					object t = DR.GetValue(3);
					TimeSpan TS = (TimeSpan)t;
					LVI.SubItems.Add(TS.ToString());
					LVI.Tag = DR.GetInt32(4);
					if (DR.GetDateTime(6) == DateTime.Now.Date && TS < DateTime.Now.TimeOfDay)
						continue;
					LV.Items.Add(LVI);
				}
			}
			DR.Close();
		}

		private void LoadGenres(ListView LV)
		{
			cmd.CommandText = "SELECT Genres.id, Genres.name, COUNT(*), Sessions.date, Sessions.time FROM Films, Genres, Sessions WHERE Films.id = Sessions.id_film AND Sessions.date >= convert(datetime, '" + this.SelectedDateFrom + "', 104) AND Sessions.date <= convert(datetime, '" + this.SelectedDateTo + "', 104) AND Genres.name LIKE '%" + this.SearchInput + "%' AND Genres.id = Films.id_genre AND Sessions.is_cancelled = 0 GROUP BY Genres.name, Genres.id, Films.name, Sessions.date, Sessions.time ORDER BY Genres.name ASC";
			DbDataReader DR = cmd.ExecuteReader();
			LV.Items.Clear();
			if (DR.HasRows)
			{
				LV.Columns.Clear();
				LV.Columns.Add("Название жанра", 300);
				LV.Columns.Add("Кол-во сеансов", 200);
				if (DateTime.Parse(this.SelectedDateFrom) < DateTime.Parse(this.SelectedDateTo))
					LV.Columns.Add("Дата", 120);
				while (DR.Read())
				{
					ListViewItem LVI = new ListViewItem();
					LVI.Text = DR.GetString(1);
					LVI.SubItems.Add(DR.GetInt32(2).ToString());
					if (DateTime.Parse(this.SelectedDateFrom) < DateTime.Parse(this.SelectedDateTo))
						LVI.SubItems.Add(DR.GetDateTime(3).ToShortDateString());
					LVI.Tag = DR.GetInt32(0);
					TimeSpan TS = (TimeSpan)DR.GetValue(4);
					if (DR.GetDateTime(3) == DateTime.Now.Date && TS < DateTime.Now.TimeOfDay)
						continue;
					LV.Items.Add(LVI);
				}
			}
			DR.Close();
		}

		private void LoadCinemas(ListView LV)
		{
			cmd.CommandText = "SELECT Cinemas.id, Cinemas.name, COUNT(*), Sessions.date, Sessions.time FROM Cinemas, Films, Genres, Sessions WHERe Films.id = Sessions.id_film AND Sessions.date >= convert(datetime, '" + this.SelectedDateFrom + "', 104) AND Sessions.date <= convert(datetime, '" + this.SelectedDateTo + "', 104) AND Genres.id = Films.id_genre AND Cinemas.name LIKE '%" + this.SearchInput + "%' AND Sessions.is_cancelled = 0 AND Sessions.id_cinema = Cinemas.id GROUP BY Cinemas.id, Cinemas.name, Sessions.date, Sessions.time ORDER BY Cinemas.name ASC";
			DbDataReader DR = cmd.ExecuteReader();
			LV.Items.Clear();
			if (DR.HasRows)
			{
				LV.Columns.Clear();
				LV.Columns.Add("Название кинотеатра", 300);
				LV.Columns.Add("Кол-во сеансов", 160);
				if (DateTime.Parse(this.SelectedDateFrom) < DateTime.Parse(this.SelectedDateTo))
					LV.Columns.Add("Дата", 120);
				while (DR.Read())
				{
					ListViewItem LVI = new ListViewItem();
					LVI.Text = DR.GetString(1);
					LVI.SubItems.Add(DR.GetInt32(2).ToString());
					LVI.Tag = DR.GetInt32(0);
					TimeSpan TS = (TimeSpan)DR.GetValue(4);
					if (DateTime.Parse(this.SelectedDateFrom) < DateTime.Parse(this.SelectedDateTo))
						LVI.SubItems.Add(DR.GetDateTime(3).ToShortDateString());
					if (DR.GetDateTime(3) == DateTime.Now.Date && TS < DateTime.Now.TimeOfDay)
						continue;
					LV.Items.Add(LVI);
				}
			}
			DR.Close();
		}

		private void LoadTickets(ListView LV)
		{
			cmd.CommandText = String.Format("SELECT Tickets.id, Films.name, Genres.name, Cinemas.name, Sessions.time, Tickets.row, Tickets.col, Tickets.email, Tickets.phone FROM Tickets, Films, Genres, Sessions, Cinemas WHERE (Tickets.id_user = {0} OR ((Tickets.email = '{2}' OR Tickets.phone = '{3}') AND Tickets.id_user IS NULL)) AND Sessions.date = convert(datetime, '{1}', 104) AND Tickets.id_session = Sessions.id AND Sessions.id_film = Films.id AND Films.id_genre = Genres.id AND Sessions.id_cinema = Cinemas.id ORDER BY Sessions.date, Sessions.time", this.user.Id, this.SelectedDateFrom, this.user.Email, this.user.Phone);
			DbDataReader DR = cmd.ExecuteReader();
			LV.Items.Clear();
			String cmds = "";
			if (DR.HasRows)
			{
				LV.Columns.Clear();
				LV.Columns.Add("Фильм", 120);
				LV.Columns.Add("Жанр", 120);
				LV.Columns.Add("Кинотеатр", 120);
				LV.Columns.Add("Начало сеанса", 120);
				LV.Columns.Add("Ряд", 50);
				LV.Columns.Add("Место", 50);
				while (DR.Read())
				{
					ListViewItem LVI = new ListViewItem();
					LVI.Text = DR.GetString(1);
					LVI.SubItems.Add(DR.GetString(2));
					LVI.SubItems.Add(DR.GetString(3));
					object t = DR.GetValue(4);
					TimeSpan TS = (TimeSpan)t;
					LVI.SubItems.Add(TS.ToString());
					LVI.SubItems.Add((DR.GetInt32(5) + 1).ToString());
					LVI.SubItems.Add((DR.GetInt32(6) + 1).ToString());
					LVI.Tag = DR.GetInt32(0);
					LV.Items.Add(LVI);
				}
			}
			DR.Close();
			if (cmds != "")
			{
				cmd.CommandText = cmds;
				cmd.ExecuteNonQuery();
			}
		}

		private void LoadResults(object sender)
		{
			if (sender is TextBox)
				this.CurrentPage = this.SearchFilter;
			if (this.SelectedMenuItem != null)
				this.SelectedMenuItem.BackColor = Color.White;
			this.SelectedMenuItem = this.PageToMenuButton[this.CurrentPage];
			this.SelectedMenuItem.BackColor = Color.YellowGreen;
			String Table = this.FilterToTableName[this.CurrentPage];
			String date;
			if (this.SelectedDateFrom == this.SelectedDateTo)
			{
				date = this.SelectedDateFrom;
			}
			else
			{
				date = this.SelectedDateFrom + " - " + this.SelectedDateTo;
				this.tabControl1.SelectedTab.Text = date;
			}
			switch (Table)
			{
				case "Films":
					{
						this.LoadFilms(this.result_table);
						this.result_info_label.Text = "Фильмы на " + date;
						if (this.SearchInput.Trim() != "")
							this.result_info_label.Text += " по запросу \"" + this.SearchInput + "\"";
						if (this.GenreNameFilter != null)
						{
							this.result_info_label.Text += " по жанру " + this.GenreNameFilter;
							this.GenreNameFilter = null;
						}
						if (this.CinemaNameFilter != null)
						{
							this.result_info_label.Text += " в кинотеатре " + this.CinemaNameFilter;
							this.CinemaNameFilter = null;
						}
					}
					break;
				case "Genres":
					{
						this.LoadGenres(this.result_table);
						this.result_info_label.Text = "Фильмы по жанрам на " + date;
						if (this.SearchInput.Trim() != "")
							this.result_info_label.Text += " по запросу \"" + this.SearchInput + "\"";
					}
					break;
				case "Cinemas":
					{
						this.LoadCinemas(this.result_table);
						this.result_info_label.Text = "Афиша в кинотеатрах на " + date;
						if (this.SearchInput.Trim() != "")
							this.result_info_label.Text += " по запросу \"" + this.SearchInput + "\"";
					}
					break;
				case "Films;Genres;Cinemas":
					{
						/* Загружаем результаты по фильмам */
						this.LoadFilms(this.films_result_table);
						this.film_results_info.Text = "Фильмы на " + date;
						if (this.SearchInput.Trim() != "")
							this.film_results_info.Text += " по запросу \"" + this.SearchInput + "\"";
						/* Загружаем результаты фильмов по жанрам */
						this.LoadGenres(this.genres_result_table);
						this.genre_results_info.Text = "Фильмы по жанрам на " + date;
						if (this.SearchInput.Trim() != "")
							this.genre_results_info.Text += " по запросу \"" + this.SearchInput + "\"";
						/* Загружаем афиши в кинотеатрах */
						this.LoadCinemas(this.cinemas_result_table);
						this.cinema_result_info.Text = "Афиша в кинотеатрах на " + date;
						if (this.SearchInput.Trim() != "")
							this.cinema_result_info.Text += " по запросу \"" + this.SearchInput + "\"";
					}
					break;
				case "Tickets":
					{
						this.LoadTickets(this.result_table);
						this.result_info_label.Text = String.Format("Мои билеты на {0}\r\n(нажмите ПКМ по билету, который хотите отменить)", this.SelectedDateFrom);
					}
					break;
			}
			if (Table == "Films;Genres;Cinemas")
			{
				/* Скрываем таблицу с конкретными результатами (чтобы ее размер изменился, в случае ресайза окна)
				 * и показываем панель с общими результатами 
				 */
				this.tableLayoutPanel8.Visible = false;
				this.panel1.Visible = true;
				/* Показываем результаты по каждой таблице (Фильмы, Жанры, Кинотеатры)
				 * Если в какой-либо из табилц нет результатов, скрываем ее
				 * Если нет ни единого результата, будут скрыты все таблицы и показана соответствующая надпись */

				if (this.films_result_table.Items.Count != 0)
				{
					this.films_result_table.Visible = true;
					this.film_results_info.Location = new Point(3, 12);
					this.films_result_table.Location = new Point(3, this.film_results_info.Bounds.Bottom + 19);
					this.films_result_table.Height = 28 + this.films_result_table.Items[0].Bounds.Height * (this.films_result_table.Items.Count + 1);
					this.genre_results_info.Location = new Point(3, this.films_result_table.Bounds.Bottom + 10);
				}
				else
				{
					this.films_result_table.Visible = false;
					this.film_results_info.Location = new Point(3, -28);
					this.genre_results_info.Location = new Point(3, this.film_results_info.Bounds.Bottom + 17);
				}

				this.genres_result_table.Location = new Point(3, this.genre_results_info.Bounds.Bottom + 17);

				if (this.genres_result_table.Items.Count != 0)
				{
					this.genres_result_table.Visible = true;
					this.genre_results_info.Visible = true;
					this.genres_result_table.Height = 28 + this.genres_result_table.Items[0].Bounds.Height * (this.genres_result_table.Items.Count + 1);
					this.cinema_result_info.Location = new Point(3, this.genres_result_table.Bounds.Bottom + 17);
				}
				else
				{
					this.genres_result_table.Visible = false;
					this.genre_results_info.Visible = false;
					this.cinema_result_info.Location = new Point(3, ((this.films_result_table.Items.Count == 0) ? this.film_results_info.Bounds.Bottom : this.films_result_table.Bounds.Bottom) + 10);
				}

				this.cinemas_result_table.Location = new Point(3, this.cinema_result_info.Bounds.Bottom + 17);

				if (this.cinemas_result_table.Items.Count != 0)
				{
					this.cinema_result_info.Visible = true;
					this.cinemas_result_table.Visible = true;
					this.cinemas_result_table.Height = 28 + this.cinemas_result_table.Items[0].Bounds.Height * (this.genres_result_table.Items.Count + 1);
				}
				else
				{
					this.cinema_result_info.Visible = false;
					this.cinemas_result_table.Visible = false;
				}

				if (this.films_result_table.Items.Count == 0 &&
					this.genres_result_table.Items.Count == 0 &&
					this.cinemas_result_table.Items.Count == 0)
					this.NoAllResults.Visible = true;
				else
					this.NoAllResults.Visible = false;
			}
			else
			{
				/* Скрываем панель с общими результатами (чтобы ее размер изменился, в случае ресайза окна)
				 * и показываем таблицу с конкретными результатами
				 */
				this.panel1.Visible = false;
				this.tableLayoutPanel8.Visible = true;
				/* Если в результирующей таблице содержится хотя бы одна строка, показываем ее
				 * иначе показываем надпись "Результатов по данному запросу не найдено"
				 */
				if (this.result_table.Items.Count != 0)
				{
					this.NoResults.Parent = null;
					this.result_table.Parent = this.tableLayoutPanel8;
				}
				else
				{
					this.result_table.Parent = null;
					this.NoResults.Parent = this.tableLayoutPanel8;
				}
			}
			if (Table == "Tickets")
			{
				this.result_table.MultiSelect = true;
			}
			else
			{
				this.result_table.MultiSelect = false;
			}
		}

		private void search_input_Enter(object sender, EventArgs e)
		{
			/* Скрытие placeholder`а */
			if (this.search_input.Text.Trim() == "Введите запрос для поиска...")
			{
				this.search_input.Text = "";
				this.search_input.ForeColor = Color.Black;
			}
			/* --------------------- */
		}

		private void search_input_Leave(object sender, EventArgs e)
		{
			/* Проявления placeholder`a */
			if (this.search_input.Text.Trim() == "" || this.search_input.Text.Trim() == "Введите запрос для поиска...")
			{
				this.search_input.Text = "Введите запрос для поиска...";
				this.search_input.ForeColor = Color.Gray;
			}
			/* ------------------------ */
		}

		private void search_filter_SelectedIndexChanged(object sender, EventArgs e)
		{
			/* Выбор фильтра для поиска */
			this.SearchFilter = this.search_filter.SelectedItem.ToString();
			/* ------------------------ */

			/* Заполнение подсказок по выбранному фильтру */
			foreach (String table in this.FilterToTableName[this.SearchFilter].Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
			{
				this.cmd.CommandText = String.Format("SELECT name FROM {0}", table);
				DbDataReader DR = this.cmd.ExecuteReader();
				while (DR.Read())
				{
					this.AutoCompleteList.Add(DR.GetString(0));
				}
				DR.Close();
			}
			/* ------------------------------------------ */
		}

		private void search_input_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && this.search_input.Text.Trim() != "")
			{
				/* Поиск по запросу с использованием фильтра */
				this.SearchInput = this.search_input.Text.Trim();
				this.LoadResults(sender);
				this.SearchInput = "";
				/* ----------------------------------------- */
				this.tabControl2.Visible = false;
				this.tabControl1.Visible = true;
			}
		}

		private void ChangeResults(object sender, EventArgs e)
		{
			this.CurrentPage = ((Button)sender).Tag.ToString();
			if (this.CurrentPage != "ПУ")
			{
				this.tabControl2.Visible = false;
				this.tabControl1.Visible = true;
				this.SelectedDateFrom = this.SelectedDateTo = this.tabControl1.SelectedTab.Tag.ToString();
				this.tabControl1.SelectedTab.Text = this.tabControl1.SelectedTab.Tag.ToString();
			}
			else
			{
				this.tabControl2.Visible = true;
				this.tabControl1.Visible = false;
			}
			this.LoadResults(sender);
		}

		private void registerButton_Click(object sender, EventArgs e)
		{
			Register RegisterForm = new Register();
			if (RegisterForm.ShowDialog() == DialogResult.OK)
			{
				cmd.CommandText = String.Format("INSERT INTO Users (login, password, email, phone) VALUES ('{0}', '{1}', '{2}', '{3}')", RegisterForm.login.Text, Main.Md5Hash(RegisterForm.pswd.Text), RegisterForm.email.Text, RegisterForm.phone.Text);
				try
				{
					cmd.ExecuteNonQuery();
				}
				catch (Exception)
				{
					MessageBox.Show("Пользователь с таким именем уже существует", "Ошибка", MessageBoxButtons.OK);
					return;
				}
				if (RegisterForm.login_save.Checked == true)
				{
					String pswd = Main.Md5Hash(RegisterForm.pswd.Text);
					this.user = this.Login(new String[] { RegisterForm.login.Text, pswd });
					String token = Main.Salt1;
					token += RegisterForm.login.Text;
					token += Main.Salt1;
					token += pswd;
					token += Main.Salt1;
					this.EncryptAesToken(new FileStream(userTokenFile, FileMode.Create, FileAccess.Write), token);
				}
			}
		}

		static public String Md5Hash(String s)
		{
			/* Хэшируем пароль */
			MD5 md5 = MD5.Create();
			byte[] pswdBytes = Encoding.UTF8.GetBytes(Main.Salt2 + s + Main.Salt1);
			byte[] pswdHash = md5.ComputeHash(pswdBytes);
			StringBuilder pswd = new StringBuilder();
			for (int i = 0; i < pswdHash.Length; i++)
				pswd.Append(pswdHash[i].ToString("X2"));
			/* --------------- */
			return pswd.ToString();
		}

		private void loginButton_Click(object sender, EventArgs e)
		{
			Login LoginForm = new Login();
			if (LoginForm.ShowDialog() == DialogResult.OK)
			{
				String pswd = Main.Md5Hash(LoginForm.password.Text);
				String token = Main.Salt1;
				token += LoginForm.log.Text;
				token += Main.Salt1;
				token += pswd;
				token += Main.Salt1;
				this.user = this.Login(new String[] { LoginForm.log.Text, pswd });
				if (this.user == null)
				{
					MessageBox.Show("Введен неверный логин и/или пароль");
					return;
				}
				if (LoginForm.checkBox1.Checked == true)
					this.EncryptAesToken(new FileStream(userTokenFile, FileMode.Create, FileAccess.Write), token);
			}
		}

		private void tabControl1_Selected(object sender, TabControlEventArgs e)
		{
			TabControl TC = (TabControl)sender;
			/* Записываем выбранную дату */
			this.SelectedDateFrom = this.SelectedDateTo = TC.SelectedTab.Text;
			if (this.PrevTP != null)
				this.PrevTP.Text = this.PrevTP.Tag.ToString();
			this.PrevTP = TC.SelectedTab;
			/* Заносим результаты по таблице в соответствии с датой*/
			this.LoadResults(sender);
			/* Переносим таблицу и панель с результатами на выбранную страницу */
			this.tableLayoutPanel8.Parent = TC.SelectedTab;
			this.panel1.Parent = TC.SelectedTab;
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			this.CalendarForm.DateFrom = this.SelectedDateFrom;
			this.CalendarForm.DateTo = this.SelectedDateTo;
			this.CalendarForm.Result = "Результат: " + this.SelectedDateFrom + " - " + this.SelectedDateTo;
			if (this.CalendarForm.ShowDialog() == DialogResult.OK)
			{
				this.SelectedDateFrom = this.CalendarForm.DateFrom;
				this.SelectedDateTo = this.CalendarForm.DateTo;
			}
		}

		private void BookATicket(object sender, EventArgs e)
		{
			int id = Int32.Parse(((ListView)sender).SelectedItems[0].Tag.ToString());
			cmd.CommandText = "SELECT Sessions.id, Films.name, Genres.name, Cinemas.name, " +
				"date, time, Films.duration, Cinemas.Rows, Cinemas.Columns, Sessions.is_cancelled " +
				"FROM Sessions, Films, Cinemas, Genres " +
				"WHERE Films.id = Sessions.id_film AND Genres.id = Films.id_genre AND Cinemas.id = Sessions.id_cinema AND Sessions.id = " + id;
			DbDataReader DR = cmd.ExecuteReader();
			Dictionary<int, Dictionary<int, int?>> bookedPlaces = null;
			Ticket ticket = null;
			if (DR.HasRows)
			{
				DR.Read();
				if (!DR.GetBoolean(9))
				{
					ticket = new Ticket(DR.GetInt32(0),
						DR.GetString(1),
						DR.GetString(2),
						DR.GetString(3),
						((TimeSpan)((object)DR.GetValue(5))),
						DR.GetInt32(6),
						DR.GetDateTime(4),
						DR.GetInt32(7),
						DR.GetInt32(8),
						this.user);
					DR.Close();
					cmd.CommandText = String.Format("SELECT row, col, id_user, email, phone FROM Tickets WHERE id_session = {0}", ticket.Id);
					DR = cmd.ExecuteReader();
					String cmds = "";
					if (DR.HasRows)
					{
						bookedPlaces = new Dictionary<int, Dictionary<int, int?>>();
						while (DR.Read())
						{
							Dictionary<int, int?> xPlaces;
							if (bookedPlaces.TryGetValue(DR.GetInt32(0), out xPlaces) == false)
							{
								bookedPlaces.Add(DR.GetInt32(0), new Dictionary<int, int?>());
								xPlaces = bookedPlaces[DR.GetInt32(0)];
							}
							int? i = (DR.IsDBNull(2)) ? null : (int?)DR.GetInt32(2);
							xPlaces.Add(DR.GetInt32(1), i);
						}
					}
					DR.Close();
					if (cmds != "")
					{
						cmd.CommandText = cmds;
						cmd.ExecuteNonQuery();
					}
				}
				else
				{
					MessageBox.Show("Данный сеанс был отменен");
					DR.Close();
					this.LoadResults(sender);
					return;
				}
			}
			else
			{
				MessageBox.Show("Данного сеанса не существует или он уже начался");
				DR.Close();
				this.LoadResults(sender);
				return;
			}
			BookTicket BookTicketForm = new BookTicket(ticket, bookedPlaces);
			this.Hide();
			if (BookTicketForm.ShowDialog() == DialogResult.OK)
			{
				this.Show();
				if (this.user != null)
				{
					cmd.CommandText = String.Format("DELETE FROM Tickets WHERE id_session = {0} AND id_user = {1}", ticket.Id, this.user.Id);
					cmd.ExecuteNonQuery();
				}
				String unique_id_hash = BookTicketForm.unique_id_hash;
				foreach (int[] place in BookTicketForm.places)
				{
					cmd.CommandText = String.Format("INSERT INTO Tickets (id_session, id_user, row, col, unique_id, email, phone) VALUES ({0}, {1}, {2}, {3}, '{4}', '{5}', '{6}')", ticket.Id, (this.user != null) ? this.user.Id.ToString() : "null", place[0], place[1], unique_id_hash, BookTicketForm.email.Text, BookTicketForm.phone.Text);
					cmd.ExecuteNonQuery();
				}
				if (this.CurrentPage == "Tickets")
					this.LoadResults(sender);
				if (MessageBox.Show("Хотите сохранить билет у себя на компьютере?", "Места успешно забронированы", MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					SaveFileDialog SFD = new SaveFileDialog();
					SFD.FileName = "Ticket";
					SFD.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
					SFD.Filter = "Изображение (*.png)|*.png";
					if (SFD.ShowDialog() == DialogResult.OK)
						BookTicketForm.bmp.Save(SFD.FileName, ImageFormat.Png);
				}
			}
			else
				this.Show();
		}

		private void ResultItemClick(object sender, EventArgs e)
		{
			ListView LV = (ListView)sender;
			if (LV == this.genres_result_table)
				this.CurrentPage = "По жанрам";
			if (LV == this.cinemas_result_table)
				this.CurrentPage = "По кинотеатрам";
			switch (this.CurrentPage)
			{
				case "По кинотеатрам":
					{
						this.CinemaIdFilter = LV.SelectedItems[0].Tag.ToString();
						this.CinemaNameFilter = LV.SelectedItems[0].Text;
						this.ChangeResults(this.PageToMenuButton["По фильмам"], null);
					}
					break;
				case "По жанрам":
					{
						this.GenreIdFilter = LV.SelectedItems[0].Tag.ToString();
						this.GenreNameFilter = LV.SelectedItems[0].Text;
						this.ChangeResults(this.PageToMenuButton["По фильмам"], null);
					}
					break;
				case "По фильмам":
					{
						this.BookATicket(sender, e);
					}
					break;
				case "Tickets":
					{
						this.BookATicket(sender, e);
					}
					break;
			}
		}
	}

	public partial class Ticket
	{
		public int Id { set; get; }
		public String Film { get; set; }
		public String Genre { get; set; }
		public String Cinema { get; set; }
		public TimeSpan StartTime { get; set; }
		public int Duration { get; set; }
		public DateTime Date { get; set; }
		public User User_ { get; set; }
		public int Rows { get; set; }
		public int Columns { get; set; }
		public Ticket(int id, String film, String genre, String cinema, TimeSpan startitme, int duration, DateTime date, int rows, int cols, User user)
		{
			this.Rows = rows;
			this.Columns = cols;
			this.Id = id;
			this.Film = film;
			this.Genre = genre;
			this.Cinema = cinema;
			this.StartTime = startitme;
			this.Duration = duration;
			this.Date = date;
			this.User_ = user;
		}
	}

	public class User
	{
		public int? Id { get; }
		public String Login { get; }
		public bool IsAdmin { get; }
		public String Phone { get; set; }
		public String Email { get; set; }
		public User(int id, String login, bool isadmin, String email, String phone)
		{
			this.Id = id;
			this.Login = login;
			this.IsAdmin = isadmin;
			this.Phone = phone;
			this.Email = email;
		}
	}
}
