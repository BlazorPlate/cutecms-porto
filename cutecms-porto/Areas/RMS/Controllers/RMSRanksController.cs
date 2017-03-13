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
    [LocalizedAuthorize(Roles = "Admin")]
    public class RMSRanksController : BaseController
    {
        #region Fields
        private RMSEntities db = new RMSEntities();
        #endregion Fields

        #region Methods
        // GET: RMS/RMSRanks
        public ActionResult Index()
        {
            return View(db.RMSRanks.ToList());
        }

        // GET: RMS/RMSRanks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            RMSRank rMSRank = db.RMSRanks.Find(id);
            if (rMSRank == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(rMSRank);
        }

        // GET: RMS/RMSRanks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RMS/RMSRanks/Create To protect from overposting attacks, please enable the specific
        // properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Code,Visible,Ordinal")] RMSRank rMSRank)
        {
            if (ModelState.IsValid)
            {
                db.RMSRanks.Add(rMSRank);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rMSRank);
        }

        // GET: RMS/RMSRanks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            RMSRank rMSRank = db.RMSRanks.Find(id);
            if (rMSRank == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(rMSRank);
        }

        // POST: RMS/RMSRanks/Edit/5 To protect from overposting attacks, please enable the specific
        // properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Code,Visible,Ordinal")] RMSRank rMSRank)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rMSRank).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rMSRank);
        }

        // GET: RMS/RMSRanks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            RMSRank rMSRank = db.RMSRanks.Find(id);
            if (rMSRank == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(rMSRank);
        }

        // POST: RMS/RMSRanks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RMSRank rMSRank = db.RMSRanks.Find(id);
            db.RMSRanks.Remove(rMSRank);
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