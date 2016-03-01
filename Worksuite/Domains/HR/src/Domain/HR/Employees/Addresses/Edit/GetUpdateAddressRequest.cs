using System.Linq;
using WTS.WorkSuite.HR.HR.Employees.Addresses.New;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.Employees.Addresses.Edit
{
    public class GetUpdateAddressRequest : IGetUpdateRequest
    {
        public GetUpdateAddressRequest(IEntityRepository<Employee> the_repository)
        {
            Guard.IsNotNull(the_repository, "the_repository");

            repository = the_repository;
        }

        public Response<UpdateAddressRequest> execute(AddressIdentity request)
        {
            var employee = repository
                              .Entities
                              .Single(e => e.id == request.employee_id)
                              ;

            var address = employee.Address.Single(a => a.id == request.address_id);

            return new Response<UpdateAddressRequest>
            {
                result = new UpdateAddressRequest
                {
                    address_id = request.address_id,
                    employee_id = request.employee_id,
                    number_or_name = address.number_or_name,
                    line_one = address.line_one,
                    line_two = address.line_two,
                    line_three = address.line_three,
                    county = address.county,
                    country = address.country,
                    postcode = address.postcode,
                    current_priority = address.priority.ToString()
                }
            };
        }

        private IEntityRepository<Employee> repository;
    }
}