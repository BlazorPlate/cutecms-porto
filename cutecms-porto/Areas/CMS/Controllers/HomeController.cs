using cutecms_porto.Helpers;
using System.Web.Mvc;

namespace cutecms_porto.Areas.CMS.Controllers
{
    public class HomeController : BaseController
    {
        #region Methods
        public ActionResult Index(string email)
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        #endregion Methods
    }
}