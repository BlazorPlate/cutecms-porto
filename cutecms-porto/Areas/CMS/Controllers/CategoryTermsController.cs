using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using cutecms_porto.Areas.CMS.Models.DBModel;
using cutecms_porto.Helpers;

namespace cutecms_porto.Areas.CMS.Controllers
{
    public class CategoryTermsController : BaseController
    {
        private CMSEntities db = new CMSEntities();

        // GET: CMS/CategoryTerms
        public ActionResult Index()
        {
            var categoryTerms = db.CategoryTerms.Include(c => c.Category);
            return View(categoryTerms.ToList());
        }

        // GET: CMS/CategoryTerms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryTerm categoryTerm = db.CategoryTerms.Find(id);
            if (categoryTerm == null)
            {
                return HttpNotFound();
            }
            return View(categoryTerm);
        }

        // GET: CMS/CategoryTerms/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "TenantId");
            return View();
        }

        // POST: CMS/CategoryTerms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LanguageId,Value,CategoryId")] CategoryTerm categoryTerm)
        {
            if (ModelState.IsValid)
            {
                db.CategoryTerms.Add(categoryTerm);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "TenantId", categoryTerm.CategoryId);
            return View(categoryTerm);
        }

        // GET: CMS/CategoryTerms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryTerm categoryTerm = db.CategoryTerms.Find(id);
            if (categoryTerm == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "TenantId", categoryTerm.CategoryId);
            return View(categoryTerm);
        }

        // POST: CMS/CategoryTerms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LanguageId,Value,CategoryId")] CategoryTerm categoryTerm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoryTerm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "TenantId", categoryTerm.CategoryId);
            return View(categoryTerm);
        }

        // GET: CMS/CategoryTerms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryTerm categoryTerm = db.CategoryTerms.Find(id);
            if (categoryTerm == null)
            {
                return HttpNotFound();
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
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
