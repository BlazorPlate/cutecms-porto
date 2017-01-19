using System.Web.Optimization;

namespace cutecms_porto
{
    public class BundleConfig
    {
        #region Methods
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/assets/plugins/jquery/jquery-2.1.4.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/assets/porto/vendor/validation/jquery.validate.js",
                        "~/assets/porto/vendor/validation/jquery.validate.unobtrusive.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/assets/plugins/bootstrap/js/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/root-js")
                .Include("~/assets/plugins/newsbox/jquery.bootstrap.newsbox.js")
                .Include("~/assets/plugins/slider.revolution/js/jquery.themepunch.tools.min.js")
                .Include("~/assets/plugins/slider.revolution/js/jquery.themepunch.revolution.min.js")
                .Include("~/assets/js/view/demo.revolution_slider.js")
                .Include("~/assets/plugins/bootstrap.daterangepicker/moment.min.js")
                .Include("~/assets/plugins/fullcalendar/fullcalendar.min.js")
                .Include("~/assets/plugins/fullcalendar/locale-all.js")
                .Include("~/assets/plugins/toastr/toastr.js"));

            bundles.Add(new StyleBundle("~/bundles/admin-css")
                .Include("~/assets/admin/assets/stylesheets/bootstrap.min.css", new CssRewriteUrlTransform())
                .Include("~/assets/admin/assets/stylesheets/pixel-admin.min.css", new CssRewriteUrlTransform())
                .Include("~/assets/admin/assets/stylesheets/widgets.min.css", new CssRewriteUrlTransform())
                .Include("~/assets/admin/assets/stylesheets/themes.min.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/admin-css-rtl")
                .Include("~/assets/admin/assets/stylesheets/bootstrap-rtl.min.css", new CssRewriteUrlTransform())
                .Include("~/assets/admin/assets/stylesheets/pixel-admin.min.css", new CssRewriteUrlTransform())
                .Include("~/assets/admin/assets/stylesheets/widgets.min.css", new CssRewriteUrlTransform())
                .Include("~/assets/admin/assets/stylesheets/rtl.min.css", new CssRewriteUrlTransform())
                .Include("~/assets/css/droidarabickufi.css", new CssRewriteUrlTransform())
                .Include("~/assets/admin/assets/stylesheets/themes.min.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/root-css")
                .Include("~/assets/css/essentials.css", new CssRewriteUrlTransform())
                .Include("~/assets/css/layout.css", new CssRewriteUrlTransform())
                .Include("~/assets/plugins/bootstrap/css/bootstrap.min.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/root-css-rtl")
                .Include("~/assets/css/essentials.css", new CssRewriteUrlTransform())
                .Include("~/assets/css/layout.css", new CssRewriteUrlTransform())
                .Include("~/assets/plugins/bootstrap/css/bootstrap.min.css", new CssRewriteUrlTransform())
                .Include("~/assets/css/droidarabickufi.css", new CssRewriteUrlTransform())
                .Include("~/assets/plugins/bootstrap/RTL/bootstrap-rtl.min.css", new CssRewriteUrlTransform())
                .Include("~/assets/plugins/bootstrap/RTL/bootstrap-flipped.min.css", new CssRewriteUrlTransform())
                .Include("~/assets/css/layout-RTL.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/root-css-layout")
                 .Include("~/assets/plugins/slider.revolution/css/extralayers.css", new CssRewriteUrlTransform())
                 .Include("~/assets/plugins/slider.revolution/css/settings.css", new CssRewriteUrlTransform())
                 .Include("~/assets/plugins/smarticker/css/jquery.smarticker.css", new CssRewriteUrlTransform())
                 .Include("~/assets/plugins/newsbox/newbox.css")
                 .Include("~/assets/css/header-1.css")
                 .Include("~/assets/css/color_scheme/darkblue.css")
                 .Include("~/assets/plugins/toastr/toastr.css")
                 .Include("~/assets/plugins/fullcalendar/fullcalendar.css"));

            BundleTable.EnableOptimizations = true;

        }
        #endregion Methods
    }
}