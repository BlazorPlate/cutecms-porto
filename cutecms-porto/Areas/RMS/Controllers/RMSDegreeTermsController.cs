using cutecms_porto.Areas.RMS.Models.DBModel;
using cutecms_porto.Helpers;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cutecms_porto.Areas.RMS.Controllers
{
    public class RMSDegreeTermsController : BaseController
    {
        #region Fields
        private RMSEntities db = new RMSEntities();
        #endregion Fields

        #region Methods
        // GET: RMS/DegreeTerms
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            var rmsDegreeTerms = db.RMSDegreeTerms.Include(d => d.Degree).Include(d => d.Language).Where(d => d.DegreeId == id);
            ViewBag.DegreeId = id;
            return View(rmsDegreeTerms.ToList());
        }

        // GET: RMS/DegreeTerms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            RMSDegreeTerm rmsDegreeTerm = db.RMSDegreeTerms.Include("Language").Include("Degree").Where(d => d.Id == id).FirstOrDefault();
            if (rmsDegreeTerm == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(rmsDegreeTerm);
        }

        // GET: RMS/DegreeTerms/Create
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            ViewBag.DegreeId = id;
            ViewBag.DegreeCode = db.RMSDegrees.Find(id).Code;
            int[] assignedLanguages = db.RMSDegreeTerms.Where(t => t.DegreeId == id).Select(t => t.LanguageId).ToArray();
            ViewBag.LanguageId = new SelectList(db.RMSLanguages.Where(l => !assignedLanguages.Contains(l.Id) && l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name");
            return View();
        }

        // POST: RMS/DegreeTerms/Create To protect from overposting attacks,
        // please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LanguageId,Value,DegreeId")] RMSDegreeTerm rmsDegreeTerm)
        {
            if (ModelState.IsValid)
            {
                db.RMSDegreeTerms.Add(rmsDegreeTerm);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = rmsDegreeTerm.DegreeId });
            }
            ViewBag.DegreeId = rmsDegreeTerm.DegreeId;
            ViewBag.DegreeCode = db.RMSDegrees.Find(rmsDegreeTerm.DegreeId).Code;
            int[] assignedLanguages = db.RMSDegreeTerms.Where(t => t.DegreeId == rmsDegreeTerm.DegreeId && t.LanguageId != rmsDegreeTerm.LanguageId).Select(t => t.LanguageId).ToArray();
            ViewBag.LanguageId = new SelectList(db.RMSLanguages.Where(l => !assignedLanguages.Contains(l.Id) && l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name", rmsDegreeTerm.LanguageId);
            return View(rmsDegreeTerm);
        }

        // GET: RMS/DegreeTerms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            RMSDegreeTerm rmsDegreeTerm = db.RMSDegreeTerms.Find(id);
            if (rmsDegreeTerm == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            ViewBag.DegreeCode = db.RMSDegrees.Find(rmsDegreeTerm.DegreeId).Code;
            int[] assignedLanguages = db.RMSDegreeTerms.Where(t => t.DegreeId == rmsDegreeTerm.DegreeId && t.LanguageId != rmsDegreeTerm.LanguageId).Select(t => t.LanguageId).ToArray();
            ViewBag.LanguageId = new SelectList(db.RMSLanguages.Where(l => !assignedLanguages.Contains(l.Id) && l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name", rmsDegreeTerm.LanguageId);
            return View(rmsDegreeTerm);
        }

        // POST: RMS/DegreeTerms/Edit/5 To protect from overposting attacks,
        // please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LanguageId,Value,DegreeId")] RMSDegreeTerm rmsDegreeTerm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rmsDegreeTerm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = rmsDegreeTerm.DegreeId });
            }
            ViewBag.DegreeCode = db.RMSDegrees.Find(rmsDegreeTerm.DegreeId).Code;
            int[] assignedLanguages = db.RMSDegreeTerms.Where(t => t.DegreeId == rmsDegreeTerm.DegreeId && t.LanguageId != rmsDegreeTerm.LanguageId).Select(t => t.LanguageId).ToArray();
            ViewBag.LanguageId = new SelectList(db.RMSLanguages.Where(l => !assignedLanguages.Contains(l.Id) && l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name", rmsDegreeTerm.LanguageId);
            return View(rmsDegreeTerm);
        }

        // GET: RMS/DegreeTerms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            RMSDegreeTerm rmsDegreeTerm = db.RMSDegreeTerms.Include("Language").Include("Degree").Where(d => d.Id == id).FirstOrDefault();
            if (rmsDegreeTerm == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(rmsDegreeTerm);
        }

        // POST: RMS/DegreeTerms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RMSDegreeTerm rmsDegreeTerm = db.RMSDegreeTerms.Find(id);
            db.RMSDegreeTerms.Remove(rmsDegreeTerm);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = rmsDegreeTerm.DegreeId });
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