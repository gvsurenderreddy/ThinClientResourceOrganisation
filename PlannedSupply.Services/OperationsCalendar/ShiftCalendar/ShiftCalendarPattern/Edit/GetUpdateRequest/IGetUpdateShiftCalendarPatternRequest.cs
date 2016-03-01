using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.Edit.GetUpdateRequest
{
    /// <summary>
    ///     Gets an update request for a shift calendar pattern details.
    /// </summary>
    public interface IGetUpdateShiftCalendarPatternRequest
                            : ICommand<ShiftCalendarPatternIdentity,
                                        Response<UpdateShiftCalendarPatternRequest>
                                      > { }
}