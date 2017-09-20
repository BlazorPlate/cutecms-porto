using Microsoft.Owin;
using Owin;

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