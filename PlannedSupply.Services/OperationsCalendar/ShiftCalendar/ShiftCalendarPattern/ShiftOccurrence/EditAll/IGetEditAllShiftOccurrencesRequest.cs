using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.EditAll
{
    public interface IGetEditAllShiftOccurrencesRequest
                        : ICommand<ShiftOccurrenceIdentity,
                                   Response<EditAllShiftOccurrencesRequest>
                                  > { }
}