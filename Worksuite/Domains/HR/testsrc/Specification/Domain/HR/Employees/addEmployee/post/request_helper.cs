using WTS.WorkSuite.HR.HR.Employees.addEmployee;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.addEmployee.post
{
    public class AddEmployee_request_helper
    {
        public AddEmployeeRequest given_a_valid_request()
        {
            return new AddEmployeeRequest
            {
                employee_reference = "ABC123",
                forename = "Fred",
                surname = "Alpha",
            };
        }
    }
}
