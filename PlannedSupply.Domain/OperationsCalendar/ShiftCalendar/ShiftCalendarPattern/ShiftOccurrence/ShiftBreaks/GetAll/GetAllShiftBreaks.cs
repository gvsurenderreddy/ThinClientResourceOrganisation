using System.Linq;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Duration;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.AggregateRoot;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.ShiftBreaks.GetAll
{
    public class GetAllShiftBreaks : IGetAllShiftBreaks
    {
        public GetAllShiftBreaksResponse execute(ShiftOccurrenceIdentity request)
        {
            var shift_occurrence = get_occurrence.execute(request);

            var time_allocation = shift_occurrence.time_allocation;

            var shift_breaks = time_allocation.TimeAllocationBreaks
                                                .OrderBy(sb => sb.offset_from_start_time_in_seconds)
                                                .ToList();

            var transformed_breaks = shift_breaks.Select(sb => new ShiftBreakDetails
            {
                offset_from_start_time = sb.offset_from_start_time_in_seconds.to_duration_request(),
                shift_break_id = sb.id,
                duration = sb.duration_in_seconds.to_duration_request(),
                is_paid = sb.is_paid,
                position = shift_breaks.IndexOf(sb) + 1,
                operations_calendar_id = request.operations_calendar_id,
                shift_calendar_id = request.shift_calendar_id,
                shift_calendar_pattern_id = request.shift_calendar_pattern_id,
                shift_occurrence_id = request.shift_occurrence_id
            });

            return new GetAllShiftBreaksResponse()
            {
                result = transformed_breaks,
                has_errors = false,
                messages = null
            };
        }


        public GetAllShiftBreaks(GetOccurrence the_get_occurrence)
        {
            get_occurrence = Guard.IsNotNull(the_get_occurrence, "the_get_occurrence");
        }

        private readonly GetOccurrence get_occurrence;
    }
}
