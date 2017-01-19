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
    public class ContentTypeTermsController : BaseController
    {
        #region Fields
        private CMSEntities db = new CMSEntities();
        #endregion Fields

        #region Methods
        // GET: CMS/ContentTypeTerms
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            var contentTypeTerms = db.ContentTypeTerms.Include(c => c.ContentType).Include(c => c.Language).Where(c => c.ContentTypeId == id);
            ViewBag.ContentTypeId = id;
            return View(contentTypeTerms.ToList());
        }

        // GET: CMS/ContentTypeTerms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            ContentTypeTerm contentTypeTerm = db.ContentTypeTerms.Include("Language").Include("ContentType").Where(c => c.Id == id).FirstOrDefault();
            if (contentTypeTerm == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(contentTypeTerm);
        }

        // GET: CMS/ContentTypeTerms/Create
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            ViewBag.ContentTypeId = id;
            ViewBag.ContentTypeCode = db.ContentTypes.Find(id).Code;
            int[] assignedLanguages = db.ContentTypeTerms.Where(t => t.ContentTypeId == id).Select(t => t.LanguageId).ToArray();
            ViewBag.LanguageId = new SelectList(db.CMSLanguages.Where(l => !assignedLanguages.Contains(l.Id) && l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name");
            return View();
        }

        // POST: CMS/ContentTypeTerms/Create To protect from overposting attacks,
        // please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LanguageId,Value,ContentTypeId")] ContentTypeTerm contentTypeTerm)
        {
            if (ModelState.IsValid)
            {
                db.ContentTypeTerms.Add(contentTypeTerm);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = contentTypeTerm.ContentTypeId });
            }
            ViewBag.ContentTypeId = contentTypeTerm.ContentTypeId;
            ViewBag.ContentTypeCode = db.ContentTypes.Find(contentTypeTerm.ContentTypeId).Code;
            int[] assignedLanguages = db.ContentTypeTerms.Where(t => t.ContentTypeId == contentTypeTerm.ContentTypeId && t.LanguageId != contentTypeTerm.LanguageId).Select(t => t.LanguageId).ToArray();
            ViewBag.LanguageId = new SelectList(db.CMSLanguages.Where(l => !assignedLanguages.Contains(l.Id) && l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name", contentTypeTerm.LanguageId);
            return View(contentTypeTerm);
        }

        // GET: CMS/ContentTypeTerms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            ContentTypeTerm contentTypeTerm = db.ContentTypeTerms.Find(id);
            if (contentTypeTerm == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            int[] assignedLanguages = db.ContentTypeTerms.Where(t => t.ContentTypeId == contentTypeTerm.ContentTypeId && t.LanguageId != contentTypeTerm.LanguageId).Select(t => t.LanguageId).ToArray();
            ViewBag.LanguageId = new SelectList(db.CMSLanguages.Where(l => !assignedLanguages.Contains(l.Id) && l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name", contentTypeTerm.LanguageId);
            return View(contentTypeTerm);
        }

        // POST: CMS/ContentTypeTerms/Edit/5 To protect from overposting attacks,
        // please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LanguageId,Value,ContentTypeId")] ContentTypeTerm contentTypeTerm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contentTypeTerm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = contentTypeTerm.ContentTypeId });
            }
            int[] assignedLanguages = db.ContentTypeTerms.Where(t => t.ContentTypeId == contentTypeTerm.ContentTypeId && t.LanguageId != contentTypeTerm.LanguageId).Select(t => t.LanguageId).ToArray();
            ViewBag.LanguageId = new SelectList(db.CMSLanguages.Where(l => !assignedLanguages.Contains(l.Id) && l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name", contentTypeTerm.LanguageId);
            return View(contentTypeTerm);
        }

        // GET: CMS/ContentTypeTerms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            ContentTypeTerm contentTypeTerm = db.ContentTypeTerms.Include("Language").Include("ContentType").Where(c => c.Id == id).FirstOrDefault();
            if (contentTypeTerm == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(contentTypeTerm);
        }

        // POST: CMS/ContentTypeTerms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContentTypeTerm contentTypeTerm = db.ContentTypeTerms.Find(id);
            db.ContentTypeTerms.Remove(contentTypeTerm);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = contentTypeTerm.ContentTypeId });
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