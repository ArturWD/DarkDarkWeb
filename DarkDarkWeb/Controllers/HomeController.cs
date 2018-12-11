using DDW.Core.Entities;
using DDW.Core.ViewModels;
using DDW.DataAccess.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DarkDarkWeb.Controllers
{
    public class HomeController : Controller
    {
        private DataContext db = new DataContext();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string keywordsString)
        {
            return RedirectToAction("Search","Home", new {keyword = keywordsString });
        }
        public ActionResult Search(string keywordsString)
        {
            List<Resource> resources;
            List<Category> categories = db.Categories.ToList();
            if (keywordsString == null)
            {
                resources = db.Resources.ToList();
            }
            else
            {
               
                resources = db.Resources.ToList().Search(keywordsString);
            }
            ResourceCategoriesListViewt model = new ResourceCategoriesListViewt();
            model.Categories = categories;
            model.Resources = resources;
            return View(model);

        }

    }
}