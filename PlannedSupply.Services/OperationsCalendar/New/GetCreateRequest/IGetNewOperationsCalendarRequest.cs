using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.New.GetCreateRequest
{
    /// <summary>
    ///     Create an add operations calendar request and fills it out with 
    ///     any default values.
    /// 
    ///     Default values:
    ///     Currently there are no default values for any of the
    ///     add operations calendar request fields.
    /// </summary>
    public interface IGetNewOperationsCalendarRequest
                            : ICommand< NewOperationsCalendarRequest > {}
}