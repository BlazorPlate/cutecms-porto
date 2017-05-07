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
    
    #line 2 "..\..\Areas\RMS\Views\Vacancies\Translations.cshtml"
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/RMS/Views/Vacancies/Translations.cshtml")]
    public partial class _Areas_RMS_Views_Vacancies_Translations_cshtml : System.Web.Mvc.WebViewPage<IEnumerable<cutecms_porto.Areas.RMS.Models.DBModel.Vacancy>>
    {
        public _Areas_RMS_Views_Vacancies_Translations_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Areas\RMS\Views\Vacancies\Translations.cshtml"
  
    ViewBag.MainTitle = Resources.Resources.Translations;
    ViewBag.Title = Resources.Resources.Index;

            
            #line default
            #line hidden
WriteLiteral("\r\n<p>\r\n");

WriteLiteral("    ");

            
            #line 8 "..\..\Areas\RMS\Views\Vacancies\Translations.cshtml"
Write(Html.ActionLink(Resources.Resources.AddTranslation, "Create", new { id = ViewBag.TranslationId }));

            
            #line default
            #line hidden
WriteLiteral("\r\n</p>\r\n<table");

WriteLiteral(" class=\"table\"");

WriteLiteral(">\r\n    <tr>\r\n        <th>\r\n");

WriteLiteral("            ");

            
            #line 13 "..\..\Areas\RMS\Views\Vacancies\Translations.cshtml"
       Write(Html.DisplayNameFor(model => model.Code));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </th>\r\n        <th>\r\n");

WriteLiteral("            ");

            
            #line 16 "..\..\Areas\RMS\Views\Vacancies\Translations.cshtml"
       Write(Html.DisplayNameFor(model => model.Title));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </th>\r\n        <th>\r\n");

WriteLiteral("            ");

            
            #line 19 "..\..\Areas\RMS\Views\Vacancies\Translations.cshtml"
       Write(Html.DisplayNameFor(model => model.LanguageId));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </th>\r\n        <th>\r\n");

WriteLiteral("            ");

            
            #line 22 "..\..\Areas\RMS\Views\Vacancies\Translations.cshtml"
       Write(Html.DisplayNameFor(model => model.JobTypeId));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </th>\r\n        <th>\r\n");

WriteLiteral("            ");

            
            #line 25 "..\..\Areas\RMS\Views\Vacancies\Translations.cshtml"
       Write(Html.DisplayNameFor(model => model.StatusId));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </th>\r\n        <th></th>\r\n    </tr>\r\n");

            
            #line 29 "..\..\Areas\RMS\Views\Vacancies\Translations.cshtml"
    
            
            #line default
            #line hidden
            
            #line 29 "..\..\Areas\RMS\Views\Vacancies\Translations.cshtml"
     foreach (var item in Model)
    {

            
            #line default
            #line hidden
WriteLiteral("        <tr>\r\n            <td>\r\n");

WriteLiteral("                ");

            
            #line 33 "..\..\Areas\RMS\Views\Vacancies\Translations.cshtml"
           Write(Html.DisplayFor(modelItem => item.Code));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </td>\r\n            <td>\r\n");

WriteLiteral("                ");

            
            #line 36 "..\..\Areas\RMS\Views\Vacancies\Translations.cshtml"
           Write(Html.DisplayFor(modelItem => item.Title));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </td>\r\n            <td>\r\n");

WriteLiteral("                ");

            
            #line 39 "..\..\Areas\RMS\Views\Vacancies\Translations.cshtml"
           Write(Html.DisplayFor(modelItem => item.Language.Name));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </td>\r\n            <td>\r\n");

            
            #line 42 "..\..\Areas\RMS\Views\Vacancies\Translations.cshtml"
                
            
            #line default
            #line hidden
            
            #line 42 "..\..\Areas\RMS\Views\Vacancies\Translations.cshtml"
                   var jobType = item.JobType.JobTypeTerms.Where(p => p.Language.CultureName.Trim().Equals(Thread.CurrentThread.CurrentCulture.Name) && p.JobTypeId == item.JobTypeId).FirstOrDefault()?.Value ?? item.JobType.Code;
            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 43 "..\..\Areas\RMS\Views\Vacancies\Translations.cshtml"
           Write(jobType);

            
            #line default
            #line hidden
WriteLiteral("\r\n            </td>\r\n            <td>\r\n");

            
            #line 46 "..\..\Areas\RMS\Views\Vacancies\Translations.cshtml"
                
            
            #line default
            #line hidden
            
            #line 46 "..\..\Areas\RMS\Views\Vacancies\Translations.cshtml"
                   var status = item.Status.StatusTerms.Where(p => p.Language.CultureName.Trim().Equals(Thread.CurrentThread.CurrentCulture.Name) && p.StatusId == item.StatusId).FirstOrDefault()?.Value ?? item.Status.Code;
            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 47 "..\..\Areas\RMS\Views\Vacancies\Translations.cshtml"
           Write(status);

            
            #line default
            #line hidden
WriteLiteral("\r\n            </td>\r\n            <td>\r\n");

WriteLiteral("                ");

            
            #line 50 "..\..\Areas\RMS\Views\Vacancies\Translations.cshtml"
           Write(Html.ActionLink(" ", "Edit", new { id = item.Id }, new { @class = "fa fa-2x fa-pencil", @title = Resources.Resources.Edit }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 51 "..\..\Areas\RMS\Views\Vacancies\Translations.cshtml"
           Write(Html.ActionLink(" ", "Details", new { id = item.Id }, new { @class = "fa fa-2x fa-file-text", @title = Resources.Resources.Details }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 52 "..\..\Areas\RMS\Views\Vacancies\Translations.cshtml"
           Write(Html.ActionLink(" ", "Index", "Submissions", new { id = item.Id }, new { @class = "fa fa-2x fa-list", @title = Resources.Resources.Submissions }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 53 "..\..\Areas\RMS\Views\Vacancies\Translations.cshtml"
           Write(Html.ActionLink(" ", "Delete", new { id = item.Id }, new { @class = "fa fa-2x fa-times", @title = Resources.Resources.Delete }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");

            
            #line 56 "..\..\Areas\RMS\Views\Vacancies\Translations.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("</table>\r\n<div>\r\n");

WriteLiteral("    ");

            
            #line 59 "..\..\Areas\RMS\Views\Vacancies\Translations.cshtml"
Write(Html.ActionLink(Resources.Resources.BackToList, "Index"));

            
            #line default
            #line hidden
WriteLiteral("\r\n</div>");

        }
    }
}
#pragma warning restore 1591