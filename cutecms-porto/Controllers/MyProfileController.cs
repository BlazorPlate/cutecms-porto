using cutecms_porto.Areas.Identity.Models.DBModel;
using cutecms_porto.Helpers;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace cutecms_porto.Controllers
{
    [LocalizedAuthorize]
    public class MyProfileController : BaseController
    {
        #region Fields
        private IdentityEntities db = new IdentityEntities();
        private string statusMessage = null;
        #endregion Fields
        #region Methods
        public int ProfileCompletion(Employee emp)
        {
            var percentage = 100;
            List<string> values = new List<string>();
            var properties = emp.GetType().GetProperties().Where(p => !p.GetGetMethod().IsVirtual && p.Name != "Id" && p.Name != "LoginId" && p.Name != "Image" && p.Name != "File" && p.Name != "Image" && p.Name != "ResumeFileName" && p.Name != "Ordinal");
            foreach (PropertyInfo propInfo in properties)
            {
                if (propInfo.GetValue(emp, null) == null)
                {
                    values.Add("NULL" + "_" + propInfo.Name);
                }
                else
                {
                    values.Add(propInfo.GetValue(emp, null).ToString());
                }
            }
            var nullValues = values.Where(nv => nv.Contains("NULL")).Count();
            var realValues = values.Where(rv => !rv.Contains("NULL")).Count();
            var allValues = values.Count();
            percentage = (realValues * 100) / allValues;
            return percentage;
        }
        public ActionResult Translations(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            var employees = db.Employees.Include(o => o.Language).Where(o => o.TranslationId == id).OrderBy(o => o.Ordinal);
            ViewBag.TranslationId = id;
            return View(employees.ToList());
        }
        public ActionResult Index(int? id, int? languageId, string statusMessage, string submit)
        {
            DefaultTab(submit);
            string currentUserId = User.Identity.GetUserId();
            int? translationId = db.Employees.Where(e => e.LoginId.Equals(currentUserId)).FirstOrDefault() == null ? null : db.Employees.Where(e => e.LoginId.Equals(currentUserId)).FirstOrDefault().TranslationId;
            int[] assignedLanguages = db.Employees.Where(e => e.TranslationId == translationId).Select(v => v.LanguageId).ToArray();
            Employee employee = new Employee();
            if (languageId == null)
            {
                employee = db.Employees.Where(e => e.LoginId.Equals(currentUserId) && (e.Language.CultureName.Trim().Equals(Thread.CurrentThread.CurrentCulture.Name))).FirstOrDefault();
            }
            if (employee == null)
            {

                ViewBag.LanguageId = new SelectList(db.IdentityLanguages.Where(l => !assignedLanguages.Contains(l.Id) && l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name");
                ViewBag.PersonalTitleId = new SelectList(TermsHelper.PersonalTitles(), "PersonalTitleId", "Value");
                ViewBag.DegreeId = new SelectList(TermsHelper.Degrees(), "DegreeId", "Value");
                ViewBag.ProgramId = new SelectList(TermsHelper.Programs(), "ProgramId", "Value");
                ViewBag.RankId = new SelectList(TermsHelper.Ranks(), "RankId", "Value");
                return View();
            }
            ViewBag.LanguageId = new SelectList(db.IdentityLanguages.Where(l => l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name", employee.LanguageId);
            ViewBag.PersonalTitleId = new SelectList(TermsHelper.PersonalTitles(), "PersonalTitleId", "Value", employee.PersonalTitleId);
            ViewBag.DegreeId = new SelectList(TermsHelper.Degrees(), "DegreeId", "Value", employee.DegreeId);
            ViewBag.ProgramId = new SelectList(TermsHelper.Programs(), "ProgramId", "Value", employee.ProgramId);
            ViewBag.RankId = new SelectList(TermsHelper.Ranks(), "RankId", "Value", employee.RankId);
            ViewBag.StatusMessage = statusMessage;
            return View("Index", employee);
        }
        [LocalizedAuthorize]
        public ActionResult Manage(int? translationId)
        {
            DefaultTab("");
            string currentUserId = User.Identity.GetUserId();
            Employee employee = new Employee();
            employee = db.Employees.Where(e => e.LoginId.Equals(currentUserId) && e.Language.CultureName.Trim().Equals(Thread.CurrentThread.CurrentCulture.Name)).SingleOrDefault();
            if (translationId == null && employee != null)
            {
                employee.TranslationId = employee.Id;
                int[] assignedLanguages = db.Employees.Where(e => e.TranslationId == translationId).Select(v => v.LanguageId).ToArray();
                ViewBag.LanguageId = new SelectList(db.IdentityLanguages.Where(l => !assignedLanguages.Contains(l.Id) && l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name", employee.LanguageId);
                ViewBag.PersonalTitleId = new SelectList(TermsHelper.PersonalTitles(), "PersonalTitleId", "Value", employee.PersonalTitleId);
                ViewBag.DegreeId = new SelectList(TermsHelper.Degrees(), "DegreeId", "Value", employee.DegreeId);
                ViewBag.ProgramId = new SelectList(TermsHelper.Programs(), "ProgramId", "Value", employee.ProgramId);
                ViewBag.RankId = new SelectList(TermsHelper.Ranks(), "RankId", "Value", employee.RankId);
            }
            else
            {
                employee = new Employee();
                employee.TranslationId = translationId;
                int[] assignedLanguages = db.Employees.Where(e => e.TranslationId == translationId).Select(v => v.LanguageId).ToArray();
                ViewBag.LanguageId = new SelectList(db.IdentityLanguages.Where(l => !assignedLanguages.Contains(l.Id) && l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name");
                ViewBag.PersonalTitleId = new SelectList(TermsHelper.PersonalTitles(), "PersonalTitleId", "Value");
                ViewBag.DegreeId = new SelectList(TermsHelper.Degrees(), "DegreeId", "Value");
                ViewBag.ProgramId = new SelectList(TermsHelper.Programs(), "ProgramId", "Value");
                ViewBag.RankId = new SelectList(TermsHelper.Ranks(), "RankId", "Value");
            }
            return View("Index", employee);
        }
        [LocalizedAuthorize]
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Manage(Employee employee, string submit)
        {
            if (ModelState.IsValid)
            {
                TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                employee.FirstName = textInfo.ToTitleCase(employee.FirstName.Trim().ToLower());
                employee.LastName = textInfo.ToTitleCase(employee.LastName.Trim().ToLower());
                string currentUserId = User.Identity.GetUserId();
                string timeStamp = DateTime.UtcNow.ToString("ddMMyyyy HHmmssfff", CultureInfo.InvariantCulture);
                if (employee.CV != null && employee.CV.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(employee.CV.FileName);
                    var extension = Path.GetExtension(employee.CV.FileName);
                    var newFileName = Helpers.StringHelper.CleanFileName(employee.FullName.Trim() + "[" + timeStamp + "]" + extension);
                    var path = String.Format("/biography/{0}", newFileName);
                    employee.CV.SaveAs(System.Web.Hosting.HostingEnvironment.MapPath(path)); ;
                    employee.ResumeFilePath = path;
                    employee.ResumeFileName = newFileName;
                }
                if (employee.Image != null && employee.Image.ContentLength > 0)
                {
                    var extension = Path.GetExtension(employee.Image.FileName);
                    //var newFileName = Helpers.StringHelper.CleanFileName(employee.Title + extension);
                    var newFileName = Helpers.StringHelper.CleanFileName(employee.FullName.Trim() + "[" + timeStamp + "]" + extension);
                    var path = String.Format("/personal-photo/{0}", newFileName);
                    employee.PersonalPhotoPath = path;
                    employee.PersonalPhotoName = newFileName;
                    using (var img = System.Drawing.Image.FromStream(employee.Image.InputStream))
                    {
                        ImageUploaderHelper.SaveImageToFolder(img, extension, new Size(230, 320), employee.PersonalPhotoPath);
                    }
                }
                employee.LoginId = User.Identity.GetUserId();
                db.Employees.AddOrUpdate(e => e.Id, employee);
                db.SaveChanges();
                if (employee.TranslationId == null)
                {
                    var userId = User.Identity.GetUserId();
                    var originalEmployeeProfile = db.Employees.Where(e => e.LoginId.Equals(userId) && e.Id == e.TranslationId).FirstOrDefault();
                    if (originalEmployeeProfile == null)
                    {
                        employee.TranslationId = employee.Id;
                    }
                    else
                    {
                        employee.TranslationId = originalEmployeeProfile.TranslationId;
                    }
                    db.Entry(employee).State = EntityState.Modified;
                    db.SaveChanges();
                }
                statusMessage = "Success";
                RouteValueDictionary rvd = new RouteValueDictionary()
                {
                  { "culture", db.IdentityLanguages.Find(employee.LanguageId).CultureName.Trim()},
                  { "controller", "MyProfile" }
                };
                rvd["statusMessage"] = statusMessage;
                rvd["submit"] = submit;
                return RedirectToRoute("MyProfile", rvd);
            }
            int[] assignedLanguages = db.Employees.Where(e => e.LoginId.Equals(employee.LoginId)).Select(e => e.LanguageId).ToArray();
            ViewBag.LanguageId = new SelectList(db.IdentityLanguages.Where(l => l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name");
            ViewBag.PersonalTitleId = new SelectList(TermsHelper.PersonalTitles(), "PersonalTitleId", "Value");
            ViewBag.DegreeId = new SelectList(TermsHelper.Degrees(), "DegreeId", "Value");
            ViewBag.ProgramId = new SelectList(TermsHelper.Programs(), "ProgramId", "Value");
            ViewBag.RankId = new SelectList(TermsHelper.Ranks(), "RankId", "Value");
            DefaultTab(submit);
            statusMessage = "Error";
            ViewBag.StatusMessage = statusMessage;
            return View("Index", employee);
        }
        // GET: Profiles/Details/5
        // GET: Profiles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(employee);
        }
        // POST: Profiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            using (IdentityEntities db = new IdentityEntities())
            {
                int idTranslationSwap = new int();
                string currentUserId = User.Identity.GetUserId();
                Employee employee = db.Employees.Find(id);
                using (var dbContextTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Employees.Remove(employee);
                        db.Entry(employee).State = System.Data.Entity.EntityState.Deleted;
                        db.SaveChanges();
                        if (employee.TranslationId == employee.Id)
                        {
                            if (db.Employees.Where(e => e.LoginId.Equals(currentUserId)).Any())
                            {
                                idTranslationSwap = db.Employees.Where(e => e.LoginId.Equals(currentUserId) && e.Id != employee.Id).First().Id;
                                foreach (var item in db.Employees.Where(e => e.LoginId.Equals(currentUserId)))
                                {
                                    item.TranslationId = idTranslationSwap;
                                    db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                                }
                            }
                        }
                        db.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();
                        ModelState.AddModelError("ERROR", ex.InnerException.ToString());
                        return View(employee);
                    }

                    if (db.Employees.Where(e => e.LoginId.Equals(currentUserId)).FirstOrDefault() != null)
                    {
                        return RedirectToAction("Translations", new { id = idTranslationSwap == 0 ? employee.TranslationId : idTranslationSwap });
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
        }
        public ActionResult Download(string FilePath, string FileName)
        {
            return File(FilePath, FileName);
        }
        private void DefaultTab(string submit)
        {
            switch (submit)
            {
                case "PersonalInfo":
                    ViewBag.ActiveInPersonalInfo = "active in";
                    ViewBag.ActiveInPersonalPhoto = "";
                    ViewBag.ActiveInAcademicInfo = "";
                    ViewBag.ActiveInBiography = "";
                    ViewBag.ActiveInContactInfo = "";

                    ViewBag.ActivePersonalInfo = "active";
                    ViewBag.ActivePersonalPhoto = "";
                    ViewBag.ActiveAcademicInfo = "";
                    ViewBag.ActiveBiography = "";
                    ViewBag.ActiveContactInfo = "";

                    ViewBag.AriaExpandedPersonalInfo = "true";
                    ViewBag.AriaExpandedPersonalPhoto = "false";
                    ViewBag.AriaExpandedAcademicInfo = "false";
                    ViewBag.AriaExpandedBiography = "false";
                    ViewBag.AriaExpandedContactInfo = "false";
                    break;

                case "PersonalPhoto":
                    ViewBag.ActiveInPersonalInfo = "";
                    ViewBag.ActiveInPersonalPhoto = "active in";
                    ViewBag.ActiveInAcademicInfo = "";
                    ViewBag.ActiveInBiography = "";
                    ViewBag.ActiveInContactInfo = "";

                    ViewBag.ActivePersonalInfo = "";
                    ViewBag.ActivePersonalPhoto = "active";
                    ViewBag.ActiveAcademicInfo = "";
                    ViewBag.ActiveBiography = "";
                    ViewBag.ActiveContactInfo = "";

                    ViewBag.AriaExpandedPersonalInfo = "false";
                    ViewBag.AriaExpandedPersonalPhoto = "true";
                    ViewBag.AriaExpandedAcademicInfo = "false";
                    ViewBag.AriaExpandedBiography = "false";
                    ViewBag.AriaExpandedContactInfo = "false";
                    break;

                case "AcademicInfo":
                    ViewBag.ActiveInPersonalInfo = "";
                    ViewBag.ActiveInPersonalPhoto = "";
                    ViewBag.ActiveInAcademicInfo = "active in";
                    ViewBag.ActiveInBiography = "";
                    ViewBag.ActiveInContactInfo = "";

                    ViewBag.ActivePersonalInfo = "";
                    ViewBag.ActivePersonalPhoto = "";
                    ViewBag.ActiveAcademicInfo = "active";
                    ViewBag.ActiveBiography = "";
                    ViewBag.ActiveContactInfo = "";

                    ViewBag.AriaExpandedPersonalInfo = "false";
                    ViewBag.AriaExpandedPersonalPhoto = "false";
                    ViewBag.AriaExpandedAcademicInfo = "true";
                    ViewBag.AriaExpandedBiography = "false";
                    ViewBag.AriaExpandedContactInfo = "false";
                    break;

                case "Biography":
                    ViewBag.ActiveInPersonalInfo = "";
                    ViewBag.ActiveInPersonalPhoto = "";
                    ViewBag.ActiveInAcademicInfo = "";
                    ViewBag.ActiveInBiography = "active in";
                    ViewBag.ActiveInContactInfo = "";

                    ViewBag.ActivePersonalInfo = "";
                    ViewBag.ActivePersonalPhoto = "";
                    ViewBag.ActiveAcademicInfo = "";
                    ViewBag.ActiveBiography = "active";
                    ViewBag.ActiveContactInfo = "";

                    ViewBag.AriaExpandedPersonalInfo = "false";
                    ViewBag.AriaExpandedPersonalPhoto = "false";
                    ViewBag.AriaExpandedAcademicInfo = "false";
                    ViewBag.AriaExpandedBiography = "true";
                    ViewBag.AriaExpandedContactInfo = "false";
                    break;

                case "ContactInfo":
                    ViewBag.ActiveInPersonalInfo = "";
                    ViewBag.ActiveInPersonalPhoto = "";
                    ViewBag.ActiveInAcademicInfo = "";
                    ViewBag.ActiveInBiography = "";
                    ViewBag.ActiveInContactInfo = "active in";

                    ViewBag.ActivePersonalInfo = "";
                    ViewBag.ActivePersonalPhoto = "";
                    ViewBag.ActiveAcademicInfo = "";
                    ViewBag.ActiveBiography = "";
                    ViewBag.ActiveContactInfo = "active";

                    ViewBag.AriaExpandedPersonalInfo = "false";
                    ViewBag.AriaExpandedPersonalPhoto = "false";
                    ViewBag.AriaExpandedAcademicInfo = "false";
                    ViewBag.AriaExpandedBiography = "false";
                    ViewBag.AriaExpandedContactInfo = "true";
                    break;

                default:
                    ViewBag.ActiveInPersonalInfo = "active in";
                    ViewBag.ActiveInPersonalPhoto = "";
                    ViewBag.ActiveInAcademicInfo = "";
                    ViewBag.ActiveInBiography = "";
                    ViewBag.ActiveInContactInfo = "";

                    ViewBag.ActivePersonalInfo = "active";
                    ViewBag.ActivePersonalPhoto = "";
                    ViewBag.ActiveAcademicInfo = "";
                    ViewBag.ActiveBiography = "";
                    ViewBag.ActiveContactInfo = "";

                    ViewBag.AriaExpandedPersonalInfo = "true";
                    ViewBag.AriaExpandedPersonalPhoto = "false";
                    ViewBag.AriaExpandedAcademicInfo = "false";
                    ViewBag.AriaExpandedBiography = "false";
                    ViewBag.AriaExpandedContactInfo = "false";
                    break;
            }
        }
        protected internal virtual new FilePathResult File(string FilePath, string FileName)
        {
            return new FilePathResult(FilePath, "*.*") { FileDownloadName = FileName };
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