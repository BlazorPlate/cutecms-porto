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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/CMS/Views/ListItems/Index.cshtml")]
    public partial class _Areas_CMS_Views_ListItems_Index_cshtml : System.Web.Mvc.WebViewPage<IEnumerable<cutecms_porto.Areas.CMS.Models.DBModel.ListItem>>
    {
        public _Areas_CMS_Views_ListItems_Index_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Areas\CMS\Views\ListItems\Index.cshtml"
  
    ViewBag.MainTitle = Resources.Resources.ListItems;
    ViewBag.Title = Resources.Resources.Index;

            
            #line default
            #line hidden
WriteLiteral("\r\n<p>\r\n");

WriteLiteral("    ");

            
            #line 7 "..\..\Areas\CMS\Views\ListItems\Index.cshtml"
Write(Html.ActionLink(Resources.Resources.Create, "Create", new { id = ViewBag.ContentListId }));

            
            #line default
            #line hidden
WriteLiteral("\r\n</p>\r\n<table");

WriteLiteral(" class=\"table\"");

WriteLiteral(">\r\n    <tr>\r\n        <th>\r\n");

WriteLiteral("            ");

            
            #line 12 "..\..\Areas\CMS\Views\ListItems\Index.cshtml"
       Write(Html.DisplayNameFor(model => model.ContentList.Title));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </th>\r\n        <th>\r\n");

WriteLiteral("            ");

            
            #line 15 "..\..\Areas\CMS\Views\ListItems\Index.cshtml"
       Write(Html.DisplayNameFor(model => model.Title));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </th>\r\n        <th>\r\n");

WriteLiteral("            ");

            
            #line 18 "..\..\Areas\CMS\Views\ListItems\Index.cshtml"
       Write(Html.DisplayNameFor(model => model.Visible));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </th>\r\n        <th>\r\n");

WriteLiteral("            ");

            
            #line 21 "..\..\Areas\CMS\Views\ListItems\Index.cshtml"
       Write(Html.DisplayNameFor(model => model.Ordinal));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </th>\r\n        <th></th>\r\n    </tr>\r\n");

            
            #line 25 "..\..\Areas\CMS\Views\ListItems\Index.cshtml"
    
            
            #line default
            #line hidden
            
            #line 25 "..\..\Areas\CMS\Views\ListItems\Index.cshtml"
     foreach (var item in Model)
    {

            
            #line default
            #line hidden
WriteLiteral("        <tr>\r\n            <td>\r\n");

WriteLiteral("                ");

            
            #line 29 "..\..\Areas\CMS\Views\ListItems\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.ContentList.Title));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </td>\r\n            <td>\r\n");

WriteLiteral("                ");

            
            #line 32 "..\..\Areas\CMS\Views\ListItems\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Title));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </td>\r\n            <td>\r\n");

WriteLiteral("                ");

            
            #line 35 "..\..\Areas\CMS\Views\ListItems\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Visible));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </td>\r\n            <td>\r\n");

WriteLiteral("                ");

            
            #line 38 "..\..\Areas\CMS\Views\ListItems\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Ordinal));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </td>\r\n            <td>\r\n");

WriteLiteral("                ");

            
            #line 41 "..\..\Areas\CMS\Views\ListItems\Index.cshtml"
           Write(Html.ActionLink(Resources.Resources.Edit, "Edit", new { id = item.Id }));

            
            #line default
            #line hidden
WriteLiteral(" |\r\n");

WriteLiteral("                ");

            
            #line 42 "..\..\Areas\CMS\Views\ListItems\Index.cshtml"
           Write(Html.ActionLink(Resources.Resources.Details, "Details", new { id = item.Id }));

            
            #line default
            #line hidden
WriteLiteral(" |\r\n");

WriteLiteral("                ");

            
            #line 43 "..\..\Areas\CMS\Views\ListItems\Index.cshtml"
           Write(Html.ActionLink(Resources.Resources.Delete, "Delete", new { id = item.Id }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");

            
            #line 46 "..\..\Areas\CMS\Views\ListItems\Index.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("</table>\r\n<p>\r\n");

WriteLiteral("    ");

            
            #line 49 "..\..\Areas\CMS\Views\ListItems\Index.cshtml"
Write(Html.ActionLink(Resources.Resources.BackToList, "Index", "ContentLists", new { id = ViewBag.ContentId }, null));

            
            #line default
            #line hidden
WriteLiteral("\r\n</p>");

        }
    }
}
#pragma warning restore 1591
