using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.Edit
{
    public interface IGetEditSingleShiftOccurrenceRequest
                                        : ICommand < ShiftOccurrenceIdentity,
                                                     Response < EditSingleShiftOccurrenceRequest >> { }
}