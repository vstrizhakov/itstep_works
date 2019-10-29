using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace JaxaHelper.Models
{
	public class BookContext : DbContext
	{
		public DbSet<SrcBook> Books { get; set; }
	}
}