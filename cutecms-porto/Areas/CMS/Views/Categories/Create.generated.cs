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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/CMS/Views/Categories/Create.cshtml")]
    public partial class _Areas_CMS_Views_Categories_Create_cshtml : System.Web.Mvc.WebViewPage<cutecms_porto.Areas.CMS.Models.DBModel.Category>
    {
        public _Areas_CMS_Views_Categories_Create_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Areas\CMS\Views\Categories\Create.cshtml"
  
    ViewBag.MainTitle = Resources.Resources.Category;
    ViewBag.Title = Resources.Resources.Create;

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

            
            #line 8 "..\..\Areas\CMS\Views\Categories\Create.cshtml"
 using (Html.BeginForm()) 
{
    
            
            #line default
            #line hidden
            
            #line 10 "..\..\Areas\CMS\Views\Categories\Create.cshtml"
Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 10 "..\..\Areas\CMS\Views\Categories\Create.cshtml"
                                

            
            #line default
            #line hidden
WriteLiteral("    <div");

WriteLiteral(" class=\"form-horizontal\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 12 "..\..\Areas\CMS\Views\Categories\Create.cshtml"
   Write(Html.ValidationSummary(true, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 15 "..\..\Areas\CMS\Views\Categories\Create.cshtml"
       Write(Html.LabelFor(model => model.Code, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 17 "..\..\Areas\CMS\Views\Categories\Create.cshtml"
           Write(Html.EditorFor(model => model.Code, new { htmlAttributes = new { @class = "form-control" } }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 18 "..\..\Areas\CMS\Views\Categories\Create.cshtml"
           Write(Html.ValidationMessageFor(model => model.Code, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 23 "..\..\Areas\CMS\Views\Categories\Create.cshtml"
       Write(Html.LabelFor(model => model.Visible, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"checkbox\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 26 "..\..\Areas\CMS\Views\Categories\Create.cshtml"
               Write(Html.CheckBoxFor(model => model.Visible, new { @class = "js-switch" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                    ");

            
            #line 27 "..\..\Areas\CMS\Views\Categories\Create.cshtml"
               Write(Html.ValidationMessageFor(model => model.Visible, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 33 "..\..\Areas\CMS\Views\Categories\Create.cshtml"
       Write(Html.LabelFor(model => model.Ordinal, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 35 "..\..\Areas\CMS\Views\Categories\Create.cshtml"
           Write(Html.EditorFor(model => model.Ordinal, new { htmlAttributes = new { @class = "form-control" } }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 36 "..\..\Areas\CMS\Views\Categories\Create.cshtml"
           Write(Html.ValidationMessageFor(model => model.Ordinal, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"col-md-offset-2 col-md-10\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" type=\"submit\"");

WriteAttribute("value", Tuple.Create(" value=", 1825), Tuple.Create("", 1857)
            
            #line 42 "..\..\Areas\CMS\Views\Categories\Create.cshtml"
, Tuple.Create(Tuple.Create("", 1832), Tuple.Create<System.Object, System.Int32>(Resources.Resources.Save
            
            #line default
            #line hidden
, 1832), false)
);

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" />\r\n            </div>\r\n        </div>\r\n    </div>\r\n");

            
            #line 46 "..\..\Areas\CMS\Views\Categories\Create.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("\r\n<div>\r\n");

WriteLiteral("    ");

            
            #line 49 "..\..\Areas\CMS\Views\Categories\Create.cshtml"
Write(Html.ActionLink(Resources.Resources.BackToList, "Index", new { id = ViewBag.CategoryId }));

            
            #line default
            #line hidden
WriteLiteral("\r\n</div>\r\n");

DefineSection("Scripts", () => {

WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 52 "..\..\Areas\CMS\Views\Categories\Create.cshtml"
Write(Scripts.Render("~/bundles/jqueryval"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

});

        }
    }
}
#pragma warning restore 1591