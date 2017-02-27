using cutecms_porto.Areas.CMS.Models.DBModel;
using cutecms_porto.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace cutecms_porto.Areas.CMS.Controllers
{
    public class GalleryTermsController : BaseController
    {
        #region Fields
        private CMSEntities db = new CMSEntities();
        #endregion Fields

        #region Methods
        // GET: CMS/GalleryTerms
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            var galleryTerms = db.GalleryTerms.Include(g => g.Gallery).Include(g => g.Language).Where(g => g.Gallery.TenantId.Trim().Equals(Tenant.TenantId) && g.GalleryId == id);
            ViewBag.GalleryId = id;
            return View(galleryTerms.ToList());
        }

        // GET: CMS/GalleryTerms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            GalleryTerm galleryTerm = db.GalleryTerms.Include("Language").Include("Gallery").Where(g => g.Gallery.TenantId.Trim().Equals(Tenant.TenantId) && g.GalleryId == id).FirstOrDefault();
            if (galleryTerm == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(galleryTerm);
        }

        // GET: CMS/GalleryTerms/Create
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            ViewBag.GalleryId = id;
            ViewBag.GalleryCode = db.Galleries.Find(id).Code;
            int[] assignedLanguages = db.GalleryTerms.Where(t => t.GalleryId == id).Select(t => t.LanguageId).ToArray();
            ViewBag.LanguageId = new SelectList(db.CMSLanguages.Where(l => !assignedLanguages.Contains(l.Id) && l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name");
            return View();
        }

        // POST: CMS/GalleryTerms/Create To protect from overposting attacks,
        // please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LanguageId,Value,Description,GalleryId")] GalleryTerm galleryTerm)
        {
            if (ModelState.IsValid)
            {
                db.GalleryTerms.Add(galleryTerm);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = galleryTerm.GalleryId });
            }
            ViewBag.GalleryId = galleryTerm.GalleryId;
            ViewBag.GalleryCode = db.Galleries.Find(galleryTerm.GalleryId).Code;
            int[] assignedLanguages = db.GalleryTerms.Where(t => t.GalleryId == galleryTerm.GalleryId && t.LanguageId != galleryTerm.LanguageId).Select(t => t.LanguageId).ToArray();
            ViewBag.LanguageId = new SelectList(db.CMSLanguages.Where(l => !assignedLanguages.Contains(l.Id) && l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name", galleryTerm.LanguageId);
            return View(galleryTerm);
        }

        // GET: CMS/GalleryTerms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            GalleryTerm galleryTerm = db.GalleryTerms.Where(g => g.Gallery.TenantId.Trim().Equals(Tenant.TenantId) && g.Id == id).FirstOrDefault();
            if (galleryTerm == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            ViewBag.GalleryCode = db.Galleries.Find(galleryTerm.GalleryId).Code;
            int[] assignedLanguages = db.GalleryTerms.Where(t => t.GalleryId == galleryTerm.GalleryId && t.LanguageId != galleryTerm.LanguageId).Select(t => t.LanguageId).ToArray();
            ViewBag.LanguageId = new SelectList(db.CMSLanguages.Where(l => !assignedLanguages.Contains(l.Id) && l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name", galleryTerm.LanguageId);
            return View(galleryTerm);
        }

        // POST: CMS/GalleryTerms/Edit/5 To protect from overposting attacks,
        // please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LanguageId,Value,Description,GalleryId")] GalleryTerm galleryTerm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(galleryTerm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = galleryTerm.GalleryId });
            }
            ViewBag.GalleryCode = db.Galleries.Find(galleryTerm.GalleryId).Code;
            int[] assignedLanguages = db.GalleryTerms.Where(t => t.GalleryId == galleryTerm.GalleryId && t.LanguageId != galleryTerm.LanguageId).Select(t => t.LanguageId).ToArray();
            ViewBag.LanguageId = new SelectList(db.CMSLanguages.Where(l => !assignedLanguages.Contains(l.Id) && l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name", galleryTerm.LanguageId);
            return View(galleryTerm);
        }

        // GET: CMS/GalleryTerms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            GalleryTerm galleryTerm = db.GalleryTerms.Include("Language").Include("Gallery").Where(g => g.Gallery.TenantId.Trim().Equals(Tenant.TenantId) && g.GalleryId == id).FirstOrDefault();
            if (galleryTerm == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(galleryTerm);
        }

        // POST: CMS/GalleryTerms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GalleryTerm galleryTerm = db.GalleryTerms.Find(id);
            db.GalleryTerms.Remove(galleryTerm);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = galleryTerm.GalleryId });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion Methods
    }
}