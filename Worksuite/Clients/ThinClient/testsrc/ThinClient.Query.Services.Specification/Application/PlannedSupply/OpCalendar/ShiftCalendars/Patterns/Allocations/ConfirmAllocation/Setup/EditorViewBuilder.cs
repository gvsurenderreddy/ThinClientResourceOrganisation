using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WTS.WorkSuite.ThinClient.Query.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.ConfirmResourceAllocation;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.ConfirmAllocation.Setup
{
    public class FindConfirmResourceAllocationEditorViewBuilder : IEntityBuilder<ConfirmResourceAllocationEditorView>
    {
        public ConfirmResourceAllocationEditorView entity { get { return employee_table_view; } }

        public FindConfirmResourceAllocationEditorViewBuilder employee_id(int employee_id)
        {
            employee_table_view.employee_id = employee_id;
            return this;
        }
        public FindConfirmResourceAllocationEditorViewBuilder employee_reference(string employee_reference)
        {
            employee_table_view.employee_reference = employee_reference;
            return this;
        }

        public FindConfirmResourceAllocationEditorViewBuilder name(string name)
        {
            employee_table_view.name = name;
            return this;
        }

        public FindConfirmResourceAllocationEditorViewBuilder job_title(string job_title)
        {
            employee_table_view.job_title = job_title;
            return this;
        }

        public FindConfirmResourceAllocationEditorViewBuilder location(string location)
        {
            employee_table_view.location = location;
            return this;
        }
        public FindConfirmResourceAllocationEditorViewBuilder()
        {
            employee_table_view = new ConfirmResourceAllocationEditorView();
        }
        public ConfirmResourceAllocationEditorView employee_table_view;
    }
}
