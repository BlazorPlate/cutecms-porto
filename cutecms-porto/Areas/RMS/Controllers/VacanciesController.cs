using cutecms_porto.Areas.CMS.Models.DBModel;
using cutecms_porto.Areas.Identity.Models;
using cutecms_porto.Areas.Identity.Models.DBModel;
using cutecms_porto.Areas.RMS.Models;
using cutecms_porto.Areas.RMS.Models.DBModel;
using cutecms_porto.Helpers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using static cutecms_porto.Helpers.DatatableHelpers;

namespace cutecms_porto.Areas.RMS.Controllers
{
    [ValidateInput(false)]
    [Authorize(Roles = "Admin, HR")]
    public class VacanciesController : BaseController
    {
        #region Fields
        private RMSEntities db = new RMSEntities();
        private IdentityEntities IdentityDb = new IdentityEntities();
        private ApplicationDbContext _db = new ApplicationDbContext();
        private int? StatusId;
        private List<object> DepartmentsList = new List<object>();
        private string DepartmentPath = "";
        #endregion Fields
        #region Methods
        public ActionResult Translations(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            ViewBag.TranslationId = id;

            var vacancies = db.Vacancies.Include("Language").Where(v => v.TenantId.Trim().Equals(Tenant.TenantId) && v.TranslationId == id);
            return View(vacancies.ToList());
        }
        // GET: /Vacancies/
        [Authorize]
        public ActionResult Index(int? statusId = null)
        {
            ViewBag.StatusMessageId = statusId;
            return View();
        }
        public JsonResult DataHandler(DTParameters param)
        {
            try
            {
                var VacancyDT = new List<VacancyViewModel>();
                using (RMSEntities db = new RMSEntities())
                {
                    List<string> roles = GetUserRoles();
                    var vacancies = db.Vacancies.Include("Language").Include("Status").Include("JobType").Include("Department").Where(v => v.TenantId.Trim().Equals(Tenant.TenantId) && (roles.Any(r => v.RoleVID.Equals(r)) || v.RoleVID == null) || v.RoleVID == null).OrderBy(v => v.Title);
                    foreach (var item in vacancies)
                    {
                        string departmentName = (TermsHelper.DepartmentTerms().Where(d => d.DepartmentId == item.Department.Id).FirstOrDefault() == null) ?
                                                 db.RMSDepartments.Include("Department").Where(d => d.Id == item.Department.Id).FirstOrDefault().Code :
                                                 TermsHelper.DepartmentTerms().Where(d => d.DepartmentId == item.Department.Id).FirstOrDefault().Value;
                        string jobTypeName = (TermsHelper.JobTypes().Where(d => d.JobTypeId == item.JobType.Id).FirstOrDefault() == null) ?
                                              db.JobTypes.Where(d => d.Id == item.JobType.Id).FirstOrDefault().Code :
                                              TermsHelper.JobTypes().Where(d => d.JobTypeId == item.JobType.Id).FirstOrDefault().Value;
                        string statusName = (TermsHelper.Statuses().Where(d => d.StatusId == item.Status.Id).FirstOrDefault() == null) ?
                                             db.Statuses.Where(d => d.Id == item.Status.Id).FirstOrDefault().Code :
                                             TermsHelper.Statuses().Where(d => d.StatusId == item.Status.Id).FirstOrDefault().Value;
                        VacancyViewModel vacancyViewModel = new VacancyViewModel();
                        vacancyViewModel.Id = item.Id;
                        vacancyViewModel.Code = item.Code;
                        vacancyViewModel.Title = item.Title;
                        vacancyViewModel.Language = item.Language.Name;
                        vacancyViewModel.LanguageId = item.LanguageId;
                        vacancyViewModel.Department = departmentName;
                        vacancyViewModel.JobType = jobTypeName;
                        vacancyViewModel.PublishedOn = item.PublishedOn.ToString();
                        vacancyViewModel.ExpiredOn = item.ExpiredOn.ToString();
                        vacancyViewModel.IsTranslated = item.IsTranslated;
                        vacancyViewModel.TranslationId = item.TranslationId;
                        vacancyViewModel.Status = statusName;
                        VacancyDT.Add(vacancyViewModel);
                    }
                }

                List<String> columnSearch = new List<string>();

                foreach (var col in param.Columns)
                {
                    columnSearch.Add(col.Search.Value);
                }

                List<VacancyViewModel> data = new ResultSet().GetVacancyResult(param.Search.Value, param.SortOrder, param.Start, param.Length, VacancyDT, columnSearch);
                int count = new ResultSet().CountVacancy(param.Search.Value, VacancyDT, columnSearch);
                DTResult<VacancyViewModel> result = new DTResult<VacancyViewModel>
                {
                    draw = param.Draw,
                    data = data,
                    recordsFiltered = count,
                    recordsTotal = count
                };
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
        }
        // GET: /Vacancies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            List<string> roles = GetUserRoles();
            Vacancy vacancy = db.Vacancies.Include("Language").Include("Program").Include("Program.ProgramTerms").Include("Program.ProgramTerms.Language").Include("Status").Include("Status.StatusTerms").Include("Status.StatusTerms.Language").Include("JobType").Include("JobType.JobTypeTerms").Include("JobType.JobTypeTerms.Language").Where(v => v.TenantId.Trim().Equals(Tenant.TenantId) && (roles.Any(r => v.RoleVID.Equals(r)) || v.RoleVID == null) && v.Id == id).FirstOrDefault();
            if (vacancy == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            ViewBag.Author = _db.Users.Find(vacancy.Author).UserName;
            ViewBag.ModifiedBy = string.IsNullOrEmpty(vacancy.ModifiedBy) ? Resources.Resources.NotAvailable : ViewBag.ModifiedBy = _db.Users.Find(vacancy.ModifiedBy).UserName;
            return View(vacancy);
        }
        // GET: /Vacancies/Create
        public ActionResult Create(int? id)
        {
            var vacanyWithDR = new CreateVacancyWithDRViewModel();
            ViewBag.RoleVID = new SelectList(_db.Roles, "Id", "Name");
            ViewBag.JobTypeId = new SelectList(TermsHelper.JobTypes(), "JobTypeId", "Value");
            ViewBag.ProgramId = new SelectList(TermsHelper.Programs(), "ProgramId", "Value");
            ViewBag.StatusId = new SelectList(TermsHelper.Statuses(), "StatusId", "Value");
            int[] assignedLanguages = db.Vacancies.Where(v => v.TranslationId == id).Select(v => v.LanguageId).ToArray();
            ViewBag.LanguageId = new SelectList(db.RMSLanguages.Where(l => !assignedLanguages.Contains(l.Id) && l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name");
            ViewBag.DeptId = new SelectList(GetDepartmentsServerSide(Thread.CurrentThread.CurrentCulture.Name), "Id", "Name");
            vacanyWithDR.TranslationId = id;
            return View(vacanyWithDR);
        }
        // POST: /Vacancies/Create To protect from overposting attacks, please enable the specific
        // properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken, ValidateInput(false)]
        public ActionResult Create(CreateVacancyWithDRViewModel vacanyWithDR, string status)
        {
            if (ModelState.IsValid)
            {
                var vacancyStatus = db.Statuses.Find(vacanyWithDR.StatusId);
                if (vacancyStatus.Code.Trim().Equals("published"))
                    vacanyWithDR.PublishedOn = DateTime.Now;
                var vacancy = new Vacancy();
                vacancy.TenantId = Tenant.TenantId;
                vacancy.Code = "0";
                vacancy.Title = vacanyWithDR.Title;
                vacancy.Description = vacanyWithDR.Description;
                vacancy.Requirements = vacanyWithDR.Requirements;
                vacancy.Skills = vacanyWithDR.Skills;
                vacancy.Documents = vacanyWithDR.Documents;
                vacancy.DeptId = vacanyWithDR.DeptId;
                vacancy.JobTypeId = vacanyWithDR.JobTypeId;
                vacancy.ProgramId = vacanyWithDR.ProgramId;
                vacancy.Available = vacanyWithDR.Available == 0 ? 1 : vacanyWithDR.Available;
                vacancy.Notes = vacanyWithDR.Notes;
                vacancy.RoleVID = vacanyWithDR.RoleVID;
                vacancy.Author = User.Identity.GetUserId();
                vacancy.CreatedOn = DateTime.Now;
                vacancy.ModifiedOn = DateTime.Now;
                vacancy.ExpiredOn = vacanyWithDR.ExpiredOn;
                vacancy.LanguageId = vacanyWithDR.LanguageId;
                vacancy.IsTranslated = vacanyWithDR.IsTranslated;
                vacancy.TranslationId = vacanyWithDR.TranslationId;
                vacancy.StatusId = vacanyWithDR.StatusId;
                int vacancyCounter = db.Vacancies.Where(v => v.TenantId.Trim().Equals(Tenant.TenantId) && v.DeptId == vacancy.DeptId).Count();
                vacancyCounter++;
                string deptCode = db.RMSDepartments.Find(vacancy.DeptId).Code.Trim();
                string vacancyLanguage = db.RMSLanguages.Find(vacancy.LanguageId).CultureName.Substring(0, 2).ToUpper().Trim();
                string programCode = db.RMSPrograms.Find(vacancy.ProgramId).Code.Trim();
                string timeStamp = DateTime.UtcNow.ToString("ddMMyyyy", CultureInfo.InvariantCulture).Trim();
                vacancy.Code = (vacancyCounter + "-" + vacancyLanguage + "-" + deptCode + "-" + programCode + "-" + timeStamp).ToUpper();
                vacancy.TenantId = Tenant.TenantId;
                db.Vacancies.Add(vacancy);
                db.SaveChanges();
                if (vacancy.TranslationId == null)
                    vacancy.TranslationId = vacancy.Id;
                db.Entry(vacancy).State = EntityState.Modified;
                db.SaveChanges();
                foreach (var item in vacanyWithDR.Degrees)
                {
                    if (item.Selected)
                    {
                        AddDegreeToVacancy(vacancy.Id, item.DegreeId);
                    }
                }
                foreach (var item in vacanyWithDR.Ranks)
                {
                    if (item.Selected)
                    {
                        AddRankToFile(vacancy.Id, item.RankId);
                    }
                }
                StatusId = vacancyStatus.Id;
                return RedirectToAction("Index", new { statusId = StatusId });
            }
            ViewBag.RoleVID = new SelectList(_db.Roles, "Id", "Name", vacanyWithDR.RoleVID);
            ViewBag.JobTypeId = new SelectList(TermsHelper.JobTypes(), "JobTypeId", "Value", vacanyWithDR.JobTypeId);
            ViewBag.ProgramId = new SelectList(TermsHelper.Programs(), "ProgramId", "Value", vacanyWithDR.ProgramId);
            ViewBag.StatusId = new SelectList(TermsHelper.Statuses(), "StatusId", "Value", vacanyWithDR.StatusId);
            int[] assignedLanguages = db.Vacancies.Where(v => v.TranslationId == vacanyWithDR.TranslationId).Select(v => v.LanguageId).ToArray();
            ViewBag.LanguageId = new SelectList(db.RMSLanguages.Where(l => !assignedLanguages.Contains(l.Id) && l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name");
            ViewBag.DeptId = new SelectList(GetDepartmentsServerSide(Thread.CurrentThread.CurrentCulture.Name), "Id", "Name", vacanyWithDR.DeptId);
            return View(vacanyWithDR);
        }
        // GET: /Vacancies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            List<string> roles = GetUserRoles();
            Vacancy vacancy = new Vacancy();
            vacancy = db.Vacancies.Include("Language").Where(v => v.TenantId.Trim().Equals(Tenant.TenantId) && (roles.Any(r => v.RoleVID.Equals(r)) || v.RoleVID == null) && v.Id == id).FirstOrDefault();
            if (vacancy == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            var vacanyWithDR = new EditVacancyWithDRViewModel(vacancy);
            ViewBag.JobTypeId = new SelectList(TermsHelper.JobTypes(), "JobTypeId", "Value", vacanyWithDR.JobTypeId);
            ViewBag.ProgramId = new SelectList(TermsHelper.Programs(), "ProgramId", "Value", vacanyWithDR.ProgramId);
            ViewBag.StatusId = new SelectList(TermsHelper.Statuses(), "StatusId", "Value", vacanyWithDR.StatusId);
            ViewBag.LanguageId = vacancy.Language.Name;
            ViewBag.DeptId = new SelectList(GetDepartmentsServerSide(Thread.CurrentThread.CurrentCulture.Name), "Id", "Name", vacanyWithDR.DeptId);
            ViewBag.RoleVID = new SelectList(_db.Roles, "Id", "Name", vacanyWithDR.RoleVID);
            ViewBag.Author = _db.Users.Find(vacanyWithDR.Author).UserName;
            ViewBag.ModifiedBy = string.IsNullOrEmpty(vacanyWithDR.ModifiedBy) ? Resources.Resources.NotAvailable : ViewBag.ModifiedBy = _db.Users.Find(vacanyWithDR.ModifiedBy).UserName;
            return View(vacanyWithDR);
        }
        // POST: /Vacancies/Edit/5 To protect from overposting attacks, please enable the specific
        // properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken, ValidateInput(false)]
        public ActionResult Edit(EditVacancyWithDRViewModel vacanyWithDR, string status)
        {
            if (ModelState.IsValid)
            {
                var vacancyStatus = db.Statuses.Find(vacanyWithDR.StatusId);
                if (vacancyStatus.Code.Trim().Equals("published") && vacanyWithDR.PublishedOn == null)
                    vacanyWithDR.PublishedOn = DateTime.Now;
                else if (vacancyStatus.Code.Trim().Equals("archived"))
                    vacanyWithDR.PublishedOn = null;
                var isVacancyPublished = (db.Vacancies.Find(vacanyWithDR.Id).Status.Code.ToLower().Equals("published")) ? true : false;
                var vacancy = new Vacancy();
                vacancy.Id = vacanyWithDR.Id;
                vacancy.TenantId = Tenant.TenantId;
                vacancy.Code = vacanyWithDR.Code;
                vacancy.Title = vacanyWithDR.Title;
                vacancy.Description = vacanyWithDR.Description;
                vacancy.Requirements = vacanyWithDR.Requirements;
                vacancy.Skills = vacanyWithDR.Skills;
                vacancy.Documents = vacanyWithDR.Documents;
                vacancy.DeptId = vacanyWithDR.DeptId;
                vacancy.JobTypeId = vacanyWithDR.JobTypeId;
                vacancy.ProgramId = vacanyWithDR.ProgramId;
                vacancy.Available = vacanyWithDR.Available == 0 ? 1 : vacanyWithDR.Available;
                vacancy.Notes = vacanyWithDR.Notes;
                vacancy.RoleVID = vacanyWithDR.RoleVID;
                vacancy.Author = User.Identity.GetUserId();
                vacancy.ModifiedBy = User.Identity.GetUserId();
                vacancy.CreatedOn = vacanyWithDR.CreatedOn;
                vacancy.ModifiedOn = DateTime.Now;
                vacancy.PublishedOn = vacanyWithDR.PublishedOn;
                vacancy.ExpiredOn = vacanyWithDR.ExpiredOn;
                vacancy.LanguageId = vacanyWithDR.LanguageId;
                vacancy.IsTranslated = vacanyWithDR.IsTranslated;
                vacancy.TranslationId = vacanyWithDR.TranslationId;
                vacancy.StatusId = vacanyWithDR.StatusId;
                string vacancyCounter = vacancy.Code.Substring(0, vacancy.Code.IndexOf("-"));
                string vacancyLanguage = db.RMSLanguages.Find(vacancy.LanguageId).CultureName.Substring(0, 2).ToUpper().Trim();
                string deptCode = db.RMSDepartments.Find(vacancy.DeptId).Code.Trim();
                string programCode = db.RMSPrograms.Find(vacancy.ProgramId).Code.Trim();
                string timeStamp = DateTime.UtcNow.ToString("ddMMyyyy", CultureInfo.InvariantCulture).Trim();
                vacancy.Code = (vacancyCounter + "-" + vacancyLanguage + "-" + deptCode + "-" + programCode + "-" + timeStamp).ToUpper();
                vacancy.TenantId = Tenant.TenantId;
                using (var db = new RMSEntities())
                {
                    db.Entry(vacancy).State = EntityState.Modified;
                    try
                    {
                        db.SaveChanges();
                    }
                    catch (DbEntityValidationException e)
                    {
                        foreach (var eve in e.EntityValidationErrors)
                        {
                            Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                                eve.Entry.Entity.GetType().Name, eve.Entry.State);
                            foreach (var ve in eve.ValidationErrors)
                            {
                                Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                    ve.PropertyName, ve.ErrorMessage);
                            }
                        }
                        throw;
                    }
                }
                ClearVacancyDegrees(vacancy.Id);
                foreach (var degree in vacanyWithDR.Degrees)
                {
                    if (degree.Selected)
                    {
                        AddDegreeToVacancy(vacancy.Id, degree.DegreeId);
                    }
                }
                ClearVacancyRanks(vacancy.Id);
                foreach (var rank in vacanyWithDR.Ranks)
                {
                    if (rank.Selected)
                    {
                        AddRankToFile(vacancy.Id, rank.RankId);
                    }
                }
                StatusId = vacancyStatus.Id;
                return RedirectToAction("Index", new { statusId = StatusId });
            }
            ViewBag.JobTypeId = new SelectList(TermsHelper.JobTypes(), "JobTypeId", "Value", vacanyWithDR.JobTypeId);
            ViewBag.ProgramId = new SelectList(TermsHelper.Programs(), "ProgramId", "Value", vacanyWithDR.ProgramId);
            ViewBag.StatusId = new SelectList(TermsHelper.Statuses(), "StatusId", "Value", vacanyWithDR.StatusId);
            ViewBag.LanguageId = new SelectList(db.RMSLanguages.Where(l => l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name", vacanyWithDR.LanguageId);

            ViewBag.DeptId = new SelectList(GetDepartmentsServerSide(Thread.CurrentThread.CurrentCulture.Name), "Id", "Name", vacanyWithDR.DeptId);
            ViewBag.RoleVID = new SelectList(_db.Roles, "Name", "Name", vacanyWithDR.RoleVID);
            ViewBag.Author = _db.Users.Find(vacanyWithDR.Author).UserName;
            ViewBag.ModifiedBy = string.IsNullOrEmpty(vacanyWithDR.ModifiedBy) ? Resources.Resources.NotAvailable : ViewBag.ModifiedBy = _db.Users.Find(vacanyWithDR.ModifiedBy).UserName;
            return View(vacanyWithDR);
        }
        // GET: /Vacancies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            List<string> roles = GetUserRoles();
            Vacancy vacancy = db.Vacancies.Include("Language").Include("Program").Include("Program.ProgramTerms").Include("Program.ProgramTerms.Language").Include("Status").Include("Status.StatusTerms").Include("Status.StatusTerms.Language").Include("JobType").Include("JobType.JobTypeTerms").Include("JobType.JobTypeTerms.Language").Include("VacancyRanks").Include("VacancyDegrees").Where(v => v.TenantId.Trim().Equals(Tenant.TenantId) && (roles.Any(r => v.RoleVID.Equals(r)) || v.RoleVID == null) && v.Id == id).FirstOrDefault();
            if (vacancy == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            ViewBag.Author = _db.Users.Find(vacancy.Author).UserName;
            ViewBag.ModifiedBy = string.IsNullOrEmpty(vacancy.ModifiedBy) ? Resources.Resources.NotAvailable : ViewBag.ModifiedBy = _db.Users.Find(vacancy.ModifiedBy).UserName;
            return View(vacancy);
        }
        // POST: /Vacancies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            using (var db = new RMSEntities())
            {
                using (var dbContextTransaction = db.Database.BeginTransaction())
                {
                    Vacancy vacancy = db.Vacancies.Include("Language").Include("Program").Include("Program.ProgramTerms").Include("Program.ProgramTerms.Language").Include("Status").Include("Status.StatusTerms").Include("Status.StatusTerms.Language").Include("JobType").Include("JobType.JobTypeTerms").Include("JobType.JobTypeTerms.Language").Include("VacancyRanks").Include("VacancyDegrees").Where(v => v.TenantId.Trim().Equals(Tenant.TenantId) && v.Id == id).FirstOrDefault();
                    try
                    {
                        if (vacancy.Submissions.Count > 0)
                        {
                            ModelState.AddModelError("ERROR", Resources.Resources.VacancyUnableToDelete);
                            return View(vacancy);
                        }
                        foreach (var item in vacancy.VacancyRanks)
                        {
                            db.Entry(item).State = EntityState.Deleted;
                            db.VacancyRanks.Remove(item);
                        }
                        foreach (var item in vacancy.VacancyDegrees)
                        {
                            db.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                            db.VacancyDegrees.Remove(item);
                        }
                        db.Entry(vacancy).State = EntityState.Deleted;
                        db.Vacancies.Remove(vacancy);
                        db.SaveChanges();
                        Vacancy translatedContent = db.Vacancies.Where(c => c.TranslationId == vacancy.TranslationId).FirstOrDefault();
                        if (translatedContent != null)
                        {
                            db.Entry(translatedContent).State = System.Data.Entity.EntityState.Modified;
                            translatedContent.IsTranslated = false;
                            translatedContent.TranslationId = null;
                            db.SaveChanges();
                        }
                        dbContextTransaction.Commit();
                    }
                    catch
                    {
                        dbContextTransaction.Rollback();
                    }
                }
            }
            ReGenerateCodes();
            return RedirectToAction("Index");
        }
        public void AddDegreeToVacancy(int vacancyId, int degreeId)
        {
            Vacancy vacancy = db.Vacancies.Find(vacancyId);
            RMSDegree degree = db.RMSDegrees.First(r => r.Id == degreeId);
            var newVacancyDegree = new VacancyDegree
            {
                VacancyId = vacancy.Id,
                Vacancy = vacancy,
                DegreeId = degree.Id,
                Degree = degree
            };
            // make sure the VacancyDegrees is not already present
            if (!vacancy.VacancyDegrees.Contains(newVacancyDegree))
            {
                vacancy.VacancyDegrees.Add(newVacancyDegree);
                db.SaveChanges();
            }
        }
        public void AddRankToFile(int vacancyId, int rankId)
        {
            Vacancy vacancy = db.Vacancies.Find(vacancyId);
            RMSRank Rank = db.RMSRanks.First(r => r.Id == rankId);
            var newVacancyRank = new VacancyRank
            {
                VacancyId = vacancy.Id,
                Vacancy = vacancy,
                RankId = Rank.Id,
                Rank = Rank
            };
            // make sure the VacancyRanks is not already present
            if (!vacancy.VacancyRanks.Contains(newVacancyRank))
            {
                vacancy.VacancyRanks.Add(newVacancyRank);
                db.SaveChanges();
            }
        }
        public void ClearVacancyDegrees(int vacancyId)
        {
            IEnumerable<VacancyDegree> vacancyDegrees = db.VacancyDegrees.Where(vd => vd.VacancyId.Equals(vacancyId));
            foreach (var item in vacancyDegrees)
            {
                db.VacancyDegrees.Remove(item);
            }
            db.SaveChanges();
        }
        public void ClearVacancyRanks(int vacancyId)
        {
            IEnumerable<VacancyRank> vacancyRanks = db.VacancyRanks.Where(vr => vr.VacancyId == vacancyId);
            foreach (var item in vacancyRanks)
            {
                db.VacancyRanks.Remove(item);
            }
            db.SaveChanges();
        }
        public void ReGenerateCodes()
        {
            var departments = (from v in db.Vacancies join d in db.RMSDepartments on v.DeptId equals d.Id select d).Distinct();
            foreach (var dept in departments)
            {
                int vacancyCounter = 0;
                var vacanciesInDept = db.Vacancies.Where(v => v.TenantId.Trim().Equals(Tenant.TenantId) && v.DeptId == dept.Id).OrderBy(v => v.CreatedOn);
                foreach (var vacancy in vacanciesInDept)
                {
                    vacancyCounter++;
                    string deptCode = db.RMSDepartments.Find(vacancy.DeptId).Code;
                    string vacancyLanguage = db.RMSLanguages.Find(vacancy.LanguageId).CultureName.Substring(0, 2).ToUpper().Trim();
                    string programCode = db.RMSPrograms.Find(vacancy.ProgramId).Code.Trim();
                    string timeStamp = DateTime.UtcNow.ToString("ddMMyyyy", CultureInfo.InvariantCulture).Trim();
                    vacancy.Code = (vacancyCounter + "-" + vacancyLanguage + "-" + deptCode + "-" + programCode + "-" + timeStamp).ToUpper();
                    db.Entry(vacancy).State = EntityState.Modified;
                }
            }
            db.SaveChanges();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        private string GetParents(IdentityDepartment element)
        {
            if (element.ParentId == null)
            {
                DepartmentPath = element.DepartmentTerms.Where(d => d.Language.CultureName.Trim().Equals(Thread.CurrentThread.CurrentCulture.Name) && d.DepartmentId == element.Id).FirstOrDefault().Value + "/" + DepartmentPath;
                return DepartmentPath;
            }
            IdentityDepartment department = element;
            DepartmentPath = IdentityDb.IdentityDepartmentTerms.Where(d => d.Language.CultureName.Trim().Equals(Thread.CurrentThread.CurrentCulture.Name) && d.DepartmentId == department.Id).FirstOrDefault().Value + "/" + DepartmentPath;
            GetParents(IdentityDb.IdentityDepartments.Find(department.ParentId));
            return DepartmentPath;
        }
        private List<object> GetDepartmentsServerSide(string culture)
        {
            foreach (var item in TermsHelper.Departments())
            {
                DepartmentsList.Add(new
                {
                    Id = item.Id,
                    Name = GetParents(item)
                });
                DepartmentPath = "";
            }
            return DepartmentsList;
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
    }
}