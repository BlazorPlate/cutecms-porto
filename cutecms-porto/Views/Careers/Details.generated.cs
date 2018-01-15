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
    
    #line 2 "..\..\Views\Careers\Details.cshtml"
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
    
    #line 3 "..\..\Views\Careers\Details.cshtml"
    using cutecms_porto.Areas.RMS.Models.DBModel;
    
    #line default
    #line hidden
    using cutecms_porto.Helpers;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Careers/Details.cshtml")]
    public partial class _Views_Careers_Details_cshtml : System.Web.Mvc.WebViewPage<cutecms_porto.Areas.RMS.Models.DBModel.Vacancy>
    {
        public _Views_Careers_Details_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 4 "..\..\Views\Careers\Details.cshtml"
  
    ViewBag.Title = Resources.Resources.Careers;
    Layout = "~/Views/Shared/_Layout.cshtml";
    RMSEntities db = new RMSEntities();

            
            #line default
            #line hidden
WriteLiteral("\r\n");

DefineSection("PageHeader", () => {

WriteLiteral("\r\n    <section");

WriteLiteral(" class=\"page-header\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"container\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"col-md-12\"");

WriteLiteral(">\r\n                    <h1>");

            
            #line 15 "..\..\Views\Careers\Details.cshtml"
                   Write(ViewBag.Title);

            
            #line default
            #line hidden
WriteLiteral("</h1>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </section>" +
"\r\n");

});

WriteLiteral("<div");

WriteLiteral(" class=\"container\"");

WriteLiteral(">\r\n    <h3");

WriteLiteral(" class=\"heading-primary\"");

WriteLiteral(">");

            
            #line 22 "..\..\Views\Careers\Details.cshtml"
                           Write(Model.Title);

            
            #line default
            #line hidden
WriteLiteral("</h3>\r\n    <div");

WriteLiteral(" class=\"row text-justify\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"col-md-12\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"feature-box feature-box-style-2\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"feature-box-icon\"");

WriteLiteral(">\r\n                    <i");

WriteLiteral(" class=\"fa fa-file-text\"");

WriteLiteral("></i>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"feature-box-info\"");

WriteLiteral(">\r\n                    <h4");

WriteLiteral(" class=\"mb-none\"");

WriteLiteral(">");

            
            #line 30 "..\..\Views\Careers\Details.cshtml"
                                   Write(Resources.Resources.Description);

            
            #line default
            #line hidden
WriteLiteral("</h4>\r\n                    <p");

WriteLiteral(" class=\"tall\"");

WriteLiteral(">");

            
            #line 31 "..\..\Views\Careers\Details.cshtml"
                               Write(Html.Raw(HttpUtility.HtmlDecode(Model.Description)));

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n                </div>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"feature-box feature-box-style-2\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"feature-box-icon\"");

WriteLiteral(">\r\n                    <i");

WriteLiteral(" class=\"fa fa-list-ol\"");

WriteLiteral("></i>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"feature-box-info\"");

WriteLiteral(">\r\n                    <h4");

WriteLiteral(" class=\"mb-none\"");

WriteLiteral(">");

            
            #line 39 "..\..\Views\Careers\Details.cshtml"
                                   Write(Resources.Resources.Requirements);

            
            #line default
            #line hidden
WriteLiteral("</h4>\r\n                    <p");

WriteLiteral(" class=\"tall\"");

WriteLiteral(">");

            
            #line 40 "..\..\Views\Careers\Details.cshtml"
                               Write(Html.Raw(HttpUtility.HtmlDecode(Model.Requirements)));

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n                </div>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"feature-box feature-box-style-2\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"feature-box-icon\"");

WriteLiteral(">\r\n                    <i");

WriteLiteral(" class=\"fa fa-folder-open\"");

WriteLiteral("></i>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"feature-box-info\"");

WriteLiteral(">\r\n                    <h4");

WriteLiteral(" class=\"mb-none\"");

WriteLiteral(">");

            
            #line 48 "..\..\Views\Careers\Details.cshtml"
                                   Write(Resources.Resources.Documents);

            
            #line default
            #line hidden
WriteLiteral("</h4>\r\n                    <p");

WriteLiteral(" class=\"tall\"");

WriteLiteral(">");

            
            #line 49 "..\..\Views\Careers\Details.cshtml"
                               Write(Html.Raw(HttpUtility.HtmlDecode(Model.Documents)));

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n                </div>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"feature-box feature-box-style-2\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"feature-box-icon\"");

WriteLiteral(">\r\n                    <i");

WriteLiteral(" class=\"fa fa-check-square\"");

WriteLiteral("></i>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"feature-box-info\"");

WriteLiteral(">\r\n                    <h4");

WriteLiteral(" class=\"mb-none\"");

WriteLiteral(">");

            
            #line 57 "..\..\Views\Careers\Details.cshtml"
                                   Write(Resources.Resources.Skills);

            
            #line default
            #line hidden
WriteLiteral("</h4>\r\n                    <p");

WriteLiteral(" class=\"tall\"");

WriteLiteral(">");

            
            #line 58 "..\..\Views\Careers\Details.cshtml"
                               Write(Html.Raw(HttpUtility.HtmlDecode(Model.Skills)));

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n                </div>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"feature-box feature-box-style-2\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"feature-box-icon\"");

WriteLiteral(">\r\n                    <i");

WriteLiteral(" class=\"fa fa-id-card-o\"");

WriteLiteral("></i>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"feature-box-info\"");

WriteLiteral(">\r\n                    <h4");

WriteLiteral(" class=\"mb-none\"");

WriteLiteral(">");

            
            #line 66 "..\..\Views\Careers\Details.cshtml"
                                   Write(Resources.Resources.JobType);

            
            #line default
            #line hidden
WriteLiteral("</h4>\r\n");

            
            #line 67 "..\..\Views\Careers\Details.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 67 "..\..\Views\Careers\Details.cshtml"
                      
                        string jobTypeName = TermsHelper.JobTypes().Where(j => j.JobTypeId == Model.JobTypeId).FirstOrDefault()?.Value ?? db.JobTypes.Where(j => j.Id == Model.JobTypeId).FirstOrDefault().Code;

            
            #line default
            #line hidden
WriteLiteral("                        <p");

WriteLiteral(" class=\"tall\"");

WriteLiteral(">");

            
            #line 69 "..\..\Views\Careers\Details.cshtml"
                                   Write(jobTypeName);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n");

            
            #line 70 "..\..\Views\Careers\Details.cshtml"
                    
            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n            </div>\r\n");

            
            #line 73 "..\..\Views\Careers\Details.cshtml"
            
            
            #line default
            #line hidden
            
            #line 73 "..\..\Views\Careers\Details.cshtml"
             if (Model.VacancyDegrees.Count() > 0)
            {

            
            #line default
            #line hidden
WriteLiteral("                <div");

WriteLiteral(" class=\"feature-box feature-box-style-2\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"feature-box-icon\"");

WriteLiteral(">\r\n                        <i");

WriteLiteral(" class=\"fa fa-graduation-cap\"");

WriteLiteral("></i>\r\n                    </div>\r\n\r\n                    <div");

WriteLiteral(" class=\"feature-box-info\"");

WriteLiteral(">\r\n                        <h4");

WriteLiteral(" class=\"mb-none\"");

WriteLiteral(">");

            
            #line 81 "..\..\Views\Careers\Details.cshtml"
                                       Write(Resources.Resources.Degree);

            
            #line default
            #line hidden
WriteLiteral("</h4>\r\n");

            
            #line 82 "..\..\Views\Careers\Details.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 82 "..\..\Views\Careers\Details.cshtml"
                         foreach (var degree in Model.VacancyDegrees)
                        {
                            string degreeName = TermsHelper.Degrees().Where(d => d.DegreeId == degree.DegreeId).FirstOrDefault()?.Value ?? db.RMSDegrees.Where(d => d.Id == degree.DegreeId).FirstOrDefault().Code;

            
            #line default
            #line hidden
WriteLiteral("                            <p");

WriteLiteral(" class=\"tall\"");

WriteLiteral(">");

            
            #line 85 "..\..\Views\Careers\Details.cshtml"
                                       Write(degreeName);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n");

            
            #line 86 "..\..\Views\Careers\Details.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("                    </div>\r\n\r\n\r\n                </div>\r\n");

            
            #line 91 "..\..\Views\Careers\Details.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("            ");

            
            #line 92 "..\..\Views\Careers\Details.cshtml"
             if (Model.VacancyRanks.Count() > 0)
            {

            
            #line default
            #line hidden
WriteLiteral("                <div");

WriteLiteral(" class=\"feature-box feature-box-style-2\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"feature-box-icon\"");

WriteLiteral(">\r\n                        <i");

WriteLiteral(" class=\"fa fa-star\"");

WriteLiteral("></i>\r\n                    </div>\r\n                    <div");

WriteLiteral(" class=\"feature-box-info\"");

WriteLiteral(">\r\n                        <h4");

WriteLiteral(" class=\"mb-none\"");

WriteLiteral(">");

            
            #line 99 "..\..\Views\Careers\Details.cshtml"
                                       Write(Resources.Resources.Rank);

            
            #line default
            #line hidden
WriteLiteral("</h4>\r\n");

            
            #line 100 "..\..\Views\Careers\Details.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 100 "..\..\Views\Careers\Details.cshtml"
                         foreach (var rank in Model.VacancyRanks)
                        {
                            string rankName = TermsHelper.Ranks().Where(d => d.RankId == rank.RankId).FirstOrDefault()?.Value ?? db.RMSRanks.Where(d => d.Id == rank.RankId).FirstOrDefault().Code;

            
            #line default
            #line hidden
WriteLiteral("                            <p");

WriteLiteral(" class=\"tall\"");

WriteLiteral(">");

            
            #line 103 "..\..\Views\Careers\Details.cshtml"
                                       Write(rankName);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n");

            
            #line 104 "..\..\Views\Careers\Details.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("                    </div>\r\n                </div>\r\n");

            
            #line 107 "..\..\Views\Careers\Details.cshtml"

            }

            
            #line default
            #line hidden
WriteLiteral("            ");

            
            #line 109 "..\..\Views\Careers\Details.cshtml"
             if (Model.Notes != null)
            {

            
            #line default
            #line hidden
WriteLiteral("                <div");

WriteLiteral(" class=\"feature-box feature-box-style-2\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"feature-box-icon\"");

WriteLiteral(">\r\n                        <i");

WriteLiteral(" class=\"fa fa-sticky-note\"");

WriteLiteral("></i>\r\n                    </div>\r\n                    <div");

WriteLiteral(" class=\"feature-box-info\"");

WriteLiteral(">\r\n                        <h4");

WriteLiteral(" class=\"mb-none\"");

WriteLiteral(">");

            
            #line 116 "..\..\Views\Careers\Details.cshtml"
                                       Write(Resources.Resources.Notes);

            
            #line default
            #line hidden
WriteLiteral("</h4>\r\n                        <p");

WriteLiteral(" class=\"tall\"");

WriteLiteral(">");

            
            #line 117 "..\..\Views\Careers\Details.cshtml"
                                   Write(Html.Raw(HttpUtility.HtmlDecode(Model.Notes)));

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n                    </div>\r\n                </div>\r\n");

            
            #line 120 "..\..\Views\Careers\Details.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 122 "..\..\Views\Careers\Details.cshtml"
            
            
            #line default
            #line hidden
            
            #line 122 "..\..\Views\Careers\Details.cshtml"
             if (Model.ExpiredOn != null)
            {

            
            #line default
            #line hidden
WriteLiteral("                <div");

WriteLiteral(" class=\"feature-box feature-box-style-2\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"feature-box-icon\"");

WriteLiteral(">\r\n                        <i");

WriteLiteral(" class=\"fa fa-clock-o\"");

WriteLiteral("></i>\r\n                    </div>\r\n                    <div");

WriteLiteral(" class=\"feature-box-info\"");

WriteLiteral(">\r\n                        <h4");

WriteLiteral(" class=\"mb-none\"");

WriteLiteral(">");

            
            #line 129 "..\..\Views\Careers\Details.cshtml"
                                       Write(Resources.Resources.ExpiredOn);

            
            #line default
            #line hidden
WriteLiteral("</h4>\r\n                        <p");

WriteLiteral(" class=\"tall\"");

WriteLiteral(">");

            
            #line 130 "..\..\Views\Careers\Details.cshtml"
                                   Write(Model.ExpiredOn);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n                    </div>\r\n                </div>\r\n");

            
            #line 133 "..\..\Views\Careers\Details.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("            <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                <a");

WriteLiteral(" class=\"btn btn-primary mb-xl\"");

WriteAttribute("href", Tuple.Create(" href=\"", 6016), Tuple.Create("\"", 6077)
            
            #line 135 "..\..\Views\Careers\Details.cshtml"
, Tuple.Create(Tuple.Create("", 6023), Tuple.Create<System.Object, System.Int32>(Url.Action("Apply", "Careers", new { id = Model.Id })
            
            #line default
            #line hidden
, 6023), false)
);

WriteLiteral(">");

            
            #line 135 "..\..\Views\Careers\Details.cshtml"
                                                                                                          Write(Resources.Resources.ApplyNow);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n                <a");

WriteLiteral(" class=\"btn btn-primary mb-xl\"");

WriteAttribute("href", Tuple.Create(" href=\"", 6162), Tuple.Create("\"", 6200)
            
            #line 136 "..\..\Views\Careers\Details.cshtml"
, Tuple.Create(Tuple.Create("", 6169), Tuple.Create<System.Object, System.Int32>(Url.Action("Index", "Careers")
            
            #line default
            #line hidden
, 6169), false)
);

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-arrow-left\"");

WriteLiteral("></i> ");

            
            #line 136 "..\..\Views\Careers\Details.cshtml"
                                                                                                                    Write(Resources.Resources.BackToList);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"post-block post-share\"");

WriteLiteral(">\r\n        <h3");

WriteLiteral(" class=\"heading-primary\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-share\"");

WriteLiteral("></i>");

            
            #line 141 "..\..\Views\Careers\Details.cshtml"
                                                          Write(Resources.Resources.Share);

            
            #line default
            #line hidden
WriteLiteral("</h3>\r\n\r\n        <!-- AddThis Button BEGIN -->\r\n        <div");

WriteLiteral(" class=\"addthis_toolbox addthis_default_style \"");

WriteLiteral(">\r\n            <a");

WriteLiteral(" class=\"addthis_button_facebook_like\"");

WriteLiteral(" fb:like:layout=\"button_count\"");

WriteLiteral("></a>\r\n            <a");

WriteLiteral(" class=\"addthis_button_tweet\"");

WriteLiteral("></a>\r\n            <a");

WriteLiteral(" class=\"addthis_button_pinterest_pinit\"");

WriteLiteral("></a>\r\n            <a");

WriteLiteral(" class=\"addthis_counter addthis_pill_style\"");

WriteLiteral("></a>\r\n        </div>\r\n        <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(" src=\"//s7.addthis.com/js/300/addthis_widget.js#pubid=xa-50faf75173aadc53\"");

WriteLiteral("></script>\r\n        <!-- AddThis Button END -->\r\n    </div>\r\n\r\n</div>\r\n");

        }
    }
}
#pragma warning restore 1591
