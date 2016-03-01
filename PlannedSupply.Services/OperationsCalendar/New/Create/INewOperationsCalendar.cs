using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.New.Create
{
    /// <summary>
    ///     Creates an operations calendar and returns it's identity
    /// 
    ///  Validation:
    ///     Calendar name is mandatory and must be unique (case insensitive)
    /// </summary>
    public interface INewOperationsCalendar
                            : IResponseCommand< NewOperationsCalendarRequest,
                                                NewOperationsCalendarResponse
                                              > {}
}