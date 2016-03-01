using System.Collections.Generic;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern;
using WTS.WorkSuite.ThinClient.Query.Application.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.AllocatedResources.listItem;
using WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.AllocatableResources.Setup;
using WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.AllocatedResources.Setup;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.AllocatedResources.Fields
{
    public class AllocatedResourcesListViewFixture
    {
        public FindAllocatedResourcesListViewBuilder add_employee()
        {
            return helper.add();
        }

        public ResourceAllocationDetailsBuilder add_resource()
        {
            var allocated_resources_details_builder = new ResourceAllocationDetailsBuilder();
            FakeAllocatedResourcesByGetShiftCalendarPattern.allocated_resources.Add(allocated_resources_details_builder.entity);
            return allocated_resources_details_builder;
        }

        public void execute()
        {
            result = get_allocated_resources_query.execute(pattern_id);
        }

        public AllocatedResourcesListViewFixture(IGetAllocatedResources get_allocated_resources_query
                                                , FindAllocatedResourcesListViewHelper helper)
        {
            this.get_allocated_resources_query = Guard.IsNotNull(get_allocated_resources_query,"get_allocated_resources_query");
            this.helper = Guard.IsNotNull(helper, "helper");
            pattern_id = new ShiftCalendarPatternIdentity
            {
                operations_calendar_id = 0,
                shift_calendar_id = 0,
                shift_calendar_pattern_id =0
            };
        }

        private readonly ShiftCalendarPatternIdentity pattern_id;
        public IEnumerable<ShiftCalendarPatternResource> result;
        public IGetAllocatedResources get_allocated_resources_query;
        private readonly FindAllocatedResourcesListViewHelper helper;
    }
}
