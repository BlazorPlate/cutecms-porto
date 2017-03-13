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
    public class CategoryTermsController : BaseController
    {
        #region Fields
        private CMSEntities db = new CMSEntities();
        #endregion Fields

        #region Methods
        // GET: CMS/CategoryTerms
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            var categoryTerms = db.CategoryTerms.Include(c => c.Category).Include(c => c.Language).Where(c => c.CategoryId == id);
            ViewBag.CategoryId = id;
            return View(categoryTerms.ToList());
        }

        // GET: CMS/CategoryTerms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            CategoryTerm categoryTerm = db.CategoryTerms.Include("Language").Include("Category").Where(c => c.Id == id).FirstOrDefault();
            if (categoryTerm == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(categoryTerm);
        }

        // GET: CMS/CategoryTerms/Create
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            ViewBag.CategoryId = id;
            ViewBag.CategoryCode = db.Categories.Find(id).Code;
            int[] assignedLanguages = db.CategoryTerms.Where(t => t.CategoryId == id).Select(t => t.LanguageId).ToArray();
            ViewBag.LanguageId = new SelectList(db.CMSLanguages.Where(l => !assignedLanguages.Contains(l.Id) && l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name");
            return View();
        }

        // POST: CMS/CategoryTerms/Create To protect from overposting attacks,
        // please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LanguageId,Value,CategoryId")] CategoryTerm categoryTerm)
        {
            if (ModelState.IsValid)
            {
                db.CategoryTerms.Add(categoryTerm);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = categoryTerm.CategoryId });
            }
            ViewBag.CategoryId = categoryTerm.CategoryId;
            ViewBag.CategoryCode = db.Categories.Find(categoryTerm.CategoryId).Code;
            int[] assignedLanguages = db.CategoryTerms.Where(t => t.CategoryId == categoryTerm.CategoryId && t.LanguageId != categoryTerm.LanguageId).Select(t => t.LanguageId).ToArray();
            ViewBag.LanguageId = new SelectList(db.CMSLanguages.Where(l => !assignedLanguages.Contains(l.Id) && l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name", categoryTerm.LanguageId);
            return View(categoryTerm);
        }

        // GET: CMS/CategoryTerms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            CategoryTerm categoryTerm = db.CategoryTerms.Find(id);
            if (categoryTerm == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            ViewBag.CategoryCode = db.Categories.Find(categoryTerm.CategoryId).Code;
            int[] assignedLanguages = db.CategoryTerms.Where(t => t.CategoryId == categoryTerm.CategoryId && t.LanguageId != categoryTerm.LanguageId).Select(t => t.LanguageId).ToArray();
            ViewBag.LanguageId = new SelectList(db.CMSLanguages.Where(l => !assignedLanguages.Contains(l.Id) && l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name", categoryTerm.LanguageId);
            return View(categoryTerm);
        }

        // POST: CMS/CategoryTerms/Edit/5 To protect from overposting attacks,
        // please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LanguageId,Value,CategoryId")] CategoryTerm categoryTerm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoryTerm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = categoryTerm.CategoryId });
            }
            int[] assignedLanguages = db.CategoryTerms.Where(t => t.CategoryId == categoryTerm.CategoryId && t.LanguageId != categoryTerm.LanguageId).Select(t => t.LanguageId).ToArray();
            ViewBag.LanguageId = new SelectList(db.CMSLanguages.Where(l => !assignedLanguages.Contains(l.Id) && l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name", categoryTerm.LanguageId);
            return View(categoryTerm);
        }

        // GET: CMS/CategoryTerms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            CategoryTerm categoryTerm = db.CategoryTerms.Include("Language").Include("Category").Where(c => c.Id == id).FirstOrDefault();
            if (categoryTerm == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(categoryTerm);
        }

        // POST: CMS/CategoryTerms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CategoryTerm categoryTerm = db.CategoryTerms.Find(id);
            db.CategoryTerms.Remove(categoryTerm);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = categoryTerm.CategoryId });
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