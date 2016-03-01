using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.HR.HR.Employees.Addresses.New;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.Addresses.Features.New
{
    public class NewAddressRequestHelper : IRequestHelper<NewAddressRequest>
    {
        public NewAddressRequestHelper(EmployeeHelper the_helper)
        {
            helper = Guard.IsNotNull(the_helper, "the_helper");
        }

        public NewAddressRequest given_a_valid_request()
        {
            //Create an Employee
            var employee = helper.add().entity;

            return new NewAddressRequest
                {
                    number_or_name = "1",
                    line_one = "Lancaster Road",
                    line_two = "North Street",
                    line_three = "Manchester",
                    county = "Cheshire",
                    postcode = "M11233",
                    employee_id = employee.id,
                };

        }


        private EmployeeHelper helper;
    }
}