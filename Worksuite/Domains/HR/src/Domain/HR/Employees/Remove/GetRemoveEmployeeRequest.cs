using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Date;

namespace WTS.WorkSuite.HR.HR.Employees.Remove
{
    public class GetRemoveEmployeeRequest : IGetRemoveEmployeeRequest
    {
        public Response<RemoveEmployeeRequest> execute(EmployeeIdentity request)
        {

            var employee = repository
                            .Entities
                            .Single(e => e.id == request.employee_id)
                            ;
            var remove = new Response<RemoveEmployeeRequest>
            {

                result = new RemoveEmployeeRequest()
                {
                    employee_id = employee.id,
                    employeeReference = employee.employeeReference,
                    forename = employee.forename,
                    surname = employee.surname,
                    title = employee.title == null ? "" : employee.title.description,
                    gender = employee.gender == null ? "" : employee.gender.description,
                    othername = employee.othername,
                    birth_place = employee.birth_place,
                    dateofbirth = employee.dateofbirth.FormatForReport(),
                }
            };
            return remove;
        }

        public GetRemoveEmployeeRequest(IEntityRepository<Employee> the_repository)
        {

            Guard.IsNotNull(the_repository, "the_repository");

            repository = the_repository;
        }

        private IEntityRepository<Employee> repository;
    }

}
