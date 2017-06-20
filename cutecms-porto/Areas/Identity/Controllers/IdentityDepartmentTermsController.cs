using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using cutecms_porto.Areas.Identity.Models.DBModel;
using cutecms_porto.Helpers;
using System.IO;
using System.Drawing;
using System.Globalization;

namespace cutecms_porto.Areas.Identity.Controllers
{
    [LocalizedAuthorize(Roles = "Admin")]
    public class IdentityDepartmentTermsController : BaseController
    {
        private IdentityEntities db = new IdentityEntities();

        // GET: Identity/IdentityDepartmentTerms
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            var identityDepartmentTerms = db.IdentityDepartmentTerms.Include(d => d.Department).Include(d => d.Language).Where(d => d.DepartmentId == id);
            ViewBag.DepartmentId = id;
            return View(identityDepartmentTerms.ToList());
        }

        // GET: Identity/IdentityDepartmentTerms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            IdentityDepartmentTerm identityDepartmentTerm = db.IdentityDepartmentTerms.Include("Language").Include("Department").Where(d => d.Id == id).FirstOrDefault();
            if (identityDepartmentTerm == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(identityDepartmentTerm);
        }

        // GET: Identity/IdentityDepartmentTerms/Create
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            ViewBag.DepartmentId = id;
            ViewBag.DepartmentCode = db.IdentityDepartments.Where(d => d.TenantId.Equals(Tenant.TenantId) && d.Id == id).FirstOrDefault().Code;
            int[] assignedLanguages = db.IdentityDepartmentTerms.Where(t => t.DepartmentId == id).Select(t => t.LanguageId).ToArray();
            ViewBag.LanguageId = new SelectList(db.IdentityLanguages.Where(l => !assignedLanguages.Contains(l.Id) && l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name");
            return View();
        }

        // POST: Identity/IdentityDepartmentTerms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LanguageId,Value,UrlSlug,AbsolutePath,Icon,IconName,IconPath,Summary,Description,Image,ImageName,ImagePath,Visible,HomeVisible,Ordinal,DepartmentId")] IdentityDepartmentTerm identityDepartmentTerm)
        {
            if (ModelState.IsValid)
            {
                var culture = db.IdentityLanguages.Find(identityDepartmentTerm.LanguageId).CultureName.Trim();
                if (identityDepartmentTerm.Icon != null && identityDepartmentTerm.Icon.ContentLength > 0)
                {
                    var extension = Path.GetExtension(identityDepartmentTerm.Icon.FileName);
                    string timeStamp = DateTime.UtcNow.ToString("ddMMyyyy HHmmssfff", CultureInfo.InvariantCulture);
                    var newFileName = StringHelper.CleanFileName(identityDepartmentTerm.Value.Trim() + "-" + timeStamp + "-" + extension);
                    var path = String.Format("/fileman/Uploads/Images/Identity/Departments/Icons/{0}", newFileName);
                    identityDepartmentTerm.IconPath = path;
                    identityDepartmentTerm.IconName = newFileName;
                    using (var img = Image.FromStream(identityDepartmentTerm.Icon.InputStream))
                    {
                        ImageUploaderHelper.SaveImageToFolder(img, extension, new Size(43, 57), identityDepartmentTerm.IconPath);
                    }
                }
                if (identityDepartmentTerm.Image != null && identityDepartmentTerm.Image.ContentLength > 0)
                {
                    var extension = Path.GetExtension(identityDepartmentTerm.Image.FileName);
                    string timeStamp = DateTime.UtcNow.ToString("ddMMyyyy HHmmssfff", CultureInfo.InvariantCulture);
                    var newFileName = Helpers.StringHelper.CleanFileName(identityDepartmentTerm.Value.Trim() + "-" + timeStamp + "-" + extension);
                    var path = String.Format("/fileman/Uploads/Images/Identity/Departments/Images/{0}", newFileName);
                    identityDepartmentTerm.ImagePath = path;
                    identityDepartmentTerm.ImageName = newFileName;
                    using (var img = System.Drawing.Image.FromStream(identityDepartmentTerm.Image.InputStream))
                    {
                        ImageUploaderHelper.SaveImageToFolder(img, extension, new Size(360, 180), identityDepartmentTerm.ImagePath);
                    }
                }
                var dept = db.IdentityDepartments.Find(identityDepartmentTerm.DepartmentId);
                string parentDepartmentPath = StringHelper.GetParentDepartmentPath(dept, culture);
                var link = StringHelper.BuildDepartmentUrl(culture, parentDepartmentPath);
                identityDepartmentTerm.UrlSlug = link.Item1;
                identityDepartmentTerm.AbsolutePath = link.Item2;
                db.IdentityDepartmentTerms.Add(identityDepartmentTerm);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = identityDepartmentTerm.DepartmentId });
            }
            ViewBag.DepartmentId = identityDepartmentTerm.DepartmentId;
            ViewBag.DepartmentCode = db.IdentityDepartments.Where(d => d.TenantId.Equals(Tenant.TenantId) && d.Id == identityDepartmentTerm.DepartmentId).FirstOrDefault().Code;
            int[] assignedLanguages = db.IdentityDepartmentTerms.Where(t => t.DepartmentId == identityDepartmentTerm.DepartmentId && t.LanguageId != identityDepartmentTerm.LanguageId).Select(t => t.LanguageId).ToArray();
            ViewBag.LanguageId = new SelectList(db.IdentityLanguages.Where(l => !assignedLanguages.Contains(l.Id) && l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name", identityDepartmentTerm.LanguageId);
            return View(identityDepartmentTerm);
        }

        // GET: Identity/IdentityDepartmentTerms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            IdentityDepartmentTerm identityDepartmentTerm = db.IdentityDepartmentTerms.Find(id);
            if (identityDepartmentTerm == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            ViewBag.DepartmentCode = db.IdentityDepartments.Where(d => d.TenantId.Equals(Tenant.TenantId) && d.Id == identityDepartmentTerm.DepartmentId).FirstOrDefault().Code;
            int[] assignedLanguages = db.IdentityDepartmentTerms.Where(t => t.DepartmentId == identityDepartmentTerm.DepartmentId && t.LanguageId != identityDepartmentTerm.LanguageId).Select(t => t.LanguageId).ToArray();
            ViewBag.LanguageId = new SelectList(db.IdentityLanguages.Where(l => !assignedLanguages.Contains(l.Id) && l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name", identityDepartmentTerm.LanguageId);
            return View(identityDepartmentTerm);
        }

        // POST: Identity/IdentityDepartmentTerms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LanguageId,Value,UrlSlug,AbsolutePath,Icon,IconName,IconPath,Summary,Description,Image,ImageName,ImagePath,Visible,HomeVisible,Ordinal,DepartmentId")] IdentityDepartmentTerm identityDepartmentTerm)
        {
            if (ModelState.IsValid)
            {
                var culture = db.IdentityLanguages.Find(identityDepartmentTerm.LanguageId).CultureName.Trim();
                if (identityDepartmentTerm.Icon != null && identityDepartmentTerm.Icon.ContentLength > 0)
                {
                    var extension = Path.GetExtension(identityDepartmentTerm.Icon.FileName);
                    string timeStamp = DateTime.UtcNow.ToString("ddMMyyyy HHmmssfff", CultureInfo.InvariantCulture);
                    var newFileName = StringHelper.CleanFileName(identityDepartmentTerm.Value.Trim() + "-" + timeStamp + "-" + extension);
                    var path = String.Format("/fileman/Uploads/Images/Identity/Departments/Icons/{0}", newFileName);
                    identityDepartmentTerm.IconPath = path;
                    identityDepartmentTerm.IconName = newFileName;
                    using (var img = Image.FromStream(identityDepartmentTerm.Icon.InputStream))
                    {
                        ImageUploaderHelper.SaveImageToFolder(img, extension, new Size(43, 57), identityDepartmentTerm.IconPath);
                    }
                }
                if (identityDepartmentTerm.Image != null && identityDepartmentTerm.Image.ContentLength > 0)
                {
                    var extension = Path.GetExtension(identityDepartmentTerm.Image.FileName);
                    string timeStamp = DateTime.UtcNow.ToString("ddMMyyyy HHmmssfff", CultureInfo.InvariantCulture);
                    var newFileName = Helpers.StringHelper.CleanFileName(identityDepartmentTerm.Value.Trim() + "-" + timeStamp + "-" + extension);
                    var path = String.Format("/fileman/Uploads/Images/Identity/Departments/Images/{0}", newFileName);
                    identityDepartmentTerm.ImagePath = path;
                    identityDepartmentTerm.ImageName = newFileName;
                    using (var img = Image.FromStream(identityDepartmentTerm.Image.InputStream))
                    {
                        ImageUploaderHelper.SaveImageToFolder(img, extension, new Size(360, 180), identityDepartmentTerm.ImagePath);
                    }
                }
                var dept = db.IdentityDepartments.Find(identityDepartmentTerm.DepartmentId);
                string parentDepartmentPath = StringHelper.GetParentDepartmentPath(dept, culture);
                var link = StringHelper.BuildDepartmentUrl(culture, parentDepartmentPath);
                identityDepartmentTerm.UrlSlug = link.Item1;
                identityDepartmentTerm.AbsolutePath = link.Item2;
                db.Entry(identityDepartmentTerm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = identityDepartmentTerm.DepartmentId });
            }
            ViewBag.DepartmentCode = db.IdentityDepartments.Where(d => d.TenantId.Equals(Tenant.TenantId) && d.Id == identityDepartmentTerm.DepartmentId).FirstOrDefault().Code;
            int[] assignedLanguages = db.IdentityDepartmentTerms.Where(t => t.DepartmentId == identityDepartmentTerm.DepartmentId && t.LanguageId != identityDepartmentTerm.LanguageId).Select(t => t.LanguageId).ToArray();
            ViewBag.LanguageId = new SelectList(db.IdentityLanguages.Where(l => !assignedLanguages.Contains(l.Id) && l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name", identityDepartmentTerm.LanguageId);
            return View(identityDepartmentTerm);
        }

        // GET: Identity/IdentityDepartmentTerms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            IdentityDepartmentTerm identityDepartmentTerm = db.IdentityDepartmentTerms.Include("Language").Include("Department").Where(d => d.Id == id).FirstOrDefault();
            if (identityDepartmentTerm == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(identityDepartmentTerm);
        }

        // POST: Identity/IdentityDepartmentTerms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IdentityDepartmentTerm identityDepartmentTerm = db.IdentityDepartmentTerms.Find(id);
            db.IdentityDepartmentTerms.Remove(identityDepartmentTerm);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = identityDepartmentTerm.DepartmentId });
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
