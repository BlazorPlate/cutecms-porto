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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/Config/Views/SMTPSettings/Edit.cshtml")]
    public partial class _Areas_Config_Views_SMTPSettings_Edit_cshtml : System.Web.Mvc.WebViewPage<cutecms_porto.Areas.Config.Models.DBModel.SMTPSetting>
    {
        public _Areas_Config_Views_SMTPSettings_Edit_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Areas\Config\Views\SMTPSettings\Edit.cshtml"
     
    ViewBag.MainTitle = Resources.Resources.SMTPSetting;
    ViewBag.Title = Resources.Resources.Edit;

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 6 "..\..\Areas\Config\Views\SMTPSettings\Edit.cshtml"
 using (Html.BeginForm())
{
    
            
            #line default
            #line hidden
            
            #line 8 "..\..\Areas\Config\Views\SMTPSettings\Edit.cshtml"
Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 8 "..\..\Areas\Config\Views\SMTPSettings\Edit.cshtml"
                            

            
            #line default
            #line hidden
WriteLiteral("    <div");

WriteLiteral(" class=\"form-horizontal\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 10 "..\..\Areas\Config\Views\SMTPSettings\Edit.cshtml"
   Write(Html.HiddenFor(model => model.Id));

            
            #line default
            #line hidden
WriteLiteral("\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 12 "..\..\Areas\Config\Views\SMTPSettings\Edit.cshtml"
       Write(Html.LabelFor(model => model.Code, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 14 "..\..\Areas\Config\Views\SMTPSettings\Edit.cshtml"
           Write(Html.EditorFor(model => model.Code, new { htmlAttributes = new { @class = "form-control" } }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 15 "..\..\Areas\Config\Views\SMTPSettings\Edit.cshtml"
           Write(Html.ValidationMessageFor(model => model.Code, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 19 "..\..\Areas\Config\Views\SMTPSettings\Edit.cshtml"
       Write(Html.LabelFor(model => model.SMTP, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 21 "..\..\Areas\Config\Views\SMTPSettings\Edit.cshtml"
           Write(Html.EditorFor(model => model.SMTP, new { htmlAttributes = new { @class = "form-control" } }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 22 "..\..\Areas\Config\Views\SMTPSettings\Edit.cshtml"
           Write(Html.ValidationMessageFor(model => model.SMTP, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 26 "..\..\Areas\Config\Views\SMTPSettings\Edit.cshtml"
       Write(Html.LabelFor(model => model.Port, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 28 "..\..\Areas\Config\Views\SMTPSettings\Edit.cshtml"
           Write(Html.EditorFor(model => model.Port, new { htmlAttributes = new { @class = "form-control" } }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 29 "..\..\Areas\Config\Views\SMTPSettings\Edit.cshtml"
           Write(Html.ValidationMessageFor(model => model.Port, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 33 "..\..\Areas\Config\Views\SMTPSettings\Edit.cshtml"
       Write(Html.LabelFor(model => model.EnableSsl, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 35 "..\..\Areas\Config\Views\SMTPSettings\Edit.cshtml"
           Write(Html.EditorFor(model => model.EnableSsl));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 36 "..\..\Areas\Config\Views\SMTPSettings\Edit.cshtml"
           Write(Html.ValidationMessageFor(model => model.EnableSsl, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 40 "..\..\Areas\Config\Views\SMTPSettings\Edit.cshtml"
       Write(Html.LabelFor(model => model.SenderEmail, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 42 "..\..\Areas\Config\Views\SMTPSettings\Edit.cshtml"
           Write(Html.EditorFor(model => model.SenderEmail, new { htmlAttributes = new { @class = "form-control" } }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 43 "..\..\Areas\Config\Views\SMTPSettings\Edit.cshtml"
           Write(Html.ValidationMessageFor(model => model.SenderEmail, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 47 "..\..\Areas\Config\Views\SMTPSettings\Edit.cshtml"
       Write(Html.LabelFor(model => model.SenderPasswordHash, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 49 "..\..\Areas\Config\Views\SMTPSettings\Edit.cshtml"
           Write(Html.EditorFor(model => model.SenderPasswordHash, new { htmlAttributes = new { @class = "form-control" } }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 50 "..\..\Areas\Config\Views\SMTPSettings\Edit.cshtml"
           Write(Html.ValidationMessageFor(model => model.SenderPasswordHash, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 54 "..\..\Areas\Config\Views\SMTPSettings\Edit.cshtml"
       Write(Html.LabelFor(model => model.RecipientEmail, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 56 "..\..\Areas\Config\Views\SMTPSettings\Edit.cshtml"
           Write(Html.EditorFor(model => model.RecipientEmail, new { htmlAttributes = new { @class = "form-control" } }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 57 "..\..\Areas\Config\Views\SMTPSettings\Edit.cshtml"
           Write(Html.ValidationMessageFor(model => model.RecipientEmail, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 61 "..\..\Areas\Config\Views\SMTPSettings\Edit.cshtml"
       Write(Html.LabelFor(model => model.Visible, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 63 "..\..\Areas\Config\Views\SMTPSettings\Edit.cshtml"
           Write(Html.CheckBoxFor(model => model.Visible, new { @class = "js-switch" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 64 "..\..\Areas\Config\Views\SMTPSettings\Edit.cshtml"
           Write(Html.ValidationMessageFor(model => model.Visible, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 68 "..\..\Areas\Config\Views\SMTPSettings\Edit.cshtml"
       Write(Html.LabelFor(model => model.Ordinal, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 70 "..\..\Areas\Config\Views\SMTPSettings\Edit.cshtml"
           Write(Html.EditorFor(model => model.Ordinal, new { htmlAttributes = new { @class = "form-control" } }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 71 "..\..\Areas\Config\Views\SMTPSettings\Edit.cshtml"
           Write(Html.ValidationMessageFor(model => model.Ordinal, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"col-md-offset-2 col-md-10\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" type=\"submit\"");

WriteAttribute("value", Tuple.Create(" value=", 4333), Tuple.Create("", 4365)
            
            #line 76 "..\..\Areas\Config\Views\SMTPSettings\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 4340), Tuple.Create<System.Object, System.Int32>(Resources.Resources.Save
            
            #line default
            #line hidden
, 4340), false)
);

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" />\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"col-md-offset-2 col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 81 "..\..\Areas\Config\Views\SMTPSettings\Edit.cshtml"
           Write(Html.ValidationSummary(false, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n");

            
            #line 85 "..\..\Areas\Config\Views\SMTPSettings\Edit.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("<div>\r\n");

WriteLiteral("    ");

            
            #line 87 "..\..\Areas\Config\Views\SMTPSettings\Edit.cshtml"
Write(Html.ActionLink(Resources.Resources.BackToList, "Index"));

            
            #line default
            #line hidden
WriteLiteral("\r\n</div>\r\n");

        }
    }
}
#pragma warning restore 1591
