using System.Collections.Generic;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern;
using WTS.WorkSuite.ThinClient.Query.Application.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.AllocatableResources.tableItem;
using WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.AllocatableResources.Setup;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.AllocatableResources.Fields
{
    public class GetAllocatableResourceFixture
    {

        public FindAllocatableResourcesTableViewBuilder add_employee()
        {
            return helper.add();
        }

        public ResourceAllocationDetailsBuilder add_resources()
        {
            var resources_allocation_builder = new ResourceAllocationDetailsBuilder();
            fack_get_resource_allocations._resources.Add(resources_allocation_builder.entity);
            return resources_allocation_builder;
        }

        public void execute()
        {
            result = get_allocatable_resources.execute(pattern_id);
        }


        public GetAllocatableResourceFixture(FakeGetResourceAllocationsByShiftCalendar get_resource_allocations
                                             , IGetAllocatableResources get_allocatable_resources
                                             , FindAllocatableResourcesTableViewHelper helper )
        {
            this.fack_get_resource_allocations = Guard.IsNotNull(get_resource_allocations, "get_resource_allocations");
            this.helper = Guard.IsNotNull(helper, "helper");
            this.get_allocatable_resources = Guard.IsNotNull(get_allocatable_resources, "get_all_resources");

            pattern_id = new ShiftCalendarPatternIdentity
            {
                operations_calendar_id = 1,
                shift_calendar_id = 1,
                shift_calendar_pattern_id = 1
            };
        }
        private readonly FakeGetResourceAllocationsByShiftCalendar fack_get_resource_allocations;
        private readonly ShiftCalendarPatternIdentity pattern_id;
        private readonly IGetAllocatableResources get_allocatable_resources;
        private readonly FindAllocatableResourcesTableViewHelper helper;

        public IEnumerable<EmployeeWithAllocationStatus> result;
    }
}
