using System.Collections.Generic;
using WorkSuite.Library.Service.Specification.Helpers.Persistence;
using WTS.WorkSuite.HR.HR.Employees.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.ThinClient.Query.Application.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.AllocatableResources.eventHandlers;
using WTS.WorkSuite.ThinClient.Query.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.AllocatableResources;
using WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.AllocatableResources.Setup;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.AllocatableResources.Events.Remove
{
    public class EmployeeRmoveFixture
    {
        public EmployeeRemovedEvent simulat_event()
        {
            var the_id = ++new_event_id;
            var find_employee_table_view = employee_view_repository_view_helper.add().entity;
            find_employee_table_view.employee_id = the_id;
            find_employee_table_view.forename = "forname";
            find_employee_table_view.surname = "surname";
            find_employee_table_view.employee_reference = "ref";
            return new EmployeeRemovedEvent
            {
                employee_id = the_id,
            };
        }

        public IEnumerable<AllocatableResourcesTableView> all_employee_views { get { return employee_view_repository_view_helper.entities; } }

        public bool changes_were_commited()
        {
            return fake_unit_of_work.commit_was_called;
        }

        public EmployeeRmoveFixture( RemoveAllocatableResourcesTableItemWhenEmployeeRemoved event_handler
                                   , FindAllocatableResourcesTableViewHelper employee_view_repository_view_helper
                                   , FakeUnitOfWork unit_of_work)
        {
            this.employee_view_repository_view_helper = Guard.IsNotNull(employee_view_repository_view_helper,
                                                                       "employee_view_repository_view_helper");
            this.event_handler = Guard.IsNotNull(event_handler, "event_handler");
            this.fake_unit_of_work = Guard.IsNotNull(unit_of_work, "unit_of_work");
        }
        private readonly FindAllocatableResourcesTableViewHelper employee_view_repository_view_helper;
        private readonly FakeUnitOfWork fake_unit_of_work;
        public RemoveAllocatableResourcesTableItemWhenEmployeeRemoved event_handler { get; private set; }

        private int new_event_id = 0;
    }
}
