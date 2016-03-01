define([], function() {

    // action identity
    // ---------------

    // action identity is used to identify a behaviour for an action.  An action is defined by it's context and 
    // name.  The context for an action is either just context type or a specific named instance of a context type.
    //
    // This is used when looking up a behaviour for a specific action.

    // { action: 'navigation',      // the name of the context type action for the behaviour we want to identify
    //   context: {
    //      type: 'tile',           // the type of the context for the behaviour we want to find
    //      name: 'view employees', // the named instance of the context type for the behaviour we want to find
    // }

    var context_identity_is_wellformed = function(context_identity) {

        var result = true;

        result = result && context_identity;
        result = result && context_identity.type && typeof context_identity.type == 'string'; // type must exists and be a string

        return result;
    };


    return {

        identity_is_wellformed : function ( action_identity ) {
    
            var result = true;

            result = result && action_identity;  // it has to be an object for it to exist
            result = result && action_identity.action && typeof action_identity.action == 'string'; // action must exists and be a string
            result = result && action_identity.context && context_identity_is_wellformed( action_identity.context ) ; // must have a context

            return result;
        }
    };
});