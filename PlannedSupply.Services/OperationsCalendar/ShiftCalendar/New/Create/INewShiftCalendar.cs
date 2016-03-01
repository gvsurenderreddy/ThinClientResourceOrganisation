using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.New.Create
{
    /// <summary>
    ///     Creates a shift calendar and returns it's identity
    /// 
    ///  Validation:
    ///     Calendar name is mandatory and must be unique (case insensitive)
    /// </summary>
    public interface INewShiftCalendar
                            : IResponseCommand< NewShiftCalendarRequest,
                                                NewShiftCalendarResponse
                                              > { }
}