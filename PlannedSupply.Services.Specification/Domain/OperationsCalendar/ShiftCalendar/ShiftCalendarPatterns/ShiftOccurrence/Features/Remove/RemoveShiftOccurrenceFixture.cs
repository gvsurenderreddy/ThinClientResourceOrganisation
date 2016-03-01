using System.Linq;
using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WorkSuite.Library.Service.Specification.Helpers.Specifications.ForResponseCommands;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.Events;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.Remove;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.Features.Remove
{
    public class RemoveShiftOccurrenceFixture : ResponseCommandFixture<ShiftOccurrenceIdentity, RemoveShiftOccurrenceResponse, IRemoveShiftOccurrence>
    {
        public void clear_repository()
        {
            operations_calendar_repository.clear();
        }

        public Maybe<ShiftOccurrenceRemovedEvent> get_shift_occurrence_removed_event_for(ShiftOccurrenceIdentity the_request)
        {
            var the_event = events_publisher
                                .published_events
                                .Where(e => e.operations_calendar_id == the_request.operations_calendar_id)
                                .FirstOrDefault(e => e.shift_calendar_id == the_request.shift_calendar_id)
                                ;

            return the_event != null
                    ? new Just<ShiftOccurrenceRemovedEvent>(the_event) as Maybe<ShiftOccurrenceRemovedEvent>
                    : new Nothing<ShiftOccurrenceRemovedEvent>()
                    ;
        }

        public RemoveShiftOccurrenceFixture(IRemoveShiftOccurrence the_command
                                           , IRequestHelper<ShiftOccurrenceIdentity> the_request_builder
                                           , FakeOperationsCalendarRepository the_operations_calendar_repository
                                           , FakeEventPublisher<ShiftOccurrenceRemovedEvent> the_event_publisher)
            : base(the_command, the_request_builder)
        {
            events_publisher = Guard.IsNotNull(the_event_publisher, "the_event_publisher");
            operations_calendar_repository = Guard.IsNotNull(the_operations_calendar_repository, "the_operations_calendar_repository");
        }

        private FakeEventPublisher<ShiftOccurrenceRemovedEvent> events_publisher;
        private readonly FakeOperationsCalendarRepository operations_calendar_repository;
    }
}