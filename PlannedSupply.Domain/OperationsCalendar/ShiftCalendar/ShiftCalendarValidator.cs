using System;
using System.Collections.Generic;
using System.Linq;
using Content.Services.PlannedSupply.Messages;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Validation;
using WTS.WorkSuite.PlannedSupply.OperationsCalendars;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar {

    public class ShiftCalendarValidator {

        public IEnumerable<ResponseMessage> validate_name 
                                                ( string calendar_name
                                                , ShiftCalendarIdentity identity ) {

            // Improve: this should come from a factory that uses the dependency injection system.
            var validator = new Validator();

            validator
                .field("calendar_name")
                     .is_madatory( calendar_name, ValidationMessages.error_00_0039 )
                     .does_not_exceed_the_maximum_number_of_characters_for_a_text_field( calendar_name, ValidationMessages.error_00_0037 )
                     .premise_holds( name_is_unique( calendar_name, identity ), ValidationMessages.error_00_0040 )
                     ;

            return validator.errors;
        }

        private bool name_is_unique
                        ( string calendar_name
                        , ShiftCalendarIdentity identity ) {

            return !calendar_repository
                    .Entities
                    .Where( oc => oc.id == identity.operations_calendar_id )
                    .SelectMany( oc => oc.ShiftCalendars )
                    .Where( sc => sc.id != identity.shift_calendar_id )
                    .Any( sc => sc.calendar_name.Equals( calendar_name, StringComparison.InvariantCultureIgnoreCase  ))
                    ;
        }

        public ShiftCalendarValidator
                ( IEntityRepository<OperationalCalendar> the_calendar_repository ) {

            calendar_repository = Guard.IsNotNull( the_calendar_repository, "the_calendar_repository" );
        }

        private readonly IEntityRepository<OperationalCalendar> calendar_repository;
    }
}