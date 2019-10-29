using JaxaHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JaxaHelper.Controllers
{
	public class HomeController : Controller
	{
		private BookContext context = new BookContext();

		public ActionResult Index()
		{
			var books = context.Books;
			return View(books);
		}

		[HttpPost]
		public ActionResult Calculate(string one, string two)
		{
			ViewBag.Result = 0;
			if (Double.TryParse(one, out double doubleOne) && Double.TryParse(two, out double doubleTwo))
			{
				double result = doubleOne + doubleTwo;
				ViewBag.Result = result;
			}
			return PartialView();
		}
	}
}