using System;
using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WorkSuite.Library.Service.Specification.Helpers.IdentityProvider;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.ResourceAllocations;
using WTS.WorkSuite.PlannedSupply.HR.Employee;

namespace WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars.ShiftCalendarPatterns.ResourceAllocations
{
    /// <summary>
    ///     Builder for the resource allocation
    /// </summary>
    public class ResourceAllocationBuilder
                        : IEntityBuilder<ResourceAllocation>
    {
        public ResourceAllocation entity
        {
            get { return _resource_allocation; }
        }

        public ResourceAllocationBuilder()
        {
            int the_resource_id = next_id();
            int the_employee_id = next_employee_id();
            DateTime the_created_date = DateTime.Now;

            _resource_allocation = new ResourceAllocation
            {
                id = the_resource_id,
                created_date = the_created_date,
                employee = new EmployeePlannedSupply { employee_id = the_employee_id }
            };
        }

        public ResourceAllocationBuilder employee(EmployeePlannedSupply the_employee)
        {
            var emp = Guard.IsNotNull(the_employee, "the_employee");
            _resource_allocation.employee = new EmployeePlannedSupply { employee_id = emp.employee_id };
            return this;
        }

        public ResourceAllocationBuilder created_date(DateTime the_created_date)
        {
            _resource_allocation.created_date = the_created_date;
            return this;
        }

        private int next_id()
        {
            var identity_provider = new IntIdentityProvider<ResourceAllocation>();
            return identity_provider.next();
        }

        private int next_employee_id()
        {
            var identity_provider = new IntIdentityProvider<EmployeePlannedSupply>();
            return identity_provider.next();
        }

        private readonly ResourceAllocation _resource_allocation;
    }
}
