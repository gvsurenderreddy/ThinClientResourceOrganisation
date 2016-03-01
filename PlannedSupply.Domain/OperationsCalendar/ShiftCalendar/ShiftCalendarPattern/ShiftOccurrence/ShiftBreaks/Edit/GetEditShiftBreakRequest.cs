using System.Linq;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Duration;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.AggregateRoot;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.ShiftBreaks.Edit
{
    public class GetEditShiftBreakRequest : IGetEditShiftBreakRequest
    {
        public Response<EditShiftBreakRequest> execute(ShiftBreakIdentity request)
        {
            var shift_break = get_occurrence.execute(request)
                                                    .time_allocation
                                                    .TimeAllocationBreaks
                                                    .Single(br => br.id == request.shift_break_id);

            return new Response<EditShiftBreakRequest>()
            {
                result = new EditShiftBreakRequest()
                {
                    operations_calendar_id = request.operations_calendar_id,
                    shift_calendar_id = request.shift_calendar_id,
                    shift_calendar_pattern_id = request.shift_calendar_pattern_id,
                    shift_occurrence_id = request.shift_occurrence_id,
                    is_paid = shift_break.is_paid,
                    duration = shift_break.duration_in_seconds.to_duration_request(),
                    off_set = shift_break.offset_from_start_time_in_seconds.to_duration_request(),
                    shift_break_id = shift_break.id
                },
                messages = null,
                has_errors = false
            };
        }


        public GetEditShiftBreakRequest(GetOccurrence the_get_occurrence)
        {
            get_occurrence = Guard.IsNotNull(the_get_occurrence, "the_get_occurrence");
        }

        private readonly GetOccurrence get_occurrence;
    }
}
