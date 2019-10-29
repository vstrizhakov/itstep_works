using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_.Models
{
	public class Product
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public double Price { get; set; }
		public int Weight { get; set; }
		public int CategoryId { get; set; }
	}
}