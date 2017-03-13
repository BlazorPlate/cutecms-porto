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
    [LocalizedAuthorize(Roles = "Admin")]
    public class ImageFileTermsController : BaseController
    {
        #region Fields
        private CMSEntities db = new CMSEntities();
        #endregion Fields

        #region Methods
        // GET: CMS/ImageFileTerms
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            var imageFileTerms = db.ImageFileTerms.Include(i => i.ImageFile).Include(i => i.Language).Where(i => i.ImageFile.TenantId.Trim().Equals(Tenant.TenantId) && i.ImageFileId == id);
            ViewBag.ImageFileId = id;
            return View(imageFileTerms.ToList());
        }

        // GET: CMS/ImageFileTerms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            ImageFileTerm imageFileTerm = db.ImageFileTerms.Include("Language").Include("ImageFile").Where(i => i.ImageFile.TenantId.Trim().Equals(Tenant.TenantId) && i.Id == id).FirstOrDefault();
            if (imageFileTerm == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(imageFileTerm);
        }

        // GET: CMS/ImageFileTerms/Create
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            ViewBag.ImageFileId = id;
            ViewBag.ImageFileCode = db.ImageFiles.Find(id).Code;
            int[] assignedLanguages = db.ImageFileTerms.Where(t => t.ImageFileId == id).Select(t => t.LanguageId).ToArray();
            ViewBag.LanguageId = new SelectList(db.CMSLanguages.Where(l => !assignedLanguages.Contains(l.Id) && l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name");
            return View();
        }

        // POST: CMS/ImageFileTerms/Create To protect from overposting attacks,
        // please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LanguageId,Value,Description,ImageFileId")] ImageFileTerm imageFileTerm)
        {
            if (ModelState.IsValid)
            {
                db.ImageFileTerms.Add(imageFileTerm);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = imageFileTerm.ImageFileId });
            }
            ViewBag.ImageFileId = imageFileTerm.ImageFileId;
            ViewBag.ImageFileCode = db.ImageFiles.Find(imageFileTerm.ImageFileId).Code;
            int[] assignedLanguages = db.ImageFileTerms.Where(t => t.ImageFileId == imageFileTerm.ImageFileId && t.LanguageId != imageFileTerm.LanguageId).Select(t => t.LanguageId).ToArray();
            ViewBag.LanguageId = new SelectList(db.CMSLanguages.Where(l => !assignedLanguages.Contains(l.Id) && l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name", imageFileTerm.LanguageId);
            return View(imageFileTerm);
        }

        // GET: CMS/ImageFileTerms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            ImageFileTerm imageFileTerm = db.ImageFileTerms.Where(i => i.ImageFile.TenantId.Trim().Equals(Tenant.TenantId) && i.Id == id).FirstOrDefault();
            if (imageFileTerm == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            ViewBag.ImageFileCode = db.ImageFiles.Find(imageFileTerm.ImageFileId).Code;
            int[] assignedLanguages = db.ImageFileTerms.Where(t => t.ImageFileId == imageFileTerm.ImageFileId && t.LanguageId != imageFileTerm.LanguageId).Select(t => t.LanguageId).ToArray();
            ViewBag.LanguageId = new SelectList(db.CMSLanguages.Where(l => !assignedLanguages.Contains(l.Id) && l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name", imageFileTerm.LanguageId);
            return View(imageFileTerm);
        }

        // POST: CMS/ImageFileTerms/Edit/5 To protect from overposting attacks,
        // please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LanguageId,Value,Description,ImageFileId")] ImageFileTerm imageFileTerm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(imageFileTerm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = imageFileTerm.ImageFileId });
            }
            ViewBag.ImageFileCode = db.ImageFiles.Find(imageFileTerm.ImageFileId).Code;
            int[] assignedLanguages = db.ImageFileTerms.Where(t => t.ImageFileId == imageFileTerm.ImageFileId && t.LanguageId != imageFileTerm.LanguageId).Select(t => t.LanguageId).ToArray();
            ViewBag.LanguageId = new SelectList(db.CMSLanguages.Where(l => !assignedLanguages.Contains(l.Id) && l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name", imageFileTerm.LanguageId);
            return View(imageFileTerm);
        }

        // GET: CMS/ImageFileTerms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            ImageFileTerm imageFileTerm = db.ImageFileTerms.Include("Language").Include("ImageFile").Where(i => i.ImageFile.TenantId.Trim().Equals(Tenant.TenantId) && i.Id == id).FirstOrDefault();
            if (imageFileTerm == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(imageFileTerm);
        }

        // POST: CMS/ImageFileTerms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ImageFileTerm imageFileTerm = db.ImageFileTerms.Find(id);
            db.ImageFileTerms.Remove(imageFileTerm);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = imageFileTerm.ImageFileId });
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