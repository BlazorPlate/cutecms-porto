using cutecms_porto.Helpers;
using System.Web.Mvc;

namespace cutecms_porto
{
    public class FilterConfig
    {
        #region Methods
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
        public static void RegisterGlobalCustomFilters(GlobalFilterCollection filters)
        {
            filters.Add(new LocalizedAuthorizeAttribute()); 
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        }
        #endregion Methods
    }
}