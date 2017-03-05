using cutecms_porto.Areas.Identity.Models;
using cutecms_porto.Areas.RMS.Models;
using cutecms_porto.Areas.RMS.Models.DBModel;
using cutecms_porto.Helpers;
using Ionic.Zip;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using static cutecms_porto.Helpers.DatatableHelpers;

namespace cutecms_porto.Areas.RMS.Controllers
{
    [Authorize(Roles = "Admin, HR, Dean")]
    public class SubmissionsController : BaseController
    {
        #region Fields
        private RMSEntities db = new RMSEntities();
        private ApplicationDbContext _db = new ApplicationDbContext();
        #endregion Fields

        #region Methods
        // GET: /Submission/
        public ActionResult Index(int? id)
        {
            ViewBag.VacancyId = id;
            return View();
        }
        public JsonResult DataHandler(DTParameters param,int? id)
        {
            try
            {
                var submissionDT = new List<SubmissionViewModel>();
                List<int> submissionIds = new List<int>();
                using (RMSEntities db = new RMSEntities())
                {
                    var vacancyId = id;
                    List<string> roles = GetUserRoles();
                    var submissions = db.Submissions.Include("Vacancy").Include("Applicant").Include("Vacancy.Department").Include("Vacancy.Department.DepartmentTerms").Include("Vacancy.Department.DepartmentTerms.Language").Where(s => roles.Any(r => s.Vacancy.TenantId.Trim().Equals(Tenant.TenantId) && s.Vacancy.RoleVID.Equals(r)) && ((s.VacancyId.Equals(vacancyId.Value)) || vacancyId == null));
                    foreach (var item in submissions)
                    {
                        SubmissionViewModel submissionViewModel = new SubmissionViewModel();
                        submissionViewModel.Id = item.Id.ToString();
                        submissionViewModel.ApplicantFullName = item.Applicant.FullName;
                        submissionViewModel.SubmissionDate = item.SubmissionDate.ToString();
                        submissionViewModel.VacancyTitle = item.Vacancy.Title;
                        submissionViewModel.ResumeFilePath = item.Applicant.ResumeFilePath;
                        submissionViewModel.ResumeFileName = item.Applicant.ResumeFileName;
                        submissionViewModel.Department = item.Vacancy.Department.DepartmentTerms.Where(d => d.Language.CultureName.Trim().Equals(Thread.CurrentThread.CurrentCulture.Name) && d.DepartmentId == item.Vacancy.DeptId).FirstOrDefault()?.Value ?? item.Vacancy.Department.Code;
                        submissionDT.Add(submissionViewModel);
                    }
                }
                List<String> columnSearch = new List<string>();
                foreach (var col in param.Columns)
                {
                    columnSearch.Add(col.Search.Value);
                }
                List<SubmissionViewModel> data = new ResultSet().GetSubmissionResult(param.Search.Value, param.SortOrder, param.Start, param.Length, submissionDT, columnSearch);
                int count = new ResultSet().CountSubmission(param.Search.Value, submissionDT, columnSearch);
                DTResult<SubmissionViewModel> result = new DTResult<SubmissionViewModel>
                {
                    draw = param.Draw,
                    data = data,
                    recordsFiltered = count,
                    recordsTotal = count
                };
                foreach (var item in data)
                {
                    submissionIds.Add(Convert.ToInt32(item.Id));
                }
                TempData["submissionIds"] = submissionIds;
                TempData.Keep();
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
        }
        // GET: /Submission/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            Submission submission = db.Submissions.Include("Applicant").Include("Applicant.Gender").Include("Applicant.Gender.GenderTerms").Include("Applicant.Gender.GenderTerms.Language").Include("Applicant.Attachments").Where(s => s.Id == id).FirstOrDefault();
            if (submission == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(submission);
        }

        // GET: /Default1/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            Submission submission = db.Submissions.Include("Applicant").Include("Applicant.Gender").Include("Applicant.Gender.GenderTerms").Include("Applicant.Gender.GenderTerms.Language").Include("Applicant.Attachments").Where(s => s.Id == id).FirstOrDefault();
            if (submission == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(submission);
        }

        // POST: /Default1/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            Submission submission = db.Submissions.Find(id);
            db.Submissions.Remove(submission);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ExportCV(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            Submission submission = db.Submissions.Include("Applicant").Where(s => s.Vacancy.TenantId.Trim().Equals(Tenant.TenantId) && s.Id == id).FirstOrDefault();
            return File(submission.Applicant.ResumeFilePath, submission.Applicant.ResumeFileName);
        }

        public void ExportApplicant(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            using (ZipFile zip = new ZipFile())
            {
                zip.AlternateEncodingUsage = ZipOption.Always;
                zip.AlternateEncoding = Encoding.UTF8;
                zip.AddDirectoryByName("Applicants_CVs");
                Submission submission = db.Submissions.Include("Applicant").Include("Applicant.Attachments").Where(s => s.Vacancy.TenantId.Trim().Equals(Tenant.TenantId) && s.Id == id).FirstOrDefault();
                if (submission == null)
                {
                    throw new HttpException(400, "Bad Request");
                }
                if (System.IO.File.Exists(System.Web.Hosting.HostingEnvironment.MapPath(submission.Applicant.ResumeFilePath)))
                    zip.AddFile(System.Web.Hosting.HostingEnvironment.MapPath(submission.Applicant.ResumeFilePath), String.Format("Applicants_CVs\\{0}", submission.Id + "-" + submission.Applicant.FullName));
                if (submission.Applicant.Attachments.Count() != 0)
                {
                    foreach (var attachment in submission.Applicant.Attachments)
                    {
                        var filePath = System.Web.Hosting.HostingEnvironment.MapPath(attachment.FilePath);
                        if (System.IO.File.Exists(filePath))
                            zip.AddFile(filePath, String.Format("Applicants_CVs\\{0}", submission.Id + "-" + submission.Applicant.FullName));
                    }
                }
                Response.Clear();
                Response.BufferOutput = false;
                string zipName = String.Format("CVs_{0}.zip", DateTime.UtcNow.ToString("dd-MM-yyyy-HHmmss"));
                Response.ContentType = "application/zip";
                Response.AddHeader("content-disposition", "attachment; filename=" + zipName);
                zip.Save(Response.OutputStream);
                Response.End();
            }
            TempData.Keep();
        }
        public void ExportApplicants()
        {
            using (ZipFile zip = new ZipFile())
            {
                zip.AlternateEncodingUsage = ZipOption.Always;
                zip.AlternateEncoding = Encoding.UTF8;
                zip.AddDirectoryByName("Applicants_CVs");
                List<int> submissionIds = (List<int>)TempData["submissionIds"];
                foreach (var submissionId in submissionIds)
                {
                    var submission = db.Submissions.Include("Applicant").Include("Applicant.Attachments").Where(s => s.Vacancy.TenantId.Trim().Equals(Tenant.TenantId) && s.Id == submissionId).FirstOrDefault();
                    if (System.IO.File.Exists(System.Web.Hosting.HostingEnvironment.MapPath(submission.Applicant.ResumeFilePath)))
                        zip.AddFile(System.Web.Hosting.HostingEnvironment.MapPath(submission.Applicant.ResumeFilePath), String.Format("Applicants_CVs\\{0}", submission.Id + "-" + submission.Applicant.FullName));
                    if (submission.Applicant.Attachments.Count() != 0)
                    {
                        foreach (var attachment in submission.Applicant.Attachments)
                        {
                            var filePath = System.Web.Hosting.HostingEnvironment.MapPath(attachment.FilePath);
                            if (System.IO.File.Exists(filePath))
                                zip.AddFile(filePath, String.Format("Applicants_CVs\\{0}", submission.Id + "-" + submission.Applicant.FullName));
                        }
                    }
                }
                Response.Clear();
                Response.BufferOutput = false;
                string zipName = String.Format("CVs_{0}.zip", DateTime.UtcNow.ToString("dd-MM-yyyy-HHmmss"));
                Response.ContentType = "application/zip";
                Response.AddHeader("content-disposition", "attachment; filename=" + zipName);
                zip.Save(Response.OutputStream);
                Response.End();
            }
            TempData.Keep();
        }
        public ActionResult Download(string FilePath, string FileName)
        {
            return File(FilePath, FileName);
        }
        protected internal virtual new FilePathResult File(string filePath, string fileName)
        {
            return new FilePathResult(filePath, "*.*") { FileDownloadName = fileName };
        }

        private List<string> GetUserRoles()
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var userRoles = manager.GetRoles(User.Identity.GetUserId());
            List<string> roleIds = new List<string>();
            foreach (var item in userRoles)
            {
                roleIds.Add(_db.Roles.Where(r => r.Name.Equals(item)).Single().Id);
            }
            return roleIds;
        }
        #endregion Methods

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}