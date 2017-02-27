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
    public class RMSProgramTermsController : BaseController
    {
        #region Fields
        private RMSEntities db = new RMSEntities();
        #endregion Fields

        #region Methods
        // GET: RMS/ProgramTerms
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            var rmsProgramTerms = db.RMSProgramTerms.Include(p => p.Program).Include(p => p.Language).Where(p => p.ProgramId == id);
            ViewBag.ProgramId = id;
            return View(rmsProgramTerms.ToList());
        }

        // GET: RMS/ProgramTerms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            RMSProgramTerm rmsProgramTerm = db.RMSProgramTerms.Include("Language").Include("Program").Where(p => p.Id == id).FirstOrDefault();
            if (rmsProgramTerm == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(rmsProgramTerm);
        }

        // GET: RMS/ProgramTerms/Create
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            ViewBag.ProgramId = id;
            ViewBag.ProgramCode = db.RMSPrograms.Find(id).Code;
            int[] assignedLanguages = db.RMSProgramTerms.Where(t => t.ProgramId == id).Select(t => t.LanguageId).ToArray();
            ViewBag.LanguageId = new SelectList(db.RMSLanguages.Where(l => !assignedLanguages.Contains(l.Id) && l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name");
            return View();
        }

        // POST: RMS/ProgramTerms/Create To protect from overposting attacks,
        // please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LanguageId,Value,ProgramId")] RMSProgramTerm rmsProgramTerm)
        {
            if (ModelState.IsValid)
            {
                db.RMSProgramTerms.Add(rmsProgramTerm);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = rmsProgramTerm.ProgramId });
            }
            ViewBag.ProgramId = rmsProgramTerm.ProgramId;
            ViewBag.ProgramCode = db.RMSPrograms.Find(rmsProgramTerm.ProgramId).Code;
            int[] assignedLanguages = db.RMSProgramTerms.Where(t => t.ProgramId == rmsProgramTerm.ProgramId && t.LanguageId != rmsProgramTerm.LanguageId).Select(t => t.LanguageId).ToArray();
            ViewBag.LanguageId = new SelectList(db.RMSLanguages.Where(l => !assignedLanguages.Contains(l.Id) && l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name", rmsProgramTerm.LanguageId);
            return View(rmsProgramTerm);
        }

        // GET: RMS/ProgramTerms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            RMSProgramTerm rmsProgramTerm = db.RMSProgramTerms.Find(id);
            if (rmsProgramTerm == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            ViewBag.ProgramCode = db.RMSPrograms.Find(rmsProgramTerm.ProgramId).Code;
            int[] assignedLanguages = db.RMSProgramTerms.Where(t => t.ProgramId == rmsProgramTerm.ProgramId && t.LanguageId != rmsProgramTerm.LanguageId).Select(t => t.LanguageId).ToArray();
            ViewBag.LanguageId = new SelectList(db.RMSLanguages.Where(l => !assignedLanguages.Contains(l.Id) && l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name", rmsProgramTerm.LanguageId);
            return View(rmsProgramTerm);
        }

        // POST: RMS/ProgramTerms/Edit/5 To protect from overposting attacks,
        // please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LanguageId,Value,ProgramId")] RMSProgramTerm rmsProgramTerm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rmsProgramTerm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = rmsProgramTerm.ProgramId });
            }
            ViewBag.ProgramCode = db.RMSPrograms.Find(rmsProgramTerm.ProgramId).Code;
            int[] assignedLanguages = db.RMSProgramTerms.Where(t => t.ProgramId == rmsProgramTerm.ProgramId && t.LanguageId != rmsProgramTerm.LanguageId).Select(t => t.LanguageId).ToArray();
            ViewBag.LanguageId = new SelectList(db.RMSLanguages.Where(l => !assignedLanguages.Contains(l.Id) && l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name", rmsProgramTerm.LanguageId);
            return View(rmsProgramTerm);
        }

        // GET: RMS/ProgramTerms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            RMSProgramTerm rmsProgramTerm = db.RMSProgramTerms.Include("Language").Include("Program").Where(p => p.Id == id).FirstOrDefault();
            if (rmsProgramTerm == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(rmsProgramTerm);
        }

        // POST: RMS/ProgramTerms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RMSProgramTerm rmsProgramTerm = db.RMSProgramTerms.Find(id);
            db.RMSProgramTerms.Remove(rmsProgramTerm);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = rmsProgramTerm.ProgramId });
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