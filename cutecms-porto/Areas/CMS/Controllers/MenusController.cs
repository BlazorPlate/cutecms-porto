using cutecms_porto.Areas.CMS.Models.DBModel;
using cutecms_porto.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace cutecms_porto.Areas.CMS.Controllers
{
    [LocalizedAuthorize(Roles = "Admin")]
    public class MenusController : BaseController
    {
        #region Fields
        private CMSEntities db = new CMSEntities();
        #endregion Fields

        #region Methods
        // GET: CMS/Menus
        public ActionResult Index()
        {
            var menus = db.Menus.Where(m => m.TenantId.Trim().Equals(Tenant.TenantId)).OrderBy(m => m.Ordinal).ToList();
            return View(menus);
        }

        // GET: CMS/Menus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            Menu menu = db.Menus.Where(m => (m.TenantId.Trim().Equals(Tenant.TenantId) || string.IsNullOrEmpty(m.TenantId) && m.Id == id)).FirstOrDefault();
            if (menu == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(menu);
        }

        // GET: CMS/Menus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CMS/Menus/Create To protect from overposting attacks, please enable the specific
        // properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Code,Visible,Ordinal")] Menu menu)
        {
            if (ModelState.IsValid)
            {
                menu.TenantId = Tenant.TenantId;
                db.Menus.Add(menu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(menu);
        }

        // GET: CMS/Menus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            Menu menu = db.Menus.Where(m => (m.TenantId.Trim().Equals(Tenant.TenantId) || string.IsNullOrEmpty(m.TenantId)) && m.Id == id).FirstOrDefault();
            if (menu == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            menu.TenantId = Tenant.TenantId;
            return View(menu);
        }

        // POST: CMS/Menus/Edit/5 To protect from overposting attacks, please enable the specific
        // properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Code,Visible,Ordinal")] Menu menu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(menu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(menu);
        }

        // GET: CMS/Menus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            Menu menu = db.Menus.Where(m => (m.TenantId.Trim().Equals(Tenant.TenantId) || string.IsNullOrEmpty(m.TenantId) && m.Id == id)).FirstOrDefault();
            if (menu == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(menu);
        }

        // POST: CMS/Menus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Menu menu = db.Menus.Find(id);
            db.Menus.Remove(menu);
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