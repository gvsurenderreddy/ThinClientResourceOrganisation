using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.Employees.Addresses.Reorder
{
    public class GetReorderAddressRequest : IGetReorderAddressRequest
    {
        public GetReorderAddressRequest(IEntityRepository<Employee> the_repository)
        {
            Guard.IsNotNull(the_repository, "the_repository");

            repository = the_repository;
        }


        public Response<ReorderAddressDetails> execute(ReorderAddressRequest request)
        {
            var employee = repository
                              .Entities
                              .Single(e => e.id == request.employee_id)
                              ;

            var address = employee.Address.Single(a => a.id == request.address_id);

            return new Response<ReorderAddressDetails>
            {
                result = new ReorderAddressDetails
                {
                    address_id = request.address_id,
                    employee_id = request.employee_id,
                    number_or_name = address.number_or_name,
                    line1 = address.line_one,
                    line2 = address.line_two,
                    line3 = address.line_three,
                    county = address.county,
                    country = address.country,
                    postcode = address.postcode,
                    priority = request.priority,
                    current_priority = address.priority
                }
            };
        }

        private readonly IEntityRepository<Employee> repository;
    }
}
