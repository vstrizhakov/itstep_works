using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HttpCookie_
{
	public partial class Default : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (IsPostBack)
			{
				HttpCookie cookie = new HttpCookie(TextBox1.Text, TextBox2.Text);
				cookie.Expires = DateTime.Now.AddMinutes(3);
				Response.Cookies.Add(cookie);
			}
			string[] allKeys = Request.Cookies.AllKeys;
			StringBuilder stringBuilder = new StringBuilder();
			foreach (string key in allKeys)
			{
				stringBuilder.Append($"{key} - {Request.Cookies[key].Value}<br>");
			}
			info.Text = stringBuilder.ToString();
		}
	}
}