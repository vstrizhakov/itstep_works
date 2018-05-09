using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListBox_
{
	public partial class ProductForm : Form
	{
		public ProductForm()
		{
			InitializeComponent();
			this.FormClosing += ProductForm_FormClosing;
			this.errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
		}

		private void ProductForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (this.name.Text == "" || this.price.Text == "" || this.weight.Text == "")
			{
				if (MessageBox.Show("Вы не заполнили все поля. Элемент не будет добавлен/отредактирован!", "Ошибка", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
					e.Cancel = true;
				else
					this.DialogResult = DialogResult.Cancel;
			}
			else
			{
				try
				{
					Double.Parse(this.price.Text.Replace(".", ","));
					Int32.Parse(this.weight.Text);
				}
				catch
				{
					if (MessageBox.Show("Вы ввели неверные значения. Элемент не будет добавлен/отредактирован!", "Ошибка", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
						e.Cancel = true;
					else
						this.DialogResult = DialogResult.Cancel;
				}
			}
		}

		private void name_TextChanged(object sender, EventArgs e)
		{
			if (((TextBox)sender).Text == "")
				errorProvider1.SetError((TextBox)sender, "Заполните это поле!");
			else
				errorProvider1.SetError((TextBox)sender, "");
		}

		private void price_TextChanged(object sender, EventArgs e)
		{
			try {
				//((TextBox)sender).Text = ((TextBox)sender).Text.Replace(".", ",");
				Double.Parse(((TextBox)sender).Text.Replace(".", ","));
				errorProvider1.SetError((TextBox)sender, "");
			}
			catch {
				errorProvider1.SetError((TextBox)sender, "Заполните это поле!");
			}
		}

		private void weight_TextChanged(object sender, EventArgs e)
		{
			try
			{
				Int32.Parse(((TextBox)sender).Text);
				errorProvider1.SetError((TextBox)sender, "");
			}
			catch
			{
				errorProvider1.SetError((TextBox)sender, "Заполните это поле!");
			}
		}
	}
}
