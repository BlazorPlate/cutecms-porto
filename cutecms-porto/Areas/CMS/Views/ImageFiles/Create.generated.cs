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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/CMS/Views/ImageFiles/Create.cshtml")]
    public partial class _Areas_CMS_Views_ImageFiles_Create_cshtml : System.Web.Mvc.WebViewPage<cutecms_porto.Areas.CMS.Models.CreateImageWithTagsViewModel>
    {
        public _Areas_CMS_Views_ImageFiles_Create_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Areas\CMS\Views\ImageFiles\Create.cshtml"
  
    ViewBag.MainTitle = Resources.Resources.Image;
    ViewBag.Title = Resources.Resources.Create;

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 6 "..\..\Areas\CMS\Views\ImageFiles\Create.cshtml"
 using (Html.BeginForm("Create", "ImageFiles", FormMethod.Post, new { enctype = "multipart/form-data" }))
{
    
            
            #line default
            #line hidden
            
            #line 8 "..\..\Areas\CMS\Views\ImageFiles\Create.cshtml"
Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 8 "..\..\Areas\CMS\Views\ImageFiles\Create.cshtml"
                            

            
            #line default
            #line hidden
WriteLiteral("    <div");

WriteLiteral(" class=\"form-horizontal\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 11 "..\..\Areas\CMS\Views\ImageFiles\Create.cshtml"
       Write(Html.LabelFor(model => model.GalleryId, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 13 "..\..\Areas\CMS\Views\ImageFiles\Create.cshtml"
           Write(Html.DropDownList("GalleryId", null, Resources.Resources.ChooseGallery, htmlAttributes: new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 14 "..\..\Areas\CMS\Views\ImageFiles\Create.cshtml"
           Write(Html.ValidationMessageFor(model => model.GalleryId, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 18 "..\..\Areas\CMS\Views\ImageFiles\Create.cshtml"
       Write(Html.LabelFor(model => model.ImageFile.Code, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 20 "..\..\Areas\CMS\Views\ImageFiles\Create.cshtml"
           Write(Html.EditorFor(model => model.ImageFile.Code, new { htmlAttributes = new { @class = "form-control" } }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 21 "..\..\Areas\CMS\Views\ImageFiles\Create.cshtml"
           Write(Html.ValidationMessageFor(model => model.ImageFile.Code, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 25 "..\..\Areas\CMS\Views\ImageFiles\Create.cshtml"
       Write(Html.LabelFor(model => model.ImageFile.Ordinal, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 27 "..\..\Areas\CMS\Views\ImageFiles\Create.cshtml"
           Write(Html.EditorFor(model => model.ImageFile.Ordinal, new { htmlAttributes = new { @class = "form-control" } }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 28 "..\..\Areas\CMS\Views\ImageFiles\Create.cshtml"
           Write(Html.ValidationMessageFor(model => model.ImageFile.Ordinal, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 32 "..\..\Areas\CMS\Views\ImageFiles\Create.cshtml"
       Write(Html.LabelFor(model => model.ImageFiles, new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-sm-5\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 34 "..\..\Areas\CMS\Views\ImageFiles\Create.cshtml"
           Write(Html.TextBoxFor(model => model.ImageFiles, new { type = "file", multiple = "multiple" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 35 "..\..\Areas\CMS\Views\ImageFiles\Create.cshtml"
           Write(Html.ValidationMessageFor(model => model.ImageFile));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 39 "..\..\Areas\CMS\Views\ImageFiles\Create.cshtml"
       Write(Html.Label(Resources.Resources.Dimensions, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 41 "..\..\Areas\CMS\Views\ImageFiles\Create.cshtml"
           Write(Html.TextBox("width", null, new { @placeholder = @Resources.Resources.Width }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 42 "..\..\Areas\CMS\Views\ImageFiles\Create.cshtml"
           Write(Html.TextBox("height", null, new { @placeholder = @Resources.Resources.Height }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 46 "..\..\Areas\CMS\Views\ImageFiles\Create.cshtml"
       Write(Html.LabelFor(model => model.Tags, new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-sm-5\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 48 "..\..\Areas\CMS\Views\ImageFiles\Create.cshtml"
           Write(Html.EditorFor(model => model.Tags, new { htmlAttributes = new { @class = "form-control" } }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"col-md-offset-2 col-md-10\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" type=\"submit\"");

WriteAttribute("value", Tuple.Create(" value=", 2974), Tuple.Create("", 3008)
            
            #line 53 "..\..\Areas\CMS\Views\ImageFiles\Create.cshtml"
, Tuple.Create(Tuple.Create("", 2981), Tuple.Create<System.Object, System.Int32>(Resources.Resources.Create
            
            #line default
            #line hidden
, 2981), false)
);

WriteLiteral(" class=\"btn btn-primary\"");

WriteLiteral("/>\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"col-md-offset-2 col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 58 "..\..\Areas\CMS\Views\ImageFiles\Create.cshtml"
           Write(Html.ValidationSummary(false, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n");

            
            #line 62 "..\..\Areas\CMS\Views\ImageFiles\Create.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("<div>\r\n");

WriteLiteral("    ");

            
            #line 64 "..\..\Areas\CMS\Views\ImageFiles\Create.cshtml"
Write(Html.ActionLink(Resources.Resources.BackToList, "Index"));

            
            #line default
            #line hidden
WriteLiteral("\r\n</div>\r\n");

DefineSection("Scripts", () => {

WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 67 "..\..\Areas\CMS\Views\ImageFiles\Create.cshtml"
Write(Scripts.Render("~/bundles/jqueryval"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

});

        }
    }
}
#pragma warning restore 1591