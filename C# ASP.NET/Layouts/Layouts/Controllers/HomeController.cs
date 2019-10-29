using Layouts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Layouts.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<Person> arr = new List<Person>();
            arr.Add(new Person() { Lastname = "Gates", Firstname = "Bill", Age = 63, Sex = false });
            return View(arr);
        }

        public ActionResult TestOne()
        {
            return View(77);
        }

        public ActionResult IndexTwo()
        {
            List<Person> arr = new List<Person>();
            arr.Add(new Person() { Lastname = "Gates", Firstname = "Bill", Age = 63, Sex = false });
            return View();
        }

        public ActionResult IndexThree()
        {
            ViewBag.Message = "Hello, world";
            return View();
        }

        public ActionResult TestTwo()
        {
            ViewBag.Message = "Пример частичного вида";
            return PartialView();
        }
    }
}