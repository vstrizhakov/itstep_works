using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Store.Controllers
{
    public class BaseController : Controller
    {
        protected StoreDbContext _context = new StoreDbContext();
		protected String _baseRoute = "/";
		protected bool _loadCategories = true;

        protected User CurrentUser
		{
			get
			{
				return Session["CurrentUser"] as User;
			}
			set
			{
				Session["CurrentUser"] = value;
			}
		}

		public ActionResult View(String view = "", int activeCategoryId = -1)
		{
			if (_loadCategories) LoadCategories(activeCategoryId);
			ViewBag.IsUserAdmin = IsUserAdmin();
			ViewBag.IsUserLoggedIn = IsUserLoggedIn();
			ViewBag.LoadCategories = _loadCategories;
			if (view == String.Empty)
			{
				return base.View();
			}
			else
			{
				return base.View(view);
			}
		}

		protected bool IsUserAdmin()
		{
			return CurrentUser != null && CurrentUser.Role.RoleType == Role.Type.Admin;
		}

		protected bool IsUserLoggedIn()
		{
			return CurrentUser != null;
		}

		protected void LoadCategories(int activeCategoryId = -1)
        {
            IEnumerable<Category> categories = _context.Categories.Where(c => c.ParentCategoryId == null).Include((Category c) => c.ChildCategories);
            categories = categories.OrderBy(c => c.Name).ToList();
            foreach (var category in categories)
            {
                category.ChildCategories = category.ChildCategories.OrderBy(c => c.Name).ToList();
            }
            ViewBag.Categories = categories;
            ViewBag.ActiveCategoryId = activeCategoryId;
        }

        protected ActionResult RedirectToReferrer()
        {
            return (Request.UrlReferrer != null) ? Redirect(Request.UrlReferrer.ToString()) : Redirect(_baseRoute);
        }
    }
}