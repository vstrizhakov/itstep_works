using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TemplateHelpers.Models;

namespace TemplateHelpers.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Person person = new Person()
            {
                LastName = "Gates",
                FirstName = "Bill",
                Age = 63,
                Gender = true,
                IsProgrammer = true,
                Password = "123456"
            };
            return View(person);
        }

        public ActionResult ShowPassword(Person person)
        {
            ViewBag.Person = person;
            return View();
        }
    }
}