using cutecms_porto.Areas.Config.Models.DBModel;
using System.Threading;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace cutecms_porto.Helpers
{
    public static class Tenant
    {
        public static string TenantId { get; set; }
    }

    public static class OrganizationData
    {
        public static Organization Organization { get; set; }
    }
}