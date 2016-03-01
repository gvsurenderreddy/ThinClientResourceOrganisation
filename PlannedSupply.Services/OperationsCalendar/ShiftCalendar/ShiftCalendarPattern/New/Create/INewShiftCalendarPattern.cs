using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.New.Create
{
    /// <summary>
    ///     Creates a shift calendar pattern and returns it's identity
    ///  Validation:
    ///     Pattern name is mandatory and must be unique within a shift calendar (case insensitive)
    /// </summary>
    public interface INewShiftCalendarPattern
                            : IResponseCommand<NewShiftCalendarPatternRequest,
                                                NewShiftCalendarPatternResponse
                                              > { }
}