using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace First
{
	public partial class _default : Page
	{
		public _default()
		{
			PreRender += _default_PreRender;
		}

		private void _default_PreRender(object sender, EventArgs e)
		{
			Response.Clear();
			Response.ContentType = "image/jpeg";
			Response.WriteFile("Koala.jpg");
			Response.End();
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			Response.Write("Page_Load");
		}

		protected void Button1_Click(object sender, EventArgs e)
		{
			Response.Write("Button_Click");
		}
	}
}