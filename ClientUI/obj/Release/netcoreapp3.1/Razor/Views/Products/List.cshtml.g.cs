#pragma checksum "C:\0 Dom\0. Saityno taikomųjų programų projektavimas\ClientUI\Views\Products\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8efe9a69fcb384666145c65bb171d39f12181334"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Products_List), @"mvc.1.0.view", @"/Views/Products/List.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\0 Dom\0. Saityno taikomųjų programų projektavimas\ClientUI\Views\_ViewImports.cshtml"
using ClientUI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\0 Dom\0. Saityno taikomųjų programų projektavimas\ClientUI\Views\_ViewImports.cshtml"
using ClientUI.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\0 Dom\0. Saityno taikomųjų programų projektavimas\ClientUI\Views\_ViewImports.cshtml"
using ClientUI.Resources;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\0 Dom\0. Saityno taikomųjų programų projektavimas\ClientUI\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Mvc;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\0 Dom\0. Saityno taikomųjų programų projektavimas\ClientUI\Views\_ViewImports.cshtml"
using ClientUI.Services;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8efe9a69fcb384666145c65bb171d39f12181334", @"/Views/Products/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5057ad31693b47fd158a8961bb2a4f5bdb0eefb2", @"/Views/_ViewImports.cshtml")]
    public class Views_Products_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ClientUI.Models.Product>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\0 Dom\0. Saityno taikomųjų programų projektavimas\ClientUI\Views\Products\List.cshtml"
  
    TempData["Title"] = "List";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Our products</h1>\r\n\r\n\r\n");
#nullable restore
#line 10 "C:\0 Dom\0. Saityno taikomųjų programų projektavimas\ClientUI\Views\Products\List.cshtml"
  
    if (TempData["isAdmin"].Equals("true"))
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <p>\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8efe9a69fcb384666145c65bb171d39f121813344537", async() => {
                WriteLiteral("Create New");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </p>\r\n");
#nullable restore
#line 16 "C:\0 Dom\0. Saityno taikomųjų programų projektavimas\ClientUI\Views\Products\List.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 23 "C:\0 Dom\0. Saityno taikomųjų programų projektavimas\ClientUI\Views\Products\List.cshtml"
           Write(Html.DisplayNameFor(model => model.name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 26 "C:\0 Dom\0. Saityno taikomųjų programų projektavimas\ClientUI\Views\Products\List.cshtml"
           Write(Html.DisplayNameFor(model => model.description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 29 "C:\0 Dom\0. Saityno taikomųjų programų projektavimas\ClientUI\Views\Products\List.cshtml"
           Write(Html.DisplayNameFor(model => model.price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 35 "C:\0 Dom\0. Saityno taikomųjų programų projektavimas\ClientUI\Views\Products\List.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 39 "C:\0 Dom\0. Saityno taikomųjų programų projektavimas\ClientUI\Views\Products\List.cshtml"
               Write(Html.DisplayFor(modelItem => item.name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 42 "C:\0 Dom\0. Saityno taikomųjų programų projektavimas\ClientUI\Views\Products\List.cshtml"
               Write(Html.DisplayFor(modelItem => item.description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 45 "C:\0 Dom\0. Saityno taikomųjų programų projektavimas\ClientUI\Views\Products\List.cshtml"
               Write(Html.DisplayFor(modelItem => item.price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 48 "C:\0 Dom\0. Saityno taikomųjų programų projektavimas\ClientUI\Views\Products\List.cshtml"
               Write(Html.ActionLink("Add to cart", "CartAdd", new { id = item.id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 49 "C:\0 Dom\0. Saityno taikomųjų programų projektavimas\ClientUI\Views\Products\List.cshtml"
                     if (TempData["isAdmin"].Equals("true"))
                        {
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 51 "C:\0 Dom\0. Saityno taikomųjų programų projektavimas\ClientUI\Views\Products\List.cshtml"
                       Write(Html.ActionLink("Edit", "Edit", new { id=item.id }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 51 "C:\0 Dom\0. Saityno taikomųjų programų projektavimas\ClientUI\Views\Products\List.cshtml"
                                                                                ;
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 52 "C:\0 Dom\0. Saityno taikomųjų programų projektavimas\ClientUI\Views\Products\List.cshtml"
                       Write(Html.ActionLink("  Delete", "Delete", new { id=item.id }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 52 "C:\0 Dom\0. Saityno taikomųjų programų projektavimas\ClientUI\Views\Products\List.cshtml"
                                                                                      ;
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    \r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 57 "C:\0 Dom\0. Saityno taikomųjų programų projektavimas\ClientUI\Views\Products\List.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ClientUI.Models.Product>> Html { get; private set; }
    }
}
#pragma warning restore 1591
