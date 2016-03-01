using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.New.GetCreateRequest
{
    /// <summary>
    ///     Create and add shift calendar pattern request and fills it out with
    ///     any default values.
    ///
    ///     Default values:
    ///     Currently there are no default values for any of the
    ///     add shift calendar pattern request fields.
    /// </summary>
    public interface IGetNewShiftCalendarPatternRequest
                            : ICommand<ShiftCalendarPatternIdentity,
                                        NewShiftCalendarPatternRequest
                                      > { }
}