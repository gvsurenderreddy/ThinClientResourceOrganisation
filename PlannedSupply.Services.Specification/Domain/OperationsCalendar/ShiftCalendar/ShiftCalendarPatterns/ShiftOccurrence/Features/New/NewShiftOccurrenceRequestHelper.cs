using System;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Colour;
using WTS.WorkSuite.Library.DomainTypes.Duration;
using WTS.WorkSuite.Library.DomainTypes.Time;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.New;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars.ShiftCalendarPatterns;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars.ShiftCalendarPatterns.ShiftOccurrence;
using WTS.WorkSuite.PlannedSupply.TimeAllocations;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.Features.New
{
    public class NewShiftOccurrenceRequestHelper : IRequestHelper<NewShiftOccurrenceRequest>
    {
        public NewShiftOccurrenceRequest given_a_valid_request()
        {
            var shift_calendar_pattern = shift_calendar_pattern_helper
                                                .add()
                                                .pattern_name("Shift calendar pattern A")
                                                .number_of_resources(1)
                                                .priority(1)
                                                .entity
                                                ;

            var shift_calendar = shift_calender_helper
                                                .add()
                                                .calendar_name("Shift calendar A")
                                                .add_shift_calendar_pattern(shift_calendar_pattern)
                                                .entity
                                                ;


            var operational_calender = operational_calendar_helper
                                               .add()
                                               .calendar_name("An operations calendar")
                                               .add_shift_calendar(shift_calendar)
                                               .entity
                                               ;


            var time_allocation = build_an_arbitrary_time_allocation_only_needed_for_building_a_valid_new_shift_occurrence_request();

            return new NewShiftOccurrenceRequest()
            {
                operations_calendar_id = operational_calender.id,
                shift_calendar_id = shift_calendar.id,
                shift_calendar_pattern_id = shift_calendar_pattern.id,
                start_date = DateTime.Now.AddMonths(2).Date,
                shift_title = time_allocation.title,
                colour = time_allocation.colour.to_rgb_colour_request_from_persistence_format(),
                start_time = time_allocation.start_time_in_seconds_from_midnight.ToTimeRequestFromSeconds(),
                duration = time_allocation.duration_in_seconds.to_duration_request()

            };
        }

        private TimeAllocation build_an_arbitrary_time_allocation_only_needed_for_building_a_valid_new_shift_occurrence_request()
        {
            return time_allocation_builder
                            .colour(new RgbColour(25, 24, 28))
                            .start_time(new TimeRequest() { hours = "12", minutes = "23" })
                            .duration(new DurationRequest() { hours = "3", minutes = "23" })
                            .shift_title("new shift")
                            .entity;
        }

        public NewShiftOccurrenceRequestHelper(ShiftCalendarPatternHelper the_shift_calendar_pattern_helper
                                               , TimeAllocationBuilder the_time_allocation_builder
                                               , ShiftCalendarHelper the_shift_calender_helper
                                               , OperationsCalendarHelper the_operational_calender)
        {
            operational_calendar_helper = Guard.IsNotNull(the_operational_calender, "the_operational_calender");
            shift_calender_helper = Guard.IsNotNull(the_shift_calender_helper, "the_shift_calender_helper");
            time_allocation_builder = Guard.IsNotNull(the_time_allocation_builder, "the_shift_occurrence_helper");
            shift_calendar_pattern_helper = Guard.IsNotNull(the_shift_calendar_pattern_helper, "the_shift_calendar_pattern_helper");
        }

        private readonly OperationsCalendarHelper operational_calendar_helper;
        private readonly ShiftCalendarHelper shift_calender_helper;
        private readonly TimeAllocationBuilder time_allocation_builder;
        private readonly ShiftCalendarPatternHelper shift_calendar_pattern_helper;
    }
}