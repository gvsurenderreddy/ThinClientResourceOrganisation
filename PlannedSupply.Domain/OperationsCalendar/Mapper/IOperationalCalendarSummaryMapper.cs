using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.Mapper
{
    public interface IOperationalCalendarSummaryMapper
                            : IMapper<OperationsCalendarDetails,
                                        OperationsCalendars.OperationalCalendar
                                     > { }
}