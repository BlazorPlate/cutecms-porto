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
    
    #line 2 "..\..\Views\EmpInDepts\Details.cshtml"
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
    using cutecms_porto.Helpers;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/EmpInDepts/Details.cshtml")]
    public partial class _Views_EmpInDepts_Details_cshtml : System.Web.Mvc.WebViewPage<cutecms_porto.Areas.Identity.Models.DBModel.EmpInDept>
    {
        public _Views_EmpInDepts_Details_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Views\EmpInDepts\Details.cshtml"
  
    ViewBag.Title = Resources.Resources.Departments;

            
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

            
            #line 12 "..\..\Views\EmpInDepts\Details.cshtml"
                   Write(ViewBag.Title);

            
            #line default
            #line hidden
WriteLiteral("</h1>\r\n                    <h2>");

            
            #line 13 "..\..\Views\EmpInDepts\Details.cshtml"
                   Write(Resources.Resources.Details);

            
            #line default
            #line hidden
WriteLiteral("</h2>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </section>" +
"\r\n");

});

WriteLiteral("<section>\r\n    <div");

WriteLiteral(" class=\"container\"");

WriteLiteral(">\r\n        <!-- RIGHT -->\r\n        <div");

WriteLiteral(" class=\"col-lg-9 col-md-9 col-sm-8 col-lg-push-3 col-md-push-3 col-sm-push-4 marg" +
"in-bottom-80\"");

WriteLiteral(">\r\n            <ul");

WriteLiteral(" id=\"tabbed-list\"");

WriteLiteral(" class=\"nav nav-tabs nav-top-border\"");

WriteLiteral(">\r\n                <li");

WriteLiteral(" class=\"active\"");

WriteLiteral("><a");

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(">");

            
            #line 24 "..\..\Views\EmpInDepts\Details.cshtml"
                                                   Write(Resources.Resources.Departments);

            
            #line default
            #line hidden
WriteLiteral("</a></li>\r\n            </ul>\r\n            <div");

WriteLiteral(" class=\"tab-content margin-top-20\"");

WriteLiteral(">\r\n                <h4>");

            
            #line 27 "..\..\Views\EmpInDepts\Details.cshtml"
               Write(Resources.Resources.Details);

            
            #line default
            #line hidden
WriteLiteral("</h4>\r\n");

WriteLiteral("                ");

            
            #line 28 "..\..\Views\EmpInDepts\Details.cshtml"
           Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
WriteLiteral("\r\n                <div>\r\n                    <hr/>\r\n                    <dl>\r\n   " +
"                     <dt>\r\n");

WriteLiteral("                            ");

            
            #line 33 "..\..\Views\EmpInDepts\Details.cshtml"
                       Write(Html.DisplayNameFor(model => model.DeptId));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </dt>\r\n                        <dd>\r\n");

WriteLiteral("                            ");

            
            #line 36 "..\..\Views\EmpInDepts\Details.cshtml"
                       Write(Html.DisplayFor(model => model.Department.DepartmentTerms.Where(d => d.Language.CultureName.Trim().Equals(Thread.CurrentThread.CurrentCulture.Name)).FirstOrDefault().Value));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </dd>\r\n                        <dt>\r\n");

WriteLiteral("                            ");

            
            #line 39 "..\..\Views\EmpInDepts\Details.cshtml"
                       Write(Html.DisplayNameFor(model => model.OccupationId));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </dt>\r\n                        <dd>\r\n");

WriteLiteral("                            ");

            
            #line 42 "..\..\Views\EmpInDepts\Details.cshtml"
                       Write(Html.DisplayFor(model => model.Occupation.OccupationTerms.Where(o => o.Language.CultureName.Trim().Equals(Thread.CurrentThread.CurrentCulture.Name)).FirstOrDefault().Value));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </dd>\r\n                        <dt>\r\n");

WriteLiteral("                            ");

            
            #line 45 "..\..\Views\EmpInDepts\Details.cshtml"
                       Write(Html.DisplayNameFor(model => model.EmployeeTypeId));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </dt>\r\n                        <dd>\r\n");

WriteLiteral("                            ");

            
            #line 48 "..\..\Views\EmpInDepts\Details.cshtml"
                       Write(Html.DisplayFor(model => model.EmployeeType.EmployeeTypeTerms.Where(e => e.Language.CultureName.Trim().Equals(Thread.CurrentThread.CurrentCulture.Name)).FirstOrDefault().Value));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </dd>\r\n                    </dl>\r\n                </div" +
">\r\n                <div");

WriteLiteral(" class=\"form-actions no-color\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 53 "..\..\Views\EmpInDepts\Details.cshtml"
               Write(Html.ActionLink(Resources.Resources.Edit, "Edit", new { id = Model.Id }));

            
            #line default
            #line hidden
WriteLiteral(" |\r\n");

WriteLiteral("                    ");

            
            #line 54 "..\..\Views\EmpInDepts\Details.cshtml"
               Write(Html.ActionLink(Resources.Resources.BackToList, "Index", new { redirectEmpId = Model.EmpId }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n        <!-- LEFT -" +
"->\r\n");

WriteLiteral("        ");

            
            #line 59 "..\..\Views\EmpInDepts\Details.cshtml"
   Write(Html.Partial("_MyProfile"));

            
            #line default
            #line hidden
WriteLiteral(";\r\n    </div>\r\n</section>");

        }
    }
}
#pragma warning restore 1591