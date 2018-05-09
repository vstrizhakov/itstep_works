using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ConsoleApp3
{
	class Program
	{
		static void Main(string[] args)
		{
			using (var ctx = new sp2822Entities())
			{
				var myProducts = from t in ctx.product_09358 select t;

				foreach (var product in myProducts)
					Console.WriteLine("Name: {0}, Weight: {1}, Price: {2}", product.prodname, product.prodweight, product.price);

				product_09358 T = new product_09358()
				{
					price = 455,
					prodname = "Snicke687876rs",
					prodweight = 129
				};

				ctx.product_09358.Add(T);
				ctx.SaveChanges();
			}
		}
	}

}
