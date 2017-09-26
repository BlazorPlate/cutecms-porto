using cutecms_porto.Areas.CMS.Models.DBModel;
using cutecms_porto.Helpers;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace cutecms_porto.Areas.CMS.Controllers
{
    [LocalizedAuthorize(Roles = "Admin,CMS,Galleries")]
    public class GalleriesController : BaseController
    {
        #region Fields
        private CMSEntities db = new CMSEntities();
        #endregion Fields

        #region Methods
        // GET: CMS/Galleries
        public ActionResult Index()
        {
            var galleries = db.Galleries.Where(g => g.TenantId.Trim().Equals(Tenant.TenantId)).OrderBy(g => g.Ordinal).ToList();
            return View(galleries);
        }

        // GET: CMS/Galleries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            Gallery gallery = db.Galleries.Where(g => g.TenantId.Trim().Equals(Tenant.TenantId) && g.Id == id).FirstOrDefault();
            if (gallery == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(gallery);
        }

        // GET: CMS/Galleries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CMS/Galleries/Create To protect from overposting attacks, please enable the specific
        // properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Code,HomeVisible,Visible,Ordinal")] Gallery gallery)
        {
            if (ModelState.IsValid)
            {
                gallery.TenantId = Tenant.TenantId;
                db.Galleries.Add(gallery);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gallery);
        }

        // GET: CMS/Galleries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            Gallery gallery = db.Galleries.Where(g => g.TenantId.Trim().Equals(Tenant.TenantId) && g.Id == id).FirstOrDefault();
            if (gallery == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(gallery);
        }

        // POST: CMS/Galleries/Edit/5 To protect from overposting attacks, please enable the specific
        // properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Code,HomeVisible,Visible,Ordinal")] Gallery gallery)
        {
            if (ModelState.IsValid)
            {
                gallery.TenantId = Tenant.TenantId;
                db.Entry(gallery).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gallery);
        }

        // GET: CMS/Galleries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            Gallery gallery = db.Galleries.Where(g => g.TenantId.Trim().Equals(Tenant.TenantId) && g.Id == id).FirstOrDefault();
            if (gallery == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(gallery);
        }

        // POST: CMS/Galleries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gallery gallery = db.Galleries.Find(id);
            db.Galleries.Remove(gallery);
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