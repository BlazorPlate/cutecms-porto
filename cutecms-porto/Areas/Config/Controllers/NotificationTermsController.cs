using cutecms_porto.Areas.Config.Models.DBModel;
using cutecms_porto.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace cutecms_porto.Areas.Config.Controllers
{
    [LocalizedAuthorize(Roles = "Admin")]
    public class NotificationTermsController : BaseController
    {
        #region Fields
        private ConfigEntities db = new ConfigEntities();
        #endregion Fields

        #region Methods
        // GET: RMS/NotificationTerms
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            var notificationTerms = db.NotificationTerms.Include(n => n.Notification).Include(n => n.Language).Where(n => n.NotificationId == id);
            ViewBag.NotificationId = id;
            return View(notificationTerms.ToList());
        }

        // GET: RMS/NotificationTerms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            NotificationTerm notificationTerm = db.NotificationTerms.Include("Language").Include("Notification.NotificationCode").Where(n => n.Id == id).FirstOrDefault();
            if (notificationTerm == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(notificationTerm);
        }

        // GET: RMS/NotificationTerms/Create
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            ViewBag.NotificationId = id;
            ViewBag.NotificationCode = db.Notifications.Find(id).NotificationCode.Code;
            int[] assignedLanguages = db.NotificationTerms.Where(t => t.NotificationId == id).Select(t => t.LanguageId).ToArray();
            ViewBag.LanguageId = new SelectList(db.ConfigLanguages.Where(l => !assignedLanguages.Contains(l.Id) && l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name");
            return View();
        }

        // POST: RMS/NotificationTerms/Create To protect from overposting attacks,
        // please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LanguageId,Subject,Body,NotificationId")] NotificationTerm notificationTerm)
        {
            if (ModelState.IsValid)
            {
                db.NotificationTerms.Add(notificationTerm);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = notificationTerm.NotificationId });
            }
            ViewBag.NotificationId = notificationTerm.NotificationId;
            ViewBag.NotificationCode = db.NotificationCodes.Find(notificationTerm.NotificationId).Code;
            int[] assignedLanguages = db.NotificationTerms.Where(t => t.NotificationId == notificationTerm.NotificationId && t.LanguageId != notificationTerm.LanguageId).Select(t => t.LanguageId).ToArray();
            ViewBag.LanguageId = new SelectList(db.ConfigLanguages.Where(l => !assignedLanguages.Contains(l.Id) && l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name", notificationTerm.LanguageId);
            return View(notificationTerm);
        }

        // GET: RMS/NotificationTerms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            NotificationTerm notificationTerm = db.NotificationTerms.Find(id);
            if (notificationTerm == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            ViewBag.NotificationCode = db.NotificationCodes.Find(notificationTerm.NotificationId).Code;
            int[] assignedLanguages = db.NotificationTerms.Where(t => t.NotificationId == notificationTerm.NotificationId && t.LanguageId != notificationTerm.LanguageId).Select(t => t.LanguageId).ToArray();
            ViewBag.LanguageId = new SelectList(db.ConfigLanguages.Where(l => !assignedLanguages.Contains(l.Id) && l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name", notificationTerm.LanguageId);
            return View(notificationTerm);
        }

        // POST: RMS/NotificationTerms/Edit/5 To protect from overposting attacks,
        // please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LanguageId,Subject,Body,NotificationId")] NotificationTerm notificationTerm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(notificationTerm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = notificationTerm.NotificationId });
            }
            ViewBag.NotificationCode = db.NotificationCodes.Find(notificationTerm.NotificationId).Code;
            int[] assignedLanguages = db.NotificationTerms.Where(t => t.NotificationId == notificationTerm.NotificationId && t.LanguageId != notificationTerm.LanguageId).Select(t => t.LanguageId).ToArray();
            ViewBag.LanguageId = new SelectList(db.ConfigLanguages.Where(l => !assignedLanguages.Contains(l.Id) && l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name", notificationTerm.LanguageId);
            return View(notificationTerm);
        }

        // GET: RMS/NotificationTerms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            NotificationTerm notificationTerm = db.NotificationTerms.Include("Language").Include("Notification.NotificationCode").Where(n => n.Id == id).FirstOrDefault();
            if (notificationTerm == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(notificationTerm);
        }

        // POST: RMS/NotificationTerms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NotificationTerm notificationTerm = db.NotificationTerms.Include("Language").Include("Notification").Where(n => n.Id == id).FirstOrDefault();
            db.NotificationTerms.Remove(notificationTerm);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = notificationTerm.NotificationId });
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