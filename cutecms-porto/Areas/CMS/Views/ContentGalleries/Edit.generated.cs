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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/CMS/Views/ContentGalleries/Edit.cshtml")]
    public partial class _Areas_CMS_Views_ContentGalleries_Edit_cshtml : System.Web.Mvc.WebViewPage<cutecms_porto.Areas.CMS.Models.DBModel.ContentGallery>
    {
        public _Areas_CMS_Views_ContentGalleries_Edit_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Areas\CMS\Views\ContentGalleries\Edit.cshtml"
  
    ViewBag.MainTitle = Resources.Resources.Gallery;
    ViewBag.Title = Resources.Resources.Edit;

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 6 "..\..\Areas\CMS\Views\ContentGalleries\Edit.cshtml"
 using (Html.BeginForm())
{
    
            
            #line default
            #line hidden
            
            #line 8 "..\..\Areas\CMS\Views\ContentGalleries\Edit.cshtml"
Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 8 "..\..\Areas\CMS\Views\ContentGalleries\Edit.cshtml"
                            

            
            #line default
            #line hidden
WriteLiteral("    <div");

WriteLiteral(" class=\"form-horizontal\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 10 "..\..\Areas\CMS\Views\ContentGalleries\Edit.cshtml"
   Write(Html.HiddenFor(model => model.Id));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("        ");

            
            #line 11 "..\..\Areas\CMS\Views\ContentGalleries\Edit.cshtml"
   Write(Html.HiddenFor(model => model.ContentId));

            
            #line default
            #line hidden
WriteLiteral("\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 13 "..\..\Areas\CMS\Views\ContentGalleries\Edit.cshtml"
       Write(Html.LabelFor(model => model.Content.Title, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 15 "..\..\Areas\CMS\Views\ContentGalleries\Edit.cshtml"
           Write(Html.TextBox("ContentTitle",null, new { @disabled = "disabled", @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 19 "..\..\Areas\CMS\Views\ContentGalleries\Edit.cshtml"
       Write(Html.LabelFor(model => model.GalleryId, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 21 "..\..\Areas\CMS\Views\ContentGalleries\Edit.cshtml"
           Write(Html.DropDownList("GalleryId", null, string.Empty, htmlAttributes: new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 22 "..\..\Areas\CMS\Views\ContentGalleries\Edit.cshtml"
           Write(Html.ValidationMessageFor(model => model.GalleryId, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 26 "..\..\Areas\CMS\Views\ContentGalleries\Edit.cshtml"
       Write(Html.LabelFor(model => model.Ordinal, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 28 "..\..\Areas\CMS\Views\ContentGalleries\Edit.cshtml"
           Write(Html.EditorFor(model => model.Ordinal, new { htmlAttributes = new { @class = "form-control" } }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 29 "..\..\Areas\CMS\Views\ContentGalleries\Edit.cshtml"
           Write(Html.ValidationMessageFor(model => model.Ordinal, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"col-md-offset-2 col-md-10\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" type=\"submit\"");

WriteAttribute("value", Tuple.Create(" value=\"", 1697), Tuple.Create("\"", 1730)
            
            #line 34 "..\..\Areas\CMS\Views\ContentGalleries\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 1705), Tuple.Create<System.Object, System.Int32>(Resources.Resources.Save
            
            #line default
            #line hidden
, 1705), false)
);

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" />\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"col-md-offset-2 col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 39 "..\..\Areas\CMS\Views\ContentGalleries\Edit.cshtml"
           Write(Html.ValidationSummary(false, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n");

            
            #line 43 "..\..\Areas\CMS\Views\ContentGalleries\Edit.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("<div>\r\n");

WriteLiteral("    ");

            
            #line 45 "..\..\Areas\CMS\Views\ContentGalleries\Edit.cshtml"
Write(Html.ActionLink(Resources.Resources.BackToList, "Index", new { id = Model.ContentId }));

            
            #line default
            #line hidden
WriteLiteral("\r\n</div>\r\n");

DefineSection("Scripts", () => {

WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 48 "..\..\Areas\CMS\Views\ContentGalleries\Edit.cshtml"
Write(Scripts.Render("~/bundles/jqueryval"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

});

        }
    }
}
#pragma warning restore 1591
