using System.Collections.Generic;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ResourceAllocation;
using WTS.WorkSuite.ThinClient.Query.Application.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.AllocatedResources.listItem;

namespace WTS.WorkSuite.ThinClient.Query.Application.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.AllocatedResources.listReport
{
   public class MergeResourcesAndEmployeesRequest
    {
       public MergeResourcesAndEmployeesRequest( IEnumerable<ResourceAllocationDetails> resources_to_display
                                               , IEnumerable<AllocatedResourcesListItems> resources_details)
       {
           this.resources_to_display = Guard.IsNotNull(resources_to_display, "resources_to_display");
           this.resources_details = Guard.IsNotNull(resources_details, "resources_details");
       }
       public IEnumerable<ResourceAllocationDetails> resources_to_display { get; private set; }
       public IEnumerable<AllocatedResourcesListItems> resources_details { get; private set; }
    }
}
