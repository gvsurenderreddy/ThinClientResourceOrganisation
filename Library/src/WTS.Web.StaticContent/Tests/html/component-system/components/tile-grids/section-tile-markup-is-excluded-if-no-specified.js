require([ 'application_boot' ], function () {

    require( ['jquery', 'dom_test_helpers', 'tile_grid_constants'], function ( $, dom_helpers, tile_grid_constants ) { 

        // done: title markup should not be included if title is not specified

        var element_exists = dom_helpers.element_exists;
        var tile_grid_section_title_class = '.' + tile_grid_constants.tile_gird_section_title_class;

        test( 'title markup should not be included if title is not specified', function () {
            
            ok( !element_exists( tile_grid_section_title_class )  )

        });

    });
});