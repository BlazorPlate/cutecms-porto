using cutecms_porto.Areas.Config.Models.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cutecms_porto.Models
{
    public class OrganizationViewModel
    {
        public Organization Organization { get; set; }
        public string SenderName { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}