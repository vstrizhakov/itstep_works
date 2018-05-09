using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
namespace ContextMenu_
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			ContextMenu menu = new ContextMenu();
			MenuItem menuOpen = new MenuItem("Open");
			menuOpen.Tag = "Open";
			menu.MenuItems.Add(menuOpen);

			MenuItem menuFormat = new MenuItem("Format");
			menuFormat.Tag = "Format";
			menu.MenuItems.Add(menuFormat);

			menuOpen.Click += MenuFormat_Click;
			menuFormat.Click += MenuFormat_Click;
			this.ContextMenu = menu;
		}

		private void MenuFormat_Click(object sender, EventArgs e)
		{
			if (sender is MenuItem)
			{
				MenuItem tmp = (MenuItem)sender;
				switch(tmp.Tag.ToString())
				{
					case "Open":
						{
							OpenFileDialog OFD = new OpenFileDialog();
							OFD.ShowDialog();
						}
						break;
					case "Format":
						{
							Process.Start("ping.exe", "10.3.0.5");
						}
						break;
				}
			}
		}
	}
}
