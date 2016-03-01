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
    
    #line 2 "..\..\Controls\Tiles\TileGridControl.cshtml"
    using Controls.Primitives;
    
    #line default
    #line hidden
    
    #line 3 "..\..\Controls\Tiles\TileGridControl.cshtml"
    using Controls.Tiles;
    
    #line default
    #line hidden
    
    #line 4 "..\..\Controls\Tiles\TileGridControl.cshtml"
    using Server.Framework.ViewModels.Tiles;
    
    #line default
    #line hidden
    
    #line 5 "..\..\Controls\Tiles\TileGridControl.cshtml"
    using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    internal class TileGridControl
    {

public static System.Web.WebPages.HelperResult Render( IEnumerable<Tile> tiles, IEnumerable<string> classes = null ) {
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {



#line 7 "..\..\Controls\Tiles\TileGridControl.cshtml"
                                                                               

    Guard.IsNotNull(tiles, "tiles");


#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "    <ul class=\"tile-grid ");



#line 11 "..\..\Controls\Tiles\TileGridControl.cshtml"
WebViewPage.WriteTo(@__razor_helper_writer, classes.AsHtmlClassString(  ));

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\">\r\n");



#line 12 "..\..\Controls\Tiles\TileGridControl.cshtml"
         foreach (var tile in tiles) {

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "            <li>\r\n                ");



#line 14 "..\..\Controls\Tiles\TileGridControl.cshtml"
WebViewPage.WriteTo(@__razor_helper_writer, TileControl.Render(tile));

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\r\n            </li>\r\n");



#line 16 "..\..\Controls\Tiles\TileGridControl.cshtml"
        }

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "    </ul>\r\n");



#line 18 "..\..\Controls\Tiles\TileGridControl.cshtml"

#line default
#line hidden

});

}


    }
}
#pragma warning restore 1591