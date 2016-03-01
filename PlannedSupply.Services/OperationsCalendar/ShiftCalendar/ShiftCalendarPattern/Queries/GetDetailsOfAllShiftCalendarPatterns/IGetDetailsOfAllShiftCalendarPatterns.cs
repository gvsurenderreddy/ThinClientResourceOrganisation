using System.Collections.Generic;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.Queries.GetDetailsOfAllShiftCalendarPatterns
{
    /// <summary>
    ///     Get details of all shift calendar patterns of a shift calendar in the system
    /// </summary>
    public interface IGetDetailsOfAllShiftCalendarPatterns
                            : IQuery<ShiftCalendarIdentity, Response<IEnumerable<ShiftCalendarPatternDetails>>> { }
}