using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Coffee.Models
{
	public class Additive
    {
        public int Id { get; set; }
        public string Name { get; set; }

		public Additive() { }

        public Additive(string name)
        {
            Name = name;
		}

		static public explicit operator SelectListItem(Additive additive)
		{
			return new SelectListItem()
			{
				Text = additive.Name,
				Value = additive.Id.ToString(),
			};
		}
	}
}
