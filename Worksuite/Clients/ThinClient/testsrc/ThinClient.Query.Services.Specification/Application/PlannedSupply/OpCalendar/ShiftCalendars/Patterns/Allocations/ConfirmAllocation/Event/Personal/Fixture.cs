using System.Collections.Generic;
using WorkSuite.Library.Service.Specification.Helpers.Persistence;
using WTS.WorkSuite.HR.HR.Employees.EmployeePersonalDetails.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.ThinClient.Query.Application.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.ConfirmResourcesAllocation.eventHandlers;
using WTS.WorkSuite.ThinClient.Query.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.ConfirmResourceAllocation;
using WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.ConfirmAllocation.Setup;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.ConfirmAllocation.Event.Personal
{
    public class EmployeePersonalDetailsUpdatedEventFixture
    {
        public EmployeePersonalDetailsUpdatedEvent simulate_event()
        {
            var the_id =++ new_event_id;
            const string name = "Name";
            const string family = "Family";
            var fake_employee_view = new ConfirmResourceAllocationEditorView
            {
                employee_id = the_id,
                name = name +" "+family,
                employee_reference = "reference"+the_id
            };
            var find_employee_table_view = employee_repository_helper.add().entity;
            find_employee_table_view.employee_id = fake_employee_view.employee_id;
            find_employee_table_view.name = fake_employee_view.name;
            
            return new EmployeePersonalDetailsUpdatedEvent
            {
                employee_id = fake_employee_view.employee_id,
                forename = name,
               surname = family
            };
        }
        public IEnumerable<ConfirmResourceAllocationEditorView> all_employee_views { get { return employee_repository_helper.entities; } }

        public bool changes_were_commited()
        {
            return fake_unit_of_work.commit_was_called;
        }

        public EmployeePersonalDetailsUpdatedEventFixture(UpdateConfirmResourceAllocationEditorViewWhenEmployeePersonalDetailsEventUpdated employee_personal_details_event_updated
                                                         , FindConfirmResourceAllocationEditorViewHelper employee_repository_helper
                                                         , FakeUnitOfWork fake_unit_of_work)
        {
            this.employee_personal_details_event_updated = Guard.IsNotNull(employee_personal_details_event_updated,
                "employee_personal_details_event_updated");
            this.employee_repository_helper = Guard.IsNotNull(employee_repository_helper, "employee_repository_helper");
            this.fake_unit_of_work = Guard.IsNotNull(fake_unit_of_work, "fake_unit_of_work");
        }

        private readonly FindConfirmResourceAllocationEditorViewHelper employee_repository_helper;
        private readonly FakeUnitOfWork fake_unit_of_work;

        public UpdateConfirmResourceAllocationEditorViewWhenEmployeePersonalDetailsEventUpdated employee_personal_details_event_updated { get; private set; }
        private int new_event_id = 0;
    }
}
