using System.Collections.Generic;
using System.Linq;
using Content.Services.PlannedSupply.Messages;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.Library.DomainTypes.DefaultValues;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Sanitisation;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.Events;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.New.Create;
using WTS.WorkSuite.PlannedSupply.OperationsCalendars;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.New {

    public class NewOperationsCalendar
                        : INewOperationsCalendar {

        public NewOperationsCalendarResponse execute
                                                ( NewOperationsCalendarRequest the_new_operations_calendar_request ) {

            return this
                    .set_request( the_new_operations_calendar_request )
                    .authorize_to_create_a_new_operations_calendar()
                    .sanitize_request()
                    .validate_request()
                    .create_new_operations_calendar()
                    .commit()
                    .publish_operation_calendar_created_event()
                    .build_response()
                    ;
        }

    
        public NewOperationsCalendar
                    ( IEntityRepository< OperationalCalendar> the_operations_calendar_repository
                    , IUnitOfWork the_unit_of_work
                    , OperationsCalendarValidator the_operations_calendar_validator
                    , ICanAddNewOperationsCalendar the_execute_permission 
                    , IEventPublisher<OperationCalendarCreatedEvent> the_operation_created_event_publisher ) {

            operation_calendar_repository = Guard.IsNotNull( the_operations_calendar_repository ,"the_operations_calendar_repository" );
            unit_of_work = Guard.IsNotNull( the_unit_of_work, "the_unit_of_work" );
            validator = Guard.IsNotNull( the_operations_calendar_validator, "the_operations_calendar_validator" );
            execute_permission = Guard.IsNotNull( the_execute_permission, "the_execute_permission" );
            operation_created_event_publisher = Guard.IsNotNull( the_operation_created_event_publisher, "the_operation_created_event_publisher" );
        }        
        
        private NewOperationsCalendar set_request
                                        ( NewOperationsCalendarRequest the_new_operations_calendar_request ) {

            new_operation_calendar_request = Guard.IsNotNull( the_new_operations_calendar_request, "the_new_operations_calendar_request" );

            response_builder = new ResponseBuilder< OperationsCalendarIdentity
                                                  , NewOperationsCalendarResponse >();

            response_builder.set_response( new OperationsCalendarIdentity {
                operations_calendar_id = Null.Id
            });
            return this;
        }

        private NewOperationsCalendar authorize_to_create_a_new_operations_calendar() {

            if ( response_builder.has_errors ) return this;


            Guard.IsNotNull( new_operation_calendar_request, "new_operations_calendar_request" );

            if ( !execute_permission.IsGrantedFor( new_operation_calendar_request )) {
                response_builder.add_error( WarningMessages.warning_03_0014 );
            }
            return this;
        }

        private NewOperationsCalendar sanitize_request() {

            if ( response_builder.has_errors ) return this;


            Guard.IsNotNull( new_operation_calendar_request, "new_operation_calendar_request" );

            new_operation_calendar_request = new NewOperationsCalendarRequest {
                                                    calendar_name = new_operation_calendar_request
                                                                        .calendar_name
                                                                        .normalise_for_persistence()
                                                  };
            return this;
        }

        private NewOperationsCalendar validate_request() {

            if ( response_builder.has_errors ) return this;

            
            Guard.IsNotNull( new_operation_calendar_request, "new_operation_calendar_request" ) ;

            validator
                .validate_name
                    ( new_operation_calendar_request.calendar_name
                    , new OperationsCalendarIdentity { operations_calendar_id = Null.Id } )
                .has_entries (                 
                    yes: entries => response_builder.add_errors( entries ),
                    no: () => { }  // do nothing as this means there were no errors.                 
                );

            if ( response_builder.has_errors ) {
                response_builder.add_error( WarningMessages.warning_03_0014 );                
            }
            return this;
        }


        private NewOperationsCalendar create_new_operations_calendar() {

            if ( response_builder.has_errors ) return this;


            Guard.IsNotNull( new_operation_calendar_request, "new_operation_calendar_request" );
            Guard.IsNotNull( operation_calendar_repository, "operation_calendar_repository" );

            operation_calendar = new OperationalCalendar {
                                        calendar_name = new_operation_calendar_request.calendar_name
                                     };

            operation_calendar_repository.add( operation_calendar );
            return this;
        }

        private NewOperationsCalendar commit() {

            if ( response_builder.has_errors ) return this;


            unit_of_work.Commit();

            response_builder.add_message( ConfirmationMessages.confirmation_04_0017 );
            response_builder.set_response( new OperationsCalendarIdentity {
                operations_calendar_id = operation_calendar.id
            });
            return this;
        }

        private NewOperationsCalendar publish_operation_calendar_created_event () {

            if ( response_builder.has_errors ) return this;


            Guard.IsNotNull( operation_calendar, "operation_calendar" );

            operation_created_event_publisher.publish( new OperationCalendarCreatedEvent {
                operations_calendar_id = operation_calendar.id
            });
            return this;
        }

        private NewOperationsCalendarResponse build_response() {

            return response_builder.build();
        }


        private NewOperationsCalendarRequest new_operation_calendar_request;
        private ResponseBuilder<OperationsCalendarIdentity, NewOperationsCalendarResponse> response_builder;
        private OperationalCalendar operation_calendar;


        private readonly IEntityRepository<OperationalCalendar> operation_calendar_repository;
        private readonly ICanAddNewOperationsCalendar execute_permission;
        private readonly OperationsCalendarValidator validator;
        private readonly IUnitOfWork unit_of_work;
        private readonly IEventPublisher<OperationCalendarCreatedEvent> operation_created_event_publisher;
    }
}