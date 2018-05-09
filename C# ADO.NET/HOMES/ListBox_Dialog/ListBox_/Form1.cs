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

namespace ListBox_
{
	public partial class Form1 : Form
	{
		private ListViewItem EditItem;
		private static DbConnection cn = new SqlConnection();
		private static DbCommand cmd = cn.CreateCommand();
		public Form1()
		{
			InitializeComponent();
			this.Closing += Form1_Closing;
			this.listView1.View = View.Details;
			this.listView1.FullRowSelect = true;
			this.listView1.Columns.Add("Название");
			this.listView1.Columns[0].Width = 120;
			this.listView1.Columns.Add("Цена");
			this.listView1.Columns.Add("Вес");
			cn.ConnectionString = @"Data Source=DESKTOP-UABFEJE;Initial Catalog=master;Integrated Security=True";
			cn.Open();
			this.GetAllProducts();
		}

		private void GetAllProducts()
		{
			this.listView1.Items.Clear();
			cmd.CommandText = "SELECT * FROM products";
			try
			{
				DbDataReader DR = cmd.ExecuteReader();
				while (DR.Read())
				{
					int id = (DR.IsDBNull(0)) ? 0 : DR.GetInt32(0);
					string name = (DR.IsDBNull(1)) ? "" : DR.GetString(1);
					decimal price = (DR.IsDBNull(2)) ? 0 : DR.GetDecimal(2);
					int weight = (DR.IsDBNull(3)) ? 0 : DR.GetInt32(3);

					ListViewItem LVI = new ListViewItem();
					LVI.Text = name;
					LVI.SubItems.Add(price.ToString());
					LVI.SubItems.Add(weight.ToString());
					LVI.SubItems.Add(id.ToString());
					this.listView1.Items.Add(LVI);
					this.EditItem = null;
					this.button2.Enabled = false;
					this.button3.Enabled = false;
				}
				DR.Close();
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}

		private void Form1_Closing(object sender, CancelEventArgs e)
		{
			cn.Close();
		}

		private void button1_Click(object sender, EventArgs e)
		{			
			ProductForm PF = new ProductForm();
			if (PF.ShowDialog() == DialogResult.OK)
			{
				try
				{
					cmd.CommandText = @"INSERT INTO products (name, weight, price) VALUES ('" + PF.name.Text + "'," + PF.weight.Text + "," + PF.price.Text.Replace(",", ".") + ")";
					cmd.ExecuteNonQuery();
					this.GetAllProducts();
				}
				catch (Exception a)
				{
					MessageBox.Show(a.Message);
				}				
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.EditItem = this.listView1.SelectedItems[0];
			ProductForm PF = new ProductForm();
			PF.name.Text = this.EditItem.SubItems[0].Text;
			PF.price.Text = this.EditItem.SubItems[1].Text;
			PF.weight.Text = this.EditItem.SubItems[2].Text;
			if (PF.ShowDialog() == DialogResult.OK)
			{
				try
				{
					cmd.CommandText = @"UPDATE products SET name = '" + PF.name.Text + "', price = " + PF.price.Text.Replace(",", ".") + ", weight = " + PF.weight.Text + " WHERE id = " + this.EditItem.SubItems[3].Text;
					cmd.ExecuteNonQuery();
					this.GetAllProducts();
				}
				catch (Exception a)
				{
					MessageBox.Show(a.Message);
				}
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			this.EditItem = this.listView1.SelectedItems[0];
			if (MessageBox.Show("Вы уверены, что хотите удалить запись?", "Вы уверены?", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				try
				{
					cmd.CommandText = @"DELETE FROM products WHERE id = " + this.EditItem.SubItems[3].Text;
					cmd.ExecuteNonQuery();
					this.GetAllProducts();
				}
				catch (Exception a)
				{
					MessageBox.Show(a.Message);
				}
			}
		}

		private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.listView1.SelectedItems.Count != 0)
			{
				this.button2.Enabled = true;
				this.button3.Enabled = true;
			}
		}
	}
}
