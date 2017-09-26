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
    [LocalizedAuthorize(Roles = "Admin,Config,Notifications")]
    public class NotificationsController : BaseController
    {
        private ConfigEntities db = new ConfigEntities();

        // GET: Config/Notifications
        public ActionResult Index()
        {
            var notifications = db.Notifications.Include(n => n.NotificationCode).Include(n => n.SMTPSetting);
            return View(notifications.ToList());
        }

        // GET: Config/Notifications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            Notification notification = db.Notifications.Find(id);
            if (notification == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(notification);
        }

        // GET: Config/Notifications/Create
        public ActionResult Create()
        {
            ViewBag.CodeId = new SelectList(db.NotificationCodes, "Id", "Code");
            ViewBag.SMTPId = new SelectList(db.SMTPSettings, "Id", "Code");
            return View();
        }

        // POST: Config/Notifications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CodeId,SMTPId")] Notification notification)
        {
            if (ModelState.IsValid)
            {
                db.Notifications.Add(notification);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CodeId = new SelectList(db.NotificationCodes, "Id", "Code", notification.CodeId);
            ViewBag.SMTPId = new SelectList(db.SMTPSettings, "Id", "Code", notification.SMTPId);
            return View(notification);
        }

        // GET: Config/Notifications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            Notification notification = db.Notifications.Find(id);
            if (notification == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            ViewBag.CodeId = new SelectList(db.NotificationCodes, "Id", "Code", notification.CodeId);
            ViewBag.SMTPId = new SelectList(db.SMTPSettings, "Id", "Code", notification.SMTPId);
            return View(notification);
        }

        // POST: Config/Notifications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CodeId,SMTPId")] Notification notification)
        {
            if (ModelState.IsValid)
            {
                db.Entry(notification).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CodeId = new SelectList(db.NotificationCodes, "Id", "Code", notification.CodeId);
            ViewBag.SMTPId = new SelectList(db.SMTPSettings, "Id", "Code", notification.SMTPId);
            return View(notification);
        }

        // GET: Config/Notifications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            Notification notification = db.Notifications.Find(id);
            if (notification == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(notification);
        }

        // POST: Config/Notifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Notification notification = db.Notifications.Find(id);
            db.Notifications.Remove(notification);
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
