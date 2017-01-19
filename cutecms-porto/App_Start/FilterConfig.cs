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
        #endregion Methods
    }
}