using System.Linq;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Duration;
using WTS.WorkSuite.Library.DomainTypes.Time;
using WTS.WorkSuite.Library.DomainTypes.Time.Clocks;
using WTS.WorkSuite.Library.DomainTypes.Time.Periods;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.AggregateRoot;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.ShiftBreaks;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.TimeAllocationOccurrence;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.GetShiftDetailsByStartDate
{
    public class GetShiftOccurrenceByStartDate : IGetShiftOccurrenceByStartDate
    {

        public Response<ShiftOccurrenceDetails> execute(TimeBlockIdentity request)
        {
            var shift_occurrence = get_shift_calendar_pattern.execute(request)
                                                            .TimeAllocationOccurrences
                                                            .Single(o => o.start_date.Date == request.start_date.Date);

            var start_hours = shift_occurrence.time_allocation.start_time_in_seconds_from_midnight.seconds_to_hours();
            var start_minutes = shift_occurrence.time_allocation.start_time_in_seconds_from_midnight.seconds_to_minutes();


            var time_allocation = shift_occurrence.time_allocation;

            var shift_breaks = time_allocation.TimeAllocationBreaks
                                                .OrderBy(sb => sb.offset_from_start_time_in_seconds)
                                                .ToList();

            return new Response<ShiftOccurrenceDetails>
            {
                result = new ShiftOccurrenceDetails
                {
                    operations_calendar_id = request.operations_calendar_id,
                    shift_calendar_id = request.shift_calendar_id,
                    shift_calendar_pattern_id = request.shift_calendar_pattern_id,
                    shift_occurrence_id = shift_occurrence.id,
                    shift_title = shift_occurrence.time_allocation.title,
                    time_period = new TimePeriod( new UtcTime(shift_occurrence.start_date.Year
                                              , shift_occurrence.start_date.Month
                                              , shift_occurrence.start_date.Day
                                              , start_hours, start_minutes, 0, 0),
                        shift_occurrence.time_allocation.duration_in_seconds),
                    breaks = shift_breaks.Select(sb => new ShiftBreakDetails
                    {
                        offset_from_start_time = sb.offset_from_start_time_in_seconds.to_duration_request(),
                        shift_break_id = sb.id,
                        duration = sb.duration_in_seconds.to_duration_request(),
                        is_paid = sb.is_paid,
                        position = shift_breaks.IndexOf(sb) + 1,
                        operations_calendar_id = request.operations_calendar_id,
                        shift_calendar_id = request.shift_calendar_id,
                        shift_calendar_pattern_id = request.shift_calendar_pattern_id,
                        shift_occurrence_id = shift_occurrence.id
                    })

                }
            };
        }

        public GetShiftOccurrenceByStartDate(GetShiftCalendarPattern the_get_shift_calendar_pattern)
        {
            get_shift_calendar_pattern = Guard.IsNotNull(the_get_shift_calendar_pattern, "the_get_shift_calendar_pattern");
        }

        private readonly GetShiftCalendarPattern get_shift_calendar_pattern;
    }
}