using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Client
{
	public partial class Connecting : Form
	{
		public Connecting()
		{
			InitializeComponent();
			this.FormClosing += IfOnFormClosing;
			this.Shown += OnFormShown;
		}

		private void OnFormShown(object sender, EventArgs e)
		{
			Thread T = new Thread(this.TryToConnect);
			T.IsBackground = true;
			T.Start();
		}

		private void TryToConnect()
		{
			while (this.IsHandleCreated == false) { }
			this.Invoke(new Action(() =>
			{
				this.linkLabel1.Visible = false;
				this.linkLabel2.Visible = false;
			}));
			for (int i = 0; i < 5; i++)
			{
				this.label1.Invoke(new Action(() => { this.label1.Text = String.Format("Попытка {0} из 5 соединения с сервером...", i + 1); }));
				if (GameController.Connect(GameController.Username) == 0)
				{
					this.DialogResult = DialogResult.OK;
					return;
				}
			}
			this.Invoke(new Action(() =>
			{
				this.label1.Text = "Не удалось соединиться с сервером";
				this.linkLabel1.Visible = true;
				this.linkLabel2.Visible = true;
			}));
		}

		private void IfOnFormClosing(object sender, FormClosingEventArgs e)
		{
			if (this.DialogResult != DialogResult.OK)
			{
				if (MessageBox.Show("Вы уверены, что хотите выйти из программы?", "Выход", MessageBoxButtons.YesNo) == DialogResult.Yes)
					this.DialogResult = DialogResult.Yes;
				else
					e.Cancel = true;
			}
		}

		private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			this.Close();
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			this.OnFormShown(null, null);
		}
	}
}
