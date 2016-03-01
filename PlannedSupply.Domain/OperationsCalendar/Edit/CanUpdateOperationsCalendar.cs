using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.Edit.Update;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.Edit
{
    public class CanUpdateOperationsCalendar
                        :   PermissionGranted< UpdateOperationsCalendarRequest >,
                            ICanUpdateOperationsCalendar {}
}