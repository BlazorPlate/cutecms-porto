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
    
    #line 1 "..\..\Areas\CMS\Views\Contents\Delete.cshtml"
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/CMS/Views/Contents/Delete.cshtml")]
    public partial class _Areas_CMS_Views_Contents_Delete_cshtml : System.Web.Mvc.WebViewPage<cutecms_porto.Areas.CMS.Models.DBModel.Content>
    {
        public _Areas_CMS_Views_Contents_Delete_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Areas\CMS\Views\Contents\Delete.cshtml"
  
    ViewBag.MainTitle = Resources.Resources.Content;
    ViewBag.Title = Resources.Resources.Delete;

            
            #line default
            #line hidden
WriteLiteral("\r\n<h3>");

            
            #line 7 "..\..\Areas\CMS\Views\Contents\Delete.cshtml"
Write(Resources.Resources.DeleteConfirmation);

            
            #line default
            #line hidden
WriteLiteral("</h3>\r\n<div>\r\n    <dl");

WriteLiteral(" class=\"dl-horizontal\"");

WriteLiteral(">\r\n        <dt>\r\n");

WriteLiteral("            ");

            
            #line 11 "..\..\Areas\CMS\Views\Contents\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.LanguageId));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n");

WriteLiteral("            ");

            
            #line 14 "..\..\Areas\CMS\Views\Contents\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Language.Name));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n");

WriteLiteral("            ");

            
            #line 17 "..\..\Areas\CMS\Views\Contents\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Code));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n");

WriteLiteral("            ");

            
            #line 20 "..\..\Areas\CMS\Views\Contents\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Code));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n");

WriteLiteral("            ");

            
            #line 23 "..\..\Areas\CMS\Views\Contents\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Title));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n");

WriteLiteral("            ");

            
            #line 26 "..\..\Areas\CMS\Views\Contents\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Title));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n");

WriteLiteral("            ");

            
            #line 29 "..\..\Areas\CMS\Views\Contents\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.ContentTypeId));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n");

            
            #line 32 "..\..\Areas\CMS\Views\Contents\Delete.cshtml"
            
            
            #line default
            #line hidden
            
            #line 32 "..\..\Areas\CMS\Views\Contents\Delete.cshtml"
               var contentType = Model.ContentType.ContentTypeTerms.Where(p => p.Language.CultureName.Trim().Equals(Thread.CurrentThread.CurrentCulture.Name) && p.ContentTypeId == Model.ContentTypeId).FirstOrDefault()?.Value ?? Model.ContentType.Code;
            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("            ");

            
            #line 33 "..\..\Areas\CMS\Views\Contents\Delete.cshtml"
       Write(contentType);

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n");

WriteLiteral("            ");

            
            #line 36 "..\..\Areas\CMS\Views\Contents\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.UrlSlug));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n");

WriteLiteral("            ");

            
            #line 39 "..\..\Areas\CMS\Views\Contents\Delete.cshtml"
       Write(Html.DisplayFor(model => model.UrlSlug));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n");

WriteLiteral("            ");

            
            #line 42 "..\..\Areas\CMS\Views\Contents\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Author));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n");

WriteLiteral("            ");

            
            #line 45 "..\..\Areas\CMS\Views\Contents\Delete.cshtml"
       Write(Html.Display("Author"));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n");

WriteLiteral("            ");

            
            #line 48 "..\..\Areas\CMS\Views\Contents\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.ModifiedBy));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n");

WriteLiteral("            ");

            
            #line 51 "..\..\Areas\CMS\Views\Contents\Delete.cshtml"
       Write(Html.Display("ModifiedBy"));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n");

WriteLiteral("            ");

            
            #line 54 "..\..\Areas\CMS\Views\Contents\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.CreatedOn));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n");

WriteLiteral("            ");

            
            #line 57 "..\..\Areas\CMS\Views\Contents\Delete.cshtml"
       Write(Html.DisplayFor(model => model.CreatedOn));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n");

WriteLiteral("            ");

            
            #line 60 "..\..\Areas\CMS\Views\Contents\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.PublishedOn));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n");

WriteLiteral("            ");

            
            #line 63 "..\..\Areas\CMS\Views\Contents\Delete.cshtml"
       Write(Html.DisplayFor(model => model.PublishedOn));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n");

WriteLiteral("            ");

            
            #line 66 "..\..\Areas\CMS\Views\Contents\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.ModifiedOn));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n");

WriteLiteral("            ");

            
            #line 69 "..\..\Areas\CMS\Views\Contents\Delete.cshtml"
       Write(Html.DisplayFor(model => model.ModifiedOn));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n");

WriteLiteral("            ");

            
            #line 72 "..\..\Areas\CMS\Views\Contents\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.IsTranslated));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n");

WriteLiteral("            ");

            
            #line 75 "..\..\Areas\CMS\Views\Contents\Delete.cshtml"
       Write(Html.CheckBoxFor(model => model.IsTranslated, new { htmlAttributes = new { @class = "js-switch", @disabled = "disabled" } }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n");

WriteLiteral("            ");

            
            #line 78 "..\..\Areas\CMS\Views\Contents\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.StatusId));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n");

            
            #line 81 "..\..\Areas\CMS\Views\Contents\Delete.cshtml"
            
            
            #line default
            #line hidden
            
            #line 81 "..\..\Areas\CMS\Views\Contents\Delete.cshtml"
               var status = Model.Status.StatusTerms.Where(p => p.Language.CultureName.Trim().Equals(Thread.CurrentThread.CurrentCulture.Name) && p.StatusId == Model.StatusId).FirstOrDefault()?.Value ?? Model.Status.Code;
            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("            ");

            
            #line 82 "..\..\Areas\CMS\Views\Contents\Delete.cshtml"
       Write(status);

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n");

            
            #line 85 "..\..\Areas\CMS\Views\Contents\Delete.cshtml"
    
            
            #line default
            #line hidden
            
            #line 85 "..\..\Areas\CMS\Views\Contents\Delete.cshtml"
     using (Html.BeginForm())
    {
        
            
            #line default
            #line hidden
            
            #line 87 "..\..\Areas\CMS\Views\Contents\Delete.cshtml"
   Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 87 "..\..\Areas\CMS\Views\Contents\Delete.cshtml"
                                

            
            #line default
            #line hidden
WriteLiteral("        <div");

WriteLiteral(" class=\"form-actions no-color\"");

WriteLiteral(">\r\n            <input");

WriteLiteral(" type=\"submit\"");

WriteAttribute("value", Tuple.Create(" value=", 2983), Tuple.Create("", 3017)
            
            #line 89 "..\..\Areas\CMS\Views\Contents\Delete.cshtml"
, Tuple.Create(Tuple.Create("", 2990), Tuple.Create<System.Object, System.Int32>(Resources.Resources.Delete
            
            #line default
            #line hidden
, 2990), false)
);

WriteLiteral(" class=\"btn btn-primary\"");

WriteLiteral(" /> |\r\n");

WriteLiteral("            ");

            
            #line 90 "..\..\Areas\CMS\Views\Contents\Delete.cshtml"
       Write(Html.ActionLink(Resources.Resources.BackToList, "Index"));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n");

WriteLiteral("        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"col-md-offset-2 col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 94 "..\..\Areas\CMS\Views\Contents\Delete.cshtml"
           Write(Html.ValidationSummary(false, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n");

            
            #line 97 "..\..\Areas\CMS\Views\Contents\Delete.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("</div>");

        }
    }
}
#pragma warning restore 1591
