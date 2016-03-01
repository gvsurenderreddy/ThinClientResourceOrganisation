using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.Edit.Update;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.Edit
{
    public class CanUpdateShiftCalendarPattern
                        : PermissionGranted<UpdateShiftCalendarPatternRequest>,
                            ICanUpdateShiftCalendarPattern { }
}