using System.Collections.Generic;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern;

namespace WTS.WorkSuite.ThinClient.Query.Application.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.AllocatedResources.listItem
{
    public interface IGetAllocatedResources : IQuery<ShiftCalendarPatternIdentity, IEnumerable<ShiftCalendarPatternResource>>
    {
    }
}
