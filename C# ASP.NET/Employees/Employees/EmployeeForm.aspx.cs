using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Employees
{
	public partial class EmployeeForm : System.Web.UI.Page
	{
		private DbConnection dbConnection;
		private DbDataAdapter dbAdapter;
		private DataSet dataSet;

		public EmployeeForm()
		{
			dbConnection = new SqlConnection("Data Source=tcp:192.168.56.1,49172;Initial Catalog=employees;Integrated Security=True");
			dbConnection.Open();
			dbAdapter = new SqlDataAdapter();
			dataSet = new DataSet();

			Unload += EmployeeForm_Unload;
		}

		private void EmployeeForm_Unload(object sender, EventArgs e)
		{
			dbConnection.Close();
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if (Request.QueryString["id"] != null)
			{
				btn.Text = "Редактировать";
				var hiddenId = new HtmlInputHidden();
				panel.Controls.Add(hiddenId);
				hiddenId.ID = "id";
				hiddenId.Value = Request.QueryString["id"];

				DbCommand command = dbConnection.CreateCommand();
				command.CommandText = String.Format("SELECT first_name, last_name, age, sex, post FROM employees WHERE id = '{0}'", Request.QueryString["id"]);
				DbDataReader dataReader = command.ExecuteReader();
				if (dataReader.RecordsAffected == 0)
				{
					Response.Redirect("Default.aspx");
					return;
				}
				dataReader.Read();
				string firstName = dataReader.GetString(0);
				string lastName = dataReader.GetString(1);
				int age = dataReader.GetInt32(2);
				int sex = dataReader.GetInt32(3);
				string post = dataReader.GetString(4);
				dataReader.Close();

				this.firstName.Text = firstName;
				this.lastName.Text = lastName;
				this.age.Text = age.ToString();
				this.post.Text = post;
				if (sex == 1)
				{
					this.female.Checked = true;
				}
			}
			if (IsPostBack)
			{
				string firstName = Request.Form["firstName"].Trim();
				string lastName = Request.Form["lastName"].Trim();
				string age = Request.Form["age"].Trim();
				string post = Request.Form["post"].Trim();
				string sex = Request.Form["sex"].Trim();
				
				if (firstName == String.Empty ||
					lastName == String.Empty ||
					age == String.Empty ||
					post == String.Empty ||
					(sex != "male" && sex != "female"))
				{
					error.Text = "Заполните все поля!";
					return;
				}

				if (!Int32.TryParse(age, out int a))
				{
					error.Text = "Значение поля \"Возраст\" должно быть числом!";
					return;
				}

				DbCommand command = dbConnection.CreateCommand();
				if (Request.Form["id"] == null)
				{
					command.CommandText = String.Format("INSERT INTO employees (first_name, last_name, age, sex, post) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')", firstName, lastName, age, (sex == "male") ? 0 : 1, post);
				}
				else
				{
					string id = Request.Form["id"];
					command.CommandText = String.Format("UPDATE employees SET first_name = '{0}', last_name = '{1}', age = '{2}', sex = '{3}', post = '{4}' WHERE id = '{5}'", firstName, lastName, age, (sex == "male") ? 0 : 1, post, id);
				}
				command.ExecuteNonQuery();
				Response.Redirect("Default.aspx");
			}
		}
	}
}