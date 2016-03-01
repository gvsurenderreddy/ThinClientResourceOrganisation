using WTS.WorkSuite.Core.DomainIdentity;

namespace WTS.WorkSuite.HR.HR.Employees.Addresses.New
{
    public class GetNewAddressRequest : IGetNewAddressRequest
    {

        public NewAddressRequest execute(EmployeeIdentity request)
        {
            return new NewAddressRequest
                {
                    number_or_name = string.Empty,
                    line_one = string.Empty,
                    line_two = string.Empty,
                    line_three = string.Empty,
                    county = string.Empty,
                    postcode = string.Empty,
                    employee_id = request.employee_id,
                };
        }
    }
}