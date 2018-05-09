using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListView
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			this.listView1.View = View.Details;
			this.listView1.LargeImageList = this.imageList1;
			this.listView1.SmallImageList = this.imageList2;
			for (int i = 0; i < 100;i++)
			{
				ListViewItem LVI = new ListViewItem("Hello " + i, i % 3);
				LVI.SubItems.Add("World " + i);
				LVI.SubItems.Add("Forever " + i);
				this.listView1.Items.Add(LVI);
			}

			//this.listView1.Columns.Add("1");
			ColumnHeader CH1 = new ColumnHeader();
			CH1.Text = "1";
			CH1.Width = 150;
			CH1.TextAlign = HorizontalAlignment.Center;
			this.listView1.Columns.Add(CH1);

			this.listView1.Columns.Add("2");
			this.listView1.Columns.Add("3");
			this.listView1.GridLines = true;
			this.listView1.FullRowSelect = true;
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}
	}

	
}
