using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees.Addresses.Edit;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.Addresses.Features.Update {

    public class UpdateAddressRequestHelper 
                    : IRequestHelper<UpdateAddressRequest> {

        public UpdateAddressRequestHelper
                ( EmployeeHelper the_helper ) {

            helper = Guard.IsNotNull(the_helper, "the_helper");
        }

        public UpdateAddressRequest given_a_valid_request() {
            
            //Create an Employee
            var employee = helper
                            .add().entity;

            var address = new Address {
                id = 1,
                priority = 1,
                number_or_name = "1",
                line_one = "Lancaster Road",
                line_two = "North Street",
                line_three = "Manchester",
                county = "Cheshire",
                country = "England",
                postcode = "M11 233",                
            };

            employee
                .Address
                .Add( address );

            return new UpdateAddressRequest {
                employee_id = employee.id,
                address_id = address.id,
                number_or_name = address.number_or_name,
                line_one = address.line_one,
                line_two = address.line_two,
                line_three = address.line_three,
                county = address.county,
                country = address.country,
                postcode = address.postcode,
            };

        }


        private readonly EmployeeHelper helper;
    }
}