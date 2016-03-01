// Log service, 

// Log service provides an log service interface, it uses an a log provider to log messages.  This is so that we can change the 
// log provider with out having to change all the files that need to log messages. The log provider is a dependency that is should
// should be changed depending on where we are deploying to, as such it is only the path to the module that should be changed as this
// should be relatively easy to do in a deployment script rather than having to change the injected module.  

// NOTE - we consider where we log to a configuration concern rather than a coding concern so we have tried to make it easy to change
//        via configuration.

// message severity:
//
//  message - informational message
//  warning - something is wrong but not critical e.g. an action is published without tha does not have a behaviour registed for it.
//  error   - there was an error but it was an anticipated condition and there is logic in the application to deal with it.
//  failure - there was an error that was not anticipated condition so the application is now in an unknown state. 

define( ['log_provider'], function ( log ) {
    
    return {
        
        message: function ( message ) {
            log.message( message );
        },

        warning: function ( message ) {
            log.warning( message );
        },

        error: function ( message ) {
            log.error( message );
        },

        failure: function ( message ) {
            log.failure( message );
        }
    }
} );