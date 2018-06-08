using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlParser
{
	public class HtmlObject
	{
		public String Tag { get; set; } = "";
		public Dictionary<String, String> Attributes { get; set; } = new Dictionary<string, string>();
		public String OuterHTML { get; set; } = "";
		public String InnerHTML { get; set; } = "";
		public List<HtmlObject> ChildTags { set; get; } = new List<HtmlObject>();
		public bool IsSelfClosing { get; set; } = false;

		public HtmlObject(String tag)
		{
			this.Tag = tag;
		}

		public void Print(int i = 0)
		{
			for (int j = 0; j < i; j++)
				Console.Write('\t');
			Console.Write("<" + this.Tag);
			foreach (KeyValuePair<String, String> attr in this.Attributes)
			{
				Console.Write(" " + attr.Key + "=\"" + attr.Value + "\"");
			}
			Console.WriteLine(">");
			foreach (HtmlObject o in this.ChildTags)
				o.Print(i + 1);
			if (this.IsSelfClosing == false)
			{
				for (int j = 0; j < i; j++)
					Console.Write('\t');
				Console.WriteLine("</" + this.Tag + ">");
			}
		}

		public List<HtmlObject> FindByTagName(String tag)
		{
			List<HtmlObject> result = new List<HtmlObject>();
			foreach (HtmlObject obj in this.ChildTags)
				result = result.Concat(obj.FindByTagName(tag)).ToList();
			if (this.Tag == tag)
				result.Add(this);
			return result;

		}

		public List<HtmlObject> FindByClassName(String cls)
		{
			List<HtmlObject> result = new List<HtmlObject>();
			foreach (HtmlObject obj in this.ChildTags)
				result = result.Concat(obj.FindByClassName(cls)).ToList();
			if (this.Attributes.ContainsKey("class") && this.Attributes["class"].Contains(cls))
				result.Add(this);
			return result;
		}

		public List<HtmlObject> FindById(String id)
		{
			List<HtmlObject> result = new List<HtmlObject>();
			foreach (HtmlObject obj in this.ChildTags)
				result = result.Concat(obj.FindById(id)).ToList();
			if (this.Attributes.ContainsKey("id") && this.Attributes["id"].Contains(id))
				result.Add(this);
			return result;
		}

		public List<HtmlObject> FindByAttributes(Dictionary<String, String> rules)
		{
			List<HtmlObject> result = new List<HtmlObject>();
			foreach (HtmlObject obj in this.ChildTags)
				result = result.Concat(obj.FindByAttributes(rules)).ToList();
			bool i = true;
			foreach (KeyValuePair<String, String> rule in rules)
				if (!this.Attributes.ContainsKey(rule.Key) || !this.Attributes[rule.Key].Contains(rule.Value))
					i = false;
			if (i)
				result.Add(this);
			return result;
		}

		public List<HtmlObject> FindByAttributesStrictly(Dictionary<String, String> rules)
		{
			List<HtmlObject> result = new List<HtmlObject>();
			foreach (HtmlObject obj in this.ChildTags)
				result = result.Concat(obj.FindByAttributesStrictly(rules)).ToList();
			bool i = true;
			foreach (KeyValuePair<String, String> rule in rules)
				if (!this.Attributes.ContainsKey(rule.Key) || !this.Attributes[rule.Key].Equals(rule.Value))
					i = false;
			if (i)
				result.Add(this);
			return result;
		}
	}
}
