using System.Collections.Generic;
using WorkSuite.Library.Service.Specification.Helpers.Persistence;
using WTS.WorkSuite.HR.HR.Employees.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.ThinClient.Query.Application.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.AllocatableResources.eventHandlers;
using WTS.WorkSuite.ThinClient.Query.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.AllocatableResources;
using WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.AllocatableResources.Setup;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.Events.Created
{
   public class EmployeeCreateEventFixture
    {
       public EmployeeCreatedEvent simulat_event()
       {
           var next_id = ++new_event_id;

           return new EmployeeCreatedEvent
           {
               employee_id = next_id,
               employee_reference = "EB" + next_id,
               forename = "A forename" + next_id,
               surname = "surname"+next_id
           };
       }

       public IEnumerable<AllocatableResourcesTableView> all_employee_table_views { get { return employee_repository_helper.entities; } }

       public bool Changes_were_commited()
       {
           return fake_unit_of_work.commit_was_called;
       }

       public EmployeeCreateEventFixture( FindAllocatableResourcesTableViewHelper employee_repository_helper
                                        , FakeUnitOfWork fake_unit_of_work
                                        , AddAllocatableResourcesTableItemWhenEmployeeCreated create_event_when_employee_created)
       {
           this.employee_repository_helper = Guard.IsNotNull(employee_repository_helper, "employee_repository_helper");
           this.fake_unit_of_work = Guard.IsNotNull(fake_unit_of_work, "fake_unit_of_work");
           this.create_event_when_employee_created = Guard.IsNotNull(create_event_when_employee_created, "create_event_when_employee_created");
       }
       public AddAllocatableResourcesTableItemWhenEmployeeCreated  create_event_when_employee_created { get; private set; }
       private readonly FindAllocatableResourcesTableViewHelper employee_repository_helper;
       private readonly FakeUnitOfWork fake_unit_of_work;
       private int new_event_id = 0;
    }
}
