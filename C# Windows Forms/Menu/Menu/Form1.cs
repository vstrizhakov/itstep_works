using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Menu
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			MainMenu MM = new MainMenu();
			MenuItem menuFile = new MenuItem("File");
			MenuItem menuEdit = new MenuItem("Edit");

			MM.MenuItems.Add(menuFile);
			MM.MenuItems.Add(menuEdit);
			this.Menu = MM;

			MenuItem menuFileOpen = new MenuItem("Open");
			menuFile.MenuItems.Add(menuFileOpen);

			MenuItem menuFileSave = new MenuItem("Save");
			menuFile.MenuItems.Add(menuFileSave);

			MenuItem menuFileCopy = new MenuItem("Copy");
			menuEdit.MenuItems.Add(menuFileCopy);

			MenuItem menuFilePaste = new MenuItem("Paste");
			menuEdit.MenuItems.Add(menuFilePaste);

			menuFileOpen.Click += MenuFileOpen_Click;
			menuFileOpen.Tag = (object)1;
			menuFileCopy.Click += MenuFileOpen_Click;
			menuFileCopy.Tag = (object)2;
			menuFileSave.Click += MenuFileOpen_Click;
			menuFileSave.Tag = (object)3;
			menuFilePaste.Click += MenuFileOpen_Click;
			menuFilePaste.Tag = (object)4;
		}

		private void MenuFileOpen_Click(object sender, EventArgs e)
		{
			if (sender is MenuItem)
			{
				int tag = (int)((MenuItem)sender).Tag;
				switch (tag)
				{
					case 1:
						MessageBox.Show("Open");
						break;
					case 2:
						MessageBox.Show("Copy");
						break;
					case 3:
						MessageBox.Show("Save");
						break;
					case 4:
						MessageBox.Show("Paste");
						break;
				}
			}
		}
	}
}
