using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.Remove
{
    public interface IGetRemoveShiftCalendarRequest
                            : ICommand<ShiftCalendarIdentity, Response<RemoveShiftCalendarRequest>>
    {
    }
}