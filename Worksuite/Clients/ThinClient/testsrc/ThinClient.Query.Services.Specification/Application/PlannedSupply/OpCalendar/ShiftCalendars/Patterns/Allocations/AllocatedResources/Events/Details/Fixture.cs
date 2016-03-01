using System.Collections.Generic;
using WorkSuite.Library.Service.Specification.Helpers.Persistence;
using WTS.WorkSuite.HR.HR.Employees.EmploymentDetails.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.ThinClient.Query.Application.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.AllocatedResources.eventHandlers;
using WTS.WorkSuite.ThinClient.Query.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.AllocatedResources;
using WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.AllocatedResources.Setup;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.AllocatedResources.Events.Details
{
    public class EmployeeEmploymentDetailsUpdatedFixture
    {
        public EmployeeEmploymentDetailsUpdatedEvent simulate_event()
        {
            var the_id = ++new_event_id;

            var fake_employee_view = new AllocatedResourcesListView
            {
                employee_id = the_id,
                employee_reference = "ref" + the_id,
                job_title_id =  the_id,
                job_title = "job" + the_id,
                location_id = the_id,
                location = "location" + the_id,
                id = the_id
            };

            var find_employee_table_view = employee_repository_helper.add().entity;
            find_employee_table_view.employee_id = fake_employee_view.employee_id;
            find_employee_table_view.employee_reference = fake_employee_view.employee_reference;
            find_employee_table_view.job_title_id = fake_employee_view.job_title_id;
            find_employee_table_view.job_title = fake_employee_view.job_title;
            find_employee_table_view.location_id = fake_employee_view.location_id;
            find_employee_table_view.location = fake_employee_view.location;
           

            return new EmployeeEmploymentDetailsUpdatedEvent
            {
                employee_id = fake_employee_view.employee_id,
                employee_reference = fake_employee_view.employee_reference + "updated",
                job_title_id = fake_employee_view.job_title_id,
                job_title_description = fake_employee_view.job_title + "updated",
                location_id = fake_employee_view.location_id,
                location_description = fake_employee_view.location + "updated",
            };
        }

        public IEnumerable<AllocatedResourcesListView> all_employee_views {get { return employee_repository_helper.entities; }}

        public bool changes_were_commited()
        {
           return  unit_of_work.commit_was_called;
        }

        public EmployeeEmploymentDetailsUpdatedFixture(UpdateAllocatedResourcesListViewWhenEmploymentDetailsUpdated event_handler
                                                      , FindAllocatedResourcesListViewHelper employee_repository_helper
                                                      , FakeUnitOfWork unit_of_work)
        {
            this.event_handler = Guard.IsNotNull(event_handler, "event_handler");
            this.unit_of_work = Guard.IsNotNull(unit_of_work, "unit_of_work");
            this.employee_repository_helper = Guard.IsNotNull(employee_repository_helper, "employee_repository_helper");
        }

        private readonly FindAllocatedResourcesListViewHelper employee_repository_helper;
        private readonly FakeUnitOfWork unit_of_work;
        public UpdateAllocatedResourcesListViewWhenEmploymentDetailsUpdated event_handler { get; private set; }

        private int new_event_id = 0;
    }
}
