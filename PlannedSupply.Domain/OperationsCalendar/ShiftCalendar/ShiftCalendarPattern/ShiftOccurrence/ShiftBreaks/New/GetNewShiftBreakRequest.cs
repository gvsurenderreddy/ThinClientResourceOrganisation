using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Duration;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.AggregateRoot;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.ShiftBreaks.New
{
    public class GetNewShiftBreakRequest : IGetNewShiftBreakRequest
    {
        public Response<NewShiftBreakRequest> execute(ShiftOccurrenceIdentity request)
        {
            var shift_occurrence = get_occurrence.execute(request);

            return new Response<NewShiftBreakRequest>()
            {
                result = new NewShiftBreakRequest()
                {
                    operations_calendar_id = request.operations_calendar_id,
                    shift_calendar_id = request.shift_calendar_id,
                    shift_calendar_pattern_id = request.shift_calendar_pattern_id,
                    shift_occurrence_id = shift_occurrence.id,
                    is_paid = false,
                    duration = new DurationRequest()
                    {
                        hours = string.Empty,
                        minutes = string.Empty
                    },
                    off_set = new DurationRequest()
                    {
                        hours = string.Empty,
                        minutes = string.Empty
                    }
                },
                messages = null,
                has_errors = false
            };
        }


        public GetNewShiftBreakRequest(GetOccurrence the_get_occurrence)
        {
            get_occurrence = Guard.IsNotNull(the_get_occurrence, "the_get_occurrence");
        }

        private readonly GetOccurrence get_occurrence;
    }
}
