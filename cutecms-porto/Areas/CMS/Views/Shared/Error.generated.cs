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
    
    #line 1 "..\..\Areas\CMS\Views\Shared\Error.cshtml"
    using System.Diagnostics;
    
    #line default
    #line hidden
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/CMS/Views/Shared/Error.cshtml")]
    public partial class _Areas_CMS_Views_Shared_Error_cshtml : System.Web.Mvc.WebViewPage<System.Web.Mvc.HandleErrorInfo>
    {
        public _Areas_CMS_Views_Shared_Error_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Areas\CMS\Views\Shared\Error.cshtml"
  
    ViewBag.Title = "Error";
    var message = string.Format("Error in Controller ({0}), Action Method ({1}). Exception: {2}",
    Model.ControllerName, Model.ActionName, Model.Exception.InnerException.InnerException.Message);
    ViewBag.Error = message;

            
            #line default
            #line hidden
WriteLiteral("\r\n<h1");

WriteLiteral(" class=\"text-danger\"");

WriteLiteral(">Error.</h1>\r\n<h5");

WriteLiteral(" class=\"text-danger\"");

WriteLiteral(">");

            
            #line 10 "..\..\Areas\CMS\Views\Shared\Error.cshtml"
                   Write(ViewBag.Error);

            
            #line default
            #line hidden
WriteLiteral("</h5>");

        }
    }
}
#pragma warning restore 1591
