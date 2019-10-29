using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Second
{
	public partial class Default : System.Web.UI.Page
	{
		private static string[] months = new string[]
		{
			"Январь", "Ферваль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь"
		};

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!this.IsPostBack)
			{
				DropDownList1.DataSource = months;
				DropDownList1.DataBind();
			}
			else
			{
				labelInfo.Text = DropDownList1.SelectedValue;
			}
		}
	}
}