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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/Config/Views/NotificationTerms/Delete.cshtml")]
    public partial class _Areas_Config_Views_NotificationTerms_Delete_cshtml : System.Web.Mvc.WebViewPage<cutecms_porto.Areas.Config.Models.DBModel.NotificationTerm>
    {
        public _Areas_Config_Views_NotificationTerms_Delete_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Areas\Config\Views\NotificationTerms\Delete.cshtml"
  
    ViewBag.MainTitle = Resources.Resources.Term;
    ViewBag.Title = Resources.Resources.Delete;

            
            #line default
            #line hidden
WriteLiteral("\r\n<h3>");

            
            #line 6 "..\..\Areas\Config\Views\NotificationTerms\Delete.cshtml"
Write(Resources.Resources.DeleteConfirmation);

            
            #line default
            #line hidden
WriteLiteral("</h3>\r\n<div>\r\n    <dl");

WriteLiteral(" class=\"dl-horizontal\"");

WriteLiteral(">\r\n        <dt>\r\n");

WriteLiteral("            ");

            
            #line 10 "..\..\Areas\Config\Views\NotificationTerms\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Notification.NotificationCode.Code));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n");

WriteLiteral("            ");

            
            #line 13 "..\..\Areas\Config\Views\NotificationTerms\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Notification.NotificationCode.Code));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n");

WriteLiteral("            ");

            
            #line 16 "..\..\Areas\Config\Views\NotificationTerms\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.LanguageId));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n");

WriteLiteral("            ");

            
            #line 19 "..\..\Areas\Config\Views\NotificationTerms\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Language.Name));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n");

WriteLiteral("            ");

            
            #line 22 "..\..\Areas\Config\Views\NotificationTerms\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Subject));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n");

WriteLiteral("            ");

            
            #line 25 "..\..\Areas\Config\Views\NotificationTerms\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Subject));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n");

WriteLiteral("            ");

            
            #line 28 "..\..\Areas\Config\Views\NotificationTerms\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Body));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n");

WriteLiteral("            ");

            
            #line 31 "..\..\Areas\Config\Views\NotificationTerms\Delete.cshtml"
       Write(Html.Raw(HttpUtility.HtmlDecode(Model.Body)));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n");

            
            #line 34 "..\..\Areas\Config\Views\NotificationTerms\Delete.cshtml"
    
            
            #line default
            #line hidden
            
            #line 34 "..\..\Areas\Config\Views\NotificationTerms\Delete.cshtml"
     using (Html.BeginForm()) {
        
            
            #line default
            #line hidden
            
            #line 35 "..\..\Areas\Config\Views\NotificationTerms\Delete.cshtml"
   Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 35 "..\..\Areas\Config\Views\NotificationTerms\Delete.cshtml"
                                

            
            #line default
            #line hidden
WriteLiteral("        <div");

WriteLiteral(" class=\"form-actions no-color\"");

WriteLiteral(">\r\n            <input");

WriteLiteral(" type=\"submit\"");

WriteAttribute("value", Tuple.Create(" value=", 1163), Tuple.Create("", 1197)
            
            #line 37 "..\..\Areas\Config\Views\NotificationTerms\Delete.cshtml"
, Tuple.Create(Tuple.Create("", 1170), Tuple.Create<System.Object, System.Int32>(Resources.Resources.Delete
            
            #line default
            #line hidden
, 1170), false)
);

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" /> |\r\n");

WriteLiteral("            ");

            
            #line 38 "..\..\Areas\Config\Views\NotificationTerms\Delete.cshtml"
       Write(Html.ActionLink(Resources.Resources.BackToList, "Index", new { id = Model.NotificationId }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n");

            
            #line 40 "..\..\Areas\Config\Views\NotificationTerms\Delete.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n");

        }
    }
}
#pragma warning restore 1591
