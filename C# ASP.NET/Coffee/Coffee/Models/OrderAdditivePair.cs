using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Coffee.Models
{
	public class OrderAdditivePair
	{
		public int Id { get; set; }
		public int OrderId { get; set; }
		public int AdditiveId { get; set; }

		public Additive Additive { get; set; }
	}
}