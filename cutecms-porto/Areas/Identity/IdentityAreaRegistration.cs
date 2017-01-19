using cutecms_porto.Helpers;
using System.Web.Mvc;

namespace cutecms_porto.Areas.Identity
{
    public class IdentityAreaRegistration : AreaRegistration
    {
        #region Properties
        public override string AreaName
        {
            get
            {
                return "Identity";
            }
        }
        #endregion Properties

        #region Methods
        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Identity_default",
                "{culture}/Identity/{controller}/{action}/{id}",
                 new { culture = CultureHelper.GetDefaultCulture(), action = "Index", id = UrlParameter.Optional },
                       constraints: new { TenantAccess = new TenantRouteConstraint() },
                       namespaces: new[] { "cutecms_porto.Areas.Identity.Controllers" }
            );
        }
        #endregion Methods
    }
}