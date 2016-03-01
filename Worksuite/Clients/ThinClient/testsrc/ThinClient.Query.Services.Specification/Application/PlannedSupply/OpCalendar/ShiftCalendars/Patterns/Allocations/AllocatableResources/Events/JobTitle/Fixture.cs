using System.Collections.Generic;
using WorkSuite.Library.Service.Specification.Helpers.Persistence;
using WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.ThinClient.Query.Application.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.AllocatableResources.eventHandlers;
using WTS.WorkSuite.ThinClient.Query.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.AllocatableResources;
using WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.AllocatableResources.Setup;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.AllocatableResources.Events.JobTitle
{
    public class JobTitleUpdatedFixture
    {
        public JobTitleUpdatedEvent simulate_event()
        {
            var the_id = ++new_event_id;
            var fake_employee_view = new AllocatableResourcesTableView()
            {
                employee_id = the_id,
                employee_reference = "ref" + the_id,
                forename = "name" + the_id,
                surname = "surname" + the_id,
                job_title = "job" + the_id,
                job_title_id = the_id,
                location = "location" + the_id,
                location_id = the_id,
                id = the_id
            };

            var find_employee_table_view = employee_repository_helper.add().entity;
            find_employee_table_view.employee_id = fake_employee_view.employee_id;
            find_employee_table_view.employee_reference = fake_employee_view.employee_reference;
            find_employee_table_view.forename = fake_employee_view.forename;
            find_employee_table_view.surname = fake_employee_view.surname;
            find_employee_table_view.job_title_id = fake_employee_view.job_title_id;
            find_employee_table_view.job_title = fake_employee_view.job_title;
            find_employee_table_view.location_id = fake_employee_view.location_id;
            find_employee_table_view.location = fake_employee_view.location;

            return new JobTitleUpdatedEvent
            {
                id = fake_employee_view.job_title_id,
                description = fake_employee_view.job_title + "updated"
            };
        }
        public IEnumerable<AllocatableResourcesTableView> all_employee_views { get { return employee_repository_helper.entities; } }

        public bool changes_were_commited()
        {
            return fake_unit_of_work.commit_was_called;
        }
        public JobTitleUpdatedFixture( UpdateAllocatableResourcesTableItemWhenEmployeeJobTitleUpdated event_handler
                                     , FindAllocatableResourcesTableViewHelper employee_repository_helper
                                     , FakeUnitOfWork fake_unit_of_work)
        {
            this.event_handler = Guard.IsNotNull(event_handler, "event_handler");
            this.employee_repository_helper = Guard.IsNotNull(employee_repository_helper, "employee_repository_helper");
            this.fake_unit_of_work = Guard.IsNotNull(fake_unit_of_work, "fake_unit_of_work");
        }
        public UpdateAllocatableResourcesTableItemWhenEmployeeJobTitleUpdated event_handler { get; private set; }
        private readonly FindAllocatableResourcesTableViewHelper employee_repository_helper;
        private readonly FakeUnitOfWork fake_unit_of_work;
        private int new_event_id = 0;
    }
}
