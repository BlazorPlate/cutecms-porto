using cutecms_porto.Helpers;
using System.Web.Mvc;
using System.Web.Routing;

namespace cutecms_porto
{
    public class RouteConfig
    {
        #region Methods
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.LowercaseUrls = true;
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{file}.js");
            routes.IgnoreRoute("{file}.css");
            routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.ico(/.*)?" });

            routes.MapRoute(name: "Content", url: "{culture}/content/pages/{*slug}",
            defaults: new { culture = CultureHelper.GetDefaultCulture(), controller = "Pages", action = "Content", id = UrlParameter.Optional, tenant = UrlParameter.Optional },            
            namespaces: new[] { "cutecms_porto.Controllers" });

            routes.MapRoute(name: "Default", url: "{culture}/{controller}/{action}/{id}",
            defaults: new { culture = CultureHelper.GetDefaultCulture(), controller = "Home", action = "Index", id = UrlParameter.Optional, tenant = UrlParameter.Optional },
            namespaces: new[] { "cutecms_porto.Controllers" });

            routes.MapRoute(name: "MyProfile", url: "{culture}/MyProfile",
            defaults: new { culture = CultureHelper.GetDefaultCulture(), controller = "MyProfile", action = "Index", id = UrlParameter.Optional, tenant = UrlParameter.Optional },          
            namespaces: new[] { "cutecms_porto.Controllers" });

            // This will handle any non-existing urls
            routes.MapRoute(name: "404-PageNotFound", url: "{*url}",
            defaults: new { culture = CultureHelper.GetDefaultCulture(), controller = "Error", action = "CatchAll" },
            
            namespaces: new[] { "cutecms_porto.Controllers" });
        }

        #endregion Methods
    }
}
