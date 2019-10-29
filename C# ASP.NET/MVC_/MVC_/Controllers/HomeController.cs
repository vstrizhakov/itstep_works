using MVC_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_.Controllers
{
	public class HomeController : Controller
	{
		private ProductContext dataBase = new ProductContext();

		public ActionResult Index()
		{
			IEnumerable<Category> categories = dataBase.Categories;
			ViewBag.Categories = categories;

			IEnumerable<Product> products = dataBase.Products;
			ViewBag.Products = products;
			return View();
		}

        public ActionResult AddForm()
        {
            IEnumerable<Category> categories = dataBase.Categories;
            ViewBag.Categories = categories;

            return View();
        }

        [HttpPost]
        public ActionResult AddForm(Product product)
        {
            dataBase.Products.Add(product);
            dataBase.SaveChanges();
            return Redirect("/Home/Index");
        }

		[HttpGet]
		public ActionResult Info(int id)
		{
			ViewBag.ProductId = id;
			return View();
		}

		[HttpGet]
		public ActionResult Remove(int id)
		{
			// Найти продукт с ID = id и записать его в P -> LINQ поиск продукта
			//Product product = dataBase.Products.Where(p => p.Id == id).FirstOrDefault();

			Product product = (from p in dataBase.Products
							  where p.Id == id
							  select p).FirstOrDefault();

			dataBase.Products.Remove(product);
			dataBase.SaveChanges();

			return Redirect("/Home/Index");
		}
	}
}