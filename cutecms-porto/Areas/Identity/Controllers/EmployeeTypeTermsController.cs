using cutecms_porto.Areas.Identity.Models.DBModel;
using cutecms_porto.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace cutecms_porto.Areas.Identity.Controllers
{
    public class EmployeeTypeTermsController : BaseController
    {
        #region Fields
        private IdentityEntities db = new IdentityEntities();
        #endregion Fields

        #region Methods
        // GET: Identity/EmployeeTypeTerms
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            var employeeTypeTerms = db.EmployeeTypeTerms.Include(e => e.EmployeeType).Include(e => e.Language).Where(e => e.EmployeeTypeId == id);
            ViewBag.EmployeeTypeId = id;
            return View(employeeTypeTerms.ToList());
        }

        // GET: Identity/EmployeeTypeTerms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            EmployeeTypeTerm employeeTypeTerm = db.EmployeeTypeTerms.Include("Language").Include("EmployeeType").Where(e => e.Id == id).FirstOrDefault();
            if (employeeTypeTerm == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(employeeTypeTerm);
        }

        // GET: Identity/EmployeeTypeTerms/Create
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            ViewBag.EmployeeTypeId = id;
            ViewBag.EmployeeTypeCode = db.EmployeeTypes.Find(id).Code;
            int[] assignedLanguages = db.EmployeeTypeTerms.Where(t => t.EmployeeTypeId == id).Select(rt => rt.LanguageId).ToArray();
            ViewBag.LanguageId = new SelectList(db.IdentityLanguages.Where(l => !assignedLanguages.Contains(l.Id) && l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name");
            return View();
        }

        // POST: Identity/EmployeeTypeTerms/Create To protect from overposting attacks,
        // please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LanguageId,Value,EmployeeTypeId")] EmployeeTypeTerm employeeTypeTerm)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeTypeTerms.Add(employeeTypeTerm);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = employeeTypeTerm.EmployeeTypeId });
            }
            ViewBag.EmployeeTypeId = employeeTypeTerm.EmployeeTypeId;
            ViewBag.EmployeeTypeCode = db.EmployeeTypes.Find(employeeTypeTerm.EmployeeTypeId).Code;
            int[] assignedLanguages = db.EmployeeTypeTerms.Where(t => t.EmployeeTypeId == employeeTypeTerm.EmployeeTypeId && t.LanguageId != employeeTypeTerm.LanguageId).Select(rt => rt.LanguageId).ToArray();
            ViewBag.LanguageId = new SelectList(db.IdentityLanguages.Where(l => !assignedLanguages.Contains(l.Id) && l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name", employeeTypeTerm.LanguageId);
            return View(employeeTypeTerm);
        }

        // GET: Identity/EmployeeTypeTerms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            EmployeeTypeTerm employeeTypeTerm = db.EmployeeTypeTerms.Find(id);
            if (employeeTypeTerm == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            ViewBag.EmployeeTypeCode = db.EmployeeTypes.Find(employeeTypeTerm.EmployeeTypeId).Code;
            int[] assignedLanguages = db.EmployeeTypeTerms.Where(t => t.EmployeeTypeId == employeeTypeTerm.EmployeeTypeId && t.LanguageId != employeeTypeTerm.LanguageId).Select(rt => rt.LanguageId).ToArray();
            ViewBag.LanguageId = new SelectList(db.IdentityLanguages.Where(l => !assignedLanguages.Contains(l.Id) && l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name", employeeTypeTerm.LanguageId);
            return View(employeeTypeTerm);
        }

        // POST: Identity/EmployeeTypeTerms/Edit/5 To protect from overposting attacks,
        // please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LanguageId,Value,EmployeeTypeId")] EmployeeTypeTerm employeeTypeTerm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeTypeTerm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = employeeTypeTerm.EmployeeTypeId });
            }
            ViewBag.EmployeeTypeCode = db.EmployeeTypes.Find(employeeTypeTerm.EmployeeTypeId).Code;
            int[] assignedLanguages = db.EmployeeTypeTerms.Where(t => t.EmployeeTypeId == employeeTypeTerm.EmployeeTypeId && t.LanguageId != employeeTypeTerm.LanguageId).Select(rt => rt.LanguageId).ToArray();
            ViewBag.LanguageId = new SelectList(db.IdentityLanguages.Where(l => !assignedLanguages.Contains(l.Id) && l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name", employeeTypeTerm.LanguageId);
            return View(employeeTypeTerm);
        }

        // GET: Identity/EmployeeTypeTerms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            EmployeeTypeTerm employeeTypeTerm = db.EmployeeTypeTerms.Include("Language").Include("EmployeeType").Where(e => e.Id == id).FirstOrDefault();
            if (employeeTypeTerm == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(employeeTypeTerm);
        }

        // POST: Identity/EmployeeTypeTerms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeTypeTerm employeeTypeTerm = db.EmployeeTypeTerms.Find(id);
            db.EmployeeTypeTerms.Remove(employeeTypeTerm);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = employeeTypeTerm.EmployeeTypeId });
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