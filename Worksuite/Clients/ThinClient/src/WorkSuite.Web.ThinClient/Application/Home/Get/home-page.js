require(['application_boot' ], function () {

    require( ['tile_bootstrapper' ], function ( tile_bootstrapper ) {

        tile_bootstrapper
            .use_standard_navigation_action_behaviour_as_default()
            .bind();
    });
});