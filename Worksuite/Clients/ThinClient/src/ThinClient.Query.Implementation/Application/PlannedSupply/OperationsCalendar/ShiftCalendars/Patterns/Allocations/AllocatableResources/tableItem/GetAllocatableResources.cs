using System.Collections.Generic;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ResourceAllocation.Queries.GetResourceAllocationsByShiftCalendar;

namespace WTS.WorkSuite.ThinClient.Query.Application.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.AllocatableResources.tableItem
{
    public class GetAllocatableResources : IGetAllocatableResources
    {
        public IEnumerable<EmployeeWithAllocationStatus> execute(ShiftCalendarPatternIdentity request)
        {
            var resource_allocation = get_resource_allocations.execute(request);

            var resource_merger_request = new MergeResourcesAndEmployeeRequest(resource_allocation.result
                                                                              , get_allocatable_resources_table_item.execute()
                                                                              , request);

            var resource_details = resource_merger.execute(resource_merger_request);




            return resource_details;
        }

        public GetAllocatableResources(IGetResourceAllocationsByShiftCalendar get_resource_allocations
                              , GetAllocatableResourcesTableItems get_allocatable_resources_table_item
                              , MergeResourceAndEmployee resource_merger)
        {
            this.get_allocatable_resources_table_item = Guard.IsNotNull(get_allocatable_resources_table_item, "get_employee_table_item");
            this.get_resource_allocations = Guard.IsNotNull(get_resource_allocations, "get_resource_allocations");
            this.resource_merger = Guard.IsNotNull(resource_merger, "resource_merger");
        }
        private readonly IGetResourceAllocationsByShiftCalendar get_resource_allocations;
        private readonly GetAllocatableResourcesTableItems get_allocatable_resources_table_item;
        private readonly MergeResourceAndEmployee resource_merger;
    }
}
