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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/Identity/Views/Roles/Delete.cshtml")]
    public partial class _Areas_Identity_Views_Roles_Delete_cshtml : System.Web.Mvc.WebViewPage<cutecms_porto.Areas.Identity.Models.RoleViewModel>
    {
        public _Areas_Identity_Views_Roles_Delete_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Areas\Identity\Views\Roles\Delete.cshtml"
  
    ViewBag.MainTitle = Resources.Resources.Role;
    ViewBag.Title = Resources.Resources.Delete;

            
            #line default
            #line hidden
WriteLiteral("\r\n<h3>");

            
            #line 6 "..\..\Areas\Identity\Views\Roles\Delete.cshtml"
Write(Resources.Resources.DeleteConfirmation);

            
            #line default
            #line hidden
WriteLiteral("</h3>\r\n<div>\r\n    <dl");

WriteLiteral(" class=\"dl-horizontal\"");

WriteLiteral(">\r\n        <dt>\r\n");

WriteLiteral("            ");

            
            #line 10 "..\..\Areas\Identity\Views\Roles\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.RoleName));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n");

WriteLiteral("            ");

            
            #line 13 "..\..\Areas\Identity\Views\Roles\Delete.cshtml"
       Write(Html.DisplayFor(model => model.RoleName));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n");

WriteLiteral("            ");

            
            #line 16 "..\..\Areas\Identity\Views\Roles\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Description));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n");

WriteLiteral("            ");

            
            #line 19 "..\..\Areas\Identity\Views\Roles\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Description));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n");

            
            #line 22 "..\..\Areas\Identity\Views\Roles\Delete.cshtml"
    
            
            #line default
            #line hidden
            
            #line 22 "..\..\Areas\Identity\Views\Roles\Delete.cshtml"
     using (Html.BeginForm())
    {
        
            
            #line default
            #line hidden
            
            #line 24 "..\..\Areas\Identity\Views\Roles\Delete.cshtml"
   Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 24 "..\..\Areas\Identity\Views\Roles\Delete.cshtml"
                                

            
            #line default
            #line hidden
WriteLiteral("        <div");

WriteLiteral(" class=\"form-actions no-color\"");

WriteLiteral(">\r\n            <input");

WriteLiteral(" type=\"submit\"");

WriteAttribute("value", Tuple.Create(" value=", 764), Tuple.Create("", 798)
            
            #line 26 "..\..\Areas\Identity\Views\Roles\Delete.cshtml"
, Tuple.Create(Tuple.Create("", 771), Tuple.Create<System.Object, System.Int32>(Resources.Resources.Delete
            
            #line default
            #line hidden
, 771), false)
);

WriteLiteral(" class=\"btn btn-primary\"");

WriteLiteral(" /> |\r\n");

WriteLiteral("            ");

            
            #line 27 "..\..\Areas\Identity\Views\Roles\Delete.cshtml"
       Write(Html.ActionLink(Resources.Resources.BackToList, "Index"));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n");

            
            #line 29 "..\..\Areas\Identity\Views\Roles\Delete.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("</div>");

        }
    }
}
#pragma warning restore 1591