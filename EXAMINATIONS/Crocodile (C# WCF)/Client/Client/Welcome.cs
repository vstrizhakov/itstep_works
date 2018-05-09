using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrocodileServer;

namespace Client
{
	public partial class Welcome : Form
	{
		public Welcome()
		{
			InitializeComponent();
			this.Shown += OnFormShown;
			this.FormClosing += OnFormClosing;
			GameController.OnPlayersCountChanged += GameController_OnPlayersCountChanged;
		}

		private void GameController_OnPlayersCountChanged()
		{
			this.Invoke(new Action(() =>
			{
				this.players_online.Text = "Игроков онлайн: " + GameController.PlayersCount.ToString();
			}));
		}

		private void OnFormClosing(object sender, FormClosingEventArgs e)
		{
			this.Hide();
			GameController.Disconnect();
		}

		private void OnFormShown(object sender, EventArgs e)
		{
			Connecting C = new Connecting();
			if (C.ShowDialog() == DialogResult.Yes)
			{
				this.Close();
			}
			else
			{
				this.nick_label.Text = GameController.Username;
			}
			C.Dispose();
		}

		private void nick_textBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
				this.change_name_Click(null, null);
		}

		private void change_name_Click(object sender, EventArgs e)
		{
			int result = GameController.ChangeNickName((this.nick_textBox.Text != "Введите новый ник...") ? this.nick_textBox.Text : "");
			if (result == -1)
			{
				this.OnFormShown(null, null);
			}
			this.nick_label.Text = GameController.Username;
		}

		private void nick_textBox_Enter(object sender, EventArgs e)
		{
			if (this.nick_textBox.Text == "Введите новый ник...")
			{
				this.nick_textBox.Text = "";
				this.nick_textBox.ForeColor = Color.Black;
			}
		}

		private void nick_textBox_Leave(object sender, EventArgs e)
		{
			if (this.nick_textBox.Text == "")
			{
				this.nick_textBox.Text = "Введите новый ник...";
				this.nick_textBox.ForeColor = Color.Gray;
			}
		}

		private void dont_draw_Click(object sender, EventArgs e)
		{
			this.want_to_draw.Checked = false;
		}

		private void want_to_draw_Click(object sender, EventArgs e)
		{
			this.dont_draw.Checked = false;
		}

		private void play_Click(object sender, EventArgs e)
		{
			int type = 0;
			if (this.dont_draw.Checked)
				type = 1;
			if (this.want_to_draw.Checked)
				type = 2;
			while (true)
			{
				Room R = GameController.EnterRoom(type);
				if (R == null)
				{
					this.OnFormShown(null, null);
					return;
				}

				Game G = new Game(R, type);
				DialogResult DG = DialogResult.OK;
				this.Hide();
				DG = G.ShowDialog();
				this.Show();
				if (DG == DialogResult.Abort)
					this.OnFormShown(null, null);
				if (DG != DialogResult.Yes)
					break;
			}
		}
	}
}
