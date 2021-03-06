#pragma checksum "C:\UNIAPPS\OpenHouse\OpenHouseWeb\OpenHouse.Core.Web\OpenHouse.Core.Web\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "69042fcc8e41cac7ab448cd28150c6aff688db00"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\UNIAPPS\OpenHouse\OpenHouseWeb\OpenHouse.Core.Web\OpenHouse.Core.Web\Views\_ViewImports.cshtml"
using OpenHouse.Core.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\UNIAPPS\OpenHouse\OpenHouseWeb\OpenHouse.Core.Web\OpenHouse.Core.Web\Views\_ViewImports.cshtml"
using OpenHouse.Core.Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"69042fcc8e41cac7ab448cd28150c6aff688db00", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c2bcca83ecb3b43921cb7c3c61d2af41f51c15f2", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<OpenHouse.Model.Core.Model.vwaction>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary w-100"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Properties", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Tenancies", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Persons", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\UNIAPPS\OpenHouse\OpenHouseWeb\OpenHouse.Core.Web\OpenHouse.Core.Web\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script type=""text/javascript"">
        $(document).ready(function () {
            $('#ddlSearchItem').change(function (e) {
                var searchItem = $(this).children(""option:selected"").val(); //Get selected item

                //Update placeholder text in search bar based on dropdown selection
                if (searchItem == 'Property') {
                    $('#txtSearch').attr('placeholder', 'Search by property ID or address...');
                }
                else if (searchItem == 'Tenancy') {
                    $('#txtSearch').attr('placeholder', 'Search by tenancy ID or Lead tenant name...');
                }
                else if (searchItem == 'Person') {
                    $('#txtSearch').attr('placeholder', 'Search by person ID or person name...');
                }
            });

            //Perform search on enter key press in search bar
            $(""#txtSearch"").keyup(function (event) {
                if (event.keyCode === 13) {
            ");
                WriteLiteral(@"        populateSearchResults();
                }
            });
        });

        function populateSearchResults() {
            var searchItem = $('#ddlSearchItem').val();
            var searchString = $('#txtSearch').val();
            var returnViewAction;

            var sendData = {
                searchString: searchString,
                displayType: 'search'
            };

            var sendJson = JSON.stringify(sendData);

            if (searchItem == 'Property') {
                returnViewAction = '");
#nullable restore
#line 46 "C:\UNIAPPS\OpenHouse\OpenHouseWeb\OpenHouse.Core.Web\OpenHouse.Core.Web\Views\Home\Index.cshtml"
                               Write(Url.Action("_PropertySearch","Properties"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\';\r\n            }\r\n            else if (searchItem == \'Tenancy\') {\r\n                returnViewAction = \'");
#nullable restore
#line 49 "C:\UNIAPPS\OpenHouse\OpenHouseWeb\OpenHouse.Core.Web\OpenHouse.Core.Web\Views\Home\Index.cshtml"
                               Write(Url.Action("_TenancySearch","Tenancies"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\';\r\n            }\r\n            else if (searchItem == \'Person\') {\r\n                returnViewAction = \'");
#nullable restore
#line 52 "C:\UNIAPPS\OpenHouse\OpenHouseWeb\OpenHouse.Core.Web\OpenHouse.Core.Web\Views\Home\Index.cshtml"
                               Write(Url.Action("_PersonSearch","Persons"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"';
            }

            $.ajax({
                url: returnViewAction,
                contentType: 'application/json',
                type: 'GET',
                data: sendData,
                beforeSend: function () {
                    $('#search-result').fadeOut();
                    $('#search-result').LoadingOverlay(""show"");
                },
                success: function (data) { //AJAX Success
                    $('#search-result').html(data); //Populate HTML from data
                    $('#search-result').LoadingOverlay(""hide"");
                    $('#search-result').fadeIn(); //Fade in
                },
                error: function (jqXHR, textStatus, errorThrown) { //AJAX Error
                    console.log(textStatus, errorThrown); //Log error
                    $('#search-result').LoadingOverlay(""hide"");
                    $('#search-result').fadeIn(); //Fade in
                    $('#search-result').html('');
                    alert('Error lo");
                WriteLiteral("ading search results\');\r\n                }\r\n            });\r\n        }\r\n    </script>\r\n");
            }
            );
            WriteLiteral("<div class=\"col-12\">\r\n    <div class=\"card mt-4 mb-4\">\r\n        <div class=\"card-body\">\r\n            <div class=\"row\">\r\n                <div class=\"col-md-4\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "69042fcc8e41cac7ab448cd28150c6aff688db009366", async() => {
                WriteLiteral("<i class=\"fa fa-home\"></i>&nbsp;Create Property");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </div>\r\n                <div class=\"col-md-4\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "69042fcc8e41cac7ab448cd28150c6aff688db0010943", async() => {
                WriteLiteral("<i class=\"fas fa-house-user\"></i>&nbsp;Create Tenancy");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </div>\r\n                <div class=\"col-md-4\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "69042fcc8e41cac7ab448cd28150c6aff688db0012527", async() => {
                WriteLiteral("<i class=\"fas fa-user-plus\"></i>&nbsp;Create Person");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                </div>
            </div>
        </div>
    </div>
    <ul class=""nav nav-tabs"" id=""myTab"" role=""tablist"">
        <li class=""nav-item"">
            <a class=""nav-link active"" id=""search-tab"" data-toggle=""tab"" href=""#search"" role=""tab"" aria-controls=""search"" aria-selected=""true"">Search</a>
        </li>
");
#nullable restore
#line 100 "C:\UNIAPPS\OpenHouse\OpenHouseWeb\OpenHouse.Core.Web\OpenHouse.Core.Web\Views\Home\Index.cshtml"
         if (User.IsInRole("Admin") || User.IsInRole("HousingUser") || User.IsInRole("HousingManager"))
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li class=\"nav-item\">\r\n                <a class=\"nav-link\" id=\"actions-tab\" data-toggle=\"tab\" href=\"#actions\" role=\"tab\" aria-controls=\"actions\" aria-selected=\"false\">My Actions <span class=\"badge badge-pill badge-danger\">");
#nullable restore
#line 103 "C:\UNIAPPS\OpenHouse\OpenHouseWeb\OpenHouse.Core.Web\OpenHouse.Core.Web\Views\Home\Index.cshtml"
                                                                                                                                                                                                  Write(ViewBag.OutstandingActionsCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></a>\r\n            </li>\r\n");
#nullable restore
#line 105 "C:\UNIAPPS\OpenHouse\OpenHouseWeb\OpenHouse.Core.Web\OpenHouse.Core.Web\Views\Home\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    </ul>
    <div class=""tab-content"" id=""myTabContent"">
        <div class=""tab-pane fade show active"" id=""search"" role=""tabpanel"" aria-labelledby=""search-tab"">
            <div class=""mt-3"">
                <div class=""card w-100"">
                    <div class=""card-header"">
                        <i class=""fa fa-search""></i>&nbsp;Search
                    </div>
                    <div class=""card-body"">
                        <div class=""row"">
                            <div class=""col-sm-6"">
                                <input type=""text"" id=""txtSearch"" name=""txtSearch"" placeholder=""Search by property ID or address..."" class=""form-control"" />
                            </div>
                            <div class=""col-sm-3"">
                                <select id=""ddlSearchItem"" class=""form-control float-right"">
                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "69042fcc8e41cac7ab448cd28150c6aff688db0016589", async() => {
                WriteLiteral("Property");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "69042fcc8e41cac7ab448cd28150c6aff688db0017586", async() => {
                WriteLiteral("Tenancy");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "69042fcc8e41cac7ab448cd28150c6aff688db0018582", async() => {
                WriteLiteral("Person");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                </select>
                            </div>
                            <div class=""col-sm-3"">
                                <button id=""btnSearch"" onclick=""populateSearchResults()"" class=""btn btn-primary w-100"">Search</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class=""row mt-4"">
                <div id=""search-result"" class=""w-100"">
                </div>
            </div>
        </div>
");
#nullable restore
#line 138 "C:\UNIAPPS\OpenHouse\OpenHouseWeb\OpenHouse.Core.Web\OpenHouse.Core.Web\Views\Home\Index.cshtml"
         if (User.IsInRole("Admin") || User.IsInRole("HousingUser") || User.IsInRole("HousingManager"))
        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <div class=""tab-pane fade"" id=""actions"" role=""tabpanel"" aria-labelledby=""action-tab"">
                <div class=""mt-3"">
                    <div class=""card w-100"">
                        <div class=""card-header"">
                            <i class=""fa fa-inbox""></i>&nbsp;My Actions
                        </div>
                        <div class=""card-body"">
                            <div class=""table-responsive"">
                                <table class=""table table-borderless"">
                                    <thead>
                                        <tr>
                                            <th class=""text-center d-none d-lg-table-cell d-xl-table-cell"">Tenancy Id</th>
                                            <th>Address</th>
                                            <th>Type</th>
                                            <th>Due Date</th>
                                            <th></th>
                                        </tr>
     ");
            WriteLiteral("                               </thead>\r\n                                    <tbody>\r\n");
#nullable restore
#line 159 "C:\UNIAPPS\OpenHouse\OpenHouseWeb\OpenHouse.Core.Web\OpenHouse.Core.Web\Views\Home\Index.cshtml"
                                         foreach (var action in Model)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <tr>\r\n                                                <td class=\"text-center d-none d-lg-table-cell d-xl-table-cell\">\r\n                                                    ");
#nullable restore
#line 163 "C:\UNIAPPS\OpenHouse\OpenHouseWeb\OpenHouse.Core.Web\OpenHouse.Core.Web\Views\Home\Index.cshtml"
                                               Write(Html.ActionLink(action.tenancyId.ToString(), "Details", "Tenancies", new { @id = action.tenancyId }, new { @class = "btn btn-link", @target = "_blank" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                </td>\r\n                                                <td>\r\n                                                    ");
#nullable restore
#line 166 "C:\UNIAPPS\OpenHouse\OpenHouseWeb\OpenHouse.Core.Web\OpenHouse.Core.Web\Views\Home\Index.cshtml"
                                               Write(Html.ActionLink(action.contactAddress.ToString(), "Details", "Properties", new { @id = action.propertyId }, new { @class = "btn btn-link", @target = "_blank" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                </td>\r\n                                                <td>\r\n                                                    ");
#nullable restore
#line 169 "C:\UNIAPPS\OpenHouse\OpenHouseWeb\OpenHouse.Core.Web\OpenHouse.Core.Web\Views\Home\Index.cshtml"
                                               Write(action.actionType);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                </td>\r\n                                                <td>\r\n                                                    ");
#nullable restore
#line 172 "C:\UNIAPPS\OpenHouse\OpenHouseWeb\OpenHouse.Core.Web\OpenHouse.Core.Web\Views\Home\Index.cshtml"
                                               Write(action.actionDueDate.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                </td>\r\n                                                <td>\r\n                                                    <a class=\"btn btn-light\"");
            BeginWriteAttribute("onauxclick", " onauxclick=\"", 8857, "\"", 8953, 3);
            WriteAttributeValue("", 8870, "window.open(\'", 8870, 13, true);
#nullable restore
#line 175 "C:\UNIAPPS\OpenHouse\OpenHouseWeb\OpenHouse.Core.Web\OpenHouse.Core.Web\Views\Home\Index.cshtml"
WriteAttributeValue("", 8883, Url.Action("Details", "Tenancies", new { @id = action.tenancyId }), 8883, 67, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 8950, "\');", 8950, 3, true);
            EndWriteAttribute();
            BeginWriteAttribute("onclick", " onclick=\"", 8954, "\"", 9045, 3);
            WriteAttributeValue("", 8964, "window.open(\'", 8964, 13, true);
#nullable restore
#line 175 "C:\UNIAPPS\OpenHouse\OpenHouseWeb\OpenHouse.Core.Web\OpenHouse.Core.Web\Views\Home\Index.cshtml"
WriteAttributeValue("", 8977, Url.Action("Details","Tenancies",new { @id = action.tenancyId }), 8977, 65, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 9042, "\');", 9042, 3, true);
            EndWriteAttribute();
            WriteLiteral(">View</a>\r\n                                                </td>\r\n                                            </tr>\r\n");
#nullable restore
#line 178 "C:\UNIAPPS\OpenHouse\OpenHouseWeb\OpenHouse.Core.Web\OpenHouse.Core.Web\Views\Home\Index.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    </tbody>\r\n                                </table>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 186 "C:\UNIAPPS\OpenHouse\OpenHouseWeb\OpenHouse.Core.Web\OpenHouse.Core.Web\Views\Home\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<OpenHouse.Model.Core.Model.vwaction>> Html { get; private set; }
    }
}
#pragma warning restore 1591
