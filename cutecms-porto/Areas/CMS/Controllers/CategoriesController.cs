using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using cutecms_porto.Areas.CMS.Models.DBModel;
using cutecms_porto.Helpers;

namespace cutecms_porto.Areas.CMS.Controllers
{
    [LocalizedAuthorize(Roles = "Admin")]
    public class CategoriesController : BaseController
    {
        private CMSEntities db = new CMSEntities();

        // GET: CMS/Categories
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }

        // GET: CMS/Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(category);
        }

        // GET: CMS/Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CMS/Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Code,Visible,Ordinal")] Category category)
        {
            if (ModelState.IsValid)
            {
                category.TenantId = Tenant.GetCurrentTenantId();
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: CMS/Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(category);
        }

        // POST: CMS/Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Code,Visible,Ordinal")] Category category)
        {
            if (ModelState.IsValid)
            {
                category.TenantId = Tenant.GetCurrentTenantId();
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: CMS/Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(category);
        }

        // POST: CMS/Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
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
