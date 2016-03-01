using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.DefaultValues;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.AggregateRoot;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.ShiftBreaks.ApplyFromTemplate
{
    public class GetApplyShiftBreaksFromBreakTemplateRequest : IGetApplyShiftBreaksFromBreakTemplateRequest
    {

        public Response<ApplyShiftBreaksFromBreakTemplateRequest> execute(ShiftOccurrenceIdentity request)
        {
            var shift_occurrence = get_occurrence.execute(request);

            return new Response<ApplyShiftBreaksFromBreakTemplateRequest>()
            {
                result = new ApplyShiftBreaksFromBreakTemplateRequest()
                {
                    operations_calendar_id = request.operations_calendar_id,
                    shift_calendar_id = request.shift_calendar_id,
                    shift_calendar_pattern_id = request.shift_calendar_pattern_id,
                    shift_occurrence_id = shift_occurrence.id,
                    break_template_id = Null.Id
                },
                messages = null,
                has_errors = false
            };
        }


        public GetApplyShiftBreaksFromBreakTemplateRequest(GetOccurrence the_get_occurrence)
        {
            get_occurrence = Guard.IsNotNull(the_get_occurrence, "the_get_occurrence");
        }

        private readonly GetOccurrence get_occurrence;
    }
}