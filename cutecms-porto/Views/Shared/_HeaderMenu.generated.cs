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
    
    #line 2 "..\..\Views\Shared\_HeaderMenu.cshtml"
    using System.Globalization;
    
    #line default
    #line hidden
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    
    #line 3 "..\..\Views\Shared\_HeaderMenu.cshtml"
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
    
    #line 1 "..\..\Views\Shared\_HeaderMenu.cshtml"
    using cutecms_porto.Areas.CMS.Models.DBModel;
    
    #line default
    #line hidden
    using cutecms_porto.Helpers;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/_HeaderMenu.cshtml")]
    public partial class _Views_Shared__HeaderMenu_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {

#line 15 "..\..\Views\Shared\_HeaderMenu.cshtml"
public System.Web.WebPages.HelperResult GetTreeView(IEnumerable<MenuItem> menuItems, int? parentID)
{
#line default
#line hidden
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {

#line 16 "..\..\Views\Shared\_HeaderMenu.cshtml"
 
foreach (var item in menuItems.Where(m => m.ParentId.Equals(parentID)).OrderBy(m => m.Ordinal))
{

    var submenu = menuItems.Where(s => s.ParentId.Equals(item.Id)).Count();
    if (item.IsParent)
    {
        if (submenu > 0 && item.MenuItem1 == null)
        {


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "                <li");

WriteLiteralTo(__razor_helper_writer, " class=\"dropdown\"");

WriteLiteralTo(__razor_helper_writer, ">\r\n                    <a");

WriteLiteralTo(__razor_helper_writer, " class=\"dropdown-toggle\"");

WriteAttributeTo(__razor_helper_writer, "href", Tuple.Create(" href=\"", 1012), Tuple.Create("\"", 1029)

#line 26 "..\..\Views\Shared\_HeaderMenu.cshtml"
, Tuple.Create(Tuple.Create("", 1019), Tuple.Create<System.Object, System.Int32>(item.Path

#line default
#line hidden
, 1019), false)
);

WriteLiteralTo(__razor_helper_writer, ">");


#line 26 "..\..\Views\Shared\_HeaderMenu.cshtml"
                                   WriteTo(__razor_helper_writer, item.Name);


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "</a>\r\n");


#line 27 "..\..\Views\Shared\_HeaderMenu.cshtml"
                    

#line default
#line hidden

#line 27 "..\..\Views\Shared\_HeaderMenu.cshtml"
                     if (submenu > 0)
                    {


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "                        <ul");

WriteLiteralTo(__razor_helper_writer, " class=\"dropdown-menu\"");

WriteLiteralTo(__razor_helper_writer, ">\r\n                            ");

WriteLiteralTo(__razor_helper_writer, "\r\n");

WriteLiteralTo(__razor_helper_writer, "                            ");


#line 31 "..\..\Views\Shared\_HeaderMenu.cshtml"
WriteTo(__razor_helper_writer, GetTreeView(menuItems, item.Id));


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "\r\n                        </ul>\r\n");


#line 33 "..\..\Views\Shared\_HeaderMenu.cshtml"
                    }


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "                </li>\r\n");


#line 35 "..\..\Views\Shared\_HeaderMenu.cshtml"

            }
            else
            {


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "                <li");

WriteLiteralTo(__razor_helper_writer, " class=\"dropdown-submenu\"");

WriteLiteralTo(__razor_helper_writer, ">\r\n                    <a");

WriteAttributeTo(__razor_helper_writer, "href", Tuple.Create(" href=\"", 1497), Tuple.Create("\"", 1514)

#line 40 "..\..\Views\Shared\_HeaderMenu.cshtml"
, Tuple.Create(Tuple.Create("", 1504), Tuple.Create<System.Object, System.Int32>(item.Path

#line default
#line hidden
, 1504), false)
);

WriteLiteralTo(__razor_helper_writer, ">");


#line 40 "..\..\Views\Shared\_HeaderMenu.cshtml"
           WriteTo(__razor_helper_writer, item.Name);


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "</a>\r\n\r\n");


#line 42 "..\..\Views\Shared\_HeaderMenu.cshtml"
                    

#line default
#line hidden

#line 42 "..\..\Views\Shared\_HeaderMenu.cshtml"
                     if (submenu > 0)
                    {


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "                        <ul");

WriteLiteralTo(__razor_helper_writer, " class=\"dropdown-menu\"");

WriteLiteralTo(__razor_helper_writer, ">\r\n                            ");

WriteLiteralTo(__razor_helper_writer, "\r\n");

WriteLiteralTo(__razor_helper_writer, "                            ");


#line 46 "..\..\Views\Shared\_HeaderMenu.cshtml"
WriteTo(__razor_helper_writer, GetTreeView(menuItems, item.Id));


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "\r\n                        </ul>\r\n");


#line 48 "..\..\Views\Shared\_HeaderMenu.cshtml"
                    }


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "                </li>\r\n");


#line 50 "..\..\Views\Shared\_HeaderMenu.cshtml"
        }
    }
    else
    {


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "            <li>\r\n                <a");

WriteAttributeTo(__razor_helper_writer, "href", Tuple.Create(" href=", 1936), Tuple.Create("", 1952)

#line 55 "..\..\Views\Shared\_HeaderMenu.cshtml"
, Tuple.Create(Tuple.Create("", 1942), Tuple.Create<System.Object, System.Int32>(item.Path

#line default
#line hidden
, 1942), false)
);

WriteLiteralTo(__razor_helper_writer, ">");


#line 55 "..\..\Views\Shared\_HeaderMenu.cshtml"
     WriteTo(__razor_helper_writer, item.Name);


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "</a>\r\n            </li>\r\n");


#line 57 "..\..\Views\Shared\_HeaderMenu.cshtml"

    }
}


#line default
#line hidden
});

#line 60 "..\..\Views\Shared\_HeaderMenu.cshtml"
}
#line default
#line hidden

        public _Views_Shared__HeaderMenu_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 4 "..\..\Views\Shared\_HeaderMenu.cshtml"
  
    int count = 0;
    CMSEntities db = new CMSEntities();
    IEnumerable<MenuItem> menuItems = db.MenuItems.Include("Status").Include("Menu").Include("Language").Where(m => m.Menu.TenantId.Trim().Equals(Tenant.TenantId) && m.Menu.Code.Trim().Equals("header") && m.Visible && m.Language.CultureName.Trim().Equals(Thread.CurrentThread.CurrentCulture.Name));
    count = menuItems.Count();

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

            
            #line 11 "..\..\Views\Shared\_HeaderMenu.cshtml"
 if (menuItems != null && count > 0)
{
    
            
            #line default
            #line hidden
            
            #line 13 "..\..\Views\Shared\_HeaderMenu.cshtml"
Write(GetTreeView(menuItems, null));

            
            #line default
            #line hidden
            
            #line 13 "..\..\Views\Shared\_HeaderMenu.cshtml"
                                 
}

            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591
