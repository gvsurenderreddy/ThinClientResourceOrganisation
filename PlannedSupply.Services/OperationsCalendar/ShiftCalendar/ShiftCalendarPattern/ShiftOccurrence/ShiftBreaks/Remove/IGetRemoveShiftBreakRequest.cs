using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.ShiftBreaks.Remove
{
    public interface IGetRemoveShiftBreakRequest : ICommand<ShiftBreakIdentity, Response<RemoveShiftBreakRequest>>
    {
    }
}
