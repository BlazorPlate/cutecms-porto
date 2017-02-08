using cutecms_porto.Helpers;
using System.Web.Mvc;

namespace cutecms_porto.Areas.Config
{
    public class ConfigAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Config";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Config_default",
                "{culture}/Config/{controller}/{action}/{id}",
                 new { culture = CultureHelper.GetDefaultCulture(), action = "Index", id = UrlParameter.Optional },
                       namespaces: new[] { "cutecms_porto.Areas.Config.Controllers" });
        }
    }
}