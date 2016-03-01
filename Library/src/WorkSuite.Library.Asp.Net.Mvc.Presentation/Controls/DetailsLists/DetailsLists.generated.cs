﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WorkSuite.Library.Asp.Net.Mvc.Presentation.Controls.DetailsLists
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
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    
    #line 3 "..\..\Controls\DetailsLists\DetailsLists.cshtml"
    using Controls.Reports;
    
    #line default
    #line hidden
    
    #line 4 "..\..\Controls\DetailsLists\DetailsLists.cshtml"
    using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    public static class DetailsLists
    {

public static System.Web.WebPages.HelperResult For(DetailsList view_model)
{
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {



#line 7 "..\..\Controls\DetailsLists\DetailsLists.cshtml"
 
    var has_description = !string.IsNullOrWhiteSpace(@view_model.header.description);
    

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "    <section id=\"");



#line 10 "..\..\Controls\DetailsLists\DetailsLists.cshtml"
WebViewPage.WriteTo(@__razor_helper_writer, view_model.id);

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\" class=\"report-wrapper ");



#line 10 "..\..\Controls\DetailsLists\DetailsLists.cshtml"
             WebViewPage.WriteTo(@__razor_helper_writer, view_model.is_sortable ? "sortable" : null);

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\">\r\n\r\n        <article \r\n        id=\"");



#line 13 "..\..\Controls\DetailsLists\DetailsLists.cshtml"
WebViewPage.WriteTo(@__razor_helper_writer, view_model.id);

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "-header\"\r\n        class=\"details-list-header report\" >\r\n            <h2>");



#line 15 "..\..\Controls\DetailsLists\DetailsLists.cshtml"
WebViewPage.WriteTo(@__razor_helper_writer, view_model.header.title);

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "</h2>\r\n            ");



#line 16 "..\..\Controls\DetailsLists\DetailsLists.cshtml"
WebViewPage.WriteTo(@__razor_helper_writer, ReportActions.For(@view_model.header.actions));

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\r\n");



#line 17 "..\..\Controls\DetailsLists\DetailsLists.cshtml"
             if (has_description){
#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "<p>");



#line 17 "..\..\Controls\DetailsLists\DetailsLists.cshtml"
WebViewPage.WriteTo(@__razor_helper_writer, view_model.header.description);

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "</p>");



#line 17 "..\..\Controls\DetailsLists\DetailsLists.cshtml"
                                                                       }

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "        </article>\r\n\r\n");



#line 20 "..\..\Controls\DetailsLists\DetailsLists.cshtml"
         foreach (var element in view_model.elements)
        {
            
#line default
#line hidden


#line 22 "..\..\Controls\DetailsLists\DetailsLists.cshtml"
WebViewPage.WriteTo(@__razor_helper_writer, Reports.For(element as dynamic));

#line default
#line hidden


#line 22 "..\..\Controls\DetailsLists\DetailsLists.cshtml"
                                            
        }

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\r\n\r\n    </section>\r\n");



#line 27 "..\..\Controls\DetailsLists\DetailsLists.cshtml"
        

#line default
#line hidden

});

}


    }
}
#pragma warning restore 1591