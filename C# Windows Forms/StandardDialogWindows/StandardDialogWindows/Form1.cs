using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StandardDialogWindows
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void цветФонаToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ColorDialog CD = new ColorDialog();
			CD.AnyColor = false;
			CD.Color = this.BackColor;
			CD.FullOpen = true;
			if (CD.ShowDialog() == DialogResult.OK)
			{
				this.BackColor = CD.Color;
				for (int i = 0; i < CD.CustomColors.Length; i++)
					Console.WriteLine(CD.CustomColors[i]);
			}
		}

		private void выбратьToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog FBD = new FolderBrowserDialog();
			FBD.ShowNewFolderButton = true;
			FBD.RootFolder = Environment.SpecialFolder.CommonProgramFiles;
			if (FBD.ShowDialog() == DialogResult.OK)
			{
				this.Text = FBD.SelectedPath;
			}
		}

		private void шрифтToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FontDialog FD = new FontDialog();
			FD.Font = this.label1.Font;
			FD.ScriptsOnly = true;
			FD.ShowColor = true;
			FD.ShowEffects = true;
			FD.ShowApply = true;
			FD.Apply += FD_Apply;
			if (FD.ShowDialog() == DialogResult.OK)
			{
				this.label1.Font = FD.Font;
			}
		}

		private void FD_Apply(object sender, EventArgs e)
		{
			if (sender is FontDialog)
			{
				FontDialog FD = (FontDialog)sender;
				this.label1.Font = FD.Font;
			}
		}
	}
}
