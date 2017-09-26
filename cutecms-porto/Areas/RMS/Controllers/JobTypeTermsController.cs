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
    [LocalizedAuthorize(Roles = "Admin,RMS,JobTypes")]
    public class JobTypeTermsController : BaseController
    {
        #region Fields
        private RMSEntities db = new RMSEntities();
        #endregion Fields

        #region Methods
        // GET: RMS/JobTypeTerms
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            var jobTypeTerms = db.JobTypeTerms.Include(j => j.JobType).Include(j => j.Language).Where(j => j.JobTypeId == id);
            ViewBag.JobTypeId = id;
            return View(jobTypeTerms.ToList());
        }

        // GET: RMS/JobTypeTerms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            JobTypeTerm jobTypeTerm = db.JobTypeTerms.Include("Language").Include("JobType").Where(j => j.Id == id).FirstOrDefault();
            if (jobTypeTerm == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(jobTypeTerm);
        }

        // GET: RMS/JobTypeTerms/Create
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            ViewBag.JobTypeId = id;
            ViewBag.JobTypeCode = db.JobTypes.Find(id).Code;
            int[] assignedLanguages = db.JobTypeTerms.Where(t => t.JobTypeId == id).Select(rt => rt.LanguageId).ToArray();
            ViewBag.LanguageId = new SelectList(db.RMSLanguages.Where(l => !assignedLanguages.Contains(l.Id) && l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name");
            return View();
        }

        // POST: RMS/JobTypeTerms/Create To protect from overposting attacks,
        // please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LanguageId,Value,JobTypeId")] JobTypeTerm jobTypeTerm)
        {
            if (ModelState.IsValid)
            {
                db.JobTypeTerms.Add(jobTypeTerm);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = jobTypeTerm.JobTypeId });
            }
            ViewBag.JobTypeId = jobTypeTerm.JobTypeId;
            ViewBag.JobTypeCode = db.JobTypes.Find(jobTypeTerm.JobTypeId).Code;
            int[] assignedLanguages = db.JobTypeTerms.Where(t => t.JobTypeId == jobTypeTerm.JobTypeId && t.LanguageId != jobTypeTerm.LanguageId).Select(rt => rt.LanguageId).ToArray();
            ViewBag.LanguageId = new SelectList(db.RMSLanguages.Where(l => !assignedLanguages.Contains(l.Id) && l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name", jobTypeTerm.LanguageId);
            return View(jobTypeTerm);
        }

        // GET: RMS/JobTypeTerms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            JobTypeTerm jobTypeTerm = db.JobTypeTerms.Find(id);
            if (jobTypeTerm == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            ViewBag.JobTypeCode = db.JobTypes.Find(jobTypeTerm.JobTypeId).Code;
            int[] assignedLanguages = db.JobTypeTerms.Where(t => t.JobTypeId == jobTypeTerm.JobTypeId && t.LanguageId != jobTypeTerm.LanguageId).Select(rt => rt.LanguageId).ToArray();
            ViewBag.LanguageId = new SelectList(db.RMSLanguages.Where(l => !assignedLanguages.Contains(l.Id) && l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name", jobTypeTerm.LanguageId);
            return View(jobTypeTerm);
        }

        // POST: RMS/JobTypeTerms/Edit/5 To protect from overposting attacks,
        // please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LanguageId,Value,JobTypeId")] JobTypeTerm jobTypeTerm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobTypeTerm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = jobTypeTerm.JobTypeId });
            }
            ViewBag.JobTypeCode = db.JobTypes.Find(jobTypeTerm.JobTypeId).Code;
            int[] assignedLanguages = db.JobTypeTerms.Where(t => t.JobTypeId == jobTypeTerm.JobTypeId && t.LanguageId != jobTypeTerm.LanguageId).Select(rt => rt.LanguageId).ToArray();
            ViewBag.LanguageId = new SelectList(db.RMSLanguages.Where(l => !assignedLanguages.Contains(l.Id) && l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name", jobTypeTerm.LanguageId);
            return View(jobTypeTerm);
        }

        // GET: RMS/JobTypeTerms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            JobTypeTerm jobTypeTerm = db.JobTypeTerms.Include("Language").Include("JobType").Where(j => j.Id == id).FirstOrDefault();
            if (jobTypeTerm == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(jobTypeTerm);
        }

        // POST: RMS/JobTypeTerms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JobTypeTerm jobTypeTerm = db.JobTypeTerms.Find(id);
            db.JobTypeTerms.Remove(jobTypeTerm);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = jobTypeTerm.JobTypeId });
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