using cutecms_porto.Helpers;
using System.Web.Mvc;

namespace cutecms_porto.Areas.CMS
{
    public class CMSAreaRegistration : AreaRegistration
    {
        #region Properties
        public override string AreaName
        {
            get
            {
                return "CMS";
            }
        }
        #endregion Properties

        #region Methods
        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "CMS_default",
                "{culture}/CMS/{controller}/{action}/{id}",
                 new { culture = CultureHelper.GetDefaultCulture(), action = "Index", id = UrlParameter.Optional },
                       constraints: new { TenantAccess = new TenantRouteConstraint() },
                       namespaces: new[] { "cutecms_porto.Areas.CMS.Controllers" }
            );
        }
        #endregion Methods
    }
}