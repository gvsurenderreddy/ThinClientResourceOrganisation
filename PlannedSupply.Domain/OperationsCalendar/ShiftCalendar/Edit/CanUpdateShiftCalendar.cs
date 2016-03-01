using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.Edit.Update;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.Edit
{
    public class CanUpdateShiftCalendar
                        : PermissionGranted<UpdateShiftCalendarRequest>,
                            ICanUpdateShiftCalendar { }
}