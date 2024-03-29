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

namespace WorkSuite.Library.Asp.Net.Mvc.Presentation.Controls.Tiles
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
    
    #line 2 "..\..\Controls\Tiles\TileControl.cshtml"
    using Controls.Primitives;
    
    #line default
    #line hidden
    
    #line 3 "..\..\Controls\Tiles\TileControl.cshtml"
    using Server.Framework.ViewModels.Tiles;
    
    #line default
    #line hidden
    
    #line 4 "..\..\Controls\Tiles\TileControl.cshtml"
    using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    internal class TileControl
    {

public static System.Web.WebPages.HelperResult Render(Tile tile) {
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {



#line 6 "..\..\Controls\Tiles\TileControl.cshtml"
                           
    Guard.IsNotNull( tile, "tile" );
    
    var context_specific_classes = tile.classes.AsHtmlClassString();
    

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "    <div class=\"tile ");



#line 11 "..\..\Controls\Tiles\TileControl.cshtml"
WebViewPage.WriteTo(@__razor_helper_writer, context_specific_classes);

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\">\r\n    <a href=\"");



#line 12 "..\..\Controls\Tiles\TileControl.cshtml"
WebViewPage.WriteTo(@__razor_helper_writer, tile.url);

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\">\r\n        <h3>");



#line 13 "..\..\Controls\Tiles\TileControl.cshtml"
WebViewPage.WriteTo(@__razor_helper_writer, tile.title);

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "</h3>\r\n    </a>\r\n</div>\r\n");



#line 16 "..\..\Controls\Tiles\TileControl.cshtml"

        

#line default
#line hidden

});

}


    }
}
#pragma warning restore 1591
