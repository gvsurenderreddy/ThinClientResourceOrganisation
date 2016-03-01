using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.Edit.GetUpdateRequest
{
    /// <summary>
    ///     Gets an update request for a shift calendar details.
    /// </summary>
    public interface IGetUpdateShiftCalendarRequest
                            : ICommand<ShiftCalendarIdentity,
                                        Response<UpdateShiftCalendarRequest>
                                      > { }
}