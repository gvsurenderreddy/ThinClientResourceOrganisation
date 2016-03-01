using WorkSuite.Library.Persistence;

namespace WTS.WorkSuite.ThinClient.Query.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.AllocatedResources
{
    public class AllocatedResourcesListView : BaseEntity<int>
    {
        public virtual int employee_id { get; set; }
        public virtual string name { get; set; }
        public virtual int job_title_id { get; set; }
        public virtual string job_title { get; set; }
        public virtual string employee_reference { get; set; }
        public virtual int location_id { get; set; }
        public virtual string location { get; set; }
    }
}
