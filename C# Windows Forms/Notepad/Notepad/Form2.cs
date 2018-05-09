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
	public partial class Form2 : Form
	{
		private String FilePath;
		private Form parent;
		private String Textb;
		public Form2(String filePath, Form parent, String text)
		{
			this.Textb = text;
			this.parent = parent;
			this.FilePath = filePath;
			InitializeComponent();
			if (this.FilePath == null)
				this.save.Enabled = false;
		}

		private void Save(object sender, EventArgs e)
		{
			FileStream FS = File.Open(this.FilePath, FileMode.Create, FileAccess.Write);
			StreamWriter SW = new StreamWriter(FS);
			SW.Write(this.Textb);
			SW.Close();
		}
		
		private void SaveAs(object sender, EventArgs e)
		{
			SaveFileDialog SFD = new SaveFileDialog();
			SFD.Title = "Выберите файл для сохранения";
			SFD.Filter = "Text Files (*.txt)|*.txt";
			if (SFD.ShowDialog() == DialogResult.OK)
			{
				FileStream FS = File.Open(SFD.FileName, FileMode.Create, FileAccess.Write);
				StreamWriter SW = new StreamWriter(FS);
				SW.Write(this.Textb);
				SW.Close();
			}
		}
	}
	
}
