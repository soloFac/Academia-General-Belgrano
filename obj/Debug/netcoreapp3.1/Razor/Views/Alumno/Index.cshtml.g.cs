#pragma checksum "C:\Users\Franco\Desktop\Repositorios\AGB\Proyecto\Views\Alumno\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "72a56a4e310095289fe73a07aa3b58e8661fb89d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Alumno_Index), @"mvc.1.0.view", @"/Views/Alumno/Index.cshtml")]
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
#line 1 "C:\Users\Franco\Desktop\Repositorios\AGB\Proyecto\Views\_ViewImports.cshtml"
using Proyecto;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Franco\Desktop\Repositorios\AGB\Proyecto\Views\_ViewImports.cshtml"
using Proyecto.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Franco\Desktop\Repositorios\AGB\Proyecto\Views\_ViewImports.cshtml"
using Proyecto.Entidades;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Franco\Desktop\Repositorios\AGB\Proyecto\Views\_ViewImports.cshtml"
using Proyecto.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"72a56a4e310095289fe73a07aa3b58e8661fb89d", @"/Views/Alumno/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5b996767206e3279f8aefde860e76985de865a97", @"/Views/_ViewImports.cshtml")]
    public class Views_Alumno_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Proyecto.Entidades.Alumno>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<header>
    <h1>Listado Usuarios</h1>
</header>

<table class=""table"">
    <tr>
        <th>Nombre</th>
        <th>Apellido</th>
        <th>Mail</th>
        <th>DNI</th>
        <th>FechaNacimiento</th>
        <th>Provincia</th>
        <th>Departamento</th>
        <th>Localidad</th>
        <th>Domicilio</th>
        <th>Turno</th>
        <th>Establecimiento</th>
        <th>Grupo</th>
        <th>Curso</th>
");
            WriteLiteral("        <th>Estado</th>\r\n        <th>Instituto</th>\r\n    </tr>\r\n\r\n");
#nullable restore
#line 27 "C:\Users\Franco\Desktop\Repositorios\AGB\Proyecto\Views\Alumno\Index.cshtml"
     foreach (Alumno alumno in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr id=\"tablerow\">\r\n            <td>");
#nullable restore
#line 30 "C:\Users\Franco\Desktop\Repositorios\AGB\Proyecto\Views\Alumno\Index.cshtml"
           Write(alumno.Nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 31 "C:\Users\Franco\Desktop\Repositorios\AGB\Proyecto\Views\Alumno\Index.cshtml"
           Write(alumno.Apellido);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 32 "C:\Users\Franco\Desktop\Repositorios\AGB\Proyecto\Views\Alumno\Index.cshtml"
           Write(alumno.Mail);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 33 "C:\Users\Franco\Desktop\Repositorios\AGB\Proyecto\Views\Alumno\Index.cshtml"
           Write(alumno.DNI);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 34 "C:\Users\Franco\Desktop\Repositorios\AGB\Proyecto\Views\Alumno\Index.cshtml"
           Write(alumno.FechaNacimiento);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 35 "C:\Users\Franco\Desktop\Repositorios\AGB\Proyecto\Views\Alumno\Index.cshtml"
           Write(alumno.Provincia);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 36 "C:\Users\Franco\Desktop\Repositorios\AGB\Proyecto\Views\Alumno\Index.cshtml"
           Write(alumno.Departamento);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 37 "C:\Users\Franco\Desktop\Repositorios\AGB\Proyecto\Views\Alumno\Index.cshtml"
           Write(alumno.Localidad);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 38 "C:\Users\Franco\Desktop\Repositorios\AGB\Proyecto\Views\Alumno\Index.cshtml"
           Write(alumno.Domicilio);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 39 "C:\Users\Franco\Desktop\Repositorios\AGB\Proyecto\Views\Alumno\Index.cshtml"
           Write(alumno.Turno);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 40 "C:\Users\Franco\Desktop\Repositorios\AGB\Proyecto\Views\Alumno\Index.cshtml"
           Write(alumno.Establecimiento);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
            WriteLiteral("            <td></td>\r\n            <td>");
#nullable restore
#line 43 "C:\Users\Franco\Desktop\Repositorios\AGB\Proyecto\Views\Alumno\Index.cshtml"
           Write(alumno.Curso);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
            WriteLiteral("            <td>");
#nullable restore
#line 45 "C:\Users\Franco\Desktop\Repositorios\AGB\Proyecto\Views\Alumno\Index.cshtml"
           Write(alumno.Estado);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 46 "C:\Users\Franco\Desktop\Repositorios\AGB\Proyecto\Views\Alumno\Index.cshtml"
           Write(alumno.Instituto);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\r\n");
#nullable restore
#line 48 "C:\Users\Franco\Desktop\Repositorios\AGB\Proyecto\Views\Alumno\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Proyecto.Entidades.Alumno>> Html { get; private set; }
    }
}
#pragma warning restore 1591
