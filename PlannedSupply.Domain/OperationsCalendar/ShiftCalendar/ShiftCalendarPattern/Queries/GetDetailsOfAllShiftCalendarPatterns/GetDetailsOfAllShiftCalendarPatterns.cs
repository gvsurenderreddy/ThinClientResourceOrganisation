using System.Collections.Generic;
using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.Queries.GetDetailsOfAllShiftCalendarPatterns
{
    public class GetDetailsOfAllShiftCalendarPatterns
                        : IGetDetailsOfAllShiftCalendarPatterns
    {
        public Response<IEnumerable<ShiftCalendarPatternDetails>> execute(ShiftCalendarIdentity shift_calendar_identity)
        {
            var operational_calendar = _operations_calendar_query_repository
                                            .Entities
                                            .Single(oc => oc.id == shift_calendar_identity.operations_calendar_id)
                                            ;

            var shift_calendar = operational_calendar
                                    .ShiftCalendars
                                    .Single(sc => sc.id == shift_calendar_identity.shift_calendar_id)
                                    ;

            var all_shift_calendar_patterns = shift_calendar
                                                .ShiftCalendarPatterns
                                                .OrderBy(a => a.priority)
                                                .AsEnumerable()
                                                .Select(p => new ShiftCalendarPatternDetails
                                                                    {
                                                                        operations_calendar_id = operational_calendar.id,
                                                                        shift_calendar_id = shift_calendar.id,
                                                                        shift_calendar_pattern_id = p.id,
                                                                        shift_calendar_pattern_name = p.name,
                                                                        number_of_resources = p.number_of_resources,
                                                                        priority = p.priority,
                                                                        resource_allocation_summary = p.ResourceAllocations.Count()
                                                                    }
                                                       )
                                                ;

            var response = new GetAllShiftCalendarPatternDetailsResponse
                                    {
                                        messages = null,
                                        has_errors = false,
                                        result = all_shift_calendar_patterns
                                    };

            return response;
        }

        public GetDetailsOfAllShiftCalendarPatterns(IQueryRepository<PlannedSupply.OperationsCalendars.OperationalCalendar> the_operations_calendar_query_repository)
        {
            _operations_calendar_query_repository = Guard.IsNotNull(the_operations_calendar_query_repository,
                                                                        "the_operations_calendar_query_repository"
                                                                     );
        }

        private readonly IQueryRepository<PlannedSupply.OperationsCalendars.OperationalCalendar> _operations_calendar_query_repository;
    }
}