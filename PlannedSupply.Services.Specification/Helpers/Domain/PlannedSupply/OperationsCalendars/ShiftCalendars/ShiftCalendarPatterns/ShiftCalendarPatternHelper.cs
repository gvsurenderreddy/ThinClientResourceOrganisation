using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WTS.WorkSuite.PlannedSupply.ShiftCalendarPatterns;

namespace WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars.ShiftCalendarPatterns
{
    public class ShiftCalendarPatternHelper
                        : EnityHelper<ShiftCalendarPattern,
                                        int,
                                        ShiftCalendarPatternBuilder,
                                        FakeShiftCalendarPatternRepository
                                     > { }
}