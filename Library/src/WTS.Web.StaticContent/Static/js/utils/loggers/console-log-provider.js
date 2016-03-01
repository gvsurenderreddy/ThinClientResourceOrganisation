// console log provider

// this is a log provider that writes messages out to the console. 

define([], function () {
    var null_log = function ( ) {}

    var message_logger_factory = function () {
        
        return console.log 
             ? function ( message  ) { console.log( message ); }
             : null_log;
    }

    var warning_logger_factory = function () {
        
        return console.warn
             ? function ( message ) { console.warn ( message ); }
             : null_log;
    }

    var error_logger_factory = function () {
        
        return console.error
             ? function ( message ) { console.error ( message ); }
             : null_log;
    }

    var failure_logger_factory = function () {
        
        return console.error
             ? function ( message ) { console.error ( message ); }
             : null_log;
    }


    return {
        message: message_logger_factory(),
        warning: warning_logger_factory(),
        error: error_logger_factory(),
        failure: failure_logger_factory()            
    }    
});