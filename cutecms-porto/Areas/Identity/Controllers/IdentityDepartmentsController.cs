using cutecms_porto.Areas.Identity.Models;
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

namespace cutecms_porto.Areas.Identity.Controllers
{
    [LocalizedAuthorize(Roles = "Admin")]
    public class IdentityDepartmentsController : BaseController
    {
        #region Fields
        private IdentityEntities db = new IdentityEntities();

        #endregion Fields

        #region Methods

        // GET: Identity/Departments
        public ActionResult Index()
        {
            DepartmentsViewModel departments = new DepartmentsViewModel();
            departments.DepartmentTerms = TermsHelper.Departments(null);
            departments.Departments = db.IdentityDepartments.Where(d => d.TenantId.Equals(Tenant.TenantId) && !d.DepartmentTerms.Where(dt => dt.Language.CultureName.Trim().Equals(Thread.CurrentThread.CurrentCulture.Name)).Any());
            return View(departments);
        }

        // GET: Identity/Departments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            IdentityDepartment department = db.IdentityDepartments.Where(d => d.TenantId.Equals(Tenant.TenantId) && d.Id == id).FirstOrDefault();
            if (department == null)
            {
                throw new HttpException(404, "Page Not Found");
            }

            return View(department);
        }

        // GET: Identity/Departments/Create
        public ActionResult Create()
        {
            ViewBag.ManagerId = new SelectList(db.Employees.Where(e => e.Language.CultureName.Trim().Equals(Thread.CurrentThread.CurrentCulture.Name)), "TranslationId", "FullName");
            ViewBag.ParentId = new SelectList(TermsHelper.GetDepartmentTree(Thread.CurrentThread.CurrentCulture.Name), "Id", "Name");
            return View();
        }

        // POST: Identity/Departments/Create To protect from overposting attacks, please enable the
        // specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Code,ManagerId,TypeId,ParentId,Ordinal")] IdentityDepartment department)
        {
            if (ModelState.IsValid)
            {
                department.TenantId = Tenant.TenantId;
                db.IdentityDepartments.Add(department);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ManagerId = new SelectList(db.Employees.Where(e => e.Language.CultureName.Trim().Equals(Thread.CurrentThread.CurrentCulture.Name)), "TranslationId", "FullName", department.ManagerId);
            ViewBag.ParentId = new SelectList(TermsHelper.GetDepartmentTree(Thread.CurrentThread.CurrentCulture.Name), "Id", "Name", department.ParentId);
            return View(department);
        }

        // GET: Identity/Departments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            IdentityDepartment department = db.IdentityDepartments.Where(d => d.TenantId.Equals(Tenant.TenantId) && d.Id == id).FirstOrDefault();
            if (department == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            ViewBag.ManagerId = new SelectList(db.Employees.Where(e => e.Language.CultureName.Trim().Equals(Thread.CurrentThread.CurrentCulture.Name)), "TranslationId", "FullName", department.ManagerId);
            ViewBag.ParentId = new SelectList(TermsHelper.GetDepartmentTree(Thread.CurrentThread.CurrentCulture.Name), "Id", "Name", department.ParentId);
            return View(department);
        }

        // POST: Identity/Departments/Edit/5 To protect from overposting attacks, please enable the
        // specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Code,ManagerId,TypeId,ParentId,Ordinal")] IdentityDepartment department)
        {
            if (ModelState.IsValid)
            {
                department.TenantId = Tenant.TenantId;
                db.Entry(department).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ManagerId = new SelectList(db.Employees.Where(e => e.Language.CultureName.Trim().Equals(Thread.CurrentThread.CurrentCulture.Name)), "TranslationId", "FullName", department.ManagerId);
            ViewBag.ParentId = new SelectList(TermsHelper.GetDepartmentTree(Thread.CurrentThread.CurrentCulture.Name), "Id", "Name", department.ParentId);
            return View(department);
        }

        // GET: Identity/Departments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            IdentityDepartment department = db.IdentityDepartments.Where(d => d.TenantId.Equals(Tenant.TenantId) && d.Id == id).FirstOrDefault();
            if (department == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(department);
        }

        // POST: Identity/Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IdentityDepartment department = db.IdentityDepartments.Find(id);
            db.IdentityDepartments.Remove(department);
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