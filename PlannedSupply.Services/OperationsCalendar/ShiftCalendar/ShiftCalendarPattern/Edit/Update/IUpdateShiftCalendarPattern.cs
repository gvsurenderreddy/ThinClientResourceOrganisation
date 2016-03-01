using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.Edit.Update
{
    public interface IUpdateShiftCalendarPattern
                            : IResponseCommand<UpdateShiftCalendarPatternRequest,
                                                UpdateShiftCalendarPatternResponse
                                              > { }
}