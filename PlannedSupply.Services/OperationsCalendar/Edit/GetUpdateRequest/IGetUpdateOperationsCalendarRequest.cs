using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.Edit.GetUpdateRequest
{
    /// <summary>
    ///     Gets an update request for an operations calendar details.
    /// </summary>
    public interface IGetUpdateOperationsCalendarRequest
                                : ICommand< OperationsCalendarIdentity,
                                            Response< UpdateOperationsCalendarRequest >
                                          > {}
}