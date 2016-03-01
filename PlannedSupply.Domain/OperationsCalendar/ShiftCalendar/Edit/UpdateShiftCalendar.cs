using System.Linq;
using Content.Services.PlannedSupply.Messages;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Sanitisation;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.Edit.Update;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.Events;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.Edit{
    using OperationalCalendar = PlannedSupply.OperationsCalendars.OperationalCalendar;
    using ShiftCalendar = PlannedSupply.ShiftCalendars.ShiftCalendar;


    public class UpdateShiftCalendar
                        : IUpdateShiftCalendar {


        public UpdateShiftCalendarResponse execute
                                            ( UpdateShiftCalendarRequest the_update_shift_calendar_request ) {

            return this
                    .set_request( the_update_shift_calendar_request )
                    .authorize_to_update_shift_calendar()
                    .sanitize_request()
                    .find_operational_calendar()
                    .find_shift_calendar()
                    .validate_request()
                    .update_shift_calendar()
                    .commit()
                    .publish_shift_calendar_updated_event()
                    .build_response()
                    ;
        }

        private UpdateShiftCalendar set_request
                                        ( UpdateShiftCalendarRequest the_update_shift_calendar_request ) {

            update_shift_calendar_request = Guard.IsNotNull(the_update_shift_calendar_request, "the_update_shift_calendar_request" );
            response_builder = new ResponseBuilder<UpdateShiftCalendarResponse>();
            return this;
        }

        private UpdateShiftCalendar authorize_to_update_shift_calendar() {
            if ( response_builder.has_errors ) return this;


            Guard.IsNotNull( update_shift_calendar_request, "update_shift_calendar_request" );

            if ( !can_update_shift_calendar.IsGrantedFor( update_shift_calendar_request )) {
                response_builder.add_error( WarningMessages.warning_03_0017 );
            }
            return this;
        }

        private UpdateShiftCalendar sanitize_request() {
            if ( response_builder.has_errors ) return this;


            Guard.IsNotNull( update_shift_calendar_request, "update_shift_calendar_request" );

            update_shift_calendar_request = new UpdateShiftCalendarRequest {
                operations_calendar_id = update_shift_calendar_request.operations_calendar_id,
                shift_calendar_id = update_shift_calendar_request.shift_calendar_id,
                calendar_name = update_shift_calendar_request.calendar_name.normalise_for_persistence(),
            };
            return this;
        }

        private UpdateShiftCalendar find_operational_calendar() {
            if ( response_builder.has_errors ) return this;


            Guard.IsNotNull( update_shift_calendar_request, "update_shift_calendar_request" );

            // Improve: need to change this once we have worked out how to handle resouce not found errors
            operation_calendar = operation_calendar_repository
                                    .Entities
                                    .Single( oc => oc.id == update_shift_calendar_request.operations_calendar_id )
                                    ;
            return this;
        }

        private UpdateShiftCalendar find_shift_calendar() {
            if ( response_builder.has_errors ) return this;


            Guard.IsNotNull( update_shift_calendar_request, "_update_shift_calendar_request" );
            Guard.IsNotNull( operation_calendar, "_operational_calendar");

            // Improve: need to change this once we have worked out how to handle resouce not found errors
            shift_calendar_to_be_updated = operation_calendar
                                            .ShiftCalendars
                                            .Single( sc => sc.id == update_shift_calendar_request.shift_calendar_id )
                                            ;
            return this;
        }

        private UpdateShiftCalendar validate_request() {
            if ( response_builder.has_errors ) return this;


            Guard.IsNotNull( update_shift_calendar_request, "update_shift_calendar_request" );
            Guard.IsNotNull( operation_calendar, "operational_calendar" );

            validator
                .validate_name
                    ( update_shift_calendar_request.calendar_name
                    , update_shift_calendar_request )
                .has_entries( 
                    yes: errors => response_builder.add_errors( errors ),
                    no: () => { } // if there are no error we do not need to do anything
                );

            if ( response_builder.has_errors ) {
                response_builder.add_error( WarningMessages.warning_03_0017 );
            }
            return this;
        }

        private UpdateShiftCalendar update_shift_calendar() {
            if ( response_builder.has_errors ) return this;


            Guard.IsNotNull( update_shift_calendar_request, "update_shift_calendar_request" );
            Guard.IsNotNull( shift_calendar_to_be_updated, "shift_calendar_to_be_updated" );

            shift_calendar_to_be_updated.calendar_name = update_shift_calendar_request.calendar_name;
            return this;
        }

        private UpdateShiftCalendar commit() {
            if ( response_builder.has_errors ) return this;

            unit_of_work.Commit();
            response_builder.add_message( ConfirmationMessages.confirmation_04_0021 );
            return this;
        }

        private UpdateShiftCalendar publish_shift_calendar_updated_event () {
            if (response_builder.has_errors) return this;


            Guard.IsNotNull( operation_calendar, "operation_calendar" );
            Guard.IsNotNull( shift_calendar_to_be_updated, "shift_calendar_to_be_updated" );

            shift_calendar_updated_event_publisher.publish( new ShiftCalendarUpdatedEvent {
                operations_calendar_id = operation_calendar.id,
                shift_calendar_id = shift_calendar_to_be_updated.id,                
                calendar_name = shift_calendar_to_be_updated.calendar_name,
            });
            return this;
        }

        private UpdateShiftCalendarResponse build_response() {
            return response_builder.build();
        }


        public UpdateShiftCalendar
                ( IEntityRepository<OperationalCalendar> the_operational_calendar_repository
                , ShiftCalendarValidator the_validator
                , ICanUpdateShiftCalendar can_update_shift_calendar_permission
                , IUnitOfWork the_unit_of_work 
                , IEventPublisher<ShiftCalendarUpdatedEvent> the_shift_calendar_updated_event_publisher ) {

            operation_calendar_repository = Guard.IsNotNull( the_operational_calendar_repository, "the_operational_calendar_repository" );
            validator = Guard.IsNotNull( the_validator, "the_validator" );
            can_update_shift_calendar = Guard.IsNotNull( can_update_shift_calendar_permission, "can_update_shift_calendar_permission" );
            unit_of_work = Guard.IsNotNull( the_unit_of_work, "the_unit_of_work" );
            shift_calendar_updated_event_publisher = Guard.IsNotNull( the_shift_calendar_updated_event_publisher, "the_shift_calendar_updated_event_publisher" );
        }

        private readonly IEntityRepository<OperationalCalendar> operation_calendar_repository;
        private readonly ShiftCalendarValidator validator;
        private readonly ICanUpdateShiftCalendar can_update_shift_calendar;
        private readonly IUnitOfWork unit_of_work;
        private readonly IEventPublisher<ShiftCalendarUpdatedEvent> shift_calendar_updated_event_publisher;

        private ResponseBuilder<UpdateShiftCalendarResponse> response_builder;

        private UpdateShiftCalendarRequest update_shift_calendar_request;
        private OperationalCalendar operation_calendar;
        private ShiftCalendar shift_calendar_to_be_updated;
    }
}