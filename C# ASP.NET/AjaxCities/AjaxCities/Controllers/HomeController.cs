using AjaxCities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace AjaxCities.Controllers
{
	public class HomeController : Controller
	{
		private CityContext _context = new CityContext();

		private string Bold(string str)
		{
			return String.Format("<b>{0}</b>", str);
		}

		public ActionResult Index()
		{
			ViewBag.Cities = _context.Cities;
			return View();
		}

		[HttpPost]
		public ActionResult GetTable(string search)
		{
			string invertedSearch = LiteralInverter.Invert(search);
			string translitedSearch = LiteralInverter.Translit(search);
			IEnumerable<City> cities = from city in _context.Cities
									   where (city.RuName.Contains(search) || city.EnName.Contains(search)) || (city.RuName.Contains(invertedSearch) || city.EnName.Contains(invertedSearch))
									   select city;
			Regex regex = new Regex(String.Format("^(.*)({0}|{1}|{2})(.*)$", search, invertedSearch, translitedSearch), RegexOptions.IgnoreCase);
			foreach (var city in cities)
			{
				city.RuName = regex.Replace(city.RuName, "$1<b>$2</b>$3");
				city.EnName = regex.Replace(city.EnName, "$1<b>$2</b>$3");
			}
			ViewBag.Cities = cities;
			return PartialView();
		}
	}
}