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
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.NewFromTemplate;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.TimeAllocation.Events;
using WTS.WorkSuite.PlannedSupply.OperationsCalendars;
using WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.Features.Edit;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars.ShiftCalendarPatterns.ShiftOccurrence;
using WTS.WorkSuite.PlannedSupply.TimeAllocationBreaks;
using WTS.WorkSuite.PlannedSupply.TimeAllocationOccurrences;
using WTS.WorkSuite.PlannedSupply.TimeAllocations;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.Features.NewFromTemplate
{
    public class NewShiftOccurrenceFromShiftTemplateFixture : ResponseCommandVerifiedByAnEntitiesStateFixture < NewShiftOccurrenceFromShiftTemplateRequest,
                                                                                                                 NewShiftOccurrenceFromShiftTemplateResponse,
                                                                                                                 INewShiftOccurrenceFromShiftTemplate,
                                                                                                                 TimeAllocationOccurrence>
                                                                                      , IClashingShiftFixture < NewShiftOccurrenceFromShiftTemplateRequest
                                                                                                              , NewShiftOccurrenceFromShiftTemplateResponse>
    {
        public override TimeAllocationOccurrence entity
        {
            get
            {
                Guard.IsNotNull(response, "response");

                var operational_calendar = operations_calendar_repository
                                                                    .Entities
                                                                    .Single(e=>e.id == response.result
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

        public void create_request(ShiftCalendarPatternIdentity pattern_id 
                                   , DateTime next_non_clashing_occurrence_date
                                   , int next_non_clashing_shift_start_time)
        {
            var shift_template = shift_template_repository.Entities.Single(st => st.id == request.shift_template_id);
            request.operations_calendar_id = pattern_id.operations_calendar_id;
            request.shift_calendar_id = pattern_id.shift_calendar_id;
            request.shift_calendar_pattern_id = pattern_id.shift_calendar_pattern_id;
            request.shift_template_id = shift_template.id;
            request.start_date = next_non_clashing_occurrence_date;
        }

        public void set_request_starts_time(TimeRequest value)
        {
            var shift_template = shift_template_repository.Entities.Single(st => st.id == request.shift_template_id);
            shift_template .start_time_in_seconds_from_midnight= value.to_Seconds();
        }

        public void set_request_duration(DurationRequest value)
        {
            var shift_template = shift_template_repository.Entities.Single(st => st.id == request.shift_template_id);
            shift_template.duration_in_seconds = value.to_seconds();
        }

        public virtual TimeAllocationOccurrence seed_pre_existing_shift_for(NewShiftOccurrenceFromShiftTemplateRequest seed_request)
        {
            //Improve: These seed methods are essentially the same except for a few differences
            var operation_calendar = operations_calendar_repository
                                                                .Entities
                                                                .Single(e => e.id == seed_request.operations_calendar_id);

            var shift_template = shift_template_repository.Entities.Single(st => st.id == seed_request.shift_template_id);

            var time_allocation = time_allocation_builder
                                    .colour(shift_template.colour.rgb_colour_format())
                                    .start_time(shift_template.start_time_in_seconds_from_midnight.ToTimeRequestFromSeconds())
                                    .duration(shift_template.duration_in_seconds.to_duration_request())
                                    .shift_title(shift_template.shift_title)
                                    .add_breaks(shift_template.break_template.all_breaks.Select(bt => new TimeAllocationBreak()
                                                                                                {
                                                                                                    duration_in_seconds = bt.duration_in_seconds,
                                                                                                    is_paid = bt.is_paid,
                                                                                                    offset_from_start_time_in_seconds = bt.offset_from_start_time_in_seconds
                                                                                                }))
                                    .entity;

            time_allocation.id = -111;//Id is being passed in for lack of an identity service


            var occurrence = new TimeAllocationOccurrence()
            {
                id = -1111, //The id is being passed in to temporarily solve the problem with the lack of an identity service.
                start_date = seed_request.start_date,
                time_allocation = time_allocation
            };

            operation_calendar.TimeAllocations.Add(time_allocation);

            operation_calendar
                        .ShiftCalendars
                        .Single(sc => sc.id == seed_request.shift_calendar_id)
                        .ShiftCalendarPatterns
                        .Single(sp => sp.id == seed_request.shift_calendar_pattern_id)
                        .TimeAllocationOccurrences
                        .Add(occurrence);

            return occurrence;
        }

        public virtual TimeAllocationOccurrence seed_pre_existing_shift_that_is_different_from(NewShiftOccurrenceFromShiftTemplateRequest seed_request)
        {
            //Improve: These seed methods are essentially the same except for a few differences
            var operation_calendar = operations_calendar_repository
                                                                .Entities
                                                                .Single(e => e.id == seed_request.operations_calendar_id);

            var shift_template = shift_template_repository.Entities.Single(st => st.id == seed_request.shift_template_id);

            var time_allocation = time_allocation_builder
                                    .colour(shift_template.colour.rgb_colour_format())
                                    .start_time(shift_template.start_time_in_seconds_from_midnight.ToTimeRequestFromSeconds())
                                    .duration(shift_template.duration_in_seconds.to_duration_request())
                                    .shift_title(shift_template.shift_title + "different")
                                    .add_breaks(shift_template.break_template.all_breaks.Select(bt=>new TimeAllocationBreak()
                                                                                                {
                                                                                                    duration_in_seconds = bt.duration_in_seconds, 
                                                                                                    is_paid = bt.is_paid, 
                                                                                                    offset_from_start_time_in_seconds = bt.offset_from_start_time_in_seconds
                                                                                                }))
                                    .entity;

            time_allocation.id = -111;//Id is being passed in for lack of an identity service


            var occurrence = new TimeAllocationOccurrence()
            {
                id = -1111, //The id is being passed in to temporarily solve the problem with the lack of an identity service.
                start_date = seed_request.start_date,
                time_allocation = time_allocation
            };

            operation_calendar.TimeAllocations.Add(time_allocation);

            operation_calendar
                        .ShiftCalendars
                        .Single(sc => sc.id == seed_request.shift_calendar_id)
                        .ShiftCalendarPatterns
                        .Single(sp => sp.id == seed_request.shift_calendar_pattern_id)
                        .TimeAllocationOccurrences
                        .Add(occurrence);

            return occurrence;
        }

        public virtual TimeAllocationOccurrence seed_pre_existing_shift_that_has_same_details_but_different_break_signature(NewShiftOccurrenceFromShiftTemplateRequest seed_request)
        {
            //Improve: These seed methods are essentially the same except for a few differences
            var operation_calendar = operations_calendar_repository
                                                                .Entities
                                                                .Single(e => e.id == seed_request.operations_calendar_id);

            var shift_template = shift_template_repository.Entities.Single(st => st.id == seed_request.shift_template_id);

            var time_allocation = time_allocation_builder
                                    .colour(shift_template.colour.rgb_colour_format())
                                    .start_time(shift_template.start_time_in_seconds_from_midnight.ToTimeRequestFromSeconds())
                                    .duration(shift_template.duration_in_seconds.to_duration_request())
                                    .shift_title(shift_template.shift_title)
                                    .add_breaks(shift_template.break_template.all_breaks.Select(bt => new TimeAllocationBreak()
                                    {
                                        duration_in_seconds = bt.duration_in_seconds + 1,//adding 1 second to each duration
                                        is_paid = bt.is_paid,
                                        offset_from_start_time_in_seconds = bt.offset_from_start_time_in_seconds
                                    }))
                                    .entity;

            time_allocation.id = -111;//Id is being passed in for lack of an identity service


            var occurrence = new TimeAllocationOccurrence()
            {
                id = -1111, //The id is being passed in to temporarily solve the problem with the lack of an identity service.
                start_date = seed_request.start_date,
                time_allocation = time_allocation
            };

            operation_calendar.TimeAllocations.Add(time_allocation);

            operation_calendar
                        .ShiftCalendars
                        .Single(sc => sc.id == seed_request.shift_calendar_id)
                        .ShiftCalendarPatterns
                        .Single(sp => sp.id == seed_request.shift_calendar_pattern_id)
                        .TimeAllocationOccurrences
                        .Add(occurrence);

            return occurrence;
        }

        public virtual void contaminate_internal_shift_template()
        {
            //Improve: These seed methods are essentially the same except for a few differences
            var operation_calendar = operations_calendar_repository
                                                                .Entities
                                                                .Single(e => e.id == request.operations_calendar_id);

            var shift_template = shift_template_repository.Entities.Single(st => st.id == request.shift_template_id);

            var first_break = shift_template.break_template.all_breaks.FirstOrDefault();


            shift_template.shift_title = "";

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




        public NewShiftOccurrenceFromShiftTemplateFixture(INewShiftOccurrenceFromShiftTemplate the_new_shift_calendar_pattern
                                                            ,IRequestHelper<NewShiftOccurrenceFromShiftTemplateRequest> the_new_shift_calendar_pattern_request
                                                            ,IEntityRepository<OperationalCalendar> the_operations_calendar_repository
                                                            , IEntityRepository<PlannedSupply.ShiftTemplates.ShiftTemplate> the_shift_template_repository
                                                            , FakeEventPublisher<TimeAllocationCreatedEvent> the_time_allocation_created_events_publisher
                                                            , FakeEventPublisher<ShiftOccurrenceCreatedEvent> the_shift_occurrence_created_events_publisher
                                                            , TimeAllocationBuilder the_time_allocation_builder
                                                            , TimeAllocationHelper the_time_allocation_helper)

        : base(the_new_shift_calendar_pattern, the_new_shift_calendar_pattern_request)
        {
            operations_calendar_repository = Guard.IsNotNull(the_operations_calendar_repository,"the_operations_calendar_repository");
            shift_template_repository = Guard.IsNotNull(the_shift_template_repository, "the_shift_template_repository");
            time_allocation_created_events_publisher = Guard.IsNotNull(the_time_allocation_created_events_publisher, "the_time_allocation_created_events_publisher");
            shift_occurrence_created_events_publisher = Guard.IsNotNull(the_shift_occurrence_created_events_publisher, "the_shift_occurrence_created_events_publisher");
            time_allocation_builder = the_time_allocation_builder;
            shift_helper = Guard.IsNotNull(the_time_allocation_helper, "the_time_allocation_helper");
        }

        private readonly IEntityRepository<OperationalCalendar> operations_calendar_repository;
        private readonly IEntityRepository<PlannedSupply.ShiftTemplates.ShiftTemplate> shift_template_repository;
        private readonly TimeAllocationBuilder time_allocation_builder;
        public TimeAllocationHelper shift_helper { get; private set; }

       
    }
}