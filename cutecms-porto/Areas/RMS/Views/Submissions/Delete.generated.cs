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
    
    #line 1 "..\..\Areas\RMS\Views\Submissions\Delete.cshtml"
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/RMS/Views/Submissions/Delete.cshtml")]
    public partial class _Areas_RMS_Views_Submissions_Delete_cshtml : System.Web.Mvc.WebViewPage<cutecms_porto.Areas.RMS.Models.DBModel.Submission>
    {
        public _Areas_RMS_Views_Submissions_Delete_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Areas\RMS\Views\Submissions\Delete.cshtml"
  
    ViewBag.MainTitle = Resources.Resources.Submission;
    ViewBag.Title = Resources.Resources.Delete;

            
            #line default
            #line hidden
WriteLiteral("\r\n<h3>");

            
            #line 7 "..\..\Areas\RMS\Views\Submissions\Delete.cshtml"
Write(Resources.Resources.DeleteConfirmation);

            
            #line default
            #line hidden
WriteLiteral("</h3>\r\n<div>\r\n    <dl");

WriteLiteral(" class=\"dl-horizontal\"");

WriteLiteral(">\r\n        <dt>\r\n");

WriteLiteral("            ");

            
            #line 11 "..\..\Areas\RMS\Views\Submissions\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Id));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n");

WriteLiteral("            ");

            
            #line 14 "..\..\Areas\RMS\Views\Submissions\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Id));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n");

WriteLiteral("            ");

            
            #line 17 "..\..\Areas\RMS\Views\Submissions\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Applicant.FullName));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n");

WriteLiteral("            ");

            
            #line 20 "..\..\Areas\RMS\Views\Submissions\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Applicant.FullName));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n");

WriteLiteral("            ");

            
            #line 23 "..\..\Areas\RMS\Views\Submissions\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Applicant.GenderId));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n");

            
            #line 26 "..\..\Areas\RMS\Views\Submissions\Delete.cshtml"
            
            
            #line default
            #line hidden
            
            #line 26 "..\..\Areas\RMS\Views\Submissions\Delete.cshtml"
               var gender = Model.Applicant.Gender.GenderTerms.Where(p => p.Language.CultureName.Trim().Equals(Thread.CurrentThread.CurrentCulture.Name) && p.GenderId == Model.Applicant.GenderId).FirstOrDefault()?.Value ?? Model.Applicant.Gender.Code;
            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("            ");

            
            #line 27 "..\..\Areas\RMS\Views\Submissions\Delete.cshtml"
       Write(gender);

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n");

WriteLiteral("            ");

            
            #line 30 "..\..\Areas\RMS\Views\Submissions\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Applicant.DOB));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n");

WriteLiteral("            ");

            
            #line 33 "..\..\Areas\RMS\Views\Submissions\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Applicant.DOB));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n");

WriteLiteral("            ");

            
            #line 36 "..\..\Areas\RMS\Views\Submissions\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Applicant.Mobile));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n");

WriteLiteral("            ");

            
            #line 39 "..\..\Areas\RMS\Views\Submissions\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Applicant.Mobile));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n");

WriteLiteral("            ");

            
            #line 42 "..\..\Areas\RMS\Views\Submissions\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Applicant.Email));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n");

WriteLiteral("            ");

            
            #line 45 "..\..\Areas\RMS\Views\Submissions\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Applicant.Email));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n");

WriteLiteral("            ");

            
            #line 48 "..\..\Areas\RMS\Views\Submissions\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.CoverLetter));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n");

WriteLiteral("            ");

            
            #line 51 "..\..\Areas\RMS\Views\Submissions\Delete.cshtml"
       Write(Html.Raw(HttpUtility.HtmlDecode(Model.CoverLetter)));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n");

WriteLiteral("            ");

            
            #line 54 "..\..\Areas\RMS\Views\Submissions\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.SubmissionDate));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n");

WriteLiteral("            ");

            
            #line 57 "..\..\Areas\RMS\Views\Submissions\Delete.cshtml"
       Write(Html.DisplayFor(model => model.SubmissionDate));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n");

WriteLiteral("            ");

            
            #line 60 "..\..\Areas\RMS\Views\Submissions\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Applicant.ResumeFilePath));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n");

WriteLiteral("            ");

            
            #line 63 "..\..\Areas\RMS\Views\Submissions\Delete.cshtml"
       Write(Html.ActionLink(Resources.Resources.Download, "Download", new { FilePath = Model.Applicant.ResumeFilePath, FileName = Model.Applicant.ResumeFileName }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dd>\r\n        <dd>\r\n            <br />\r\n        </dd>\r\n        <dt>\r\n");

WriteLiteral("            ");

            
            #line 69 "..\..\Areas\RMS\Views\Submissions\Delete.cshtml"
       Write(Resources.Resources.Attachments);

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n");

            
            #line 72 "..\..\Areas\RMS\Views\Submissions\Delete.cshtml"
            
            
            #line default
            #line hidden
            
            #line 72 "..\..\Areas\RMS\Views\Submissions\Delete.cshtml"
             foreach (var item in Model.Applicant.Attachments)
            {
                
            
            #line default
            #line hidden
            
            #line 74 "..\..\Areas\RMS\Views\Submissions\Delete.cshtml"
           Write(Html.ActionLink(Resources.Resources.Download, "Download", new { FilePath = item.FilePath, FileName = @item.FileName }));

            
            #line default
            #line hidden
            
            #line 74 "..\..\Areas\RMS\Views\Submissions\Delete.cshtml"
                                                                                                                                       

            
            #line default
            #line hidden
WriteLiteral("                <br />\r\n");

            
            #line 76 "..\..\Areas\RMS\Views\Submissions\Delete.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("        </dd>\r\n    </dl>\r\n");

            
            #line 79 "..\..\Areas\RMS\Views\Submissions\Delete.cshtml"
    
            
            #line default
            #line hidden
            
            #line 79 "..\..\Areas\RMS\Views\Submissions\Delete.cshtml"
     using (Html.BeginForm())
    {
        
            
            #line default
            #line hidden
            
            #line 81 "..\..\Areas\RMS\Views\Submissions\Delete.cshtml"
   Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 81 "..\..\Areas\RMS\Views\Submissions\Delete.cshtml"
                                

            
            #line default
            #line hidden
WriteLiteral("        <div");

WriteLiteral(" class=\"form-actions no-color\"");

WriteLiteral(">\r\n            <input");

WriteLiteral(" type=\"submit\"");

WriteAttribute("value", Tuple.Create(" value=", 2832), Tuple.Create("", 2866)
            
            #line 83 "..\..\Areas\RMS\Views\Submissions\Delete.cshtml"
, Tuple.Create(Tuple.Create("", 2839), Tuple.Create<System.Object, System.Int32>(Resources.Resources.Delete
            
            #line default
            #line hidden
, 2839), false)
);

WriteLiteral(" class=\"btn btn-primary\"");

WriteLiteral(" /> |\r\n");

WriteLiteral("            ");

            
            #line 84 "..\..\Areas\RMS\Views\Submissions\Delete.cshtml"
       Write(Html.ActionLink(Resources.Resources.BackToList, "Index"));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n");

            
            #line 86 "..\..\Areas\RMS\Views\Submissions\Delete.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("</div>");

        }
    }
}
#pragma warning restore 1591
