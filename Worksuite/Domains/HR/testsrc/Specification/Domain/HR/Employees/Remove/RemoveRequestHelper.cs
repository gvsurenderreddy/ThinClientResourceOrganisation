using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.Remove
{
    public class RemoveRequestHelper : IRequestHelper<EmployeeIdentity>
    {
        private readonly FakeEmployeeRepository repository;

        public RemoveRequestHelper(FakeEmployeeRepository the_repository)
        {
            repository = Guard.IsNotNull(the_repository, "the_employee_repository");
        }

        public EmployeeIdentity given_a_valid_request()
        {

            var employee = new Employee
            {
                forename = "John",
                surname = "Sculley"

            };

            repository.add(employee);

            return new EmployeeIdentity()
            {
                employee_id = employee.id
            };
        }
    }
}
