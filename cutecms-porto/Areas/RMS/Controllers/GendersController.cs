using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using cutecms_porto.Areas.RMS.Models.DBModel;
using cutecms_porto.Helpers;

namespace cutecms_porto.Areas.RMS.Controllers
{
    public class GendersController : BaseController
    {
        private RMSEntities db = new RMSEntities();

        // GET: RMS/Genders
        public ActionResult Index()
        {
            return View(db.Genders.ToList());
        }

        // GET: RMS/Genders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            Gender gender = db.Genders.Find(id);
            if (gender == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(gender);
        }

        // GET: RMS/Genders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RMS/Genders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Code,Visible,Ordinal")] Gender gender)
        {
            if (ModelState.IsValid)
            {
                db.Genders.Add(gender);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gender);
        }

        // GET: RMS/Genders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            Gender gender = db.Genders.Find(id);
            if (gender == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(gender);
        }

        // POST: RMS/Genders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Code,Visible,Ordinal")] Gender gender)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gender).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gender);
        }

        // GET: RMS/Genders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            Gender gender = db.Genders.Find(id);
            if (gender == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(gender);
        }

        // POST: RMS/Genders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gender gender = db.Genders.Find(id);
            db.Genders.Remove(gender);
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
