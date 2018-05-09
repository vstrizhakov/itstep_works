using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statics
{
	class WebRobot
	{
		private static String lang = "en";
		private String name;

		public String Greeting()
		{
			switch (WebRobot.lang)
			{
				case "en":
					{
						return String.Format("Language: {0}", WebRobot.lang);
					}
				case "ru":
					{
						return String.Format("Язык: {0}", WebRobot.lang);
					}
				default:
					return String.Format("???");
			}
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
		}
	}
}
