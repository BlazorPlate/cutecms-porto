﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    
    #line 4 "..\..\Views\Home\Index.cshtml"
    using System.Threading;
    
    #line default
    #line hidden
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Optimization;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    using cutecms_porto;
    
    #line 1 "..\..\Views\Home\Index.cshtml"
    using cutecms_porto.Areas.CMS.Models.DBModel;
    
    #line default
    #line hidden
    
    #line 3 "..\..\Views\Home\Index.cshtml"
    using cutecms_porto.Areas.Config.Models.DBModel;
    
    #line default
    #line hidden
    
    #line 2 "..\..\Views\Home\Index.cshtml"
    using cutecms_porto.Areas.Identity.Models.DBModel;
    
    #line default
    #line hidden
    using cutecms_porto.Helpers;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Home/Index.cshtml")]
    public partial class _Views_Home_Index_cshtml : System.Web.Mvc.WebViewPage<cutecms_porto.Models.HomeViewModel>
    {
        public _Views_Home_Index_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 6 "..\..\Views\Home\Index.cshtml"
  
    ViewBag.Title = Resources.Resources.Home;
    CMSEntities cmsDb = new CMSEntities();
    CMSEntities configDb = new CMSEntities();
    IdentityEntities IdentityDb = new IdentityEntities();
    var openingHours = Model.ContentLists.Where(c => c.Code.Trim().Equals("opening-hour")).FirstOrDefault()?.ListItems ?? new List<ListItem>();
    var shortcutContents = Model.Contents.Where(c => c.HasShortcut);
    var partnerList = Model.ContentLists.Where(c => c.Code.Trim().Equals("partner"))?.FirstOrDefault() ?? new ContentList();
    var resourcesList = Model.ContentLists.Where(c => c.Code.Trim().Equals("resource"))?.FirstOrDefault() ?? new ContentList();
    var testimonialList = Model.ContentLists.Where(c => c.Code.Trim().Equals("testimonials"))?.FirstOrDefault() ?? new ContentList();
    IdentityEntities identityDb = new IdentityEntities();
    var organizations = (List<Organization>)HttpRuntime.Cache["Organizations"];
    var organization = organizations.Where(o => o.Language.CultureName.Trim().Equals(Thread.CurrentThread.CurrentCulture.Name))?.FirstOrDefault() ?? new Organization();
    IEnumerable<MenuItem> footerMenuItems = configDb.MenuItems.Include("Status").Include("Menu").Include("Language").Where(m => m.Menu.TenantId.Trim().Equals(Tenant.TenantId) && m.Menu.Code.Trim().Equals("footer-menu") && m.Status.Code.Trim().Equals("published") && m.Language.CultureName.Trim().Equals(Thread.CurrentThread.CurrentCulture.Name)).OrderBy(o => o.Ordinal);

            
            #line default
            #line hidden
WriteLiteral("\r\n");

DefineSection("Styles", () => {

WriteLiteral("\r\n    <!-- Current Page CSS -->\r\n    <link");

WriteLiteral(" rel=\"stylesheet\"");

WriteAttribute("href", Tuple.Create(" href=\"", 1783), Tuple.Create("\"", 1838)
, Tuple.Create(Tuple.Create("", 1790), Tuple.Create<System.Object, System.Int32>(Href("~/assets/porto/vendor/rs-plugin/css/settings.css")
, 1790), false)
);

WriteLiteral(">\r\n    <link");

WriteLiteral(" rel=\"stylesheet\"");

WriteAttribute("href", Tuple.Create(" href=\"", 1868), Tuple.Create("\"", 1921)
, Tuple.Create(Tuple.Create("", 1875), Tuple.Create<System.Object, System.Int32>(Href("~/assets/porto/vendor/rs-plugin/css/layers.css")
, 1875), false)
);

WriteLiteral(">\r\n    <link");

WriteLiteral(" rel=\"stylesheet\"");

WriteAttribute("href", Tuple.Create(" href=\"", 1951), Tuple.Create("\"", 2008)
, Tuple.Create(Tuple.Create("", 1958), Tuple.Create<System.Object, System.Int32>(Href("~/assets/porto/vendor/rs-plugin/css/navigation.css")
, 1958), false)
);

WriteLiteral(">\r\n");

});

WriteLiteral("<div");

WriteLiteral(" role=\"main\"");

WriteLiteral(" class=\"main\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"slider-container rev_slider_wrapper\"");

WriteLiteral(" style=\"height: 780px;\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" id=\"revolutionSlider\"");

WriteLiteral(" class=\"slider rev_slider\"");

WriteLiteral(" data-plugin-revolution-slider");

WriteLiteral(" data-plugin-options=\"{\'delay\': 5000, \'gridwidth\': 800, \'gridheight\': 650}\"");

WriteLiteral(">\r\n            <ul>\r\n");

            
            #line 31 "..\..\Views\Home\Index.cshtml"
                
            
            #line default
            #line hidden
            
            #line 31 "..\..\Views\Home\Index.cshtml"
                 foreach (var item in Model.HomeGallery)
                {

            
            #line default
            #line hidden
WriteLiteral("                    <li");

WriteLiteral(" data-transition=\"fade\"");

WriteLiteral(">\r\n                        <img");

WriteAttribute("src", Tuple.Create(" src=\"", 2465), Tuple.Create("\"", 2485)
            
            #line 34 "..\..\Views\Home\Index.cshtml"
, Tuple.Create(Tuple.Create("", 2471), Tuple.Create<System.Object, System.Int32>(item.FilePath
            
            #line default
            #line hidden
, 2471), false)
);

WriteAttribute("alt", Tuple.Create("\r\n                             alt=\"", 2486), Tuple.Create("\"", 2703)
            
            #line 35 "..\..\Views\Home\Index.cshtml"
, Tuple.Create(Tuple.Create("", 2522), Tuple.Create<System.Object, System.Int32>(item.ImageFileTerms.Where(it => it.Language.CultureName.Trim().Equals(Thread.CurrentThread.CurrentCulture.Name) && it.ImageFileId == item.Id).FirstOrDefault()?.Value ?? item.Code
            
            #line default
            #line hidden
, 2522), false)
);

WriteLiteral("\r\n                             data-bgposition=\"center center\"");

WriteLiteral("\r\n                             data-bgfit=\"cover\"");

WriteLiteral("\r\n                             data-bgrepeat=\"no-repeat\"");

WriteLiteral("\r\n                             class=\"rev-slidebg\"");

WriteLiteral(">\r\n");

            
            #line 40 "..\..\Views\Home\Index.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 40 "..\..\Views\Home\Index.cshtml"
                          
                            var primaryCaption = item.ImageFileTerms.Where(it => it.Language.CultureName.Trim().Equals(Thread.CurrentThread.CurrentCulture.Name) && it.ImageFileId == item.Id).FirstOrDefault()?.PrimaryCaption;

                            if (!string.IsNullOrEmpty(primaryCaption))
                            {

            
            #line default
            #line hidden
WriteLiteral("                                <div");

WriteLiteral(" class=\"tp-caption\"");

WriteLiteral("\r\n                                     data-x=\"center\"");

WriteLiteral(" data-hoffset=\"-450\"");

WriteLiteral("\r\n                                     data-y=\"center\"");

WriteLiteral(" data-voffset=\"-140\"");

WriteLiteral("\r\n                                     data-start=\"1000\"");

WriteLiteral("\r\n                                     style=\"z-index: 5\"");

WriteLiteral("\r\n                                     data-transform_in=\"x:[-300%];opacity:0;s:5" +
"00;\"");

WriteLiteral("><img");

WriteAttribute("src", Tuple.Create(" src=\"", 3689), Tuple.Create("\"", 3743)
, Tuple.Create(Tuple.Create("", 3695), Tuple.Create<System.Object, System.Int32>(Href("~/assets/porto/img/slides/slide-title-border.png")
, 3695), false)
);

WriteLiteral(" alt=\"\"");

WriteLiteral("></div>\r\n");

            
            #line 51 "..\..\Views\Home\Index.cshtml"


            
            #line default
            #line hidden
WriteLiteral("                                <div");

WriteLiteral(" class=\"tp-caption top-label\"");

WriteLiteral("\r\n                                     data-x=\"center\"");

WriteLiteral(" data-hoffset=\"20\"");

WriteLiteral("\r\n                                     data-y=\"center\"");

WriteLiteral(" data-voffset=\"-140\"");

WriteLiteral("\r\n                                     data-start=\"500\"");

WriteLiteral("\r\n                                     style=\"z-index: 5;\"");

WriteLiteral("\r\n                                     data-transform_in=\"y:[-300%];opacity:0;s:5" +
"00;\"");

WriteLiteral(">");

            
            #line 57 "..\..\Views\Home\Index.cshtml"
                                                                               Write(primaryCaption);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n");

            
            #line 58 "..\..\Views\Home\Index.cshtml"


            
            #line default
            #line hidden
WriteLiteral("                                    <div");

WriteLiteral(" class=\"tp-caption\"");

WriteLiteral("\r\n                                         data-x=\"center\"");

WriteLiteral(" data-hoffset=\"450\"");

WriteLiteral("\r\n                                         data-y=\"center\"");

WriteLiteral(" data-voffset=\"-140\"");

WriteLiteral("\r\n                                         data-start=\"1000\"");

WriteLiteral("\r\n                                         style=\"z-index: 5\"");

WriteLiteral("\r\n                                         data-transform_in=\"x:[300%];opacity:0;" +
"s:500;\"");

WriteLiteral("><img");

WriteAttribute("src", Tuple.Create(" src=\"", 4625), Tuple.Create("\"", 4679)
, Tuple.Create(Tuple.Create("", 4631), Tuple.Create<System.Object, System.Int32>(Href("~/assets/porto/img/slides/slide-title-border.png")
, 4631), false)
);

WriteLiteral(" alt=\"\"");

WriteLiteral("></div>\r\n");

            
            #line 65 "..\..\Views\Home\Index.cshtml"
                                }
                        
            
            #line default
            #line hidden
WriteLiteral("\r\n                        <div");

WriteLiteral(" class=\"tp-caption main-label\"");

WriteLiteral("\r\n                             data-x=\"center\"");

WriteLiteral(" data-hoffset=\"0\"");

WriteLiteral("\r\n                             data-y=\"center\"");

WriteLiteral(" data-voffset=\"-70\"");

WriteLiteral("\r\n                             data-start=\"1500\"");

WriteLiteral("\r\n                             data-whitespace=\"nowrap\"");

WriteLiteral("\r\n                             data-transform_in=\"y:[100%];s:500;\"");

WriteLiteral("\r\n                             data-transform_out=\"opacity:0;s:500;\"");

WriteLiteral("\r\n                             style=\"z-index: 5\"");

WriteLiteral("\r\n                             data-mask_in=\"x:0px;y:0px;\"");

WriteLiteral(">");

            
            #line 75 "..\..\Views\Home\Index.cshtml"
                                                     Write(item.ImageFileTerms.Where(it => it.Language.CultureName.Trim().Equals(Thread.CurrentThread.CurrentCulture.Name) && it.ImageFileId == item.Id).FirstOrDefault()?.SecondaryCaption);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n\r\n                            <div");

WriteLiteral(" class=\"tp-caption bottom-label\"");

WriteLiteral("\r\n                                 data-x=\"center\"");

WriteLiteral(" data-hoffset=\"0\"");

WriteLiteral("\r\n                                 data-y=\"center\"");

WriteLiteral(" data-voffset=\"25\"");

WriteLiteral("\r\n                                 data-start=\"2000\"");

WriteLiteral("\r\n                                 style=\"z-index: 5\"");

WriteLiteral("\r\n                                 data-transform_in=\"y:[100%];opacity:0;s:500;\"");

WriteLiteral(">");

            
            #line 82 "..\..\Views\Home\Index.cshtml"
                                                                           Write(item.ImageFileTerms.Where(it => it.Language.CultureName.Trim().Equals(Thread.CurrentThread.CurrentCulture.Name) && it.ImageFileId == item.Id).FirstOrDefault()?.TertiaryCaption);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n\r\n                                <a");

WriteLiteral(" class=\"tp-caption btn btn-lg btn-primary btn-slider-action\"");

WriteLiteral("\r\n                                   data-hash");

WriteLiteral("\r\n                                   data-hash-offset=\"85\"");

WriteLiteral("\r\n                                   href=\"#home-intro\"");

WriteLiteral("\r\n                                   data-x=\"center\"");

WriteLiteral(" data-hoffset=\"0\"");

WriteLiteral("\r\n                                   data-y=\"center\"");

WriteLiteral(" data-voffset=\"120\"");

WriteLiteral("\r\n                                   data-start=\"2200\"");

WriteLiteral("\r\n                                   data-whitespace=\"nowrap\"");

WriteLiteral("\r\n                                   data-transform_in=\"y:[100%];s:500;\"");

WriteLiteral("\r\n                                   data-transform_out=\"opacity:0;s:500;\"");

WriteLiteral("\r\n                                   style=\"z-index: 5\"");

WriteLiteral("\r\n                                   data-mask_in=\"x:0px;y:0px;\"");

WriteLiteral(">");

            
            #line 95 "..\..\Views\Home\Index.cshtml"
                                                          Write(Resources.Resources.ExploreOurSite);

            
            #line default
            #line hidden
WriteLiteral("!</a>\r\n\r\n                            </li>\r\n");

            
            #line 98 "..\..\Views\Home\Index.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("            </ul>\r\n        </div>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"home-intro home-intro-primary\"");

WriteLiteral(" id=\"home-intro\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"container\"");

WriteLiteral(">\r\n\r\n            <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"col-md-8\"");

WriteLiteral(">\r\n                    <p>\r\n");

WriteLiteral("                        ");

            
            #line 108 "..\..\Views\Home\Index.cshtml"
                    Write(Model.ContentLists.Where(c => c.Code.Trim().Equals("intro")).FirstOrDefault()?.Title);

            
            #line default
            #line hidden
WriteLiteral("\r\n                        <span");

WriteLiteral(" class=\"text-light\"");

WriteLiteral(">");

            
            #line 109 "..\..\Views\Home\Index.cshtml"
                                             Write(Model.ContentLists.Where(c => c.Code.Trim().Equals("intro")).FirstOrDefault()?.Subtitle);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                    </p>\r\n                </div>\r\n                ");

WriteLiteral("\r\n            </div>\r\n\r\n        </div>\r\n    </div>\r\n    ");

WriteLiteral("\r\n    <section");

WriteLiteral(" class=\"section section-background section-center mt-none\"");

WriteLiteral(" style=\"background-image: url(~/assets/porto/img/patterns/swirl_pattern.png);\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"container\"");

WriteLiteral(">\r\n            <h2");

WriteLiteral(" class=\"mb-xl\"");

WriteLiteral(">Our <strong>Services</strong></h2>\r\n            <hr />\r\n");

            
            #line 208 "..\..\Views\Home\Index.cshtml"
            
            
            #line default
            #line hidden
            
            #line 208 "..\..\Views\Home\Index.cshtml"
             foreach (var item in shortcutContents.Where(c => c.ContentType.Code.Trim().Equals("service")))
            {

            
            #line default
            #line hidden
WriteLiteral("                <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"col-md-12\"");

WriteLiteral(">\r\n                        <div>\r\n                            <h3");

WriteLiteral(" class=\"mb-sm\"");

WriteLiteral(">");

            
            #line 213 "..\..\Views\Home\Index.cshtml"
                                         Write(item.Title);

            
            #line default
            #line hidden
WriteLiteral("</h3>\r\n                            <img");

WriteLiteral(" width=\"300\"");

WriteLiteral(" height=\"225\"");

WriteAttribute("src", Tuple.Create(" src=\"", 13926), Tuple.Create("\"", 13947)
            
            #line 214 "..\..\Views\Home\Index.cshtml"
, Tuple.Create(Tuple.Create("", 13932), Tuple.Create<System.Object, System.Int32>(item.ImagePath
            
            #line default
            #line hidden
, 13932), false)
);

WriteAttribute("alt", Tuple.Create(" alt=\"", 13948), Tuple.Create("\"", 13969)
            
            #line 214 "..\..\Views\Home\Index.cshtml"
    , Tuple.Create(Tuple.Create("", 13954), Tuple.Create<System.Object, System.Int32>(item.ImageName
            
            #line default
            #line hidden
, 13954), false)
);

WriteLiteral(" class=\" boxshadow\"");

WriteLiteral(" />\r\n                            <p");

WriteLiteral(" class=\"bold mt-lg\"");

WriteLiteral(">");

            
            #line 215 "..\..\Views\Home\Index.cshtml"
                                             Write(item.Subtitle);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n                            <p");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(">");

            
            #line 216 "..\..\Views\Home\Index.cshtml"
                                              Write(item.MainContent.StripHtml().Chop(300).Trim());

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n                            <a");

WriteLiteral(" class=\"btn btn-borders btn-quaternary custom-button text-uppercase mb-lg font-we" +
"ight-bold\"");

WriteAttribute("href", Tuple.Create(" href=\"", 14288), Tuple.Create("\"", 14355)
            
            #line 217 "..\..\Views\Home\Index.cshtml"
                                               , Tuple.Create(Tuple.Create("", 14295), Tuple.Create<System.Object, System.Int32>(Url.Action("Content", "Pages" , new { slug=@item.UrlSlug })
            
            #line default
            #line hidden
, 14295), false)
);

WriteLiteral(">");

            
            #line 217 "..\..\Views\Home\Index.cshtml"
                                                                                                                                                                                         Write(Resources.Resources.ReadMore);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n                        </div>\r\n                        ");

WriteLiteral("\r\n                    </div>\r\n                </div>\r\n");

WriteLiteral("                <hr />\r\n");

            
            #line 225 "..\..\Views\Home\Index.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("        </div>\r\n    </section>\r\n");

            
            #line 228 "..\..\Views\Home\Index.cshtml"
    
            
            #line default
            #line hidden
            
            #line 228 "..\..\Views\Home\Index.cshtml"
      
        var about = cmsDb.Contents.Where(c => c.Code.Trim().Equals("about")).FirstOrDefault();
    
            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 231 "..\..\Views\Home\Index.cshtml"
    
            
            #line default
            #line hidden
            
            #line 231 "..\..\Views\Home\Index.cshtml"
     if (about != null)
    {

            
            #line default
            #line hidden
WriteLiteral("        <section");

WriteLiteral(" class=\"section section-tertiary pb-none mb-none\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"container\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"col-md-7\"");

WriteLiteral(">\r\n                        <h2");

WriteLiteral(" class=\"text-light\"");

WriteLiteral("><strong>Who</strong> We Are</h2>\r\n                        <p");

WriteLiteral(" class=\"bold\"");

WriteLiteral(">");

            
            #line 238 "..\..\Views\Home\Index.cshtml"
                                    Write(about?.Subtitle);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n                        <p");

WriteLiteral(" class=\"text-light\"");

WriteLiteral(">");

            
            #line 239 "..\..\Views\Home\Index.cshtml"
                                          Write(about?.MainContent.StripHtml().Chop(350));

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n                        <a");

WriteLiteral(" class=\"btn btn-secondary mt-lg mb-sm\"");

WriteAttribute("href", Tuple.Create(" href=\"", 15393), Tuple.Create("\"", 15461)
            
            #line 240 "..\..\Views\Home\Index.cshtml"
, Tuple.Create(Tuple.Create("", 15400), Tuple.Create<System.Object, System.Int32>(Url.Action("Content", "Pages" , new { slug=@about.UrlSlug })
            
            #line default
            #line hidden
, 15400), false)
);

WriteLiteral(">");

            
            #line 240 "..\..\Views\Home\Index.cshtml"
                                                                                                                                 Write(Resources.Resources.ReadMore);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n                    </div>\r\n                    <div");

WriteLiteral(" class=\"col-md-4 col-md-offset-1\"");

WriteLiteral(">\r\n                        <img");

WriteLiteral(" class=\"img-responsive appear-animation\"");

WriteAttribute("src", Tuple.Create(" src=\"", 15654), Tuple.Create("\"", 15679)
            
            #line 243 "..\..\Views\Home\Index.cshtml"
, Tuple.Create(Tuple.Create("", 15660), Tuple.Create<System.Object, System.Int32>(about?.ImagePath
            
            #line default
            #line hidden
, 15660), false)
);

WriteLiteral(" alt=\"\"");

WriteLiteral(" data-appear-animation=\"fadeInUp\"");

WriteLiteral(">\r\n                    </div>\r\n                </div>\r\n            </div>\r\n      " +
"  </section>\r\n");

            
            #line 248 "..\..\Views\Home\Index.cshtml"

    }

            
            #line default
            #line hidden
WriteLiteral("    <section");

WriteLiteral(" class=\"section section-background section-center mt-none\"");

WriteLiteral(" style=\"background-image: url(~/assets/porto/img/patterns/swirl_pattern.png);\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"container\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"col-md-10 col-md-offset-1\"");

WriteLiteral(">\r\n                    <h2");

WriteLiteral(" class=\"heading-dark mt-xl\"");

WriteLiteral(">Our <strong>Clients</strong></h2>\r\n                    <div");

WriteLiteral(" class=\"owl-carousel owl-theme nav-bottom rounded-nav\"");

WriteLiteral(" data-plugin-options=\"{\'items\': 1, \'loop\': false}\"");

WriteLiteral(">\r\n");

            
            #line 256 "..\..\Views\Home\Index.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 256 "..\..\Views\Home\Index.cshtml"
                         foreach (var item in testimonialList.ListItems)
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <div>\r\n                                <div");

WriteLiteral(" class=\"col-md-12\"");

WriteLiteral(">\r\n                                    <div");

WriteLiteral(" class=\"testimonial testimonial-style-2 testimonial-with-quotes mb-none\"");

WriteLiteral(">\r\n                                        <div");

WriteLiteral(" class=\"testimonial-author\"");

WriteLiteral(">\r\n                                            <img");

WriteAttribute("src", Tuple.Create(" src=\"", 16743), Tuple.Create("\"", 16764)
            
            #line 262 "..\..\Views\Home\Index.cshtml"
, Tuple.Create(Tuple.Create("", 16749), Tuple.Create<System.Object, System.Int32>(item.ThumbPath
            
            #line default
            #line hidden
, 16749), false)
);

WriteLiteral(" class=\"img-responsive img-circle\"");

WriteLiteral(" alt=\"\"");

WriteLiteral(">\r\n                                        </div>\r\n                              " +
"          <blockquote>\r\n                                            <p>");

            
            #line 265 "..\..\Views\Home\Index.cshtml"
                                          Write(Html.Raw(HttpUtility.HtmlDecode(item.Body)));

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n                                        </blockquote>\r\n                    " +
"                    <div");

WriteLiteral(" class=\"testimonial-author\"");

WriteLiteral(">\r\n                                            <p><strong>");

            
            #line 268 "..\..\Views\Home\Index.cshtml"
                                                  Write(item.Title);

            
            #line default
            #line hidden
WriteLiteral("</strong><span>");

            
            #line 268 "..\..\Views\Home\Index.cshtml"
                                                                            Write(item.Subtitle);

            
            #line default
            #line hidden
WriteLiteral("</span></p>\r\n                                        </div>\r\n                    " +
"                </div>\r\n                                </div>\r\n                " +
"            </div>\r\n");

            
            #line 273 "..\..\Views\Home\Index.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("                    </div>\r\n                </div>\r\n            </div>\r\n        <" +
"/div>\r\n    </section>\r\n\r\n    <section");

WriteLiteral(" class=\"section section-primary\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"container\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"col-md-6\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"recent-posts mb-xl\"");

WriteLiteral(">\r\n                        <h2");

WriteLiteral(" class=\"mb-xs\"");

WriteLiteral(">Our <strong>Blog</strong></h2>\r\n                        <div");

WriteLiteral(" class=\"owl-carousel owl-theme nav-bottom rounded-nav pl-xs pr-xs\"");

WriteLiteral(" data-plugin-options=\"{\'delay\': 5000, \'items\': 1, \'loop\': true, \'dots\': false, \'n" +
"av\': true}\"");

WriteLiteral(">\r\n\r\n");

            
            #line 288 "..\..\Views\Home\Index.cshtml"
                            
            
            #line default
            #line hidden
            
            #line 288 "..\..\Views\Home\Index.cshtml"
                              var newsIndex = 0; bool newsDivClosed = false; 
            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 289 "..\..\Views\Home\Index.cshtml"
                            
            
            #line default
            #line hidden
            
            #line 289 "..\..\Views\Home\Index.cshtml"
                             foreach (var item in Model.Contents.Where(c => c.ContentType.Code.Trim().Equals("blog")).OrderByDescending(c => c.PublishedOn).Take(12))
                {
                    newsDivClosed = false;
                    if (newsIndex % 2 == 0)
                    {

            
            #line default
            #line hidden
WriteLiteral("                        ");

WriteLiteral("<div class=\"row mt-lg\">\r\n");

            
            #line 295 "..\..\Views\Home\Index.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("            <div");

WriteLiteral(" class=\"col-md-6\"");

WriteLiteral(">\r\n                <article>\r\n                    <div");

WriteLiteral(" class=\"date\"");

WriteLiteral(">\r\n                        <span");

WriteLiteral(" class=\"day\"");

WriteLiteral(">");

            
            #line 299 "..\..\Views\Home\Index.cshtml"
                                     Write(item.PublishedOn.Value.Day);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                        <span");

WriteLiteral(" class=\"month month background-color-secondary\"");

WriteLiteral(">");

            
            #line 300 "..\..\Views\Home\Index.cshtml"
                                                                        Write(item.PublishedOn.Value.Month);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                    </div>\r\n                    <h4><a");

WriteLiteral(" class=\"text-light\"");

WriteAttribute("href", Tuple.Create(" href=\"", 18829), Tuple.Create("\"", 18896)
            
            #line 302 "..\..\Views\Home\Index.cshtml"
, Tuple.Create(Tuple.Create("", 18836), Tuple.Create<System.Object, System.Int32>(Url.Action("Content", "Pages" , new { slug=@item.UrlSlug })
            
            #line default
            #line hidden
, 18836), false)
);

WriteLiteral(">");

            
            #line 302 "..\..\Views\Home\Index.cshtml"
                                                                                                             Write(item.Title);

            
            #line default
            #line hidden
WriteLiteral("</a></h4>\r\n                    <p");

WriteLiteral(" class=\"text-justify\"");

WriteLiteral(">");

            
            #line 303 "..\..\Views\Home\Index.cshtml"
                                       Write(item.MainContent.StripHtml().Chop(120));

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n                    <a");

WriteLiteral(" class=\"btn btn-secondary mt-3 mb-2 mb-lg-0\"");

WriteAttribute("href", Tuple.Create(" href=\"", 19075), Tuple.Create("\"", 19142)
            
            #line 304 "..\..\Views\Home\Index.cshtml"
, Tuple.Create(Tuple.Create("", 19082), Tuple.Create<System.Object, System.Int32>(Url.Action("Content", "Pages" , new { slug=@item.UrlSlug })
            
            #line default
            #line hidden
, 19082), false)
);

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-plus\"");

WriteLiteral("></i><span> ");

            
            #line 304 "..\..\Views\Home\Index.cshtml"
                                                                                                                                                                   Write(Resources.Resources.ReadMore);

            
            #line default
            #line hidden
WriteLiteral("</span></a>\r\n                </article>\r\n            </div>\r\n");

            
            #line 307 "..\..\Views\Home\Index.cshtml"
newsIndex++;
if (newsIndex % 2 == 0)
{
    newsDivClosed = true;

            
            #line default
            #line hidden
WriteLiteral("            ");

WriteLiteral("            </div>\r\n");

            
            #line 312 "..\..\Views\Home\Index.cshtml"
}
}

            
            #line default
            #line hidden
WriteLiteral("                        </div>\r\n");

            
            #line 315 "..\..\Views\Home\Index.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 315 "..\..\Views\Home\Index.cshtml"
                         if (!newsDivClosed)
            {
                newsDivClosed = true;

            
            #line default
            #line hidden
WriteLiteral("                ");

WriteLiteral("            </div>\r\n");

            
            #line 319 "..\..\Views\Home\Index.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("                    </div>\r\n                    <div");

WriteLiteral(" class=\"col-md-6\"");

WriteLiteral(">\r\n                        <h2");

WriteLiteral(" class=\"mb-xs\"");

WriteLiteral(">Our <strong>Stats</strong></h2>\r\n                        <div");

WriteLiteral(" class=\"content-grid content-grid-dashed mt-xlg mb-lg\"");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\"row content-grid-row\"");

WriteLiteral(">\r\n                                <div");

WriteLiteral(" class=\"content-grid-item col-md-6 center\"");

WriteLiteral(">\r\n                                    <div");

WriteLiteral(" class=\"counters\"");

WriteLiteral(">\r\n                                        <div");

WriteLiteral(" class=\"counter text-color-light\"");

WriteLiteral(">\r\n                                            <strong");

WriteLiteral(" data-to=\"25000\"");

WriteLiteral(" data-append=\"+\"");

WriteLiteral(">0</strong>\r\n                                            <label>Happy Clients</la" +
"bel>\r\n                                        </div>\r\n                          " +
"          </div>\r\n                                </div>\r\n                      " +
"          <div");

WriteLiteral(" class=\"content-grid-item col-md-6 center\"");

WriteLiteral(">\r\n                                    <div");

WriteLiteral(" class=\"counters\"");

WriteLiteral(">\r\n                                        <div");

WriteLiteral(" class=\"counter text-color-light\"");

WriteLiteral(">\r\n                                            <strong");

WriteLiteral(" data-to=\"15\"");

WriteLiteral(@">0</strong>
                                            <label>Years in Business</label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div");

WriteLiteral(" class=\"row content-grid-row\"");

WriteLiteral(">\r\n                                <div");

WriteLiteral(" class=\"content-grid-item col-md-6 center\"");

WriteLiteral(">\r\n                                    <div");

WriteLiteral(" class=\"counters\"");

WriteLiteral(">\r\n                                        <div");

WriteLiteral(" class=\"counter text-color-light\"");

WriteLiteral(">\r\n                                            <strong");

WriteLiteral(" data-to=\"12\"");

WriteLiteral(">0</strong>\r\n                                            <label>Awards</label>\r\n " +
"                                       </div>\r\n                                 " +
"   </div>\r\n                                </div>\r\n                             " +
"   <div");

WriteLiteral(" class=\"content-grid-item col-md-6 center\"");

WriteLiteral(">\r\n                                    <div");

WriteLiteral(" class=\"counters\"");

WriteLiteral(">\r\n                                        <div");

WriteLiteral(" class=\"counter text-color-light\"");

WriteLiteral(">\r\n                                            <strong");

WriteLiteral(" data-to=\"178\"");

WriteLiteral(@">0</strong>
                                            <label>High Score</label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        ");

WriteLiteral("\r\n    </div>\r\n");

        }
    }
}
#pragma warning restore 1591
