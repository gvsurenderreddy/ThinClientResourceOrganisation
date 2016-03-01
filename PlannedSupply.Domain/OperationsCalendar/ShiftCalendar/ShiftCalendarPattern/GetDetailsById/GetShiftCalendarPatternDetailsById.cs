
using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.GetDetailsById
{
    public class GetShiftCalendarPatternDetailsById : IGetShiftCalendarPatternDetailsById
    {
        public GetShiftCalendarPatternDetailsByIdResponse execute(ShiftCalendarPatternIdentity request)
        {
            var operation_calendar =
                operations_calendar_repository.Entities.Single(oc => oc.id == request.operations_calendar_id);

            var shift_calendar = operation_calendar.ShiftCalendars.Single(sc => sc.id == request.shift_calendar_id);

            var shift_calendar_pattern =
                shift_calendar.ShiftCalendarPatterns.Single(cp => cp.id == request.shift_calendar_pattern_id);

            return new GetShiftCalendarPatternDetailsByIdResponse
            {
                has_errors = false,
                messages = null,
                result = new ShiftCalendarPatternDetails
                {
                    operations_calendar_id = operation_calendar.id,
                    shift_calendar_id = shift_calendar.id,
                    shift_calendar_pattern_id = shift_calendar_pattern.id,
                    shift_calendar_pattern_name = shift_calendar_pattern.name,
                    number_of_resources = shift_calendar_pattern.number_of_resources,
                    resource_allocation_summary = shift_calendar_pattern.ResourceAllocations.Count()
                }
            };
        }


        public GetShiftCalendarPatternDetailsById(IQueryRepository<OperationsCalendars.OperationalCalendar> the_operations_calendar_repository)
        {
            operations_calendar_repository = Guard.IsNotNull(the_operations_calendar_repository, "the_operations_calendar_repository");
        }

        private readonly IQueryRepository<OperationsCalendars.OperationalCalendar> operations_calendar_repository;
    }



}
