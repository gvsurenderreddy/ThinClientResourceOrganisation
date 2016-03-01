using System.Collections.Generic;
using WorkSuite.Library.Service.Specification.Helpers.Persistence;
using WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.ThinClient.Query.Application.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.AllocatedResources.eventHandlers;
using WTS.WorkSuite.ThinClient.Query.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.AllocatedResources;
using WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.AllocatedResources.Setup;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.AllocatedResources.Events.JobTitle
{
    public class JobTitleUpdatedFixture
    {
        public JobTitleUpdatedEvent simulate_event()
        {
            var the_id = ++new_event_id;
            var fake_employee_view = new AllocatedResourcesListView
            {
                job_title = "job" + the_id,
                job_title_id = the_id,
                id = the_id
            };

            var find_employee_table_view = employee_repository_helper.add().entity;
            find_employee_table_view.job_title_id = fake_employee_view.job_title_id;
            find_employee_table_view.job_title = fake_employee_view.job_title;

            return new JobTitleUpdatedEvent
            {
                id = fake_employee_view.job_title_id,
                description = fake_employee_view.job_title + "updated"
            };
        }
        public IEnumerable<AllocatedResourcesListView> all_employee_views { get { return employee_repository_helper.entities; } }

        public bool changes_were_commited()
        {
            return fake_unit_of_work.commit_was_called;
        }
        public JobTitleUpdatedFixture(UpdateAllocatedResourcesListViewWhenEmployeeJobTitleUpdated event_handler
                                     , FindAllocatedResourcesListViewHelper employee_repository_helper
                                     , FakeUnitOfWork fake_unit_of_work)
        {
            this.event_handler = Guard.IsNotNull(event_handler, "event_handler");
            this.employee_repository_helper = Guard.IsNotNull(employee_repository_helper, "employee_repository_helper");
            this.fake_unit_of_work = Guard.IsNotNull(fake_unit_of_work, "fake_unit_of_work");
        }
        public UpdateAllocatedResourcesListViewWhenEmployeeJobTitleUpdated event_handler { get; private set; }
        private readonly FindAllocatedResourcesListViewHelper employee_repository_helper;
        private readonly FakeUnitOfWork fake_unit_of_work;
        private int new_event_id = 0;
    }
}
