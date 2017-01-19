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
    public class IdentityPersonalTitlesController : BaseController
    {
        #region Fields
        private IdentityEntities db = new IdentityEntities();
        #endregion Fields

        #region Methods
        // GET: Identity/IdentityPersonalTitles
        public ActionResult Index()
        {
            return View(db.IdentityPersonalTitles.ToList());
        }

        // GET: Identity/IdentityPersonalTitles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            IdentityPersonalTitle identityPersonalTitle = db.IdentityPersonalTitles.Find(id);
            if (identityPersonalTitle == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(identityPersonalTitle);
        }

        // GET: Identity/IdentityPersonalTitles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Identity/IdentityPersonalTitles/Create To protect from overposting attacks, please
        // enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Code,Visible,Ordinal")] IdentityPersonalTitle identityPersonalTitle)
        {
            if (ModelState.IsValid)
            {
                db.IdentityPersonalTitles.Add(identityPersonalTitle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(identityPersonalTitle);
        }

        // GET: Identity/IdentityPersonalTitles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            IdentityPersonalTitle identityPersonalTitle = db.IdentityPersonalTitles.Find(id);
            if (identityPersonalTitle == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(identityPersonalTitle);
        }

        // POST: Identity/IdentityPersonalTitles/Edit/5 To protect from overposting attacks, please
        // enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Code,Visible,Ordinal")] IdentityPersonalTitle identityPersonalTitle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(identityPersonalTitle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(identityPersonalTitle);
        }

        // GET: Identity/IdentityPersonalTitles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            IdentityPersonalTitle identityPersonalTitle = db.IdentityPersonalTitles.Find(id);
            if (identityPersonalTitle == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(identityPersonalTitle);
        }

        // POST: Identity/IdentityPersonalTitles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IdentityPersonalTitle identityPersonalTitle = db.IdentityPersonalTitles.Find(id);
            db.IdentityPersonalTitles.Remove(identityPersonalTitle);
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
        #endregion Methods
    }
}