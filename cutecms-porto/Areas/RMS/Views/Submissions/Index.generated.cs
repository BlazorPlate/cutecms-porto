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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/RMS/Views/Submissions/Index.cshtml")]
    public partial class _Areas_RMS_Views_Submissions_Index_cshtml : System.Web.Mvc.WebViewPage<IEnumerable<cutecms_porto.Areas.RMS.Models.SubmissionViewModel>>
    {
        public _Areas_RMS_Views_Submissions_Index_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Areas\RMS\Views\Submissions\Index.cshtml"
  
    ViewBag.MainTitle = Resources.Resources.Submissions;
    ViewBag.Title = Resources.Resources.Index;

            
            #line default
            #line hidden
WriteLiteral("\r\n<div>");

            
            #line 6 "..\..\Areas\RMS\Views\Submissions\Index.cshtml"
Write(Html.ActionLink(Resources.Resources.DownloadApplications, "ExportApplicants", null, new { @class = "btn btn-danger" }));

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n");

DefineSection("styles", () => {

WriteLiteral("\r\n    <link");

WriteLiteral(" href=\"https://cdn.datatables.net/1.10.12/css/jquery.dataTables.min.css\"");

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n    <link");

WriteLiteral(" href=\"https://cdn.datatables.net/buttons/1.2.1/css/buttons.dataTables.min.css\"");

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n");

});

WriteLiteral("<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"col-sm-12\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"white-box\"");

WriteLiteral(">\r\n            ");

WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"table-responsive\"");

WriteLiteral(">\r\n                <table");

WriteLiteral(" id=\"submissionTable\"");

WriteLiteral(" class=\"display nowrap\"");

WriteLiteral(" cellspacing=\"0\"");

WriteLiteral(" width=\"100%\"");

WriteLiteral(">\r\n                    <thead>\r\n                        <tr>\r\n                   " +
"         <th>");

            
            #line 20 "..\..\Areas\RMS\Views\Submissions\Index.cshtml"
                           Write(Html.DisplayNameFor(model => model.Id));

            
            #line default
            #line hidden
WriteLiteral("</th>\r\n                            <th>");

            
            #line 21 "..\..\Areas\RMS\Views\Submissions\Index.cshtml"
                           Write(Html.DisplayNameFor(model => model.ApplicantFullName));

            
            #line default
            #line hidden
WriteLiteral("</th>\r\n                            <th>");

            
            #line 22 "..\..\Areas\RMS\Views\Submissions\Index.cshtml"
                           Write(Html.DisplayNameFor(model => model.SubmissionDate));

            
            #line default
            #line hidden
WriteLiteral("</th>\r\n                            <th");

WriteLiteral(" class=\"select-filter\"");

WriteLiteral(">");

            
            #line 23 "..\..\Areas\RMS\Views\Submissions\Index.cshtml"
                                                 Write(Html.DisplayNameFor(model => model.VacancyTitle));

            
            #line default
            #line hidden
WriteLiteral("</th>\r\n                            <th");

WriteLiteral(" class=\"select-filter\"");

WriteLiteral(">");

            
            #line 24 "..\..\Areas\RMS\Views\Submissions\Index.cshtml"
                                                 Write(Html.DisplayNameFor(model => model.Department));

            
            #line default
            #line hidden
WriteLiteral("</th>\r\n                            <th>");

            
            #line 25 "..\..\Areas\RMS\Views\Submissions\Index.cshtml"
                           Write(Resources.Resources.Actions);

            
            #line default
            #line hidden
WriteLiteral(@"</th>
                        </tr>
                    </thead>
                    <tfoot>
                        <tr>
                            <th></th>
                            <th></th>
                            <th></th>
                            <th>");

            
            #line 33 "..\..\Areas\RMS\Views\Submissions\Index.cshtml"
                           Write(Html.DisplayNameFor(model => model.VacancyTitle));

            
            #line default
            #line hidden
WriteLiteral("</th>\r\n                            <th>");

            
            #line 34 "..\..\Areas\RMS\Views\Submissions\Index.cshtml"
                           Write(Html.DisplayNameFor(model => model.Department));

            
            #line default
            #line hidden
WriteLiteral("</th>\r\n                            <th></th>\r\n                        </tr>\r\n    " +
"                </tfoot>\r\n                </table>\r\n            </div>\r\n        " +
"</div>\r\n    </div>\r\n</div>\r\n");

DefineSection("scripts", () => {

WriteLiteral("\r\n    <!-- Custom Theme JavaScript -->\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 2193), Tuple.Create("\"", 2230)
, Tuple.Create(Tuple.Create("", 2199), Tuple.Create<System.Object, System.Int32>(Href("~/assets/admin/js/custom.min.js")
, 2199), false)
);

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 2254), Tuple.Create("\"", 2335)
, Tuple.Create(Tuple.Create("", 2260), Tuple.Create<System.Object, System.Int32>(Href("~/assets/admin/plugins/bower_components/datatables/jquery.dataTables.min.js")
, 2260), false)
);

WriteLiteral("></script>\r\n    <!-- start - This is for export functionality only -->\r\n    <scri" +
"pt");

WriteLiteral(" src=\"https://cdn.datatables.net/buttons/1.2.2/js/dataTables.buttons.min.js\"");

WriteLiteral("></script>\r\n    <script");

WriteLiteral(" src=\"https://cdn.datatables.net/buttons/1.2.2/js/buttons.flash.min.js\"");

WriteLiteral("></script>\r\n    <script");

WriteLiteral(" src=\"https://cdnjs.cloudflare.com/ajax/libs/jszip/2.5.0/jszip.min.js\"");

WriteLiteral("></script>\r\n    <script");

WriteLiteral(" src=\"https://cdn.rawgit.com/bpampuch/pdfmake/0.1.18/build/pdfmake.min.js\"");

WriteLiteral("></script>\r\n    <script");

WriteLiteral(" src=\"https://cdn.rawgit.com/bpampuch/pdfmake/0.1.18/build/vfs_fonts.js\"");

WriteLiteral("></script>\r\n    <script");

WriteLiteral(" src=\"https://cdn.datatables.net/buttons/1.2.2/js/buttons.html5.min.js\"");

WriteLiteral("></script>\r\n    <script");

WriteLiteral(" src=\"https://cdn.datatables.net/buttons/1.2.2/js/buttons.print.min.js\"");

WriteLiteral("></script>\r\n    <script");

WriteLiteral(" src=\"//cdn.datatables.net/buttons/1.2.1/js/buttons.colVis.min.js\"");

WriteLiteral(@"></script>
    <!-- end - This is for export functionality only -->
    <script>
        //$('#submissionTable tfoot th').each(function () {
        //    $(this).html('<input type=""text"" />');
        //});
        $(document).ready(function () {
            var oTable = $('#submissionTable').DataTable({
                ""serverSide"": true,
                ""scrollX"": true,
                ""scrollX"": true,
                ""lengthMenu"": [[5,10, 25, 50, -1], [5,10, 25, 50, ""All""]],
                dom: 'lBfrtip',
                buttons: [
                   {
                       text: '");

            
            #line 70 "..\..\Areas\RMS\Views\Submissions\Index.cshtml"
                         Write(Resources.Resources.Reload);

            
            #line default
            #line hidden
WriteLiteral("\',\r\n                       action: function (e, dt, node, config) {\r\n            " +
"               dt.ajax.reload();\r\n                       }\r\n                   }" +
",\r\n                   {\r\n                       text: \'");

            
            #line 76 "..\..\Areas\RMS\Views\Submissions\Index.cshtml"
                         Write(Resources.Resources.Copy);

            
            #line default
            #line hidden
WriteLiteral("\',\r\n                       extend: \'copyHtml5\',\r\n                       exportOpt" +
"ions: {\r\n                           columns: \':visible\'\r\n                       " +
"}\r\n                   },\r\n                  {\r\n                      text: \'");

            
            #line 83 "..\..\Areas\RMS\Views\Submissions\Index.cshtml"
                        Write(Resources.Resources.ExportExcel);

            
            #line default
            #line hidden
WriteLiteral("\',\r\n                      extend: \'excelHtml5\',\r\n                      exportOpti" +
"ons: {\r\n                          columns: \':visible\'\r\n                      }\r\n" +
"                  },\r\n                  {\r\n                      text: \'");

            
            #line 90 "..\..\Areas\RMS\Views\Submissions\Index.cshtml"
                        Write(Resources.Resources.ExportPDF);

            
            #line default
            #line hidden
WriteLiteral("\',\r\n                      extend: \'pdfHtml5\',\r\n                      exportOption" +
"s: {\r\n                          columns: \':visible\'\r\n                      }\r\n  " +
"                },\r\n                  {\r\n                      text: \'");

            
            #line 97 "..\..\Areas\RMS\Views\Submissions\Index.cshtml"
                        Write(Resources.Resources.Print);

            
            #line default
            #line hidden
WriteLiteral("\',\r\n                      extend: \'print\',\r\n                      exportOptions: " +
"{\r\n                          columns: \':visible\'\r\n                      }\r\n     " +
"             },\r\n                  {\r\n                      text: \'");

            
            #line 104 "..\..\Areas\RMS\Views\Submissions\Index.cshtml"
                        Write(Resources.Resources.ColVis);

            
            #line default
            #line hidden
WriteLiteral("\',\r\n                      extend: \'colvis\',\r\n                  },\r\n              " +
"  ],\r\n                \"language\": {\r\n                    \"url\": \"");

            
            #line 109 "..\..\Areas\RMS\Views\Submissions\Index.cshtml"
                       Write(Resources.Resources.DataTableLanguage);

            
            #line default
            #line hidden
WriteLiteral("\"\r\n                },\r\n                //\"responsive\": true,\r\n                \"aj" +
"ax\": {\r\n                    \"type\": \"POST\",\r\n                    \"url\": \"");

            
            #line 114 "..\..\Areas\RMS\Views\Submissions\Index.cshtml"
                       Write(Url.Action("DataHandler", "Submissions", new { area = "RMS",id=ViewBag.VacancyId }));

            
            #line default
            #line hidden
WriteLiteral(@""",
                    ""contentType"": 'application/json; charset=utf-8',
                    'data': function (data) {
                        return data = JSON.stringify(data);
                    }
                },
                ""processing"": true,
                ""paging"": true,
                ""deferRender"": true,
                ""columns"": [
               { ""data"": ""Id"" },
               { ""data"": ""ApplicantFullName"" },
               { ""data"": ""SubmissionDate"" },
               { ""data"": ""VacancyTitle"" },
               { ""data"": ""Department"", ""visible"": false },
               {
                   ""data"": ""Action"",
                   ""sortable"": false,
                   ""render"": function (data, type, col) {
                       return '<a class=\'btn\' href=\'' + '");

            
            #line 133 "..\..\Areas\RMS\Views\Submissions\Index.cshtml"
                                                       Write(Url.Action("Details", "Submissions"));

            
            #line default
            #line hidden
WriteLiteral("?id=\' + col[\"Id\"] + \'\\\'>");

            
            #line 133 "..\..\Areas\RMS\Views\Submissions\Index.cshtml"
                                                                                                                    Write(Resources.Resources.View);

            
            #line default
            #line hidden
WriteLiteral("</a>\'\r\n                       + \'|<a class=\\\'btn\\\' href=\\\'\' + \'");

            
            #line 134 "..\..\Areas\RMS\Views\Submissions\Index.cshtml"
                                                   Write(Url.Action("ExportCV", "Submissions"));

            
            #line default
            #line hidden
WriteLiteral("?id=\' + col[\"Id\"] + \'\\\'>");

            
            #line 134 "..\..\Areas\RMS\Views\Submissions\Index.cshtml"
                                                                                                                 Write(Resources.Resources.CurriculumVitae);

            
            #line default
            #line hidden
WriteLiteral("</a>\'\r\n                       + \'|<a class=\\\'btn\\\' href=\\\'\' + \'");

            
            #line 135 "..\..\Areas\RMS\Views\Submissions\Index.cshtml"
                                                   Write(Url.Action("ExportApplicant", "Submissions"));

            
            #line default
            #line hidden
WriteLiteral("?id=\' + col[\"Id\"] + \'\\\'>");

            
            #line 135 "..\..\Areas\RMS\Views\Submissions\Index.cshtml"
                                                                                                                        Write(Resources.Resources.Export);

            
            #line default
            #line hidden
WriteLiteral("</a>\';\r\n                       ");

WriteLiteral("\r\n                   }\r\n                   //\"render\": function (o) { return \'<i " +
"class=\"ui-tooltip fa fa-pencil\" style=\"font-size: 22px;\" data-original-title=\"Ed" +
"it\"></i><i class=\"ui-tooltip fa fa-trash-o\" style=\"font-size: 22px;\" data-origin" +
"al-title=\"Delete\"></i>\'; }\r\n               },\r\n                ],\r\n             " +
"   \"order\": [0, \"asc\"],\r\n                \"initComplete\": function () {\r\n        " +
"            this.api().columns(\'.select-filter\').every(function () {\r\n          " +
"              var column = this;\r\n                        var select = $(\'<selec" +
"t><option value=\"\"></option></select>\')\r\n                       .appendTo($(colu" +
"mn.footer()).empty())\r\n                       .on(\'change\', function () {\r\n     " +
"                      var val = $(this).val();\r\n                           colum" +
"n\r\n                               .search(val, true, false)\r\n                   " +
"            .draw();\r\n                       });\r\n                        column" +
".data().unique().sort().each(function (d, j) {\r\n                            sele" +
"ct.append(\'<option value=\"\' + d + \'\">\' + d + \'</option>\')\r\n                     " +
"   });\r\n                    });\r\n                }\r\n            });\r\n           " +
" oTable.columns().every(function () {\r\n                var that = this;\r\n       " +
"         $(\'input\', this.footer()).on(\'keyup change\', function () {\r\n           " +
"         that\r\n                        .search(this.value)\r\n                    " +
"    .draw();\r\n                });\r\n            });\r\n        });\r\n    </script>\r\n" +
"");

});

        }
    }
}
#pragma warning restore 1591
