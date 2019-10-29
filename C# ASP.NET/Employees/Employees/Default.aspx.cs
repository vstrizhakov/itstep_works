using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;

namespace Employees
{
	public partial class Default : System.Web.UI.Page
	{
		private DbConnection dbConnection;
		private DbDataAdapter dbAdapter;
		private DataSet dataSet;

		public Default()
		{
			dbConnection = new SqlConnection("Data Source=tcp:192.168.56.1,49172;Initial Catalog=employees;Integrated Security=True");
			dbConnection.Open();
			dbAdapter = new SqlDataAdapter();
			dataSet = new DataSet();

			Unload += Default_Unload;
		}

		private void Default_Unload(object sender, EventArgs e)
		{
			dbConnection.Close();
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			DbCommand command = dbConnection.CreateCommand();
			command.CommandText = "SELECT * FROM employees";
			dbAdapter.SelectCommand = command;

			dbAdapter.Fill(dataSet, "Employees");

			foreach (DataRow row in dataSet.Tables["Employees"].Rows)
			{
				var card = new HtmlGenericControl("div class=\"card my-4\"");

				var cardHeader = new HtmlGenericControl("div class=\"card-header\"");
				card.Controls.Add(cardHeader);

				var cardTitle = new HtmlGenericControl("h4 class=\"card-title mb-0\"")
				{
					InnerText = String.Format("{0} {1}", row["first_name"], row["last_name"])
				};
				cardHeader.Controls.Add(cardTitle);

				var cardBody = new HtmlGenericControl("div class=\"card-body\"");
				card.Controls.Add(cardBody);

				var cardBodyRow = new HtmlGenericControl("div class=\"row\"");
				cardBody.Controls.Add(cardBodyRow);

				var leftCol = new HtmlGenericControl("div class=\"col col-lg-9\"");
				cardBodyRow.Controls.Add(leftCol);

				var ageParagraph = new HtmlGenericControl("p")
				{
					InnerText = String.Format("Возраст: {0}", row["age"])
				};
				var sexParagraph = new HtmlGenericControl("p")
				{
					InnerText = String.Format("Пол: {0}", (Int32.Parse(row["sex"].ToString()) == 0) ? "Мужчина" : "Женщина")
				};
				var postParagraph = new HtmlGenericControl("p")
				{
					InnerText = String.Format("Должность: {0}", row["post"])
				};
				leftCol.Controls.Add(ageParagraph);
				leftCol.Controls.Add(sexParagraph);
				leftCol.Controls.Add(postParagraph);

				var rightCol = new HtmlGenericControl("div class=\"col col-lg-3\"");
				cardBodyRow.Controls.Add(rightCol);

				var editButton = new HtmlButton()
				{
					InnerText = "Редактировать"
				};
				editButton.Attributes["class"] = "btn btn-success btn-block";
				editButton.ServerClick += EditButton_ServerClick;
				editButton.Attributes["data-id"] = row["id"].ToString();
				rightCol.Controls.Add(editButton);

				var deleteButton = new HtmlButton()
				{
					InnerText = "Удалить"
				};
				deleteButton.Attributes["class"] = "btn btn-danger btn-block";
				deleteButton.ServerClick += DeleteButton_ServerClick;
				deleteButton.Attributes["data-id"] = row["id"].ToString();
				rightCol.Controls.Add(deleteButton);

				content.Controls.Add(card);
			}
		}

		private void EditButton_ServerClick(object sender, EventArgs e)
		{
			Response.Redirect(String.Format("EmployeeForm.aspx?id={0}", (sender as HtmlButton).Attributes["data-id"]));
		}

		private void DeleteButton_ServerClick(object sender, EventArgs e)
		{
			DbCommand command = dbConnection.CreateCommand();
			command.CommandText = String.Format("DELETE FROM employees WHERE id = {0}", (sender as HtmlButton).Attributes["data-id"]);
			command.ExecuteNonQuery();
			Response.Redirect("Default.aspx");
		}

		protected void Unnamed1_Click(object sender, EventArgs e)
		{
			Response.Redirect("EmployeeForm.aspx");
		}
	}
}