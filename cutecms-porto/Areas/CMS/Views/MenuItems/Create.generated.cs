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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/CMS/Views/MenuItems/Create.cshtml")]
    public partial class _Areas_CMS_Views_MenuItems_Create_cshtml : System.Web.Mvc.WebViewPage<cutecms_porto.Areas.CMS.Models.DBModel.MenuItem>
    {
        public _Areas_CMS_Views_MenuItems_Create_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Areas\CMS\Views\MenuItems\Create.cshtml"
  
    ViewBag.MainTitle = Resources.Resources.MenuItem;
    ViewBag.Title = Resources.Resources.Create;

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 6 "..\..\Areas\CMS\Views\MenuItems\Create.cshtml"
 using (Html.BeginForm())
{
    
            
            #line default
            #line hidden
            
            #line 8 "..\..\Areas\CMS\Views\MenuItems\Create.cshtml"
Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 8 "..\..\Areas\CMS\Views\MenuItems\Create.cshtml"
                            
    
            
            #line default
            #line hidden
            
            #line 9 "..\..\Areas\CMS\Views\MenuItems\Create.cshtml"
Write(Html.HiddenFor(model => model.MenuId));

            
            #line default
            #line hidden
            
            #line 9 "..\..\Areas\CMS\Views\MenuItems\Create.cshtml"
                                          
    
            
            #line default
            #line hidden
            
            #line 10 "..\..\Areas\CMS\Views\MenuItems\Create.cshtml"
Write(Html.HiddenFor(model => model.StatusId));

            
            #line default
            #line hidden
            
            #line 10 "..\..\Areas\CMS\Views\MenuItems\Create.cshtml"
                                            

            
            #line default
            #line hidden
WriteLiteral("    <div");

WriteLiteral(" class=\"form-horizontal\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 13 "..\..\Areas\CMS\Views\MenuItems\Create.cshtml"
       Write(Html.LabelFor(model => model.MenuId, new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 15 "..\..\Areas\CMS\Views\MenuItems\Create.cshtml"
           Write(Html.TextBox("MenuCode", null, htmlAttributes: new { @class = "form-control", @disabled = "disabled" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 19 "..\..\Areas\CMS\Views\MenuItems\Create.cshtml"
       Write(Html.LabelFor(model => model.LanguageId, new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 21 "..\..\Areas\CMS\Views\MenuItems\Create.cshtml"
           Write(Html.DropDownList("LanguageId", null, Resources.Resources.ChooseLanguage, htmlAttributes: new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 22 "..\..\Areas\CMS\Views\MenuItems\Create.cshtml"
           Write(Html.ValidationMessageFor(model => model.LanguageId, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 26 "..\..\Areas\CMS\Views\MenuItems\Create.cshtml"
       Write(Html.LabelFor(model => model.ParentId, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 28 "..\..\Areas\CMS\Views\MenuItems\Create.cshtml"
           Write(Html.DropDownList("ParentId", null, Resources.Resources.ChooseParentMenuItem, htmlAttributes: new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 29 "..\..\Areas\CMS\Views\MenuItems\Create.cshtml"
           Write(Html.ValidationMessageFor(model => model.ParentId, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 33 "..\..\Areas\CMS\Views\MenuItems\Create.cshtml"
       Write(Html.LabelFor(model => model.Name, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 35 "..\..\Areas\CMS\Views\MenuItems\Create.cshtml"
           Write(Html.EditorFor(model => model.Name, new { htmlAttributes = new { @class = "form-control" } }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 36 "..\..\Areas\CMS\Views\MenuItems\Create.cshtml"
           Write(Html.ValidationMessageFor(model => model.Name, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 40 "..\..\Areas\CMS\Views\MenuItems\Create.cshtml"
       Write(Html.LabelFor(model => model.CssClass, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 42 "..\..\Areas\CMS\Views\MenuItems\Create.cshtml"
           Write(Html.EditorFor(model => model.CssClass, new { htmlAttributes = new { @class = "form-control" } }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 43 "..\..\Areas\CMS\Views\MenuItems\Create.cshtml"
           Write(Html.ValidationMessageFor(model => model.CssClass, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 47 "..\..\Areas\CMS\Views\MenuItems\Create.cshtml"
       Write(Html.LabelFor(model => model.Ordinal, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 49 "..\..\Areas\CMS\Views\MenuItems\Create.cshtml"
           Write(Html.EditorFor(model => model.Ordinal, new { htmlAttributes = new { @class = "form-control" } }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 50 "..\..\Areas\CMS\Views\MenuItems\Create.cshtml"
           Write(Html.ValidationMessageFor(model => model.Ordinal, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 54 "..\..\Areas\CMS\Views\MenuItems\Create.cshtml"
       Write(Html.LabelFor(model => model.Visible, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 56 "..\..\Areas\CMS\Views\MenuItems\Create.cshtml"
           Write(Html.CheckBoxFor(model => model.Visible, new { @class = "js-switch" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 57 "..\..\Areas\CMS\Views\MenuItems\Create.cshtml"
           Write(Html.ValidationMessageFor(model => model.Visible, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 61 "..\..\Areas\CMS\Views\MenuItems\Create.cshtml"
       Write(Html.LabelFor(model => model.IsParent, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 63 "..\..\Areas\CMS\Views\MenuItems\Create.cshtml"
           Write(Html.CheckBoxFor(model => model.IsParent, new { @class = "js-switch"}));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 64 "..\..\Areas\CMS\Views\MenuItems\Create.cshtml"
           Write(Html.ValidationMessageFor(model => model.IsParent, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(" id=\"UrlDiv\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 68 "..\..\Areas\CMS\Views\MenuItems\Create.cshtml"
       Write(Html.LabelFor(model => model.Path, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 70 "..\..\Areas\CMS\Views\MenuItems\Create.cshtml"
           Write(Html.EditorFor(model => model.Path, new { htmlAttributes = new { @class = "form-control" } }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 71 "..\..\Areas\CMS\Views\MenuItems\Create.cshtml"
           Write(Html.ValidationMessageFor(model => model.Path, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"col-md-offset-2 col-md-10\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" type=\"submit\"");

WriteAttribute("value", Tuple.Create(" value=", 4289), Tuple.Create("", 4323)
            
            #line 76 "..\..\Areas\CMS\Views\MenuItems\Create.cshtml"
, Tuple.Create(Tuple.Create("", 4296), Tuple.Create<System.Object, System.Int32>(Resources.Resources.Create
            
            #line default
            #line hidden
, 4296), false)
);

WriteLiteral(" class=\"btn btn-primary\"");

WriteLiteral(" />\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"col-md-offset-2 col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 81 "..\..\Areas\CMS\Views\MenuItems\Create.cshtml"
           Write(Html.ValidationSummary(false, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n");

            
            #line 85 "..\..\Areas\CMS\Views\MenuItems\Create.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("<div>\r\n");

WriteLiteral("    ");

            
            #line 87 "..\..\Areas\CMS\Views\MenuItems\Create.cshtml"
Write(Html.ActionLink(Resources.Resources.BackToList, "Index", new { id = Model.MenuId }));

            
            #line default
            #line hidden
WriteLiteral("\r\n</div>\r\n");

DefineSection("Scripts", () => {

WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 90 "..\..\Areas\CMS\Views\MenuItems\Create.cshtml"
Write(Scripts.Render("~/bundles/jqueryval"));

            
            #line default
            #line hidden
WriteLiteral("\r\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(">\r\n    $(document).ready(function () {\r\n        //Dropdownlist Selectedchange eve" +
"nt\r\n        $(\"#LanguageId\").change(function () {\r\n            $.ajax({\r\n       " +
"         type: \'POST\',\r\n                url: \'");

            
            #line 97 "..\..\Areas\CMS\Views\MenuItems\Create.cshtml"
                 Write(Url.Action("GetMenuItemsClientSide"));

            
            #line default
            #line hidden
WriteLiteral(@"', // we are calling json method
                dataType: 'json',
                data: { languageId: $(""#LanguageId"").val(), id: $(""#MenuId"").val() },
                success: function (MenuItems) {
                    // MenuItems contains the JSON formatted list
                    // of MenuItems passed from the controller
                    $(""#ParentId"").empty();
                    $.each(MenuItems, function (i, MenuItem) {
                        $(""#ParentId"").append('<option value=""' + MenuItem.Value + '"">' + MenuItem.Text + '</option>');
                    }); // here we are adding option for MenuItems
                },
                error: function (ex) {
                    $(""#ParentId"").empty();
                    //alert('Failed to retrieve MenuItems.' + ex);
                }
            });
            return false;
        })
    });
    </script>
");

});

        }
    }
}
#pragma warning restore 1591
