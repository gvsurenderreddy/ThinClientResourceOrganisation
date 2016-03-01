using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees;

namespace WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees
{
    public class EmployeeIdentityHelper
    {
        public EmployeeIdentity get_identity()
        {
            return new EmployeeIdentity
            {
                employee_id = _employee.id
            };
        }

        public EmployeeIdentityHelper()
        {
            _employee_helper = DependencyResolver.resolve<EmployeeHelper>();

            _employee = _employee_helper.add().entity;
        }

        private Employee _employee;
        private EmployeeHelper _employee_helper;
    }
}