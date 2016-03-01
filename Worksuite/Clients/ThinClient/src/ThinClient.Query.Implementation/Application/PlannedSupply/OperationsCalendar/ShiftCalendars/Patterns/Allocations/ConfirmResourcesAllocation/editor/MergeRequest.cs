using System.Collections.Generic;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ResourceAllocation.AllocateEmployeeToPattern;

namespace WTS.WorkSuite.ThinClient.Query.Application.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.ConfirmResourcesAllocation.editor
{
    public class MergeWithEmployeeRequest
    {
        public MergeWithEmployeeRequest(AllocateEmployeeToPatternRequest allocation_request
                                       , IEnumerable<AllocationRequestDetailsEditorItem> resources_details
                                       )
        {
            this.resources_details = Guard.IsNotNull(resources_details,"resources_details");
            this.allocation_request = Guard.IsNotNull(allocation_request, "allocation_request");
        }

        public IEnumerable<AllocationRequestDetailsEditorItem> resources_details;
        public AllocateEmployeeToPatternRequest allocation_request;
    }
}
