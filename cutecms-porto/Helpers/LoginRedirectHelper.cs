using System;
using System.Collections.Generic;
using System.Linq;

namespace cutecms_porto.Helpers
{
    public interface IReturnUrlHandler
    {
        #region Methods
        void Register(string returnUrlPrefix, string loginRoute);

        string GetRoute(string returnUrl);
        #endregion Methods
    }

    public class ReturnUrlHandler : IReturnUrlHandler
    {
        #region Fields
        private const string DefaultRoute = "Home";
        private readonly Dictionary<string, string> redirectRules = new Dictionary<string, string>();
        #endregion Fields

        #region Methods
        public void Register(string returnUrlPrefix, string loginRoute)
        {
            redirectRules.Add(returnUrlPrefix, loginRoute);
        }

        public string GetRoute(string returnUrl)
        {
            var key = redirectRules.Keys.FirstOrDefault(x =>
                returnUrl.StartsWith(x, StringComparison.OrdinalIgnoreCase));
            return !string.IsNullOrEmpty(key) ? redirectRules[key] : DefaultRoute;
        }
        #endregion Methods
    }
}