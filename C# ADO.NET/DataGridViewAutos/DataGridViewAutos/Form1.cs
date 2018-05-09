using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataGridViewAutos
{
	public partial class Autos : Form
	{
		static private DbConnection cn = new SqlConnection("Data Source=DESKTOP-UABFEJE;Initial Catalog=master;Integrated Security=True");
		static private DbCommand cmd = cn.CreateCommand();
		private List<int> DeletedRowsId = new List<int>();
		public Autos()
		{
			InitializeComponent();
			this.FormClosing += Autos_FormClosing;
			try
			{
				cn.Open();
				DataTable DT = new DataTable();
				cmd.CommandText = "SELECT * FROM Autos";
				DT.Load(cmd.ExecuteReader());
				this.dataGridView1.DataSource = DT;
				cn.Close();
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
				this.Close();
			}
		}

		private void Autos_FormClosing(object sender, FormClosingEventArgs e)
		{
			DataTable DT = ((DataTable)(this.dataGridView1.DataSource)).GetChanges();
			if (DT != null && MessageBox.Show("Сохранить изменения в БД?", "Выход", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				this.button1_Click(null, null);
			}
		}

		private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
		{
			this.DeletedRowsId.Add((int)((DataTable)this.dataGridView1.DataSource).Rows[e.Row.Index][0]);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			DataTable DT = ((DataTable)(this.dataGridView1.DataSource)).GetChanges();
			if (DT != null && DT.Rows.Count > 0)
			{
				cn.Open();
				foreach (DataRow DR in DT.Rows)
				{
					if (DR.RowState == DataRowState.Modified)
					{
						try
						{
							cmd.CommandText = String.Format("UPDATE Autos SET marka = '{0}', model = '{1}', year = {2}, color = '{3}' WHERE id = {4}", DR[1], DR[2], DR[3], DR[4], DR[0]);
							cmd.ExecuteNonQuery();
						}
						catch (Exception a)
						{
							MessageBox.Show(a.Message);
						}
					}
					else if (DR.RowState == DataRowState.Added)
					{
						try
						{
							cmd.CommandText = String.Format("INSERT INTO Autos (marka, model, year, color) VALUES ('{0}', '{1}', {2}, '{3}')", DR[1], DR[2], DR[3], DR[4]);
							cmd.ExecuteNonQuery();
						}
						catch (Exception a)
						{
							MessageBox.Show(a.Message);
						}
					}
				}
				foreach (int id in this.DeletedRowsId)
				{
					try
					{
						cmd.CommandText = String.Format("DELETE FROM Autos WHERE id = {0}", id);
						cmd.ExecuteNonQuery();
					}
					catch (Exception a)
					{
						MessageBox.Show(a.Message);
					}
				}
				this.DeletedRowsId.Clear();
				cn.Close();
				((DataTable)(this.dataGridView1.DataSource)).AcceptChanges();
			}
			MessageBox.Show("Изменения успешно сохранены");
		}
	}
}
