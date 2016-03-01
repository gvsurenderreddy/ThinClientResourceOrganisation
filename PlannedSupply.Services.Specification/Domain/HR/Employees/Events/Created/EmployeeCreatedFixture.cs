using System.Collections.Generic;
using System.Linq;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Persistence;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR.Employees;
using WTS.WorkSuite.HR.HR.Employees.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.HR.Employee;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.HR.Employees.Events.Created
{
    public class EmployeeCreatedFixture
    {

        public EmployeeCreatedEvent create_event()
        {
            return new EmployeeCreatedEvent
            {
                employee_id = ++new_event_id,
            };
        }


        /// <summary>
        ///     all the employee trails
        /// </summary>
        public IEnumerable<EmployeePlannedSupply> all_employee_planned_supply { get { return employee_plannedsupply.Entities; } }

        /// <summary>
        ///     event handler that is being tested
        /// </summary>
        public CreateEmployeePlannedSupplyWhenEmployeeCreated event_handler { get; private set; }
        
        public bool changes_were_commited()
        {
            return unit_of_work.commit_was_called;
        }


        public Maybe<EmployeePlannedSupply> get_employee_for
                                        (EmployeeIdentity created_event)
        {
            var employee_trail = all_employee_planned_supply
                                .SingleOrDefault(at => at.employee_id == created_event.employee_id)
                                ;

            return employee_trail != null
                    ? new Just<EmployeePlannedSupply>(employee_trail) as Maybe<EmployeePlannedSupply>
                    : new Nothing<EmployeePlannedSupply>()
                    ;
        }

        public EmployeeCreatedFixture()
        {
            employee_plannedsupply = DependencyResolver.resolve<IEntityRepository<EmployeePlannedSupply>>();
            event_handler = DependencyResolver.resolve<CreateEmployeePlannedSupplyWhenEmployeeCreated>();
            unit_of_work = DependencyResolver.resolve<FakeUnitOfWork>();
           
        }
        
        private readonly IEntityRepository<EmployeePlannedSupply> employee_plannedsupply;
        private readonly FakeUnitOfWork unit_of_work;
        private int new_event_id = 0;
    }
}
