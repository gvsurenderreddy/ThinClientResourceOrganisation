using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WTS.WorkSuite.ThinClient.Query.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.AllocatedResources;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.AllocatedResources.Setup
{
    public class FindAllocatedResourcesListViewBuilder : IEntityBuilder<AllocatedResourcesListView>
    {
        public AllocatedResourcesListView entity { get { return employee_table_view; } }

        public FindAllocatedResourcesListViewBuilder employee_id(int employee_id)
        {
            employee_table_view.employee_id = employee_id;
            return this;
        }
        public FindAllocatedResourcesListViewBuilder employee_reference(string employee_reference)
        {
            employee_table_view.employee_reference = employee_reference;
            return this;
        }

        public FindAllocatedResourcesListViewBuilder name(string name)
        {
            employee_table_view.name = name;
            return this;
        }

        public FindAllocatedResourcesListViewBuilder job_title(string job_title)
        {
            employee_table_view.job_title = job_title;
            return this;
        }

        public FindAllocatedResourcesListViewBuilder location(string location)
        {
            employee_table_view.location = location;
            return this;
        }
        public FindAllocatedResourcesListViewBuilder()
        {
            employee_table_view = new AllocatedResourcesListView();
        }
        public AllocatedResourcesListView employee_table_view;
    }
}
