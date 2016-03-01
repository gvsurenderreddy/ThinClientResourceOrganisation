// Repository that allow behaviours to be registered against actions.
define([
    'guards',
    'ActionBehaviours'], 
    function (
        guard,
        ActionBehaviours
    ) {

    var get_behaviour_match_execution_options_is_wellformed = function ( execution_options ) {

        var result = true;

        result = result && execution_options;
        result = result && execution_options.if_found && typeof execution_options.if_found  == 'function';
        result = result && execution_options.if_not_found && typeof execution_options.if_not_found  == 'function';

        return result;        
    };

    var behaviours = new ActionBehaviours();


    return {
        version: '1.0.0',


        // request -  is a 'register action behaviour request' see ActionBehaviours.js for the expected format.
        register_behaviour: function ( request ) {

            // action behaviour is an action identity with a behaviour added.
            behaviours
                .get_action_behaviours( request.action_identity )
                .add( request )
                ;
        },

        // action_identity -  is an 'action identity' see action.js for expected format.
        get_behaviour: function ( action_identity ) {

            // get the behaviour
            var behaviour = behaviours.find_behaviour_for_action( action_identity );

            return {

                // execution ptions
                // -----------------

                // excution options contains the functions that should be executed depeneding 
                // on whether a behaviour is found or not.

                // {
                //    if_found : ,    // function that is executed if there is a behaviour for the action. The behaviour is passed into the function as an argument
                //    if_not_found: , // function that is executed if a behaviour has not been registered for the action.
                // }

                match: function ( execution_options ) {

                    guard.PremiseHolds( get_behaviour_match_execution_options_is_wellformed( execution_options ) );


                    if ( behaviour ) {
                        return execution_options.if_found( behaviour );

                    } else {
                        return execution_options.if_not_found();
                    }
                }
            };
        }
    };
});