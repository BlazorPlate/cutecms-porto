using cutecms_porto.Areas.Identity.Models.DBModel;
using cutecms_porto.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace cutecms_porto.Areas.Identity.Controllers
{
    [LocalizedAuthorize(Roles = "Admin,Identity,PersonalTitles")]
    public class IdentityPersonalTitleTermsController : BaseController
    {
        #region Fields
        private IdentityEntities db = new IdentityEntities();
        #endregion Fields

        #region Methods
        // GET: Identity/IdentityPersonalTitleTerms
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            var identityPersonalTitleTerms = db.IdentityPersonalTitleTerms.Include(p => p.PersonalTitle).Include(p => p.Language).Where(p => p.PersonalTitleId == id);
            ViewBag.PersonalTitleId = id;
            return View(identityPersonalTitleTerms.ToList());
        }

        // GET: Identity/IdentityPersonalTitleTerms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            IdentityPersonalTitleTerm identityPersonalTitleTerm = db.IdentityPersonalTitleTerms.Include("Language").Include("PersonalTitle").Where(p => p.Id == id).FirstOrDefault();
            if (identityPersonalTitleTerm == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(identityPersonalTitleTerm);
        }

        // GET: Identity/IdentityPersonalTitleTerms/Create
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            ViewBag.PersonalTitleId = id;
            ViewBag.PersonalTitleCode = db.IdentityPersonalTitles.Find(id).Code;
            int[] assignedLanguages = db.IdentityPersonalTitleTerms.Where(t => t.PersonalTitleId == id).Select(t => t.LanguageId).ToArray();
            ViewBag.LanguageId = new SelectList(db.IdentityLanguages.Where(l => !assignedLanguages.Contains(l.Id) && l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name");
            return View();
        }

        // POST: Identity/IdentityPersonalTitleTerms/Create To protect from overposting attacks,
        // please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LanguageId,Value,PersonalTitleId")] IdentityPersonalTitleTerm identityPersonalTitleTerm)
        {
            if (ModelState.IsValid)
            {
                db.IdentityPersonalTitleTerms.Add(identityPersonalTitleTerm);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = identityPersonalTitleTerm.PersonalTitleId });
            }
            ViewBag.PersonalTitleId = identityPersonalTitleTerm.PersonalTitleId;
            ViewBag.PersonalTitleCode = db.IdentityPersonalTitles.Find(identityPersonalTitleTerm.PersonalTitleId).Code;
            int[] assignedLanguages = db.IdentityPersonalTitleTerms.Where(t => t.PersonalTitleId == identityPersonalTitleTerm.PersonalTitleId && t.LanguageId != identityPersonalTitleTerm.LanguageId).Select(t => t.LanguageId).ToArray();
            ViewBag.LanguageId = new SelectList(db.IdentityLanguages.Where(l => !assignedLanguages.Contains(l.Id) && l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name", identityPersonalTitleTerm.LanguageId);
            return View(identityPersonalTitleTerm);
        }

        // GET: Identity/IdentityPersonalTitleTerms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            IdentityPersonalTitleTerm identityPersonalTitleTerm = db.IdentityPersonalTitleTerms.Find(id);
            if (identityPersonalTitleTerm == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            ViewBag.PersonalTitleCode = db.IdentityPersonalTitles.Find(identityPersonalTitleTerm.PersonalTitleId).Code;
            int[] assignedLanguages = db.IdentityPersonalTitleTerms.Where(t => t.PersonalTitleId == identityPersonalTitleTerm.PersonalTitleId && t.LanguageId != identityPersonalTitleTerm.LanguageId).Select(t => t.LanguageId).ToArray();
            ViewBag.LanguageId = new SelectList(db.IdentityLanguages.Where(l => !assignedLanguages.Contains(l.Id) && l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name", identityPersonalTitleTerm.LanguageId);
            return View(identityPersonalTitleTerm);
        }

        // POST: Identity/IdentityPersonalTitleTerms/Edit/5 To protect from overposting attacks,
        // please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LanguageId,Value,PersonalTitleId")] IdentityPersonalTitleTerm identityPersonalTitleTerm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(identityPersonalTitleTerm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = identityPersonalTitleTerm.PersonalTitleId });
            }
            ViewBag.PersonalTitleCode = db.IdentityPersonalTitles.Find(identityPersonalTitleTerm.PersonalTitleId).Code;
            int[] assignedLanguages = db.IdentityPersonalTitleTerms.Where(t => t.PersonalTitleId == identityPersonalTitleTerm.PersonalTitleId && t.LanguageId != identityPersonalTitleTerm.LanguageId).Select(t => t.LanguageId).ToArray();
            ViewBag.LanguageId = new SelectList(db.IdentityLanguages.Where(l => !assignedLanguages.Contains(l.Id) && l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name", identityPersonalTitleTerm.LanguageId);
            return View(identityPersonalTitleTerm);
        }

        // GET: Identity/IdentityPersonalTitleTerms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            IdentityPersonalTitleTerm identityPersonalTitleTerm = db.IdentityPersonalTitleTerms.Include("Language").Include("PersonalTitle").Where(p => p.Id == id).FirstOrDefault();
            if (identityPersonalTitleTerm == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(identityPersonalTitleTerm);
        }

        // POST: Identity/IdentityPersonalTitleTerms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IdentityPersonalTitleTerm identityPersonalTitleTerm = db.IdentityPersonalTitleTerms.Find(id);
            db.IdentityPersonalTitleTerms.Remove(identityPersonalTitleTerm);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = identityPersonalTitleTerm.PersonalTitleId });
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