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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/Identity/Views/EmployeeTypeTerms/Details.cshtml")]
    public partial class _Areas_Identity_Views_EmployeeTypeTerms_Details_cshtml : System.Web.Mvc.WebViewPage<cutecms_porto.Areas.Identity.Models.DBModel.EmployeeTypeTerm>
    {
        public _Areas_Identity_Views_EmployeeTypeTerms_Details_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Areas\Identity\Views\EmployeeTypeTerms\Details.cshtml"
  
    ViewBag.MainTitle = Resources.Resources.Term;
    ViewBag.Title = Resources.Resources.Details;

            
            #line default
            #line hidden
WriteLiteral("\r\n<div>\r\n    <dl");

WriteLiteral(" class=\"dl-horizontal\"");

WriteLiteral(">\r\n        <dt>\r\n");

WriteLiteral("            ");

            
            #line 9 "..\..\Areas\Identity\Views\EmployeeTypeTerms\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.EmployeeType.Code));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n");

WriteLiteral("            ");

            
            #line 12 "..\..\Areas\Identity\Views\EmployeeTypeTerms\Details.cshtml"
       Write(Html.DisplayFor(model => model.EmployeeType.Code));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n");

WriteLiteral("            ");

            
            #line 15 "..\..\Areas\Identity\Views\EmployeeTypeTerms\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.LanguageId));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n");

WriteLiteral("            ");

            
            #line 18 "..\..\Areas\Identity\Views\EmployeeTypeTerms\Details.cshtml"
       Write(Html.DisplayFor(model => model.Language.Name));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n");

WriteLiteral("            ");

            
            #line 21 "..\..\Areas\Identity\Views\EmployeeTypeTerms\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Value));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n");

WriteLiteral("            ");

            
            #line 24 "..\..\Areas\Identity\Views\EmployeeTypeTerms\Details.cshtml"
       Write(Html.DisplayFor(model => model.Value));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<p>\r\n");

WriteLiteral("    ");

            
            #line 29 "..\..\Areas\Identity\Views\EmployeeTypeTerms\Details.cshtml"
Write(Html.ActionLink(Resources.Resources.Edit, "Edit", new { id = Model.Id }));

            
            #line default
            #line hidden
WriteLiteral(" |\r\n");

WriteLiteral("    ");

            
            #line 30 "..\..\Areas\Identity\Views\EmployeeTypeTerms\Details.cshtml"
Write(Html.ActionLink(Resources.Resources.BackToList, "Index", new { id = Model.EmployeeTypeId }));

            
            #line default
            #line hidden
WriteLiteral("\r\n</p>");

        }
    }
}
#pragma warning restore 1591
