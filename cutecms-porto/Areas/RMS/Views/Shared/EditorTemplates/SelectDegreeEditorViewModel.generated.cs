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
    
    #line 1 "..\..\Areas\RMS\Views\Shared\EditorTemplates\SelectDegreeEditorViewModel.cshtml"
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/RMS/Views/Shared/EditorTemplates/SelectDegreeEditorViewModel.cshtml")]
    public partial class _Areas_RMS_Views_Shared_EditorTemplates_SelectDegreeEditorViewModel_cshtml_ : System.Web.Mvc.WebViewPage<cutecms_porto.Areas.RMS.Models.SelectDegreeEditorViewModel>
    {
        public _Areas_RMS_Views_Shared_EditorTemplates_SelectDegreeEditorViewModel_cshtml_()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Areas\RMS\Views\Shared\EditorTemplates\SelectDegreeEditorViewModel.cshtml"
Write(Html.HiddenFor(model => model.DegreeId));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 4 "..\..\Areas\RMS\Views\Shared\EditorTemplates\SelectDegreeEditorViewModel.cshtml"
Write(Html.HiddenFor(model => model.DegreeName));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 5 "..\..\Areas\RMS\Views\Shared\EditorTemplates\SelectDegreeEditorViewModel.cshtml"
Write(Html.CheckBoxFor(model => model.Selected, new { @class = "js-switch"}));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 6 "..\..\Areas\RMS\Views\Shared\EditorTemplates\SelectDegreeEditorViewModel.cshtml"
Write(Html.DisplayFor(model => model.DegreeName));

            
            #line default
            #line hidden
WriteLiteral("<br />");

        }
    }
}
#pragma warning restore 1591
