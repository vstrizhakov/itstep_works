using ASP.NET_MVC_9.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NET_MVC_9.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Product P = new Product() { id = 1, Name = "Snickers", Price = 13.5, Weight = 45, Password="123456",  Email="Ololohs@lol.gg"};
            return View(P);
        }
        [HttpPost]
        public ActionResult Index(Product P)
        {
            return View(P);
        }
    }
}
