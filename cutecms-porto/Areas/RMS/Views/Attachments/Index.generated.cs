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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/RMS/Views/Attachments/Index.cshtml")]
    public partial class _Areas_RMS_Views_Attachments_Index_cshtml : System.Web.Mvc.WebViewPage<IEnumerable<cutecms_porto.Areas.RMS.Models.DBModel.Attachment>>
    {
        public _Areas_RMS_Views_Attachments_Index_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Areas\RMS\Views\Attachments\Index.cshtml"
  
    ViewBag.MainTitle = Resources.Resources.Attachments;
    ViewBag.Title = Resources.Resources.Index;

            
            #line default
            #line hidden
WriteLiteral("\r\n<table");

WriteLiteral(" class=\"table\"");

WriteLiteral(">\r\n    <tr>\r\n        <th>\r\n");

WriteLiteral("            ");

            
            #line 9 "..\..\Areas\RMS\Views\Attachments\Index.cshtml"
       Write(Html.DisplayNameFor(model => model.Applicant.FullName));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </th>\r\n        <th>\r\n");

WriteLiteral("            ");

            
            #line 12 "..\..\Areas\RMS\Views\Attachments\Index.cshtml"
       Write(Html.DisplayNameFor(model => model.FilePath));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </th>\r\n        <th></th>\r\n    </tr>\r\n");

            
            #line 16 "..\..\Areas\RMS\Views\Attachments\Index.cshtml"
 foreach (var item in Model) {

            
            #line default
            #line hidden
WriteLiteral("    <tr>\r\n        <td>\r\n");

WriteLiteral("            ");

            
            #line 19 "..\..\Areas\RMS\Views\Attachments\Index.cshtml"
       Write(Html.DisplayFor(modelItem => item.Applicant.FullName));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </td>\r\n        <td>\r\n");

WriteLiteral("            ");

            
            #line 22 "..\..\Areas\RMS\Views\Attachments\Index.cshtml"
       Write(Html.ActionLink(Resources.Resources.Download, "Download", new { FilePath = item.FilePath, FileName = item.FileName }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </td>\r\n        ");

WriteLiteral("\r\n    </tr>\r\n");

            
            #line 30 "..\..\Areas\RMS\Views\Attachments\Index.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("</table>");

        }
    }
}
#pragma warning restore 1591
