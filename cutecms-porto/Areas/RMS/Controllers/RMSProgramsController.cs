using cutecms_porto.Areas.RMS.Models.DBModel;
using cutecms_porto.Helpers;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cutecms_porto.Areas.RMS.Controllers
{
    public class RMSProgramsController : BaseController
    {
        #region Fields
        private RMSEntities db = new RMSEntities();
        #endregion Fields

        #region Methods
        // GET: RMS/RMSPrograms
        public ActionResult Index()
        {
            return View(db.RMSPrograms.ToList());
        }

        // GET: RMS/RMSPrograms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            RMSProgram rMSProgram = db.RMSPrograms.Find(id);
            if (rMSProgram == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(rMSProgram);
        }

        // GET: RMS/RMSPrograms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RMS/RMSPrograms/Create To protect from overposting attacks, please enable the
        // specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Code,Visible,Ordinal")] RMSProgram rMSProgram)
        {
            if (ModelState.IsValid)
            {
                db.RMSPrograms.Add(rMSProgram);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rMSProgram);
        }

        // GET: RMS/RMSPrograms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            RMSProgram rMSProgram = db.RMSPrograms.Find(id);
            if (rMSProgram == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(rMSProgram);
        }

        // POST: RMS/RMSPrograms/Edit/5 To protect from overposting attacks, please enable the
        // specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Code,Visible,Ordinal")] RMSProgram rMSProgram)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rMSProgram).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rMSProgram);
        }

        // GET: RMS/RMSPrograms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            RMSProgram rMSProgram = db.RMSPrograms.Find(id);
            if (rMSProgram == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(rMSProgram);
        }

        // POST: RMS/RMSPrograms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RMSProgram rMSProgram = db.RMSPrograms.Find(id);
            db.RMSPrograms.Remove(rMSProgram);
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