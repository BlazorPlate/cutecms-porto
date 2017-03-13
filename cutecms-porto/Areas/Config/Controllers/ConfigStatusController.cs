using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using cutecms_porto.Areas.Config.Models.DBModel;
using cutecms_porto.Helpers;

namespace cutecms_porto.Areas.Config.Controllers
{
    [LocalizedAuthorize(Roles = "Admin")]
    public class ConfigStatusController : BaseController
    {
        private ConfigEntities db = new ConfigEntities();

        // GET: Config/ConfigStatus
        public ActionResult Index()
        {
            return View(db.Statuses.ToList());
        }

        // GET: Config/ConfigStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            ConfigStatus configStatus = db.Statuses.Find(id);
            if (configStatus == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(configStatus);
        }

        // GET: Config/ConfigStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            ConfigStatus configStatus = db.Statuses.Find(id);
            if (configStatus == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(configStatus);
        }

        // POST: Config/ConfigStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Code,Visible,Ordinal")] ConfigStatus configStatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(configStatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(configStatus);
        }

        // GET: Config/ConfigStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            ConfigStatus configStatus = db.Statuses.Find(id);
            if (configStatus == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(configStatus);
        }

        // POST: Config/ConfigStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ConfigStatus configStatus = db.Statuses.Find(id);
            db.Statuses.Remove(configStatus);
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
