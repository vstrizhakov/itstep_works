using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Coffee.Models
{
	public class CoffeeAdditivePair
	{
		public int Id { get; set; }
		public int CoffeeId { get; set; }
		public int AdditiveId { get; set; }

		public Additive Additive { get; set; }

		public CoffeeAdditivePair() { }

		public CoffeeAdditivePair(int coffeeId, int additiveId)
		{
			CoffeeId = coffeeId;
			AdditiveId = additiveId;
		}
	}
}