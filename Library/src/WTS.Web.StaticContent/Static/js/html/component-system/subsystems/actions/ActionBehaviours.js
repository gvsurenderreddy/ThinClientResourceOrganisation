define([
    'guards',
    'action'],
    function( 
        guard,
        action
    ) {
    

    var behaviour_is_wellformed = function ( behaviour ) {
        
        var result = true;

        result = result && behaviour;
        result = result && typeof behaviour === 'function';

        return result;
    };


    // register action behaviour request
    // ----------------

    // register action behaviour request is used to regiter a behaviour for a context action. This can 
    // be a default behaviour for a context type or a behaviour for a specific named instance of a 
    // context type.  

    // { action_identity: ,   // is an instance of the action identity
    //   behaviour: , // function that is the behaviour for this action.
    // }
    var register_action_behaviour_request_is_wellformed = function(request) {

        var result = true;

        result = result && request; // it has to be an object for it to exist
        result = result && action.identity_is_wellformed(request.action_identity); // action identity must exist and be well formed
        result = result && behaviour_is_wellformed(request.behaviour); // must have a context

        return result;
    };

    // identifies whether an action behaviour is for a named context or the default for the context type
    var behaviour_type = function ( action_identity ) {
        
        guard.PremiseHolds( action.identity_is_wellformed( action_identity ));


        return {
            match: function(match_options) {

                // to do: Guard that the match options are well formed

                if (action_identity.context.hasOwnProperty('name')) {
                    return match_options.for_named_context(action_identity.context.name);

                } else {
                    return match_options.default_for_context();
                }
            }
        };
    };



    // Contains an actions behaviour for a context there should be default behaviour and optionaly behaviours that are for a specific named context.
    var ContextActionBehaviours = function () { };

    // adds a behavior to a context action
    ContextActionBehaviours.prototype.add = function ( request ) {

        guard.PremiseHolds( register_action_behaviour_request_is_wellformed( request ));


        var context_action_behaviours = this;
        
        behaviour_type( request.action_identity ).match({

            for_named_context: function ( context_name ) {                
                context_action_behaviours[ context_name ] = request.behaviour;
            },

            default_for_context: function ( ) {                 
                context_action_behaviours[ 'default_behaviour' ]  = request.behaviour;
            }
        });
    };



    // dictionary that stores the action behaviours.
    var ActionBehaviours = function () { };

    // There is always an entry for and action_index so if we do not find it we just create it.  
    ActionBehaviours.prototype.get_action_behaviours = function ( action_identity ) {
        
        guard.PremiseHolds( action.identity_is_wellformed( action_identity ));


        if (!this.hasOwnProperty( action_identity.context.type )) {
            this[ action_identity.context.type ] = {};
        }

        if (!this[ action_identity.context.type ].hasOwnProperty( action_identity.action )) {
            this[ action_identity.context.type ][ action_identity.action ] = new ContextActionBehaviours();
        }
        return this[ action_identity.context.type ][ action_identity.action ];
    };

    // get the behaviour that has been regisered for the context action.  Returns null if a behaviour has not been registered
    ActionBehaviours.prototype.find_behaviour_for_action = function ( action_identity ) {

        var action_behaviours = this.get_action_behaviours( action_identity );

        return behaviour_type( action_identity ).match({

            for_named_context: function ( context_name ) {
                // return either the behaviour for the named context or default behaviour for the context action 
                return action_behaviours[ context_name ] || action_behaviours[ 'default_behaviour' ];
            },

            default_for_context: function () {
                return action_behaviours[ 'default_behaviour' ];
            }
        });
    };



    return ActionBehaviours;
});