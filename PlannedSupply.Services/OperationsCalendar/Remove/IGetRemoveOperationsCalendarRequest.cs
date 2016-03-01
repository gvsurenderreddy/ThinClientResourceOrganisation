using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.Remove
{
    public interface IGetRemoveOperationsCalendarRequest
                            : ICommand< OperationsCalendarIdentity, Response< RemoveOperationsCalendarRequest > > {}
}