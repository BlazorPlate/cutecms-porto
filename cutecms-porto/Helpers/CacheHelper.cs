using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;

namespace cutecms_porto.Helpers
{
    public static class CacheHelper
    {
        #region Methods
        public static void ClearCache()
        {
            var enumerator = HttpRuntime.Cache.GetEnumerator();
            Dictionary<string, object> cacheItems = new Dictionary<string, object>();
            while (enumerator.MoveNext())
                cacheItems.Add(enumerator.Key.ToString(), enumerator.Value);
            foreach (string key in cacheItems.Keys)
                HttpRuntime.Cache.Remove(key);
            OutputCacheAttribute.ChildActionCache = new MemoryCache("NewDefault");
        }
        #endregion Methods
    }
}