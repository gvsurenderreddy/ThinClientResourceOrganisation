// tile-bootstrapper-tests

require(['application_boot'], function () {


    require([
        'tile_constants',
        'tile_bootstrapper',
        'route_table',
        'page_loader' ], 
    function (
        tile_constants,
        tile_bootstrapper,
        routes,
        fake_page_loader
    ) {
        
        // NOTE - by default we have a fake page loader configured so tha we do not go off all over the place when
        //        we are testing.  It just stored the url that were requested.

        var tile_route_name = view_model.route_request.route_name;

        // done: the standard navigation behaviour can be hooked to the tile navigation action
        // done: a custom behaviour can be hooked to the tile navigation action

        test( 'the standard navigation behaviour can be hooked to the tile navigation action', function () {
            
            routes[ tile_route_name ] = "http://www.google.co.uk";

            tile_bootstrapper
                .use_standard_navigation_action_behaviour_as_default()
                .bind();

            // trigger the navigation action
            $('.'+tile_constants.tile_class).trigger('click');

            ok( fake_page_loader.navigation_requests.indexOf( routes[ tile_route_name ] ) > -1  );
        });


        test('a custom behaviour can be hooked to the tile navigation action', function( ) {

            var behaviour_was_called = false;
        
            tile_bootstrapper
                .register_default_navigation_action_behaviour(  function () { behaviour_was_called = true; } )
                .bind();

            // trigger the navigation action
            $('.'+tile_constants.tile_class).trigger('click');

            ok( behaviour_was_called );

        });

    });
});