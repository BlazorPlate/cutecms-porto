using cutecms_porto.Areas.CMS.Models.DBModel;
using cutecms_porto.Helpers;
using System;
using System.Web.Mvc;

namespace cutecms_porto.Areas.CMS.Controllers
{
    public class HomeController : BaseController
    {
        #region Methods
        public ActionResult Index(string email)
        {
            CMSEntities db = new CMSEntities();
            {
                var currentDateTime = DateTime.Now;
                db.Database.ExecuteSqlCommand("UPDATE Contents SET StatusId = 2 WHERE ExpiredOn <= {0}", currentDateTime);
                db.Database.ExecuteSqlCommand("UPDATE Contents SET StatusId = 1 WHERE PublishedOn <= {0} AND ExpiredOn >= {0}", currentDateTime);
                db.Database.ExecuteSqlCommand("UPDATE MenuItems SET MenuItems.StatusId = Contents.StatusId FROM MenuItems INNER JOIN Contents ON MenuItems.ContentId = Contents.Id;");
                CacheHelper.ClearCache();
            }
            return View();
        }
        #endregion Methods
    }
}