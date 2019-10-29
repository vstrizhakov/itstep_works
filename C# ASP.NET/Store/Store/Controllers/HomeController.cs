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
		public HomeController() : base()
		{
			_baseRoute = "/Home/Index";
		}

		public ActionResult Index()
		{
            ViewBag.Products = _context.Products;
            ViewBag.ProductsCount = _context.Products.Count();
            ViewBag.CategoryName = "Все товары";
			return View("Category");
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
            if (category == null) return RedirectToReferrer();

            var products = _context.Products.Where(p => p.CategoryId == id || p.Category.ParentCategoryId == id);
            if (products == null)
            {
                return Redirect("/Home/Index");
            }
            else
            {
                ViewBag.Products = products;
                ViewBag.ProductsCount = products.Count();
                ViewBag.CategoryName = category.Name;
                return View(String.Empty, id.Value);
            }
        }

        [HttpGet]
        public ActionResult Product(int? id, string message)
        {
            var product = _context.Products.Include((Product p) => p.Category).FirstOrDefault(p => p.Id == id);
            if (product == null) return RedirectToReferrer();
            ViewBag.Message = (message == null) ? String.Empty : message;
            ViewBag.Product = product;
            return View(String.Empty, product.CategoryId);
        }

        [HttpPost]
        public ActionResult AddToCart(int? id, int count)
        {
            var product = _context.Products.Include((Product p) => p.Category).FirstOrDefault(p => p.Id == id);
            if (product == null) return RedirectToReferrer();

            HttpCookie cookie = (Request.Cookies["products"]?.Value != null) ? cookie = Request.Cookies["products"] : new HttpCookie("products", "[]");

            List<OrderUnit> units = JsonConvert.DeserializeObject<OrderUnit[]>(cookie.Value).ToList();
            OrderUnit unitWithCurrentProduct = units.Where(ou => ou.ProductId == id).FirstOrDefault();

			if (product.Quantity < count)
			{
				return Redirect($"{Request.UrlReferrer.ToString()}?message=Не хватает товара. Пожалуйста, попробуйте уменьшить количество заказываемого товара.");
			}
			if (unitWithCurrentProduct != null && unitWithCurrentProduct.Count + count <= product.Quantity)
			{
				return Redirect($"{Request.UrlReferrer.ToString()}?message=Не хватает товара. Пожалуйста, попробуйте уменьшить количество заказываемого товара.");
			}

			if (unitWithCurrentProduct != null)
            {
				if (unitWithCurrentProduct.Count + count <= product.Quantity)
				{
				    unitWithCurrentProduct.Count += count;
				}
			}
            else
            {
                units.Add(new OrderUnit(id.Value, count));
            }
            cookie.Value = JsonConvert.SerializeObject(units);

            Response.SetCookie(cookie);

            return Redirect($"{Request.UrlReferrer.ToString()}?message=Товар успешно добавлен в корзину.");
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
            return View();
		}

		[HttpGet]
		public ActionResult RemoveFromCart(int? ProductId)
		{
			HttpCookie cookie = (Request.Cookies["products"]?.Value != null) ? cookie = Request.Cookies["products"] : new HttpCookie("products", "[]");

			List<OrderUnit> units = JsonConvert.DeserializeObject<OrderUnit[]>(cookie.Value).ToList();
			OrderUnit currentUnit = units.FirstOrDefault(u => u.ProductId == ProductId);
			units.Remove(currentUnit);
			cookie.Value = JsonConvert.SerializeObject(units);

			Response.SetCookie(cookie);

			return RedirectToReferrer();
		}

		public ActionResult OrderCart()
        {
            if (CurrentUser == null) return Redirect("/Home/Auth?referrer=/Home/Order?message=Пожалуйста, авторизируйтесь, чтобы оформить заказ.");

            HttpCookie cookie = (Request.Cookies["products"]?.Value != null) ? cookie = Request.Cookies["products"] : new HttpCookie("products", "[]");
            List<OrderUnit> units = JsonConvert.DeserializeObject<OrderUnit[]>(cookie.Value).ToList();

            if (units.Count <= 0) return RedirectToReferrer();

            Order order = new Order(CurrentUser.Id, DateTime.Now);
            _context.Orders.Add(order);
            _context.SaveChanges();
            units.ForEach(unit =>
            {
                unit.OrderId = order.Id;
                _context.OrderUnits.Add(unit);
            });
            _context.SaveChanges();

			cookie.Value = "[]";
			Response.SetCookie(cookie);

            return Redirect("/Home/Orders");
        }

        public ActionResult Auth(string referrer, string message)
        {
            if (CurrentUser != null) return RedirectToReferrer();
            Session.Add("referrer", referrer);
            ViewBag.Message = (message == null) ? String.Empty : message;
            return View();
		}

        [HttpPost]
        public ActionResult Auth(User user)
        {
            if (CurrentUser != null) return RedirectToReferrer();

            user = _context.Users.Include(u => u.Role).FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);
            if (user != null)
            {
                CurrentUser = user;
            }

            if (Session["referrer"] is string referrer)
            {
                Session.Remove("referrer");
                return Redirect(referrer);
            }
            else
            {
                return Redirect("/Home/Index");
            }
        }

        public ActionResult Register(string message)
        {
            if (CurrentUser != null) return RedirectToReferrer();
            ViewBag.Message = (message == null) ? String.Empty : message;
			return View();
		}

        [HttpPost]
        public ActionResult Register(User user)
        {
            if (CurrentUser != null) return RedirectToReferrer();

            if (_context.Users.FirstOrDefault(u => u.Email == user.Email) == null)
            {
                user.RoleId = _context.Roles.FirstOrDefault(role => role.RoleType == Role.Type.User).Id;
                _context.Users.Add(user);
                _context.SaveChanges();
                CurrentUser = user;
                return Redirect("/Home/Index");
            }
            return Redirect("/Home/Register?message=Пользователь с таким E-Mail уже существует.");
        }

        public ActionResult Logout()
        {
            CurrentUser = null;
            return Redirect("/Home/Index");
        }

        public ActionResult Orders()
        {
            if (CurrentUser == null) return RedirectToReferrer();
			IEnumerable<Order> orders = _context.Orders.Where(order => order.UserId == CurrentUser.Id).Include(order => order.Units);
			foreach (Order order in orders)
			{
				foreach (OrderUnit unit in order.Units)
				{
					unit.Product = _context.Products.FirstOrDefault(p => p.Id == unit.ProductId);
				}
			}
			ViewBag.OrdersCount = orders.Count();
			ViewBag.Orders = orders;
            return View();
		}

        [HttpGet]
        public ActionResult Order(int? id)
        {
			if (CurrentUser == null) return RedirectToReferrer();
			var order = _context.Orders.Include((Order o) => o.Units).FirstOrDefault(o => o.Id == id);
			if (order == null) return RedirectToReferrer();
			if (CurrentUser.Id != order.UserId) return RedirectToReferrer();
			foreach (OrderUnit unit in order.Units)
			{
				unit.Product = _context.Products.FirstOrDefault(p => p.Id == unit.ProductId);
			}
			ViewBag.Order = order;
			return View();
		}
    }
}