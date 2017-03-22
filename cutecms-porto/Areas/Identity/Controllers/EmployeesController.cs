using cutecms_porto.Areas.Identity.Models;
using cutecms_porto.Areas.Identity.Models.DBModel;
using cutecms_porto.Helpers;
using Microsoft.AspNet.Identity;
using System;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
namespace cutecms_porto.Areas.Identity.Controllers
{
    [LocalizedAuthorize(Roles = "Admin")]
    public class EmployeesController : BaseController
    {
        #region Fields
        private IdentityEntities db = new IdentityEntities();
        private ApplicationDbContext _db = new ApplicationDbContext();
        #endregion Fields
        #region Methods
        public ActionResult Translations(int? id, string loginId)
        {
            ViewBag.TranslationId = id;
            ViewBag.LoginId = loginId;
            var employees = db.Employees.Where(o => o.TranslationId == id).OrderBy(o => o.Ordinal);
            return View(employees.ToList());
        }
        // GET: Identity/Employees
        public ActionResult Index(string statusMessage, int? page, string employeeNameFilter, int? languageIdFilter, int? employeeTypeIdFilter, bool hasAccountFilter = true)
        {
            var pageNumber = page ?? 1;
            ViewBag.EmployeeNameFilter = employeeNameFilter;
            ViewBag.EmployeeTypeIdFilter = new SelectList(TermsHelper.EmployeeTypes(), "EmployeeTypeId", "Value", employeeTypeIdFilter);
            ViewBag.LanguageIdFilter = new SelectList(db.IdentityLanguages.Where(l => l.IsEnabled).OrderBy(l => l.Ordinal), "Id", "Name", languageIdFilter); ;
            ViewBag.HasAccountFilter = hasAccountFilter;
            ViewBag.HasAccount = hasAccountFilter;
            ViewBag.EmployeeTypeId = employeeTypeIdFilter;
            ViewBag.LanguageId = languageIdFilter;
            IQueryable<Employee> employees;
            if (employeeTypeIdFilter.HasValue)
            {
                employees = (from e in db.Employees
                             join ed in db.EmpInDepts on e.TranslationId equals ed.Employee.TranslationId
                             join et in db.EmployeeTypes on ed.EmployeeTypeId equals et.Id
                             where et.Id == employeeTypeIdFilter && (e.LanguageId == languageIdFilter || languageIdFilter == null) && (e.FirstName.Trim().Contains(employeeNameFilter.Trim()) || e.MiddleName.Trim().Contains(employeeNameFilter.Trim()) || e.LastName.Trim().Contains(employeeNameFilter.Trim()) || string.IsNullOrEmpty(employeeNameFilter)) && (!string.IsNullOrEmpty(e.LoginId)) == hasAccountFilter
                             select e).Distinct();
            }
            else
            {
                employees = (from e in db.Employees
                             where (e.LanguageId == languageIdFilter || languageIdFilter == null) && (e.FirstName.Trim().Contains(employeeNameFilter.Trim()) || e.MiddleName.Trim().Contains(employeeNameFilter.Trim()) || e.LastName.Trim().Contains(employeeNameFilter.Trim()) || string.IsNullOrEmpty(employeeNameFilter) && (e.LanguageId == languageIdFilter || languageIdFilter == null) && (!string.IsNullOrEmpty(e.LoginId)) == hasAccountFilter)
                             orderby e.LanguageId, e.Ordinal
                             select e).Distinct();
            }
            ViewBag.Message = statusMessage;
            return View(employees.OrderBy(e => e.TranslationId).ThenBy(e => e.LanguageId).ThenBy(e => e.Ordinal).ToPagedList(pageNumber, 10));
        }
        // GET: Identity/Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            Employee employee = db.Employees.Where(e => e.Id == id).FirstOrDefault();
            if (employee == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(employee);
        }

        // GET: Identity/Employees/Create
        public ActionResult Create(int? id, string loginId)
        {
            int[] assignedLanguages = db.Employees.Where(e => e.TranslationId == id).Select(e => e.LanguageId).ToArray();
            ViewBag.LanguageId = new SelectList(db.IdentityLanguages.Where(l => !assignedLanguages.Contains(l.Id) && l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name");
            ViewBag.LoginId = new SelectList(_db.Users.OrderBy(u => u.Email), "Id", "UserName", loginId);
            ViewBag.DegreeId = new SelectList(TermsHelper.Degrees(), "DegreeId", "Value");
            ViewBag.PersonalTitleId = new SelectList(TermsHelper.PersonalTitles(), "PersonalTitleId", "Value");
            ViewBag.ProgramId = new SelectList(TermsHelper.Programs(), "ProgramId", "Value");
            ViewBag.RankId = new SelectList(TermsHelper.Ranks(), "RankId", "Value");
            Employee employees = new Employee();
            employees.TranslationId = id;
            employees.LoginId = loginId;
            return View(employees);
        }

        // POST: Identity/Employees/Create To protect from overposting attacks, please enable the
        // specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LoginId,Image,PersonalTitleId,FirstName,MiddleName,LastName,Biography,CV,RankId,DegreeId,ProgramId,OfficeNumber,Mobile,LandLine,Extension,FacebookUrl,TwitterUrl,YouTubeUrl,GooglePlusUrl,LinkedInUrl,Ordinal,LanguageId,TranslationId,Istranslated")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                employee.FirstName = textInfo.ToTitleCase(employee.FirstName.Trim().ToLower());
                employee.LastName = textInfo.ToTitleCase(employee.LastName.Trim().ToLower());
                string timeStamp = DateTime.UtcNow.ToString("ddMMyyyy HHmmssfff", CultureInfo.InvariantCulture);
                if (employee.CV != null && employee.CV.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(employee.CV.FileName);
                    var extension = Path.GetExtension(employee.CV.FileName);
                    var newFileName = Helpers.StringHelper.CleanFileName(employee.FullName.Trim() + "-" + timeStamp + "-" + extension);
                    //var path = String.Format("/fileman/Uploads/Documents/Identity/Employees/Biography/{0}", newFileName);
                    var path = String.Format("/fileman/Uploads/Documents/Identity/Employees/Biography/{0}", newFileName);
                    employee.CV.SaveAs(System.Web.Hosting.HostingEnvironment.MapPath(path)); ;
                    employee.ResumeFilePath = path;
                    employee.ResumeFileName = newFileName;
                }
                if (employee.Image != null && employee.Image.ContentLength > 0)
                {
                    var extension = Path.GetExtension(employee.Image.FileName);
                    //var ~/fileman/Uploads/Images/Identity/Employees/Personal-Photos newFileName = Helpers.StringHelper.CleanFileName(employee.Title + extension);
                    var newFileName = Helpers.StringHelper.CleanFileName(employee.FullName.Trim() + "-" + timeStamp + "-" + extension);
                    //var path = String.Format("/personal-photo/{0}", newFileName);
                    var path = String.Format("/fileman/Uploads/Images/Identity/Employees/Personal-Photos/{0}", newFileName);
                    employee.PersonalPhotoPath = path;
                    employee.PersonalPhotoName = newFileName;
                    using (var img = System.Drawing.Image.FromStream(employee.Image.InputStream))
                    {
                        ImageUploaderHelper.SaveImageToFolder(img, extension, new Size(230, 320), employee.PersonalPhotoPath);
                    }
                }
                db.Employees.Add(employee);
                try
                {
                    db.SaveChanges();
                    if (employee.TranslationId == null)
                        employee.TranslationId = employee.Id;
                    db.Entry(employee).State = EntityState.Modified;
                    db.SaveChanges();
                }
                catch
                {
                    ViewBag.LoginId = new SelectList(_db.Users.OrderBy(u => u.Email), "Id", "UserName", employee.LoginId);
                    int[] assignedLanguages = db.Employees.Where(e => e.TranslationId == employee.TranslationId).Select(v => v.LanguageId).ToArray();
                    ViewBag.LanguageId = new SelectList(db.IdentityLanguages.Where(l => !assignedLanguages.Contains(l.Id) && l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name");
                    ViewBag.DegreeId = new SelectList(TermsHelper.Degrees(), "DegreeId", "Value", employee.DegreeId);
                    ViewBag.PersonalTitleId = new SelectList(TermsHelper.PersonalTitles(), "PersonalTitleId", "Value", employee.PersonalTitleId);
                    ViewBag.ProgramId = new SelectList(TermsHelper.Programs(), "ProgramId", "Value", employee.ProgramId);
                    ViewBag.RankId = new SelectList(TermsHelper.Ranks(), "RankId", "Value", employee.RankId);
                    ModelState.AddModelError("SqlError", Resources.Resources.DuplicateError);
                    return View(employee);
                }
                return RedirectToAction("Index");
            }
            ViewBag.LoginId = new SelectList(_db.Users.OrderBy(u => u.Email), "Id", "UserName", employee.LoginId);
            ViewBag.LanguageId = new SelectList(db.IdentityLanguages.Where(l => l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name", employee.LanguageId);
            ViewBag.DegreeId = new SelectList(TermsHelper.Degrees(), "DegreeId", "Value", employee.DegreeId);
            ViewBag.PersonalTitleId = new SelectList(TermsHelper.PersonalTitles(), "PersonalTitleId", "Value", employee.PersonalTitleId);
            ViewBag.ProgramId = new SelectList(TermsHelper.Programs(), "ProgramId", "Value", employee.ProgramId);
            ViewBag.RankId = new SelectList(TermsHelper.Ranks(), "RankId", "Value", employee.RankId);
            return View(employee);
        }

        // GET: Identity/Employees/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.LoginId = new SelectList(_db.Users.OrderBy(u => u.Email), "Id", "UserName", employee.LoginId);
            ViewBag.LanguageId = new SelectList(db.IdentityLanguages.Where(l => l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name", employee.LanguageId);
            ViewBag.DegreeId = new SelectList(TermsHelper.Degrees(), "DegreeId", "Value", employee.DegreeId);
            ViewBag.PersonalTitleId = new SelectList(TermsHelper.PersonalTitles(), "PersonalTitleId", "Value", employee.PersonalTitleId);
            ViewBag.ProgramId = new SelectList(TermsHelper.Programs(), "ProgramId", "Value", employee.ProgramId);
            ViewBag.RankId = new SelectList(TermsHelper.Ranks(), "RankId", "Value", employee.RankId);
            return View(employee);
        }

        // POST: Identity/Employees/Edit/5 To protect from overposting attacks, please enable the
        // specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LoginId,Image,PersonalPhotoName,PersonalPhotoPath,PersonalTitleId,FirstName,MiddleName,LastName,Biography,CV,ResumeFileName,ResumeFilePath,RankId,DegreeId,ProgramId,OfficeNumber,Mobile,LandLine,Extension,FacebookUrl,TwitterUrl,YouTubeUrl,GooglePlusUrl,LinkedInUrl,Ordinal,LanguageId,TranslationId,Istranslated")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                employee.FirstName = textInfo.ToTitleCase(employee.FirstName.Trim().ToLower());
                employee.LastName = textInfo.ToTitleCase(employee.LastName.Trim().ToLower());
                string timeStamp = DateTime.UtcNow.ToString("ddMMyyyy HHmmssfff", CultureInfo.InvariantCulture);
                if (employee.CV != null && employee.CV.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(employee.CV.FileName);
                    var extension = Path.GetExtension(employee.CV.FileName);
                    var newFileName = Helpers.StringHelper.CleanFileName(employee.FullName.Trim() + "-" + timeStamp + "-" + extension);
                    var path = String.Format("/fileman/Uploads/Documents/Identity/Employees/Biography/{0}", newFileName);
                    employee.CV.SaveAs(System.Web.Hosting.HostingEnvironment.MapPath(path)); ;
                    employee.ResumeFilePath = path;
                    employee.ResumeFileName = newFileName;
                }
                if (employee.Image != null && employee.Image.ContentLength > 0)
                {
                    var extension = Path.GetExtension(employee.Image.FileName);
                    //var newFileName = Helpers.StringHelper.CleanFileName(employee.Title + extension);
                    var newFileName = Helpers.StringHelper.CleanFileName(employee.FullName.Trim() + "-" + timeStamp + "-" + extension);
                    var path = String.Format("/fileman/Uploads/Images/Identity/Employees/Personal-Photos/{0}", newFileName);
                    employee.PersonalPhotoPath = path;
                    employee.PersonalPhotoName = newFileName;
                    using (var img = System.Drawing.Image.FromStream(employee.Image.InputStream))
                    {
                        ImageUploaderHelper.SaveImageToFolder(img, extension, new Size(230, 230), employee.PersonalPhotoPath);
                    }
                }
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                foreach (var item in db.Employees.Where(e => e.TranslationId == employee.TranslationId))
                {
                    item.LoginId = employee.LoginId;
                    db.Entry(item).State = EntityState.Modified;
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LoginId = new SelectList(_db.Users.OrderBy(u => u.Email), "Id", "UserName", employee.LoginId);
            ViewBag.LanguageId = new SelectList(db.IdentityLanguages.Where(l => l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name", employee.LanguageId);
            ViewBag.DegreeId = new SelectList(TermsHelper.Degrees(), "DegreeId", "Value", employee.DegreeId);
            ViewBag.PersonalTitleId = new SelectList(TermsHelper.PersonalTitles(), "PersonalTitleId", "Value", employee.PersonalTitleId);
            ViewBag.ProgramId = new SelectList(TermsHelper.Programs(), "ProgramId", "Value", employee.ProgramId);
            ViewBag.RankId = new SelectList(TermsHelper.Ranks(), "RankId", "Value", employee.RankId);
            return View(employee);
        }

        // GET: Identity/Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            Employee employee = db.Employees.Where(e => e.Id == id).FirstOrDefault();
            if (employee == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(employee);
        }

        // POST: Identity/Employees/Delete/5
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
                        if (employee.TranslationId == employee.Id)
                        {

                            if (db.Employees.Where(e => e.LoginId.Equals(currentUserId)).Count() == 1)
                            {
                                db.Entry(employee).State = System.Data.Entity.EntityState.Deleted;
                                db.Employees.Remove(employee);
                            }
                            else
                            {
                                db.Employees.Remove(employee);
                                db.Entry(employee).State = System.Data.Entity.EntityState.Deleted;
                                db.SaveChanges();
                                idTranslationSwap = db.Employees.Where(e => e.LoginId.Equals(currentUserId) && e.Id != employee.Id).First().Id;
                                foreach (var item in db.Employees.Where(e => e.LoginId.Equals(currentUserId)))
                                {
                                    item.TranslationId = idTranslationSwap;
                                    db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                                }
                            }
                        }
                        else
                        {
                            db.Entry(employee).State = System.Data.Entity.EntityState.Deleted;
                            db.Employees.Remove(employee);
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
                    return RedirectToAction("Index");
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