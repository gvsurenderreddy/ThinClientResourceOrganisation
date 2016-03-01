// tile-bootstrapper

// allow behaviours to be registered against tile actions.

define( [
    'action_behaviour_repository',
    'standard_action_names',
    'tile_constants',
    'tile_events',
    'navigation_action_standard_behaviour'], 
function (
    action_behaviour_repository,
    standard_action_names,
    tile_constants,
    tile_events,
    navigation_action_standard_behaviour
) {

    var register_tile_default_navigation_behaviour = function ( behaviour ) {
    
        action_behaviour_repository
            .register_behaviour({

                action_identity: {
                    action: standard_action_names.navigation,
                    context: {
                        type: tile_constants.context_type
                    },                        
                },

                behaviour: behaviour,
            });    
    };

    return {
    
        use_standard_navigation_action_behaviour_as_default : function () {
            register_tile_default_navigation_behaviour( navigation_action_standard_behaviour ); 
            return this;
        },


        register_default_navigation_action_behaviour: function (  behaviour ) {
            register_tile_default_navigation_behaviour( behaviour );
            return this;
        },

        bind : function () {

            tile_events.bind();
            return this;
        }
    }

});