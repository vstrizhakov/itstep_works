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
	public partial class Session : Form
	{
		public Session(bool isEditing = false)
		{
			InitializeComponent();

			if (isEditing)
			{
				this.Text = "Редактирование сеанса";
				this.button1.Text = "Редактировать";
				this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 2);
				this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel4, 2);
				this.tableLayoutPanel2.Visible = false;
				this.label3.Text = "Дата";
			}
			else
			{
				this.Text = "Добавление сеанса";
				this.button1.Text = "Добавить";
			}

			this.FormClosing += Session_FormClosing;
		}

		private void Session_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (this.DialogResult == DialogResult.OK)
			{
				if (this.time.Text.Trim() == "")
				{
					MessageBox.Show("Заполните все поля!");
					e.Cancel = true;
					return;
				}
				try
				{
					DateTime.Parse(this.time.Text);
				}
				catch (Exception)
				{
					MessageBox.Show("Введеное время имеет неверный формат");
					e.Cancel = true;
					return;
				}
				if (DateTime.Parse(this.dateFrom.Text) == DateTime.Now.Date && DateTime.Now.TimeOfDay > DateTime.Parse(this.time.Text).AddMinutes(1).TimeOfDay)
				{
					MessageBox.Show("Невозможно добавить сеанс в прошлое :)");
					e.Cancel = true;
					return;
				}
			}
		}

		private void dateFrom_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				if (DateTime.Parse(this.dateTo.Text) < DateTime.Parse(this.dateFrom.Text))
				{
					String tmp = this.dateTo.Text;
					this.dateTo.Text = this.dateFrom.Text;
					this.dateFrom.Text = tmp;
				}
			}
			catch (Exception) { }
		}
	}
}
