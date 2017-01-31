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
    public class GalleryCategoriesController : BaseController
    {
        private CMSEntities db = new CMSEntities();

        // GET: CMS/GalleryCategories
        public ActionResult Index()
        {
            var galleryCategories = db.GalleryCategories.Include(g => g.Category).Include(g => g.Gallery);
            return View(galleryCategories.ToList());
        }

        // GET: CMS/GalleryCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GalleryCategory galleryCategory = db.GalleryCategories.Find(id);
            if (galleryCategory == null)
            {
                return HttpNotFound();
            }
            return View(galleryCategory);
        }

        // GET: CMS/GalleryCategories/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "TenantId");
            ViewBag.GalleryId = new SelectList(db.Galleries, "Id", "TenantId");
            return View();
        }

        // POST: CMS/GalleryCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,GalleryId,CategoryId")] GalleryCategory galleryCategory)
        {
            if (ModelState.IsValid)
            {
                db.GalleryCategories.Add(galleryCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "TenantId", galleryCategory.CategoryId);
            ViewBag.GalleryId = new SelectList(db.Galleries, "Id", "TenantId", galleryCategory.GalleryId);
            return View(galleryCategory);
        }

        // GET: CMS/GalleryCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GalleryCategory galleryCategory = db.GalleryCategories.Find(id);
            if (galleryCategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "TenantId", galleryCategory.CategoryId);
            ViewBag.GalleryId = new SelectList(db.Galleries, "Id", "TenantId", galleryCategory.GalleryId);
            return View(galleryCategory);
        }

        // POST: CMS/GalleryCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,GalleryId,CategoryId")] GalleryCategory galleryCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(galleryCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "TenantId", galleryCategory.CategoryId);
            ViewBag.GalleryId = new SelectList(db.Galleries, "Id", "TenantId", galleryCategory.GalleryId);
            return View(galleryCategory);
        }

        // GET: CMS/GalleryCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GalleryCategory galleryCategory = db.GalleryCategories.Find(id);
            if (galleryCategory == null)
            {
                return HttpNotFound();
            }
            return View(galleryCategory);
        }

        // POST: CMS/GalleryCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GalleryCategory galleryCategory = db.GalleryCategories.Find(id);
            db.GalleryCategories.Remove(galleryCategory);
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
