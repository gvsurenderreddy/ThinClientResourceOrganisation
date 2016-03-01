using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.EditAll
{
    public interface IEditAllShiftOccurrences
                        : IResponseCommand<EditAllShiftOccurrencesRequest,
                                           EditAllShiftOccurrencesResponse
                                          > { }
}