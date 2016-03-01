using System;
using System.Collections.Generic;
using System.Linq;
using Content.Services.PlannedSupply.Messages;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Sanitisation;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.Edit.Update;
using WTS.WorkSuite.PlannedSupply.OperationsCalendars;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.Edit {

    public class UpdateOperationsCalendar
                        : IUpdateOperationsCalendar {

        public UpdateOperationsCalendarResponse execute
                                                    ( UpdateOperationsCalendarRequest the_update_operations_calendar_request ){

            return this
                .set_request( the_update_operations_calendar_request )
                .authorize_to_update_operations_calendar()
                .sanitize_request()
                .find_operation_calendar()
                .validate_request()
                .update_operations_calendar()
                .commit()
                .build_response();
        }


        public UpdateOperationsCalendar
                ( IEntityRepository<OperationalCalendar> the_operation_calendar_repository
                , ICanUpdateOperationsCalendar the_execute_permission
                , IUnitOfWork the_unit_of_work
                , OperationsCalendarValidator the_validator ) {

            operation_calendar_repository = Guard.IsNotNull( the_operation_calendar_repository, "the_operation_calendar_repository" );
            execute_permission = Guard.IsNotNull( the_execute_permission, "the_execute_permission" );
            unit_of_work = Guard.IsNotNull( the_unit_of_work, "the_unit_of_work" );
            validator = Guard.IsNotNull( the_validator, "the_validator" );
        }

        private UpdateOperationsCalendar set_request
                                            ( UpdateOperationsCalendarRequest the_update_operation_calendar_request ) {

            update_operation_calendar_request = Guard.IsNotNull( the_update_operation_calendar_request, "the_update_operation_calendar_request" );

            response_builder = new ResponseBuilder<UpdateOperationsCalendarResponse>();
            return this;
        }

        private UpdateOperationsCalendar authorize_to_update_operations_calendar() {

            if ( response_builder.has_errors ) return this;


            Guard.IsNotNull( update_operation_calendar_request, "update_operation_calendar_request" );
            
            if ( !execute_permission.IsGrantedFor( update_operation_calendar_request )) {
                response_builder.add_error( WarningMessages.warning_03_0015 );
            }
            return this;
        }

        private UpdateOperationsCalendar sanitize_request() {

            if ( response_builder.has_errors ) return this;


            Guard.IsNotNull( update_operation_calendar_request, "update_operation_calendar_request" );

            update_operation_calendar_request = new UpdateOperationsCalendarRequest{
                operations_calendar_id = update_operation_calendar_request.operations_calendar_id,
                calendar_name = update_operation_calendar_request.calendar_name.normalise_for_persistence()
            };
            return this;
        }

        private UpdateOperationsCalendar find_operation_calendar() {

            if ( response_builder.has_errors ) return this;


            Guard.IsNotNull( update_operation_calendar_request, "update_operation_calendar_request" );
            Guard.IsNotNull( operation_calendar_repository, "operation_calendar_repository" );

            // Improve: Need a better way of handling resource not found errors.
            operation_calendar = operation_calendar_repository
                                    .Entities
                                    .Single( oc => oc.id == update_operation_calendar_request.operations_calendar_id )
                                    ;
            return this;
        }

        private UpdateOperationsCalendar validate_request() {

            if ( response_builder.has_errors ) return this;


            Guard.IsNotNull( update_operation_calendar_request, "update_operation_calendar_request" );

            validator
                .validate_name
                    ( update_operation_calendar_request.calendar_name
                    , update_operation_calendar_request )
                .has_entries (                 
                    yes: entries => response_builder.add_errors( entries ),
                    no: () => { }  // do nothing as this means there were no errors.                 
                );


            if ( response_builder.has_errors ) {
                response_builder.add_error( WarningMessages.warning_03_0015 );
            }
            return this;
        }

        private UpdateOperationsCalendar update_operations_calendar() {

            if ( response_builder.has_errors ) return this;


            Guard.IsNotNull( update_operation_calendar_request, "update_operation_calendar_request" );
            Guard.IsNotNull( operation_calendar, "operation_calendar" );

            operation_calendar.calendar_name = update_operation_calendar_request.calendar_name;
            return this;
        }
        
        private UpdateOperationsCalendar commit() {

            if ( response_builder.has_errors ) return this;

            unit_of_work.Commit();
            response_builder.add_message( ConfirmationMessages.confirmation_04_0018 );
            return this;
        }

        private UpdateOperationsCalendarResponse build_response() {
            return response_builder.build();
        }



        private readonly IEntityRepository<OperationalCalendar> operation_calendar_repository;
        private readonly OperationsCalendarValidator validator;
        private readonly IUnitOfWork unit_of_work;
        private readonly ICanUpdateOperationsCalendar execute_permission;

        private UpdateOperationsCalendarRequest update_operation_calendar_request;
        private OperationalCalendar operation_calendar;
        private ResponseBuilder<UpdateOperationsCalendarResponse> response_builder;
    }
}