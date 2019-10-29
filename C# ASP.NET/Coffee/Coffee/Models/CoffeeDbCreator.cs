using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Coffee.Models
{
	public class CoffeeDbCreator : CreateDatabaseIfNotExists<CoffeeDbContext>
	{
		protected override void Seed(CoffeeDbContext context)
		{
			context.Coffees.Add(new Coffee("Кофе"));
			context.Coffees.Add(new Coffee("Капучино"));
			context.Coffees.Add(new Coffee("Латте"));
			context.Coffees.Add(new Coffee("Эспрессо"));
			context.Coffees.Add(new Coffee("Американо"));
			context.Coffees.Add(new Coffee("Маккиато"));

			context.Additives.Add(new Additive("Сахар"));
			context.Additives.Add(new Additive("Молоко"));
			context.Additives.Add(new Additive("Сливки"));
			context.Additives.Add(new Additive("Шоколад"));
			context.Additives.Add(new Additive("Карамель"));
			context.Additives.Add(new Additive("Орехи"));
			context.Additives.Add(new Additive("Корица"));
			context.Additives.Add(new Additive("Ром"));
			context.Additives.Add(new Additive("Бренди"));

			context.CoffeeAdditivePairs.Add(new CoffeeAdditivePair(1, 1));
			context.CoffeeAdditivePairs.Add(new CoffeeAdditivePair(1, 2));
			context.CoffeeAdditivePairs.Add(new CoffeeAdditivePair(1, 4));
			context.CoffeeAdditivePairs.Add(new CoffeeAdditivePair(1, 3));
			context.CoffeeAdditivePairs.Add(new CoffeeAdditivePair(2, 1));
			context.CoffeeAdditivePairs.Add(new CoffeeAdditivePair(2, 4));
			context.CoffeeAdditivePairs.Add(new CoffeeAdditivePair(2, 5));
			context.CoffeeAdditivePairs.Add(new CoffeeAdditivePair(3, 7));
			context.CoffeeAdditivePairs.Add(new CoffeeAdditivePair(3, 1));
			context.CoffeeAdditivePairs.Add(new CoffeeAdditivePair(3, 8));
			context.CoffeeAdditivePairs.Add(new CoffeeAdditivePair(4, 1));
			context.CoffeeAdditivePairs.Add(new CoffeeAdditivePair(4, 2));
			context.CoffeeAdditivePairs.Add(new CoffeeAdditivePair(4, 5));
			context.CoffeeAdditivePairs.Add(new CoffeeAdditivePair(4, 9));
			context.CoffeeAdditivePairs.Add(new CoffeeAdditivePair(5, 1));
			context.CoffeeAdditivePairs.Add(new CoffeeAdditivePair(6, 1));
			context.CoffeeAdditivePairs.Add(new CoffeeAdditivePair(6, 2));
			context.CoffeeAdditivePairs.Add(new CoffeeAdditivePair(6, 9));
			context.CoffeeAdditivePairs.Add(new CoffeeAdditivePair(6, 3));
			context.CoffeeAdditivePairs.Add(new CoffeeAdditivePair(6, 8));

			base.Seed(context);
		}
	}
}