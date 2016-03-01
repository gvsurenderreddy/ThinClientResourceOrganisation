using System;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.ShiftBreaks.Remove;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars.ShiftCalendarPatterns;
using WTS.WorkSuite.PlannedSupply.TimeAllocationOccurrences;
using WTS.WorkSuite.PlannedSupply.TimeAllocations;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.ShiftBreaks.Features.RemoveShiftBreak
{
    public class RemoveShiftBreakRequestHelper : IRequestHelper<RemoveShiftBreakRequest>
    {
        public RemoveShiftBreakRequest given_a_valid_request()
        {

            var shift_break = new TimeAllocationBreaks.TimeAllocationBreak()
            {
                duration_in_seconds = 3600,
                is_paid = true,
                offset_from_start_time_in_seconds = 20,
                id = 999
            };

            var time_allocation = new TimeAllocation()
            {
                colour = "12,13,14",
                duration_in_seconds = 43200,
                start_time_in_seconds_from_midnight = 60,
                title = "A time allocation"
            };

            time_allocation.TimeAllocationBreaks.Add(shift_break);

            var time_allocation_occurrence = new TimeAllocationOccurrence()
            {
                id = -111,
                start_date = DateTime.Now.Date,
                time_allocation = time_allocation
            };

            var time_allocation_occurrence_2 = new TimeAllocationOccurrence()
            {
                id = -112,
                start_date = DateTime.Now.Date,
                time_allocation = time_allocation
            };

            var shift_calendar_pattern = shift_calendar_pattern_helper
                .add()
                .pattern_name("Shift calendar pattern A")
                .number_of_resources(1)
                .priority(1)
                .add_occurrence(time_allocation_occurrence)
                .add_occurrence(time_allocation_occurrence_2)
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


            return new RemoveShiftBreakRequest()
            {
                operations_calendar_id = operational_calendar.id,
                shift_calendar_id = shift_calendar.id,
                shift_calendar_pattern_id = shift_calendar_pattern.id,
                shift_occurrence_id = time_allocation_occurrence.id,
                is_paid = true,
                duration = null,
                off_set = null,
                shift_break_id = shift_break.id
            };
        }


        public RemoveShiftBreakRequestHelper(OperationsCalendarHelper the_operational_calendar_helper
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
