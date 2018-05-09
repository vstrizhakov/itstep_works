using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Common;
using System.Configuration;

namespace UniversalLibrary
{
	public partial class Form1 : Form
	{
		private DbConnection cn;
		private DataSet DS;
		private DbDataAdapter DA;
		private String[] tables =
		{
			"Authors", "Books", "Categories", "Departments", "Faculties", "Groups", "Libs", "Press",
			"S_Cards", "T_Cards", "Students", "Teachers", "Themes"
		};
		public Form1()
		{
			InitializeComponent();
			string provider = ConfigurationManager.AppSettings["provider"];
			string connectionStr = ConfigurationManager.AppSettings["connectionStr"];

			DbProviderFactory DPF = DbProviderFactories.GetFactory(provider);
			this.cn = DPF.CreateConnection();
			this.cn.ConnectionString = connectionStr;
			this.cn.Open();

			this.DS = new DataSet();

			this.DA = DPF.CreateDataAdapter();
			foreach (String table in this.tables)
			{
				DbCommand cmd = this.cn.CreateCommand();
				cmd.CommandText = "SELECT * FROM " + table;
				this.DA.SelectCommand = cmd;
				this.DA.Fill(this.DS, table);

				this.selectedTable.Items.Add(table);
			}

			this.selectedTable.SelectedIndex = 0;
		}

		private void selectedTable_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.dataGridView1.DataSource = this.DS.Tables[this.selectedTable.SelectedIndex];
		}
	}
}
