using System;
using System.Collections.Generic;
using System.Linq;
using Content.Services.PlannedSupply.Messages;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Validation;
using WTS.WorkSuite.PlannedSupply.OperationsCalendars;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar {


    public class OperationsCalendarValidator {


        public IEnumerable<ResponseMessage> validate_name 
                                                ( string calendar_name
                                                , OperationsCalendarIdentity identity ) {
            
            // Improve: This should really be create from a factory that uses the depenendy injection framework
            var validator = new Validator();

            validator
                .field( "calendar_name" )
                     .is_madatory( calendar_name, ValidationMessages.error_00_0035 )
                     .does_not_exceed_the_maximum_number_of_characters_for_a_text_field( calendar_name, ValidationMessages.error_00_0037 )
                     .premise_holds( name_is_unique( calendar_name, identity ), ValidationMessages.error_00_0036 )
                    ;

            return validator.errors;
        }


        public OperationsCalendarValidator
                        ( IEntityRepository<OperationalCalendar> the_operation_calendar_repository ) {

            operation_calendar_repository = Guard.IsNotNull( the_operation_calendar_repository, "the_operation_calendar_repository" );
        }


        // Check that there are no other operation calendars with the same name.
        private bool name_is_unique
                         ( string calendar_name
                         , OperationsCalendarIdentity identity ) {

            return !operation_calendar_repository
                        .Entities
                        .Where( oc => oc.id != identity.operations_calendar_id ) // do not check against itself or it is not valid to use when updating
                        .Any( oc => oc.calendar_name.Equals( calendar_name, StringComparison.InvariantCultureIgnoreCase ))
                        ;
        }

        private readonly IEntityRepository<OperationalCalendar> operation_calendar_repository;
    }
}