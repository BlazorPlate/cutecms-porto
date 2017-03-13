using cutecms_porto.Areas.Identity.Models.DBModel;
using cutecms_porto.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace cutecms_porto.Areas.Identity.Controllers
{
    [LocalizedAuthorize(Roles = "Admin")]
    public class EmpInDeptsController : BaseController
    {
        #region Fields
        private IdentityEntities db = new IdentityEntities();
        private List<object> DepartmentsList = new List<object>();
        #endregion Fields

        #region Methods

        // GET: Identity/EmpInDepts
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            var empInDepts = (from p in db.EmpInDepts.Include(e => e.Department).Include(e => e.Occupation)
                              join c in db.Employees on p.EmpId equals c.TranslationId
                              where p.DeptId == id && c.Language.CultureName.Trim().Equals(Thread.CurrentThread.CurrentCulture.Name)
                              orderby p.Ordinal
                              orderby p.DeptId
                              select p);
            ViewBag.DeptId = id.Value;
            return View(empInDepts.ToList());
        }

        // GET: Identity/EmpInDepts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            EmpInDept empInDept = db.EmpInDepts.Find(id);
            if (empInDept == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(empInDept);
        }

        // GET: Identity/EmpInDepts/Create
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            ViewBag.EmpId = new SelectList(db.Employees, "TranslationId", "FullName");
            ViewBag.OccupationId = new SelectList(TermsHelper.Occupations(), "OccupationId", "Value");
            ViewBag.EmployeeTypeId = new SelectList(TermsHelper.EmployeeTypes(), "EmployeeTypeId", "Value");
            ViewBag.DeptId = id;
            ViewBag.DepartmentName = db.IdentityDepartmentTerms.Where(d => d.DepartmentId == id && d.Language.CultureName.Trim().Equals(Thread.CurrentThread.CurrentCulture.Name)).FirstOrDefault().Value;
            EmpInDept empInDept = new EmpInDept();
            empInDept.DeptId = id.Value;
            return View(empInDept);
        }

        // POST: Identity/EmpInDepts/Create To protect from overposting attacks, please enable the
        // specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EmpId,DeptId,OccupationId,EmployeeTypeId,Ordinal")] EmpInDept empInDept)
        {
            if (ModelState.IsValid)
            {
                db.EmpInDepts.Add(empInDept);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = empInDept.DeptId });
            }
            ViewBag.EmpId = new SelectList(db.Employees, "TranslationId", "FullName", empInDept.EmpId);
            ViewBag.DeptId = empInDept.DeptId;
            ViewBag.OccupationId = new SelectList(TermsHelper.Occupations(), "OccupationId", "Value", empInDept.OccupationId);
            ViewBag.DepartmentName = db.IdentityDepartmentTerms.Where(d => d.DepartmentId == empInDept.DeptId && d.Language.CultureName.Trim().Equals(Thread.CurrentThread.CurrentCulture.Name)).FirstOrDefault().Value;
            ViewBag.EmployeeTypeId = new SelectList(TermsHelper.EmployeeTypes(), "EmployeeTypeId", "Value", empInDept.EmployeeTypeId);
            return View(empInDept);
        }

        // GET: Identity/EmpInDepts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            EmpInDept empInDept = db.EmpInDepts.Find(id);
            if (empInDept == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            ViewBag.EmpId = new SelectList(db.Employees, "TranslationId", "FullName", empInDept.EmpId);
            ViewBag.DepartmentName = db.IdentityDepartmentTerms.Where(d => d.DepartmentId == empInDept.DeptId && d.Language.CultureName.Trim().Equals(Thread.CurrentThread.CurrentCulture.Name)).FirstOrDefault().Value;
            ViewBag.OccupationId = new SelectList(TermsHelper.Occupations(), "OccupationId", "Value", empInDept.OccupationId);
            ViewBag.EmployeeTypeId = new SelectList(TermsHelper.EmployeeTypes(), "EmployeeTypeId", "Value", empInDept.EmployeeTypeId);
            return View(empInDept);
        }

        // POST: Identity/EmpInDepts/Edit/5 To protect from overposting attacks, please enable the
        // specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EmpId,DeptId,OccupationId,EmployeeTypeId,Ordinal")] EmpInDept empInDept)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empInDept).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = empInDept.DeptId });
            }
            ViewBag.EmpId = new SelectList(db.Employees, "TranslationId", "FullName", empInDept.EmpId);
            ViewBag.DepartmentName = db.IdentityDepartmentTerms.Where(d => d.DepartmentId == empInDept.DeptId && d.Language.CultureName.Trim().Equals(Thread.CurrentThread.CurrentCulture.Name)).FirstOrDefault().Value;
            ViewBag.OccupationId = new SelectList(TermsHelper.Occupations(), "OccupationId", "Value", empInDept.OccupationId);
            ViewBag.EmployeeTypeId = new SelectList(TermsHelper.EmployeeTypes(), "EmployeeTypeId", "Value", empInDept.EmployeeTypeId);
            return View(empInDept);
        }

        // GET: Identity/EmpInDepts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            EmpInDept empInDept = db.EmpInDepts.Find(id);
            if (empInDept == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(empInDept);
        }

        // POST: Identity/EmpInDepts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmpInDept empInDept = db.EmpInDepts.Find(id);
            db.EmpInDepts.Remove(empInDept);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = empInDept.DeptId});
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