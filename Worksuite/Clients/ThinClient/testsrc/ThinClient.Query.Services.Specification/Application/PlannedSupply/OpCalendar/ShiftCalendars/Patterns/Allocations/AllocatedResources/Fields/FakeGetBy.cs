using System.Collections.Generic;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ResourceAllocation;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ResourceAllocation.Queries.GetResourceAllocationsByShiftCalendarPattern;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.AllocatedResources.Fields
{
    public class FakeAllocatedResourcesByGetShiftCalendarPattern : IGetResourceAllocationsByShiftCalendarPattern
    {
        public GetResourceAllocationsByShiftCalendarPatternResponse execute(ShiftCalendarPatternIdentity request)
        {
            return new GetResourceAllocationsByShiftCalendarPatternResponse
            {
                has_errors = false,
                messages = null,
                result = allocated_resources
            };
        }

        public static  List<ResourceAllocationDetails> allocated_resources=new List<ResourceAllocationDetails>();
    }
}
