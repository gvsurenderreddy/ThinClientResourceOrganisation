using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.Employees.ContactDetails.Edit 
{

    public class GetUpdateContactDetailsRequest : IGetUpdateRequest 
    {
        private IEntityRepository<Employee> repository;

        public Response<UpdateRequest> execute ( EmployeeIdentity request ) {

            var employee = repository
                            .Entities
                            .Single( e => e.id == request.employee_id )
                            ;

            return new Response<UpdateRequest> {
                result = new UpdateRequest {
                    employee_id = employee.id,
                    phone = employee.phone_number,
                    mobile = employee.mobile,
                    email = employee.email,
                    other = employee.other,
                }
            };
        }

        public GetUpdateContactDetailsRequest ( IEntityRepository<Employee> the_repository ) {

            Guard.IsNotNull( the_repository, "the_repository" );

            repository = the_repository;
        }


    }
}