using cutecms_porto.Areas.Config.Models.DBModel;
using cutecms_porto.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace cutecms_porto.Areas.Config.Controllers
{
    public class ConfigStatusTermsController : BaseController
    {
        #region Fields
        private ConfigEntities db = new ConfigEntities();
        #endregion Fields
        #region Methods
        // GET: Config/ConfigStatusTerms
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            var configStatusTerms = db.ConfigStatusTerms.Include(s => s.Status).Include(s => s.Language).Where(s => s.StatusId == id);
            ViewBag.StatusId = id;
            return View(configStatusTerms.ToList());
        }

        // GET: Config/ConfigStatusTerms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            ConfigStatusTerm configStatusTerm = db.ConfigStatusTerms.Include("Language").Include("Status").Where(s => s.Id == id).FirstOrDefault();
            if (configStatusTerm == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(configStatusTerm);
        }

        // GET: Config/ConfigStatusTerms/Create
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            ViewBag.StatusId = id;
            ViewBag.ConfigStatusCode = db.Statuses.Find(id).Code;
            int[] assignedLanguages = db.ConfigStatusTerms.Where(t => t.StatusId == id).Select(t => t.LanguageId).ToArray();
            ViewBag.LanguageId = new SelectList(db.ConfigLanguages.Where(l => !assignedLanguages.Contains(l.Id) && l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name");
            return View();
        }

        // POST: Config/ConfigStatusTerms/Create To protect from overposting attacks,
        // please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LanguageId,Value,StatusId")] ConfigStatusTerm configStatusTerm)
        {
            if (ModelState.IsValid)
            {
                db.ConfigStatusTerms.Add(configStatusTerm);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = configStatusTerm.StatusId });
            }
            ViewBag.StatusId = configStatusTerm.StatusId;
            ViewBag.ConfigStatusCode = db.Statuses.Find(configStatusTerm.StatusId).Code;
            int[] assignedLanguages = db.ConfigStatusTerms.Where(t => t.StatusId == configStatusTerm.StatusId && t.LanguageId != configStatusTerm.LanguageId).Select(t => t.LanguageId).ToArray();
            ViewBag.LanguageId = new SelectList(db.ConfigLanguages.Where(l => !assignedLanguages.Contains(l.Id) && l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name", configStatusTerm.LanguageId);
            return View(configStatusTerm);
        }

        // GET: Config/ConfigStatusTerms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            ConfigStatusTerm configStatusTerm = db.ConfigStatusTerms.Find(id);
            if (configStatusTerm == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            int[] assignedLanguages = db.ConfigStatusTerms.Where(t => t.StatusId == configStatusTerm.StatusId && t.LanguageId != configStatusTerm.LanguageId).Select(t => t.LanguageId).ToArray();
            ViewBag.LanguageId = new SelectList(db.ConfigLanguages.Where(l => !assignedLanguages.Contains(l.Id) && l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name", configStatusTerm.LanguageId);
            return View(configStatusTerm);
        }

        // POST: Config/ConfigStatusTerms/Edit/5 To protect from overposting attacks,
        // please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LanguageId,Value,StatusId")] ConfigStatusTerm configStatusTerm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(configStatusTerm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = configStatusTerm.StatusId });
            }
            int[] assignedLanguages = db.ConfigStatusTerms.Where(t => t.StatusId == configStatusTerm.StatusId && t.LanguageId != configStatusTerm.LanguageId).Select(t => t.LanguageId).ToArray();
            ViewBag.LanguageId = new SelectList(db.ConfigLanguages.Where(l => !assignedLanguages.Contains(l.Id) && l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name", configStatusTerm.LanguageId);
            return View(configStatusTerm);
        }

        // GET: Config/ConfigStatusTerms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            ConfigStatusTerm configStatusTerm = db.ConfigStatusTerms.Include("Language").Include("Status").Where(s => s.Id == id).FirstOrDefault();
            if (configStatusTerm == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(configStatusTerm);
        }

        // POST: Config/ConfigStatusTerms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ConfigStatusTerm configStatusTerm = db.ConfigStatusTerms.Find(id);
            db.ConfigStatusTerms.Remove(configStatusTerm);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = configStatusTerm.StatusId });
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