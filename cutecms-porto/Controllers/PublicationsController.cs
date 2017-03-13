using cutecms_porto.Areas.Identity.Models.DBModel;
using cutecms_porto.Helpers;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace cutecms_porto.Controllers
{
    [LocalizedAuthorize]
    public class PublicationsController : BaseController
    {
        #region Fields
        private IdentityEntities db = new IdentityEntities();
        #endregion Fields

        #region Methods
        // GET: Identity/Publications
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            var empId = db.Employees.Where(e => e.TranslationId == id && e.Language.CultureName.Trim().Equals(Thread.CurrentThread.CurrentCulture.Name)).FirstOrDefault().Id;
            if (empId == 0)
                throw new HttpException(602, "Page Not Translated");
            ViewBag.EmpId = empId;
            var publications = db.Publications.Include(p => p.Employee).Where(p => p.Employee.TranslationId == id && p.Employee.Language.CultureName.Trim().Equals(Thread.CurrentThread.CurrentCulture.Name)).ToList();
            return View(publications);
        }

        // GET: Identity/Publications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            Publication publication = db.Publications.Find(id);
            if (publication == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(publication);
        }

        // GET: Identity/Publications/Create
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            Publication publication = new Publication();
            publication.EmpId = id.Value;
            ViewBag.TranslationId = db.Employees.Find(id).TranslationId;
            return View(publication);
        }

        // POST: Identity/Publications/Create To protect from overposting attacks, please enable the
        // specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "Id,Name,Abstract,Ordinal,EmpId")] Publication publication)
        {
            if (ModelState.IsValid)
            {
                db.Publications.Add(publication);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = db.Employees.Find(publication.EmpId).TranslationId });
            }
            ViewBag.EmpId = publication.EmpId;
            ViewBag.TranslationId = db.Employees.Find(publication.EmpId).TranslationId;
            return View(publication);
        }

        // GET: Identity/Publications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            Publication publication = db.Publications.Find(id);
            if (publication == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            ViewBag.EmpId = publication.EmpId;
            return View(publication);
        }

        // POST: Identity/Publications/Edit/5 To protect from overposting attacks, please enable the
        // specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "Id,Name,Abstract,Ordinal,EmpId")] Publication publication)
        {
            if (ModelState.IsValid)
            {
                db.Entry(publication).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = db.Employees.Find(publication.EmpId).TranslationId });
            }
            ViewBag.EmpId = publication.EmpId;
            return View(publication);
        }

        // GET: Identity/Publications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            Publication publication = db.Publications.Find(id);
            if (publication == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(publication);
        }

        // POST: Identity/Publications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Publication publication = db.Publications.Find(id);

            db.Publications.Remove(publication);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = db.Employees.Find(publication.EmpId).TranslationId });
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