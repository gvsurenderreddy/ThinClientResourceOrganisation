using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.Remove
{
    public interface IRemoveShiftCalendarPattern
                            : ICommand<ShiftCalendarPatternIdentity,
                                        RemoveShiftCalendarPatternResponse
                                      >
    {
    }
}