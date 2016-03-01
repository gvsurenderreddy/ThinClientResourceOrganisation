using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WTS.WorkSuite.ThinClient.Query.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.AllocatableResources;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.AllocatableResources.Setup
{
    public class FindAllocatableResourcesTableViewBuilder : IEntityBuilder<AllocatableResourcesTableView>
    {
        public AllocatableResourcesTableView entity {get { return employee_table_view; }}

        public FindAllocatableResourcesTableViewBuilder employee_id(int employee_id)
        {
            employee_table_view.employee_id = employee_id;
            return this;
        }
        public FindAllocatableResourcesTableViewBuilder employee_reference(string employee_reference)
        {
            employee_table_view.employee_reference = employee_reference;
            return this;
        }

        public FindAllocatableResourcesTableViewBuilder forname(string forname)
        {
            employee_table_view.forename = forname;
            return this;
        }

        public FindAllocatableResourcesTableViewBuilder surname(string surname)
        {
            employee_table_view.surname = surname;
            return this;
        }

        public FindAllocatableResourcesTableViewBuilder job_title(string job_title)
        {
            employee_table_view.job_title = job_title;
            return this;
        }

        public FindAllocatableResourcesTableViewBuilder location(string location)
        {
            employee_table_view.location = location;
            return this;
        }
        public FindAllocatableResourcesTableViewBuilder()
        {
            employee_table_view=new AllocatableResourcesTableView();
        }
        public AllocatableResourcesTableView employee_table_view;
    }
}
