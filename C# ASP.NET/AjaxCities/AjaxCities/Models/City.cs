using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AjaxCities.Models
{
	public class City
	{
		public int Id { get; set; }
		public string RuName { get; set; }
		public string EnName { get; set; }

		public City() { }
		public City(string ru, string en)
		{
			RuName = ru;
			EnName = en;
		}
	}
}