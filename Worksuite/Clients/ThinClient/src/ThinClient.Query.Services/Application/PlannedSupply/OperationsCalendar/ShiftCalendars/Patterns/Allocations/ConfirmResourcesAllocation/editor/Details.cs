using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ResourceAllocation.AllocateEmployeeToPattern;

namespace WTS.WorkSuite.ThinClient.Query.Application.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.ConfirmResourcesAllocation.editor
{
    public class AllocationRequestDetails : AllocateEmployeeToPatternRequest
    {
        public string name { get; set; }
        public string employee_reference { get; set; }
        public string location { get; set; }
        public string job_title { get; set; }
    }
}
