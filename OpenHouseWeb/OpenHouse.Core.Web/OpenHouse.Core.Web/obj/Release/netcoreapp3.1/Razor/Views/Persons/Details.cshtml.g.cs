#pragma checksum "C:\UNIAPPS\OpenHouse\OpenHouseWeb\OpenHouse.Core.Web\OpenHouse.Core.Web\Views\Persons\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ff6ba5beedf04ea3e3d33271be44b205432506a2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Persons_Details), @"mvc.1.0.view", @"/Views/Persons/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ff6ba5beedf04ea3e3d33271be44b205432506a2", @"/Views/Persons/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c2bcca83ecb3b43921cb7c3c61d2af41f51c15f2", @"/Views/_ViewImports.cshtml")]
    public class Views_Persons_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<OpenHouse.Model.Core.Model.PersonViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-primary float-right ml-1"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\UNIAPPS\OpenHouse\OpenHouseWeb\OpenHouse.Core.Web\OpenHouse.Core.Web\Views\Persons\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script type=""text/javascript"">
        //Save active tab & navigate back to on refresh
        $(document).ready(function () {
            $('a[data-toggle=""tab""]').on('shown.bs.tab', function (e) { //On tab selected
                localStorage.setItem('activeTabPerson', $(e.target).attr('href')); //log selected tab to local storage
            });

            if (performance.navigation.type == 1) { //If page is refreshes or accessed via location.reload()
                console.info(""This page is reloaded"");

                var activeTab = localStorage.getItem('activeTabPerson'); //Retrieve active tab from local storage

                if (activeTab) {
                    $('.nav-tabs a[href=""' + activeTab + '""]').tab('show'); //Select active tab
                }
            }
        });
    </script>
");
            }
            );
            WriteLiteral(@"
<div class=""row mt-4"">
    <div class=""col-md-6"">
        <h4><i class=""fa fa-user-circle""></i>&nbsp;Person Details</h4>
    </div>
    <div class=""col-md-6"">
        <input type=""button"" class=""btn btn-outline-primary float-right ml-1"" onClick=""window.open('', '_self').close();"" value=""Done"" />
        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ff6ba5beedf04ea3e3d33271be44b205432506a25458", async() => {
                WriteLiteral("Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 34 "C:\UNIAPPS\OpenHouse\OpenHouseWeb\OpenHouse.Core.Web\OpenHouse.Core.Web\Views\Persons\Details.cshtml"
                                                                                WriteLiteral(Model.personId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
<hr />
<ul class=""nav nav-tabs"" id=""myTab"" role=""tablist"">
    <li class=""nav-item"">
        <a class=""nav-link active"" id=""details-tab"" data-toggle=""tab"" href=""#details"" role=""tab"" aria-controls=""details"" aria-selected=""true"">Details</a>
    </li>
    <li class=""nav-item"">
        <a class=""nav-link"" id=""audit-tab"" data-toggle=""tab"" href=""#audit"" role=""tab"" aria-controls=""audit"" aria-selected=""false"">Audit</a>
    </li>
</ul>
<div class=""tab-content"" id=""myTabContent"">
    <div class=""tab-pane fade show active"" id=""details"" role=""tabpanel"" aria-labelledby=""search-tab"">
        <div class=""row mt-4"">
            <div class=""col-md-6"">
                <dl>
                    <dt class=""col-sm-10"">
                        Title
                    </dt>
                    <dd class=""col-sm-10 border border border-secondary rounded mt-2"">
                        ");
#nullable restore
#line 55 "C:\UNIAPPS\OpenHouse\OpenHouseWeb\OpenHouse.Core.Web\OpenHouse.Core.Web\Views\Persons\Details.cshtml"
                   Write(Html.DisplayFor(model => model.title.title1));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dd>\r\n                    <dt class=\"col-sm-10\">\r\n                        First name\r\n                    </dt>\r\n                    <dd class=\"col-sm-10 border border border-secondary rounded mt-2\">\r\n                        ");
#nullable restore
#line 61 "C:\UNIAPPS\OpenHouse\OpenHouseWeb\OpenHouse.Core.Web\OpenHouse.Core.Web\Views\Persons\Details.cshtml"
                   Write(Html.DisplayFor(model => model.firstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dd>\r\n                    <dt class=\"col-sm-10\">\r\n                        Middle name\r\n                    </dt>\r\n                    <dd class=\"col-sm-10 border border border-secondary rounded mt-2\">\r\n                        ");
#nullable restore
#line 67 "C:\UNIAPPS\OpenHouse\OpenHouseWeb\OpenHouse.Core.Web\OpenHouse.Core.Web\Views\Persons\Details.cshtml"
                   Write(Html.DisplayFor(model => model.middleName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dd>\r\n                    <dt class=\"col-sm-10\">\r\n                        Surname\r\n                    </dt>\r\n                    <dd class=\"col-sm-10 border border border-secondary rounded mt-2\">\r\n                        ");
#nullable restore
#line 73 "C:\UNIAPPS\OpenHouse\OpenHouseWeb\OpenHouse.Core.Web\OpenHouse.Core.Web\Views\Persons\Details.cshtml"
                   Write(Html.DisplayFor(model => model.surname));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dd>\r\n                    <dt class=\"col-sm-10\">\r\n                        Date of Birth\r\n                    </dt>\r\n                    <dd class=\"col-sm-10 border border border-secondary rounded mt-2\">\r\n                        ");
#nullable restore
#line 79 "C:\UNIAPPS\OpenHouse\OpenHouseWeb\OpenHouse.Core.Web\OpenHouse.Core.Web\Views\Persons\Details.cshtml"
                   Write(Html.DisplayFor(model => model.dateOfBirth));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dd>\r\n                    <dt class=\"col-sm-10\">\r\n                        Nationality\r\n                    </dt>\r\n                    <dd class=\"col-sm-10 border border border-secondary rounded mt-2\">\r\n                        ");
#nullable restore
#line 85 "C:\UNIAPPS\OpenHouse\OpenHouseWeb\OpenHouse.Core.Web\OpenHouse.Core.Web\Views\Persons\Details.cshtml"
                   Write(Html.DisplayFor(model => model.nationality.nationality1));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    </dd>
                </dl>
            </div>
            <div class=""col-md-6"">
                <dl>
                    <dt class=""col-sm-10"">
                        Telephone
                    </dt>
                    <dd class=""col-sm-10 border border border-secondary rounded mt-2"">
                        ");
#nullable restore
#line 95 "C:\UNIAPPS\OpenHouse\OpenHouseWeb\OpenHouse.Core.Web\OpenHouse.Core.Web\Views\Persons\Details.cshtml"
                   Write(Html.DisplayFor(model => model.telephone));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dd>\r\n                    <dt class=\"col-sm-10\">\r\n                        Email\r\n                    </dt>\r\n                    <dd class=\"col-sm-10 border border border-secondary rounded mt-2\">\r\n                        ");
#nullable restore
#line 101 "C:\UNIAPPS\OpenHouse\OpenHouseWeb\OpenHouse.Core.Web\OpenHouse.Core.Web\Views\Persons\Details.cshtml"
                   Write(Html.DisplayFor(model => model.email));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    </dd>
                    <dt class=""col-sm-10"">
                        Next of Kin First Name
                    </dt>
                    <dd class=""col-sm-10 border border border-secondary rounded mt-2"">
                        ");
#nullable restore
#line 107 "C:\UNIAPPS\OpenHouse\OpenHouseWeb\OpenHouse.Core.Web\OpenHouse.Core.Web\Views\Persons\Details.cshtml"
                   Write(Html.DisplayFor(model => model.nextOfKinFrstName));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    </dd>
                    <dt class=""col-sm-10"">
                        Next of Kin Surname
                    </dt>
                    <dd class=""col-sm-10 border border border-secondary rounded mt-2"">
                        ");
#nullable restore
#line 113 "C:\UNIAPPS\OpenHouse\OpenHouseWeb\OpenHouse.Core.Web\OpenHouse.Core.Web\Views\Persons\Details.cshtml"
                   Write(Html.DisplayFor(model => model.nextOfKinSurname));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    </dd>
                    <dt class=""col-sm-10"">
                        Next of Kin Telephone
                    </dt>
                    <dd class=""col-sm-10 border border border-secondary rounded mt-2"">
                        ");
#nullable restore
#line 119 "C:\UNIAPPS\OpenHouse\OpenHouseWeb\OpenHouse.Core.Web\OpenHouse.Core.Web\Views\Persons\Details.cshtml"
                   Write(Html.DisplayFor(model => model.nextOfKinTelephone));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    </dd>
                </dl>
            </div>
        </div>
    </div>
    <div class=""tab-pane fade"" id=""audit"" role=""tabpanel"" aria-labelledby=""audit-tab"">
        <div class=""row mt-3 mb-3"">
            <div class=""card w-100"">
                <div class=""card-body"">
                    <div class=""row"">
                        <div class=""col-md-6"">
                            <dl>
                                <dt class=""col-sm-10"">
                                    <i class=""fa fa-user""></i>&nbsp;Updated By
                                </dt>
                                <dd class=""col-sm-10 border border border-secondary rounded mt-2"">
                                    ");
#nullable restore
#line 136 "C:\UNIAPPS\OpenHouse\OpenHouseWeb\OpenHouse.Core.Web\OpenHouse.Core.Web\Views\Persons\Details.cshtml"
                               Write(Html.DisplayFor(model => model.updatedByUsername));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                </dd>
                                <dt class=""col-sm-10"">
                                    <i class=""fa fa-user-clock""></i>&nbsp;Last updated:
                                </dt>
                                <dd class=""col-sm-10 border border border-secondary rounded mt-2"">
                                    ");
#nullable restore
#line 142 "C:\UNIAPPS\OpenHouse\OpenHouseWeb\OpenHouse.Core.Web\OpenHouse.Core.Web\Views\Persons\Details.cshtml"
                               Write(Model.updatedDT.Value.ToString("dd/MM/yyyy hh:mm"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                </dd>
                            </dl>
                        </div>
                        <div class=""col-md-6"">
                            <dl>
                                <dt class=""col-sm-10"">
                                    <i class=""fa fa-user""></i>&nbsp;Created By:
                                </dt>
                                <dd class=""col-sm-10 border border border-secondary rounded mt-2"">
                                    ");
#nullable restore
#line 152 "C:\UNIAPPS\OpenHouse\OpenHouseWeb\OpenHouse.Core.Web\OpenHouse.Core.Web\Views\Persons\Details.cshtml"
                               Write(Html.DisplayFor(model => model.createdByUsername));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                </dd>
                                <dt class=""col-sm-10"">
                                    <i class=""fa fa-user-clock""></i>&nbsp;Created On:
                                </dt>
                                <dd class=""col-sm-10 border border border-secondary rounded mt-2"">
                                    ");
#nullable restore
#line 158 "C:\UNIAPPS\OpenHouse\OpenHouseWeb\OpenHouse.Core.Web\OpenHouse.Core.Web\Views\Persons\Details.cshtml"
                               Write(Model.createdDT.Value.ToString("dd/MM/yyyy hh:mm"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </dd>\r\n                            </dl>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<OpenHouse.Model.Core.Model.PersonViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591