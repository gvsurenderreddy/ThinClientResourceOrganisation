// Tests to ensure the semantic markup is applied to the tile grid's html


require([ 'application_boot' ], function () {


    require( ['jquery', 'dom_test_helpers','tile_grid_constants' ], function ( $, dom_helpers, tile_grid_constants ) {

        // done: html is identified as a 'tile grid' by a TileGrid class
        // done: html is identified as a 'tile grid section' by a TileGrid_Section class. 
        // done: html is identified as a 'tile grid section title' by a TileGrid_Sections_Title class.
        // done: the 'tile grid section title' is taken from the view model.
        // done: html is identified as a sections tile container by a TileGrid_Section_Tiles class.
        // done: html is identified as a grid tile by a TileGrid_Section_Tile class.


        var element_exists = dom_helpers.element_exists;

        var tile_grid_class = '.' + tile_grid_constants.tile_gird_class;
        var tile_grid_section_class = '.' + tile_grid_constants.tile_gird_section_class;
        var tile_grid_section_title_class = '.' + tile_grid_constants.tile_gird_section_title_class;
        var tile_grid_section_tiles_class = '.' + tile_grid_constants.tile_grid_section_tiles_class;
        var tile_grid_section_tile_class = '.' + tile_grid_constants.tile_grid_section_tile_class;


        test( 'html is identified as a tile grids by a TileGrid class', function (){
        
            ok( element_exists( tile_grid_class ));

        });

        test( "html is identified as a 'tile grid section' by a TileGrid_Section class.", function () {
        
            ok( element_exists( tile_grid_section_class ));
        });

        test( "html is identified as a the tile of a 'grid section' by a TileGrid_Sections_Title class.", function () {

            ok( element_exists( tile_grid_section_title_class ));
        });

        test( "the 'tile grid section title' is taken from the view model.", function (){

            var title = view_model.sections[0].title;

            equal(
               $( tile_grid_section_title_class ).text(),
               title
            );            
        });

        test( "html is identified as a sections tile container by a TileGrid_Section_Tiles class.", function (){
        
            ok( element_exists( tile_grid_section_tiles_class ));

        });

        test( "html is identified as a 'grid tile' by a TileGrid_Section_Tile class.", function(){
        
            ok( element_exists( tile_grid_section_tile_class  ));

        });

    });
});

