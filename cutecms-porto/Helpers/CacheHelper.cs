using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;

namespace cutecms_porto.Helpers
{
    public static class CacheHelper
    {
        #region Methods
        public static void ClearCache(string absolutePath)
        {
            var enumerator = HttpRuntime.Cache.GetEnumerator();
            Dictionary<string, object> cacheItems = new Dictionary<string, object>();
            while (enumerator.MoveNext())
                cacheItems.Add(enumerator.Key.ToString(), enumerator.Value);
            foreach (string key in cacheItems.Keys)
                HttpRuntime.Cache.Remove(key);
            var requestContext = HttpContext.Current.Request.RequestContext;
            //Clear Output Cache
            if (!string.IsNullOrEmpty(absolutePath))
                HttpResponse.RemoveOutputCacheItem(absolutePath);
            var homeIndex = new UrlHelper(requestContext).Action("Home", "Index");
            var homeContents = new UrlHelper(requestContext).Action("Home", "Contents");
            var homeContact = new UrlHelper(requestContext).Action("Home", "Contact");
            var homeCalendar = new UrlHelper(requestContext).Action("Home", "Calendar");
            var homeGalleries = new UrlHelper(requestContext).Action("Home", "Galleries");
            HttpResponse.RemoveOutputCacheItem(homeIndex);
            HttpResponse.RemoveOutputCacheItem(homeContents);
            HttpResponse.RemoveOutputCacheItem(homeContact);
            HttpResponse.RemoveOutputCacheItem(homeCalendar);
            HttpResponse.RemoveOutputCacheItem(homeGalleries);
            HttpResponse.RemoveOutputCacheItem(homeCalendar);
        }
        #endregion Methods
    }
}