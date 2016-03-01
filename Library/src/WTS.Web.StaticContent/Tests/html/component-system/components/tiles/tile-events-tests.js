// Test to ensure that tile events are behaving as expected.

require(['application_boot'], function () {

    require(
        ['jquery',
         'tile_constants',
         'standard_action_names',
         'tile_events',
         'action_behaviour_repository',
         'route_table'],
        function (
            $,
            tile_constants,
            standard_action_names,
            tile_events,
            action_behaviour_repository,
            routes
        ) {

        // when the tile is cliked the registered behaviour is execute.
        test('when the tile is clicked the registered navigation behaviour is executed,', function () {

            var navigate_action_behaviour_was_called = false;

            // register a behaviour for the navigation action 
            action_behaviour_repository
                .register_behaviour({
                    action_identity: {
                        action: standard_action_names.navigation,
                        context: {
                            type: tile_constants.context_type
                        },                        
                    },

                    behaviour: function () {
                        navigate_action_behaviour_was_called = true;
                    }
                });

            tile_events.bind();

            // trigger the navigation action
            $('.'+tile_constants.tile_class).trigger('click');

            // check that the behavour was called
            ok( navigate_action_behaviour_was_called );
        });

        test( "The the action is passed into the behaviour", function(){ 

            var tile_action = null; 

            // register a behaviour for the navigation action 
            action_behaviour_repository
                .register_behaviour({
                    action_identity: {
                        action: standard_action_names.navigation,
                        context: {
                            type: tile_constants.context_type
                        },                        
                    },

                    behaviour: function ( action ) {
                        tile_action = action;
                    }
                });

            tile_events.bind();

            // trigger the navigation action
            $('.'+tile_constants.tile_class).trigger( 'click' );

            // check that the behavour was called
            ok( tile_action );
        
        });

        test( "The tile's model is included in the action", function(){ 

            var tile_action = null; 

            // register a behaviour for the navigation action 
            action_behaviour_repository
                .register_behaviour({
                    action_identity: {
                        action: standard_action_names.navigation,
                        context: {
                            type: tile_constants.context_type
                        },
                    },

                    behaviour: function ( action ) {
                        tile_action = action;
                    }
                });

            tile_events.bind();

            // trigger the navigation action
            $('.'+tile_constants.tile_class).trigger( 'click' );

            // check that the behavour was called
            ok( tile_action.model );
        
        });

        // A tiles model is a navigation request.
        // navigation request - {
        //    route_name : <string name of the route>
        //    route_paramters: <json object the holds the parameters>
        // }
        test( "The navigation request is included in the tile's model", function(){ 

            var tile_action = null; 

            // register a behaviour for the navigation action 
            action_behaviour_repository
                .register_behaviour({
                    action_identity: {
                        action: standard_action_names.navigation,
                        context: {
                            type: tile_constants.context_type
                        },
                    },

                    behaviour: function ( action ) {
                        tile_action = action;
                    }
                });

            tile_events.bind();

            // trigger the navigation action
            $('.'+tile_constants.tile_class).trigger( 'click' );

            // check that the behavour was called
            equal( view_model.route_request.route_name, tile_action.model.route_request.route_name );
            equal( view_model.route_request.route_parameters.param, tile_action.model.route_request.route_parameters.param );
        
        });
    });
    
});