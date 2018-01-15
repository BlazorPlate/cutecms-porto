using cutecms_porto.Areas.Config.Models.DBModel;
using cutecms_porto.Areas.RMS.Models;
using cutecms_porto.Areas.RMS.Models.DBModel;
using cutecms_porto.Helpers;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading;
using System.Web;
using System.Web.Mvc;
namespace cutecms_porto.Controllers
{
    [ValidateInput(false)]
    [AllowAnonymous]
    public class CareersController : BaseController
    {
        #region Fields
        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();
        private RMSEntities db = new RMSEntities();
        private ConfigEntities configDb = new ConfigEntities();
        #endregion Fields
        #region Methods
        public static int RandomNumber(int min, int max)
        {
            lock (syncLock)
            { // synchronize
                return random.Next(min, max);
            }
        }
        // GET: /Vacancies/
        public ActionResult Index(int? page, string keywordFilter = "", int deptIdFilter = 0, int jobTypeIdFilter = 0, int statusIdFilter = 0)
        {
            var pageNumber = page ?? 1;
            keywordFilter.Trim();
            if (string.IsNullOrWhiteSpace(keywordFilter))
                keywordFilter = "";
            ViewBag.DeptIdFilter = new SelectList(TermsHelper.GetDepartmentTree(Thread.CurrentThread.CurrentCulture.Name), "Id", "Name", deptIdFilter);
            ViewBag.JobTypeIdFilter = new SelectList(TermsHelper.JobTypes(), "JobTypeId", "Value", jobTypeIdFilter);
            ViewBag.StatusIdFilter = new SelectList(TermsHelper.Statuses().Where(s => !s.Status.Code.Trim().Equals("scheduled")), "StatusId", "Value", statusIdFilter);
            ViewBag.KeywordFilter = keywordFilter;
            ViewBag.DeptId = deptIdFilter;
            ViewBag.JobTypeId = jobTypeIdFilter;
            ViewBag.StatusId = statusIdFilter;
            var vacancies = db.Vacancies.Include("Department").Include("Department.DepartmentTerms").Include("Department.DepartmentTerms.Language").Where(v => v.TenantId.Trim().Equals(Tenant.TenantId) && v.Language.CultureName.Trim().Equals(Thread.CurrentThread.CurrentCulture.Name) && (v.Title.Contains(keywordFilter.Trim()) || v.Description.Contains(keywordFilter.Trim()) || string.IsNullOrEmpty(keywordFilter)) && (v.DeptId == deptIdFilter || deptIdFilter == 0) && (v.JobTypeId == jobTypeIdFilter || jobTypeIdFilter == 0) && (v.StatusId == statusIdFilter || statusIdFilter == 0)).OrderBy(v => v.DeptId).OrderBy(v => v.Department.Ordinal).ThenByDescending(v => v.PublishedOn).ToPagedList(pageNumber, 10);
            return View(vacancies);
        }
        // GET: /Submission/Create
        public ActionResult Apply(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            Vacancy vacancy = db.Vacancies.Where(v => v.TenantId.Trim().Equals(Tenant.TenantId) && v.Id == id).FirstOrDefault();
            if (vacancy == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            ViewBag.VacancyTitle = vacancy.Title;
            return View();
        }
        // POST: /Submission/Create
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Apply(Submission submission, List<HttpPostedFileBase> attachmentFiles, int? id)
        {
            if (submission == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            if (ModelState.IsValid)
            {
                var allowedExtensions = new[] { ".png", ".jpg", ".jpeg", ".doc", ".docx", ".pdf" };
                submission.Applicant.AttachmentFiles = attachmentFiles;
                submission.Applicant.AttachmentFiles.RemoveAll(item => item == null);
                if (submission.Applicant.AttachmentFiles.Count == 0)
                {
                    ModelState.AddModelError("attachments", Resources.Resources.PleaseUploadAttachments);
                    ViewBag.VacancyTitle = db.Vacancies.Find(id).Title.ToString();
                    return View();
                }
                foreach (var item in submission.Applicant.AttachmentFiles)
                {
                    if (item != null)
                    {
                        int MaxContentLength = 20971520; //In bytes == 20MB
                        var attachemntExt = Path.GetExtension(item.FileName.ToLower());
                        if (!allowedExtensions.Contains(attachemntExt))
                        {
                            ModelState.AddModelError("files", Resources.Resources.AllowedAttachmentExtensions);
                            return View();
                        }
                        if (item.ContentLength > MaxContentLength)
                        {
                            ModelState.AddModelError("files", Resources.Resources.MaximumAllowedSize + (MaxContentLength / 1024 / 1024).ToString() + "MB");
                            return View();
                        }
                    }
                }
                using (var db = new RMSEntities())
                {
                    //submission.Applicant.File = Request.Files["Applicant.File"];
                    if (submission.Applicant.File != null && submission.Applicant.File.ContentLength > 0)
                    {
                        string submissionTimeStamp = DateTime.UtcNow.ToString("ddMMyyyy HHmmssfff", CultureInfo.InvariantCulture);
                        var vacancyName = db.Vacancies.Find(id).Title;
                        var fileName = Path.GetFileName(submission.Applicant.File.FileName);
                        var ext = Path.GetExtension(submission.Applicant.File.FileName);
                        var newFileName = StringHelper.CleanFileName(submission.Applicant.FullName + "[" + "CV-" + submission.Id + "-" + submissionTimeStamp + "-" + RandomNumber(1000000, 9999999) + "]" + ext);
                        var path = string.Format("~/fileman/Uploads/Documents/RMS/Applicants/{0}", newFileName);
                        submission.Applicant.File.SaveAs(System.Web.Hosting.HostingEnvironment.MapPath(path));
                        submission.Applicant.ResumeFilePath = path;
                        submission.Applicant.ResumeFileName = newFileName;
                        submission.SubmissionDate = DateTime.UtcNow;
                        submission.VacancyId = id.Value;
                        List<Areas.RMS.Models.DBModel.Attachment> attachments = new List<Areas.RMS.Models.DBModel.Attachment>();
                        foreach (var item in submission.Applicant.AttachmentFiles)
                        {
                            fileName = Path.GetFileName(item.FileName);
                            ext = Path.GetExtension(item.FileName);
                            newFileName = StringHelper.CleanFileName(submission.Applicant.FullName + "[" + "Att-" + submission.Id + "-" + submissionTimeStamp + "-" + RandomNumber(1000000, 9999999) + "]" + ext);
                            path = String.Format("~/fileman/Uploads/Documents/RMS/Applicants/Attachments/{0}", newFileName);
                            newFileName = StringHelper.CleanFileName(newFileName);
                            item.SaveAs(System.Web.Hosting.HostingEnvironment.MapPath(path));
                            Areas.RMS.Models.DBModel.Attachment attachment = new Areas.RMS.Models.DBModel.Attachment();
                            attachment.FilePath = path;
                            attachment.FileName = newFileName;
                            attachments.Add(attachment);
                        }
                        submission.Applicant.Attachments = attachments;
                        db.Submissions.Add(submission);
                        db.SaveChanges();
                        return RedirectToAction("Acknowledgement", new { id = submission.Id });
                    }
                    else
                    {
                        ModelState.AddModelError("InvalidFile","Please uploud non-empty CV");
                    }
                }
            }
            ViewBag.VacancyTitle = db.Vacancies.Find(id).Title.ToString();
            return View(submission);
        }
        public ActionResult Acknowledgement(int? id)
        {
            if (id == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            Submission submission = db.Submissions.Find(id);
            Notification notification = configDb.Notifications.Include("NotificationTerms").Include("NotificationTerms.Language").Include("SMTPSetting").Where(c => c.NotificationCode.Code.Trim().Equals("RMS")).FirstOrDefault();
            NotificationViewModel notificationViewModel = new NotificationViewModel();
            notificationViewModel.ApplicationNumber = submission.Id;
            notificationViewModel.FullName = submission.Applicant.FullName;
            notificationViewModel.RecepientEmail = submission.Applicant.Email;
            if (notification != null && notification.NotificationTerms.Count != 0)
            {
                notificationViewModel.SenderEmail = notification.SMTPSetting.SenderEmail;
                notificationViewModel.SenderPasswordHash = notification.SMTPSetting.SenderPasswordHash;
                notificationViewModel.Subject = notification.NotificationTerms.Where(n => n.Language.CultureName.Trim().Equals(Thread.CurrentThread.CurrentCulture.Name)).FirstOrDefault().Subject;
                notificationViewModel.Body = notification.NotificationTerms.Where(n => n.Language.CultureName.Trim().Equals(Thread.CurrentThread.CurrentCulture.Name)).FirstOrDefault().Body;
                notificationViewModel.SMTP = notification.SMTPSetting.SMTP;
                notificationViewModel.EnableSsl = notification.SMTPSetting.EnableSsl;
                notificationViewModel.Port = notification.SMTPSetting.Port;
                NotifyApplicant(notificationViewModel);
            }
            return View(notificationViewModel);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            var translationId = db.Vacancies.Find(id).TranslationId;
            IEnumerable<Vacancy> translatedVacancies = db.Vacancies.Include("Status").Include("Language").Where(v => v.TenantId.Trim().Equals(Tenant.TenantId) && v.TranslationId == translationId);
            Vacancy translatedVacancy = translatedVacancies.Where(v => v.Language.CultureName.Trim().Equals(Thread.CurrentThread.CurrentCulture.Name)).FirstOrDefault();
            if (translatedVacancy == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            if (!translatedVacancy.Status.Code.Equals("published"))
            {
                throw new HttpException(601, "Page Not Published");
            }
            return View(translatedVacancy);
        }
        private void NotifyApplicant(NotificationViewModel notification)
        {
            if (notification != null)
            {
                // Send: Configure the client:
                using (var client = new SmtpClient(notification.SMTP))
                {
                    client.Port = notification.Port;//587
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    // Create the credentials:
                    System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(notification.SenderEmail, notification.SenderPasswordHash);
                    client.EnableSsl = notification.EnableSsl;
                    client.Credentials = credentials;
                    // Create the message:
                    MailMessage message = new MailMessage(notification.SenderEmail, notification.RecepientEmail);
                    message.Subject = notification.Subject;
                    message.Body = CultureHelper.IsRighToLeft() ? @"<p dir=RTL><strong style=""color:brown"">" + Resources.Resources.YourAppNumber + "  [" + notification.ApplicationNumber + "]</strong><br>" + notification.Body + "</p>" : @"<p><strong style=""color:brown"">" + Resources.Resources.YourAppNumber + "[" + notification.ApplicationNumber + "]</strong><br>" + notification.Body + "</p>";
                    message.IsBodyHtml = true;
                    message.Priority = MailPriority.High;
                    try
                    {
                        client.Send(message);
                    }
                    catch (SmtpFailedRecipientsException ex)
                    {
                        for (int i = 0; i < ex.InnerExceptions.Length; i++)
                        {
                            SmtpStatusCode status = ex.InnerExceptions[i].StatusCode;
                            if (status == SmtpStatusCode.MailboxBusy ||
                                status == SmtpStatusCode.MailboxUnavailable)
                            {
                                Console.WriteLine("Delivery failed - retrying in 5 seconds.");
                                Thread.Sleep(5000);
                                client.Send(message);
                            }
                            else
                            {
                                Console.WriteLine("Failed to deliver message to {0}",
                                    ex.InnerExceptions[i].FailedRecipient);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Exception caught in RetryIfBusy(): {0}",
                                ex.ToString());
                    }
                }
            }
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