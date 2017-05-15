using cutecms_porto.Areas.Config.Models.DBModel;
using System.Threading;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace cutecms_porto.Helpers
{
    public class Tenant
    {
        public static string TenantId { get; set; }
        public static string GetCurrentTenantId()
        {
            var fullAddress = HttpContext.Current.Request.Headers["Host"].Split('.');
            if (fullAddress.Length < 2)
                throw new HttpException(400, "Bad Request");
            TenantId = fullAddress[0];
            //TenantId = "services";
            return TenantId;
        }
    }

    public static class OrganizationData
    {
        public static Organization Organization { get; set; }
    }
}