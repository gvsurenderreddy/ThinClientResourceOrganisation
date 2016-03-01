using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.GetOverRange
{
    public interface IGetOperationsCalendarAggregateOverRange
                            : IQuery<GetOperationsCalendarAggregateOverRangeRequest, Response<OperationsCalendarAggregateOverRange>> { }
}