using System;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars.ShiftCalendarPatterns;
using WTS.WorkSuite.PlannedSupply.TimeAllocationOccurrences;
using WTS.WorkSuite.PlannedSupply.TimeAllocations;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.Features.Remove
{
    public class RemoveShiftOccurrenceRequestHelper : IRequestHelper<ShiftOccurrenceIdentity>
    {
        public ShiftOccurrenceIdentity given_a_valid_request()
        {

            var time_allocation = new TimeAllocation()
            {
                colour = "12,13,14",
                duration_in_seconds = 40,
                start_time_in_seconds_from_midnight = 60,
                title = "A time allocation"
            };

            var time_allocation_occurrence = new TimeAllocationOccurrence()
            {
                start_date = DateTime.Now.Date,
                time_allocation = time_allocation
            };

            var shift_calendar_pattern = shift_calendar_pattern_helper
                                                                .add()
                                                                .pattern_name("Shift calendar pattern A")
                                                                .number_of_resources(1)
                                                                .priority(1)
                                                                .add_occurrence(time_allocation_occurrence)
                                                                .entity
                                                                ;


            var shift_calendar = shift_calendar_helper
                                                .add()
                                                .calendar_name("Shift calendar A")
                                                .add_shift_calendar_pattern(shift_calendar_pattern)
                                                .entity
                                                ;




            var operational_calendar = operational_calendar_helper
                                    .add()
                                    .calendar_name("An operations calendar")
                                    .add_shift_calendar(shift_calendar)
                                    .add_time_allocation(time_allocation)
                                    .entity
                                    ;


            return new ShiftOccurrenceIdentity
            {
                operations_calendar_id = operational_calendar.id,
                shift_calendar_id = shift_calendar.id,
                shift_calendar_pattern_id = shift_calendar_pattern.id,
                shift_occurrence_id = time_allocation_occurrence.id
            };
        }

        public RemoveShiftOccurrenceRequestHelper(OperationsCalendarHelper the_operational_calendar_helper
                                                                , ShiftCalendarHelper the_shift_calendar_helper
                                                                , ShiftCalendarPatternHelper the_shift_calendar_pattern_helper)
        {
            operational_calendar_helper = Guard.IsNotNull(the_operational_calendar_helper, "the_operational_calendar_helper");
            shift_calendar_helper = Guard.IsNotNull(the_shift_calendar_helper, "the_shift_calendar_helper");
            shift_calendar_pattern_helper = Guard.IsNotNull(the_shift_calendar_pattern_helper, "the_shift_calendar_pattern_helper");
        }

        private readonly OperationsCalendarHelper operational_calendar_helper;
        private readonly ShiftCalendarHelper shift_calendar_helper;
        private readonly ShiftCalendarPatternHelper shift_calendar_pattern_helper;
    }
}
