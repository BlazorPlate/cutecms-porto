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
    
    #line 3 "..\..\Views\Staff\Departments.cshtml"
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
    
    #line 2 "..\..\Views\Staff\Departments.cshtml"
    using cutecms_porto.Areas.Identity.Models.DBModel;
    
    #line default
    #line hidden
    using cutecms_porto.Helpers;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Staff/Departments.cshtml")]
    public partial class _Views_Staff_Departments_cshtml : System.Web.Mvc.WebViewPage<cutecms_porto.Areas.Identity.Models.DBModel.Employee>
    {
        public _Views_Staff_Departments_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("    ");

WriteLiteral("    ");

            
            #line 4 "..\..\Views\Staff\Departments.cshtml"
      
        ViewBag.Title = @Resources.Resources.Departments;
        IdentityEntities db = new IdentityEntities();
        var empInDepts = db.EmpInDepts.Where(e => e.Employee.TranslationId == Model.TranslationId);
    
            
            #line default
            #line hidden
WriteLiteral("\r\n    <!-- RIGHT -->\r\n    <form");

WriteLiteral(" role=\"form\"");

WriteLiteral(" action=\"#\"");

WriteLiteral(" method=\"post\"");

WriteLiteral(">\r\n        <table");

WriteLiteral(" class=\"table\"");

WriteLiteral(">\r\n            <tr>\r\n                <th>\r\n");

WriteLiteral("                    ");

            
            #line 14 "..\..\Views\Staff\Departments.cshtml"
               Write(Resources.Resources.Department);

            
            #line default
            #line hidden
WriteLiteral("\r\n                </th>\r\n                <th>\r\n");

WriteLiteral("                    ");

            
            #line 17 "..\..\Views\Staff\Departments.cshtml"
               Write(Resources.Resources.Occupation);

            
            #line default
            #line hidden
WriteLiteral("\r\n                </th>\r\n                <th>\r\n");

WriteLiteral("                    ");

            
            #line 20 "..\..\Views\Staff\Departments.cshtml"
               Write(Resources.Resources.JobType);

            
            #line default
            #line hidden
WriteLiteral("\r\n                </th>\r\n                <th></th>\r\n            </tr>\r\n");

            
            #line 24 "..\..\Views\Staff\Departments.cshtml"
            
            
            #line default
            #line hidden
            
            #line 24 "..\..\Views\Staff\Departments.cshtml"
             foreach (var item in empInDepts)
            {

            
            #line default
            #line hidden
WriteLiteral("                <tr>\r\n                    <td>\r\n");

WriteLiteral("                        ");

            
            #line 28 "..\..\Views\Staff\Departments.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Department.DepartmentTerms.Where(d => d.Language.CultureName.Trim().Equals(Thread.CurrentThread.CurrentCulture.Name)).FirstOrDefault().Value));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n");

WriteLiteral("                        ");

            
            #line 31 "..\..\Views\Staff\Departments.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Occupation.OccupationTerms.Where(o => o.Language.CultureName.Trim().Equals(Thread.CurrentThread.CurrentCulture.Name)).FirstOrDefault().Value));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n");

WriteLiteral("                        ");

            
            #line 34 "..\..\Views\Staff\Departments.cshtml"
                   Write(Html.DisplayFor(modelItem => item.EmployeeType.EmployeeTypeTerms.Where(e => e.Language.CultureName.Trim().Equals(Thread.CurrentThread.CurrentCulture.Name)).FirstOrDefault().Value));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");

            
            #line 37 "..\..\Views\Staff\Departments.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("        </table>\r\n    </form>");

        }
    }
}
#pragma warning restore 1591