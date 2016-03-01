using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.Remove
{
    public interface IGetRemoveShiftOccurrenceRequest : ICommand<ShiftOccurrenceIdentity, Response<RemoveShiftOccurrenceRequest>>
    {
    }
}
