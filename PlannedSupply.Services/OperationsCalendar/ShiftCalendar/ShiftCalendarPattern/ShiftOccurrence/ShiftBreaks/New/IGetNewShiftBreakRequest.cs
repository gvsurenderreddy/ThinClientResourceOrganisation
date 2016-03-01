using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.ShiftBreaks.New
{
    public interface IGetNewShiftBreakRequest : ICommand<ShiftOccurrenceIdentity, Response<NewShiftBreakRequest>>
    {
    }
}
