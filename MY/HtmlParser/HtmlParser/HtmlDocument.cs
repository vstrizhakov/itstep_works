using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlParser
{
	public class HtmlDocument
	{
		public List<HtmlObject> RootTags { get; set; }

		static private List<String> SelfClosingTags = new List<String>()
		{
			"!doctype", "area", "base", "br", "col", "embed", "hr", "img", "input", "link", "meta", "param", "source", "track", "wbr"
		};

		static public HtmlObject Parse(String html)
		{
			HtmlObject obj = new HtmlObject("root");

			String tmpTag = "";
			String tmpOuterHTML = "";
			String tmpInnerHTML = "";
			String tmpAttrName = "";
			String tmpAttrValue = "";
			String cTags = "";
			String tmpChildTag = "";

			char prevSpecialChar = ' ';
			char prevChar = ' ';
			bool isWritingTag = false;
			bool isWritingChildTag = false;
			bool isWritingAttributes = false;
			bool isWritingAttributeName = false;
			bool isWritingAttributeValue = false;
			bool isWritingInnerHTML = false;
			bool isComment = false;

			int charsToEndComment = -1;

			List<List<int>> childTags = new List<List<int>>();

			int i = 0;

			foreach (char c in html)
			{
				if (isComment)
				{
					if (charsToEndComment > -1)
					{
						if (charsToEndComment-- == 0)
							isComment = false;
					}
					else if (c == '-' && i + 2 < html.Length && html[i + 1] == '-' && html[i + 2] == '>')
						charsToEndComment = 2;
					tmpOuterHTML += c;
					prevChar = c;
					i++;
					continue;
				}
				else if (c == '<' && i + 1 < html.Length && html[i + 1] != '/' && html[i + 1] != ' ')
				{
					if (i + 3 < html.Length && html[i + 1] == '!' && html[i + 2] == '-' && html[i + 3] == '-')
					{
						isComment = true;
						i++;
						continue;
					}
					if (tmpTag != String.Empty)
					{
						if (tmpChildTag != "script")
						{
							if (cTags == "")
							{
								childTags.Add(new List<int>());
								childTags[childTags.Count - 1].Add(i);
							}
							isWritingChildTag = true;
							tmpChildTag = "";
							cTags += "<";
						}
					}
					else
						isWritingTag = true;
				}
				else if (c == '>')
				{
					if (isWritingTag)
					{
						obj.Tag = tmpTag;
						isWritingTag = false;
						isWritingInnerHTML = true;
						if (HtmlDocument.SelfClosingTags.Contains(tmpTag.ToLower()))
							obj.IsSelfClosing = true;
						if (isWritingAttributeName)
						{
							if (!obj.Attributes.ContainsKey(tmpAttrName))
								obj.Attributes.Add(tmpAttrName, "");
							else obj.Attributes[tmpAttrName] = "";
						}
						if (tmpTag == "script")
						{
							obj.OuterHTML = html;
							return obj;
						}
					}
				}
				else if (isWritingTag)
				{
					if (isWritingAttributes)
					{
						if (isWritingAttributeName)
						{
							if (c == ' ' && tmpAttrName == String.Empty) { }
							else if ((c == ' ' || c == '=') && tmpAttrName != String.Empty)
							{
								isWritingAttributeName = false;
								isWritingAttributeValue = true;
								prevSpecialChar = ' ';
							}
							else
								tmpAttrName += c;
						}
						else if (isWritingAttributeValue)
						{
							if (c != ' ' && c != '"' && prevChar == '=' && prevSpecialChar == ' ')
							{
								tmpAttrValue = String.Empty;
								prevSpecialChar = '=';
							}
							if (c != '"' && c != ' ' && c != '=' && prevSpecialChar == ' ')
							{
								if (!obj.Attributes.ContainsKey(tmpAttrName))
									obj.Attributes.Add(tmpAttrName, "");
								else obj.Attributes[tmpAttrName] = "";
								isWritingAttributeValue = false;
								tmpAttrName = c.ToString();
								isWritingAttributeName = true;
							}
							else if (prevSpecialChar == ' ' && c == '"')
							{
								tmpAttrValue = String.Empty;
								prevSpecialChar = '"';
							}
							else if ((prevSpecialChar == '"' && c == '"') || (prevSpecialChar == '=' && c == ' '))
							{
								if (!obj.Attributes.ContainsKey(tmpAttrName))
									obj.Attributes.Add(tmpAttrName, tmpAttrValue);
								else
									obj.Attributes[tmpAttrName] = tmpAttrValue;
								isWritingAttributeValue = false;
								if (prevSpecialChar == '=')
								{
									isWritingAttributeName = true;
									tmpAttrName = String.Empty;
								}
							}
							else
								tmpAttrValue += c;
						}
						else if (c == ' ')
						{
							isWritingAttributeName = true;
							tmpAttrName = String.Empty;
						}
					}
					else
					{
						if (c == ' ')
						{
							if (tmpTag != String.Empty)
							{
								isWritingAttributes = true;
								tmpAttrName = String.Empty;
								isWritingAttributeName = true;
							}
						}
						else
							tmpTag += c;
					}
				}
				else if (c == '/' && prevChar == '<' && cTags != "")
				{
					if (cTags == "<")
						childTags[childTags.Count - 1].Add(i);
					cTags = cTags.Remove(0, 1);
					tmpChildTag = String.Empty;
				}
				if (c == '/' && prevChar == '<' && cTags == "")
					isWritingInnerHTML = false;
				if (isWritingChildTag && c != '<')
				{
					if (tmpChildTag != String.Empty && (c == ' ' || c == '>'))
					{
						isWritingChildTag = false;
						if (HtmlDocument.SelfClosingTags.Contains(tmpChildTag.ToLower()))
						{
							if (cTags != "")
							{
								if (cTags == "<")
								{
									childTags[childTags.Count - 1].Add(i);
								}
								cTags = cTags.Remove(0, 1);
							}
						}
						if (tmpChildTag.Trim() == "script")
						{
							charsToEndComment = html.IndexOf("</script>", i) - i - 1;
							isComment = true;
						}
					}
					else
						tmpChildTag += c;
				}
				if (cTags != "" && i == html.Length - 1)
				{
					int l = cTags.Length;
					for (int j = 0; j < l; j++)
						html += "</>";
					childTags[childTags.Count - 1].Add(i + (3 * (l - 1)) + 2);

				}
				if (isWritingInnerHTML && c != '<' && c != '>')
					tmpInnerHTML += c;
				tmpOuterHTML += c;
				prevChar = c;
				i++;
			}
			foreach (List<int> list in childTags)
				obj.ChildTags.Add(HtmlDocument.Parse(html.Substring(list[0], html.IndexOf('>', list[1]) - list[0] + 1)));
			obj.InnerHTML = tmpInnerHTML;
			obj.OuterHTML = tmpOuterHTML;
			return obj;
		}

		public HtmlDocument(String html)
		{
			this.RootTags = HtmlDocument.Parse("<document>" + html + "</document>").ChildTags;
		}

		public void PrintDocument()
		{
			foreach (HtmlObject obj in this.RootTags)
				obj.Print();
		}

		public List<HtmlObject> FindByTagName(String name)
		{
			List<HtmlObject> result = new List<HtmlObject>();
			foreach (HtmlObject obj in this.RootTags)
				result = result.Concat(obj.FindByTagName(name)).ToList();
			return result;
		}

		public List<HtmlObject> FindByClassName(String cls)
		{
			List<HtmlObject> result = new List<HtmlObject>();
			foreach (HtmlObject obj in this.RootTags)
				result = result.Concat(obj.FindByClassName(cls)).ToList();
			return result;
		}

		public List<HtmlObject> FindById(String id)
		{
			List<HtmlObject> result = new List<HtmlObject>();
			foreach (HtmlObject obj in this.RootTags)
				result = result.Concat(obj.FindById(id)).ToList();
			return result;
		}

		public List<HtmlObject> FindByAttributes(Dictionary<String, String> rules)
		{
			List<HtmlObject> result = new List<HtmlObject>();
			foreach (HtmlObject obj in this.RootTags)
				result = result.Concat(obj.FindByAttributes(rules)).ToList();
			return result;
		}

		public List<HtmlObject> FindByAttributesStrictly(Dictionary<String, String> rules)
		{
			List<HtmlObject> result = new List<HtmlObject>();
			foreach (HtmlObject obj in this.RootTags)
				result = result.Concat(obj.FindByAttributesStrictly(rules)).ToList();
			return result;
		}
	}
}
