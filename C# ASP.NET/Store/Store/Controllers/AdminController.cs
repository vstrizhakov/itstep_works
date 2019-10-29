using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.Controllers
{
    public class AdminController : BaseController
    {
		public AdminController() : base()
		{
			_loadCategories = false;
			_baseRoute = "/Admin/Index";
		}

		public ActionResult Index()
        {
            return RedirectToAction("Orders");
        }

		public ActionResult Orders()
		{
			ViewBag.Orders = _context.Orders;
			return View();
		}

		public ActionResult Products()
		{
			ViewBag.Product = _context.Products;
			return View();
		}

		public ActionResult Categories()
		{
			ViewBag.Categories = _context.Categories;
			return View();
		}

		#region Products

		public ActionResult AddProduct()
		{
			return View();
		}

		[HttpPost]
		public ActionResult AddProduct(Product product)
		{
			_context.Products.Add(product);
			_context.SaveChanges();
			return Redirect("/Admin/Products");
		}

		public ActionResult EditProduct(int? id)
		{
			Product temp = _context.Products.FirstOrDefault(p => p.Id == id);
			if (temp == null) return Redirect("/Admin/AddProduct");
			ViewBag.Product = temp;
			return View();
		}

		[HttpPost]
		public ActionResult EditProduct(Product product)
		{
			Product temp = _context.Products.FirstOrDefault(p => p.Id == product.Id);
			if (temp != null)
			{
				temp.Name = product.Name;
				temp.PhotoPath = product.PhotoPath;
				temp.Price = product.Price;
				temp.Weight = product.Weight;
				temp.CategoryId = product.CategoryId;
				temp.Description = product.Description;
				temp.Quantity = product.Quantity;
				_context.SaveChanges();
			}
			return Redirect("/Admin/Products");
		}

		public ActionResult RemoveProduct(int? id)
		{
			Product temp = _context.Products.FirstOrDefault(p => p.Id == id);
			_context.Products.Remove(temp);
			_context.SaveChanges();
			return Redirect("/Admin/Products");
		}

		#endregion

		#region Categories

		public ActionResult AddCategory()
		{
			return View();
		}

		[HttpPost]
		public ActionResult AddCategory(Product product)
		{
			return Redirect("/Admin/Categories");
		}

		public ActionResult EditCategory(int? id)
		{
			return View();
		}

		public ActionResult RemoveCategory(int? id)
		{
			return Redirect("/Admin/Categories");
		}

		#endregion
	}
}