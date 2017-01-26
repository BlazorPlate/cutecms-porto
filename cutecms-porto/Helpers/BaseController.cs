using cutecms_porto.Areas.CMS.Models.DBModel;
using cutecms_porto.Areas.Config.Models.DBModel;
using System;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;

namespace cutecms_porto.Helpers
{
    public class BaseController : Controller
    {
        #region Fields
        public static object BreadcrumbLock = new object();
        public static object MenuBuilderLock = new object();
        private ConfigEntities configDb = new ConfigEntities();
        private CMSEntities cmsDb = new CMSEntities();
        #endregion Fields
        #region Methods

        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            string cultureName = RouteData.Values["culture"] as string;
            // Attempt to read the culture cookie from Request
            if (cultureName == null)
                cultureName = Request.UserLanguages != null && Request.UserLanguages.Length > 0 ? Request.UserLanguages[0] : null; // obtain it from HTTP header AcceptLanguages

            // Validate culture name
            cultureName = CultureHelper.GetImplementedCulture(cultureName); // This is safe

            if (RouteData.Values["culture"] as string != cultureName)
            {
                // Force a valid culture in the URL
                RouteData.Values["culture"] = cultureName.ToLowerInvariant(); // lower case too
                Response.RedirectToRoute("Default", RouteData.Values); // Redirect user
            }
            // Modify current thread's cultures
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cultureName);
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
            if (HttpRuntime.Cache["Organization"] == null)
                OrganizationData.Organization = configDb.Organizations.Where(o => o.TenantId.Trim().Equals(Tenant.TenantId) && o.IsDefault == true && o.Language.CultureName.Trim().Equals(Thread.CurrentThread.CurrentCulture.Name)).FirstOrDefault();
            return base.BeginExecuteCore(callback, state);
        }
        #endregion Methods
    }
}