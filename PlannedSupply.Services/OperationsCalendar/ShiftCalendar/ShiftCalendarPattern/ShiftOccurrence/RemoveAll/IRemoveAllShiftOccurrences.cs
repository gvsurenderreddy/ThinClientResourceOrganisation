using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.RemoveAll
{
    public interface IRemoveAllShiftOccurrences
                               : ICommand<ShiftOccurrenceIdentity, RemoveAllShiftOccurrencesResponse> { }
}