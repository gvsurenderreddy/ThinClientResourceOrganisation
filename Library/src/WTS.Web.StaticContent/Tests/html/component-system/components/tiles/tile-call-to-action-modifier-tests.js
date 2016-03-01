// Test to ensure that tile events are behaving as expected.

require(['application_boot'], function () {

    require(
        ['jquery',
          'dom_test_helpers',
         'tile_constants'
        ],
        function (
            $,
            dom_helpers,
            tile_constants
        ) {
            
        var element_exists = dom_helpers.element_exists;

        var call_to_action_tile_exits = function ( call_to_action_class ) {
            
            return element_exists( '.'+tile_constants.tile_class+'.'+call_to_action_class );
        }

        test( "Tile is correctly ascribed the primary call to action modifier", function() { 

            ok( call_to_action_tile_exits( tile_constants.primary_call_to_action_class ));        
        });


        test( "Tile is correctly ascribed the secondary call to action modifier", function() { 

            ok( call_to_action_tile_exits( tile_constants.secondary_call_to_action_class ));        

        });

        test( "Tile is correctly ascribed the special call to action modifier", function() { 

            ok( call_to_action_tile_exits( tile_constants.special_call_to_action_class ));        

        });


    });
    
});