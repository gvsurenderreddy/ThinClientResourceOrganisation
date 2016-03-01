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

namespace WorkSuite.Library.Asp.Net.Mvc.Presentation.Controls.Reports
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
    
    #line 3 "..\..\Controls\Reports\ReportFields.cshtml"
    using Humanizer;
    
    #line default
    #line hidden
    
    #line 9 "..\..\Controls\Reports\ReportFields.cshtml"
    using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields;
    
    #line default
    #line hidden
    
    #line 10 "..\..\Controls\Reports\ReportFields.cshtml"
    using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.BooleanField;
    
    #line default
    #line hidden
    
    #line 8 "..\..\Controls\Reports\ReportFields.cshtml"
    using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.DurationRequestField;
    
    #line default
    #line hidden
    
    #line 11 "..\..\Controls\Reports\ReportFields.cshtml"
    using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.ImageField;
    
    #line default
    #line hidden
    
    #line 12 "..\..\Controls\Reports\ReportFields.cshtml"
    using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.MultiLineFields;
    
    #line default
    #line hidden
    
    #line 4 "..\..\Controls\Reports\ReportFields.cshtml"
    using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.RGBColourField;
    
    #line default
    #line hidden
    
    #line 5 "..\..\Controls\Reports\ReportFields.cshtml"
    using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.ServiceStateField;
    
    #line default
    #line hidden
    
    #line 6 "..\..\Controls\Reports\ReportFields.cshtml"
    using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.SimpleImageField;
    
    #line default
    #line hidden
    
    #line 13 "..\..\Controls\Reports\ReportFields.cshtml"
    using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.StringField;
    
    #line default
    #line hidden
    
    #line 7 "..\..\Controls\Reports\ReportFields.cshtml"
    using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.TimeRequestField;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    public static class ReportFields
    {

public static System.Web.WebPages.HelperResult For(IEnumerable<Field> fields)
{
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {



#line 18 "..\..\Controls\Reports\ReportFields.cshtml"
 

    if (fields.Any())
    {


#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "        <dl>\r\n\r\n");



#line 25 "..\..\Controls\Reports\ReportFields.cshtml"
             foreach (var field in fields)
            {
                
#line default
#line hidden


#line 27 "..\..\Controls\Reports\ReportFields.cshtml"
WebViewPage.WriteTo(@__razor_helper_writer, Field(field as dynamic));

#line default
#line hidden


#line 27 "..\..\Controls\Reports\ReportFields.cshtml"
                                        
            }

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "        </dl>\r\n");



#line 30 "..\..\Controls\Reports\ReportFields.cshtml"
    }

#line default
#line hidden

});

}


public static System.Web.WebPages.HelperResult Field(Field field)
{
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {



#line 38 "..\..\Controls\Reports\ReportFields.cshtml"
 


#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "    <dt>Unknown field</dt>\r\n");



#line 41 "..\..\Controls\Reports\ReportFields.cshtml"

#line default
#line hidden

});

}


public static System.Web.WebPages.HelperResult Field(WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.CalendarAffected.ACalendarAffectedField field)
{
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {



#line 44 "..\..\Controls\Reports\ReportFields.cshtml"
 
    
#line default
#line hidden


#line 45 "..\..\Controls\Reports\ReportFields.cshtml"
WebViewPage.WriteTo(@__razor_helper_writer, Title(field.title));

#line default
#line hidden


#line 45 "..\..\Controls\Reports\ReportFields.cshtml"
                       

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "    <dd>\r\n        <dl class=\"CalendarsAffected\">\r\n");



#line 48 "..\..\Controls\Reports\ReportFields.cshtml"
             foreach (var calander_field in field.value)
            {

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "                <dt class=\"DescriptionList-Title\">");



#line 50 "..\..\Controls\Reports\ReportFields.cshtml"
       WebViewPage.WriteTo(@__razor_helper_writer, calander_field.name);

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "</dt>\r\n");



WebViewPage.WriteLiteralTo(@__razor_helper_writer, "                <dd class=\"DescriptionList-Value\">Occurrences ");



#line 51 "..\..\Controls\Reports\ReportFields.cshtml"
                   WebViewPage.WriteTo(@__razor_helper_writer, calander_field.count);

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "</dd>\r\n");



#line 52 "..\..\Controls\Reports\ReportFields.cshtml"
            }

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "        </dl>\r\n    </dd>\r\n");



#line 55 "..\..\Controls\Reports\ReportFields.cshtml"


#line default
#line hidden

});

}


public static System.Web.WebPages.HelperResult Field(ADurationRequestField field)
{
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {



#line 59 "..\..\Controls\Reports\ReportFields.cshtml"
 
    
#line default
#line hidden


#line 60 "..\..\Controls\Reports\ReportFields.cshtml"
WebViewPage.WriteTo(@__razor_helper_writer, Title(field.title));

#line default
#line hidden


#line 60 "..\..\Controls\Reports\ReportFields.cshtml"
                       
    var duration = "";
    if (@field.value.minutes == "0")
    {
        duration = string.Format("{0}{1}", @field.value.hours, "h");
    }
    else if (@field.value.hours == "0")
    {
        duration = string.Format("{0}{1}", @field.value.minutes, "m");
    }
    else
    {
        duration = string.Format("{0}{1}{2}{3}{4}", @field.value.hours, "h", " ", @field.value.minutes, "m");
    }

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "    <dd id=\"");



#line 74 "..\..\Controls\Reports\ReportFields.cshtml"
WebViewPage.WriteTo(@__razor_helper_writer, field.id);

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\">");



#line 74 "..\..\Controls\Reports\ReportFields.cshtml"
WebViewPage.WriteTo(@__razor_helper_writer, duration);

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "</dd>\r\n");



#line 75 "..\..\Controls\Reports\ReportFields.cshtml"

#line default
#line hidden

});

}


public static System.Web.WebPages.HelperResult Field(AStringReportField field)
{
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {



#line 80 "..\..\Controls\Reports\ReportFields.cshtml"
 
    var field_value = field.humanize ? field.value.Humanize(LetterCasing.Sentence) : field.value;

    
#line default
#line hidden


#line 83 "..\..\Controls\Reports\ReportFields.cshtml"
WebViewPage.WriteTo(@__razor_helper_writer, Title(field.title));

#line default
#line hidden


#line 83 "..\..\Controls\Reports\ReportFields.cshtml"
                       
    
#line default
#line hidden


#line 84 "..\..\Controls\Reports\ReportFields.cshtml"
WebViewPage.WriteTo(@__razor_helper_writer, Body(field.id, field_value, field.icon, field.is_rich_text));

#line default
#line hidden


#line 84 "..\..\Controls\Reports\ReportFields.cshtml"
                                                                

#line default
#line hidden

});

}


public static System.Web.WebPages.HelperResult Field(ABooleanReportField field)
{
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {



#line 88 "..\..\Controls\Reports\ReportFields.cshtml"
 
    
#line default
#line hidden


#line 89 "..\..\Controls\Reports\ReportFields.cshtml"
WebViewPage.WriteTo(@__razor_helper_writer, Title(field.title));

#line default
#line hidden


#line 89 "..\..\Controls\Reports\ReportFields.cshtml"
                       
    
#line default
#line hidden


#line 90 "..\..\Controls\Reports\ReportFields.cshtml"
WebViewPage.WriteTo(@__razor_helper_writer, YesNoBoolean(field.id, field.value));

#line default
#line hidden


#line 90 "..\..\Controls\Reports\ReportFields.cshtml"
                                        


#line default
#line hidden

});

}


public static System.Web.WebPages.HelperResult Field(AnImageField field)
{
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {



#line 97 "..\..\Controls\Reports\ReportFields.cshtml"
 
    
#line default
#line hidden


#line 98 "..\..\Controls\Reports\ReportFields.cshtml"
WebViewPage.WriteTo(@__razor_helper_writer, Title(field.title));

#line default
#line hidden


#line 98 "..\..\Controls\Reports\ReportFields.cshtml"
                       

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "    <dd id=\"");



#line 99 "..\..\Controls\Reports\ReportFields.cshtml"
WebViewPage.WriteTo(@__razor_helper_writer, field.id);

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\"><img src=");



#line 99 "..\..\Controls\Reports\ReportFields.cshtml"
WebViewPage.WriteTo(@__razor_helper_writer, field.url);

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, " alt=\"0\" width=\"120\"></dd>\r\n");



#line 100 "..\..\Controls\Reports\ReportFields.cshtml"

#line default
#line hidden

});

}


public static System.Web.WebPages.HelperResult Field(ASimpleImageField field)
{
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {



#line 105 "..\..\Controls\Reports\ReportFields.cshtml"
 

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "    <img src=");



#line 106 "..\..\Controls\Reports\ReportFields.cshtml"
WebViewPage.WriteTo(@__razor_helper_writer, field.url);

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, " alt=\"0\" width=\"120\" />\r\n");



#line 107 "..\..\Controls\Reports\ReportFields.cshtml"

#line default
#line hidden

});

}


public static System.Web.WebPages.HelperResult Field(AMultilineStringReportField field)
{
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {



#line 112 "..\..\Controls\Reports\ReportFields.cshtml"
 
    
#line default
#line hidden


#line 113 "..\..\Controls\Reports\ReportFields.cshtml"
WebViewPage.WriteTo(@__razor_helper_writer, Title(field.title));

#line default
#line hidden


#line 113 "..\..\Controls\Reports\ReportFields.cshtml"
                       
    
#line default
#line hidden


#line 114 "..\..\Controls\Reports\ReportFields.cshtml"
WebViewPage.WriteTo(@__razor_helper_writer, Lines(field.id, field.value));

#line default
#line hidden


#line 114 "..\..\Controls\Reports\ReportFields.cshtml"
                                 

#line default
#line hidden

});

}


public static System.Web.WebPages.HelperResult Field(AServiceStateField field)
{
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {



#line 119 "..\..\Controls\Reports\ReportFields.cshtml"
 
    
#line default
#line hidden


#line 120 "..\..\Controls\Reports\ReportFields.cshtml"
WebViewPage.WriteTo(@__razor_helper_writer, Title(field.title));

#line default
#line hidden


#line 120 "..\..\Controls\Reports\ReportFields.cshtml"
                       
    
#line default
#line hidden


#line 121 "..\..\Controls\Reports\ReportFields.cshtml"
WebViewPage.WriteTo(@__razor_helper_writer, Body(field.id, field.value.ToString().Humanize(LetterCasing.Sentence), field.icon, field.is_rich_text));

#line default
#line hidden


#line 121 "..\..\Controls\Reports\ReportFields.cshtml"
                                                                                                           

#line default
#line hidden

});

}


public static System.Web.WebPages.HelperResult Field(ARgbColourField field)
{
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {



#line 125 "..\..\Controls\Reports\ReportFields.cshtml"
 
    
#line default
#line hidden


#line 126 "..\..\Controls\Reports\ReportFields.cshtml"
WebViewPage.WriteTo(@__razor_helper_writer, Title(field.title));

#line default
#line hidden


#line 126 "..\..\Controls\Reports\ReportFields.cshtml"
                       

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "    <div class=\"editor-colour-wrapper\">\r\n        <div class=\"editor-colour-block\"" +
" style=\"background-color: rgb(");



#line 128 "..\..\Controls\Reports\ReportFields.cshtml"
                           WebViewPage.WriteTo(@__razor_helper_writer, string.Format("{0},{1},{2}",@field.value.R,@field.value.G,@field.value.B));

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, ")\">\r\n        </div>\r\n    </div>\r\n");



#line 131 "..\..\Controls\Reports\ReportFields.cshtml"

#line default
#line hidden

});

}


public static System.Web.WebPages.HelperResult Lines(string id, IEnumerable<string> lines)
{
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {



#line 136 "..\..\Controls\Reports\ReportFields.cshtml"
 
    var i = 1;

    foreach (var line in lines)
    {
        
#line default
#line hidden


#line 141 "..\..\Controls\Reports\ReportFields.cshtml"
WebViewPage.WriteTo(@__razor_helper_writer, Body(id + "-" + (i++), line));

#line default
#line hidden


#line 141 "..\..\Controls\Reports\ReportFields.cshtml"
                                     
    }

#line default
#line hidden

});

}


public static System.Web.WebPages.HelperResult Title(string value)
{
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {



#line 148 "..\..\Controls\Reports\ReportFields.cshtml"
 


#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "    <dt>");



#line 150 "..\..\Controls\Reports\ReportFields.cshtml"
WebViewPage.WriteTo(@__razor_helper_writer, value);

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "</dt>\r\n");



#line 151 "..\..\Controls\Reports\ReportFields.cshtml"

#line default
#line hidden

});

}


public static System.Web.WebPages.HelperResult Body(string id, string value, string icon = "", bool rich_text = false)
{
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {



#line 156 "..\..\Controls\Reports\ReportFields.cshtml"
 


#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "    <dd id=\"");



#line 158 "..\..\Controls\Reports\ReportFields.cshtml"
WebViewPage.WriteTo(@__razor_helper_writer, id);

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\" class=\"");



#line 158 "..\..\Controls\Reports\ReportFields.cshtml"
WebViewPage.WriteTo(@__razor_helper_writer, rich_text ? "rich-text":null);

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\">\r\n        ");



#line 159 "..\..\Controls\Reports\ReportFields.cshtml"
WebViewPage.WriteTo(@__razor_helper_writer, value);

#line default
#line hidden



#line 159 "..\..\Controls\Reports\ReportFields.cshtml"
                if (!string.IsNullOrEmpty(icon))
        {
#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "<span class=\"");



#line 160 "..\..\Controls\Reports\ReportFields.cshtml"
WebViewPage.WriteTo(@__razor_helper_writer, icon);

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\"></span>");



#line 160 "..\..\Controls\Reports\ReportFields.cshtml"
                                    }

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "    </dd>\r\n");



#line 162 "..\..\Controls\Reports\ReportFields.cshtml"

#line default
#line hidden

});

}


public static System.Web.WebPages.HelperResult YesNoBoolean(string id, Boolean value)
{
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {



#line 165 "..\..\Controls\Reports\ReportFields.cshtml"
 

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "    <dd id=\"");



#line 166 "..\..\Controls\Reports\ReportFields.cshtml"
WebViewPage.WriteTo(@__razor_helper_writer, id);

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\">");



#line 166 "..\..\Controls\Reports\ReportFields.cshtml"
WebViewPage.WriteTo(@__razor_helper_writer, value ? "Yes" : "No");

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "</dd>\r\n");



#line 167 "..\..\Controls\Reports\ReportFields.cshtml"

#line default
#line hidden

});

}


    }
}
#pragma warning restore 1591
