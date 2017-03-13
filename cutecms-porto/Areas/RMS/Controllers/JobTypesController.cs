using cutecms_porto.Areas.RMS.Models.DBModel;
using cutecms_porto.Helpers;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cutecms_porto.Areas.RMS.Controllers
{
    [LocalizedAuthorize(Roles = "Admin")]
    public class JobTypesController : BaseController
    {
        #region Fields
        private RMSEntities db = new RMSEntities();
        #endregion Fields

        #region Methods
        // GET: RMS/JobTypes
        public ActionResult Index()
        {
            return View(db.JobTypes.ToList());
        }

        // GET: RMS/JobTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            JobType jobType = db.JobTypes.Find(id);
            if (jobType == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(jobType);
        }

        // GET: RMS/JobTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RMS/JobTypes/Create To protect from overposting attacks, please enable the specific
        // properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Code,Ordinal,Visible")] JobType jobType)
        {
            if (ModelState.IsValid)
            {
                db.JobTypes.Add(jobType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(jobType);
        }

        // GET: RMS/JobTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            JobType jobType = db.JobTypes.Find(id);
            if (jobType == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(jobType);
        }

        // POST: RMS/JobTypes/Edit/5 To protect from overposting attacks, please enable the specific
        // properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Code,Ordinal,Visible")] JobType jobType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jobType);
        }

        // GET: RMS/JobTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            JobType jobType = db.JobTypes.Find(id);
            if (jobType == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(jobType);
        }

        // POST: RMS/JobTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JobType jobType = db.JobTypes.Find(id);
            db.JobTypes.Remove(jobType);
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