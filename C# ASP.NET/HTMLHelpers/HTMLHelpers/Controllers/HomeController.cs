using HTMLHelpers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HTMLHelpers.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            IEnumerable<Product> products = new List<Product>()
            {
                new Product
                {
                    Name = "Snickers",
                    Weight = 39,
                    Price = 12.5
                },
                new Product
                {
                    Name = "Bounty",
                    Weight = 45,
                    Price = 15,
                },
                new Product
                {
                    Name = "MilkyWay",
                    Weight = 20,
                    Price = 8,
                },
                new Product
                {
                    Name = "Mars",
                    Weight = 36,
                    Price = 14,
                },
            };
            ViewBag.Products = products;
            return View();
        }

        public ActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            ViewBag.Product = product;
            return View("ShowProduct");
        }
    }
}