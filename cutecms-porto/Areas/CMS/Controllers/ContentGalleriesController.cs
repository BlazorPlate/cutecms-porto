using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cutecms_porto.Areas.CMS.Models.DBModel;
using cutecms_porto.Helpers;

namespace cutecms_porto.Areas.CMS.Controllers
{
    [LocalizedAuthorize(Roles = "Admin")]
    public class ContentGalleriesController : BaseController
    {
        private CMSEntities db = new CMSEntities();

        // GET: CMS/ContentGalleries
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            var contentGalleries = db.ContentGalleries.Include(c => c.Content).Include(c => c.Gallery).Where(c => c.Gallery.TenantId.Equals(Tenant.TenantId) && c.ContentId == id);
            ViewBag.ContentId = id;
            return View(contentGalleries.ToList());
        }

        // GET: CMS/ContentGalleries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            var contentGallery = db.ContentGalleries.Include(c => c.Content).Include(c => c.Gallery).Where(c => c.Gallery.TenantId.Equals(Tenant.TenantId) && c.Id == id).FirstOrDefault();
            if (contentGallery == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(contentGallery);
        }

        // GET: CMS/ContentGalleries/Create
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            ViewBag.ContentId = id;
            ViewBag.ContentTitle = db.Contents.Find(id).Title;
            var contentGallery = db.ContentGalleries.Include(c => c.Content).Include(c => c.Gallery).Where(c => c.Gallery.TenantId.Equals(Tenant.TenantId) && c.Id == id).FirstOrDefault();

            int[] assignedGalleries = db.Galleries.Where(g => g.TenantId.Equals(Tenant.TenantId) && g.ContentGalleries.Any(cg => cg.ContentId == id)).Select(c => c.Id).ToArray();
            ViewBag.GalleryId = new SelectList(db.Galleries.Where(g => g.TenantId.Equals(Tenant.TenantId) && !assignedGalleries.Contains(g.Id)), "Id", "Code");
            return View();
        }

        // POST: CMS/ContentGalleries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ContentId,GalleryId,Ordinal")] ContentGallery contentGallery)
        {
            if (ModelState.IsValid)
            {
                db.ContentGalleries.Add(contentGallery);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = contentGallery.ContentId });
            }

            ViewBag.ContentId = contentGallery.ContentId;
            int[] assignedGalleries = db.Galleries.Where(c => c.TenantId.Equals(Tenant.TenantId) && c.ContentGalleries.Any(cg => cg.ContentId == contentGallery.ContentId)).Select(c => c.Id).ToArray();
            ViewBag.GalleryId = new SelectList(db.Galleries.Where(g => g.TenantId.Equals(Tenant.TenantId) && !assignedGalleries.Contains(g.Id)), "Id", "Code", contentGallery.GalleryId);
            return View(contentGallery);
        }

        // GET: CMS/ContentGalleries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            ContentGallery contentGallery = db.ContentGalleries.Include("Content").Where(c => c.Id == id).FirstOrDefault();
            if (contentGallery == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            ViewBag.ContentId = contentGallery.ContentId;
            ViewBag.ContentTitle = contentGallery.Content.Title;
            ViewBag.GalleryId = new SelectList(db.Galleries.Where(g=> g.TenantId.Equals(Tenant.TenantId)), "Id", "Code", contentGallery.GalleryId);
            return View(contentGallery);
        }

        // POST: CMS/ContentGalleries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ContentId,GalleryId,Ordinal")] ContentGallery contentGallery)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contentGallery).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = contentGallery.ContentId });
            }
            ViewBag.ContentId = contentGallery.ContentId;
            ViewBag.ContentTitle = db.Contents.Find(contentGallery.ContentId).Title;
            ViewBag.GalleryId = new SelectList(db.Galleries.Where(g=> g.TenantId.Equals(Tenant.TenantId)), "Id", "Code", contentGallery.GalleryId);
            return View(contentGallery);
        }

        // GET: CMS/ContentGalleries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            var contentGallery = db.ContentGalleries.Include(c => c.Content).Include(c => c.Gallery).Where(c => c.Gallery.TenantId.Equals(Tenant.TenantId) && c.Id == id).FirstOrDefault();
            if (contentGallery == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(contentGallery);
        }

        // POST: CMS/ContentGalleries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var contentGallery = db.ContentGalleries.Include(c => c.Content).Include(c => c.Gallery).Where(c => c.Gallery.TenantId.Equals(Tenant.TenantId) && c.Id == id).FirstOrDefault();
            db.ContentGalleries.Remove(contentGallery);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = contentGallery.ContentId });
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
