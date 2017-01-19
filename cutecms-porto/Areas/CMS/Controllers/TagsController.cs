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
    public class TagsController : BaseController
    {
        #region Fields
        private CMSEntities db = new CMSEntities();
        #endregion Fields

        #region Methods
        // GET: CMS/Tags
        public ActionResult Index()
        {
            var tags = db.Tags.Where(t => t.TenantId.Trim().Equals(Tenant.TenantId)).ToList();
            return View(tags);
        }

        // GET: CMS/Tags/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            Tag tag = db.Tags.Where(t => t.TenantId.Trim().Equals(Tenant.TenantId) && t.Id == id).FirstOrDefault();
            if (tag == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(tag);
        }

        // GET: CMS/Tags/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CMS/Tags/Create To protect from overposting attacks, please enable the specific
        // properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Code,Visible,Ordinal")] Tag tag)
        {
            if (ModelState.IsValid)
            {
                db.Tags.Add(tag);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tag);
        }

        // GET: CMS/Tags/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            Tag tag = db.Tags.Where(t => t.TenantId.Trim().Equals(Tenant.TenantId) && t.Id == id).FirstOrDefault();
            if (tag == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(tag);
        }

        // POST: CMS/Tags/Edit/5 To protect from overposting attacks, please enable the specific
        // properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Code,Visible,Ordinal")] Tag tag)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tag).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tag);
        }

        // GET: CMS/Tags/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            Tag tag = db.Tags.Where(t => t.TenantId.Trim().Equals(Tenant.TenantId) && t.Id == id).FirstOrDefault();
            if (tag == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(tag);
        }

        // POST: CMS/Tags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tag tag = db.Tags.Find(id);
            db.Tags.Remove(tag);
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