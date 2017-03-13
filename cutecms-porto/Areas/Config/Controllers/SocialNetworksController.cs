using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using cutecms_porto.Areas.Config.Models.DBModel;
using cutecms_porto.Helpers;

namespace cutecms_porto.Areas.Config.Controllers
{
    [LocalizedAuthorize(Roles = "Admin")]
    public class SocialNetworksController : BaseController
    {
        private ConfigEntities db = new ConfigEntities();

        // GET: Config/SocialNetworks
        public ActionResult Index(int? id)
        {
            var socialNetworks = db.SocialNetworks.Include(s => s.Organization).Where(s => s.OrganizationId == id).OrderBy(s => s.Ordinal);
            ViewBag.OrganizationId = id;
            return View(socialNetworks.ToList());
        }

        // GET: Config/SocialNetworks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialNetwork socialNetwork = db.SocialNetworks.Include("Organization").Where(s => s.Id == id).FirstOrDefault();
            if (socialNetwork == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrganizationId = socialNetwork.OrganizationId;
            return View(socialNetwork);
        }

        // GET: Config/SocialNetworks/Create
        public ActionResult Create(int? id)
        {
            ViewBag.OrganizationId = id;
            ViewBag.OrganizationName = db.Organizations.Find(id).Name;
            return View();
        }

        // POST: Config/SocialNetworks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Code,Name,CssClass,Url,Visible,Ordinal,OrganizationId")] SocialNetwork socialNetwork)
        {
            if (ModelState.IsValid)
            {
                db.SocialNetworks.Add(socialNetwork);
                db.SaveChanges();
                CacheHelper.ClearCache();
                return RedirectToAction("Index", new { id = socialNetwork.OrganizationId });
            }

            ViewBag.OrganizationId = socialNetwork.OrganizationId;
            ViewBag.OrganizationName = db.Organizations.Find(socialNetwork.OrganizationId).Name;
            return View(socialNetwork);
        }

        // GET: Config/SocialNetworks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialNetwork socialNetwork = db.SocialNetworks.Find(id);
            if (socialNetwork == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrganizationId = socialNetwork.OrganizationId;
            ViewBag.OrganizationName = db.Organizations.Find(socialNetwork.OrganizationId).Name;
            return View(socialNetwork);
        }

        // POST: Config/SocialNetworks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Code,Name,CssClass,Url,Visible,Ordinal,OrganizationId")] SocialNetwork socialNetwork)
        {
            if (ModelState.IsValid)
            {
                db.Entry(socialNetwork).State = EntityState.Modified;
                db.SaveChanges();
                CacheHelper.ClearCache();
                return RedirectToAction("Index", new { id = socialNetwork.OrganizationId });
            }
            ViewBag.OrganizationId = socialNetwork.OrganizationId;
            ViewBag.OrganizationName = db.Organizations.Find(socialNetwork.OrganizationId).Name;
            return View(socialNetwork);
        }

        // GET: Config/SocialNetworks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialNetwork socialNetwork = db.SocialNetworks.Include("Organization").Where(s => s.Id == id).FirstOrDefault();
            if (socialNetwork == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrganizationId = socialNetwork.OrganizationId;
            return View(socialNetwork);
        }

        // POST: Config/SocialNetworks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SocialNetwork socialNetwork = db.SocialNetworks.Find(id);
            db.SocialNetworks.Remove(socialNetwork);
            db.SaveChanges();
            CacheHelper.ClearCache();
            return RedirectToAction("Index", new { id = socialNetwork.OrganizationId });
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
