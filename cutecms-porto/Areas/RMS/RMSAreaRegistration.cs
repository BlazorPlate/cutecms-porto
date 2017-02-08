using cutecms_porto.Helpers;
using System.Web.Mvc;

namespace cutecms_porto.Areas.RMS
{
    public class RMSAreaRegistration : AreaRegistration
    {
        #region Properties
        public override string AreaName
        {
            get
            {
                return "RMS";
            }
        }
        #endregion Properties

        #region Methods
        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "RMS_default",
                "{culture}/RMS/{controller}/{action}/{id}",
                 new { culture = CultureHelper.GetDefaultCulture(), action = "Index", id = UrlParameter.Optional },                       
                       namespaces: new[] { "cutecms_porto.Areas.RMS.Controllers" }
            );
        }
        #endregion Methods
    }
}