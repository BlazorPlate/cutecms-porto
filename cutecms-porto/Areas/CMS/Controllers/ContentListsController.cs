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
    [Authorize(Roles = "Admin")]
    public class ContentListsController : BaseController
    {
        #region Fields
        private CMSEntities db = new CMSEntities();
        #endregion Fields

        #region Methods
        // GET: CMS/ContentLists
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            var contentLists = db.ContentLists.Include(c => c.Content).Where(cl => cl.ContentId == id);
            ViewBag.ContentId = id;
            return View(contentLists.ToList());
        }

        // GET: CMS/ContentLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            ContentList contentList = db.ContentLists.Find(id);
            if (contentList == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(contentList);
        }

        // GET: CMS/ContentLists/Create
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            ViewBag.ContentId = db.Contents.Find(id).Id;
            ViewBag.ContentTitle = db.Contents.Find(id).Title;
            return View();
        }

        // POST: CMS/ContentLists/Create To protect from overposting attacks, please enable the
        // specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Code,Name,MainContent,Ordinal,ContentId")] ContentList contentList)
        {
            if (ModelState.IsValid)
            {
                db.ContentLists.Add(contentList);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = contentList.ContentId });
            }
            ViewBag.ContentId = contentList.ContentId;
            ViewBag.ContentTitle = contentList.Content.Title;
            return View(contentList);
        }

        // GET: CMS/ContentLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            ContentList contentList = db.ContentLists.Find(id);
            if (contentList == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            ViewBag.ContentId = contentList.ContentId;
            ViewBag.ContentTitle = db.Contents.Find(contentList.ContentId).Title;
            return View(contentList);
        }

        // POST: CMS/ContentLists/Edit/5 To protect from overposting attacks, please enable the
        // specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Code,Name,MainContent,Ordinal,ContentId")] ContentList contentList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contentList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = contentList.ContentId });
            }
            ViewBag.ContentId = contentList.ContentId;
            ViewBag.ContentTitle = contentList.Content.Title;
            return View(contentList);
        }

        // GET: CMS/ContentLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            ContentList contentList = db.ContentLists.Find(id);
            if (contentList == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(contentList);
        }

        // POST: CMS/ContentLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContentList contentList = db.ContentLists.Find(id);
            db.ContentLists.Remove(contentList);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = contentList.ContentId });
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