using cutecms_porto.Areas.CMS.Models.DBModel;
using Microsoft.Owin;
using Owin;
using System;
using System.Data.Entity;
using System.Linq;

[assembly: OwinStartupAttribute(typeof(cutecms_porto.Startup))]
namespace cutecms_porto
{
    public partial class Startup
    {
        #region Methods
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
        #endregion Methods
    }
}