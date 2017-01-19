using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cutecms_porto.Areas.RMS.Models
{
    public class NotificationViewModel
    {
        public string Body { get; set; }
        public bool EnableSsl { get; set; }
        public int Port { get; set; }
        public string RecepientEmail { get; set; }
        public string SenderEmail { get; set; }
        public string SenderPasswordHash { get; set; }
        public string SMTP { get; set; }
        public string Subject { get; set; }
        public int ApplicationNumber { get; set; }
        public string FullName { get; set; }

    }
}