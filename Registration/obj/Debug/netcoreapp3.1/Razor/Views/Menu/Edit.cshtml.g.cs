#pragma checksum "C:\Users\alesy\source\repos\registration-employees\Registration\Views\Menu\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "379a921622cae2b67370cc669d6a62dfa8abbf4a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Menu_Edit), @"mvc.1.0.view", @"/Views/Menu/Edit.cshtml")]
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
#line 1 "C:\Users\alesy\source\repos\registration-employees\Registration\Views\_ViewImports.cshtml"
using Registration;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\alesy\source\repos\registration-employees\Registration\Views\_ViewImports.cshtml"
using Registration.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"379a921622cae2b67370cc669d6a62dfa8abbf4a", @"/Views/Menu/Edit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5f34bfc4539301239ec0930c0d87a0544d185e95", @"/Views/_ViewImports.cshtml")]
    public class Views_Menu_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Registration.Models.Employee>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\alesy\source\repos\registration-employees\Registration\Views\Menu\Edit.cshtml"
  
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Employee #");
#nullable restore
#line 6 "C:\Users\alesy\source\repos\registration-employees\Registration\Views\Menu\Edit.cshtml"
         Write(Model.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n");
#nullable restore
#line 7 "C:\Users\alesy\source\repos\registration-employees\Registration\Views\Menu\Edit.cshtml"
 using (Html.BeginForm("Edit", "Menu", FormMethod.Post))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\alesy\source\repos\registration-employees\Registration\Views\Menu\Edit.cshtml"
Write(Html.HiddenFor(m => m.Id));

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\alesy\source\repos\registration-employees\Registration\Views\Menu\Edit.cshtml"
Write(Html.LabelFor(model => model.Name, "Name"));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n");
#nullable restore
#line 13 "C:\Users\alesy\source\repos\registration-employees\Registration\Views\Menu\Edit.cshtml"
Write(Html.EditorFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n<br />\r\n");
#nullable restore
#line 16 "C:\Users\alesy\source\repos\registration-employees\Registration\Views\Menu\Edit.cshtml"
Write(Html.LabelFor(model => model.SurName, "SurName"));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n");
#nullable restore
#line 18 "C:\Users\alesy\source\repos\registration-employees\Registration\Views\Menu\Edit.cshtml"
Write(Html.EditorFor(model => model.SurName));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n<br />\r\n");
#nullable restore
#line 21 "C:\Users\alesy\source\repos\registration-employees\Registration\Views\Menu\Edit.cshtml"
Write(Html.LabelFor(model => model.Patronymic, "Patronymic"));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n");
#nullable restore
#line 23 "C:\Users\alesy\source\repos\registration-employees\Registration\Views\Menu\Edit.cshtml"
Write(Html.EditorFor(model => model.Patronymic));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n<br />\r\n");
#nullable restore
#line 26 "C:\Users\alesy\source\repos\registration-employees\Registration\Views\Menu\Edit.cshtml"
Write(Html.LabelFor(model => model.EmploymentDate, "Employment Date"));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n");
#nullable restore
#line 28 "C:\Users\alesy\source\repos\registration-employees\Registration\Views\Menu\Edit.cshtml"
Write(Html.EditorFor(model => model.EmploymentDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n<br />\r\n");
#nullable restore
#line 31 "C:\Users\alesy\source\repos\registration-employees\Registration\Views\Menu\Edit.cshtml"
Write(Html.LabelFor(model => model.Position, "Position"));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n");
#nullable restore
#line 33 "C:\Users\alesy\source\repos\registration-employees\Registration\Views\Menu\Edit.cshtml"
Write(Html.EditorFor(model => model.Position));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n<br />\r\n");
#nullable restore
#line 36 "C:\Users\alesy\source\repos\registration-employees\Registration\Views\Menu\Edit.cshtml"
Write(Html.LabelFor(model => model.Company.Name, "Company"));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n");
#nullable restore
#line 38 "C:\Users\alesy\source\repos\registration-employees\Registration\Views\Menu\Edit.cshtml"
Write(Html.EditorFor(model => model.Company.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n<br />\r\n<input type=\"submit\" value=\"Edit\" />\r\n");
#nullable restore
#line 42 "C:\Users\alesy\source\repos\registration-employees\Registration\Views\Menu\Edit.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Registration.Models.Employee> Html { get; private set; }
    }
}
#pragma warning restore 1591