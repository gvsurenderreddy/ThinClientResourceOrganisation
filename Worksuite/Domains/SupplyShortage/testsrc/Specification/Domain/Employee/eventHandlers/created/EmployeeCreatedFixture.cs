using System.Linq;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Persistence;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.HR.Employees.Events;
using WTS.WorkSuite.SupplyShortage.Employee.eventHandlers;
using WTS.WorkSuite.SupplyShortage.Employees;

namespace WTS.WorkSuite.SupplyShortage.Services.Domain.Employee.eventHandlers.created
{
    public class EmployeeCreatedFixture
    {
        public EmployeeCreatedEvent create_event( )
        {
            return new EmployeeCreatedEvent
            {
                employee_id = ++new_event_id,
            };
        }

        public EmployeeCreatedFixture( )
        {
            employee_supply_shortage_respository = DependencyResolver.resolve<IEntityRepository<EmployeeSupplyShortage>>( );
            event_handler = DependencyResolver.resolve<CreateEmployeeSupplyShortageWhenEmployeeCreated>( );
            unit_of_work = DependencyResolver.resolve<FakeUnitOfWork>( );
        }

        private readonly IEntityRepository<EmployeeSupplyShortage> employee_supply_shortage_respository;
        private int new_event_id;

        public CreateEmployeeSupplyShortageWhenEmployeeCreated event_handler { get; private set; }
        public IQueryable<EmployeeSupplyShortage> repository { get { return employee_supply_shortage_respository.Entities ; } }
        public FakeUnitOfWork unit_of_work { get; private set; }

    }
}
