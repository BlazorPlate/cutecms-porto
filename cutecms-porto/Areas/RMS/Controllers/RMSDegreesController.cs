using cutecms_porto.Areas.RMS.Models.DBModel;
using cutecms_porto.Helpers;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cutecms_porto.Areas.RMS.Controllers
{
    public class RMSDegreesController : BaseController
    {
        #region Fields
        private RMSEntities db = new RMSEntities();
        #endregion Fields

        #region Methods
        // GET: RMS/RMSDegrees
        public ActionResult Index()
        {
            return View(db.RMSDegrees.ToList());
        }

        // GET: RMS/RMSDegrees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            RMSDegree rMSDegree = db.RMSDegrees.Find(id);
            if (rMSDegree == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(rMSDegree);
        }

        // GET: RMS/RMSDegrees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RMS/RMSDegrees/Create To protect from overposting attacks, please enable the
        // specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Code,Visible,Ordinal")] RMSDegree rMSDegree)
        {
            if (ModelState.IsValid)
            {
                db.RMSDegrees.Add(rMSDegree);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rMSDegree);
        }

        // GET: RMS/RMSDegrees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            RMSDegree rMSDegree = db.RMSDegrees.Find(id);
            if (rMSDegree == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(rMSDegree);
        }

        // POST: RMS/RMSDegrees/Edit/5 To protect from overposting attacks, please enable the
        // specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Code,Visible,Ordinal")] RMSDegree rMSDegree)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rMSDegree).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rMSDegree);
        }

        // GET: RMS/RMSDegrees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            RMSDegree rMSDegree = db.RMSDegrees.Find(id);
            if (rMSDegree == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(rMSDegree);
        }

        // POST: RMS/RMSDegrees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RMSDegree rMSDegree = db.RMSDegrees.Find(id);
            db.RMSDegrees.Remove(rMSDegree);
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