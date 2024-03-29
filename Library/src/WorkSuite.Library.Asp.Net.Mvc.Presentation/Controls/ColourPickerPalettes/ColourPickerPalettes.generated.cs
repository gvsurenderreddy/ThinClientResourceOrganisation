﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WorkSuite.Library.Asp.Net.Mvc.Presentation.Controls.ColourPickerPalettes
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
    
    #line 3 "..\..\Controls\ColourPickerPalettes\ColourPickerPalettes.cshtml"
    using WorkSuite.Library.Asp.Net.Mvc.Presentation.Controls.ViewElements;
    
    #line default
    #line hidden
    
    #line 4 "..\..\Controls\ColourPickerPalettes\ColourPickerPalettes.cshtml"
    using WorkSuite.Library.Asp.Net.Mvc.Server.ColourPickerPalettes;
    
    #line default
    #line hidden
    
    #line 5 "..\..\Controls\ColourPickerPalettes\ColourPickerPalettes.cshtml"
    using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    public static class ColourPickerPalettes
    {

public static System.Web.WebPages.HelperResult For(IsAViewElement element)
{
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {



#line 9 "..\..\Controls\ColourPickerPalettes\ColourPickerPalettes.cshtml"
 
    
#line default
#line hidden


#line 10 "..\..\Controls\ColourPickerPalettes\ColourPickerPalettes.cshtml"
WebViewPage.WriteTo(@__razor_helper_writer, ViewElement.Unknown());

#line default
#line hidden


#line 10 "..\..\Controls\ColourPickerPalettes\ColourPickerPalettes.cshtml"
                          

#line default
#line hidden

});

}


public static System.Web.WebPages.HelperResult For(ColourPickerPalette view_model)
{
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {



#line 15 "..\..\Controls\ColourPickerPalettes\ColourPickerPalettes.cshtml"
 

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "    <div class=\"ColourPicker-Palette\">\r\n        <div class=\"ColourPicker-Palette-" +
"Close\">");



#line 17 "..\..\Controls\ColourPickerPalettes\ColourPickerPalettes.cshtml"
     WebViewPage.WriteTo(@__razor_helper_writer, view_model.close_button_title);

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "</div>\r\n        <div class=\"ColourPicker-Palette-Current\">\r\n            <div clas" +
"s=\"current-colour-value\" style=\"background-color:");



#line 19 "..\..\Controls\ColourPickerPalettes\ColourPickerPalettes.cshtml"
                           WebViewPage.WriteTo(@__razor_helper_writer, view_model.current_colour_value);

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, ";\"></div>\r\n        </div>\r\n        <div class=\"ColourPicker-Palette-Common\">\r\n");



#line 22 "..\..\Controls\ColourPickerPalettes\ColourPickerPalettes.cshtml"
             foreach (var colour in view_model.accellerator_colour_values)
            {

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "                <div data-colour-value=\"");



#line 24 "..\..\Controls\ColourPickerPalettes\ColourPickerPalettes.cshtml"
WebViewPage.WriteTo(@__razor_helper_writer, colour);

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\" style=\"background-color:");



#line 24 "..\..\Controls\ColourPickerPalettes\ColourPickerPalettes.cshtml"
                              WebViewPage.WriteTo(@__razor_helper_writer, colour);

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, ";\"></div>\r\n");



#line 25 "..\..\Controls\ColourPickerPalettes\ColourPickerPalettes.cshtml"
            }

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "        </div>\r\n        <div class=\"ColourPicker-Palette-Time\">\r\n            <tab" +
"le>\r\n");



#line 29 "..\..\Controls\ColourPickerPalettes\ColourPickerPalettes.cshtml"
                 foreach (var entry in view_model.palette_entries)
                {

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "                    <tr>\r\n                        <td>");



#line 32 "..\..\Controls\ColourPickerPalettes\ColourPickerPalettes.cshtml"
WebViewPage.WriteTo(@__razor_helper_writer, entry.title);

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "</td>\r\n");



#line 33 "..\..\Controls\ColourPickerPalettes\ColourPickerPalettes.cshtml"
                         foreach (var colour_value in entry.colour_values)
                        {

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "                            <td>\r\n                                <div data-colou" +
"r-value=\"");



#line 36 "..\..\Controls\ColourPickerPalettes\ColourPickerPalettes.cshtml"
             WebViewPage.WriteTo(@__razor_helper_writer, colour_value);

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\" style=\"background-color: ");



#line 36 "..\..\Controls\ColourPickerPalettes\ColourPickerPalettes.cshtml"
                                                     WebViewPage.WriteTo(@__razor_helper_writer, colour_value);

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, ";\"></div>\r\n                            </td>\r\n");



#line 38 "..\..\Controls\ColourPickerPalettes\ColourPickerPalettes.cshtml"
                        }

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "                    </tr>\r\n");



#line 40 "..\..\Controls\ColourPickerPalettes\ColourPickerPalettes.cshtml"
                }

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "            </table>\r\n        </div>\r\n    </div>\r\n");



#line 44 "..\..\Controls\ColourPickerPalettes\ColourPickerPalettes.cshtml"

#line default
#line hidden

});

}


    }
}
#pragma warning restore 1591
