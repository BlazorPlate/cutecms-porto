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
    [LocalizedAuthorize(Roles = "Admin,CMS,ContentTypes")]
    public class ContentTypesController : BaseController
    {
        #region Fields
        private CMSEntities db = new CMSEntities();
        #endregion Fields

        #region Methods
        // GET: CMS/ContentTypes
        public ActionResult Index()
        {
            return View(db.ContentTypes.ToList());
        }

        // GET: CMS/ContentTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            ContentType contentType = db.ContentTypes.Find(id);
            if (contentType == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(contentType);
        }

        // GET: CMS/ContentTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CMS/ContentTypes/Create To protect from overposting attacks, please enable the
        // specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Code,Visible,Ordinal")] ContentType contentType)
        {
            if (ModelState.IsValid)
            {
                db.ContentTypes.Add(contentType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contentType);
        }

        // GET: CMS/ContentTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            ContentType contentType = db.ContentTypes.Find(id);
            if (contentType == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(contentType);
        }

        // POST: CMS/ContentTypes/Edit/5 To protect from overposting attacks, please enable the
        // specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Code,Visible,Ordinal")] ContentType contentType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contentType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contentType);
        }

        // GET: CMS/ContentTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            ContentType contentType = db.ContentTypes.Find(id);
            if (contentType == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(contentType);
        }

        // POST: CMS/ContentTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContentType contentType = db.ContentTypes.Find(id);
            db.ContentTypes.Remove(contentType);
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