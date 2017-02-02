using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using cutecms_porto.Areas.Config.Models.DBModel;

namespace cutecms_porto.Areas.Config.Controllers
{
    public class Organizations1Controller : Controller
    {
        private ConfigEntities db = new ConfigEntities();

        // GET: Config/Organizations1
        public ActionResult Index()
        {
            var organizations = db.Organizations.Include(o => o.Language);
            return View(organizations.ToList());
        }

        // GET: Config/Organizations1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organization organization = db.Organizations.Find(id);
            if (organization == null)
            {
                return HttpNotFound();
            }
            return View(organization);
        }

        // GET: Config/Organizations1/Create
        public ActionResult Create()
        {
            ViewBag.LanguageId = new SelectList(db.ConfigLanguages, "Id", "Name");
            return View();
        }

        // POST: Config/Organizations1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TenantId,LanguageId,IsTranslated,TranslationId,Code,Name,Description,AddressLine1,AddressLine2,City,State,ZIP,Country,Telephone,Fax,Email,Longitude,Latitude,MetaDescription,FacebookUrl,TwitterUrl,YouTubeUrl,GooglePlusUrl,LinkedInUrl,RSS,Developer,DeveloperURL,PrimaryLogoPath,PrimaryLogoName,SecondaryLogoPath,SecondaryLogoName,IsDefault")] Organization organization)
        {
            if (ModelState.IsValid)
            {
                db.Organizations.Add(organization);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LanguageId = new SelectList(db.ConfigLanguages, "Id", "Name", organization.LanguageId);
            return View(organization);
        }

        // GET: Config/Organizations1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organization organization = db.Organizations.Find(id);
            if (organization == null)
            {
                return HttpNotFound();
            }
            ViewBag.LanguageId = new SelectList(db.ConfigLanguages, "Id", "Name", organization.LanguageId);
            return View(organization);
        }

        // POST: Config/Organizations1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TenantId,LanguageId,IsTranslated,TranslationId,Code,Name,Description,AddressLine1,AddressLine2,City,State,ZIP,Country,Telephone,Fax,Email,Longitude,Latitude,MetaDescription,FacebookUrl,TwitterUrl,YouTubeUrl,GooglePlusUrl,LinkedInUrl,RSS,Developer,DeveloperURL,PrimaryLogoPath,PrimaryLogoName,SecondaryLogoPath,SecondaryLogoName,IsDefault")] Organization organization)
        {
            if (ModelState.IsValid)
            {
                db.Entry(organization).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LanguageId = new SelectList(db.ConfigLanguages, "Id", "Name", organization.LanguageId);
            return View(organization);
        }

        // GET: Config/Organizations1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organization organization = db.Organizations.Find(id);
            if (organization == null)
            {
                return HttpNotFound();
            }
            return View(organization);
        }

        // POST: Config/Organizations1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Organization organization = db.Organizations.Find(id);
            db.Organizations.Remove(organization);
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
    }
}
