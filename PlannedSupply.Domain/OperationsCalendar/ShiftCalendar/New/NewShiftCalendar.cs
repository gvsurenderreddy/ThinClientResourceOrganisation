using System.Linq;
using Content.Services.PlannedSupply.Messages;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.Library.DomainTypes.DefaultValues;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Sanitisation;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.Events;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.Events;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.New.Create;
using WTS.WorkSuite.PlannedSupply.OperationsCalendars;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.New {
    using ShiftCalendar = PlannedSupply.ShiftCalendars.ShiftCalendar;

    public class NewShiftCalendar
                    : INewShiftCalendar {

        public NewShiftCalendarResponse execute
                                            ( NewShiftCalendarRequest the_new_shift_calendar_request ) {

            return this
                    .set_request( the_new_shift_calendar_request )
                    .authorise_to_create_a_new_shift_calendar()
                    .find_operational_calendar()
                    .sanitize_request()
                    .validate_request()
                    .create_new_shift_calendar()
                    .commit()
                    .publish_shift_calender_created_event()
                    .build_response()
                    ;
        }

        private NewShiftCalendar set_request
                                    ( NewShiftCalendarRequest the_new_shift_calendar_request ) {

            new_shift_calendar_request = Guard.IsNotNull( the_new_shift_calendar_request, "the_new_shift_calendar_request" );

            response_builder = new ResponseBuilder<ShiftCalendarIdentity, NewShiftCalendarResponse>();
            response_builder.set_response( new ShiftCalendarIdentity {
                shift_calendar_id = Null.Id
            });
            return this;
        }

        private NewShiftCalendar authorise_to_create_a_new_shift_calendar( ) {
            if ( response_builder.has_errors ) return this;


            Guard.IsNotNull( new_shift_calendar_request, "new_shift_calendar_request" );

            if ( !can_add_new_shift_caledar.IsGrantedFor( new_shift_calendar_request )) {
                response_builder.add_error( WarningMessages.warning_03_0016 );
            }
            return this;
        }

        private NewShiftCalendar find_operational_calendar() {
            if ( response_builder.has_errors ) return this;


            Guard.IsNotNull( new_shift_calendar_request, "new_shift_calendar_request" );

            operation_calendar = operation_calendar_repository
                                    .Entities
                                    .Single(oc => oc.id == new_shift_calendar_request.operations_calendar_id)
                                    ;
            return this;
        }

        private NewShiftCalendar sanitize_request() {
            if ( response_builder.has_errors ) return this;


            Guard.IsNotNull( new_shift_calendar_request, "new_shift_calendar_request" );

            new_shift_calendar_request = new NewShiftCalendarRequest{
                operations_calendar_id = new_shift_calendar_request.operations_calendar_id,
                calendar_name = new_shift_calendar_request.calendar_name.normalise_for_persistence()
            };
            return this;
        }

        private NewShiftCalendar validate_request() {
            if ( response_builder.has_errors ) return this;


            Guard.IsNotNull( new_shift_calendar_request, "new_shift_calendar_request");
            Guard.IsNotNull( operation_calendar, "operation_calendar" );

            validator
                .validate_name
                    ( new_shift_calendar_request.calendar_name 
                    , new ShiftCalendarIdentity { operations_calendar_id = new_shift_calendar_request.operations_calendar_id, shift_calendar_id = Null.Id})
                .has_entries( 
                    yes: entries => response_builder.add_errors( entries ),
                    no: () => {} // expected
                );

            if ( response_builder.has_errors ) {
                response_builder.add_error( WarningMessages.warning_03_0016 );
            }
            return this;
        }

        private NewShiftCalendar create_new_shift_calendar() {

            if ( response_builder.has_errors ) return this;


            Guard.IsNotNull( new_shift_calendar_request, "_new_shift_calendar_request" );
            Guard.IsNotNull( operation_calendar, "operational_calendar" );
            
            new_shift_calendar = new ShiftCalendar {
                calendar_name = new_shift_calendar_request.calendar_name
            };

            operation_calendar
                .ShiftCalendars
                .Add( new_shift_calendar )
                ;
            return this;
        }

        private NewShiftCalendar commit() {
            if ( response_builder.has_errors ) return this;


            Guard.IsNotNull( operation_calendar, "operation_calendar" );
            Guard.IsNotNull( new_shift_calendar, "new_shift_calendar" );

            unit_of_work.Commit();

            response_builder.add_message( ConfirmationMessages.confirmation_04_0020 );
            response_builder.set_response( new ShiftCalendarIdentity {
                operations_calendar_id = operation_calendar.id,
                shift_calendar_id = new_shift_calendar.id
            });
            return this;
        }


        private NewShiftCalendar publish_shift_calender_created_event () {
            if ( response_builder.has_errors ) return this;

            Guard.IsNotNull( operation_calendar, "operation_calendar" );
            Guard.IsNotNull( new_shift_calendar, "new_shift_calendar" );

            shift_calendar_created_event_publisher.publish( new ShiftCalendarCreatedEvent {
                operations_calendar_id = operation_calendar.id,
                shift_calendar_id = new_shift_calendar.id,
                calendar_name = new_shift_calendar.calendar_name,
            });


            return this;
        }

        private NewShiftCalendarResponse build_response() {
            return response_builder.build();
        }

        public NewShiftCalendar
                ( IEntityRepository<OperationalCalendar> the_operational_calendar_repository
                , IUnitOfWork the_unit_of_work
                , ShiftCalendarValidator the_validator
                , ICanAddNewShiftCalendar can_add_new_shift_calendar_permission 
                , IEventPublisher<ShiftCalendarCreatedEvent> the_shift_calendar_created_event_publisher ) {

            operation_calendar_repository = Guard.IsNotNull( the_operational_calendar_repository, "the_operational_calendar_repository" );
            unit_of_work = Guard.IsNotNull(the_unit_of_work, "the_unit_of_work" );
            validator = Guard.IsNotNull( the_validator, "the_validator" );
            can_add_new_shift_caledar = Guard.IsNotNull( can_add_new_shift_calendar_permission, "can_add_new_shift_calendar_permission" );
            shift_calendar_created_event_publisher = Guard.IsNotNull( the_shift_calendar_created_event_publisher, "the_shift_calendar_created_event_publisher" );
        }


        private readonly IEntityRepository<OperationalCalendar> operation_calendar_repository;
        private readonly IUnitOfWork unit_of_work;
        private readonly ShiftCalendarValidator validator;
        private readonly ICanAddNewShiftCalendar can_add_new_shift_caledar;
        private readonly IEventPublisher<ShiftCalendarCreatedEvent> shift_calendar_created_event_publisher;


        private NewShiftCalendarRequest new_shift_calendar_request;
        private ResponseBuilder<ShiftCalendarIdentity, NewShiftCalendarResponse> response_builder;
        private OperationalCalendar operation_calendar;
        private ShiftCalendar new_shift_calendar;

    }
}