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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/Identity/Views/Roles/Index.cshtml")]
    public partial class _Areas_Identity_Views_Roles_Index_cshtml : System.Web.Mvc.WebViewPage<IEnumerable<cutecms_porto.Areas.Identity.Models.RoleViewModel>>
    {
        public _Areas_Identity_Views_Roles_Index_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Areas\Identity\Views\Roles\Index.cshtml"
  
    ViewBag.MainTitle = Resources.Resources.Roles;
    ViewBag.Title = Resources.Resources.Index;

            
            #line default
            #line hidden
WriteLiteral("\r\n<p>\r\n");

WriteLiteral("    ");

            
            #line 7 "..\..\Areas\Identity\Views\Roles\Index.cshtml"
Write(Html.ActionLink(Resources.Resources.Create, "Create"));

            
            #line default
            #line hidden
WriteLiteral("\r\n</p>\r\n<table");

WriteLiteral(" class=\"table\"");

WriteLiteral(">\r\n    <tr>\r\n        <th>\r\n");

WriteLiteral("            ");

            
            #line 12 "..\..\Areas\Identity\Views\Roles\Index.cshtml"
       Write(Html.DisplayNameFor(model => model.RoleName));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </th>\r\n        <th>\r\n");

WriteLiteral("            ");

            
            #line 15 "..\..\Areas\Identity\Views\Roles\Index.cshtml"
       Write(Html.DisplayNameFor(model => model.Description));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </th>\r\n        <th></th>\r\n    </tr>\r\n");

            
            #line 19 "..\..\Areas\Identity\Views\Roles\Index.cshtml"
    
            
            #line default
            #line hidden
            
            #line 19 "..\..\Areas\Identity\Views\Roles\Index.cshtml"
     foreach (var item in Model)
    {

            
            #line default
            #line hidden
WriteLiteral("        <tr>\r\n            <td>\r\n");

WriteLiteral("                ");

            
            #line 23 "..\..\Areas\Identity\Views\Roles\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.RoleName));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </td>\r\n            <td>\r\n");

WriteLiteral("                ");

            
            #line 26 "..\..\Areas\Identity\Views\Roles\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Description));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </td>\r\n            <td>\r\n");

WriteLiteral("                ");

            
            #line 29 "..\..\Areas\Identity\Views\Roles\Index.cshtml"
           Write(Html.ActionLink(Resources.Resources.Edit, "Edit", new { id = item.RoleName }));

            
            #line default
            #line hidden
WriteLiteral(" |\r\n");

WriteLiteral("                ");

            
            #line 30 "..\..\Areas\Identity\Views\Roles\Index.cshtml"
           Write(Html.ActionLink(Resources.Resources.Delete, "Delete", new { id = item.RoleName }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");

            
            #line 33 "..\..\Areas\Identity\Views\Roles\Index.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("</table>");

        }
    }
}
#pragma warning restore 1591