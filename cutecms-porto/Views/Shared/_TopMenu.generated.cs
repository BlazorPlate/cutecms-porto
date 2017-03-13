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
    
    #line 3 "..\..\Views\Shared\_TopMenu.cshtml"
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
    
    #line 1 "..\..\Views\Shared\_TopMenu.cshtml"
    using cutecms_porto.Areas.CMS.Models.DBModel;
    
    #line default
    #line hidden
    
    #line 2 "..\..\Views\Shared\_TopMenu.cshtml"
    using cutecms_porto.Areas.Config.Models.DBModel;
    
    #line default
    #line hidden
    using cutecms_porto.Helpers;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/_TopMenu.cshtml")]
    public partial class _Views_Shared__TopMenu_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Views_Shared__TopMenu_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 4 "..\..\Views\Shared\_TopMenu.cshtml"
  
    CMSEntities db = new CMSEntities();
    IEnumerable<MenuItem> topMenuItems = db.MenuItems.Include("Status").Include("Menu").Include("Language").Where(m => m.Menu.TenantId.Trim().Equals(Tenant.TenantId) && m.Menu.Code.Trim().Equals("top-menu") && m.Status.Code.Trim().Equals("published") && m.Language.CultureName.Trim().Equals(Thread.CurrentThread.CurrentCulture.Name)).OrderBy(o => o.Ordinal);
    var organizations = (List<Organization>)HttpRuntime.Cache["Organizations"];
    var organization = organizations.Where(o => o.Language.CultureName.Trim().Equals(Thread.CurrentThread.CurrentCulture.Name)).FirstOrDefault();

            
            #line default
            #line hidden
WriteLiteral("\r\n<nav");

WriteLiteral(" class=\"header-nav-top\"");

WriteLiteral(" style=\"margin-left:0px;\"");

WriteLiteral(">\r\n    <ul");

WriteLiteral(" class=\"nav nav-pills\"");

WriteLiteral(">\r\n");

            
            #line 12 "..\..\Views\Shared\_TopMenu.cshtml"
        
            
            #line default
            #line hidden
            
            #line 12 "..\..\Views\Shared\_TopMenu.cshtml"
         if (CultureHelper.IsRighToLeft())
            {
                foreach (var item in topMenuItems)
                {

            
            #line default
            #line hidden
WriteLiteral("                <li");

WriteLiteral(" class=\"hidden-xs\"");

WriteLiteral(">\r\n                    <a");

WriteAttribute("href", Tuple.Create(" href=\"", 1037), Tuple.Create("\"", 1054)
            
            #line 17 "..\..\Views\Shared\_TopMenu.cshtml"
, Tuple.Create(Tuple.Create("", 1044), Tuple.Create<System.Object, System.Int32>(item.Path
            
            #line default
            #line hidden
, 1044), false)
);

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-angle-left\"");

WriteLiteral("></i> ");

            
            #line 17 "..\..\Views\Shared\_TopMenu.cshtml"
                                                                     Write(item.Name);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n                </li>\r\n");

            
            #line 19 "..\..\Views\Shared\_TopMenu.cshtml"
            }
        }
        else
        {
            foreach (var item in topMenuItems)
            {

            
            #line default
            #line hidden
WriteLiteral("                <li");

WriteLiteral(" class=\"hidden-xs\"");

WriteLiteral(">\r\n                    <a");

WriteAttribute("href", Tuple.Create(" href=\"", 1304), Tuple.Create("\"", 1321)
            
            #line 26 "..\..\Views\Shared\_TopMenu.cshtml"
, Tuple.Create(Tuple.Create("", 1311), Tuple.Create<System.Object, System.Int32>(item.Path
            
            #line default
            #line hidden
, 1311), false)
);

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-angle-right\"");

WriteLiteral("></i> ");

            
            #line 26 "..\..\Views\Shared\_TopMenu.cshtml"
                                                                      Write(item.Name);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n                </li>\r\n");

            
            #line 28 "..\..\Views\Shared\_TopMenu.cshtml"
            }
        }

            
            #line default
            #line hidden
WriteLiteral("    </ul>\r\n</nav>\r\n");

            
            #line 32 "..\..\Views\Shared\_TopMenu.cshtml"
 if (organization != null)
{

            
            #line default
            #line hidden
WriteLiteral("    <ul");

WriteLiteral(" class=\"header-social-icons social-icons hidden-xs\"");

WriteLiteral(">\r\n");

            
            #line 35 "..\..\Views\Shared\_TopMenu.cshtml"
        
            
            #line default
            #line hidden
            
            #line 35 "..\..\Views\Shared\_TopMenu.cshtml"
         foreach (var item in organization.SocialNetworks.OrderBy(s => s.Ordinal))
        {

            
            #line default
            #line hidden
WriteLiteral("            <li");

WriteAttribute("class", Tuple.Create(" class=\"", 1643), Tuple.Create("\"", 1674)
, Tuple.Create(Tuple.Create("", 1651), Tuple.Create("social-icons-", 1651), true)
            
            #line 37 "..\..\Views\Shared\_TopMenu.cshtml"
, Tuple.Create(Tuple.Create("", 1664), Tuple.Create<System.Object, System.Int32>(item.Code
            
            #line default
            #line hidden
, 1664), false)
);

WriteLiteral("><a");

WriteAttribute("href", Tuple.Create(" href=\"", 1678), Tuple.Create("\"", 1694)
            
            #line 37 "..\..\Views\Shared\_TopMenu.cshtml"
, Tuple.Create(Tuple.Create("", 1685), Tuple.Create<System.Object, System.Int32>(item.Url
            
            #line default
            #line hidden
, 1685), false)
);

WriteLiteral(" target=\"_blank\"");

WriteAttribute("title", Tuple.Create(" title=\"", 1711), Tuple.Create("\"", 1729)
            
            #line 37 "..\..\Views\Shared\_TopMenu.cshtml"
           , Tuple.Create(Tuple.Create("", 1719), Tuple.Create<System.Object, System.Int32>(item.Name
            
            #line default
            #line hidden
, 1719), false)
);

WriteLiteral("><i");

WriteAttribute("class", Tuple.Create(" class=\"", 1733), Tuple.Create("\"", 1758)
, Tuple.Create(Tuple.Create("", 1741), Tuple.Create("fa", 1741), true)
            
            #line 37 "..\..\Views\Shared\_TopMenu.cshtml"
                                   , Tuple.Create(Tuple.Create(" ", 1743), Tuple.Create<System.Object, System.Int32>(item.CssClass
            
            #line default
            #line hidden
, 1744), false)
);

WriteLiteral("></i></a></li>\r\n");

            
            #line 38 "..\..\Views\Shared\_TopMenu.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("    </ul>\r\n");

            
            #line 40 "..\..\Views\Shared\_TopMenu.cshtml"
}
            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591