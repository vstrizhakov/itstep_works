using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace AppVariables
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
			Application["userCount"] = 0;
        }

		protected void Session_Start(object sender, EventArgs e)
		{
			int count = (int)Application["userCount"];
			count++;
			Application["userCount"] = count;
		}

		protected void Session_End(object sender, EventArgs e)
		{
			int count = (int)Application["userCount"];
			count--;
			Application["userCount"] = count;
		}
    }
}