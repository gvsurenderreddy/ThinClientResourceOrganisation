using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.New.Create;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.New
{
    public class CanAddNewShiftCalendarPattern
                        : PermissionGranted<NewShiftCalendarPatternRequest>,
                            ICanAddNewShiftCalendarPattern { }
}