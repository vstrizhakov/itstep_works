using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConnectionToDB
{
	public partial class Form1 : Form
	{
		static DbConnection cn = new SqlConnection();
		public Form1()
		{
			InitializeComponent();
			cn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\vPC\Desktop\Database11.accdb";
			DbCommand cmd = cn.CreateCommand();
			cmd.CommandText = "INSERT INTO products (name, price, weight) VALUES('Snickers', 12.5, 45)";
			try
			{
				cn.Open();
				int rows = cmd.ExecuteNonQuery();
				this.textBox1.Text = "Обновлено строк: " + rows + "\r\n";
				cn.Close();
			}
			catch (Exception e)
			{
				this.textBox1.Text = "Ошибка: " + e.Message + "\r\n";
			}

			cmd.CommandText = "SELECT * FROM products";

			try
			{
				cn.Open();
				DbDataReader R = cmd.ExecuteReader();
				while (R.Read())
				{
					int id = R.GetInt32(0);
					string name = (R.IsDBNull(1)) ? "" : R.GetString(1);
					double price = (R.IsDBNull(2)) ? 0 : R.GetInt32(2);
					int weight = (R.IsDBNull(3)) ?  0 : R.GetInt32(3);

					this.textBox1.Text += String.Format("Добавлена строка: {0}, {1}, {2}, {3}\r\n", id, name, price, weight);
				}
			}
			catch (Exception e)
			{
				this.textBox1.Text = "Ошибка: " + e.Message + "\r\n";
			}
		}
	}
}
