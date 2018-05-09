using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompoBox
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			ComboBox CB = new ComboBox();
			CB.Location = new Point(20,20);
			CB.Size = new Size(120, 25);
			this.Controls.Add(CB);

			CB.Items.Add("1");
			CB.Items.Add("2");
			CB.Items.Add("3");
			CB.Items.Add("4");
			CB.Items.Add("5");
			CB.Items.Add("6");
			CB.Items.Add("7");
			CB.SelectedIndexChanged += CB_SelectedIndexChanged;

			this.FormClosing += Form1_FormClosing;
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			MessageBox.Show("SERGEY IDET NAHUY");
			e.Cancel = false;
		}

		private void CB_SelectedIndexChanged(object sender, EventArgs e)
		{
			ComboBox CB = (ComboBox)sender;
			MessageBox.Show(String.Format("Index = " + CB.SelectedIndex + "\nValue = " + CB.SelectedItem));
		}
	}
}
