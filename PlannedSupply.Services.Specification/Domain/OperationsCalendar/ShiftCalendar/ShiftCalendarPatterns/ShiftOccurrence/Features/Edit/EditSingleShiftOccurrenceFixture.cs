using System;
using System.Linq;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WorkSuite.Library.Service.Specification.Helpers.Specifications.ForResponseCommands;
using WorkSuite.Library.Service.Specification.Helpers.Specifications.ForResponseCommands.VerifiedByAnEntitiesState;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Duration;
using WTS.WorkSuite.Library.DomainTypes.Time;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.AggregateRoot;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.Edit;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.Events;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.TimeAllocation.Events;
using WTS.WorkSuite.PlannedSupply.OperationsCalendars;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars.ShiftCalendarPatterns.ShiftOccurrence;
using WTS.WorkSuite.PlannedSupply.ShiftCalendarPatterns;
using WTS.WorkSuite.PlannedSupply.TimeAllocationOccurrences;
using WTS.WorkSuite.PlannedSupply.TimeAllocations;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.Features.Edit
{

    public interface IClashingShiftFixture<P, Q> : IsAResponseCommandFixture<P, Q> where Q : Response

    {
        TimeAllocationHelper shift_helper { get; }

        void create_request( ShiftCalendarPatternIdentity pattern_id
                           , DateTime next_non_clashing_occurrence_date
                           , int next_non_clashing_shift_start_time );

        void set_request_starts_time(TimeRequest value);

        void set_request_duration(DurationRequest value);
    }


    public class EditSingleShiftOccurrenceFixture
                                 : ResponseCommandVerifiedByAnEntitiesStateFixture < EditSingleShiftOccurrenceRequest
                                                                                   , EditSingleShiftOccurrenceResponse
                                                                                   , IEditSingleShiftOcuurrence
                                                                                   , TimeAllocationOccurrence >
                                                          , IClashingShiftFixture  < EditSingleShiftOccurrenceRequest
                                                                                   , EditSingleShiftOccurrenceResponse >
    {
        public override TimeAllocationOccurrence entity
        {
            get
            {
                Guard.IsNotNull(request, "request");
                var operational_calendar = operations_calendar_repository
                                         .Entities
                                         .Single(oc => oc.id == request.operations_calendar_id);

                var shift_calendar = operational_calendar
                                          .ShiftCalendars
                                          .Single(sc => sc.id == request.shift_calendar_id);
                var shift_calendar_pattern = shift_calendar
                                          .ShiftCalendarPatterns
                                          .Single(scp => scp.id == request.shift_calendar_pattern_id);

                return shift_calendar_pattern.TimeAllocationOccurrences
                                         .Single(tao => tao.id == request.shift_occurrence_id);
            }
        }

        public void create_request ( ShiftCalendarPatternIdentity pattern_id
                                   , DateTime next_non_clashing_occurrence_date
                                   , int next_non_clashing_shift_start_time)
        {
            var pattern = get_pattern(pattern_id);

            var occurrence = new TimeAllocationOccurrence()
            {
                id = -9876,
                start_date = next_non_clashing_occurrence_date,
                time_allocation = new TimeAllocation()
                {
                    title = "shift B",
                    colour = "23,24,25",
                    start_time_in_seconds_from_midnight = next_non_clashing_shift_start_time,
                    duration_in_seconds = 3600,
                    id = -555
                }
            };

            pattern.TimeAllocationOccurrences.Add(occurrence);

            request.operations_calendar_id = pattern_id.operations_calendar_id;
            request.shift_calendar_id = pattern_id.shift_calendar_id;
            request.shift_calendar_pattern_id = pattern_id.shift_calendar_pattern_id;
            request.shift_occurrence_id = occurrence.id;
            request.start_date = next_non_clashing_occurrence_date.ToString();
            request.shift_title = occurrence.time_allocation.title;
            request.colour = occurrence.time_allocation.colour.to_rgb_colour_request_from_persistence_format();
            request.start_time = occurrence.time_allocation.start_time_in_seconds_from_midnight.ToTimeRequestFromSeconds();
            request.duration = occurrence.time_allocation.duration_in_seconds.to_duration_request();
        }

        public void set_request_starts_time(TimeRequest value)
        {
            request.start_time = value;
        }

        public void set_request_duration(DurationRequest value)
        {
            request.duration = value;
        }

        private ShiftCalendarPattern get_pattern(ShiftCalendarPatternIdentity pattern_id)
        {
            return operations_calendar_repository.Entities.Single(o => o.id == pattern_id.operations_calendar_id)
                .ShiftCalendars.Single(sc => sc.id == pattern_id.shift_calendar_id)
                .ShiftCalendarPatterns.Single(x => x.id == pattern_id.shift_calendar_pattern_id);
        }

        public void contaminate_internal_break()
        {
            //Improve: These seed methods are essentially the same except for a few differences
            var time_allocation =
                operations_calendar_repository
                                        .Entities
                                        .Single(e => e.id == request.operations_calendar_id)
                                        .ShiftCalendars
                                        .SelectMany(sc => sc.ShiftCalendarPatterns
                                        .SelectMany(scp => scp.TimeAllocationOccurrences))
                                        .Single(tao => tao.id == request.shift_occurrence_id)
                                        .time_allocation;

            time_allocation.TimeAllocationBreaks.Add(new TimeAllocationBreaks.TimeAllocationBreak()
            {
                duration_in_seconds = -1,
                offset_from_start_time_in_seconds = -1,
                is_paid = false
            });

        }

        public TimeAllocation get_backing_time_allocation(ShiftOccurrenceIdentity the_request)
        {
            return get_shift_occurrenc.execute(the_request).time_allocation;
        }

        public void ensure_a_break_ends_1_minute_before_the_end_of_this_time_allocation(TimeAllocation the_time_allocation)
        {
            var last_break = the_time_allocation
                            .TimeAllocationBreaks
                            .OrderBy(ta => ta.offset_from_start_time_in_seconds + ta.duration_in_seconds)
                            .LastOrDefault();

            if (last_break == null)
            {
                the_time_allocation.TimeAllocationBreaks.Add(new TimeAllocationBreaks.TimeAllocationBreak()
                {
                    duration_in_seconds = the_time_allocation.duration_in_seconds - 60,
                    offset_from_start_time_in_seconds = 0,
                    is_paid = false,
                    id = -991111
                });
            }
            else
            {
                last_break.offset_from_start_time_in_seconds = 0;
                last_break.duration_in_seconds = the_time_allocation.duration_in_seconds - 60;
            }
        }

        public Maybe<TimeAllocationUpdateEvent> get_time_allocation_update_event_for()
        {
            var create_event = this.time_allocation_update_events_publisher
                             .published_events
                             .SingleOrDefault(e => e.time_allocation_id == entity.time_allocation.id);
            return create_event != null
                ? new Just<TimeAllocationUpdateEvent>(create_event) as Maybe<TimeAllocationUpdateEvent>
                : new Nothing<TimeAllocationUpdateEvent>();

        }

        public Maybe<ShiftOccurrenceUpdateEvent> get_shift_occurrence_update_event_for()
        {
            var create_event = this.shift_occurrence_update_event_publisher
                             .published_events
                             .SingleOrDefault(e => e.shift_occurrence_id == entity.id);

            return create_event != null
                ? new Just<ShiftOccurrenceUpdateEvent>(create_event) as Maybe<ShiftOccurrenceUpdateEvent>
                : new Nothing<ShiftOccurrenceUpdateEvent>();
        }


        public EditSingleShiftOccurrenceFixture(IEditSingleShiftOcuurrence the_edit_single_shift_occurrence
                                               , IRequestHelper<EditSingleShiftOccurrenceRequest> the_edit_single_shift_occurrence_request_builder
                                               , IEntityRepository<OperationalCalendar> the_operations_calendar_repository
                                               , FakeEventPublisher<TimeAllocationUpdateEvent> the_time_allocation_update_events_publisher
                                               , FakeEventPublisher<ShiftOccurrenceUpdateEvent> the_shift_occurrence_update_events_publisher
                                                , TimeAllocationHelper the_time_allocation_helper
                                               , GetOccurrence the_get_shift_occurrence)
            : base(the_edit_single_shift_occurrence,
                     the_edit_single_shift_occurrence_request_builder)
        {

            operations_calendar_repository = Guard.IsNotNull(the_operations_calendar_repository, "the_operations_calendar_repository");
            time_allocation_update_events_publisher = Guard.IsNotNull(the_time_allocation_update_events_publisher, "the_time_allocation_update_events_publisher");
            shift_occurrence_update_event_publisher = Guard.IsNotNull(the_shift_occurrence_update_events_publisher, "the_shift_occurrence_update_events_publisher");
            get_shift_occurrenc = Guard.IsNotNull(the_get_shift_occurrence, "the_get_shift_occurrence");

            shift_helper = Guard.IsNotNull(the_time_allocation_helper, "the_time_allocation_helper");
        }
        private readonly GetOccurrence get_shift_occurrenc;
        private readonly IEntityRepository<OperationalCalendar> operations_calendar_repository;
        public FakeEventPublisher<TimeAllocationUpdateEvent> time_allocation_update_events_publisher { get; private set; }
        public FakeEventPublisher<ShiftOccurrenceUpdateEvent> shift_occurrence_update_event_publisher { get; private set; }
        public TimeAllocationHelper shift_helper { get; private set; }


    }
}