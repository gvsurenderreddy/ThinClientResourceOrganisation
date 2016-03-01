using System.Collections.Generic;
using System.Linq;
using WTS.WorkSuite.ThinClient.Query.Application.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.AllocatedResources.listItem;

namespace WTS.WorkSuite.ThinClient.Query.Application.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.AllocatedResources.listReport
{
    public class ResourcesAndEmployeesMerge
    {
        public IEnumerable<ShiftCalendarPatternResource> execute(MergeResourcesAndEmployeesRequest the_request)
        {
            var query = the_request.resources_to_display
               .OrderByDescending(res => res.created_date)
               .Join(
                   the_request.resources_details,
                   res => res.employee_id,
                   emp => emp.employee_id,
                   (res, emp) => new { res, emp }
               )
               .Select((a, x) => new ShiftCalendarPatternResource
               {
                   name = a.emp.name,
                   employee_reference = a.emp.employee_reference,
                   job_title = a.emp.job_title,
                   location = a.emp.location,
                   resource_label = string.Format("Resource {0}", x + 1),
                   operations_calendar_id = a.res.operations_calendar_id,
                   shift_calendar_id = a.res.shift_calendar_id,
                   shift_calendar_pattern_id = a.res.shift_calendar_pattern_id,
                   resource_allocation_id = a.res.resource_allocation_id
               }
               );

            return query;
        }
    }
}
