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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/Identity/Views/IdentityDepartmentTerms/Create.cshtml")]
    public partial class _Areas_Identity_Views_IdentityDepartmentTerms_Create_cshtml : System.Web.Mvc.WebViewPage<cutecms_porto.Areas.Identity.Models.DBModel.IdentityDepartmentTerm>
    {
        public _Areas_Identity_Views_IdentityDepartmentTerms_Create_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Areas\Identity\Views\IdentityDepartmentTerms\Create.cshtml"
  
    ViewBag.MainTitle = Resources.Resources.Term;
    ViewBag.Title = Resources.Resources.Create;

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 6 "..\..\Areas\Identity\Views\IdentityDepartmentTerms\Create.cshtml"
 using (Html.BeginForm("Create", "IdentityDepartmentTerms", FormMethod.Post, new { enctype = "multipart/form-data" }))
{
    
            
            #line default
            #line hidden
            
            #line 8 "..\..\Areas\Identity\Views\IdentityDepartmentTerms\Create.cshtml"
Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 8 "..\..\Areas\Identity\Views\IdentityDepartmentTerms\Create.cshtml"
                            
    
            
            #line default
            #line hidden
            
            #line 9 "..\..\Areas\Identity\Views\IdentityDepartmentTerms\Create.cshtml"
Write(Html.Hidden("DepartmentId"));

            
            #line default
            #line hidden
            
            #line 9 "..\..\Areas\Identity\Views\IdentityDepartmentTerms\Create.cshtml"
                                

            
            #line default
            #line hidden
WriteLiteral("    <div");

WriteLiteral(" class=\"form-horizontal\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 12 "..\..\Areas\Identity\Views\IdentityDepartmentTerms\Create.cshtml"
       Write(Html.LabelFor(model => model.DepartmentId, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 14 "..\..\Areas\Identity\Views\IdentityDepartmentTerms\Create.cshtml"
           Write(Html.TextBox("DepartmentCode", null, htmlAttributes: new { @class = "form-control", @disabled = "disabled" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 15 "..\..\Areas\Identity\Views\IdentityDepartmentTerms\Create.cshtml"
           Write(Html.ValidationMessageFor(model => model.DepartmentId, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 19 "..\..\Areas\Identity\Views\IdentityDepartmentTerms\Create.cshtml"
       Write(Html.LabelFor(model => model.LanguageId, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 21 "..\..\Areas\Identity\Views\IdentityDepartmentTerms\Create.cshtml"
           Write(Html.DropDownList("LanguageId", null, Resources.Resources.ChooseLanguage, htmlAttributes: new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 22 "..\..\Areas\Identity\Views\IdentityDepartmentTerms\Create.cshtml"
           Write(Html.ValidationMessageFor(model => model.LanguageId, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 26 "..\..\Areas\Identity\Views\IdentityDepartmentTerms\Create.cshtml"
       Write(Html.LabelFor(model => model.Value, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 28 "..\..\Areas\Identity\Views\IdentityDepartmentTerms\Create.cshtml"
           Write(Html.EditorFor(model => model.Value, new { htmlAttributes = new { @class = "form-control" } }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 29 "..\..\Areas\Identity\Views\IdentityDepartmentTerms\Create.cshtml"
           Write(Html.ValidationMessageFor(model => model.Value, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 33 "..\..\Areas\Identity\Views\IdentityDepartmentTerms\Create.cshtml"
       Write(Html.Label(Resources.Resources.UploadIcon, new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 35 "..\..\Areas\Identity\Views\IdentityDepartmentTerms\Create.cshtml"
           Write(Html.TextBoxFor(model => model.Icon, new { @class = "form-control", type = "file", multiple = "false", placeholder = "upload files" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                <small");

WriteLiteral(" class=\"text-muted block\"");

WriteLiteral(">");

            
            #line 36 "..\..\Areas\Identity\Views\IdentityDepartmentTerms\Create.cshtml"
                                           Write(Resources.Resources.ImageNotes);

            
            #line default
            #line hidden
WriteLiteral("</small>\r\n            </div>\r\n        </div>\r\n\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 41 "..\..\Areas\Identity\Views\IdentityDepartmentTerms\Create.cshtml"
       Write(Html.LabelFor(model => model.Summary, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 43 "..\..\Areas\Identity\Views\IdentityDepartmentTerms\Create.cshtml"
           Write(Html.TextAreaFor(model => model.Summary, new { htmlAttributes = new { @class = "form-control" } }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 44 "..\..\Areas\Identity\Views\IdentityDepartmentTerms\Create.cshtml"
           Write(Html.ValidationMessageFor(model => model.Summary, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 49 "..\..\Areas\Identity\Views\IdentityDepartmentTerms\Create.cshtml"
       Write(Html.LabelFor(model => model.Description, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 51 "..\..\Areas\Identity\Views\IdentityDepartmentTerms\Create.cshtml"
           Write(Html.TextAreaFor(model => model.Description, new { @class = "mceEditor" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 52 "..\..\Areas\Identity\Views\IdentityDepartmentTerms\Create.cshtml"
           Write(Html.ValidationMessageFor(model => model.Description, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 57 "..\..\Areas\Identity\Views\IdentityDepartmentTerms\Create.cshtml"
       Write(Html.Label(Resources.Resources.UploadImage, new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 59 "..\..\Areas\Identity\Views\IdentityDepartmentTerms\Create.cshtml"
           Write(Html.TextBoxFor(model => model.Image, new { @class = "form-control", type = "file", multiple = "false", placeholder = "upload files" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                <small");

WriteLiteral(" class=\"text-muted block\"");

WriteLiteral(">");

            
            #line 60 "..\..\Areas\Identity\Views\IdentityDepartmentTerms\Create.cshtml"
                                           Write(Resources.Resources.ImageNotes);

            
            #line default
            #line hidden
WriteLiteral("</small>\r\n            </div>\r\n        </div>\r\n\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 65 "..\..\Areas\Identity\Views\IdentityDepartmentTerms\Create.cshtml"
       Write(Html.LabelFor(model => model.HomeVisible, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"checkbox\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 68 "..\..\Areas\Identity\Views\IdentityDepartmentTerms\Create.cshtml"
               Write(Html.CheckBoxFor(model => model.HomeVisible, new { @class = "js-switch" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                    ");

            
            #line 69 "..\..\Areas\Identity\Views\IdentityDepartmentTerms\Create.cshtml"
               Write(Html.ValidationMessageFor(model => model.HomeVisible, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" id=\"OrdinalDiv\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 75 "..\..\Areas\Identity\Views\IdentityDepartmentTerms\Create.cshtml"
           Write(Html.LabelFor(model => model.Ordinal, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"checkbox\"");

WriteLiteral(">\r\n");

WriteLiteral("                        ");

            
            #line 78 "..\..\Areas\Identity\Views\IdentityDepartmentTerms\Create.cshtml"
                   Write(Html.EditorFor(model => model.Ordinal, new { htmlAttributes = new { @class = "form-control" } }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                        ");

            
            #line 79 "..\..\Areas\Identity\Views\IdentityDepartmentTerms\Create.cshtml"
                   Write(Html.ValidationMessageFor(model => model.Ordinal, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </div>\r\n                </div>\r\n            </div>\r\n       " +
" </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"col-md-offset-2 col-md-10\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" type=\"submit\"");

WriteAttribute("value", Tuple.Create(" value=", 4744), Tuple.Create("", 4778)
            
            #line 86 "..\..\Areas\Identity\Views\IdentityDepartmentTerms\Create.cshtml"
, Tuple.Create(Tuple.Create("", 4751), Tuple.Create<System.Object, System.Int32>(Resources.Resources.Create
            
            #line default
            #line hidden
, 4751), false)
);

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" />\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"col-md-offset-2 col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 91 "..\..\Areas\Identity\Views\IdentityDepartmentTerms\Create.cshtml"
           Write(Html.ValidationSummary(false, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n");

            
            #line 95 "..\..\Areas\Identity\Views\IdentityDepartmentTerms\Create.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("<div>\r\n");

WriteLiteral("    ");

            
            #line 97 "..\..\Areas\Identity\Views\IdentityDepartmentTerms\Create.cshtml"
Write(Html.ActionLink(Resources.Resources.BackToList, "Index", new { id = ViewBag.DepartmentId }));

            
            #line default
            #line hidden
WriteLiteral("\r\n</div>\r\n");

DefineSection("Scripts", () => {

WriteLiteral("\r\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(@">
        $(document).ready(function () {
            //Uncheck the CheckBox initially
            $('#HomeVisible').removeAttr('checked');
            $(""#OrdinalDiv"").hide();
            $('#HomeVisible').change(function () {
                if (this.checked) {
                    $('#OrdinalDiv').show();
                }
                else {
                    $(""#OrdinalDiv"").hide()
                    $(""#Ordinal"").val(null);
                }
            });
        });
    </script>
");

});

        }
    }
}
#pragma warning restore 1591
