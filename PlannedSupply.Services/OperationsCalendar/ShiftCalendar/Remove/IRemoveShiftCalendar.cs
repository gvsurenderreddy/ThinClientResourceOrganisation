using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.Remove
{
    public interface IRemoveShiftCalendar
                            : ICommand<ShiftCalendarIdentity,
                                        RemoveShiftCalendarResponse
                                      > { }
}