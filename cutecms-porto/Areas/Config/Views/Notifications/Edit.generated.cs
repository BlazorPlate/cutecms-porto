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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/Config/Views/Notifications/Edit.cshtml")]
    public partial class _Areas_Config_Views_Notifications_Edit_cshtml : System.Web.Mvc.WebViewPage<cutecms_porto.Areas.Config.Models.DBModel.Notification>
    {
        public _Areas_Config_Views_Notifications_Edit_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Areas\Config\Views\Notifications\Edit.cshtml"
  
    ViewBag.MainTitle = Resources.Resources.Notification;
    ViewBag.Title = Resources.Resources.Edit;

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 6 "..\..\Areas\Config\Views\Notifications\Edit.cshtml"
 using (Html.BeginForm())
{
    
            
            #line default
            #line hidden
            
            #line 8 "..\..\Areas\Config\Views\Notifications\Edit.cshtml"
Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 8 "..\..\Areas\Config\Views\Notifications\Edit.cshtml"
                            

            
            #line default
            #line hidden
WriteLiteral("    <div");

WriteLiteral(" class=\"form-horizontal\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 10 "..\..\Areas\Config\Views\Notifications\Edit.cshtml"
   Write(Html.HiddenFor(model => model.Id));

            
            #line default
            #line hidden
WriteLiteral("\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 12 "..\..\Areas\Config\Views\Notifications\Edit.cshtml"
       Write(Html.LabelFor(model => model.CodeId, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 14 "..\..\Areas\Config\Views\Notifications\Edit.cshtml"
           Write(Html.DropDownList("CodeId", null, htmlAttributes: new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 15 "..\..\Areas\Config\Views\Notifications\Edit.cshtml"
           Write(Html.ValidationMessageFor(model => model.CodeId, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 19 "..\..\Areas\Config\Views\Notifications\Edit.cshtml"
       Write(Html.LabelFor(model => model.SMTPId, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 21 "..\..\Areas\Config\Views\Notifications\Edit.cshtml"
           Write(Html.DropDownList("SMTPId", null, htmlAttributes: new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 22 "..\..\Areas\Config\Views\Notifications\Edit.cshtml"
           Write(Html.ValidationMessageFor(model => model.SMTPId, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"col-md-offset-2 col-md-10\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" type=\"submit\"");

WriteAttribute("value", Tuple.Create(" value=", 1280), Tuple.Create("", 1312)
            
            #line 27 "..\..\Areas\Config\Views\Notifications\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 1287), Tuple.Create<System.Object, System.Int32>(Resources.Resources.Save
            
            #line default
            #line hidden
, 1287), false)
);

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" />\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"col-md-offset-2 col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 32 "..\..\Areas\Config\Views\Notifications\Edit.cshtml"
           Write(Html.ValidationSummary(false, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n");

            
            #line 36 "..\..\Areas\Config\Views\Notifications\Edit.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("<div>\r\n");

WriteLiteral("    ");

            
            #line 38 "..\..\Areas\Config\Views\Notifications\Edit.cshtml"
Write(Html.ActionLink(Resources.Resources.BackToList, "Index"));

            
            #line default
            #line hidden
WriteLiteral("\r\n</div>\r\n");

        }
    }
}
#pragma warning restore 1591