using System;
using System.Linq;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WorkSuite.Library.Service.Specification.Helpers.Specifications.ForResponseCommands.VerifiedByAnEntitiesState;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Colour;
using WTS.WorkSuite.Library.DomainTypes.Duration;
using WTS.WorkSuite.Library.DomainTypes.Time;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.Events;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.New;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.TimeAllocation.Events;
using WTS.WorkSuite.PlannedSupply.OperationsCalendars;
using WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.Features.Edit;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars.ShiftCalendarPatterns.ShiftOccurrence;
using WTS.WorkSuite.PlannedSupply.ShiftCalendarPatterns;
using WTS.WorkSuite.PlannedSupply.TimeAllocationOccurrences;
using WTS.WorkSuite.PlannedSupply.TimeAllocations;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.Features.New
{
    public class NewShiftOccurrenceFixture : ResponseCommandVerifiedByAnEntitiesStateFixture<NewShiftOccurrenceRequest
                                                                                             , NewShiftOccurrenceResponse
                                                                                             , INewShiftOccurrence
                                                                                             , TimeAllocationOccurrence>
                                                                     , IClashingShiftFixture<NewShiftOccurrenceRequest
                                                                                            , NewShiftOccurrenceResponse>
    {
        public override TimeAllocationOccurrence entity
        {
            get
            {
                Guard.IsNotNull(response, "response");
                var operational_calendar = operations_calendar_repository
                                                                  .Entities
                                                                  .Single(e => e.id == response.result
                                                                                              .operations_calendar_id)
                                                                  ;

                var shift_calendar = operational_calendar
                                                    .ShiftCalendars
                                                    .Single(e => e.id == response.result
                                                                                    .shift_calendar_id)
                                                    ;

                var shift_calendar_pattern = shift_calendar
                                                    .ShiftCalendarPatterns
                                                    .Single(e => e.id == response.result
                                                                                .shift_calendar_pattern_id)
                                                    ;
                return shift_calendar_pattern
                           .TimeAllocationOccurrences
                           .Single(e => e.id == response.result
                                                       .shift_occurrence_id);
            }
        }

        public void create_request ( ShiftCalendarPatternIdentity pattern_id
                                   , DateTime next_non_clashing_occurrence_date,
                                   int next_non_clashing_shift_start_time)
        {
            request.operations_calendar_id = pattern_id.operations_calendar_id;
            request.shift_calendar_id = pattern_id.shift_calendar_id;
            request.shift_calendar_pattern_id = pattern_id.shift_calendar_pattern_id;
            request.start_date = next_non_clashing_occurrence_date;
        }

        public void set_request_starts_time(TimeRequest value)
        {
            request.start_time = value;
        }

        public void set_request_duration(DurationRequest value)
        {
            request.duration = value;
        }

        public virtual TimeAllocationOccurrence seed_pre_existing_shift_for(NewShiftOccurrenceRequest seed_request)
        {
            var operation_calendar = operations_calendar_repository
                                                                .Entities
                                                                .Single(e => e.id == seed_request.operations_calendar_id);


            var time_allocation = build_a_time_allocation_from(seed_request);

            //**BUILD** an occurrence
            var occurrence = new TimeAllocationOccurrence()
            {
                id = -1111, //The id is being passed in to temporarily solve the problem with the lack of an identity service.
                start_date = seed_request.start_date,
                time_allocation = time_allocation
            };

            operation_calendar.TimeAllocations.Add(time_allocation);

            operation_calendar.ShiftCalendars
                                .Single(sc => sc.id == seed_request.shift_calendar_id)
                                .ShiftCalendarPatterns
                                .Single(sp => sp.id == seed_request.shift_calendar_pattern_id)
                                .TimeAllocationOccurrences
                                .Add(occurrence);

            return occurrence;
        }

        private TimeAllocation build_a_time_allocation_from(NewShiftOccurrenceRequest seed_request)
        {
            //Note that the intention of this method is to build a time allocation object with similar details to what is passed in
            //So I'm using a builder and not a helper; it is not being added to any repository.

            var time_allocation = time_allocation_builder
                                    .colour(new RgbColour(Convert.ToByte(seed_request.colour.R), Convert.ToByte(seed_request.colour.G), Convert.ToByte(seed_request.colour.B)))
                                    .start_time(seed_request.start_time)
                                    .duration(seed_request.duration)
                                    .shift_title(seed_request.shift_title)
                                    .entity;

            time_allocation.id = -1111;//due to lack of an identity service, I'll just give it a fairly random number

            return time_allocation;
        }

        public FakeEventPublisher<TimeAllocationCreatedEvent> time_allocation_created_events_publisher { get; private set; }

        public Maybe<TimeAllocationCreatedEvent> get_time_allocation_created_event_for(TimeAllocation time_allocation)
        {

            var created_event = this
                                    .time_allocation_created_events_publisher
                                    .published_events
                                    .SingleOrDefault(e => e.time_allocation_id == entity.time_allocation.id)
                                    ;

            return created_event != null
                        ? new Just<TimeAllocationCreatedEvent>(created_event) as Maybe<TimeAllocationCreatedEvent>
                        : new Nothing<TimeAllocationCreatedEvent>();

        }

        public FakeEventPublisher<ShiftOccurrenceCreatedEvent> shift_occurrence_created_events_publisher { get; private set; }

        public Maybe<ShiftOccurrenceCreatedEvent> get_shift_occurrence_created_event_for(TimeAllocationOccurrence shift_occurrence)
        {

            var created_event = this
                                    .shift_occurrence_created_events_publisher
                                    .published_events
                                    .SingleOrDefault(e => e.shift_occurrence_id == entity.id)
                                    ;

            return created_event != null
                        ? new Just<ShiftOccurrenceCreatedEvent>(created_event) as Maybe<ShiftOccurrenceCreatedEvent>
                        : new Nothing<ShiftOccurrenceCreatedEvent>();

        }

        public NewShiftOccurrenceFixture(INewShiftOccurrence the_command
            , IRequestHelper<NewShiftOccurrenceRequest> the_request_builder
            , IEntityRepository<OperationalCalendar> the_operations_calendar_repository
            , FakeEventPublisher<TimeAllocationCreatedEvent> the_time_allocation_created_events_publisher
            , FakeEventPublisher<ShiftOccurrenceCreatedEvent> the_shift_occurrence_created_events_publisher
            , TimeAllocationBuilder the_time_allocation_builder
            , TimeAllocationHelper the_time_allocation_helper)
            : base(the_command, the_request_builder)
        {
            operations_calendar_repository = Guard.IsNotNull(the_operations_calendar_repository, "the_operations_calendar_repository");
            time_allocation_created_events_publisher = Guard.IsNotNull(the_time_allocation_created_events_publisher, "the_time_allocation_created_events_publisher");
            shift_occurrence_created_events_publisher = Guard.IsNotNull(the_shift_occurrence_created_events_publisher, "the_shift_occurrence_created_events_publisher");
            time_allocation_builder = the_time_allocation_builder;
            shift_helper = Guard.IsNotNull(the_time_allocation_helper, "the_time_allocation_helper");
        }

        private readonly IEntityRepository<OperationalCalendar> operations_calendar_repository;
        private readonly TimeAllocationBuilder time_allocation_builder;
        public TimeAllocationHelper shift_helper { get; private set; }

      
    }
}