using cutecms_porto.Areas.CMS.Models.DBModel;
using cutecms_porto.Areas.Config.Models.DBModel;
using cutecms_porto.Helpers;
using PagedList;
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
    [LocalizedAuthorize(Roles = "Admin,Config,Languages")]
    public class LanguagesController : BaseController
    {
        #region Fields
        private ConfigEntities db = new ConfigEntities();
        #endregion Fields

        #region Methods
        // GET: CMS/ConfigLanguages
        public ActionResult Index(int? page, string language, bool isEnabledFilter = false)
        {
            var pageNumber = page ?? 1;
            ViewBag.LanguageFilter = language;
            ViewBag.IsEnabledFilter = isEnabledFilter;
            ViewBag.IsEnabled = isEnabledFilter;
            var languages = db.ConfigLanguages.Where(l => ((l.CultureName.Contains(language) || string.IsNullOrEmpty(language)) || (l.Name.Contains(language) || string.IsNullOrEmpty(language))) &&  l.IsEnabled == isEnabledFilter).OrderBy(l => l.Ordinal);
            return View(languages.ToPagedList(pageNumber, 10));
        }
        // GET: CMS/ConfigLanguages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            ConfigLanguage ConfigLanguage = db.ConfigLanguages.Find(id);
            if (ConfigLanguage == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(ConfigLanguage);
        }

        // GET: CMS/ConfigLanguages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CMS/ConfigLanguages/Create To protect from overposting attacks, please enable the
        // specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,CultureName,FlagCode,IsEnabled,IsDefault,Ordinal")] ConfigLanguage ConfigLanguage)
        {
            if (ModelState.IsValid)
            {
                db.ConfigLanguages.Add(ConfigLanguage);
                db.SaveChanges();
                CultureHelper.Cultures.Clear();
                CultureHelper.Cultures = db.ConfigLanguages.Where(l => l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal).Select(l => l.CultureName.Trim()).ToList();
                return RedirectToAction("Index");
            }

            return View(ConfigLanguage);
        }

        // GET: CMS/ConfigLanguages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            ConfigLanguage ConfigLanguage = db.ConfigLanguages.Find(id);
            if (ConfigLanguage == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(ConfigLanguage);
        }

        // POST: CMS/ConfigLanguages/Edit/5 To protect from overposting attacks, please enable the
        // specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,CultureName,FlagCode,IsEnabled,IsDefault,Ordinal")] ConfigLanguage ConfigLanguage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ConfigLanguage).State = EntityState.Modified;
                db.SaveChanges();
                Helpers.CultureHelper.Cultures.Clear();
                Helpers.CultureHelper.Cultures = db.ConfigLanguages.Where(l => l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal).Select(l => l.CultureName.Trim()).ToList();
                return RedirectToAction("Index");
            }
            return View(ConfigLanguage);
        }

        // GET: CMS/ConfigLanguages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            ConfigLanguage ConfigLanguage = db.ConfigLanguages.Find(id);
            if (ConfigLanguage == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(ConfigLanguage);
        }

        // POST: CMS/ConfigLanguages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ConfigLanguage ConfigLanguage = db.ConfigLanguages.Find(id);
            db.ConfigLanguages.Remove(ConfigLanguage);
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