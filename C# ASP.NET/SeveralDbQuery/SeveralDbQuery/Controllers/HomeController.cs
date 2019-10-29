using SeveralDbQuery.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SeveralDbQuery.Controllers
{
    public class HomeController : Controller
    {
        private GeoContext context = new GeoContext();

        public ActionResult Index()
        {
            var cities = context.Cities.Include((City c) => c.Country);
            return View(cities);
        }

        public ActionResult CreateCity()
        {
            SelectList countries = new SelectList(context.Countries, "Id", "Name");
            ViewBag.Countries = countries;
            return View();
        }

        [HttpPost]
        public ActionResult CreateCity(City city)
        {
            context.Cities.Add(city);
            context.SaveChanges();
            return Redirect("Index");
        }
    }
}