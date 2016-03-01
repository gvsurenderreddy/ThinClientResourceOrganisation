using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.HR.HR.Employees.EmployeeImage.Edit;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmployeeImage.Features.Edit
{
    public class UpdateRequestHelper : IRequestHelper<UpdateRequest>
    {
        public UpdateRequestHelper(EmployeeHelper the_employee_helper)
        {
            employee_helper = Guard.IsNotNull(the_employee_helper, "the_employee_helper");
        }

        public UpdateRequest given_a_valid_request()
        {
            //Create an Employee
            var employee = employee_helper.add().entity;

            return new UpdateRequest
            {
                image_id = 2,
                employee_id = employee.id,
            };
        }

        private readonly EmployeeHelper employee_helper;
    }
}