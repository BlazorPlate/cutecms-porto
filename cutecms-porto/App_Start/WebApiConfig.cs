using System.Web.Http;

namespace cutecms_porto
{
    public static class WebApiConfig
    {
        #region Methods
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
        #endregion Methods
    }
}