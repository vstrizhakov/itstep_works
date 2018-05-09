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

namespace CountriesCities
{
	public partial class Form1 : Form
	{
		private DbDataAdapter DA;
		private DataSet DS;
		private DbConnection cn;
		private DbCommand cmdDelCountry;
		private DbCommand cmdDelCity;
		private DbCommand cmdInsCountry;
		private DbCommand cmdInsCity;
		private DbCommand cmdUpdCountry;
		private DbCommand cmdUpdCity;
		private DataGridViewComboBoxColumn cbcol;
		private String[] Tables = { "Countries", "Cities" };
		public Form1()
		{
			InitializeComponent();
			this.DS = new DataSet();
			this.cn = new OleDbConnection();
			this.cn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\CountriesCities.accdb";

			OleDbCommand cmdSel = (OleDbCommand)this.cn.CreateCommand();
			this.DA = new OleDbDataAdapter(cmdSel);
			foreach (String table in Tables)
			{
				cmdSel.CommandText = "SELECT * FROM " + table;
				this.DA.Fill(this.DS, table);
			}

			this.cmdDelCountry = this.cn.CreateCommand();
			this.cmdDelCountry.CommandText = "DELETE FROM Countries WHERE id = @id";
			DbParameter P1 = this.cmdDelCountry.CreateParameter();
			P1.DbType = DbType.Int32;
			P1.ParameterName = "@id";
			P1.SourceColumn = "id";
			this.cmdDelCountry.Parameters.Add(P1);

			this.cmdDelCity = this.cn.CreateCommand();
			this.cmdDelCity.CommandText = "DELETE FROM Cities WHERE id = @id";
			P1 = this.cmdDelCity.CreateParameter();
			P1.DbType = DbType.Int32;
			P1.ParameterName = "@id";
			P1.SourceColumn = "id";
			this.cmdDelCity.Parameters.Add(P1);

			this.cmdInsCountry = this.cn.CreateCommand();
			this.cmdInsCountry.CommandText = "INSERT INTO Countries (name) VALUES (@name)";
			P1 = this.cmdInsCountry.CreateParameter();
			P1.DbType = DbType.String;
			P1.ParameterName = "@name";
			P1.SourceColumn = "name";
			this.cmdInsCountry.Parameters.Add(P1);

			this.cmdUpdCountry = this.cn.CreateCommand();
			this.cmdUpdCountry.CommandText = "UPDATE Countries SET name = @name WHERE id = @id";
			P1 = this.cmdUpdCountry.CreateParameter();
			P1.DbType = DbType.String;
			P1.ParameterName = "@name";
			P1.SourceColumn = "name";
			this.cmdUpdCountry.Parameters.Add(P1);
			P1 = this.cmdUpdCountry.CreateParameter();
			P1.DbType = DbType.Int32;
			P1.ParameterName = "@id";
			P1.SourceColumn = "id";
			this.cmdUpdCountry.Parameters.Add(P1);

			this.cmdInsCity = this.cn.CreateCommand();
			this.cmdInsCity.CommandText = "INSERT INTO Cities (name, id_country) VALUES (@name, @id_country)";
			P1 = this.cmdInsCity.CreateParameter();
			P1.DbType = DbType.String;
			P1.ParameterName = "@name";
			P1.SourceColumn = "name";
			this.cmdInsCity.Parameters.Add(P1);
			P1 = this.cmdInsCity.CreateParameter();
			P1.DbType = DbType.Int32;
			P1.ParameterName = "@id_country";
			P1.SourceColumn = "id_country";
			this.cmdInsCity.Parameters.Add(P1);

			this.cmdUpdCity = this.cn.CreateCommand();
			this.cmdUpdCity.CommandText = "UPDATE Cities SET name = @name, id_country = @id_country WHERE id = @id";
			P1 = this.cmdUpdCity.CreateParameter();
			P1.DbType = DbType.String;
			P1.ParameterName = "@name";
			P1.SourceColumn = "name";
			this.cmdUpdCity.Parameters.Add(P1);
			P1 = this.cmdUpdCity.CreateParameter();
			P1.DbType = DbType.Int32;
			P1.ParameterName = "@id_country";
			P1.SourceColumn = "id_country";
			this.cmdUpdCity.Parameters.Add(P1);
			P1 = this.cmdUpdCity.CreateParameter();
			P1.DbType = DbType.Int32;
			P1.ParameterName = "@id";
			P1.SourceColumn = "id";
			this.cmdUpdCity.Parameters.Add(P1);

			DataRelation DR1 = new DataRelation("CityCountryRelation", this.DS.Tables["Countries"].Columns["id"], this.DS.Tables["Cities"].Columns["id_country"]);
			this.DS.Relations.Add(DR1);

			ForeignKeyConstraint FKC = DR1.ChildKeyConstraint;
			FKC.DeleteRule = Rule.None;
			FKC.UpdateRule = Rule.None;

			cbcol = new DataGridViewComboBoxColumn();
			cbcol.Name = "Country";
			cbcol.FlatStyle = FlatStyle.Flat;
			cbcol.DataSource = this.DS.Tables["Countries"];
			cbcol.ValueMember = "id";
			cbcol.DisplayMember = "name";
			cbcol.DataPropertyName = "id_country";

			this.DS.Tables["Countries"].TableNewRow += Form1_TableNewRow;

			this.toolStripComboBox1.SelectedIndex = 0;
		}

		private void Form1_TableNewRow(object sender, DataTableNewRowEventArgs e)
		{
			int max = Int32.Parse(this.DS.Tables["Countries"].Rows[0]["id"].ToString());
			foreach (DataRow DR in this.DS.Tables["Countries"].Rows)
			{
				if (DR.RowState != DataRowState.Deleted && Int32.Parse(DR["id"].ToString()) > max)
					max = Int32.Parse(DR["id"].ToString());
			}
			e.Row["id"] = max + 1;
		}

		private void toolStripComboBox1_TextChanged(object sender, EventArgs e)
		{
			this.dataGridView1.Columns.Clear();
			this.dataGridView1.DataSource = this.DS.Tables[this.toolStripComboBox1.SelectedItem.ToString()];
			if (this.toolStripComboBox1.SelectedItem.ToString() == "Cities")
			{
				this.dataGridView1.Columns.Add(cbcol);
				this.dataGridView1.Columns["id_country"].Visible = false;
			}
			this.dataGridView1.Columns["id"].Visible = false;
		}

		private void toolStripButton1_Click(object sender, EventArgs e)
		{

			this.DA.InsertCommand = this.cmdInsCountry;
			this.DA.UpdateCommand = this.cmdUpdCountry;
			this.DA.DeleteCommand = this.cmdDelCountry;
			this.DA.Update(this.DS, "Countries");

			this.DA.InsertCommand = this.cmdInsCity;
			this.DA.UpdateCommand = this.cmdUpdCity;
			this.DA.DeleteCommand = this.cmdDelCity;
			this.DA.Update(this.DS, "Cities");			
		}

		private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{
			MessageBox.Show(e.Exception.Message);
		}
	}
}
