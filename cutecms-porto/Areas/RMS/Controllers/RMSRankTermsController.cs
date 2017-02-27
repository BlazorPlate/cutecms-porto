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
    public class RMSRankTermsController : BaseController
    {
        #region Fields
        private RMSEntities db = new RMSEntities();
        #endregion Fields

        #region Methods
        // GET: RMS/RankTerms
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            var rmsRankTerms = db.RMSRankTerms.Include(r => r.Rank).Include(r => r.Language).Where(r => r.RankId == id);
            ViewBag.RankId = id;
            return View(rmsRankTerms.ToList());
        }

        // GET: RMS/RankTerms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            RMSRankTerm rmsRankTerm = db.RMSRankTerms.Include("Language").Include("Rank").Where(r => r.Id == id).FirstOrDefault();
            if (rmsRankTerm == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(rmsRankTerm);
        }

        // GET: RMS/RankTerms/Create
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            ViewBag.RankId = id;
            ViewBag.RankCode = db.RMSRanks.Find(id).Code;
            int[] assignedLanguages = db.RMSRankTerms.Where(r => r.RankId == id).Select(rt => rt.LanguageId).ToArray();
            ViewBag.LanguageId = new SelectList(db.RMSLanguages.Where(l => !assignedLanguages.Contains(l.Id) && l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name");
            return View();
        }

        // POST: RMS/RankTerms/Create To protect from overposting attacks,
        // please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LanguageId,Value,RankId")] RMSRankTerm rmsRankTerm)
        {
            if (ModelState.IsValid)
            {
                db.RMSRankTerms.Add(rmsRankTerm);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = rmsRankTerm.RankId });
            }
            ViewBag.RankId = rmsRankTerm.RankId;
            ViewBag.RankCode = db.RMSRanks.Find(rmsRankTerm.RankId).Code;
            int[] assignedLanguages = db.RMSRankTerms.Where(r => r.RankId == rmsRankTerm.RankId).Select(rt => rt.LanguageId).ToArray();
            ViewBag.LanguageId = new SelectList(db.RMSLanguages.Where(l => !assignedLanguages.Contains(l.Id) && l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name", rmsRankTerm.LanguageId);
            return View(rmsRankTerm);
        }

        // GET: RMS/RankTerms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            RMSRankTerm rmsRankTerm = db.RMSRankTerms.Find(id);
            if (rmsRankTerm == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            ViewBag.RankCode = db.RMSRanks.Find(rmsRankTerm.RankId).Code;
            int[] assignedLanguages = db.RMSRankTerms.Where(r => r.RankId == rmsRankTerm.RankId && r.LanguageId != rmsRankTerm.LanguageId).Select(rt => rt.LanguageId).ToArray();
            ViewBag.LanguageId = new SelectList(db.RMSLanguages.Where(l => !assignedLanguages.Contains(l.Id) && l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name", rmsRankTerm.LanguageId);
            return View(rmsRankTerm);
        }

        // POST: RMS/RankTerms/Edit/5 To protect from overposting attacks,
        // please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LanguageId,Value,RankId")] RMSRankTerm rmsRankTerm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rmsRankTerm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = rmsRankTerm.RankId });
            }
            ViewBag.RankCode = db.RMSRanks.Find(rmsRankTerm.RankId).Code;
            int[] assignedLanguages = db.RMSRankTerms.Where(r => r.RankId == rmsRankTerm.RankId && r.LanguageId != rmsRankTerm.LanguageId).Select(rt => rt.LanguageId).ToArray();
            ViewBag.LanguageId = new SelectList(db.RMSLanguages.Where(l => !assignedLanguages.Contains(l.Id) && l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name", rmsRankTerm.LanguageId);
            return View(rmsRankTerm);
        }

        // GET: RMS/RankTerms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            RMSRankTerm rmsRankTerm = db.RMSRankTerms.Include("Language").Include("Rank").Where(r => r.Id == id).FirstOrDefault();
            if (rmsRankTerm == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(rmsRankTerm);
        }

        // POST: RMS/RankTerms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RMSRankTerm rmsRankTerm = db.RMSRankTerms.Find(id);
            db.RMSRankTerms.Remove(rmsRankTerm);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = rmsRankTerm.RankId });
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