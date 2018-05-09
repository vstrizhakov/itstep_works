using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RadioButton2
{
	public partial class Form1 : Form
	{
		private RadioButton[] arrRB1;
		private RadioButton[] arrRB2;
		private String[] values1 = { "Winter", "Spring", "Summer", "Autumn" };
		private String[] values2 = { "Square", "Romb", "triangle" };

		public Form1()
		{
			InitializeComponent();
			arrRB1 = new RadioButton[] { this.radioButton1, this.radioButton2, this.radioButton3, this.radioButton4 };
			arrRB2 = new RadioButton[] { this.radioButton5, this.radioButton6, this.radioButton7 };
		}

		private void Group1Click(object sender, EventArgs e)
		{
			for (int i = 0; i < this.values1.Length; i++)
			{
				if (sender == this.arrRB1[i])
				{
					MessageBox.Show(this.values1[i]);
					break;
				}
			}
		}

		private void Group2Click(object sender, EventArgs e)
		{
			for (int i = 0; i < this.values1.Length; i++)
			{
				if (sender == this.arrRB2[i])
				{
					MessageBox.Show(this.values2[i]);
					break;
				}
			}
		}
	}
}
