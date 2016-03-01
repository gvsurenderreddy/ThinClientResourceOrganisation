using System.Linq;
using WTS.WorkSuite.HR.HR.Employees.Addresses.Details;
using WTS.WorkSuite.HR.HR.Employees.Addresses.New;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.Employees.Addresses.GetById
{
    public class GetAddressById : IGetAddressById
    {
        public GetAddressById(IQueryRepository<Employee> the_employee_repository)
        {
            employee_repository = Guard.IsNotNull(the_employee_repository, "the_employee_repository");
        }

        public Response<AddressDetailsForEdit> execute(AddressIdentity request)
        {
            var employee = employee_repository.Entities.Single(e => e.id == request.employee_id);

            var address = employee.Address.Single(a => a.id == request.address_id);

            return new Response<AddressDetailsForEdit>
                {
                    result = new AddressDetailsForEdit
                    {
                        number_or_Name = address.number_or_name,
                        line1 = address.line_one,
                        line2 = address.line_two,
                        line3 = address.line_three,
                        county = address.county,
                        country = address.country,
                        postcode = address.postcode,
                        address_id = request.address_id,
                        employee_id = request.employee_id,
                    }
                };
        }

        private readonly IQueryRepository<Employee> employee_repository;
    }
}