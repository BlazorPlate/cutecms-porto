using cutecms_porto.Areas.CMS.Models.DBModel;
using cutecms_porto.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace cutecms_porto.Areas.CMS.Controllers
{
    [LocalizedAuthorize(Roles = "Admin")]
    public class ListItemsController : BaseController
    {
        #region Fields
        private CMSEntities db = new CMSEntities();
        #endregion Fields

        #region Methods
        // GET: CMS/ListItems
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            var listItems = db.ListItems.Include(l => l.ContentList).Where(li => li.ContentListId == id).OrderBy(li => li.Ordinal);
            ViewBag.ContentListId = id;
            ViewBag.ContentId = db.ContentLists.Find(id).ContentId;
            return View(listItems.ToList());
        }

        // GET: CMS/ListItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            ListItem listItem = db.ListItems.Find(id);
            if (listItem == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(listItem);
        }

        // GET: CMS/ListItems/Create
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            ViewBag.ContentListId = db.ContentLists.Find(id).Id;
            ViewBag.ContentListCode = db.ContentLists.Find(id).Name;
            return View();
        }

        // POST: CMS/ListItems/Create To protect from overposting attacks, please enable the specific
        // properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Body,Url,Class,Ordinal,Visible,File,Thumb,ContentListId")] ListItem listItem)
        {
            if (ModelState.IsValid)
            {
                Random rand = new Random();
                int randomNumber = rand.Next();
                if (listItem.File != null && listItem.File.ContentLength > 0)
                {
                    var extension = Path.GetExtension(listItem.File.FileName);
                    var newFileName = Helpers.StringHelper.CleanFileName(listItem.Title + extension);
                    var path = String.Format("/fileman/Uploads/Documents/CMS/ListItems/Attachments/{0}", newFileName);
                    listItem.File.SaveAs(System.Web.Hosting.HostingEnvironment.MapPath(path));
                    listItem.FilePath = path;
                    listItem.FileName = newFileName;
                }
                if (listItem.Thumb != null && listItem.Thumb.ContentLength > 0)
                {
                    var extension = Path.GetExtension(listItem.Thumb.FileName);
                    var newFileName = Helpers.StringHelper.CleanFileName(listItem.Title + extension);
                    //var newFileName = listItem.Title + extension;
                    var path = String.Format("/fileman/Uploads/Images/CMS/ListItems/Thumbs/{0}", newFileName);
                    listItem.ThumbPath = path;
                    listItem.ThumbName = newFileName;
                    using (var img = System.Drawing.Image.FromStream(listItem.Thumb.InputStream))
                    {
                        ImageUploaderHelper.SaveThumbToFolder(img, extension, new Size(640, 424), listItem.ThumbPath);
                    }
                }
                db.ListItems.Add(listItem);
                db.SaveChanges();
                CacheHelper.ClearCache();
                return RedirectToAction("Index", new { id = listItem.ContentListId });
            }
            ViewBag.ContentListId = listItem.ContentListId;
            ViewBag.ContentListCode = db.ContentLists.Find(listItem.ContentListId).Code;
            return View(listItem);
        }

        // GET: CMS/ListItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            ListItem listItem = db.ListItems.Find(id);
            if (listItem == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            ViewBag.ContentListCode = db.ContentLists.Find(listItem.ContentListId).Code;
            return View(listItem);
        }

        // POST: CMS/ListItems/Edit/5 To protect from overposting attacks, please enable the specific
        // properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Body,Url,Class,Ordinal,Visible,File,Thumb,FilePath,ContentListId")] ListItem listItem)
        {
            if (ModelState.IsValid)
            {
                Random rand = new Random();
                int randomNumber = rand.Next();
                if (listItem.File != null && listItem.File.ContentLength > 0)
                {
                    var extension = Path.GetExtension(listItem.File.FileName);
                    //var newFileName = Helpers.StringHelper.CleanFileName(listItem.Title + extension);
                    var newFileName = listItem.Title + extension;
                    var path = String.Format("/fileman/Uploads/Documents/CMS/ListItems/Attachments/{0}", newFileName);
                    listItem.File.SaveAs(System.Web.Hosting.HostingEnvironment.MapPath(path));
                    listItem.FilePath = path;
                    listItem.FileName = newFileName;
                }
                if (listItem.Thumb != null && listItem.Thumb.ContentLength > 0)
                {
                    var extension = Path.GetExtension(listItem.Thumb.FileName);
                    //var newFileName = Helpers.StringHelper.CleanFileName(listItem.Title + extension);
                    var newFileName = listItem.Title + extension;
                    var path = String.Format("/fileman/Uploads/Images/CMS/ListItems/Thumbs/{0}", newFileName);
                    listItem.ThumbPath = path;
                    listItem.ThumbName = newFileName;
                    using (var img = System.Drawing.Image.FromStream(listItem.Thumb.InputStream))
                    {
                        ImageUploaderHelper.SaveThumbToFolder(img, extension, new Size(640, 424), listItem.ThumbPath);
                    }
                }
                db.Entry(listItem).State = EntityState.Modified;
                db.SaveChanges();
                CacheHelper.ClearCache();
                return RedirectToAction("Index", new { id = listItem.ContentListId });
            }
            ViewBag.ContentListCode = db.ContentLists.Find(listItem.ContentListId).Code;
            return View(listItem);
        }

        // GET: CMS/ListItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            ListItem listItem = db.ListItems.Find(id);
            if (listItem == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(listItem);
        }

        // POST: CMS/ListItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ListItem listItem = db.ListItems.Find(id);
            db.ListItems.Remove(listItem);
            db.SaveChanges();
            CacheHelper.ClearCache();
            return RedirectToAction("Index", new { id = listItem.ContentListId });
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