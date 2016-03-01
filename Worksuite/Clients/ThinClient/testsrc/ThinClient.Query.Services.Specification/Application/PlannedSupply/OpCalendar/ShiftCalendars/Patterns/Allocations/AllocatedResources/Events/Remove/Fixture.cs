using System.Collections.Generic;
using WorkSuite.Library.Service.Specification.Helpers.Persistence;
using WTS.WorkSuite.HR.HR.Employees.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.ThinClient.Query.Application.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.AllocatedResources.eventHandlers;
using WTS.WorkSuite.ThinClient.Query.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.AllocatedResources;
using WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.AllocatedResources.Setup;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.AllocatedResources.Events.Remove
{
    public class EmployeeRmoveFixture
    {
        public EmployeeRemovedEvent simulat_event()
        {
            var the_id = ++new_event_id;
            var find_employee_table_view = employee_view_repository_view_helper.add().entity;
            find_employee_table_view.employee_id = the_id;
            find_employee_table_view.name = "Full Name";
            find_employee_table_view.employee_reference = "ref";
            return new EmployeeRemovedEvent
            {
                employee_id = the_id,
            };
        }

        public IEnumerable<AllocatedResourcesListView> all_employee_views { get { return employee_view_repository_view_helper.entities; } }

        public bool changes_were_commited()
        {
            return fake_unit_of_work.commit_was_called;
        }

        public EmployeeRmoveFixture(RemoveAllocatedResourcesListViewWhenEmployeeRemoved event_handler
                                   , FindAllocatedResourcesListViewHelper employee_view_repository_view_helper
                                   , FakeUnitOfWork fake_unit_of_work)
        {
            this.employee_view_repository_view_helper = Guard.IsNotNull(employee_view_repository_view_helper,
                                                                       "employee_view_repository_view_helper");
            this.event_handler = Guard.IsNotNull(event_handler, "event_handler");
            this.fake_unit_of_work = Guard.IsNotNull(fake_unit_of_work, "fake_unit_of_work");
        }
        private readonly FindAllocatedResourcesListViewHelper employee_view_repository_view_helper;
        private readonly FakeUnitOfWork fake_unit_of_work;
        public RemoveAllocatedResourcesListViewWhenEmployeeRemoved event_handler { get; private set; }

        private int new_event_id = 0;
    }
}
