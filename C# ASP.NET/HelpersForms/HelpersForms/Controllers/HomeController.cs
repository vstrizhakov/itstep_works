using HelpersForms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelpersForms.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var jan = new SelectListItem
            {
                Text = "Januar",
                Value = "jan"
            };
            var feb = new SelectListItem
            {
                Text = "Februar",
                Value = "feb"
            };
            var mar = new SelectListItem
            {
                Text = "March",
                Value = "mar"
            };
            var apr = new SelectListItem
            {
                Text = "April",
                Value = "apr"
            };
            var may = new SelectListItem
            {
                Text = "May",
                Value = "may"
            };
            var jun = new SelectListItem
            {
                Text = "June",
                Value = "jun"
            };
            var jul = new SelectListItem
            {
                Text = "July",
                Value = "jul"
            };
            var aug = new SelectListItem
            {
                Text = "August",
                Value = "aug"
            };
            var sep = new SelectListItem
            {
                Text = "September",
                Value = "sep"
            };
            var oct = new SelectListItem
            {
                Text = "October",
                Value = "oct"
            };
            var nov = new SelectListItem
            {
                Text = "November",
                Value = "nov"
            };
            var dec = new SelectListItem
            {
                Text = "December",
                Value = "dec"
            };
            ViewBag.Monthes = new List<SelectListItem>
            {
                jan, feb, mar, apr, may, jun, jul, aug, sep, oct, nov, dec
            };

            List<SelectListItem> themes = new List<SelectListItem>();
            themes.Add(new SelectListItem() { Value = "1", Text = "Программирование" });
            themes.Add(new SelectListItem() { Value = "2", Text = "Базы Данных" });
            themes.Add(new SelectListItem() { Value = "3", Text = "Дизайн приложений" });
            ViewBag.Themes = themes;
            return View();
        }

        [HttpPost]
        public ActionResult Index(int color, bool isPhp, bool isJs, string month)
        {
            ViewBag.Color = color;
            ViewBag.IsPhp = isPhp;
            ViewBag.IsJs = isJs;
            ViewBag.Month = month;
            return View();
        }
    }
}