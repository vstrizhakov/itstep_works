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

namespace Notepad
{
	public partial class Form1 : Form
	{
		private String FilePath;
		public Form1()
		{
			InitializeComponent();
			this.сохранитьToolStripMenuItem.Enabled = false;
			this.FormClosing += Form1_FormClosing;
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			if ((this.FilePath != null || this.textBox1.Text != "") && this.сохранитьToolStripMenuItem.Enabled == true)
			{
				Form2 OK = new Form2(this.FilePath, this, this.textBox1.Text);
				if (OK.ShowDialog() == DialogResult.Cancel)
					e.Cancel = true;
			}
		}

		private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog OFD = new OpenFileDialog();
			OFD.Title = "Выберите файл";
			OFD.Filter = "Text Files (*.txt)|*.txt";
			if (OFD.ShowDialog() == DialogResult.OK)
			{
				this.FilePath = OFD.FileName;
				FileStream FS = File.Open(OFD.FileName, FileMode.Open, FileAccess.Read);
				StreamReader SR = new StreamReader(FS);
				this.textBox1.Text = SR.ReadToEnd();
				SR.Close();
				this.сохранитьToolStripMenuItem.Enabled = false;
			}
		}

		private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FileStream FS = File.Open(this.FilePath, FileMode.Create, FileAccess.Write);
			StreamWriter SW = new StreamWriter(FS);
			SW.Write(this.textBox1.Text);
			SW.Close();
			this.сохранитьToolStripMenuItem.Enabled = false;
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			this.сохранитьToolStripMenuItem.Enabled = true;
		}

		private void выходToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveFileDialog SFD = new SaveFileDialog();
			SFD.Title = "Выберите файл для сохранения";
			SFD.Filter = "Text Files (*.txt)|*.txt";
			if (SFD.ShowDialog() == DialogResult.OK)
			{
				this.FilePath = SFD.FileName;
				FileStream FS = File.Open(this.FilePath, FileMode.Create, FileAccess.Write);
				StreamWriter SW = new StreamWriter(FS);
				SW.Write(this.textBox1.Text);
				SW.Close();
				this.сохранитьToolStripMenuItem.Enabled = false;
			}
		}

		private void изменитьШрифтToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FontDialog FD = new FontDialog();
			FD.Font = this.textBox1.Font;
			FD.ScriptsOnly = true;
			FD.ShowColor = true;
			FD.ShowEffects = true;
			FD.ShowApply = true;
			FD.Apply += FD_Apply;
			FD.Color = this.textBox1.ForeColor;
			if (FD.ShowDialog() == DialogResult.OK)
			{
				try
				{
					this.textBox1.Font = FD.Font;
					this.textBox1.ForeColor = FD.Color;
				}
				catch
				{
					MessageBox.Show("Невозможно применить данный шрифт!");
				}
			}
		}

		private void FD_Apply(object sender, EventArgs e)
		{
			if (sender is FontDialog)
			{
				try
				{
					FontDialog FD = (FontDialog)sender;
					this.textBox1.Font = FD.Font;
					this.textBox1.ForeColor = FD.Color;
				}
				catch
				{
					MessageBox.Show("Невозможно применить данный шрифт!");
				}
			}
		}

		private void изменитьЦветФонаToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ColorDialog CD = new ColorDialog();
			CD.FullOpen = true;
			if (CD.ShowDialog() == DialogResult.OK)
			{
				this.textBox1.BackColor = CD.Color;
			}
		}

		private void изменитьЦветТекстаToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ColorDialog CD = new ColorDialog();
			CD.FullOpen = true;
			if (CD.ShowDialog() == DialogResult.OK)
			{
				this.textBox1.ForeColor = CD.Color;
			}
		}
	}
}
