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
    
    #line 2 "..\..\Views\MyProfile\Index.cshtml"
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
    using cutecms_porto.Helpers;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/MyProfile/Index.cshtml")]
    public partial class _Views_MyProfile_Index_cshtml : System.Web.Mvc.WebViewPage<cutecms_porto.Areas.Identity.Models.DBModel.Employee>
    {
        public _Views_MyProfile_Index_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Views\MyProfile\Index.cshtml"
  
    ViewBag.Title = Resources.Resources.MyProfile;
    Layout = "~/Views/Shared/_Layout.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n");

DefineSection("PageHeader", () => {

WriteLiteral("\r\n    <section");

WriteLiteral(" class=\"page-header\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"container\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"col-md-12\"");

WriteLiteral(">\r\n                    <h1>");

            
            #line 13 "..\..\Views\MyProfile\Index.cshtml"
                   Write(ViewBag.Title);

            
            #line default
            #line hidden
WriteLiteral("</h1>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </section>" +
"\r\n");

});

WriteLiteral("<section>\r\n    <div");

WriteLiteral(" class=\"container\"");

WriteLiteral(">\r\n        <!-- RIGHT -->\r\n        <div");

WriteLiteral(" class=\"col-lg-9 col-md-9 col-sm-8 col-lg-push-3 col-md-push-3 col-sm-push-4 marg" +
"in-bottom-80\"");

WriteLiteral(">\r\n            <ul");

WriteLiteral(" id=\"tabbed-list\"");

WriteLiteral(" class=\"nav nav-tabs nav-top-border\"");

WriteLiteral(">\r\n                <li");

WriteAttribute("class", Tuple.Create(" class=\"", 744), Tuple.Create("\"", 779)
            
            #line 24 "..\..\Views\MyProfile\Index.cshtml"
, Tuple.Create(Tuple.Create("", 752), Tuple.Create<System.Object, System.Int32>(ViewBag.ActivePersonalInfo
            
            #line default
            #line hidden
, 752), false)
);

WriteLiteral("><a");

WriteAttribute("aria-expanded", Tuple.Create(" aria-expanded=\"", 783), Tuple.Create("\"", 832)
            
            #line 24 "..\..\Views\MyProfile\Index.cshtml"
, Tuple.Create(Tuple.Create("", 799), Tuple.Create<System.Object, System.Int32>(ViewBag.AriaExpandedPersonalInfo
            
            #line default
            #line hidden
, 799), false)
);

WriteLiteral(" href=\"#personal-info\"");

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(">");

            
            #line 24 "..\..\Views\MyProfile\Index.cshtml"
                                                                                                                                                Write(Resources.Resources.PersonalInfo);

            
            #line default
            #line hidden
WriteLiteral("</a></li>\r\n                <li");

WriteLiteral(" id=\"PersonalPhoto\"");

WriteAttribute("class", Tuple.Create(" class=\"", 956), Tuple.Create("\"", 992)
            
            #line 25 "..\..\Views\MyProfile\Index.cshtml"
, Tuple.Create(Tuple.Create("", 964), Tuple.Create<System.Object, System.Int32>(ViewBag.ActivePersonalPhoto
            
            #line default
            #line hidden
, 964), false)
);

WriteLiteral("><a");

WriteAttribute("aria-expanded", Tuple.Create(" aria-expanded=\"", 996), Tuple.Create("\"", 1046)
            
            #line 25 "..\..\Views\MyProfile\Index.cshtml"
              , Tuple.Create(Tuple.Create("", 1012), Tuple.Create<System.Object, System.Int32>(ViewBag.AriaExpandedPersonalPhoto
            
            #line default
            #line hidden
, 1012), false)
);

WriteLiteral(" href=\"#personal-photo\"");

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(">");

            
            #line 25 "..\..\Views\MyProfile\Index.cshtml"
                                                                                                                                                                      Write(Resources.Resources.PersonalPhoto);

            
            #line default
            #line hidden
WriteLiteral("</a></li>\r\n                <li");

WriteLiteral(" id=\"AcademicInfo\"");

WriteAttribute("class", Tuple.Create(" class=\"", 1171), Tuple.Create("\"", 1206)
            
            #line 26 "..\..\Views\MyProfile\Index.cshtml"
, Tuple.Create(Tuple.Create("", 1179), Tuple.Create<System.Object, System.Int32>(ViewBag.ActiveAcademicInfo
            
            #line default
            #line hidden
, 1179), false)
);

WriteLiteral("><a");

WriteAttribute("aria-expanded", Tuple.Create(" aria-expanded=\"", 1210), Tuple.Create("\"", 1247)
            
            #line 26 "..\..\Views\MyProfile\Index.cshtml"
            , Tuple.Create(Tuple.Create("", 1226), Tuple.Create<System.Object, System.Int32>(ViewBag.AcademicInfo
            
            #line default
            #line hidden
, 1226), false)
);

WriteLiteral(" href=\"#academic-info\"");

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(">");

            
            #line 26 "..\..\Views\MyProfile\Index.cshtml"
                                                                                                                                                      Write(Resources.Resources.AcademicInfo);

            
            #line default
            #line hidden
WriteLiteral("</a></li>\r\n                <li");

WriteLiteral(" id=\"Biography\"");

WriteAttribute("class", Tuple.Create(" class=\"", 1367), Tuple.Create("\"", 1399)
            
            #line 27 "..\..\Views\MyProfile\Index.cshtml"
, Tuple.Create(Tuple.Create("", 1375), Tuple.Create<System.Object, System.Int32>(ViewBag.ActiveBiography
            
            #line default
            #line hidden
, 1375), false)
);

WriteLiteral("><a");

WriteAttribute("aria-expanded", Tuple.Create(" aria-expanded=\"", 1403), Tuple.Create("\"", 1437)
            
            #line 27 "..\..\Views\MyProfile\Index.cshtml"
      , Tuple.Create(Tuple.Create("", 1419), Tuple.Create<System.Object, System.Int32>(ViewBag.Biography
            
            #line default
            #line hidden
, 1419), false)
);

WriteLiteral(" href=\"#biography\"");

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(">");

            
            #line 27 "..\..\Views\MyProfile\Index.cshtml"
                                                                                                                                         Write(Resources.Resources.Biography);

            
            #line default
            #line hidden
WriteLiteral("</a></li>\r\n                <li");

WriteLiteral(" id=\"ContactInfo\"");

WriteAttribute("class", Tuple.Create(" class=\"", 1552), Tuple.Create("\"", 1586)
            
            #line 28 "..\..\Views\MyProfile\Index.cshtml"
, Tuple.Create(Tuple.Create("", 1560), Tuple.Create<System.Object, System.Int32>(ViewBag.ActiveContactInfo
            
            #line default
            #line hidden
, 1560), false)
);

WriteLiteral("><a");

WriteAttribute("aria-expanded", Tuple.Create(" aria-expanded=\"", 1590), Tuple.Create("\"", 1626)
            
            #line 28 "..\..\Views\MyProfile\Index.cshtml"
          , Tuple.Create(Tuple.Create("", 1606), Tuple.Create<System.Object, System.Int32>(ViewBag.ContactInfo
            
            #line default
            #line hidden
, 1606), false)
);

WriteLiteral(" href=\"#contact-info\"");

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(">");

            
            #line 28 "..\..\Views\MyProfile\Index.cshtml"
                                                                                                                                                  Write(Resources.Resources.ContactInfo);

            
            #line default
            #line hidden
WriteLiteral("</a></li>\r\n            </ul>\r\n            <div");

WriteLiteral(" class=\"tab-content margin-top-20\"");

WriteLiteral(">\r\n                <div");

WriteAttribute("class", Tuple.Create(" class=\"", 1802), Tuple.Create("\"", 1853)
, Tuple.Create(Tuple.Create("", 1810), Tuple.Create("tab-pane", 1810), true)
, Tuple.Create(Tuple.Create(" ", 1818), Tuple.Create("fade", 1819), true)
            
            #line 31 "..\..\Views\MyProfile\Index.cshtml"
, Tuple.Create(Tuple.Create(" ", 1823), Tuple.Create<System.Object, System.Int32>(ViewBag.ActiveInPersonalInfo
            
            #line default
            #line hidden
, 1824), false)
);

WriteLiteral(" id=\"personal-info\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 32 "..\..\Views\MyProfile\Index.cshtml"
               Write(Html.Partial("PersonalInfo", Model));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <!-- /PERSONAL INFO TAB -->\r\n          " +
"      <!-- PersonalPhoto TAB -->\r\n                <div");

WriteAttribute("class", Tuple.Create(" class=\"", 2067), Tuple.Create("\"", 2119)
, Tuple.Create(Tuple.Create("", 2075), Tuple.Create("tab-pane", 2075), true)
, Tuple.Create(Tuple.Create(" ", 2083), Tuple.Create("fade", 2084), true)
            
            #line 36 "..\..\Views\MyProfile\Index.cshtml"
, Tuple.Create(Tuple.Create(" ", 2088), Tuple.Create<System.Object, System.Int32>(ViewBag.ActiveInPersonalPhoto
            
            #line default
            #line hidden
, 2089), false)
);

WriteLiteral(" id=\"personal-photo\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 37 "..\..\Views\MyProfile\Index.cshtml"
               Write(Html.Partial("PersonalPhoto", Model));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <!-- /PersonalPhoto TAB -->\r\n          " +
"      <!-- AcademicInfo TAB -->\r\n                <div");

WriteAttribute("class", Tuple.Create(" class=\"", 2334), Tuple.Create("\"", 2385)
, Tuple.Create(Tuple.Create("", 2342), Tuple.Create("tab-pane", 2342), true)
, Tuple.Create(Tuple.Create(" ", 2350), Tuple.Create("fade", 2351), true)
            
            #line 41 "..\..\Views\MyProfile\Index.cshtml"
, Tuple.Create(Tuple.Create(" ", 2355), Tuple.Create<System.Object, System.Int32>(ViewBag.ActiveInAcademicInfo
            
            #line default
            #line hidden
, 2356), false)
);

WriteLiteral(" id=\"academic-info\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 42 "..\..\Views\MyProfile\Index.cshtml"
               Write(Html.Partial("AcademicInfo", Model));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <!-- /AcademicInfo TAB -->\r\n           " +
"     <!-- Biography TAB -->\r\n                <div");

WriteAttribute("class", Tuple.Create(" class=\"", 2594), Tuple.Create("\"", 2642)
, Tuple.Create(Tuple.Create("", 2602), Tuple.Create("tab-pane", 2602), true)
, Tuple.Create(Tuple.Create(" ", 2610), Tuple.Create("fade", 2611), true)
            
            #line 46 "..\..\Views\MyProfile\Index.cshtml"
, Tuple.Create(Tuple.Create(" ", 2615), Tuple.Create<System.Object, System.Int32>(ViewBag.ActiveInBiography
            
            #line default
            #line hidden
, 2616), false)
);

WriteLiteral(" id=\"biography\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 47 "..\..\Views\MyProfile\Index.cshtml"
               Write(Html.Partial("Biography", Model));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <!-- /Biography TAB -->\r\n              " +
"  <!-- ContactInfo TAB -->\r\n                <div");

WriteAttribute("class", Tuple.Create(" class=\"", 2843), Tuple.Create("\"", 2893)
, Tuple.Create(Tuple.Create("", 2851), Tuple.Create("tab-pane", 2851), true)
, Tuple.Create(Tuple.Create(" ", 2859), Tuple.Create("fade", 2860), true)
            
            #line 51 "..\..\Views\MyProfile\Index.cshtml"
, Tuple.Create(Tuple.Create(" ", 2864), Tuple.Create<System.Object, System.Int32>(ViewBag.ActiveInContactInfo
            
            #line default
            #line hidden
, 2865), false)
);

WriteLiteral(" id=\"contact-info\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 52 "..\..\Views\MyProfile\Index.cshtml"
               Write(Html.Partial("ContactInfo", Model));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <!-- /ContactInfo TAB -->\r\n            " +
"</div>\r\n        </div>\r\n        <!-- LEFT -->\r\n");

WriteLiteral("        ");

            
            #line 58 "..\..\Views\MyProfile\Index.cshtml"
   Write(Html.Partial("_MyProfile"));

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n</section>\r\n");

            
            #line 61 "..\..\Views\MyProfile\Index.cshtml"
 if (ViewBag.StatusMessage == "Success")
{

            
            #line default
            #line hidden
WriteLiteral("    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(">\r\n        $(document).ready(function () {\r\n            toastr.options.positionCl" +
"ass = \'toast-top-center\'\r\n            toastr.success(\'");

            
            #line 66 "..\..\Views\MyProfile\Index.cshtml"
                       Write(Resources.Resources.Saved);

            
            #line default
            #line hidden
WriteLiteral("\')\r\n        });\r\n    </script>\r\n");

            
            #line 69 "..\..\Views\MyProfile\Index.cshtml"
}

            
            #line default
            #line hidden
            
            #line 70 "..\..\Views\MyProfile\Index.cshtml"
 if (ViewBag.StatusMessage == "Error")
{

            
            #line default
            #line hidden
WriteLiteral("    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(">\r\n        $(document).ready(function () {\r\n            toastr.options.positionCl" +
"ass = \'toast-top-center\'\r\n            toastr.error(\'");

            
            #line 75 "..\..\Views\MyProfile\Index.cshtml"
                     Write(Resources.Resources.Error);

            
            #line default
            #line hidden
WriteLiteral("\')\r\n        });\r\n    </script>\r\n");

            
            #line 78 "..\..\Views\MyProfile\Index.cshtml"
}

            
            #line default
            #line hidden
            
            #line 79 "..\..\Views\MyProfile\Index.cshtml"
 if (Model == null || Model.Id == 0)
{
    
            
            #line default
            #line hidden
            
            #line 81 "..\..\Views\MyProfile\Index.cshtml"
                                   
    
            
            #line default
            #line hidden
DefineSection("Scripts", () => {

WriteLiteral("\r\n<script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(">\r\n        $(\"#tabbed-list > li\").addClass(\'disabled\');\r\n        $(\"#PersonalPhot" +
"o\").click(function (e) {\r\n            e.preventDefault();     // stop the defaul" +
"t action if u need\r\n            e.stopPropagation();\r\n            alert(\'");

            
            #line 88 "..\..\Views\MyProfile\Index.cshtml"
              Write(Resources.Resources.FillOutPersonalInfo);

            
            #line default
            #line hidden
WriteLiteral("\');\r\n        });\r\n        $(\"#AcademicInfo\").click(function (e) {\r\n            e." +
"preventDefault();     // stop the default action if u need\r\n            e.stopPr" +
"opagation();\r\n            alert(\'");

            
            #line 93 "..\..\Views\MyProfile\Index.cshtml"
              Write(Resources.Resources.FillOutPersonalInfo);

            
            #line default
            #line hidden
WriteLiteral("\');\r\n        });\r\n        $(\"#Biography\").click(function (e) {\r\n            e.pre" +
"ventDefault();     // stop the default action if u need\r\n            e.stopPropa" +
"gation();\r\n            alert(\'");

            
            #line 98 "..\..\Views\MyProfile\Index.cshtml"
              Write(Resources.Resources.FillOutPersonalInfo);

            
            #line default
            #line hidden
WriteLiteral("\');\r\n        });\r\n        $(\"#ContactInfo\").click(function (e) {\r\n            e.p" +
"reventDefault();     // stop the default action if u need\r\n            e.stopPro" +
"pagation();\r\n            alert(\'");

            
            #line 103 "..\..\Views\MyProfile\Index.cshtml"
              Write(Resources.Resources.FillOutPersonalInfo);

            
            #line default
            #line hidden
WriteLiteral("\');\r\n        });\r\n</script>\r\n    ");

});

            
            #line 106 "..\..\Views\MyProfile\Index.cshtml"
     
}
            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591