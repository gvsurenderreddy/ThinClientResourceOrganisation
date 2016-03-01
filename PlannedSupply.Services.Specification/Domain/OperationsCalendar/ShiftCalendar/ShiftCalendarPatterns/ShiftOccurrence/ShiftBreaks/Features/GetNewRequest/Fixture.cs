using WorkSuite.Library.Service.Specification.Helpers.Request;
using WorkSuite.Library.Service.Specification.Helpers.Specifications.ForResponseCommands;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.ShiftBreaks.New;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.ShiftBreaks.Features.GetNewRequest
{
    public class GetNewShiftBreakRequestFixture : ResponseCommandFixture<ShiftOccurrenceIdentity,
                                                                        Response<NewShiftBreakRequest>, 
                                                                        IGetNewShiftBreakRequest>
    {

        public GetNewShiftBreakRequestFixture(IGetNewShiftBreakRequest the_command,IRequestHelper<ShiftOccurrenceIdentity> the_request_helper)
            : base(the_command, the_request_helper)
        {
        }
    }
}