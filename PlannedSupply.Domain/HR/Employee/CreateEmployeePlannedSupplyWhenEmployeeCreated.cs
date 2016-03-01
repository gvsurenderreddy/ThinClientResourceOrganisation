using WorkSuite.Library.Persistence;
using WTS.WorkSuite.HR.HR.Employees.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.Library.DomainTypes.Time.Clocks;

namespace WTS.WorkSuite.PlannedSupply.HR.Employee
{
    /// <summary>
    /// creates an Employee in the PlannedSupply Domain when Employee is created in the HR Domain.
    /// </summary>
    public class CreateEmployeePlannedSupplyWhenEmployeeCreated : IEventSubscriber<EmployeeCreatedEvent> 
    {
        public void handle(EmployeeCreatedEvent the_event_to_handle)
        {
            set_event(the_event_to_handle);
            create_employee_planning_record();
            commit();
        }

        public CreateEmployeePlannedSupplyWhenEmployeeCreated
                (IEntityRepository<EmployeePlannedSupply> the_employee_plannedsupply_repository
                , IUnitOfWork the_unit_of_work)
        {
            employee_plannedsupply_repository = Guard.IsNotNull(the_employee_plannedsupply_repository, "the_employee_plannedsupply_repository ");
            unit_of_work = Guard.IsNotNull(the_unit_of_work, "the_unit_of_work");
        }

        private void set_event (EmployeeCreatedEvent the_event_to_handle)
        {
            event_to_handle = Guard.IsNotNull(the_event_to_handle, "the_event_to_handle");
        }

        private void create_employee_planning_record()
        {
            Guard.IsNotNull(event_to_handle, "event_to_handle");
            employee_plannedsupply = new EmployeePlannedSupply
            {
                employee_id = event_to_handle.employee_id
            }
            ;
        }

        private void commit()
        {
            employee_plannedsupply_repository.add(employee_plannedsupply);
            unit_of_work.Commit();
        }

        private readonly IEntityRepository<EmployeePlannedSupply> employee_plannedsupply_repository;
        private readonly IUnitOfWork unit_of_work;
        private EmployeePlannedSupply employee_plannedsupply;
        private EmployeeCreatedEvent event_to_handle;
       
    }
}
