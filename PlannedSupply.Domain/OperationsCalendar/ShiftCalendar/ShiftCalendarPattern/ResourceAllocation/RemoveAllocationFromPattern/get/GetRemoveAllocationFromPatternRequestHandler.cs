
namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ResourceAllocation.RemoveAllocationFromPattern.get
{
    public class GetRemoveResourceAllocationFromPatternRequest : IGetRemoveResourceAllocationFromPatternRequestHandler
    {
        public GetRemoveResourceAllocationFromPatternResponse execute(ResourceAllocationIdentity request)
        {
            return new GetRemoveResourceAllocationFromPatternResponse
            {
                result = new RemoveResourceAllocationFromPatternRequest
                {
                    operations_calendar_id = request.operations_calendar_id,
                    shift_calendar_id = request.shift_calendar_id,
                    shift_calendar_pattern_id = request.shift_calendar_pattern_id,
                    resource_allocation_id = request.resource_allocation_id
                }
            };
        }
    }
}
