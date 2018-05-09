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
using System.Data.OleDb;

namespace WindowsFormsApp1
{
	public partial class Form1 : Form
	{
		private DataSet DS;
		private DbDataAdapter DA;
		private DataRelation DR;
		private DbConnection cn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\CountriesCities.accdb");
		public Form1()
		{
			InitializeComponent();
			this.DS = new DataSet();
			DbCommand cmd = cn.CreateCommand();
			this.DA = new OleDbDataAdapter((OleDbCommand)cmd);
			cmd.CommandText = "SELECT * FROM Countries";
			this.DA.Fill(this.DS, "Countries");
			cmd.CommandText = "SELECT * FROM Cities";
			this.DA.Fill(this.DS, "Cities");
			this.countriesTable.DataSource = this.DS.Tables["Countries"];

			DR = new DataRelation("CityCountryRelation", this.DS.Tables["Countries"].Columns["id"], this.DS.Tables["Cities"].Columns["id_country"]);
			this.DS.Relations.Add(DR);

			ForeignKeyConstraint FKC = DR.ChildKeyConstraint;
			FKC.DeleteRule = Rule.None;
			FKC.UpdateRule = Rule.None;

			DataTable DT = new DataTable();
			DT.Columns.Add("id", typeof(int));
			DT.Columns.Add("name", typeof(string));
			DT.Columns.Add("id_country", typeof(string));
			this.citiesTable.DataSource = DT;

			this.countriesTable.Rows[0].Selected = true;
			this.countriesTable_CellMouseClick(null, null);
		}

		private void countriesTable_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			DataTable DT = this.countriesTable.DataSource as DataTable;
			if (DT != null)
			{
				DataRow DR = null;
				try
				{
					DR = ((DataRowView)this.countriesTable.SelectedRows[0].DataBoundItem).Row;
				}
				catch (Exception) { return; }
				if (DR != null)
				{
					try
					{
						DataRow[] DRS = DR.GetChildRows(this.DS.Relations["CityCountryRelation"]);
						((DataTable)this.citiesTable.DataSource).Rows.Clear();
						foreach (DataRow r in DRS)
							((DataTable)this.citiesTable.DataSource).Rows.Add(r.ItemArray);
					}
					catch (Exception a) { MessageBox.Show(a.Message); }
				}
			}
		}

		private void countriesTable_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{
			MessageBox.Show(e.Exception.Message);
		}
	}
}
