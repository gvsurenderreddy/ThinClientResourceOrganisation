using System.Collections.Generic;
using WorkSuite.Library.Service.Specification.Helpers.Persistence;
using WTS.WorkSuite.HR.HR.Employees.EmployeePersonalDetails.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.ThinClient.Query.Application.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.AllocatableResources.eventHandlers;
using WTS.WorkSuite.ThinClient.Query.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.AllocatableResources;
using WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.AllocatableResources.Setup;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.AllocatableResources.Events.Personal
{
    public class EmployeePersonalDetailsUpdatedEventFixture
    {
        public EmployeePersonalDetailsUpdatedEvent simulate_event()
        {
            var the_id =++ new_event_id;
            var fake_employee_view = new AllocatableResourcesTableView
            {
                employee_id = the_id,
                forename = "name" + the_id,
                surname = "surname"+the_id,
                job_title = "job" + the_id,
                location = "location" + the_id,
                employee_reference = "reference"+the_id
            };
            var find_employee_table_view = employee_repository_helper.add().entity;
            find_employee_table_view.employee_id = fake_employee_view.employee_id;
            find_employee_table_view.employee_reference = fake_employee_view.employee_reference;
            find_employee_table_view.forename = fake_employee_view.forename;
            find_employee_table_view.surname = fake_employee_view.surname;
            find_employee_table_view.job_title = fake_employee_view.job_title;
            find_employee_table_view.location = fake_employee_view.location;
            
            return new EmployeePersonalDetailsUpdatedEvent
            {
                employee_id = fake_employee_view.employee_id,
               forename = fake_employee_view.forename,
               surname = fake_employee_view.surname
            };
        }
        public IEnumerable<AllocatableResourcesTableView> all_employee_views { get { return employee_repository_helper.entities; } }

        public bool changes_were_commited()
        {
            return fake_unit_of_work.commit_was_called;
        }

        public EmployeePersonalDetailsUpdatedEventFixture( AddAllocatableResourcesTableItemWhenEmployeePersonalDetailsEventUpdated employee_personal_details_event_updated
                                                         , FindAllocatableResourcesTableViewHelper employee_repository_helper
                                                         , FakeUnitOfWork fake_unit_of_work)
        {
            this.employee_personal_details_event_updated = Guard.IsNotNull(employee_personal_details_event_updated,
                "employee_personal_details_event_updated");
            this.employee_repository_helper = Guard.IsNotNull(employee_repository_helper, "employee_repository_helper");
            this.fake_unit_of_work = Guard.IsNotNull(fake_unit_of_work, "fake_unit_of_work");
        }

        private readonly FindAllocatableResourcesTableViewHelper employee_repository_helper;
        private readonly FakeUnitOfWork fake_unit_of_work;

        public AddAllocatableResourcesTableItemWhenEmployeePersonalDetailsEventUpdated employee_personal_details_event_updated { get; private set; }
        private int new_event_id = 0;
    }
}
