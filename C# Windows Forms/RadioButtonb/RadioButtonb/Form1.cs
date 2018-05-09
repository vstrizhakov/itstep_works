using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RadioButtonb
{
	public partial class Form1 : Form
	{
		private String[] arrGB1Values =
		{
			"Red", "Green", "Blue", "Yellow", "Orange"
		};
		private String[] arrGB2Values =
		{
			"Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"
		};
		public Form1()
		{
			InitializeComponent();
			GroupBox GB = new GroupBox();
			GB.Location = new Point(20, 20);
			GB.Size = new Size(120, 200);
			for (int i = 0; i < 5; i++)
			{
				RadioButton RB = new RadioButton();
				RB.Text = this.arrGB1Values[i];
				RB.Location = new Point(20, 20 + 30 * i);
				GB.Controls.Add(RB);
				RB.Click += GroupClick;
				RB.Tag = (object)i;
			}
			this.Controls.Add(GB);

			GroupBox GB1 = new GroupBox();
			GB1.Location = new Point(170, 20);
			GB1.Size = new Size(120, 200);
			for (int i = 0; i < 7; i++)
			{
				RadioButton RB = new RadioButton();
				RB.Text = this.arrGB2Values[i];
				RB.Location = new Point(20, 20 + 30 * i);
				GB1.Controls.Add(RB);
				RB.Click += Group2Click;
				RB.Tag = (object)i;
			}
			this.Controls.Add(GB1);
		}

		private void GroupClick(object sender, EventArgs e)
		{
			if (sender is RadioButton)
			{
				RadioButton RB = (RadioButton)sender;
				MessageBox.Show(this.arrGB1Values[(int)RB.Tag]);
			}
		}

		private void Group2Click(object sender, EventArgs e)
		{
			if (sender is RadioButton)
			{
				RadioButton RB = (RadioButton)sender;
				MessageBox.Show(this.arrGB2Values[(int)RB.Tag]);
			}
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}
	}
}
