using Newtonsoft.Json;
using Store.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.Controllers
{
	public class HomeController : BaseController
	{
		public ActionResult Index()
		{
            LoadCategories();
			return View();
		}

        public ActionResult GetFile(string name)
        {
            string path = Server.MapPath($"~/Content/Photos/{name}");
            return File(path, "image/jpeg", name);
        }

        [HttpGet]
        public ActionResult Category(int? id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null) return Redirect("/Home/Index");

            var products = _context.Products.Where(p => p.CategoryId == id || p.Category.ParentCategoryId == id);
            if (products == null)
            {
                return Redirect("/Home/Index");
            }
            else
            {
                LoadCategories(id.Value);
                ViewBag.Products = products;
                ViewBag.ProductsCount = products.Count();
                ViewBag.CategoryName = category.Name;
                return View();
            }
        }

        [HttpGet]
        public ActionResult Product(int? id)
        {
            var product = _context.Products.Include((Product p) => p.Category).FirstOrDefault(p => p.Id == id);
            if (product == null) return Redirect("/Home/Index");

            LoadCategories(id.Value);
            ViewBag.Product = product;
            return View();
        }

        [HttpPost]
        public ActionResult AddToCart(int? id, int count)
        {
            var product = _context.Products.Include((Product p) => p.Category).FirstOrDefault(p => p.Id == id);
            if (product == null) return Redirect("/Home/Index");

            if (product.Quantity < count)
            {
                return Redirect($"{Request.UrlReferrer.ToString()}?error=Не хватает товара. Пожалуйста, попробуйте уменьшить количество заказываемого товара.");
            }

            HttpCookie cookie = (Request.Cookies["products"]?.Value != null) ? cookie = Request.Cookies["products"] : new HttpCookie("products", "[]");

            List<OrderUnit> units = JsonConvert.DeserializeObject<OrderUnit[]>(cookie.Value).ToList();
            OrderUnit unitWithCurrentProduct = units.Where(ou => ou.ProductId == id).FirstOrDefault();
            if (unitWithCurrentProduct != null)
            {
                unitWithCurrentProduct.Count += count;
            }
            else
            {
                units.Add(new OrderUnit(id.Value, count));
            }
            cookie.Value = JsonConvert.SerializeObject(units);

            Response.SetCookie(cookie);

            return Redirect($"{Request.UrlReferrer.ToString()}?success=Товар успешно добавлен в корзину.");
        }

        public ActionResult Cart()
        {
            HttpCookie cookie = (Request.Cookies["products"]?.Value != null) ? cookie = Request.Cookies["products"] : new HttpCookie("products", "[]");
            List<OrderUnit> units = JsonConvert.DeserializeObject<OrderUnit[]>(cookie.Value).ToList();
            foreach (OrderUnit unit in units)
            {
                unit.Product = _context.Products.FirstOrDefault(p => p.Id == unit.ProductId);
            }
            ViewBag.OrderUnits = units;
            LoadCategories();
            return View();
        }

        public ActionResult Orders()
        {
            return View();

        }
    }
}