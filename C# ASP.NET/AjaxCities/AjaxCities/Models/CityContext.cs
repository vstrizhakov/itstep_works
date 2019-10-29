using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AjaxCities.Models
{
	public class CityContext : DbContext
	{
		public DbSet<City> Cities { get; set; }
	}
}