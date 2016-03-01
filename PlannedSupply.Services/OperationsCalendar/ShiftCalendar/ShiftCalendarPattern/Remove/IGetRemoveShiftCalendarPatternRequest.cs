using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.Remove
{
    public interface IGetRemoveShiftCalendarPatternRequest
                            : ICommand<ShiftCalendarPatternIdentity,
                                        Response<RemoveShiftCalendarPatternRequest>
                                      >
    {
    }
}