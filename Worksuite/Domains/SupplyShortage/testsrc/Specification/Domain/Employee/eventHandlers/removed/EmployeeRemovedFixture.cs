using System.Linq;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Persistence;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.HR.Employees.Events;
using WTS.WorkSuite.SupplyShortage.Employee.eventHandlers;
using WTS.WorkSuite.SupplyShortage.Employees;

namespace WTS.WorkSuite.SupplyShortage.Services.Domain.Employee.eventHandlers.removed
{
    public class EmployeeRemovedFixture
    {
        public EmployeeRemovedEvent create_remove_event_for_employee_id( int employee_id )
        {
            var removed_employee_event = new EmployeeRemovedEvent( ) { employee_id = employee_id };

            return removed_employee_event;
        }

        public int add_employee_to_repository( )
        {
            var new_employee = new EmployeeSupplyShortage { employee_id = ++current_employee_id };

            employee_supply_shortage_respository.add( new_employee );
            
            return current_employee_id;
        }

        public EmployeeRemovedFixture( )
        {
            event_handler = DependencyResolver.resolve<RemoveEmployeeSupplyShortageWhenEmployeeRemoved>( );
            unit_of_work = DependencyResolver.resolve<FakeUnitOfWork>( );
            employee_supply_shortage_respository = DependencyResolver.resolve<IEntityRepository<EmployeeSupplyShortage>>();
        }

        private readonly IEntityRepository<EmployeeSupplyShortage> employee_supply_shortage_respository;
        private int current_employee_id;

        public RemoveEmployeeSupplyShortageWhenEmployeeRemoved event_handler { get; private set; }
        public FakeUnitOfWork unit_of_work { get; private set; }
        public IQueryable<EmployeeSupplyShortage> repository { get { return employee_supply_shortage_respository.Entities; } }
    }
}
