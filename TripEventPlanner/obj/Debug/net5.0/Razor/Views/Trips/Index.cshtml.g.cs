#pragma checksum "E:\School Folder\PBA Webdevelopment\Semester1\Backendprogrammering\src\TripEventPlanner\TripEventPlanner\TripEventPlanner\Views\Trips\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "475cde7791b249d3ec74bfc09f210efef5f5e277"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Trips_Index), @"mvc.1.0.view", @"/Views/Trips/Index.cshtml")]
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
#line 1 "E:\School Folder\PBA Webdevelopment\Semester1\Backendprogrammering\src\TripEventPlanner\TripEventPlanner\TripEventPlanner\Views\_ViewImports.cshtml"
using TripEventPlanner;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\School Folder\PBA Webdevelopment\Semester1\Backendprogrammering\src\TripEventPlanner\TripEventPlanner\TripEventPlanner\Views\_ViewImports.cshtml"
using TripEventPlanner.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"475cde7791b249d3ec74bfc09f210efef5f5e277", @"/Views/Trips/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"da44cc650cd304ab64d65c9ef881dc5706f69b6f", @"/Views/_ViewImports.cshtml")]
    public class Views_Trips_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<TripEventPlanner.Models.Trip>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "E:\School Folder\PBA Webdevelopment\Semester1\Backendprogrammering\src\TripEventPlanner\TripEventPlanner\TripEventPlanner\Views\Trips\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<section>\r\n    <h1>My Trips</h1>\r\n</section>\r\n\r\n");
#nullable restore
#line 11 "E:\School Folder\PBA Webdevelopment\Semester1\Backendprogrammering\src\TripEventPlanner\TripEventPlanner\TripEventPlanner\Views\Trips\Index.cshtml"
 foreach (var item in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <section class=\"flex\">\r\n");
#nullable restore
#line 15 "E:\School Folder\PBA Webdevelopment\Semester1\Backendprogrammering\src\TripEventPlanner\TripEventPlanner\TripEventPlanner\Views\Trips\Index.cshtml"
         if (item.StartDate > DateTime.Now)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <section class=\"flex-wrapper\">\r\n                <figure>\r\n                    <img");
            BeginWriteAttribute("src", " src=\"", 434, "\"", 492, 1);
#nullable restore
#line 19 "E:\School Folder\PBA Webdevelopment\Semester1\Backendprogrammering\src\TripEventPlanner\TripEventPlanner\TripEventPlanner\Views\Trips\Index.cshtml"
WriteAttributeValue("", 440, Html.DisplayFor(modelItem => item.Country.ImageUrl), 440, 52, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"Alternate Text\"");
            BeginWriteAttribute("class", " class=\"", 514, "\"", 522, 0);
            EndWriteAttribute();
            WriteLiteral(" />\r\n                    <figcaption>");
#nullable restore
#line 20 "E:\School Folder\PBA Webdevelopment\Semester1\Backendprogrammering\src\TripEventPlanner\TripEventPlanner\TripEventPlanner\Views\Trips\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("</figcaption>\r\n                </figure>\r\n                <p> ");
#nullable restore
#line 22 "E:\School Folder\PBA Webdevelopment\Semester1\Backendprogrammering\src\TripEventPlanner\TripEventPlanner\TripEventPlanner\Views\Trips\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.StartDate));

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 22 "E:\School Folder\PBA Webdevelopment\Semester1\Backendprogrammering\src\TripEventPlanner\TripEventPlanner\TripEventPlanner\Views\Trips\Index.cshtml"
                                                               Write(Html.DisplayFor(modelItem => item.EndDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            </section>\r\n");
#nullable restore
#line 24 "E:\School Folder\PBA Webdevelopment\Semester1\Backendprogrammering\src\TripEventPlanner\TripEventPlanner\TripEventPlanner\Views\Trips\Index.cshtml"

        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </section>\r\n");
            WriteLiteral("    <section>\r\n");
#nullable restore
#line 30 "E:\School Folder\PBA Webdevelopment\Semester1\Backendprogrammering\src\TripEventPlanner\TripEventPlanner\TripEventPlanner\Views\Trips\Index.cshtml"
         foreach (var location in item.Country.Locations)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <h1>");
#nullable restore
#line 32 "E:\School Folder\PBA Webdevelopment\Semester1\Backendprogrammering\src\TripEventPlanner\TripEventPlanner\TripEventPlanner\Views\Trips\Index.cshtml"
           Write(location.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n");
#nullable restore
#line 34 "E:\School Folder\PBA Webdevelopment\Semester1\Backendprogrammering\src\TripEventPlanner\TripEventPlanner\TripEventPlanner\Views\Trips\Index.cshtml"
             foreach (var hej in location.Activities)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <h3>");
#nullable restore
#line 36 "E:\School Folder\PBA Webdevelopment\Semester1\Backendprogrammering\src\TripEventPlanner\TripEventPlanner\TripEventPlanner\Views\Trips\Index.cshtml"
               Write(hej.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                <h3>");
#nullable restore
#line 37 "E:\School Folder\PBA Webdevelopment\Semester1\Backendprogrammering\src\TripEventPlanner\TripEventPlanner\TripEventPlanner\Views\Trips\Index.cshtml"
               Write(hej.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n");
#nullable restore
#line 38 "E:\School Folder\PBA Webdevelopment\Semester1\Backendprogrammering\src\TripEventPlanner\TripEventPlanner\TripEventPlanner\Views\Trips\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 38 "E:\School Folder\PBA Webdevelopment\Semester1\Backendprogrammering\src\TripEventPlanner\TripEventPlanner\TripEventPlanner\Views\Trips\Index.cshtml"
             

        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n    </section>\r\n");
#nullable restore
#line 44 "E:\School Folder\PBA Webdevelopment\Semester1\Backendprogrammering\src\TripEventPlanner\TripEventPlanner\TripEventPlanner\Views\Trips\Index.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<TripEventPlanner.Models.Trip>> Html { get; private set; }
    }
}
#pragma warning restore 1591
