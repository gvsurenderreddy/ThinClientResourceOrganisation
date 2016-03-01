require( ['application_boot'], function (){

    require( ['jquery','dom_test_helpers', 'tile_constants'], function ( $, dom_helpers, tile_constants ) {
    
        // to do: tiles can be rendered

        var element_exists = dom_helpers.element_exists
        var tile_class = '.' + tile_constants.tile_class;

        test( 'tiles can be rendered', function () {

            ok( element_exists( tile_class ));
        
        });


    });

} );
