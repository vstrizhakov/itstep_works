using Library.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library
{
    public partial class _Default : Page
    {
		private DbConnection _connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source='D:\Works\C# ASP.NET\Library\Library\App_Data\Library.mdb';Persist Security Info=True");

        protected void Page_Load(object sender, EventArgs e)
        {
			DbCommand command = _connection.CreateCommand();
			command.CommandText = "SELECT * FROM Books";
			DbDataAdapter adapter = new OleDbDataAdapter((OleDbCommand)command);
			DataSet set = new DataSet();
			adapter.Fill(set, "Books");
			GridView1.DataSource = set.Tables["Books"];
			GridView1.DataKeyNames = new string[] { "Name" };
			GridView1.DataBind();
		}
	}
}