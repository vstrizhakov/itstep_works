using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ASL
{
	class HTMLParser
	{
		private String content;

		public HTMLParser(String content)
		{
			this.content = Regex.Replace(content, "<!DOCTYPE.+>", "");
			
		}

		public String Parse()
		{
			Regex regex = new Regex("<[^>]+>(.*)<[^>]+>", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline | RegexOptions.Singleline);
			MatchCollection MC = regex.Matches(this.content);
			MC = regex.Matches(MC[0].Groups[1].Value);
			String result = "";
			foreach (Match m in MC)
				result += m.Groups[0].Value + "-------------------------------------------------\r\n";
			return result;
		}
	}

	class HTMLElement
	{
		private String TagName;
		private String ClassName;
		private String Content;

	}
}
