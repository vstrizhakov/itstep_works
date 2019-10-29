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
    }
}