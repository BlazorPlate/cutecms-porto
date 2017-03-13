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
    [LocalizedAuthorize(Roles = "Admin")]
    public class OccupationTermsController : BaseController
    {
        #region Fields
        private IdentityEntities db = new IdentityEntities();
        #endregion Fields

        #region Methods
        // GET: Identity/OccupationTerms
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            var occupationTerms = db.OccupationTerms.Include(o => o.Occupation).Include(o => o.Language).Where(o => o.OccupationId == id);
            ViewBag.OccupationId = id;
            return View(occupationTerms.ToList());
        }

        // GET: Identity/OccupationTerms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            OccupationTerm occupationTerm = db.OccupationTerms.Include("Language").Include("Occupation").Where(o => o.Id == id).FirstOrDefault();
            if (occupationTerm == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(occupationTerm);
        }

        // GET: Identity/OccupationTerms/Create
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            ViewBag.OccupationId = id;
            ViewBag.OccupationCode = db.Occupations.Find(id).Code;
            int[] assignedLanguages = db.OccupationTerms.Where(t => t.OccupationId == id).Select(t => t.LanguageId).ToArray();
            ViewBag.LanguageId = new SelectList(db.IdentityLanguages.Where(l => !assignedLanguages.Contains(l.Id) && l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name");
            return View();
        }

        // POST: Identity/OccupationTerms/Create To protect from overposting attacks,
        // please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LanguageId,Value,OccupationId")] OccupationTerm occupationTerm)
        {
            if (ModelState.IsValid)
            {
                db.OccupationTerms.Add(occupationTerm);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = occupationTerm.OccupationId });
            }
            ViewBag.OccupationId = occupationTerm.OccupationId;
            ViewBag.OccupationCode = db.Occupations.Find(occupationTerm.OccupationId).Code;
            int[] assignedLanguages = db.OccupationTerms.Where(t => t.OccupationId == occupationTerm.OccupationId && t.LanguageId != occupationTerm.LanguageId).Select(t => t.LanguageId).ToArray();
            ViewBag.LanguageId = new SelectList(db.IdentityLanguages.Where(l => !assignedLanguages.Contains(l.Id) && l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name", occupationTerm.LanguageId);
            return View(occupationTerm);
        }

        // GET: Identity/OccupationTerms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            OccupationTerm occupationTerm = db.OccupationTerms.Find(id);
            if (occupationTerm == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            ViewBag.OccupationCode = db.Occupations.Find(occupationTerm.OccupationId).Code;
            int[] assignedLanguages = db.OccupationTerms.Where(t => t.OccupationId == occupationTerm.OccupationId && t.LanguageId != occupationTerm.LanguageId).Select(t => t.LanguageId).ToArray();
            ViewBag.LanguageId = new SelectList(db.IdentityLanguages.Where(l => !assignedLanguages.Contains(l.Id) && l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name", occupationTerm.LanguageId);
            return View(occupationTerm);
        }

        // POST: Identity/OccupationTerms/Edit/5 To protect from overposting attacks,
        // please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LanguageId,Value,OccupationId")] OccupationTerm occupationTerm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(occupationTerm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = occupationTerm.OccupationId });
            }
            ViewBag.OccupationCode = db.Occupations.Find(occupationTerm.OccupationId).Code;
            int[] assignedLanguages = db.OccupationTerms.Where(t => t.OccupationId == occupationTerm.OccupationId && t.LanguageId != occupationTerm.LanguageId).Select(t => t.LanguageId).ToArray();
            ViewBag.LanguageId = new SelectList(db.IdentityLanguages.Where(l => !assignedLanguages.Contains(l.Id) && l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name", occupationTerm.LanguageId);
            return View(occupationTerm);
        }

        // GET: Identity/OccupationTerms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            OccupationTerm occupationTerm = db.OccupationTerms.Include("Language").Include("Occupation").Where(o => o.Id == id).FirstOrDefault();
            if (occupationTerm == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(occupationTerm);
        }

        // POST: Identity/OccupationTerms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OccupationTerm occupationTerm = db.OccupationTerms.Find(id);
            db.OccupationTerms.Remove(occupationTerm);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = occupationTerm.OccupationId });
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