using cutecms_porto.Areas.CMS.Models.DBModel;
using cutecms_porto.Helpers;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace cutecms_porto.Areas.CMS.Controllers
{
    [LocalizedAuthorize(Roles = "Admin")]
    public class ImageTagsController : BaseController
    {
        #region Fields
        private CMSEntities db = new CMSEntities();
        #endregion Fields

        #region Methods
        // GET: ImageTags
        public ActionResult Index()
        {
            var imageTags = db.ImageTags.Include(i => i.Tag);
            return View(imageTags.ToList());
        }

        // GET: ImageTags/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            ImageTag imageTag = db.ImageTags.Find(id);
            if (imageTag == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(imageTag);
        }

        // GET: ImageTags/Create
        public ActionResult Create()
        {
            ViewBag.TagId = new SelectList(db.Tags, "Id", "Name");
            return View();
        }

        // POST: ImageTags/Create To protect from overposting attacks, please enable the specific
        // properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ImageId,TagId")] ImageTag imageTag)
        {
            if (ModelState.IsValid)
            {
                db.ImageTags.Add(imageTag);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TagId = new SelectList(db.Tags, "Id", "Name", imageTag.TagId);
            return View(imageTag);
        }

        // GET: ImageTags/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            ImageTag imageTag = db.ImageTags.Find(id);
            if (imageTag == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            ViewBag.TagId = new SelectList(db.Tags, "Id", "Name", imageTag.TagId);
            return View(imageTag);
        }

        // POST: ImageTags/Edit/5 To protect from overposting attacks, please enable the specific
        // properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ImageId,TagId")] ImageTag imageTag)
        {
            if (ModelState.IsValid)
            {
                db.Entry(imageTag).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TagId = new SelectList(db.Tags, "Id", "Name", imageTag.TagId);
            return View(imageTag);
        }

        // GET: ImageTags/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            ImageTag imageTag = db.ImageTags.Find(id);
            if (imageTag == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(imageTag);
        }

        // POST: ImageTags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ImageTag imageTag = db.ImageTags.Find(id);
            db.ImageTags.Remove(imageTag);
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