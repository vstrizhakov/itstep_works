using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sessions
{
	public partial class PhoneEmail : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void Button1_Click(object sender, EventArgs e)
		{
			if (TextBox1.Text != String.Empty && TextBox2.Text != String.Empty)
			{
				Session["phone"] = TextBox1.Text;
				Session["email"] = TextBox2.Text;
				Response.Redirect("SkypeICQ.aspx");
			}
			Response.Write("Введены не все данные!");
		}
	}
}