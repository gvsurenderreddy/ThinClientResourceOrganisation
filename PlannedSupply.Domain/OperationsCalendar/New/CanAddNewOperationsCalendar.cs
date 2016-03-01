using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.New.Create;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.New
{
    public class CanAddNewOperationsCalendar
                        :   PermissionGranted<NewOperationsCalendarRequest>,
                            ICanAddNewOperationsCalendar {}
}