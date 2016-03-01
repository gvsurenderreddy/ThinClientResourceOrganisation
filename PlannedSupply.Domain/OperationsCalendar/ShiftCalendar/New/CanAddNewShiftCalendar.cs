using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.New.Create;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.New
{
    public class CanAddNewShiftCalendar
                    :   PermissionGranted<NewShiftCalendarRequest>,
                    ICanAddNewShiftCalendar { }
}