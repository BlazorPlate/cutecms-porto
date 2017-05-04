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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/Identity/Views/Employees/Edit.cshtml")]
    public partial class _Areas_Identity_Views_Employees_Edit_cshtml : System.Web.Mvc.WebViewPage<cutecms_porto.Areas.Identity.Models.DBModel.Employee>
    {
        public _Areas_Identity_Views_Employees_Edit_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
  
    ViewBag.MainTitle = Resources.Resources.Employee;
    ViewBag.Title = Resources.Resources.Edit;

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 6 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
 using (Html.BeginForm("Edit", "Employees", FormMethod.Post, new { enctype = "multipart/form-data" }))
{
    
            
            #line default
            #line hidden
            
            #line 8 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 8 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
                            
    
            
            #line default
            #line hidden
            
            #line 9 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
Write(Html.HiddenFor(model => model.Id));

            
            #line default
            #line hidden
            
            #line 9 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
                                      
    
            
            #line default
            #line hidden
            
            #line 10 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
Write(Html.HiddenFor(model => model.ResumeFilePath));

            
            #line default
            #line hidden
            
            #line 10 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
                                                  
    
            
            #line default
            #line hidden
            
            #line 11 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
Write(Html.HiddenFor(model => model.PersonalPhotoPath));

            
            #line default
            #line hidden
            
            #line 11 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
                                                     
    
            
            #line default
            #line hidden
            
            #line 12 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
Write(Html.HiddenFor(model => model.ResumeFileName));

            
            #line default
            #line hidden
            
            #line 12 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
                                                  
    
            
            #line default
            #line hidden
            
            #line 13 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
Write(Html.HiddenFor(model => model.PersonalPhotoName));

            
            #line default
            #line hidden
            
            #line 13 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
                                                     
    
            
            #line default
            #line hidden
            
            #line 14 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
Write(Html.HiddenFor(model => model.TranslationId));

            
            #line default
            #line hidden
            
            #line 14 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
                                                 

            
            #line default
            #line hidden
WriteLiteral("    <div");

WriteLiteral(" class=\"form-horizontal\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 17 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
       Write(Html.LabelFor(model => model.LanguageId, new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 19 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
           Write(Html.DropDownList("LanguageId", null, Resources.Resources.ChooseLanguage, htmlAttributes: new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 20 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
           Write(Html.ValidationMessageFor(model => model.LanguageId, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 24 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
       Write(Html.LabelFor(model => model.LoginId, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 26 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
           Write(Html.DropDownList("LoginId", null, string.Empty, htmlAttributes: new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 27 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
           Write(Html.ValidationMessageFor(model => model.LoginId, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n");

            
            #line 30 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
        
            
            #line default
            #line hidden
            
            #line 30 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
         if (Model.PersonalPhotoPath != null)
        {

            
            #line default
            #line hidden
WriteLiteral("            <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 33 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
           Write(Html.LabelFor(model => model.PersonalPhotoPath, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n                    <img");

WriteAttribute("src", Tuple.Create(" src=\"", 1824), Tuple.Create("\"", 1854)
            
            #line 35 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 1830), Tuple.Create<System.Object, System.Int32>(Model.PersonalPhotoPath
            
            #line default
            #line hidden
, 1830), false)
);

WriteAttribute("alt", Tuple.Create(" alt=\"", 1855), Tuple.Create("\"", 1885)
            
            #line 35 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 1861), Tuple.Create<System.Object, System.Int32>(Model.PersonalPhotoName
            
            #line default
            #line hidden
, 1861), false)
);

WriteLiteral("/>\r\n                </div>\r\n            </div>\r\n");

            
            #line 38 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 40 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
       Write(Html.Label(Resources.Resources.UploadPersonalPhoto, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 42 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
           Write(Html.TextBoxFor(model => model.Image, new { @class = "form-control", type = "file", multiple = "false", placeholder = "upload files" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                <small");

WriteLiteral(" class=\"text-muted block\"");

WriteLiteral(">");

            
            #line 43 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
                                           Write(Resources.Resources.ImageNotes);

            
            #line default
            #line hidden
WriteLiteral("</small><br />\r\n");

WriteLiteral("                ");

            
            #line 44 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
           Write(Html.ValidationMessageFor(model => model.Image, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n              </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 48 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
       Write(Html.LabelFor(model => model.PersonalTitleId, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 50 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
           Write(Html.DropDownList("PersonalTitleId", null, string.Empty, htmlAttributes: new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 51 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
           Write(Html.ValidationMessageFor(model => model.PersonalTitleId, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 55 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
       Write(Html.LabelFor(model => model.FirstName, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 57 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
           Write(Html.EditorFor(model => model.FirstName, new { htmlAttributes = new { @class = "form-control" } }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 58 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
           Write(Html.ValidationMessageFor(model => model.FirstName, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 62 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
       Write(Html.LabelFor(model => model.MiddleName, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 64 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
           Write(Html.EditorFor(model => model.MiddleName, new { htmlAttributes = new { @class = "form-control" } }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 65 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
           Write(Html.ValidationMessageFor(model => model.MiddleName, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 69 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
       Write(Html.LabelFor(model => model.LastName, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 71 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
           Write(Html.EditorFor(model => model.LastName, new { htmlAttributes = new { @class = "form-control" } }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 72 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
           Write(Html.ValidationMessageFor(model => model.LastName, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 76 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
       Write(Html.LabelFor(model => model.Biography, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 78 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
           Write(Html.TextAreaFor(model => model.Biography, new { @class = "mceEditor" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 79 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
           Write(Html.ValidationMessageFor(model => model.Biography, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n");

            
            #line 82 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
        
            
            #line default
            #line hidden
            
            #line 82 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
         if (Model.ResumeFilePath != null)
        {

            
            #line default
            #line hidden
WriteLiteral("            <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 85 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
           Write(Html.Label(Resources.Resources.ViewCV, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n                    <a");

WriteAttribute("href", Tuple.Create(" href=\"", 5010), Tuple.Create("\"", 5051)
            
            #line 87 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 5017), Tuple.Create<System.Object, System.Int32>(Url.Content(Model.ResumeFilePath)
            
            #line default
            #line hidden
, 5017), false)
);

WriteLiteral(">");

            
            #line 87 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
                                                            Write(Resources.Resources.Download);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n");

WriteLiteral("                    ");

            
            #line 88 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
               Write(Html.ValidationMessageFor(model => model.ResumeFilePath, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n            </div>\r\n");

            
            #line 91 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 93 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
       Write(Html.LabelFor(model => model.CV, new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 95 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
           Write(Html.TextBoxFor(model => model.CV, new { @class = "form-control", type = "file", multiple = "false", placeholder = "upload files" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 96 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
           Write(Html.ValidationMessageFor(model => model.CV, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                <small");

WriteLiteral(" class=\"text-muted block\"");

WriteLiteral(">");

            
            #line 97 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
                                           Write(Resources.Resources.CVNotes);

            
            #line default
            #line hidden
WriteLiteral("</small>\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 101 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
       Write(Html.LabelFor(model => model.RankId, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 103 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
           Write(Html.DropDownList("RankId", null, string.Empty, htmlAttributes: new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 104 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
           Write(Html.ValidationMessageFor(model => model.RankId, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 108 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
       Write(Html.LabelFor(model => model.DegreeId, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 110 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
           Write(Html.DropDownList("DegreeId", null, string.Empty, htmlAttributes: new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 111 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
           Write(Html.ValidationMessageFor(model => model.DegreeId, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 115 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
       Write(Html.LabelFor(model => model.ProgramId, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 117 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
           Write(Html.DropDownList("ProgramId", null, string.Empty, htmlAttributes: new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 118 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
           Write(Html.ValidationMessageFor(model => model.ProgramId, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 122 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
       Write(Html.LabelFor(model => model.OfficeNumber, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 124 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
           Write(Html.EditorFor(model => model.OfficeNumber, new { htmlAttributes = new { @class = "form-control" } }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 125 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
           Write(Html.ValidationMessageFor(model => model.OfficeNumber, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 129 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
       Write(Html.LabelFor(model => model.Mobile, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 131 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
           Write(Html.EditorFor(model => model.Mobile, new { htmlAttributes = new { @class = "form-control" } }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 132 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
           Write(Html.ValidationMessageFor(model => model.Mobile, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 136 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
       Write(Html.LabelFor(model => model.LandLine, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 138 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
           Write(Html.EditorFor(model => model.LandLine, new { htmlAttributes = new { @class = "form-control" } }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 139 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
           Write(Html.ValidationMessageFor(model => model.LandLine, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 143 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
       Write(Html.LabelFor(model => model.Extension, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 145 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
           Write(Html.EditorFor(model => model.Extension, new { htmlAttributes = new { @class = "form-control" } }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 146 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
           Write(Html.ValidationMessageFor(model => model.Extension, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 150 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
       Write(Html.LabelFor(model => model.FacebookUrl, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 152 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
           Write(Html.EditorFor(model => model.FacebookUrl, new { htmlAttributes = new { @class = "form-control" } }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 153 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
           Write(Html.ValidationMessageFor(model => model.FacebookUrl, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 157 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
       Write(Html.LabelFor(model => model.TwitterUrl, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 159 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
           Write(Html.EditorFor(model => model.TwitterUrl, new { htmlAttributes = new { @class = "form-control" } }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 160 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
           Write(Html.ValidationMessageFor(model => model.TwitterUrl, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 164 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
       Write(Html.LabelFor(model => model.YouTubeUrl, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 166 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
           Write(Html.EditorFor(model => model.YouTubeUrl, new { htmlAttributes = new { @class = "form-control" } }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 167 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
           Write(Html.ValidationMessageFor(model => model.YouTubeUrl, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 171 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
       Write(Html.LabelFor(model => model.GooglePlusUrl, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 173 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
           Write(Html.EditorFor(model => model.GooglePlusUrl, new { htmlAttributes = new { @class = "form-control" } }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 174 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
           Write(Html.ValidationMessageFor(model => model.GooglePlusUrl, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 178 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
       Write(Html.LabelFor(model => model.LinkedInUrl, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 180 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
           Write(Html.EditorFor(model => model.LinkedInUrl, new { htmlAttributes = new { @class = "form-control" } }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 181 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
           Write(Html.ValidationMessageFor(model => model.LinkedInUrl, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 185 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
       Write(Html.LabelFor(model => model.Ordinal, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 187 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
           Write(Html.EditorFor(model => model.Ordinal, new { htmlAttributes = new { @class = "form-control" } }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 188 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
           Write(Html.ValidationMessageFor(model => model.Ordinal, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"col-md-offset-2 col-md-10\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" type=\"submit\"");

WriteAttribute("value", Tuple.Create(" value=", 11685), Tuple.Create("", 11717)
            
            #line 193 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 11692), Tuple.Create<System.Object, System.Int32>(Resources.Resources.Save
            
            #line default
            #line hidden
, 11692), false)
);

WriteLiteral(" class=\"btn btn-primary\"");

WriteLiteral("/>\r\n");

            
            #line 194 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
                
            
            #line default
            #line hidden
            
            #line 194 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
                 if (!Model.IsTranslated)
                {
                    
            
            #line default
            #line hidden
            
            #line 196 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
               Write(Html.ActionLink(Resources.Resources.AddTranslation, "Create", new { id = Model.TranslationId }, new { @class = "btn btn-info" }));

            
            #line default
            #line hidden
            
            #line 196 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
                                                                                                                                                     
                }
                else
                {
                    
            
            #line default
            #line hidden
            
            #line 200 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
               Write(Html.ActionLink(Resources.Resources.ViewTranslation, "Edit", new { employeeId = Model.Id, translationId = Model.TranslationId, lang = Model.Language.CultureName }, new { @class = "btn btn-info" }));

            
            #line default
            #line hidden
            
            #line 200 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
                                                                                                                                                                                                                         
                }

            
            #line default
            #line hidden
WriteLiteral("                ");

            
            #line 202 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
           Write(Html.ActionLink(Resources.Resources.Delete, "Delete", new { id = Model.Id }, new { @class = "btn btn-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"col-md-offset-2 col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 207 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
           Write(Html.ValidationSummary(false, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n");

            
            #line 211 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("<div>\r\n");

WriteLiteral("    ");

            
            #line 213 "..\..\Areas\Identity\Views\Employees\Edit.cshtml"
Write(Html.ActionLink(Resources.Resources.BackToList, "Index"));

            
            #line default
            #line hidden
WriteLiteral("\r\n</div>");

        }
    }
}
#pragma warning restore 1591
