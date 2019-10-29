using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Test.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View("Test");
        }

        public ActionResult NotFound()
        {
            return new HttpStatusCodeResult(404);
        }

        [HttpGet]
        public ActionResult Price(string str, string msg)
        {
            HttpContext.Response.Write(str + " | " + msg);
            return View();
        }

        public ActionResult Test2()
        {
            Random R = new Random();
            ViewData["hello"] = "world" + R.Next(10, 100);
            return View("~/Views/Gates/Bill.cshtml");
        }

        public ActionResult TestThree()
        {
            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }

        public ActionResult TestFour()
        {
            return RedirectToAction("Price", "Home", new { str = "Hello, world", msg = "Koala" });
        }

        public ActionResult GetFileOne()
        {
            string path = Server.MapPath("~/Koala.jpg");
            byte[] buf = System.IO.File.ReadAllBytes(path);
            return File(buf, "image/jpeg", "Koala.jpg");
        }

        public ActionResult GetFileTwo()
        {
            string path = Server.MapPath("~/Koala.jpg");
            return File(path, "image/jpeg", "Koala.jpg");
        }

        public ActionResult GetFileThree()
        {
            string path = Server.MapPath("~/Koala.jpg");
            System.IO.FileStream FS = new System.IO.FileStream(path, System.IO.FileMode.Open);
            return File(FS, "image/jpeg", "Koala.jpg");
        }
    }
}