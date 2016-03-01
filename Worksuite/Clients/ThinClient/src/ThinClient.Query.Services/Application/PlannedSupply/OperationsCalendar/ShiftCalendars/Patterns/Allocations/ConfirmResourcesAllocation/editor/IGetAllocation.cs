using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ResourceAllocation.AllocateEmployeeToPattern.get;

namespace WTS.WorkSuite.ThinClient.Query.Application.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.ConfirmResourcesAllocation.editor
{
    public interface IGetAllocationRequestDetails : IQuery<GetAllocateEmployeePatternRequest, AllocationRequestDetails>
    {
    }
}
