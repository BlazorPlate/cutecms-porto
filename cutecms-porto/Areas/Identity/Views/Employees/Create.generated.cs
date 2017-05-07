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
    
    #line 3 "..\..\Areas\Identity\Views\Employees\Create.cshtml"
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
    
    #line 2 "..\..\Areas\Identity\Views\Employees\Create.cshtml"
    using cutecms_porto.Areas.Identity.Models;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/Identity/Views/Employees/Create.cshtml")]
    public partial class _Areas_Identity_Views_Employees_Create_cshtml : System.Web.Mvc.WebViewPage<cutecms_porto.Areas.Identity.Models.DBModel.Employee>
    {
        public _Areas_Identity_Views_Employees_Create_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 4 "..\..\Areas\Identity\Views\Employees\Create.cshtml"
  
    ViewBag.MainTitle = Resources.Resources.Employee;
    ViewBag.Title = Resources.Resources.Create;
    ApplicationDbContext dbIdentity = new ApplicationDbContext();

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 9 "..\..\Areas\Identity\Views\Employees\Create.cshtml"
 using (Html.BeginForm("Create", "Employees", FormMethod.Post, new { enctype = "multipart/form-data" }))
{
    
            
            #line default
            #line hidden
            
            #line 11 "..\..\Areas\Identity\Views\Employees\Create.cshtml"
Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 11 "..\..\Areas\Identity\Views\Employees\Create.cshtml"
                            

            
            #line default
            #line hidden
WriteLiteral("    <div");

WriteLiteral(" class=\"form-horizontal\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 13 "..\..\Areas\Identity\Views\Employees\Create.cshtml"
   Write(Html.HiddenFor(model => model.TranslationId));

            
            #line default
            #line hidden
WriteLiteral("\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 15 "..\..\Areas\Identity\Views\Employees\Create.cshtml"
       Write(Html.LabelFor(model => model.LanguageId, new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 17 "..\..\Areas\Identity\Views\Employees\Create.cshtml"
           Write(Html.DropDownList("LanguageId", null, Resources.Resources.ChooseLanguage, htmlAttributes: new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 18 "..\..\Areas\Identity\Views\Employees\Create.cshtml"
           Write(Html.ValidationMessageFor(model => model.LanguageId, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 22 "..\..\Areas\Identity\Views\Employees\Create.cshtml"
       Write(Html.LabelFor(model => model.LoginId, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 24 "..\..\Areas\Identity\Views\Employees\Create.cshtml"
           Write(Html.DropDownList("LoginId", null, string.Empty, htmlAttributes: new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 25 "..\..\Areas\Identity\Views\Employees\Create.cshtml"
           Write(Html.ValidationMessageFor(model => model.LoginId, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 29 "..\..\Areas\Identity\Views\Employees\Create.cshtml"
       Write(Html.Label(Resources.Resources.UploadPersonalPhoto, new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 31 "..\..\Areas\Identity\Views\Employees\Create.cshtml"
           Write(Html.TextBoxFor(model => model.Image, new { @class = "form-control", type = "file", multiple = "false", placeholder = "upload files" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 32 "..\..\Areas\Identity\Views\Employees\Create.cshtml"
           Write(Html.ValidationMessageFor(model => model.Image, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                <small");

WriteLiteral(" class=\"text-muted block\"");

WriteLiteral(">");

            
            #line 33 "..\..\Areas\Identity\Views\Employees\Create.cshtml"
                                           Write(Resources.Resources.ImageNotes);

            
            #line default
            #line hidden
WriteLiteral("</small>\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 37 "..\..\Areas\Identity\Views\Employees\Create.cshtml"
       Write(Html.LabelFor(model => model.PersonalTitleId, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 39 "..\..\Areas\Identity\Views\Employees\Create.cshtml"
           Write(Html.DropDownList("PersonalTitleId", null, Resources.Resources.ChoosePersonalTitle, htmlAttributes: new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 40 "..\..\Areas\Identity\Views\Employees\Create.cshtml"
           Write(Html.ValidationMessageFor(model => model.PersonalTitleId, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 44 "..\..\Areas\Identity\Views\Employees\Create.cshtml"
       Write(Html.LabelFor(model => model.FirstName, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 46 "..\..\Areas\Identity\Views\Employees\Create.cshtml"
           Write(Html.EditorFor(model => model.FirstName, new { htmlAttributes = new { @class = "form-control" } }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 47 "..\..\Areas\Identity\Views\Employees\Create.cshtml"
           Write(Html.ValidationMessageFor(model => model.FirstName, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 51 "..\..\Areas\Identity\Views\Employees\Create.cshtml"
       Write(Html.LabelFor(model => model.MiddleName, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 53 "..\..\Areas\Identity\Views\Employees\Create.cshtml"
           Write(Html.EditorFor(model => model.MiddleName, new { htmlAttributes = new { @class = "form-control" } }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 54 "..\..\Areas\Identity\Views\Employees\Create.cshtml"
           Write(Html.ValidationMessageFor(model => model.MiddleName, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 58 "..\..\Areas\Identity\Views\Employees\Create.cshtml"
       Write(Html.LabelFor(model => model.LastName, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 60 "..\..\Areas\Identity\Views\Employees\Create.cshtml"
           Write(Html.EditorFor(model => model.LastName, new { htmlAttributes = new { @class = "form-control" } }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 61 "..\..\Areas\Identity\Views\Employees\Create.cshtml"
           Write(Html.ValidationMessageFor(model => model.LastName, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 65 "..\..\Areas\Identity\Views\Employees\Create.cshtml"
       Write(Html.LabelFor(model => model.Biography, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 67 "..\..\Areas\Identity\Views\Employees\Create.cshtml"
           Write(Html.TextAreaFor(model => model.Biography, new { @class = "mceEditor" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 68 "..\..\Areas\Identity\Views\Employees\Create.cshtml"
           Write(Html.ValidationMessageFor(model => model.Biography, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 72 "..\..\Areas\Identity\Views\Employees\Create.cshtml"
       Write(Html.LabelFor(model => model.CV, new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 74 "..\..\Areas\Identity\Views\Employees\Create.cshtml"
           Write(Html.TextBoxFor(model => model.CV, new { @class = "form-control", type = "file", multiple = "false", placeholder = "upload files" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 75 "..\..\Areas\Identity\Views\Employees\Create.cshtml"
           Write(Html.ValidationMessageFor(model => model.CV, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                <small");

WriteLiteral(" class=\"text-muted block\"");

WriteLiteral(">");

            
            #line 76 "..\..\Areas\Identity\Views\Employees\Create.cshtml"
                                           Write(Resources.Resources.CVNotes);

            
            #line default
            #line hidden
WriteLiteral("</small>\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 80 "..\..\Areas\Identity\Views\Employees\Create.cshtml"
       Write(Html.LabelFor(model => model.RankId, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 82 "..\..\Areas\Identity\Views\Employees\Create.cshtml"
           Write(Html.DropDownList("RankId", null, string.Empty, htmlAttributes: new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 83 "..\..\Areas\Identity\Views\Employees\Create.cshtml"
           Write(Html.ValidationMessageFor(model => model.RankId, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 87 "..\..\Areas\Identity\Views\Employees\Create.cshtml"
       Write(Html.LabelFor(model => model.DegreeId, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 89 "..\..\Areas\Identity\Views\Employees\Create.cshtml"
           Write(Html.DropDownList("DegreeId", null, string.Empty, htmlAttributes: new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 90 "..\..\Areas\Identity\Views\Employees\Create.cshtml"
           Write(Html.ValidationMessageFor(model => model.DegreeId, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 94 "..\..\Areas\Identity\Views\Employees\Create.cshtml"
       Write(Html.LabelFor(model => model.ProgramId, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 96 "..\..\Areas\Identity\Views\Employees\Create.cshtml"
           Write(Html.DropDownList("ProgramId", null, string.Empty, htmlAttributes: new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 97 "..\..\Areas\Identity\Views\Employees\Create.cshtml"
           Write(Html.ValidationMessageFor(model => model.ProgramId, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 101 "..\..\Areas\Identity\Views\Employees\Create.cshtml"
       Write(Html.LabelFor(model => model.OfficeNumber, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 103 "..\..\Areas\Identity\Views\Employees\Create.cshtml"
           Write(Html.EditorFor(model => model.OfficeNumber, new { htmlAttributes = new { @class = "form-control" } }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 104 "..\..\Areas\Identity\Views\Employees\Create.cshtml"
           Write(Html.ValidationMessageFor(model => model.OfficeNumber, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 108 "..\..\Areas\Identity\Views\Employees\Create.cshtml"
       Write(Html.LabelFor(model => model.Mobile, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 110 "..\..\Areas\Identity\Views\Employees\Create.cshtml"
           Write(Html.EditorFor(model => model.Mobile, new { htmlAttributes = new { @class = "form-control" } }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 111 "..\..\Areas\Identity\Views\Employees\Create.cshtml"
           Write(Html.ValidationMessageFor(model => model.Mobile, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 115 "..\..\Areas\Identity\Views\Employees\Create.cshtml"
       Write(Html.LabelFor(model => model.LandLine, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 117 "..\..\Areas\Identity\Views\Employees\Create.cshtml"
           Write(Html.EditorFor(model => model.LandLine, new { htmlAttributes = new { @class = "form-control" } }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 118 "..\..\Areas\Identity\Views\Employees\Create.cshtml"
           Write(Html.ValidationMessageFor(model => model.LandLine, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 122 "..\..\Areas\Identity\Views\Employees\Create.cshtml"
       Write(Html.LabelFor(model => model.Extension, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 124 "..\..\Areas\Identity\Views\Employees\Create.cshtml"
           Write(Html.EditorFor(model => model.Extension, new { htmlAttributes = new { @class = "form-control" } }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 125 "..\..\Areas\Identity\Views\Employees\Create.cshtml"
           Write(Html.ValidationMessageFor(model => model.Extension, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 129 "..\..\Areas\Identity\Views\Employees\Create.cshtml"
       Write(Html.LabelFor(model => model.FacebookUrl, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 131 "..\..\Areas\Identity\Views\Employees\Create.cshtml"
           Write(Html.EditorFor(model => model.FacebookUrl, new { htmlAttributes = new { @class = "form-control" } }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 132 "..\..\Areas\Identity\Views\Employees\Create.cshtml"
           Write(Html.ValidationMessageFor(model => model.FacebookUrl, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 136 "..\..\Areas\Identity\Views\Employees\Create.cshtml"
       Write(Html.LabelFor(model => model.TwitterUrl, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 138 "..\..\Areas\Identity\Views\Employees\Create.cshtml"
           Write(Html.EditorFor(model => model.TwitterUrl, new { htmlAttributes = new { @class = "form-control" } }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 139 "..\..\Areas\Identity\Views\Employees\Create.cshtml"
           Write(Html.ValidationMessageFor(model => model.TwitterUrl, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 143 "..\..\Areas\Identity\Views\Employees\Create.cshtml"
       Write(Html.LabelFor(model => model.YouTubeUrl, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 145 "..\..\Areas\Identity\Views\Employees\Create.cshtml"
           Write(Html.EditorFor(model => model.YouTubeUrl, new { htmlAttributes = new { @class = "form-control" } }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 146 "..\..\Areas\Identity\Views\Employees\Create.cshtml"
           Write(Html.ValidationMessageFor(model => model.YouTubeUrl, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 150 "..\..\Areas\Identity\Views\Employees\Create.cshtml"
       Write(Html.LabelFor(model => model.GooglePlusUrl, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 152 "..\..\Areas\Identity\Views\Employees\Create.cshtml"
           Write(Html.EditorFor(model => model.GooglePlusUrl, new { htmlAttributes = new { @class = "form-control" } }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 153 "..\..\Areas\Identity\Views\Employees\Create.cshtml"
           Write(Html.ValidationMessageFor(model => model.GooglePlusUrl, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 157 "..\..\Areas\Identity\Views\Employees\Create.cshtml"
       Write(Html.LabelFor(model => model.LinkedInUrl, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 159 "..\..\Areas\Identity\Views\Employees\Create.cshtml"
           Write(Html.EditorFor(model => model.LinkedInUrl, new { htmlAttributes = new { @class = "form-control" } }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 160 "..\..\Areas\Identity\Views\Employees\Create.cshtml"
           Write(Html.ValidationMessageFor(model => model.LinkedInUrl, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 164 "..\..\Areas\Identity\Views\Employees\Create.cshtml"
       Write(Html.LabelFor(model => model.Ordinal, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 166 "..\..\Areas\Identity\Views\Employees\Create.cshtml"
           Write(Html.EditorFor(model => model.Ordinal, new { htmlAttributes = new { @class = "form-control" } }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 167 "..\..\Areas\Identity\Views\Employees\Create.cshtml"
           Write(Html.ValidationMessageFor(model => model.Ordinal, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"col-md-offset-2 col-md-10\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" type=\"submit\"");

WriteAttribute("value", Tuple.Create(" value=", 10653), Tuple.Create("", 10687)
            
            #line 172 "..\..\Areas\Identity\Views\Employees\Create.cshtml"
, Tuple.Create(Tuple.Create("", 10660), Tuple.Create<System.Object, System.Int32>(Resources.Resources.Create
            
            #line default
            #line hidden
, 10660), false)
);

WriteLiteral(" class=\"btn btn-primary\"");

WriteLiteral(" />\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"col-md-offset-2 col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 177 "..\..\Areas\Identity\Views\Employees\Create.cshtml"
           Write(Html.ValidationSummary(false, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n");

            
            #line 181 "..\..\Areas\Identity\Views\Employees\Create.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("<div>\r\n");

WriteLiteral("    ");

            
            #line 183 "..\..\Areas\Identity\Views\Employees\Create.cshtml"
Write(Html.ActionLink(Resources.Resources.BackToList, "Index"));

            
            #line default
            #line hidden
WriteLiteral("\r\n</div>");

        }
    }
}
#pragma warning restore 1591