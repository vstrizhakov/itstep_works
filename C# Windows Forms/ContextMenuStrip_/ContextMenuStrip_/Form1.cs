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
namespace ContextMenuStrip_
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			//ContextMenuStrip menu = new ContextMenuStrip();
			//ToolStripMenuItem menuOpen = new ToolStripMenuItem("Opem");
			//menuOpen.Click += MenuOpen_Click;
			//menuOpen.Tag = "Open";
			//menu.Items.Add(menuOpen);

			//ToolStripMenuItem menuPing = new ToolStripMenuItem("Ping");
			//menuPing.Click += MenuOpen_Click;
			//menuPing.Tag = "Ping";
			//menu.Items.Add(menuPing);

			//this.ContextMenuStrip = menu;
		}

		private void MenuOpen_Click(object sender, EventArgs e)
		{
			if (sender is ToolStripMenuItem)
			{
				ToolStripMenuItem tmp = (ToolStripMenuItem)sender;
				switch (tmp.Tag.ToString())
				{
					case "Open":
						{
							OpenFileDialog OFD = new OpenFileDialog();
							OFD.ShowDialog();
						}
						break;
					case "Ping":
						{
							Process.Start("ping.exe", "10.3.0.5");
						}
						break;
				}
			}
		}
	}
}
