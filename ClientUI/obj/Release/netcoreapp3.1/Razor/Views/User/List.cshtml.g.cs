#pragma checksum "C:\0 Dom\0. Saityno taikomųjų programų projektavimas\ClientUI\Views\User\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6a572a3ab4afc0c6d49bfb9b647d476694eb5587"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_List), @"mvc.1.0.view", @"/Views/User/List.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6a572a3ab4afc0c6d49bfb9b647d476694eb5587", @"/Views/User/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5057ad31693b47fd158a8961bb2a4f5bdb0eefb2", @"/Views/_ViewImports.cshtml")]
    public class Views_User_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ClientUI.Models.User>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\0 Dom\0. Saityno taikomųjų programų projektavimas\ClientUI\Views\User\List.cshtml"
  
    ViewData["Title"] = "List";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>List</h1>\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 13 "C:\0 Dom\0. Saityno taikomųjų programų projektavimas\ClientUI\Views\User\List.cshtml"
           Write(Html.DisplayNameFor(model => model.email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 16 "C:\0 Dom\0. Saityno taikomųjų programų projektavimas\ClientUI\Views\User\List.cshtml"
           Write(Html.DisplayNameFor(model => model.password));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 19 "C:\0 Dom\0. Saityno taikomųjų programų projektavimas\ClientUI\Views\User\List.cshtml"
           Write(Html.DisplayNameFor(model => model.role));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 25 "C:\0 Dom\0. Saityno taikomųjų programų projektavimas\ClientUI\Views\User\List.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 28 "C:\0 Dom\0. Saityno taikomųjų programų projektavimas\ClientUI\Views\User\List.cshtml"
           Write(Html.DisplayFor(modelItem => item.email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 31 "C:\0 Dom\0. Saityno taikomųjų programų projektavimas\ClientUI\Views\User\List.cshtml"
           Write(Html.DisplayFor(modelItem => item.password));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 34 "C:\0 Dom\0. Saityno taikomųjų programų projektavimas\ClientUI\Views\User\List.cshtml"
           Write(Html.DisplayFor(modelItem => item.role));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 37 "C:\0 Dom\0. Saityno taikomųjų programų projektavimas\ClientUI\Views\User\List.cshtml"
           Write(Html.ActionLink("Edit", "Edit", new {  id=item.id }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                ");
#nullable restore
#line 38 "C:\0 Dom\0. Saityno taikomųjų programų projektavimas\ClientUI\Views\User\List.cshtml"
           Write(Html.ActionLink("View Orders", "ListAdmin", "Order", new { id=item.id }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                ");
#nullable restore
#line 39 "C:\0 Dom\0. Saityno taikomųjų programų projektavimas\ClientUI\Views\User\List.cshtml"
           Write(Html.ActionLink("Delete", "Delete", new { id=item.id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 42 "C:\0 Dom\0. Saityno taikomųjų programų projektavimas\ClientUI\Views\User\List.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ClientUI.Models.User>> Html { get; private set; }
    }
}
#pragma warning restore 1591
