using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.Employees.ContactDetails.ById {

    public class GetContactDetailsById : IGetContactDetailsById 
    {
        private readonly IQueryRepository<Employee> repository;

        public Response<EmployeeContactDetails> execute ( EmployeeIdentity employee_identity ) {
            
            var employee = repository
                             .Entities
                             .Single( e => e.id == employee_identity.employee_id )
                             ;

            return new Response<EmployeeContactDetails> {
                result = new EmployeeContactDetails {
                    employee_id = employee_identity.employee_id,                    
                    phone = employee.phone_number,
                    email = employee.email,
                    mobile = employee.mobile,
                    other = employee.other,
                }            
            };
        }

        public GetContactDetailsById ( IQueryRepository<Employee> the_repository ) {
            
            Guard.IsNotNull( the_repository, "the_repository" );

            repository = the_repository;
        }

    }

}