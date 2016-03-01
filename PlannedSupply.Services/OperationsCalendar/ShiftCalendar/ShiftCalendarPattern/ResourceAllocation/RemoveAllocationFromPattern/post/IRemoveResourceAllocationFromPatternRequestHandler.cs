using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ResourceAllocation.RemoveAllocationFromPattern.post
{
    public interface IRemoveResourceAllocationFromPatternRequestHandler
        : IResponseCommand<RemoveResourceAllocationFromPatternRequest, RemoveResourceAllocationFromPatternResponse> { }
}
