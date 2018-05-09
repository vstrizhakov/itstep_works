using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Explorere
{
	public partial class AskNameForm : Form
	{
		private String path;
		public AskNameForm(String path = null)
		{
			InitializeComponent();
			this.path = Path.GetFileName(path);
			if (path != null)
				this.name.Text = this.path;
			this.FormClosing += AskNameForm_FormClosing;
		}

		private void AskNameForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (this.DialogResult == DialogResult.Cancel)
				return;
			if (this.name.Text.Intersect(Path.GetInvalidFileNameChars()).Any())
			{
				this.errorProvider1.SetError(this.name, "Название папки содержит недопустимые символы");
				e.Cancel = true;
			}
			else if (this.name.Text == "")
			{
				this.errorProvider1.SetError(this.name, "Заполните это поле");
				e.Cancel = true;
			}
			else if (!Directory.Exists(path) && Path.GetExtension(this.name.Text) != "" && Path.GetExtension(this.name.Text) != Path.GetExtension(path) && this.path != null)
			{
				this.errorProvider1.SetError(this.name, "");
				if (MessageBox.Show(String.Format("Вы уверенны, что хотите сохранить файл с расширением \"{0}\"?", Path.GetExtension(this.name.Text)), "Вы уверенны?", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
					e.Cancel = true;
			}
			else
				this.name.Text = this.name.Text + Path.GetExtension(this.path);
		}

		public String InputName
		{
			get
			{
				return this.name.Text;
			}
		}

		private void name_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.SuppressKeyPress = true;
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
		}
	}
}
