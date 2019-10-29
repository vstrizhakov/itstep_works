using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Coffee.Models
{
	public class Coffee
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public Coffee() { }

		public Coffee(string name)
		{
			Name = name;
		}

		static public explicit operator SelectListItem(Coffee coffee)
		{
			return new SelectListItem()
			{
				Text = coffee.Name,
				Value = coffee.Id.ToString(),
			};
		}
	}
}
