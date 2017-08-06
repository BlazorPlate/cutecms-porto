using cutecms_porto.Areas.Config.Models.DBModel;
using cutecms_porto.Helpers;
using System;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cutecms_porto.Areas.Config.Controllers
{
    [LocalizedAuthorize(Roles = "Admin")]
    public class OrganizationsController : BaseController
    {
        #region Fields
        private ConfigEntities db = new ConfigEntities();
        #endregion Fields

        #region Methods
        public ActionResult Translations(int? id, bool isDefault)
        {
            ViewBag.TranslationId = id;
            ViewBag.IsDefault = isDefault;
            var organizations = db.Organizations.Include("Language").Where(o => o.TenantId.Trim().Equals(Tenant.TenantId) && o.TranslationId == id).OrderBy(o => o.TranslationId);
            return View(organizations.ToList());
        }

        // GET: CMS/Organizations
        public ActionResult Index(string statusMessage)
        {
            ViewBag.Message = statusMessage;
            var organizations = db.Organizations.Include("Language").Where(o => o.TenantId.Trim().Equals(Tenant.TenantId));
            return View(organizations.ToList());
        }

        // GET: Config/Organizations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            Organization organization = db.Organizations.Include("Language").Where(o => o.TenantId.Trim().Equals(Tenant.TenantId) && o.Id == id).FirstOrDefault();
            if (organization == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(organization);
        }

        // GET: Config/Organizations/Create
        public ActionResult Create(int? id, bool? isDefault)
        {
            ViewBag.LanguageId = new SelectList(db.ConfigLanguages.Where(l => l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name");
            Organization organization = new Organization();
            organization.TranslationId = id;
            if (isDefault == null)
            {
                organization.IsDefault = false;
            }
            else
            {
                organization.IsDefault = isDefault.Value;
            }
            return View(organization);
        }

        // POST: Config/Organizations/Create To protect from overposting attacks, please enable the
        // specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TenantId,LanguageId,IsTranslated,TranslationId,Code,Name,Description,AddressLine1,AddressLine2,City,State,ZIP,Country,Telephone,Fax,Email,Longitude,Latitude,MetaDescription,Developer,DeveloperURL,PrimaryLogo,SecondaryLogo,PrimaryLogoPath,PrimaryLogoName,SecondaryLogoPath,SecondaryLogoName,IsDefault")] Organization organization, int? sWidth, int? sHeight, int? pWidth, int? pHeight)
        {
            if (ModelState.IsValid)
            {
                if (organization.PrimaryLogo != null && organization.PrimaryLogo.ContentLength > 0)
                {
                    var extension = Path.GetExtension(organization.PrimaryLogo.FileName);
                    var newFileName = Helpers.StringHelper.CleanFileName(organization.Code + "-primary-logo" + extension);
                    //var newFileName = organization.Name + extension;
                    var path = String.Format("/fileman/Uploads/Images/Config/Organizations/{0}", newFileName);
                    organization.PrimaryLogoPath = path;
                    organization.PrimaryLogoName = newFileName;
                    using (var img = Image.FromStream(organization.PrimaryLogo.InputStream))
                    {
                        if (pWidth == null)
                            pWidth = img.Width;
                        if (pHeight == null)
                            pHeight = img.Height;
                        ImageUploaderHelper.SaveImageToFolder(img, extension, new Size(pWidth.Value, pHeight.Value), organization.PrimaryLogoPath);
                    }
                }
                if (organization.SecondaryLogo != null && organization.SecondaryLogo.ContentLength > 0)
                {
                    var extension = Path.GetExtension(organization.SecondaryLogo.FileName);
                    var newFileName = StringHelper.CleanFileName(organization.Code + "-secondary" + extension);
                    //var newFileName = organization.Name + extension;
                    var path = String.Format("/fileman/Uploads/Images/Config/Organizations/{0}", newFileName);
                    organization.SecondaryLogoPath = path;
                    organization.SecondaryLogoName = newFileName;
                    using (var img = Image.FromStream(organization.SecondaryLogo.InputStream))
                    {
                        if (sWidth == null)
                            sWidth = img.Width;
                        if (sHeight == null)
                            sHeight = img.Height;
                        ImageUploaderHelper.SaveImageToFolder(img, extension, new Size(sWidth.Value, sHeight.Value), organization.SecondaryLogoPath);
                    }
                }
                if (organization.IsDefault)
                {
                    foreach (var item in db.Organizations.Where(o => o.TenantId.Trim().Equals(Tenant.TenantId)))
                    {
                        if (item.TranslationId == organization.TranslationId)
                        {
                            item.IsDefault = true;
                        }
                        else
                        {
                            item.IsDefault = false;
                        }
                        db.Entry(item).State = EntityState.Modified;
                    }
                }
                organization.TenantId = Tenant.TenantId;
                db.Organizations.Add(organization);
                db.SaveChanges();
                if (organization.TranslationId == null)
                    organization.TranslationId = organization.Id;
                db.Entry(organization).State = EntityState.Modified;

                db.SaveChanges();
                CacheHelper.ClearCache();
                return RedirectToAction("Index");
            }
            ViewBag.LanguageId = new SelectList(db.ConfigLanguages.Where(l => l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name", organization.LanguageId);
            return View(organization);
        }

        // GET: Config/Organizations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            Organization organization = db.Organizations.Where(o => o.TenantId.Trim().Equals(Tenant.TenantId) && o.Id == id).FirstOrDefault();
            if (organization == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            ViewBag.LanguageId = new SelectList(db.ConfigLanguages.Where(l => l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name", organization.LanguageId);
            return View(organization);
        }

        // POST: Config/Organizations/Edit/5 To protect from overposting attacks, please enable the
        // specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TenantId,LanguageId,IsTranslated,TranslationId,Code,Name,Description,AddressLine1,AddressLine2,City,State,ZIP,Country,Telephone,Fax,Email,Longitude,Latitude,MetaDescription,Developer,DeveloperURL,PrimaryLogo,SecondaryLogo,PrimaryLogoPath,PrimaryLogoName,SecondaryLogoPath,SecondaryLogoName,IsDefault")] Organization organization, int? sWidth, int? sHeight, int? pWidth, int? pHeight)
        {
            if (ModelState.IsValid)
            {
                if (organization.PrimaryLogo != null && organization.PrimaryLogo.ContentLength > 0)
                {
                    var extension = Path.GetExtension(organization.PrimaryLogo.FileName);
                    //var newFileName = Helpers.StringHelper.CleanFileName(listItem.Title + extension);
                    var newFileName = StringHelper.CleanFileName(organization.Code + "-primary-logo" + extension);
                    var path = String.Format("/fileman/Uploads/Images/Config/Organizations/{0}", newFileName);
                    organization.PrimaryLogoPath = path;
                    organization.PrimaryLogoName = newFileName;
                    using (var img = Image.FromStream(organization.PrimaryLogo.InputStream))
                    {
                        if (pWidth == null)
                            pWidth = img.Width;
                        if (pHeight == null)
                            pHeight = img.Height;
                        ImageUploaderHelper.SaveImageToFolder(img, extension, new Size(pWidth.Value, pHeight.Value), organization.PrimaryLogoPath);
                    }
                }
                if (organization.SecondaryLogo != null && organization.SecondaryLogo.ContentLength > 0)
                {
                    var extension = Path.GetExtension(organization.SecondaryLogo.FileName);
                    var newFileName = StringHelper.CleanFileName(organization.Code + "-secondary" + extension);
                    //var newFileName = organization.Name + extension;
                    var path = String.Format("/fileman/Uploads/Images/Config/Organizations/{0}", newFileName);
                    organization.SecondaryLogoPath = path;
                    organization.SecondaryLogoName = newFileName;
                    using (var img = Image.FromStream(organization.SecondaryLogo.InputStream))
                    {
                        if (sWidth == null)
                            sWidth = img.Width;
                        if (sHeight == null)
                            sHeight = img.Height;
                        ImageUploaderHelper.SaveImageToFolder(img, extension, new Size(sWidth.Value, sHeight.Value), organization.SecondaryLogoPath);
                    }
                }
                organization.TenantId = Tenant.TenantId;
                db.Entry(organization).State = EntityState.Modified;
                foreach (var item in db.Organizations.Where(o => o.TranslationId != organization.TranslationId && o.TenantId.Trim().Equals(Tenant.TenantId)))
                {
                    item.IsDefault = false;
                    db.Entry(item).State = EntityState.Modified;
                }
                foreach (var item in db.Organizations.Where(o => o.TranslationId == organization.TranslationId && o.TenantId.Trim().Equals(Tenant.TenantId)))
                {
                    item.IsDefault = organization.IsDefault;
                    db.Entry(item).State = EntityState.Modified;
                }
                db.SaveChanges();
                CacheHelper.ClearCache();
                return RedirectToAction("Index");
            }
            ViewBag.LanguageId = new SelectList(db.ConfigLanguages.Where(l => l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name", organization.LanguageId);
            return View(organization);
        }

        // GET: Config/Organizations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            Organization organization = db.Organizations.Include("Language").Where(o => o.TenantId.Trim().Equals(Tenant.TenantId) && o.Id == id).FirstOrDefault();
            if (organization == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(organization);
        }

        // POST: Config/Organizations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Organization organization = db.Organizations.Find(id);
            db.Organizations.Remove(organization);
            db.SaveChanges();
            Organization translatedOrganization = db.Organizations.Where(c => c.TranslationId == organization.TranslationId).FirstOrDefault();
            if (translatedOrganization != null)
            {
                db.Entry(translatedOrganization).State = System.Data.Entity.EntityState.Modified;
                translatedOrganization.IsTranslated = false;
                translatedOrganization.TranslationId = null;
                db.SaveChanges();
            }
            CacheHelper.ClearCache();
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