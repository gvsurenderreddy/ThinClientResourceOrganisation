// Allow actions to be published.  

// When an action is published, all the behaviours that have been registered against the 
// specified action identity are executed.

// To do: need to work out whether we should execute the behaviours asynchronously or synchronously

define([
    'log_service',
    'action_behaviour_repository'],
    function (
        log,
        action_behaviour_repository
    ) {

        return {
            publish: function( action_identity ) {

                // get the behaviour from the repository and execute it
                action_behaviour_repository
                    .get_behaviour( action_identity )
                    .match({

                        if_found: function( behaviour ) {
                            behaviour( action_identity );
                        },

                        if_not_found: function() {
                            log.warning( 'action publisher - behaviour not found for ' + action_identity );
                        }
                    });
            }
        };
    });