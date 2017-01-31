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
        public ActionResult Index(int? id)
        {
            var galleryCategories = db.GalleryCategories.Include(g => g.Category).Include(g => g.Gallery).Where(g => g.Gallery.TenantId.Trim().Equals(Tenant.TenantId) && g.GalleryId == id);
            ViewBag.GalleryId = id;
            return View(galleryCategories.ToList());
        }

        // GET: CMS/GalleryCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                 throw new HttpException(400, "Bad Request");
            }
            GalleryCategory galleryCategory = db.GalleryCategories.Include("Gallery").Where(g => g.Gallery.TenantId.Trim().Equals(Tenant.TenantId) && g.Id == id).FirstOrDefault();
            if (galleryCategory == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            ViewBag.GalleryId = galleryCategory.GalleryId;
            return View(galleryCategory);
        }

        // GET: CMS/GalleryCategories/Create
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                 throw new HttpException(400, "Bad Request");
            }
            ViewBag.CategoryId = new SelectList(TermsHelper.Categories(), "CategoryId", "Value");
            ViewBag.GalleryId = id;
            ViewBag.GalleryCode = db.Galleries.Find(id).Code;
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
                return RedirectToAction("Index", new { id = galleryCategory.GalleryId});
            }
            ViewBag.CategoryId = new SelectList(TermsHelper.Categories(), "CategoryId", "Value", galleryCategory.CategoryId);
            ViewBag.GalleryId = galleryCategory.GalleryId;
            ViewBag.GalleryCode = db.Galleries.Find(galleryCategory.GalleryId).Code;
            return View(galleryCategory);
        }

        // GET: CMS/GalleryCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                 throw new HttpException(400, "Bad Request");
            }
            GalleryCategory galleryCategory = db.GalleryCategories.Include("Gallery").Where(g => g.Gallery.TenantId.Trim().Equals(Tenant.TenantId) && g.Id == id).FirstOrDefault();
            if (galleryCategory == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            ViewBag.CategoryId = new SelectList(TermsHelper.Categories(), "CategoryId", "Value", galleryCategory.CategoryId);
            ViewBag.GalleryId = galleryCategory.GalleryId;
            ViewBag.GalleryCode = db.Galleries.Find(galleryCategory.GalleryId).Code;
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
                return RedirectToAction("Index", new { id = galleryCategory.GalleryId});
            }
            ViewBag.CategoryId = new SelectList(TermsHelper.Categories(), "CategoryId", "Value", galleryCategory.CategoryId);
            ViewBag.GalleryId = galleryCategory.GalleryId;
            ViewBag.GalleryCode = db.Galleries.Find(galleryCategory.GalleryId).Code;
            return View(galleryCategory);
        }

        // GET: CMS/GalleryCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                 throw new HttpException(400, "Bad Request");
            }
            GalleryCategory galleryCategory = db.GalleryCategories.Include("Gallery").Where(g => g.Gallery.TenantId.Trim().Equals(Tenant.TenantId) && g.Id == id).FirstOrDefault();
            if (galleryCategory == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            ViewBag.GalleryId = galleryCategory.GalleryId;
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
            return RedirectToAction("Index", new { id = galleryCategory.GalleryId});
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
