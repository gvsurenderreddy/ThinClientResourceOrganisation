using System.Collections.Generic;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ResourceAllocation;

namespace WTS.WorkSuite.ThinClient.Query.Application.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.AllocatableResources.tableItem
{
    public class MergeResourcesAndEmployeeRequest
    {
        public MergeResourcesAndEmployeeRequest(IEnumerable<ResourceAllocationDetails> resources_to_display
                                               , IEnumerable<GetAllocatableResourcesDetailsTableItem> resources_details
                                               , ShiftCalendarPatternIdentity pattern_identity)
        {
            this.resources_to_display = Guard.IsNotNull(resources_to_display, "resources_to_display");
            this.resources_details = Guard.IsNotNull(resources_details, "resources_details");
            this.pattern_identity = Guard.IsNotNull(pattern_identity, "pattern_identity");

        }
        public IEnumerable<ResourceAllocationDetails> resources_to_display { get; private set; }
        public IEnumerable<GetAllocatableResourcesDetailsTableItem> resources_details { get; private set; }
        public ShiftCalendarPatternIdentity pattern_identity { get; private set; }
    }
}
