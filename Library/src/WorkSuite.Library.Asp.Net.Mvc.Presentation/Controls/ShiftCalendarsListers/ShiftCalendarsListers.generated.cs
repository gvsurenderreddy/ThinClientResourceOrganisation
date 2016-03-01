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

namespace WorkSuite.Library.Asp.Net.Mvc.Presentation.Controls.ShiftCalendarsListers
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
    
    #line 3 "..\..\Controls\ShiftCalendarsListers\ShiftCalendarsListers.cshtml"
    using Controls.Primitives;
    
    #line default
    #line hidden
    
    #line 4 "..\..\Controls\ShiftCalendarsListers\ShiftCalendarsListers.cshtml"
    using Controls.ShiftCalendars;
    
    #line default
    #line hidden
    
    #line 5 "..\..\Controls\ShiftCalendarsListers\ShiftCalendarsListers.cshtml"
    using Controls.ShiftCalendarsListers;
    
    #line default
    #line hidden
    
    #line 6 "..\..\Controls\ShiftCalendarsListers\ShiftCalendarsListers.cshtml"
    using Controls.ViewElements;
    
    #line default
    #line hidden
    
    #line 7 "..\..\Controls\ShiftCalendarsListers\ShiftCalendarsListers.cshtml"
    using Server.Framework.ViewModels;
    
    #line default
    #line hidden
    
    #line 8 "..\..\Controls\ShiftCalendarsListers\ShiftCalendarsListers.cshtml"
    using Server.ShiftCalendars;
    
    #line default
    #line hidden
    
    #line 9 "..\..\Controls\ShiftCalendarsListers\ShiftCalendarsListers.cshtml"
    using Server.ShiftCalendarsListers;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    public static class ShiftCalendarsListers
    {

public static System.Web.WebPages.HelperResult For(IsAViewElement element)
{
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {



#line 13 "..\..\Controls\ShiftCalendarsListers\ShiftCalendarsListers.cshtml"
 

    
#line default
#line hidden


#line 15 "..\..\Controls\ShiftCalendarsListers\ShiftCalendarsListers.cshtml"
WebViewPage.WriteTo(@__razor_helper_writer, ViewElement.Unknown());

#line default
#line hidden


#line 15 "..\..\Controls\ShiftCalendarsListers\ShiftCalendarsListers.cshtml"
                          

#line default
#line hidden

});

}


public static System.Web.WebPages.HelperResult For(ShiftCalendarsLister view_model)
{
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {



#line 21 "..\..\Controls\ShiftCalendarsListers\ShiftCalendarsListers.cshtml"
 


#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "    <section data-component=\"shift-calendars-lister\" class=\"shift-calendars-liste" +
"r\">\r\n\r\n        <article class=\"shift-calendars-lister-header ");



#line 25 "..\..\Controls\ShiftCalendarsListers\ShiftCalendarsListers.cshtml"
           WebViewPage.WriteTo(@__razor_helper_writer, view_model.classes.AsHtmlClassString());

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\">\r\n            <h2>");



#line 26 "..\..\Controls\ShiftCalendarsListers\ShiftCalendarsListers.cshtml"
WebViewPage.WriteTo(@__razor_helper_writer, view_model.title);

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "</h2>\r\n            ");



#line 27 "..\..\Controls\ShiftCalendarsListers\ShiftCalendarsListers.cshtml"
WebViewPage.WriteTo(@__razor_helper_writer, ShiftCalendarsListerActions.For(view_model.actions));

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\r\n        </article>\r\n\r\n");



#line 30 "..\..\Controls\ShiftCalendarsListers\ShiftCalendarsListers.cshtml"
         foreach (var shift_calendar in @view_model.all_shift_calendars)
        {
            
#line default
#line hidden


#line 32 "..\..\Controls\ShiftCalendarsListers\ShiftCalendarsListers.cshtml"
WebViewPage.WriteTo(@__razor_helper_writer, ShiftCalendars.For(shift_calendar));

#line default
#line hidden


#line 32 "..\..\Controls\ShiftCalendarsListers\ShiftCalendarsListers.cshtml"
                                               
        }

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "    </section>\r\n");



#line 35 "..\..\Controls\ShiftCalendarsListers\ShiftCalendarsListers.cshtml"


#line default
#line hidden

});

}


    }
}
#pragma warning restore 1591
