using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.Edit.Update
{
    public interface IUpdateShiftCalendar
                            : IResponseCommand<UpdateShiftCalendarRequest,
                                                UpdateShiftCalendarResponse
                                              > { }
}