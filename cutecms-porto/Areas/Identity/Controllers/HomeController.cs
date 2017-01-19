using cutecms_porto.Helpers;
using System.Web.Mvc;

namespace cutecms_porto.Areas.Identity.Controllers
{
    public class HomeController : BaseController
    {
        #region Methods
        // GET: Identity/Home
        public ActionResult Index()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        #endregion Methods
    }
}