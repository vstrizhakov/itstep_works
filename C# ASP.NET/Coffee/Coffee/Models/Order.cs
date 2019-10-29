using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Coffee.Models
{
	public class Order
	{
		public int Id { get; set; }
		public int CoffeeId { get; set; }

		public Coffee Coffee { get; set; }
		public ICollection<OrderAdditivePair> Additives { get; set; } = new List<OrderAdditivePair>();
	}
}