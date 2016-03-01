using System;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.HR.HR.Employees.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.SupplyShortage.Employees;
using System.Linq;

namespace WTS.WorkSuite.SupplyShortage.Employee.eventHandlers
{
    public class RemoveEmployeeSupplyShortageWhenEmployeeRemoved : IEventSubscriber<EmployeeRemovedEvent>
    {
        public void handle( EmployeeRemovedEvent the_event_to_handle )
        {

            this
                .find_employee( the_event_to_handle )
                .remove_employee( )
                .commit( );

        }

        private RemoveEmployeeSupplyShortageWhenEmployeeRemoved find_employee( EmployeeRemovedEvent event_to_handle )
        {
            employee_to_remove = employee_supply_shortage_repository.Entities.Single(e => e.employee_id == event_to_handle.employee_id);
            
            return this;
        }

        private RemoveEmployeeSupplyShortageWhenEmployeeRemoved remove_employee( )
        {
            Guard.IsNotNull( employee_to_remove, "employee_to_remove" );

            employee_supply_shortage_repository.remove( employee_to_remove );

            return this;
        }

        private void commit( )
        {
            unit_of_work.Commit( );
        }

        public RemoveEmployeeSupplyShortageWhenEmployeeRemoved( IUnitOfWork unit_of_work, IEntityRepository<EmployeeSupplyShortage> employee_supply_shortage_repository )
        {
            this.employee_supply_shortage_repository = Guard.IsNotNull( employee_supply_shortage_repository, "employee_supply_shortage_repository" );
            this.unit_of_work = Guard.IsNotNull( unit_of_work, "unit_of_work" );
        }


        private readonly IEntityRepository<EmployeeSupplyShortage> employee_supply_shortage_repository;
        private readonly IUnitOfWork unit_of_work;

        private EmployeeSupplyShortage employee_to_remove;

    }
}
