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
    
    #line 1 "..\..\Areas\Identity\Views\Account\Login.cshtml"
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/Identity/Views/Account/Login.cshtml")]
    public partial class _Areas_Identity_Views_Account_Login_cshtml : System.Web.Mvc.WebViewPage<cutecms_porto.Areas.Identity.Models.LoginViewModel>
    {
        public _Areas_Identity_Views_Account_Login_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Areas\Identity\Views\Account\Login.cshtml"
  
    ViewBag.Title = Resources.Resources.LogIn;
    ViewBag.MainTitle = Resources.Resources.LoginToSite;
    ViewBag.SubTitle = Resources.Resources.EnterCredentials;
    ViewBag.IconTitle = "fa fa-lock";
    Layout = "~/Areas/Identity/Views/Shared/_Layout.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 10 "..\..\Areas\Identity\Views\Account\Login.cshtml"
 using (Html.BeginForm("Login", "Account", new { ReturnUrl = ViewBag.ReturnUrl }, FormMethod.Post, new { @class = "form-horizontal", role = "form" }))
{
    
            
            #line default
            #line hidden
            
            #line 12 "..\..\Areas\Identity\Views\Account\Login.cshtml"
Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 12 "..\..\Areas\Identity\Views\Account\Login.cshtml"
                            

            
            #line default
            #line hidden
WriteLiteral("    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 15 "..\..\Areas\Identity\Views\Account\Login.cshtml"
       Write(Html.TextBoxFor(m => m.Email, new { @class = "form-control", @placeholder = Resources.Resources.Email + "..." }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n    </div>\r\n");

WriteLiteral("    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 20 "..\..\Areas\Identity\Views\Account\Login.cshtml"
       Write(Html.PasswordFor(m => m.Password, new { @class = "form-control", @placeholder = Resources.Resources.Password + "..." }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n    </div>\r\n");

WriteLiteral("    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" style=\"color:#fff\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 26 "..\..\Areas\Identity\Views\Account\Login.cshtml"
           Write(Html.CheckBoxFor(m => m.RememberMe));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 27 "..\..\Areas\Identity\Views\Account\Login.cshtml"
           Write(Html.LabelFor(m => m.RememberMe));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n");

WriteLiteral("    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n            <input");

WriteLiteral(" type=\"submit\"");

WriteAttribute("value", Tuple.Create(" value=\'", 1337), Tuple.Create("\'", 1371)
            
            #line 33 "..\..\Areas\Identity\Views\Account\Login.cshtml"
, Tuple.Create(Tuple.Create("", 1345), Tuple.Create<System.Object, System.Int32>(Resources.Resources.LogIn
            
            #line default
            #line hidden
, 1345), false)
);

WriteLiteral(" class=\"btn btn-primary\"");

WriteLiteral("/>\r\n        </div>\r\n    </div>\r\n");

WriteLiteral("    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n            <div>\r\n");

WriteLiteral("                ");

            
            #line 39 "..\..\Areas\Identity\Views\Account\Login.cshtml"
           Write(Html.ActionLink(Resources.Resources.ForgetPassword, "ForgotPassword"));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n");

WriteLiteral("    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n            <div>\r\n");

WriteLiteral("                ");

            
            #line 46 "..\..\Areas\Identity\Views\Account\Login.cshtml"
           Write(Html.ActionLink(Resources.Resources.RegisterNewUser, "Register"));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n");

WriteLiteral("    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 52 "..\..\Areas\Identity\Views\Account\Login.cshtml"
       Write(Html.ValidationSummary(false, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n    </div>\r\n");

            
            #line 55 "..\..\Areas\Identity\Views\Account\Login.cshtml"
}

            
            #line default
            #line hidden
DefineSection("Scripts", () => {

WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 57 "..\..\Areas\Identity\Views\Account\Login.cshtml"
Write(Scripts.Render("~/bundles/jqueryval"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

});

        }
    }
}
#pragma warning restore 1591
