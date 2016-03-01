using System.Linq;

namespace WTS.WorkSuite.ThinClient.Query.Application.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.ConfirmResourcesAllocation.editor
{
    public class MergeWithEmployee
    {
        public AllocationRequestDetails execute(MergeWithEmployeeRequest the_request)
        {
            var query = the_request.resources_details
               .OrderBy(e => e.name)
               .AsEnumerable()
               .Select(er => new AllocationRequestDetails
               {
                   employee_id = er.employee_id,
                   name = er.name ,
                   employee_reference = er.employee_reference,
                   location = er.location,
                   job_title = er.job_title,
                   operations_calendar_id = the_request.allocation_request.operations_calendar_id,
                   shift_calendar_id = the_request.allocation_request.shift_calendar_id,
                   shift_calendar_pattern_id = the_request.allocation_request.shift_calendar_pattern_id
               })
               .SingleOrDefault(e => e.employee_id == the_request.allocation_request.employee_id);

            return query;
        }
    }
}
