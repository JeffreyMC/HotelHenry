#pragma checksum "C:\Users\Jeffrey.000\source\repos\HotelHenry\Views\Huesped\_Logueado.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1b9fa93ac61c3934d0c21915c5dec77a001fa1c5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Huesped__Logueado), @"mvc.1.0.view", @"/Views/Huesped/_Logueado.cshtml")]
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
#line 1 "C:\Users\Jeffrey.000\source\repos\HotelHenry\Views\_ViewImports.cshtml"
using HotelHenry;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Jeffrey.000\source\repos\HotelHenry\Views\_ViewImports.cshtml"
using HotelHenry.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\Jeffrey.000\source\repos\HotelHenry\Views\Huesped\_Logueado.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1b9fa93ac61c3934d0c21915c5dec77a001fa1c5", @"/Views/Huesped/_Logueado.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bc9e22bbe4ddf134a719852f9ba033115c15f39a", @"/Views/_ViewImports.cshtml")]
    public class Views_Huesped__Logueado : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Jeffrey.000\source\repos\HotelHenry\Views\Huesped\_Logueado.cshtml"
 if (Context.Session.GetString("Usuario") != null)
{
    var nombre = (string)Context.Session.GetString("Usuario");


#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <li class=""nav-item dropdown nav-item"">
        <a class=""nav-link dropdown-toggle"" href=""#"" id=""navbarDropdownMenuLink"" role=""button""
           data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
            <i class=""fa fa-user-circle""></i><Strong> ");
#nullable restore
#line 10 "C:\Users\Jeffrey.000\source\repos\HotelHenry\Views\Huesped\_Logueado.cshtml"
                                                 Write(nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral("</Strong>\r\n        </a>\r\n        <div class=\"dropdown-menu\" aria-labelledby=\"navbarDropdownMenuLink\">\r\n            <a class=\"dropdown-item\"");
            BeginWriteAttribute("href", " href=\"", 577, "\"", 617, 1);
#nullable restore
#line 13 "C:\Users\Jeffrey.000\source\repos\HotelHenry\Views\Huesped\_Logueado.cshtml"
WriteAttributeValue("", 584, Url.Action("SignOut", "Huesped"), 584, 33, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-sign-out\"></i> Salir</a>\r\n        </div>\r\n    </li>\r\n");
#nullable restore
#line 16 "C:\Users\Jeffrey.000\source\repos\HotelHenry\Views\Huesped\_Logueado.cshtml"

}

else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <li class=\"nav-item\">\r\n        <a class=\"nav-link\"");
            BeginWriteAttribute("href", " href=\"", 758, "\"", 796, 1);
#nullable restore
#line 22 "C:\Users\Jeffrey.000\source\repos\HotelHenry\Views\Huesped\_Logueado.cshtml"
WriteAttributeValue("", 765, Url.Action("Login", "Huesped"), 765, 31, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Login</a>\r\n    </li>\r\n    <li class=\"nav-item\">\r\n        <a class=\"nav-link\"");
            BeginWriteAttribute("href", " href=\"", 874, "\"", 913, 1);
#nullable restore
#line 25 "C:\Users\Jeffrey.000\source\repos\HotelHenry\Views\Huesped\_Logueado.cshtml"
WriteAttributeValue("", 881, Url.Action("SignUp", "Huesped"), 881, 32, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">SignUp</a>\r\n    </li>\r\n");
#nullable restore
#line 27 "C:\Users\Jeffrey.000\source\repos\HotelHenry\Views\Huesped\_Logueado.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
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
