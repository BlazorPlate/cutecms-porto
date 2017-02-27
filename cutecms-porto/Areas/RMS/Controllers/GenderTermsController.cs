using cutecms_porto.Areas.RMS.Models.DBModel;
using cutecms_porto.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace cutecms_porto.Areas.RMS.Controllers
{
    public class GenderTermsController : BaseController
    {
        #region Fields
        private RMSEntities db = new RMSEntities();
        #endregion Fields

        #region Methods
        // GET: RMS/GenderTerms
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            var genderTerms = db.GenderTerms.Include(g => g.Gender).Include(g => g.Language).Where(g => g.GenderId == id);
            ViewBag.GenderId = id;
            return View(genderTerms.ToList());
        }

        // GET: RMS/GenderTerms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            GenderTerm genderTerm = db.GenderTerms.Include("Language").Include("Gender").Where(i => i.Id == id).FirstOrDefault();
            if (genderTerm == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(genderTerm);
        }

        // GET: RMS/GenderTerms/Create
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            ViewBag.GenderId = id;
            ViewBag.GenderCode = db.Genders.Find(id).Code;
            int[] assignedLanguages = db.GenderTerms.Where(t => t.GenderId == id).Select(t => t.LanguageId).ToArray();
            ViewBag.LanguageId = new SelectList(db.RMSLanguages.Where(l => !assignedLanguages.Contains(l.Id) && l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name");
            return View();
        }

        // POST: RMS/GenderTerms/Create To protect from overposting attacks,
        // please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LanguageId,Value,GenderId")] GenderTerm genderTerm)
        {
            if (ModelState.IsValid)
            {
                db.GenderTerms.Add(genderTerm);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = genderTerm.GenderId });
            }
            ViewBag.GenderId = genderTerm.GenderId;
            ViewBag.GenderCode = db.Genders.Find(genderTerm.GenderId).Code;
            int[] assignedLanguages = db.GenderTerms.Where(t => t.GenderId == genderTerm.GenderId && t.LanguageId != genderTerm.LanguageId).Select(t => t.LanguageId).ToArray();
            ViewBag.LanguageId = new SelectList(db.RMSLanguages.Where(l => !assignedLanguages.Contains(l.Id) && l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name", genderTerm.LanguageId);
            return View(genderTerm);
        }

        // GET: RMS/GenderTerms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            GenderTerm genderTerm = db.GenderTerms.Include("Language").Include("Gender").Where(r => r.Id == id).FirstOrDefault();
            if (genderTerm == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            ViewBag.GenderCode = db.Genders.Find(genderTerm.GenderId).Code;
            int[] assignedLanguages = db.GenderTerms.Where(t => t.GenderId == genderTerm.GenderId && t.LanguageId != genderTerm.LanguageId).Select(t => t.LanguageId).ToArray();
            ViewBag.LanguageId = new SelectList(db.RMSLanguages.Where(l => !assignedLanguages.Contains(l.Id) && l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name", genderTerm.LanguageId);
            return View(genderTerm);
        }

        // POST: RMS/GenderTerms/Edit/5 To protect from overposting attacks,
        // please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LanguageId,Value,GenderId")] GenderTerm genderTerm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(genderTerm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = genderTerm.GenderId });
            }
            ViewBag.GenderCode = db.Genders.Find(genderTerm.GenderId).Code;
            int[] assignedLanguages = db.GenderTerms.Where(t => t.GenderId == genderTerm.GenderId && t.LanguageId != genderTerm.LanguageId).Select(t => t.LanguageId).ToArray();
            ViewBag.LanguageId = new SelectList(db.RMSLanguages.Where(l => !assignedLanguages.Contains(l.Id) && l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name", genderTerm.LanguageId);
            return View(genderTerm);
        }

        // GET: RMS/GenderTerms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            GenderTerm genderTerm = db.GenderTerms.Include("Language").Include("Gender").Where(i => i.Id == id).FirstOrDefault();
            if (genderTerm == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(genderTerm);
        }

        // POST: RMS/GenderTerms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GenderTerm genderTerm = db.GenderTerms.Find(id);
            db.GenderTerms.Remove(genderTerm);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = genderTerm.GenderId });
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