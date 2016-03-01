using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ResourceAllocation.AllocateEmployeeToPattern.get;

namespace WTS.WorkSuite.ThinClient.Query.Application.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.AllocatableResources.tableItem
{
    public class EmployeeWithAllocationStatus : GetAllocateEmployeePatternRequest
    {
        public string forename { get; set; }
        public string surname { get; set; }
        public string employee_reference { get; set; }
        public string location { get; set; }
        public string job_title { get; set; }
        public string status { get; set; }

        
    }
}
