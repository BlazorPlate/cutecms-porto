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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/Identity/Views/IdentityPersonalTitleTerms/Create.cshtml")]
    public partial class _Areas_Identity_Views_IdentityPersonalTitleTerms_Create_cshtml : System.Web.Mvc.WebViewPage<cutecms_porto.Areas.Identity.Models.DBModel.IdentityPersonalTitleTerm>
    {
        public _Areas_Identity_Views_IdentityPersonalTitleTerms_Create_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Areas\Identity\Views\IdentityPersonalTitleTerms\Create.cshtml"
  
    ViewBag.MainTitle = Resources.Resources.Term;
    ViewBag.Title = Resources.Resources.Create;

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 6 "..\..\Areas\Identity\Views\IdentityPersonalTitleTerms\Create.cshtml"
 using (Html.BeginForm())
{
    
            
            #line default
            #line hidden
            
            #line 8 "..\..\Areas\Identity\Views\IdentityPersonalTitleTerms\Create.cshtml"
Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 8 "..\..\Areas\Identity\Views\IdentityPersonalTitleTerms\Create.cshtml"
                            
    
            
            #line default
            #line hidden
            
            #line 9 "..\..\Areas\Identity\Views\IdentityPersonalTitleTerms\Create.cshtml"
Write(Html.Hidden("PersonalTitleId"));

            
            #line default
            #line hidden
            
            #line 9 "..\..\Areas\Identity\Views\IdentityPersonalTitleTerms\Create.cshtml"
                                   

            
            #line default
            #line hidden
WriteLiteral("    <div");

WriteLiteral(" class=\"form-horizontal\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 12 "..\..\Areas\Identity\Views\IdentityPersonalTitleTerms\Create.cshtml"
       Write(Html.LabelFor(model => model.PersonalTitle.Code, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 14 "..\..\Areas\Identity\Views\IdentityPersonalTitleTerms\Create.cshtml"
           Write(Html.TextBox("PersonalTitleCode", null, htmlAttributes: new { @class = "form-control", @disabled = "disabled" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 15 "..\..\Areas\Identity\Views\IdentityPersonalTitleTerms\Create.cshtml"
           Write(Html.ValidationMessageFor(model => model.PersonalTitleId, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 19 "..\..\Areas\Identity\Views\IdentityPersonalTitleTerms\Create.cshtml"
       Write(Html.LabelFor(model => model.LanguageId, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 21 "..\..\Areas\Identity\Views\IdentityPersonalTitleTerms\Create.cshtml"
           Write(Html.DropDownList("LanguageId", null, Resources.Resources.ChooseLanguage, htmlAttributes: new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 22 "..\..\Areas\Identity\Views\IdentityPersonalTitleTerms\Create.cshtml"
           Write(Html.ValidationMessageFor(model => model.LanguageId, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 26 "..\..\Areas\Identity\Views\IdentityPersonalTitleTerms\Create.cshtml"
       Write(Html.LabelFor(model => model.Value, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 28 "..\..\Areas\Identity\Views\IdentityPersonalTitleTerms\Create.cshtml"
           Write(Html.EditorFor(model => model.Value, new { htmlAttributes = new { @class = "form-control" } }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 29 "..\..\Areas\Identity\Views\IdentityPersonalTitleTerms\Create.cshtml"
           Write(Html.ValidationMessageFor(model => model.Value, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"col-md-offset-2 col-md-10\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" type=\"submit\"");

WriteAttribute("value", Tuple.Create(" value=", 1812), Tuple.Create("", 1846)
            
            #line 34 "..\..\Areas\Identity\Views\IdentityPersonalTitleTerms\Create.cshtml"
, Tuple.Create(Tuple.Create("", 1819), Tuple.Create<System.Object, System.Int32>(Resources.Resources.Create
            
            #line default
            #line hidden
, 1819), false)
);

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral("/>\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"col-md-offset-2 col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 39 "..\..\Areas\Identity\Views\IdentityPersonalTitleTerms\Create.cshtml"
           Write(Html.ValidationSummary(false, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n");

            
            #line 43 "..\..\Areas\Identity\Views\IdentityPersonalTitleTerms\Create.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("<div>\r\n");

WriteLiteral("    ");

            
            #line 45 "..\..\Areas\Identity\Views\IdentityPersonalTitleTerms\Create.cshtml"
Write(Html.ActionLink(Resources.Resources.BackToList, "Index", new { id = ViewBag.PersonalTitleId }));

            
            #line default
            #line hidden
WriteLiteral("\r\n</div>\r\n");

DefineSection("Scripts", () => {

WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 48 "..\..\Areas\Identity\Views\IdentityPersonalTitleTerms\Create.cshtml"
Write(Scripts.Render("~/bundles/jqueryval"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

});

        }
    }
}
#pragma warning restore 1591
