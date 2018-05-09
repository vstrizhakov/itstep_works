using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComboBoxDataGridView
{
	public partial class Form1 : Form
	{
		private DataTable dtA;
		private DataTable dtB;
		public Form1()
		{
			InitializeComponent();
			dtA = new DataTable("Authors");
			dtA.Columns.Add(new DataColumn("id", typeof(int)));
			dtA.Columns.Add(new DataColumn("name", typeof(string)));
			DataRow dr = dtA.NewRow();
			dr["id"] = 1;
			dr["name"] = "Bill Gates";
			dtA.Rows.Add(dr);

			dr = dtA.NewRow();
			dr["id"] = 2;
			dr["name"] = "Steve Jobs";
			dtA.Rows.Add(dr);

			dtB = new DataTable("Books");
			dtB.Columns.Add(new DataColumn("id", typeof(int)));
			dtB.Columns.Add(new DataColumn("name", typeof(string)));
			dtB.Columns.Add(new DataColumn("id_author", typeof(int)));

			dr = dtB.NewRow();
			dr["id"] = 1;
			dr["name"] = "Microsoft Windows";
			dr["id_author"] = 1;
			dtB.Rows.Add(dr);

			dr = dtB.NewRow();
			dr["id"] = 2;
			dr["name"] = "Visual Studio";
			dr["id_author"] = 1;
			dtB.Rows.Add(dr);

			dr = dtB.NewRow();
			dr["id"] = 3;
			dr["name"] = "Apple iPad";
			dr["id_author"] = 2;

			this.dataGridView1.DataSource = dtB;

			DataGridViewComboBoxColumn cbcol = new DataGridViewComboBoxColumn();
			cbcol.Name = "Author";
			cbcol.FlatStyle = FlatStyle.Flat;
			cbcol.DataSource = dtA;
			cbcol.ValueMember = "id";
			cbcol.DisplayMember = "name";
			cbcol.DataPropertyName = "id_author";

			this.dataGridView1.Columns.Add(cbcol);
			this.dataGridView1.Columns["id_author"].Visible = false;
			dtB.Rows.Add(dr);
		}
	}
}
