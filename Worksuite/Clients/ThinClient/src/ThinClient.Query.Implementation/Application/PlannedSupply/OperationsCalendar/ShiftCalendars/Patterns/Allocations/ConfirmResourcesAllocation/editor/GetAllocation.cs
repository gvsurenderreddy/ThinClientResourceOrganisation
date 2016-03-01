using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ResourceAllocation.AllocateEmployeeToPattern.get;

namespace WTS.WorkSuite.ThinClient.Query.Application.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.ConfirmResourcesAllocation.editor
{
    public class GetAllocationRequestDetails : IGetAllocationRequestDetails
    {
        public AllocationRequestDetails execute(GetAllocateEmployeePatternRequest request)
        {
            var allocate_employee_to_pattern_request = get_allocate_employee_to_pattern_request.execute(request);

            var merge_request = new MergeWithEmployeeRequest(allocate_employee_to_pattern_request.result
                                                            , get_allocation_request_details_list_report.execute()
                                                             );

            return resource_merger.execute(merge_request);
        }


        public GetAllocationRequestDetails(IGetAllocateEmployeeToPatternRequestHandler get_allocate_employee_to_pattern_request
                                           , GetAllocationRequestDetailsEditorItemsReport get_allocation_request_details_list_report
                                           , MergeWithEmployee resource_merger)
        {
            this.get_allocate_employee_to_pattern_request = Guard.IsNotNull(get_allocate_employee_to_pattern_request,
                "get_allocate_employee_to_pattern_request");
            this.get_allocation_request_details_list_report = Guard.IsNotNull(
                get_allocation_request_details_list_report, "get_allocation_request_details_list_report");
            this.resource_merger = Guard.IsNotNull(resource_merger, "resource_merger");
        }
        private readonly IGetAllocateEmployeeToPatternRequestHandler get_allocate_employee_to_pattern_request;
        private readonly GetAllocationRequestDetailsEditorItemsReport get_allocation_request_details_list_report;
        private readonly MergeWithEmployee resource_merger;
        
    }
}
