using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sessions
{
	public partial class Result : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (var session in Session)
			{
				stringBuilder.Append($"{Session[session.ToString()]}<br>");
			}
			res.Text = stringBuilder.ToString();
		}
	}
}