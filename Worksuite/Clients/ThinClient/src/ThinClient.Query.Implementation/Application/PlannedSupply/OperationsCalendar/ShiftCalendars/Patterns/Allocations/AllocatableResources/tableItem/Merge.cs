using System.Collections.Generic;
using System.Linq;

namespace WTS.WorkSuite.ThinClient.Query.Application.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.AllocatableResources.tableItem
{
    public class MergeResourceAndEmployee
    {
        public IEnumerable<EmployeeWithAllocationStatus> execute(MergeResourcesAndEmployeeRequest the_request)
        {
            var query = the_request.resources_details
             .OrderBy(e => e.surname)
             .AsEnumerable()
             .GroupJoin(
                 the_request.resources_to_display,
                 e => e.employee_id,
                 r => r.employee_id,
                 (e, r) => new { employees = e, has_resources = r.Any() }
             )
             .Select(er => new EmployeeWithAllocationStatus
             {
                 employee_id = er.employees.employee_id,
                 employee_reference = er.employees.employee_reference,
                 forename = er.employees.forename,
                 surname = er.employees.surname,
                 job_title = er.employees.job_title,
                 location = er.employees.location,
                 status = er.has_resources ? "Allocated" : "Unallocated",
                 operations_calendar_id = the_request.pattern_identity.operations_calendar_id,
                 shift_calendar_id = the_request.pattern_identity.shift_calendar_id,
                 shift_calendar_pattern_id = the_request.pattern_identity.shift_calendar_pattern_id
             });

            return query;
        }
    }
}
