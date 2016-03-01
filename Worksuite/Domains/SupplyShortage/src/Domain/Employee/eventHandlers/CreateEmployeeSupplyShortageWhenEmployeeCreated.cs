using System;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.HR.HR.Employees.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.SupplyShortage.Employees;

namespace WTS.WorkSuite.SupplyShortage.Employee.eventHandlers
{
    public class CreateEmployeeSupplyShortageWhenEmployeeCreated : IEventSubscriber<EmployeeCreatedEvent>
    {
        public void handle( EmployeeCreatedEvent the_event_to_handle )
        {
            this
                .setup( the_event_to_handle )
                .create_employee_supply_shortage( )
                .commit( )
                ;
        }

        public CreateEmployeeSupplyShortageWhenEmployeeCreated setup( EmployeeCreatedEvent event_to_handle )
        {
            employee_supply_shortage = new EmployeeSupplyShortage { employee_id = event_to_handle.employee_id };

            return this;
        }

        public CreateEmployeeSupplyShortageWhenEmployeeCreated create_employee_supply_shortage( )
        {
            Guard.IsNotNull( employee_supply_shortage, "employee_supply_shortage" );

            employee_supply_shortage_repository.add( employee_supply_shortage );

            return this;
        }

        public CreateEmployeeSupplyShortageWhenEmployeeCreated commit( )
        {
            unit_of_work.Commit();

            return this;
        }

        public CreateEmployeeSupplyShortageWhenEmployeeCreated( IEntityRepository<EmployeeSupplyShortage> the_employee_supply_shortage_repository
                                                              , IUnitOfWork the_unit_of_work )
        {
            employee_supply_shortage_repository = Guard.IsNotNull( the_employee_supply_shortage_repository, "the_employee_supply_shortage_repository " );
            unit_of_work = Guard.IsNotNull( the_unit_of_work, "the_unit_of_work" );
        }

        private readonly IEntityRepository<EmployeeSupplyShortage> employee_supply_shortage_repository;
        private readonly IUnitOfWork unit_of_work;
        private EmployeeSupplyShortage employee_supply_shortage;
    }
}
