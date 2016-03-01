using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.Edit.Update
{
    public interface IUpdateOperationsCalendar
                            : IResponseCommand< UpdateOperationsCalendarRequest,
                                                UpdateOperationsCalendarResponse
                                              > {}
}