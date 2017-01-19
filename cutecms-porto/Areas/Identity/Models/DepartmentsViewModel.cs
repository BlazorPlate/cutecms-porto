using cutecms_porto.Areas.Identity.Models.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cutecms_porto.Areas.Identity.Models
{
    public class DepartmentsViewModel
    {
        public List<IdentityDepartment> Departments { get; set; }
        public List<IdentityDepartmentTerm> DepartmentWithTerms { get; set; }
    }
}