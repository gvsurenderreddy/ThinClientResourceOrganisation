using System;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Duration;
using WTS.WorkSuite.Library.DomainTypes.Time;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.Edit;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars;
using WTS.WorkSuite.PlannedSupply.ShiftCalendarPatterns;
using WTS.WorkSuite.PlannedSupply.TimeAllocationOccurrences;
using WTS.WorkSuite.PlannedSupply.TimeAllocations;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.Features.Edit
{
    public class EditSingleShiftOccurrenceRequestHelper : IRequestHelper<EditSingleShiftOccurrenceRequest>
    {
        public EditSingleShiftOccurrenceRequest given_a_valid_request()
        {
            //var time_allocation_break = get_a_break();

            var time_allocation = get_a_time_allocation();//time_allocation_break);

            var time_allocation_occurrence = get_a_time_allocation_occurrence(time_allocation);

            var shift_calendar_pattern = get_a_shift_calendar_pattern(time_allocation_occurrence);

            var shift_calendar = get_a_shift_calendar(shift_calendar_pattern);

            var operational_calendar = operational_calendar_helper
                                   .add()
                                   .calendar_name("An operations calendar")
                                   .add_shift_calendar(shift_calendar)
                                   .add_time_allocation(time_allocation)
                                   .entity
                                   ;


            return new EditSingleShiftOccurrenceRequest()
            {
                operations_calendar_id = operational_calendar.id,
                shift_calendar_id = shift_calendar.id,
                shift_calendar_pattern_id = shift_calendar_pattern.id,
                shift_occurrence_id = time_allocation_occurrence.id,
                start_date = time_allocation_occurrence.start_date.ToString(),
                shift_title = time_allocation.title,
                colour = time_allocation.colour.to_rgb_colour_request_from_persistence_format(),
                start_time = time_allocation.start_time_in_seconds_from_midnight.ToTimeRequestFromSeconds(),
                duration = time_allocation.duration_in_seconds.to_duration_request()
            };
        }

        private ShiftCalendars.ShiftCalendar get_a_shift_calendar(ShiftCalendarPattern a_pattern)
        {
            var shift_calendar = new ShiftCalendars.ShiftCalendar()
            {
                id = -111,
                calendar_name = "calednar"
            };
            shift_calendar.ShiftCalendarPatterns.Add(a_pattern);

            return shift_calendar;
        }

        private ShiftCalendarPattern get_a_shift_calendar_pattern(TimeAllocationOccurrence an_occurrence)
        {
            var pattern = new ShiftCalendarPattern()
            {
                id = -111,
                name = "pattern",
                number_of_resources = 5,
                priority = 1
            };
            pattern.TimeAllocationOccurrences.Add(an_occurrence);

            return pattern;
        }

        private TimeAllocationOccurrence get_a_time_allocation_occurrence(TimeAllocation a_time_allocation)
        {
            return new TimeAllocationOccurrence()
            {
                id = -111,
                start_date = DateTime.Now.Date,
                time_allocation = a_time_allocation
            };
        }

        private TimeAllocation get_a_time_allocation()//TimeAllocationBreaks.TimeAllocationBreak a_break)
        {
            var time_allocation = new TimeAllocation()
            {
                colour = "12,13,14",
                duration_in_seconds = 3600 * 10,
                start_time_in_seconds_from_midnight = 3600,
                title = "A time allocation",
                id = -111
            };

//            time_allocation.TimeAllocationBreaks.Add(a_break);
            return time_allocation;
        }

//        private TimeAllocationBreaks.TimeAllocationBreak get_a_break()
//        {
//            return new TimeAllocationBreaks.TimeAllocationBreak()
//            {
//                id = -111,
//                offset_from_start_time_in_seconds = 3600,
//                duration_in_seconds = 3600,
//                is_paid = false
//            };
//        }

        public EditSingleShiftOccurrenceRequestHelper(OperationsCalendarHelper the_operational_calendar_helper)
        {
            operational_calendar_helper = Guard.IsNotNull(the_operational_calendar_helper, "the_operational_calendar_helper");
        }

        private readonly OperationsCalendarHelper operational_calendar_helper;
    }
}