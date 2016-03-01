// Guard checks, if the criteria is not met then a guard error will be thrown.  
// Guard errors are considered programming errors and so will be thrown as exceptions 

define([
    'log_service'],
    function (
        log
    ) {
   
    var GuardPremiseHoldsFailed = function ( message ){
        this.message = message;
    }

    GuardPremiseHoldsFailed.prototype = new Error();
    

    var IsNotNullFailed = function (  message ) {
        this.message = message;
    }

    IsNotNullFailed.prototype = new Error();

    return {

        PremiseHolds : function ( premise  ) {


            // Improve: remove the code duplication between this and the ObjectIsNotNull

            var error = new GuardPremiseHoldsFailed( 'Guard.Premise holds failed'  );

            if ( !premise ) {
                log.failure( error );
                throw error;
            }
        },

        IsNotNull : function ( object ) {

            var error = new IsNotNullFailed( 'Guard.Is not null failed' );

            if ( !object ) {
                log.failure( error );
                throw error;
            }

        }, 
    }
});