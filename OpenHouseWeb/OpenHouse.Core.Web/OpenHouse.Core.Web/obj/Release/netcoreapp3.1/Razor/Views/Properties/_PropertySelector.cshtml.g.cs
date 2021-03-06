#pragma checksum "C:\UNIAPPS\OpenHouse\OpenHouseWeb\OpenHouse.Core.Web\OpenHouse.Core.Web\Views\Properties\_PropertySelector.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1ab43d7a54ef60fac3a0920cb1fe89e67c04f22a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Properties__PropertySelector), @"mvc.1.0.view", @"/Views/Properties/_PropertySelector.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1ab43d7a54ef60fac3a0920cb1fe89e67c04f22a", @"/Views/Properties/_PropertySelector.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c2bcca83ecb3b43921cb7c3c61d2af41f51c15f2", @"/Views/_ViewImports.cshtml")]
    public class Views_Properties__PropertySelector : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div id=""modalPropertySearch"" class=""modal fade"" aria-hidden=""true"" tabindex=""-1"" role=""dialog"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title""><i class=""fa fa-home""></i>&nbsp;Property Search</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">
                <div class=""row"">
                    <div class=""col-sm-9"">
                        <input type=""text"" id=""txtPropertySearch"" name=""txtPropertySearch"" placeholder=""Search by property ID or address..."" class=""form-control"" />
                    </div>
                    <div class=""col-sm-3"">
                        <button id=""btnSearch"" onclick=""populatePropertySearchResults()"" class=""btn btn-primary w-100"">Search</button>
              ");
            WriteLiteral(@"      </div>
                </div>
                <div class=""row mt-2"" id=""property-search-result"">

                </div>
            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-secondary"" onclick=""clearPropertySearch();"" data-dismiss=""modal"">Close</button>
            </div>
        </div>
    </div>
</div>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
