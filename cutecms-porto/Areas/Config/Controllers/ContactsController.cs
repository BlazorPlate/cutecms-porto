using cutecms_porto.Areas.Config.Models.DBModel;
using cutecms_porto.Areas.Identity.Models.DBModel;
using cutecms_porto.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace cutecms_porto.Areas.Config.Controllers
{
    [LocalizedAuthorize(Roles = "Admin")]
    public class ContactsController : BaseController
    {
        #region Fields
        private ConfigEntities db = new ConfigEntities();
        private IdentityEntities identityDb = new IdentityEntities();
        private List<object> DepartmentsList = new List<object>();
        private string departmentPath = "";
        #endregion Fields

        #region Methods

        // GET: CMS/Contacts
        public ActionResult Index(int? id)
        {
            var contacts = db.Contacts.Include("PersonalTitle").Include("PersonalTitle.PersonalTitleTerms").Include("PersonalTitle.PersonalTitleTerms.Language").Include("Department").Include("Department.DepartmentTerms").Include("Department.DepartmentTerms.Language").Include("Organization").Where(c => c.OrganizationId == id);
            ViewBag.OrganizationId = id;
            return View(contacts.ToList());
        }

        // GET: CMS/Contacts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            Contact contact = db.Contacts.Include("PersonalTitle").Include("PersonalTitle.PersonalTitleTerms").Include("PersonalTitle.PersonalTitleTerms.Language").Include("Department").Include("Department.DepartmentTerms").Include("Department.DepartmentTerms.Language").Where(c => c.Id == id).FirstOrDefault();
            if (contact == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            ViewBag.OrganizationId = contact.OrganizationId;
            return View(contact);
        }

        // GET: CMS/Contacts/Create
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            ViewBag.PersonalTitleId = new SelectList(TermsHelper.PersonalTitles(), "PersonalTitleId", "Value");
            ViewBag.DepartmentId = new SelectList(TermsHelper.GetDepartmentTree(Thread.CurrentThread.CurrentCulture.Name), "Id", "Name");
            ViewBag.OrganizationId = id;
            ViewBag.OrganizationName = db.Organizations.Find(id).Name;
            return View();
        }

        // POST: CMS/Contacts/Create To protect from overposting attacks, please enable the specific
        // properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PersonalTitleId,Name,Position,DepartmentId,Office,Email,Ordinal,OrganizationId")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Contacts.Add(contact);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = contact.OrganizationId });
            }
            ViewBag.PersonalTitleId = new SelectList(TermsHelper.PersonalTitles(), "PersonalTitleId", "Value", contact.PersonalTitleId);
            ViewBag.DepartmentId = new SelectList(TermsHelper.GetDepartmentTree(Thread.CurrentThread.CurrentCulture.Name), "Id", "Name", contact.DepartmentId);
            ViewBag.OrganizationId = contact.OrganizationId;
            ViewBag.OrganizationName = db.Organizations.Find(contact.OrganizationId).Name;
            return View(contact);
        }

        // GET: CMS/Contacts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            ViewBag.PersonalTitleId = new SelectList(TermsHelper.PersonalTitles(), "PersonalTitleId", "Value", contact.PersonalTitleId);
            ViewBag.DepartmentId = new SelectList(TermsHelper.GetDepartmentTree(Thread.CurrentThread.CurrentCulture.Name), "Id", "Name", contact.DepartmentId);
            ViewBag.OrganizationId = contact.OrganizationId;
            ViewBag.OrganizationName = db.Organizations.Find(contact.OrganizationId).Name;
            return View(contact);
        }

        // POST: CMS/Contacts/Edit/5 To protect from overposting attacks, please enable the specific
        // properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PersonalTitleId,Name,Position,DepartmentId,Office,Email,Ordinal,OrganizationId")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = contact.OrganizationId });
            }
            ViewBag.PersonalTitleId = new SelectList(TermsHelper.PersonalTitles(), "PersonalTitleId", "Value", contact.PersonalTitleId);
            ViewBag.DepartmentId = new SelectList(TermsHelper.GetDepartmentTree(Thread.CurrentThread.CurrentCulture.Name), "Id", "Name", contact.DepartmentId);
            ViewBag.OrganizationId = contact.OrganizationId;
            ViewBag.OrganizationName = db.Organizations.Find(contact.OrganizationId).Name;
            return View(contact);
        }

        // GET: CMS/Contacts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            Contact contact = db.Contacts.Include("PersonalTitle").Include("PersonalTitle.PersonalTitleTerms").Include("PersonalTitle.PersonalTitleTerms.Language").Include("Department").Include("Department.DepartmentTerms").Include("Department.DepartmentTerms.Language").Where(c => c.Id == id).FirstOrDefault();
            if (contact == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            ViewBag.OrganizationId = contact.OrganizationId;
            return View(contact);
        }

        // POST: CMS/Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contact contact = db.Contacts.Find(id);
            db.Contacts.Remove(contact);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = contact.OrganizationId });
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