using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ResourceAllocation;

namespace WTS.WorkSuite.ThinClient.Query.Application.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.AllocatedResources.listItem
{
    public class ShiftCalendarPatternResource : ResourceAllocationIdentity
    {
        public virtual string resource_label { get; set; }
        public virtual string name { get; set; }
        public virtual string employee_reference { get; set; }
        public virtual string job_title { get; set; }
        public virtual string location { get; set; }
    }
}
