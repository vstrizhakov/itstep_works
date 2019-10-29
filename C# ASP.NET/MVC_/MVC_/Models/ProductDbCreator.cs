using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_.Models
{
	public class ProductDbCreator : DropCreateDatabaseAlways<ProductContext>
	{
		protected override void Seed(ProductContext context)
		{
			context.Categories.Add(new Category { Id = 1, Name = "Хлебобулочные" });
			context.Categories.Add(new Category { Id = 2, Name = "Кондитерские" });
			context.Categories.Add(new Category { Id = 3, Name = "Напитки" });

			context.Products.Add(new Product
			{
				Id = 1,
				Name = "Snickers",
				Price = 13.5,
				Weight = 45,
				CategoryId = 2
			});

			base.Seed(context);
		}
	}
}