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

namespace RichTextBox_
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog OFD = new OpenFileDialog();
			OFD.Filter = "RTF (*.rtf)|*.rtf|Text (*.txt)|*.txt";
			if (OFD.ShowDialog() == DialogResult.OK)
			{
				FileStream FS = new FileStream(OFD.FileName, FileMode.Open, FileAccess.Read);
				if (Path.GetExtension(OFD.FileName) == ".rtf")
					this.richTextBox1.LoadFile(FS, RichTextBoxStreamType.RichText);
				else
					this.richTextBox1.LoadFile(FS, RichTextBoxStreamType.PlainText);
			}
		}

		private void saveAsRTFToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveFileDialog SFD = new SaveFileDialog();
			SFD.Filter = "RTF (*.rtf)|*.rtf|Text (*.txt)|*.txt";
			SFD.CheckPathExists = true;
			SFD.DefaultExt = "rtf";
			SFD.AddExtension = true;
			if (SFD.ShowDialog() == DialogResult.OK)
			{
				if (Path.GetExtension(SFD.FileName) == ".rtf")
					this.richTextBox1.SaveFile(SFD.FileName, RichTextBoxStreamType.RichText);
				else
					this.richTextBox1.SaveFile(SFD.FileName, RichTextBoxStreamType.PlainText);
			}
		}
		
		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void textColorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ColorDialog CD = new ColorDialog();
			if (CD.ShowDialog() == DialogResult.OK)
			{
				this.richTextBox1.SelectionColor = CD.Color;
			}
		}

		private void textBackcolorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ColorDialog CD = new ColorDialog();
			if (CD.ShowDialog() == DialogResult.OK)
			{
				this.richTextBox1.SelectionBackColor = CD.Color;
			}
		}

		private void textFontToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FontDialog FD = new FontDialog();
			if (FD.ShowDialog() == DialogResult.OK)
			{
				this.richTextBox1.SelectionFont = FD.Font;
			}
		}
	}
}
