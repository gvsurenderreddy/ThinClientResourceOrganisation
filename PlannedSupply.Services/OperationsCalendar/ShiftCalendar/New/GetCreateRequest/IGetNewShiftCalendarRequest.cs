using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.New.GetCreateRequest
{
    /// <summary>
    ///     Create and add shift calendar request and fills it out with
    ///     any default values.
    ///
    ///     Default values:
    ///     Currently there are no default values for any of the
    ///     add shift calendar request fields.
    /// </summary>
    public interface IGetNewShiftCalendarRequest
                        : ICommand<ShiftCalendarIdentity,
                            NewShiftCalendarRequest> { }
}