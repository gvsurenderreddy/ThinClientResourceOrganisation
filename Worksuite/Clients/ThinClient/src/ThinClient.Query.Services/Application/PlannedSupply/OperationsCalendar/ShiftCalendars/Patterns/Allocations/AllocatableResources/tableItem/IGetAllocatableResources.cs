using System.Collections.Generic;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern;

namespace WTS.WorkSuite.ThinClient.Query.Application.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.AllocatableResources.tableItem
{
    public interface IGetAllocatableResources : IQuery<ShiftCalendarPatternIdentity, IEnumerable<EmployeeWithAllocationStatus>>
    {
    }
}
