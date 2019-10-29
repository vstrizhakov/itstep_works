using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sessions
{
	public partial class Default : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			
		}

		protected void Button1_Click(object sender, EventArgs e)
		{
			if (TextBox1.Text != String.Empty && TextBox2.Text != String.Empty)
			{
				Session["lastname"] = TextBox1.Text;
				Session["firstname"] = TextBox2.Text;
				Response.Redirect("PhoneEmail.aspx");
			}
			Response.Write("Введены не все данные!");
		}
	}
}