using WorkSuite.Library.Service.Specification.Helpers.Request;
using WorkSuite.Library.Service.Specification.Helpers.Specifications.ForResponseCommands;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.ShiftBreaks.ApplyFromTemplate;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.ShiftBreaks.Features.GetApplyFromTemplateRequest
{
    public class GetApplyShiftBreaksFromBreakTemplateRequestFixture : ResponseCommandFixture<ShiftOccurrenceIdentity, 
                                                                                            Response<ApplyShiftBreaksFromBreakTemplateRequest>, 
                                                                                            IGetApplyShiftBreaksFromBreakTemplateRequest>
    {

        public GetApplyShiftBreaksFromBreakTemplateRequestFixture(IGetApplyShiftBreaksFromBreakTemplateRequest the_command, 
                                                                    IRequestHelper<ShiftOccurrenceIdentity> the_request_helper)
            : base(the_command, the_request_helper)
        {
        }
    }
}