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
    
    #line 3 "..\..\Controls\Tiles\Tiles.cshtml"
    using Controls.Primitives;
    
    #line default
    #line hidden
    
    #line 4 "..\..\Controls\Tiles\Tiles.cshtml"
    using Controls.Tiles;
    
    #line default
    #line hidden
    
    #line 5 "..\..\Controls\Tiles\Tiles.cshtml"
    using Controls.ViewElements;
    
    #line default
    #line hidden
    
    #line 6 "..\..\Controls\Tiles\Tiles.cshtml"
    using Server.Framework.ViewModels.SectionedTileGrid;
    
    #line default
    #line hidden
    
    #line 7 "..\..\Controls\Tiles\Tiles.cshtml"
    using Server.Framework.ViewModels.TileGrids;
    
    #line default
    #line hidden
    
    #line 8 "..\..\Controls\Tiles\Tiles.cshtml"
    using Server.Framework.ViewModels.Tiles;
    
    #line default
    #line hidden
    
    #line 9 "..\..\Controls\Tiles\Tiles.cshtml"
    using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    public static class Tiles
    {

public static System.Web.WebPages.HelperResult For ( IsAViewElement element ) {
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {



#line 11 "..\..\Controls\Tiles\Tiles.cshtml"
                                            
    
#line default
#line hidden


#line 12 "..\..\Controls\Tiles\Tiles.cshtml"
WebViewPage.WriteTo(@__razor_helper_writer, ViewElement.Unknown( ));

#line default
#line hidden


#line 12 "..\..\Controls\Tiles\Tiles.cshtml"
                           

#line default
#line hidden

});

}


public static System.Web.WebPages.HelperResult For( SectionedTileGrid tile_grid ) {
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {



#line 15 "..\..\Controls\Tiles\Tiles.cshtml"
                                            
    

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "    <div class=\"sectioned-tile-grid ");



#line 17 "..\..\Controls\Tiles\Tiles.cshtml"
WebViewPage.WriteTo(@__razor_helper_writer, tile_grid.classes.AsHtmlClassString());

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "\">\r\n");



#line 18 "..\..\Controls\Tiles\Tiles.cshtml"
         foreach ( var section in tile_grid.sections ) {
        
#line default
#line hidden


#line 19 "..\..\Controls\Tiles\Tiles.cshtml"
WebViewPage.WriteTo(@__razor_helper_writer, TileGridSectionControl.Render( section ));

#line default
#line hidden


#line 19 "..\..\Controls\Tiles\Tiles.cshtml"
                                                 
        }        

#line default
#line hidden

WebViewPage.WriteLiteralTo(@__razor_helper_writer, "    </div>\r\n");



#line 22 "..\..\Controls\Tiles\Tiles.cshtml"

#line default
#line hidden

});

}


public static System.Web.WebPages.HelperResult For( TileGrid tile_grid ) {
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {



#line 24 "..\..\Controls\Tiles\Tiles.cshtml"
                                   
    var is_tile_grid_section = !string.IsNullOrWhiteSpace( tile_grid.title );
    var tiles = tile_grid.tiles ?? new Tile[] { };
    var classes = tile_grid.classes ?? new string[]{};

    
#line default
#line hidden


#line 29 "..\..\Controls\Tiles\Tiles.cshtml"
WebViewPage.WriteTo(@__razor_helper_writer,  is_tile_grid_section ? @TileGridSectionControl.Render(tile_grid) : @TileGridControl.Render(tiles, classes));

#line default
#line hidden


#line 29 "..\..\Controls\Tiles\Tiles.cshtml"
                                                                                                                  

#line default
#line hidden

});

}


public static System.Web.WebPages.HelperResult For( IEnumerable<Tile> tiles ) {
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {



#line 32 "..\..\Controls\Tiles\Tiles.cshtml"
                                        
    
#line default
#line hidden


#line 33 "..\..\Controls\Tiles\Tiles.cshtml"
WebViewPage.WriteTo(@__razor_helper_writer, TileGridControl.Render( tiles ));

#line default
#line hidden


#line 33 "..\..\Controls\Tiles\Tiles.cshtml"
                                    

#line default
#line hidden

});

}


public static System.Web.WebPages.HelperResult For( Tile tile ) {
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {



#line 36 "..\..\Controls\Tiles\Tiles.cshtml"
                          
    
#line default
#line hidden


#line 37 "..\..\Controls\Tiles\Tiles.cshtml"
WebViewPage.WriteTo(@__razor_helper_writer, TileControl.Render( tile ));

#line default
#line hidden


#line 37 "..\..\Controls\Tiles\Tiles.cshtml"
                               

#line default
#line hidden

});

}


    }
}
#pragma warning restore 1591
