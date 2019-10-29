using Coffee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Coffee.Controllers
{
	public class HomeController : Controller
	{
		static private CoffeeDbContext _context = new CoffeeDbContext();

		public ActionResult Index()
		{
			List<SelectListItem> coffeeItems = new List<SelectListItem>();
			foreach (Models.Coffee coffee in _context.Coffees)
			{
				coffeeItems.Add((SelectListItem)coffee);
			}
			ViewBag.Coffees = _context.Coffees;
			return View();
		}

		[HttpGet]
		public ActionResult Coffee(int? id)
		{
			Models.Coffee coffee = _context.Coffees.Where(c => c.Id == id).FirstOrDefault();
			if (coffee != null)
			{
				ViewBag.Additives = _context.CoffeeAdditivePairs.Where(p => p.CoffeeId == coffee.Id).Include((CoffeeAdditivePair p) => p.Additive).Select((CoffeeAdditivePair p) => p.Additive);
				ViewBag.Coffee = coffee;
				return View();
			}
			return Redirect("/Home/Index");
		}

		[HttpPost]
		public ActionResult Coffee()
		{
			int coffeeId = Int32.Parse(Request.Form["id"]);
			Order order = new Order()
			{
				CoffeeId = coffeeId
			};
			_context.Orders.Add(order);
			_context.SaveChanges();

			List<string> additivesId = Request.Form.AllKeys.Where(s => s.Contains("additive_")).ToList();
			additivesId.ForEach(s =>
			{
				if (Request.Form[s].Contains("true") && Int32.TryParse(s.Replace("additive_", ""), out int id))
				{
					CoffeeAdditivePair pair = _context.CoffeeAdditivePairs.Where(p => p.CoffeeId == coffeeId && p.AdditiveId == id).FirstOrDefault();
					if (pair != null)
					{
						_context.OrderAdditivePairs.Add(new OrderAdditivePair() { OrderId = order.Id, AdditiveId = id });
					}
				}
			});
			_context.SaveChanges();
			return Redirect("/Home/Orders");
		}

		public ActionResult Orders()
		{
			ViewBag.Orders = _context.Orders.Include((Order o) => o.Additives);
			return View();
		}

		[HttpPost]
		public ActionResult GetAdditives()
		{
			string id = Request.Form["coffee"];
			Models.Coffee coffee = _context.Coffees.Where(c => c.Id.ToString() == id).FirstOrDefault();
			ViewBag.Additives = _context.CoffeeAdditivePairs.Where(p => p.CoffeeId == coffee.Id).Include((CoffeeAdditivePair p) => p.Additive).Select((CoffeeAdditivePair p) => p.Additive);
			ViewBag.CoffeeId = id;
			return PartialView();
		}
	}
}