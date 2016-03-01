using WTS.WorkSuite.Service.HR.Employees;
using WTS.WorkSuite.Service.HR.Employees.EmployeeImage.New;

namespace WTS.WorkSuite.Domain.HR.Employees.EmployeeImage.New
{
    public class GetNewEmployeeImageRequest : IGetNewEmployeeImageRequest
    {
        public NewEmployeeImageRequest execute(EmployeeIdentity request)
        {
            return new NewEmployeeImageRequest
            {
                isDefault = true,
                employee_id = request.employee_id
            };
        }
    }
}
