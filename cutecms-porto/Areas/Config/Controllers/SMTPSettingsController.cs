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
    public class SMTPSettingsController : BaseController
    {
        private ConfigEntities db = new ConfigEntities();

        // GET: Config/SMTPSettings
        public ActionResult Index()
        {
            return View(db.SMTPSettings.ToList());
        }

        // GET: Config/SMTPSettings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            SMTPSetting sMTPSetting = db.SMTPSettings.Find(id);
            if (sMTPSetting == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(sMTPSetting);
        }

        // GET: Config/SMTPSettings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Config/SMTPSettings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Code,SMTP,Port,EnableSsl,SenderEmail,SenderPasswordHash,RecipientEmail,Visible,Ordinal")] SMTPSetting sMTPSetting)
        {
            if (ModelState.IsValid)
            {
                db.SMTPSettings.Add(sMTPSetting);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sMTPSetting);
        }

        // GET: Config/SMTPSettings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            SMTPSetting sMTPSetting = db.SMTPSettings.Find(id);
            if (sMTPSetting == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(sMTPSetting);
        }

        // POST: Config/SMTPSettings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Code,SMTP,Port,EnableSsl,SenderEmail,SenderPasswordHash,RecipientEmail,Visible,Ordinal")] SMTPSetting sMTPSetting)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sMTPSetting).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sMTPSetting);
        }

        // GET: Config/SMTPSettings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            SMTPSetting sMTPSetting = db.SMTPSettings.Find(id);
            if (sMTPSetting == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(sMTPSetting);
        }

        // POST: Config/SMTPSettings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SMTPSetting sMTPSetting = db.SMTPSettings.Find(id);
            db.SMTPSettings.Remove(sMTPSetting);
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
