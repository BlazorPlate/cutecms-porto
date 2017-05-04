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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/Config/Views/Organizations/Translations.cshtml")]
    public partial class _Areas_Config_Views_Organizations_Translations_cshtml : System.Web.Mvc.WebViewPage<IEnumerable<cutecms_porto.Areas.Config.Models.DBModel.Organization>>
    {
        public _Areas_Config_Views_Organizations_Translations_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Areas\Config\Views\Organizations\Translations.cshtml"
  
    ViewBag.MainTitle = Resources.Resources.Translations;
    ViewBag.Title = Resources.Resources.Index;

            
            #line default
            #line hidden
WriteLiteral("\r\n<p>\r\n");

WriteLiteral("    ");

            
            #line 7 "..\..\Areas\Config\Views\Organizations\Translations.cshtml"
Write(Html.ActionLink(Resources.Resources.AddTranslation, "Create", new { id = ViewBag.TranslationId, isDefault = ViewBag.IsDefault }));

            
            #line default
            #line hidden
WriteLiteral("\r\n</p>\r\n<table");

WriteLiteral(" class=\"table\"");

WriteLiteral(">\r\n    <tr>\r\n        <th>\r\n");

WriteLiteral("            ");

            
            #line 12 "..\..\Areas\Config\Views\Organizations\Translations.cshtml"
       Write(Html.DisplayNameFor(model => model.Code));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </th>\r\n        <th>\r\n");

WriteLiteral("            ");

            
            #line 15 "..\..\Areas\Config\Views\Organizations\Translations.cshtml"
       Write(Html.DisplayNameFor(model => model.Name));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </th>\r\n        <th>\r\n");

WriteLiteral("            ");

            
            #line 18 "..\..\Areas\Config\Views\Organizations\Translations.cshtml"
       Write(Html.DisplayNameFor(model => model.IsDefault));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </th>\r\n        <th></th>\r\n    </tr>\r\n");

            
            #line 22 "..\..\Areas\Config\Views\Organizations\Translations.cshtml"
    
            
            #line default
            #line hidden
            
            #line 22 "..\..\Areas\Config\Views\Organizations\Translations.cshtml"
     foreach (var item in Model)
    {

            
            #line default
            #line hidden
WriteLiteral("        <tr>\r\n            <td>\r\n");

WriteLiteral("                ");

            
            #line 26 "..\..\Areas\Config\Views\Organizations\Translations.cshtml"
           Write(Html.DisplayFor(modelItem => item.Code));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </td>\r\n            <td>\r\n");

WriteLiteral("                ");

            
            #line 29 "..\..\Areas\Config\Views\Organizations\Translations.cshtml"
           Write(Html.DisplayFor(modelItem => item.Name));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </td>\r\n            <td>\r\n");

WriteLiteral("                ");

            
            #line 32 "..\..\Areas\Config\Views\Organizations\Translations.cshtml"
           Write(Html.DisplayFor(modelItem => item.IsDefault));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </td>\r\n            <td>\r\n");

WriteLiteral("                ");

            
            #line 35 "..\..\Areas\Config\Views\Organizations\Translations.cshtml"
           Write(Html.ActionLink(" ", "Index", "Contacts", new { organizationId = item.Id }, new { @class = "fa fa-2x fa-users", @Resources.Resources.ManageContacts }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 36 "..\..\Areas\Config\Views\Organizations\Translations.cshtml"
           Write(Html.ActionLink(" ", "Edit", new { id = item.Id }, new { @class = "fa fa-2x fa-pencil", @title = Resources.Resources.Edit }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 37 "..\..\Areas\Config\Views\Organizations\Translations.cshtml"
           Write(Html.ActionLink(" ", "Details", new { id = item.Id }, new { @class = "fa fa-2x fa-file-text", @title = Resources.Resources.Details }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 38 "..\..\Areas\Config\Views\Organizations\Translations.cshtml"
           Write(Html.ActionLink(" ", "Delete", new { id = item.Id }, new { @class = "fa fa-2x fa-times", @title = Resources.Resources.Delete }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");

            
            #line 41 "..\..\Areas\Config\Views\Organizations\Translations.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("</table>\r\n<div>\r\n");

WriteLiteral("    ");

            
            #line 44 "..\..\Areas\Config\Views\Organizations\Translations.cshtml"
Write(Html.ActionLink(Resources.Resources.BackToList, "Index"));

            
            #line default
            #line hidden
WriteLiteral("\r\n</div>");

        }
    }
}
#pragma warning restore 1591
