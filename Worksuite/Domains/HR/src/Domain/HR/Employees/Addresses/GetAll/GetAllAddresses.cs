using System.Collections.Generic;
using System.Linq;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR.Employees.Addresses.Details;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.Employees.Addresses.GetAll
{
    public class GetAllAddresses : IGetAllAddresses
    {
        public GetAllAddresses(IQueryRepository<Employee> the_repository)
        {
            repository = Guard.IsNotNull(the_repository, "the_repository");
        }

        private readonly IQueryRepository<Employee> repository;
        private Employee employee;

        public Response<IEnumerable<AddressDetails>> execute(EmployeeIdentity request)
        {
            employee = repository
                       .Entities
                       .Single(e => e.id == request.employee_id);

            return new Response<IEnumerable<AddressDetails>>
                {
                    result = employee.Address.OrderBy(a=>a.priority).Select(a => new AddressDetails 
                                {lines = new List<string>
                                    {
                                        a.number_or_name,
                                        a.line_one,
                                        a.line_two,
                                        a.line_three,
                                    }.Where( l => l != null)  ,
                                 county = a.county,
                                 country = a.country,
                                 postcode = a.postcode,
                                 priority = a.priority.ToString(),
                                 employee_id = request.employee_id,
                                 address_id = a.id})
                };
        }
    }
}