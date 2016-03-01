using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ResourceAllocation.AllocateEmployeeToPattern;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ResourceAllocation.AllocateEmployeeToPattern.get;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.ConfirmAllocation.Fields
{
    public class FakeGetAllocateEmployeeToPatternRequest : IGetAllocateEmployeeToPatternRequestHandler
    {
        public GetAllocateEmployeePatternResponse execute(
            GetAllocateEmployeePatternRequest request)
        {
            return new GetAllocateEmployeePatternResponse
            {
                result = new AllocateEmployeeToPatternRequest
                {
                    employee_id = 1,
                    operations_calendar_id = 1,
                    shift_calendar_id = 1,
                    shift_calendar_pattern_id = 1
                }
            };

        }
    }
}
