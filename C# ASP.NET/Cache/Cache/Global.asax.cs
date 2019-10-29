using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Caching;
using System.Web.Security;
using System.Web.SessionState;

namespace Cache
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
			//Context.Cache.Add(
			//	"Greeting",
			//	"Hello, world!",
			//	null,
			//	DateTime.Now.AddMinutes(2),
			//	System.Web.Caching.Cache.NoSlidingExpiration,
			//	CacheItemPriority.Normal,
			//	OnRemovedCallback);

			Context.Cache.Add(
				"fileContent",
				File.ReadAllText(Server.MapPath("test.txt")),
				new CacheDependency(Server.MapPath("test.txt")),
				System.Web.Caching.Cache.NoAbsoluteExpiration,
				System.Web.Caching.Cache.NoSlidingExpiration,
				CacheItemPriority.Normal,
				OnRemovedCallback);

			Application["Context"] = Context;
			Application["filePath"] = Server.MapPath("test.txt");
		}

		public void OnRemovedCallback(string key, object value, CacheItemRemovedReason reason)
		{
			HttpContext context = (HttpContext)Application["Context"];
			//Context.Cache.Add(
			//	key,
			//	value + "!",
			//	null,
			//	DateTime.Now.AddMinutes(2),
			//	System.Web.Caching.Cache.NoSlidingExpiration,
			//	CacheItemPriority.Normal,
			//	OnRemovedCallback);
			string fPath = Application["filePath"] as string;
			context.Cache.Add(
				key,
				File.ReadAllText(fPath),
				new CacheDependency(fPath),
				System.Web.Caching.Cache.NoAbsoluteExpiration,
				System.Web.Caching.Cache.NoSlidingExpiration,
				CacheItemPriority.Normal,
				OnRemovedCallback);
		}
    }
}