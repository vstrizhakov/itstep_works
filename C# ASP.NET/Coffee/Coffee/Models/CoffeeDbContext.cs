using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Coffee.Models
{
	public class CoffeeDbContext : DbContext
	{
		public DbSet<Coffee> Coffees { get; set; }
		public DbSet<Additive> Additives { get; set; }
		public DbSet<OrderAdditivePair> OrderAdditivePairs { get; set; }
		public DbSet<CoffeeAdditivePair> CoffeeAdditivePairs { get; set; }
		public DbSet<Order> Orders { get; set; }
	}
}