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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/Identity/Views/Account/ResetPasswordConfirmation.cshtml")]
    public partial class _Areas_Identity_Views_Account_ResetPasswordConfirmation_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_Identity_Views_Account_ResetPasswordConfirmation_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Areas\Identity\Views\Account\ResetPasswordConfirmation.cshtml"
  
    ViewBag.Title = Resources.Resources.ResetPasswordConfirmation;
    ViewBag.MainTitle = Resources.Resources.ResetPasswordConfirmation;
    ViewBag.IconTitle = "fa fa-key";
    Layout = "~/Areas/Identity/Views/Shared/_Layout.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n<div>\r\n    <p>\r\n");

WriteLiteral("        ");

            
            #line 9 "..\..\Areas\Identity\Views\Account\ResetPasswordConfirmation.cshtml"
   Write(Resources.Resources.PasswordReset);

            
            #line default
            #line hidden
WriteLiteral(" ");

            
            #line 9 "..\..\Areas\Identity\Views\Account\ResetPasswordConfirmation.cshtml"
                                      Write(Resources.Resources.Please);

            
            #line default
            #line hidden
WriteLiteral(" ");

            
            #line 9 "..\..\Areas\Identity\Views\Account\ResetPasswordConfirmation.cshtml"
                                                                  Write(Html.ActionLink(@Resources.Resources.ClickLogin, "Login", "Account", routeValues: null, htmlAttributes: new { id = "loginLink" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n    </p>\r\n</div>");

        }
    }
}
#pragma warning restore 1591