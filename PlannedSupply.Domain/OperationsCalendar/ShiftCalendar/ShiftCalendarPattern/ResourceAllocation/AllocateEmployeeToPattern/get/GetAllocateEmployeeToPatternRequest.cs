using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendars;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ResourceAllocation.AllocateEmployeeToPattern.get
{
    public class GetAllocateEmployeeToPatternRequestHandler : IGetAllocateEmployeeToPatternRequestHandler
    {
        public GetAllocateEmployeePatternResponse execute(GetAllocateEmployeePatternRequest request)
        {
           OperationalCalendar operational_calendar = _operations_calendar_query_repository
                                                                                .Entities
                                                                                .Single(oc => oc.id == request.operations_calendar_id)
                                                                                ;

            ShiftCalendars.ShiftCalendar shift_calendar = operational_calendar
                                                                .ShiftCalendars
                                                                .Single(sc => sc.id == request.shift_calendar_id)
                                                                ;

            ShiftCalendarPatterns.ShiftCalendarPattern shift_calendar_pattern = shift_calendar
                                                                                    .ShiftCalendarPatterns
                                                                                    .Single(scp => scp.id == request.shift_calendar_pattern_id)
                                                                                    ;

            return new GetAllocateEmployeePatternResponse
            {
                result = new AllocateEmployeeToPatternRequest
                {
                    employee_id = request.employee_id,
                    operations_calendar_id = operational_calendar.id,
                    shift_calendar_id = shift_calendar.id,
                    shift_calendar_pattern_id = shift_calendar_pattern.id
                }

            };

            
        }


        public GetAllocateEmployeeToPatternRequestHandler(IQueryRepository<OperationalCalendar> the_operations_calendar_query_repository)
        {
            _operations_calendar_query_repository = Guard.IsNotNull(the_operations_calendar_query_repository,
                                                                        "the_operations_calendar_query_repository"
                                                                     );
        }

        private readonly IQueryRepository<OperationalCalendar> _operations_calendar_query_repository;
       
    }
}
