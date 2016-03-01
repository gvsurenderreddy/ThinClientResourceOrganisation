using Content.Services.PlannedSupply.Messages;
using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.Events;
using WTS.WorkSuite.PlannedSupply.OperationsCalendars;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.Remove
{
    using ShiftCalendar = PlannedSupply.ShiftCalendars.ShiftCalendar;

    public class RemoveShiftCalendar
                        : IRemoveShiftCalendar
    {
        public RemoveShiftCalendarResponse execute
                                            (ShiftCalendarIdentity the_remove_shift_calendar_request)
        {
            return this
                    .set_request(the_remove_shift_calendar_request)
                    .find_operational_calendar()
                    .find_shift_calendar()
                    .create_shift_calendar_removed_event()
                    .remove_shift_calendar()
                    .commit()
                    .publish_shift_calendar_removed_event()
                    .build_response()
                    ;
        }

        private RemoveShiftCalendar set_request
                                        (ShiftCalendarIdentity the_remove_shift_calendar_request)
        {
            remove_shift_calendar_request = Guard.IsNotNull(the_remove_shift_calendar_request, "the_remove_shift_calendar_request");
            response_builder = new ResponseBuilder<RemoveShiftCalendarResponse>();
            return this;
        }

        private RemoveShiftCalendar find_operational_calendar()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(remove_shift_calendar_request, "remove_shift_calendar_request");

            operation_calendar = operational_calendar_repository
                                    .Entities
                                    .Single(oc => oc.id == remove_shift_calendar_request.operations_calendar_id)
                                    ;
            return this;
        }

        private RemoveShiftCalendar find_shift_calendar()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(remove_shift_calendar_request, "remove_shift_calendar_request");
            Guard.IsNotNull(operation_calendar, "operational_calendar");

            shift_calendar_to_be_removed = operation_calendar
                                            .ShiftCalendars
                                            .Single(sc => sc.id == remove_shift_calendar_request.shift_calendar_id)
                                            ;
            return this;
        }

        private RemoveShiftCalendar create_shift_calendar_removed_event()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(operation_calendar, "operation_calendar");
            Guard.IsNotNull(shift_calendar_to_be_removed, "shift_calendar_to_be_removed");

            shift_calendar_removed_event = new ShiftCalendarRemovedEvent
                                                {
                                                    operations_calendar_id = operation_calendar.id,
                                                    shift_calendar_id = shift_calendar_to_be_removed.id,
                                                    calendar_name = shift_calendar_to_be_removed.calendar_name
                                                };

            return this;
        }

        private RemoveShiftCalendar remove_shift_calendar()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(operation_calendar, "operational_calendar");
            Guard.IsNotNull(shift_calendar_to_be_removed, "shift_calendar_to_be_removed");
            Guard.IsNotNull(remove_shift_calendar_request, "remove_shift_calendar_request");

            operation_calendar
                .ShiftCalendars
                .Remove(shift_calendar_to_be_removed)
                ;

            operational_calendar_repository
                        .remove(shift_calendar_to_be_removed)
                        ;

            return this;
        }

        private RemoveShiftCalendar commit()
        {
            if (response_builder.has_errors) return this;

            unit_of_work.Commit();
            response_builder.add_message(ConfirmationMessages.confirmation_04_0022);
            return this;
        }

        private RemoveShiftCalendar publish_shift_calendar_removed_event()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(shift_calendar_removed_event_publisher, "shift_calendar_removed_event_publisher");
            Guard.IsNotNull(shift_calendar_removed_event, "shift_calendar_removed_event");

            shift_calendar_removed_event_publisher
                .publish(shift_calendar_removed_event);

            return this;
        }

        private RemoveShiftCalendarResponse build_response()
        {
            return response_builder.build();
        }

        public RemoveShiftCalendar
                (IEntityRepository<OperationalCalendar> the_operational_calendar_repository
                , IUnitOfWork the_unit_of_work
                , IEventPublisher<ShiftCalendarRemovedEvent> the_shift_calendar_removed_event_publisher
                )
        {
            operational_calendar_repository = Guard.IsNotNull(the_operational_calendar_repository, "the_operational_calendar_repository");
            unit_of_work = Guard.IsNotNull(the_unit_of_work, "the_unit_of_work");
            shift_calendar_removed_event_publisher = Guard.IsNotNull(the_shift_calendar_removed_event_publisher,
                                                                     "the_shift_calendar_removed_event_publisher"
                                                                    );
        }

        private ShiftCalendarIdentity remove_shift_calendar_request;
        private ResponseBuilder<RemoveShiftCalendarResponse> response_builder;
        private OperationalCalendar operation_calendar;
        private ShiftCalendar shift_calendar_to_be_removed;
        private ShiftCalendarRemovedEvent shift_calendar_removed_event;

        private readonly IEntityRepository<OperationalCalendar> operational_calendar_repository;
        private readonly IUnitOfWork unit_of_work;
        private readonly IEventPublisher<ShiftCalendarRemovedEvent> shift_calendar_removed_event_publisher;
    }
}