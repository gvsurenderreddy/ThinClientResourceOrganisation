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

namespace WorkSuite.Library.Asp.Net.Mvc.Presentation.Controls.Editors
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
    
    #line 3 "..\..\Controls\Editors\Editors.cshtml"
    using Controls.Editors;
    
    #line default
    #line hidden
    
    #line 4 "..\..\Controls\Editors\Editors.cshtml"
    using Controls.ViewElements;
    
    #line default
    #line hidden
    
    #line 5 "..\..\Controls\Editors\Editors.cshtml"
    using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels;
    
    #line default
    #line hidden
    
    #line 6 "..\..\Controls\Editors\Editors.cshtml"
    using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    public static class Editors
    {

public static System.Web.WebPages.HelperResult For( IsAViewElement element ) {
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {



#line 10 "..\..\Controls\Editors\Editors.cshtml"
                                       
    
    
#line default
#line hidden


#line 12 "..\..\Controls\Editors\Editors.cshtml"
WebViewPage.WriteTo(@__razor_helper_writer, ViewElement.Unknown(  ));

#line default
#line hidden


#line 12 "..\..\Controls\Editors\Editors.cshtml"
                            

#line default
#line hidden

});

}


public static System.Web.WebPages.HelperResult For( Editor view_model ){
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {



#line 18 "..\..\Controls\Editors\Editors.cshtml"
                                 
    var has_description = !string.IsNullOrWhiteSpace(@view_model.description);

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "    <form   \r\n        data-component=\"editor\"      \r\n        id=\"");



#line 22 "..\..\Controls\Editors\Editors.cshtml"
WebViewPage.WriteTo(@__razor_helper_writer, view_model.id);

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\"\r\n        class=\"editor\"\r\n          data-type=\"");



#line 24 "..\..\Controls\Editors\Editors.cshtml"
WebViewPage.WriteTo(@__razor_helper_writer, view_model.data_type);

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\">\r\n          \r\n        <fieldset>\r\n            <legend class=\"editor-title\">");



#line 27 "..\..\Controls\Editors\Editors.cshtml"
WebViewPage.WriteTo(@__razor_helper_writer, view_model.title);

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "</legend>\r\n");



#line 28 "..\..\Controls\Editors\Editors.cshtml"
             if (has_description)
            {
#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "<div class=\"Report_Instructions\">");



#line 29 "..\..\Controls\Editors\Editors.cshtml"
   WebViewPage.WriteTo(@__razor_helper_writer, view_model.description);

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "</div> ");



#line 29 "..\..\Controls\Editors\Editors.cshtml"
                                                                            }

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "            ");



#line 30 "..\..\Controls\Editors\Editors.cshtml"
WebViewPage.WriteTo(@__razor_helper_writer, EditorFields.For( view_model.fields ));

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\r\n            ");



#line 31 "..\..\Controls\Editors\Editors.cshtml"
WebViewPage.WriteTo(@__razor_helper_writer, EditorActions.For( view_model.actions, view_model.data_type ));

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\r\n        </fieldset>\r\n    </form>        \r\n");



#line 34 "..\..\Controls\Editors\Editors.cshtml"

#line default
#line hidden

});

}


    }
}
#pragma warning restore 1591
