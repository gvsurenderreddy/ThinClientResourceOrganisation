using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ResourceAllocation.AllocateEmployeeToPattern.get;
using WTS.WorkSuite.ThinClient.Query.Application.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.ConfirmResourcesAllocation.editor;
using WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.ConfirmAllocation.Setup;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.ConfirmAllocation.Fields
{
    public class GetSelectedAllocatableResourceFixture
    {
        public FindConfirmResourceAllocationEditorViewBuilder add_employee()
        {
            return helper.add();
        }

        public void execute()
        {
            result = get_allocation_request_details.execute(pattern_id);
        }

        public GetSelectedAllocatableResourceFixture(FindConfirmResourceAllocationEditorViewHelper helper
                                                    , IGetAllocationRequestDetails get_allocation_request_details)
        {
            this.get_allocation_request_details = Guard.IsNotNull(get_allocation_request_details,
                "get_allocation_request_details");
            this.helper = Guard.IsNotNull(helper, "helper");

            pattern_id = new GetAllocateEmployeePatternRequest
            {
                operations_calendar_id = 1,
                shift_calendar_id = 1,
                shift_calendar_pattern_id = 1,
                employee_id = 1,
            };

        }

        private readonly IGetAllocationRequestDetails get_allocation_request_details;
        private readonly FindConfirmResourceAllocationEditorViewHelper helper;
        private readonly GetAllocateEmployeePatternRequest pattern_id;
        public AllocationRequestDetails result;
    }
}
