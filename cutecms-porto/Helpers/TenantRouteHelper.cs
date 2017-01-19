using cutecms_porto.Areas.Config.Models.DBModel;
using System.Threading;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace cutecms_porto.Helpers
{

    public class TenantRouteConstraint : IRouteConstraint
    {
        private ConfigEntities configDb = new ConfigEntities();
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (!values.ContainsKey("tenant"))
            {
                //var fullAddress = httpContext.Request.Headers["Host"].Split('.');
                //if (fullAddress.Length < 2)
                //    return false;
                //var tenantSubdomain = fullAddress[0];
                //var tenantSubdomain = "studentaffairs";
                var tenantSubdomain = "demo";
                //var tenantSubdomain = "admission";
                //var tenantSubdomain = "time";
                values.Add("tenant", tenantSubdomain);
                Tenant.TenantId = tenantSubdomain;
            }
            return true;
        }
    }
    public static class Tenant
    {
        public static string TenantId { get; set; }
    }

    public static class OrganizationData
    {
        public static Organization Organization { get; set; }
    }
}