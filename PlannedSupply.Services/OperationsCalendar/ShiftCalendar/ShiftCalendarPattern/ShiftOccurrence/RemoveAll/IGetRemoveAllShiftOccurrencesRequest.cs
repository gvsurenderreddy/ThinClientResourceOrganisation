using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.RemoveAll
{
    public interface IGetRemoveAllShiftOccurrencesRequest 
                                 : ICommand < ShiftOccurrenceIdentity, Response < RemoveAllShiftOccurrencesRequest >> { }
}