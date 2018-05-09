using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToolBar
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void toolStripButton1_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Hello, World!");
		}

		private void ChangeColor(object sender, EventArgs e)
		{
			if (sender is ToolStripItem)
			{
				ToolStripItem TSI = (ToolStripItem)sender;
				if (TSI.Tag.ToString() == "red")
					this.BackColor = Color.Red;
				if (TSI.Tag.ToString() == "green")
					this.BackColor = Color.Green;
				if (TSI.Tag.ToString() == "blue")
					this.BackColor = Color.Blue;

			}
		}

		private void toolStripSplitButton1_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Microsoft Forever");
		}
	}
}
