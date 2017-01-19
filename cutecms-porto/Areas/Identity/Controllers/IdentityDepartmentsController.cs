using cutecms_porto.Areas.CMS.Models.DBModel;
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
    [Authorize(Roles = "Admin")]
    public class IdentityDepartmentsController : BaseController
    {
        #region Fields
        private IdentityEntities db = new IdentityEntities();
        private List<object> DepartmentsList = new List<object>();
        private string departmentPath = "";
        #endregion Fields

        #region Methods
        public string GetParents(IdentityDepartment element, int? languageId)
        {
            if (element.ParentId == null)
            {
                departmentPath = element.DepartmentTerms.Where(d => d.DepartmentId == element.Id && d.LanguageId == languageId).FirstOrDefault().Value + "/" + departmentPath;
                return departmentPath;
            }
            IdentityDepartment department = element;
            departmentPath = db.IdentityDepartmentTerms.Where(d => d.DepartmentId == element.Id && d.LanguageId == languageId).FirstOrDefault().Value + "/" + departmentPath;
            GetParents(db.IdentityDepartments.Find(department.ParentId), languageId);
            return departmentPath;
        }

        public List<object> GetDepartmentsServerSide(int? languageId)
        {
            foreach (var item in TermsHelper.DepartmentList(languageId))
            {
                DepartmentsList.Add(new
                {
                    Id = item.DepartmentId,
                    Name = GetParents(item.Department, languageId)
                }
                 );
                departmentPath = "";
            }
            return DepartmentsList;
        }

        // GET: Identity/Departments
        public ActionResult Index(int? languageId)
        {
            DepartmentsViewModel departments = new DepartmentsViewModel();
            departments.DepartmentWithTerms = TermsHelper.DepartmentList(languageId);
            departments.Departments = db.IdentityDepartments.Where(i => i.DepartmentTerms.Where(d => d.LanguageId == languageId).ToList().Count == 0).ToList();
            ViewBag.LanguageId = new SelectList(db.IdentityLanguages.Where(l => l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name", languageId);
            ViewBag.CurrentLanguageId = languageId;
            return View(departments);
        }

        // GET: Identity/Departments/Details/5
        public ActionResult Details(int? id, int? languageId)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            IdentityDepartment department = db.IdentityDepartments.Find(id);
            if (department == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            ViewBag.LanguageId = languageId;
            return View(department);
        }

        // GET: Identity/Departments/Create
        public ActionResult Create(int? languageId)
        {
            if (languageId == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            ViewBag.LanguageId = languageId;
            ViewBag.ManagerId = new SelectList(db.Employees.Where(e => e.LanguageId == languageId), "TranslationId", "FullName");
            ViewBag.ParentId = new SelectList(GetDepartmentsServerSide(languageId), "Id", "Name");
            return View();
        }

        // POST: Identity/Departments/Create To protect from overposting attacks, please enable the
        // specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Code,ManagerId,TypeId,ParentId,Ordinal")] IdentityDepartment department, int? languageId)
        {
            if (ModelState.IsValid)
            {
                db.IdentityDepartments.Add(department);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LanguageId = languageId;
            ViewBag.ManagerId = new SelectList(db.Employees.Where(e => e.LanguageId == languageId), "TranslationId", "FullName", department.ManagerId);
            ViewBag.ParentId = new SelectList(GetDepartmentsServerSide(languageId), "Id", "Name", department.ParentId);
            return View(department);
        }

        // GET: Identity/Departments/Edit/5
        public ActionResult Edit(int? id, int? languageId)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            IdentityDepartment department = db.IdentityDepartments.Find(id);
            if (department == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            ViewBag.LanguageId = languageId;
            ViewBag.ManagerId = new SelectList(db.Employees.Where(e => e.LanguageId == languageId), "TranslationId", "FullName", department.ManagerId);
            ViewBag.ParentId = new SelectList(GetDepartmentsServerSide(languageId), "Id", "Name", department.ParentId);
            return View(department);
        }

        // POST: Identity/Departments/Edit/5 To protect from overposting attacks, please enable the
        // specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Code,ManagerId,TypeId,ParentId,Ordinal")] IdentityDepartment department, int? languageId)
        {
            if (ModelState.IsValid)
            {
                db.Entry(department).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LanguageId = languageId;
            ViewBag.ManagerId = new SelectList(db.Employees.Where(e => e.LanguageId == languageId), "TranslationId", "FullName", department.ManagerId);
            ViewBag.ParentId = new SelectList(GetDepartmentsServerSide(languageId), "Id", "Name", department.ParentId);
            return View(department);
        }

        // GET: Identity/Departments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            IdentityDepartment department = db.IdentityDepartments.Find(id);
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