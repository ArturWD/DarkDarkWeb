using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DDW.Core.Entities;
using DDW.Core.ViewModels;
using DDW.DataAccess.SQL;

namespace DarkDarkWeb.Controllers
{
    public class ResourceController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Resource
        public ActionResult Index(string Category = null)
        {
            List<Resource> resources;
            List<Category> categories = db.Categories.ToList();
            if (Category == null)
            {
                resources = db.Resources.ToList();
            }
            else
            {
                Category category = categories.Single(c => c.CategoryName == Category);
                resources = db.Resources.ToList().Where(r => r.Category == category).ToList();
            }
            ResourceCategoriesListViewt model = new ResourceCategoriesListViewt();
            model.Categories = categories;
            model.Resources = resources;
            return View(model);



            //var resources = db.Resources.Include(r => r.Category);
            //return View(resources.ToList());
        }

        

        // GET: Resource/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName");
            return View();
        }

        // POST: Resource/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( ResourceCreateView resourceView)
        {
            if (ModelState.IsValid)
            {
                var resource = new Resource
                {
                    ResourceName = resourceView.ResourceName,
                    URL = resourceView.URL,
                    RefreshDate = DateTime.Now,
                    Description = resourceView.Description,
                    Contacts = resourceView.Contacts,
                    CategoryId = resourceView.CategoryId,
                    Category = db.Categories.Single(c => c.CategoryId == resourceView.CategoryId),
                    Keywords = resourceView.Keywords.GetKeywords()
                };
                db.Resources.Add(resource);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", resourceView.CategoryId);
            return View(resourceView);
        }

        // GET: Resource/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resource resource = db.Resources.Find(id);
            if (resource == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", resource.CategoryId);
            return View(resource);
        }

        // POST: Resource/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ResourceId,ResourceName,URL,RefreshDate,Description,Contacts,CategoryId")] Resource resource)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resource).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", resource.CategoryId);
            return View(resource);
        }

        // GET: Resource/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resource resource = db.Resources.Find(id);
            if (resource == null)
            {
                return HttpNotFound();
            }
            return View(resource);
        }

        // POST: Resource/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Resource resource = db.Resources.Find(id);
            db.Resources.Remove(resource);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
