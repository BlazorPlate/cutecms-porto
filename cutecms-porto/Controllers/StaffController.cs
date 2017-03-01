using cutecms_porto.Areas.Identity.Models.DBModel;
using cutecms_porto.Helpers;
using PagedList;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace cutecms_porto.Controllers
{
    public class StaffController : BaseController
    {
        #region Fields
        private IdentityEntities db = new IdentityEntities();
        #endregion Fields

        #region Methods
        // GET: Identity/Employees
        public ActionResult Index()
        {
            ViewBag.EmpTypeId = new SelectList(Helpers.TermsHelper.EmployeeTypes(), "EmployeeTypeId", "Value");
            var departments = db.IdentityDepartments.Include(d => d.Department1).Include(d => d.Employee);
            return View(departments);
        }
        [HttpGet]
        public ActionResult Search()
        {
            return View();
        }

        // POST: Identity/Employees
        [HttpPost]
        public ActionResult Search(int? page, string EmpName, int? EmpTypeId)
        {
            var pageNumber = page ?? 1;
            var query = (from employees in db.Employees
                         join empInDept in db.EmpInDepts
                         on employees.TranslationId equals empInDept.EmpId
                         where employees.Language.CultureName.Trim().Equals(Thread.CurrentThread.CurrentCulture.Name) &&
                         (employees.FirstName.ToLower().Trim().Contains(EmpName.ToLower().Trim()) || employees.LastName.ToLower().Trim().Contains(EmpName.ToLower().Trim()) || string.IsNullOrEmpty(EmpName.Trim()) &&
                         (empInDept.EmployeeTypeId == EmpTypeId || EmpTypeId == null))
                         select employees).Distinct();
            query.Include(q => q.PersonalTitle).Include(q => q.EmpInDepts).Include(q => q.PersonalTitle.PersonalTitleTerms).Include(q => q.PersonalTitle.PersonalTitleTerms.Select(p => p.Language)).Include(q => q.Departments).Include(q => q.Language).Include(q => q.EmpInDepts.Select(o => o.Occupation)).OrderBy(e => e.FirstName);
            ViewBag.EmpName = EmpName;
            ViewBag.EmpTypeId = EmpTypeId;
            return View(query.OrderBy(e => e.FirstName).ToPagedList(pageNumber, 8));
        }

        // GET: Identity/Employees/Details/5
        public ActionResult MemberProfile(int? id)
        {
            if (id == null)
                throw new HttpException(404, "Page Not Found");
            Employee employee = db.Employees.Where(e => e.TranslationId == id && e.Language.CultureName.Trim().Equals(Thread.CurrentThread.CurrentCulture.Name)).FirstOrDefault();
            if (employee == null)
                throw new HttpException(404, "Page Not Found");
            ViewBag.Employee = employee;
            return View(employee);
        }

        // GET: Identity/Employees/Details/5
        public ActionResult Publications(int? empId)
        {
            var publication = db.Publications.Where(p => p.EmpId == empId).OrderBy(p => p.Ordinal);
            if (publication == null)
                throw new HttpException(404, "Page Not Found");
            return View(publication);
        }

        public ActionResult EmpInDepts(int? id)
        {
            var empInDepts = db.EmpInDepts.Where(p => p.EmpId == id);
            if (empInDepts == null)
                throw new HttpException(404, "Page Not Found");
            return View(empInDepts);
        }

        public ActionResult EmpsInDept(int? id, int? page)
        {
            if (id == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            var department = db.IdentityDepartments.Find(id);
            if (department == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            var pageNumber = page ?? 1;
            var departments = TreeHelper.Traversal(department, x => x.Departments1.Where(d => d.EmpInDepts.Count() > 0)).ToPagedList(pageNumber, 5);
            return View(departments);
        }

        public ActionResult Download(string FilePath, string FileName)
        {
            return File(FilePath, FileName);
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