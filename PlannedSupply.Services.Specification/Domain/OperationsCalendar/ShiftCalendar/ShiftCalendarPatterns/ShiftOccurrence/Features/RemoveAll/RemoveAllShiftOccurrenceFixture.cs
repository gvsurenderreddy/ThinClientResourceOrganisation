using System.Linq;
using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WorkSuite.Library.Service.Specification.Helpers.Specifications.ForResponseCommands;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.Events;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.RemoveAll;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars;
using WTS.WorkSuite.PlannedSupply.TimeAllocations;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.Features.RemoveAll
{
    public class RemoveAllShiftOccurrenceFixture : ResponseCommandFixture<ShiftOccurrenceIdentity, RemoveAllShiftOccurrencesResponse, IRemoveAllShiftOccurrences>
    {
        public void clear_repository()
        {
            operations_calendar_repository.clear();

        }

        public TimeAllocation the_time_allocation_entity()
        {
            return operations_calendar_repository
                                             .Entities.Single(o => o.id == request.operations_calendar_id)
                                             .ShiftCalendars
                                             .Single(sc => sc.id == request.shift_calendar_id)
                                             .ShiftCalendarPatterns
                                             .Single(scp => scp.id == request.shift_calendar_pattern_id)
                                             .TimeAllocationOccurrences
                                             .Single(oc => oc.id == request.shift_occurrence_id)
                                             .time_allocation;


        }

        public Maybe<ShiftOccurrenceRemovedEvent> get_shift_occurrence_removed_event_for(ShiftOccurrenceIdentity the_request)
        {
            var the_event = events_publisher
                           .published_events
                           .Where(e => e.operations_calendar_id == the_request.operations_calendar_id)
                           .FirstOrDefault(e => e.shift_calendar_id == the_request.shift_calendar_id);

            return the_event != null
                      ? new Just<ShiftOccurrenceRemovedEvent>(the_event) as Maybe<ShiftOccurrenceRemovedEvent>
                      : new Nothing<ShiftOccurrenceRemovedEvent>();
        }

        public RemoveAllShiftOccurrenceFixture(IRemoveAllShiftOccurrences the_command
                                               , IRequestHelper<ShiftOccurrenceIdentity> the_request_builder
                                               , FakeOperationsCalendarRepository the_operations_calendar_repository
                                               , FakeEventPublisher<ShiftOccurrenceRemovedEvent> the_event_publisher)

            : base(the_command, the_request_builder)
        {
            events_publisher = Guard.IsNotNull(the_event_publisher, "the_event_publisher");
            operations_calendar_repository = Guard.IsNotNull(the_operations_calendar_repository, "the_operations_calendar_repository");
            command = Guard.IsNotNull(the_command, "the_command");
        }

        private readonly FakeEventPublisher<ShiftOccurrenceRemovedEvent> events_publisher;
        private readonly FakeOperationsCalendarRepository operations_calendar_repository;
        private IRemoveAllShiftOccurrences command;
    }
}