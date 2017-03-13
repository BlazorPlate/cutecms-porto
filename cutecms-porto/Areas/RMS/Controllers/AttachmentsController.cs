using cutecms_porto.Areas.RMS.Models.DBModel;
using cutecms_porto.Helpers;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cutecms_porto.Areas.RMS.Controllers
{
    [LocalizedAuthorize(Roles = "Admin, HR")]
    public class AttachmentsController : BaseController
    {
        #region Fields
        private RMSEntities db = new RMSEntities();
        #endregion Fields

        #region Methods
        // GET: RMS/Attachments
        public ActionResult Index(int? applicantId)
        {
            if (applicantId == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            var attachements = db.Attachments.Include(a => a.Applicant).Where(a => a.ApplicantId == applicantId);
            return View(attachements.ToList());
        }

        // GET: RMS/Attachments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            Attachment attachment = db.Attachments.Find(id);
            if (attachment == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(attachment);
        }

        // GET: RMS/Attachments/Create
        public ActionResult Create()
        {
            ViewBag.ApplicantId = new SelectList(db.Applicants, "Id", "FirstName");
            return View();
        }

        // POST: RMS/Attachments/Create To protect from overposting attacks, please enable the
        // specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FileName,FilePath,ApplicantId")] Attachment attachment)
        {
            if (ModelState.IsValid)
            {
                db.Attachments.Add(attachment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ApplicantId = new SelectList(db.Applicants, "Id", "FirstName", attachment.ApplicantId);
            return View(attachment);
        }

        // GET: RMS/Attachments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            Attachment attachment = db.Attachments.Find(id);
            if (attachment == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            ViewBag.ApplicantId = new SelectList(db.Applicants, "Id", "FirstName", attachment.ApplicantId);
            return View(attachment);
        }

        // POST: RMS/Attachments/Edit/5 To protect from overposting attacks, please enable the
        // specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FileName,FilePath,ApplicantId")] Attachment attachment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(attachment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApplicantId = new SelectList(db.Applicants, "Id", "FirstName", attachment.ApplicantId);
            return View(attachment);
        }

        public ActionResult Download(string FilePath, string FileName)
        {
            return File(FilePath, FileName);
        }

        // GET: RMS/Attachments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            Attachment attachment = db.Attachments.Find(id);
            if (attachment == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(attachment);
        }

        // POST: RMS/Attachments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Attachment attachment = db.Attachments.Find(id);
            db.Attachments.Remove(attachment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        protected internal virtual new FilePathResult File(string FilePath, string FileName)
        {
            return new FilePathResult(FilePath, "*.*") { FileDownloadName = FileName };
        }
        #endregion Methods
    }
}