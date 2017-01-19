using cutecms_porto.Areas.Identity.Models.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cutecms_porto.Models
{
    public class StaffViewModel
    {
        #region Properties
        public Employee Employee { get; set; }
        public List<EmpInDept> EmpInDepts { get; set; }
        #endregion Properties
    }
}