using System.Collections.Generic;
using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendars;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ResourceAllocation.Queries.GetResourceAllocationsByShiftCalendar
{
    public class GetResourceAllocationsByShiftCalendar : IGetResourceAllocationsByShiftCalendar
    {
        public GetResourceAllocationsByShiftCalendarResponse execute(ShiftCalendarIdentity shift_calendar_identity)
        {

            var all_resource_allocations = _operations_calendar_query_repository
                                        .Entities
                                        .Where(op => op.id == shift_calendar_identity.operations_calendar_id)
                                        .SelectMany(op => op.ShiftCalendars)
                                        .Where(sc => sc.id == shift_calendar_identity.shift_calendar_id)
                                        .SelectMany(sc => sc.ShiftCalendarPatterns)
                                        .SelectMany(scp => scp.ResourceAllocations
                                                .Select(ra => new ResourceAllocationDetails()
                                                {
                                                    operations_calendar_id = shift_calendar_identity.operations_calendar_id,
                                                    shift_calendar_id = shift_calendar_identity.shift_calendar_id,
                                                    shift_calendar_pattern_id = scp.id,
                                                    resource_allocation_id = ra.id,
                                                    employee_id = ra.employee.employee_id,
                                                    created_date = ra.created_date
                                                }));


            var response = new GetResourceAllocationsByShiftCalendarResponse
                                    {
                                        messages = null,
                                        has_errors = false,
                                        result = all_resource_allocations
                                    };

            return response;
        }

        public GetResourceAllocationsByShiftCalendar(IQueryRepository<OperationalCalendar> the_operations_calendar_query_repository)
        {
            _operations_calendar_query_repository = Guard.IsNotNull(the_operations_calendar_query_repository,
                                                                        "the_operations_calendar_query_repository"
                                                                     );
        }

        private readonly IQueryRepository<OperationalCalendar> _operations_calendar_query_repository;

    }
}
