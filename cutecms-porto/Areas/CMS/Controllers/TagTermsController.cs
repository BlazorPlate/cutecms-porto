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
    public class TagTermsController : BaseController
    {
        #region Fields
        private CMSEntities db = new CMSEntities();
        #endregion Fields

        #region Methods
        // GET: CMS/TagTerms
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            var tagTerms = db.TagTerms.Include(t => t.Tag).Include(t => t.Language).Where(t => t.Tag.TenantId.Trim().Equals(Tenant.TenantId) && t.TagId == id);
            ViewBag.TagId = id;
            return View(tagTerms.ToList());
        }

        // GET: CMS/TagTerms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            TagTerm tagTerm = db.TagTerms.Include("Language").Include("Tag").Where(t => t.Tag.TenantId.Trim().Equals(Tenant.TenantId) && t.Id == id).FirstOrDefault();
            if (tagTerm == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(tagTerm);
        }

        // GET: CMS/TagTerms/Create
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            ViewBag.TagId = id;
            ViewBag.TagCode = db.Tags.Find(id).Code;
            int[] assignedLanguages = db.TagTerms.Where(t => t.TagId == id).Select(t => t.LanguageId).ToArray();
            ViewBag.LanguageId = new SelectList(db.CMSLanguages.Where(l => !assignedLanguages.Contains(l.Id) && l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name");
            return View();
        }

        // POST: CMS/TagTerms/Create To protect from overposting attacks,
        // please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LanguageId,Value,TagId")] TagTerm tagTerm)
        {
            if (ModelState.IsValid)
            {
                db.TagTerms.Add(tagTerm);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = tagTerm.TagId });
            }
            ViewBag.TagId = tagTerm.TagId;
            ViewBag.TagCode = db.Tags.Find(tagTerm.TagId).Code;
            int[] assignedLanguages = db.TagTerms.Where(t => t.TagId == tagTerm.TagId && t.LanguageId != tagTerm.LanguageId).Select(t => t.LanguageId).ToArray();
            ViewBag.LanguageId = new SelectList(db.CMSLanguages.Where(l => !assignedLanguages.Contains(l.Id) && l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name", tagTerm.LanguageId);
            return View(tagTerm);
        }

        // GET: CMS/TagTerms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            TagTerm tagTerm = db.TagTerms.Where(t => t.Tag.TenantId.Trim().Equals(Tenant.TenantId) && t.Id == id).FirstOrDefault();
            if (tagTerm == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            ViewBag.TagCode = db.Tags.Find(tagTerm.TagId).Code;
            int[] assignedLanguages = db.TagTerms.Where(t => t.TagId == tagTerm.TagId && t.LanguageId != tagTerm.LanguageId).Select(t => t.LanguageId).ToArray();
            ViewBag.LanguageId = new SelectList(db.CMSLanguages.Where(l => !assignedLanguages.Contains(l.Id) && l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name", tagTerm.LanguageId);
            return View(tagTerm);
        }

        // POST: CMS/TagTerms/Edit/5 To protect from overposting attacks,
        // please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LanguageId,Value,TagId")] TagTerm tagTerm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tagTerm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = tagTerm.TagId });
            }
            ViewBag.TagCode = db.Tags.Find(tagTerm.TagId).Code;
            int[] assignedLanguages = db.TagTerms.Where(t => t.TagId == tagTerm.TagId && t.LanguageId != tagTerm.LanguageId).Select(t => t.LanguageId).ToArray();
            ViewBag.LanguageId = new SelectList(db.CMSLanguages.Where(l => !assignedLanguages.Contains(l.Id) && l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name", tagTerm.LanguageId);
            return View(tagTerm);
        }

        // GET: CMS/TagTerms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            TagTerm tagTerm = db.TagTerms.Include("Language").Include("Tag").Where(t => t.Tag.TenantId.Trim().Equals(Tenant.TenantId) && t.Id == id).FirstOrDefault();
            if (tagTerm == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(tagTerm);
        }

        // POST: CMS/TagTerms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TagTerm tagTerm = db.TagTerms.Find(id);
            db.TagTerms.Remove(tagTerm);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = tagTerm.TagId });
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