using System.Collections.Generic;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ResourceAllocation;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ResourceAllocation.Queries.GetResourceAllocationsByShiftCalendar;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.AllocatableResources.Fields
{
    public class FakeGetResourceAllocationsByShiftCalendar : IGetResourceAllocationsByShiftCalendar
    {
        public GetResourceAllocationsByShiftCalendarResponse execute(ShiftCalendarIdentity request)
        {
            return new GetResourceAllocationsByShiftCalendarResponse
            {
                has_errors = false,
                messages = null,
                result = _resources
            };
        }
       
        public List<ResourceAllocationDetails> _resources = new List<ResourceAllocationDetails>();
    }
}
