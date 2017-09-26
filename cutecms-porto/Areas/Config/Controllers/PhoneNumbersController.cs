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
    [LocalizedAuthorize(Roles = "Admin,Config,Organizations")]
    public class PhoneNumbersController : BaseController
    {
        #region Fields
        private ConfigEntities db = new ConfigEntities();
        #endregion Fields

        #region Methods
        // GET: CMS/PhoneNumbers
        public ActionResult Index(int? contactId)
        {
            var phoneNumbers = db.PhoneNumbers.Include(p => p.Contact).Where(c => c.ContactId == contactId);
            ViewBag.ContactId = contactId;
            ViewBag.OrganizationId = db.Contacts.Find(contactId).OrganizationId;
            return View(phoneNumbers.ToList());
        }

        // GET: CMS/PhoneNumbers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            PhoneNumber phonesNumber = db.PhoneNumbers.Find(id);
            ViewBag.ContactId = phonesNumber.ContactId;
            if (phonesNumber == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(phonesNumber);
        }

        // GET: CMS/PhoneNumbers/Create
        public ActionResult Create(int? contactId)
        {
            if (contactId == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            ViewBag.ContactId = contactId;
            ViewBag.ContactName = db.Contacts.Find(contactId).Name;
            return View();
        }

        // POST: CMS/PhoneNumbers/Create To protect from overposting attacks, please enable the
        // specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Number,Extension,ContactId")] PhoneNumber phonesNumber)
        {
            if (ModelState.IsValid)
            {
                db.PhoneNumbers.Add(phonesNumber);
                db.SaveChanges();
                return RedirectToAction("Index", new { contactId = phonesNumber.ContactId });
            }
            ViewBag.ContactId = phonesNumber.ContactId;
            ViewBag.ContactName = db.Contacts.Find(phonesNumber.ContactId).Name;
            return View(phonesNumber);
        }

        // GET: CMS/PhoneNumbers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            PhoneNumber phonesNumber = db.PhoneNumbers.Find(id);
            if (phonesNumber == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            ViewBag.ContactId = phonesNumber.ContactId;
            ViewBag.ContactName = db.Contacts.Find(phonesNumber.ContactId).Name;
            return View(phonesNumber);
        }

        // POST: CMS/PhoneNumbers/Edit/5 To protect from overposting attacks, please enable the
        // specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Number,Extension,ContactId")] PhoneNumber phonesNumber)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phonesNumber).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { contactId = phonesNumber.ContactId });
            }
            ViewBag.ContactId = new SelectList(db.Contacts, "Id", "Code", phonesNumber.ContactId);
            return View(phonesNumber);
        }

        // GET: CMS/PhoneNumbers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            PhoneNumber phonesNumber = db.PhoneNumbers.Find(id);
            ViewBag.ContactId = phonesNumber.ContactId;
            if (phonesNumber == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(phonesNumber);
        }

        // POST: CMS/PhoneNumbers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PhoneNumber phonesNumber = db.PhoneNumbers.Find(id);
            db.PhoneNumbers.Remove(phonesNumber);
            db.SaveChanges();
            return RedirectToAction("Index", new { contactId = phonesNumber.ContactId });
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