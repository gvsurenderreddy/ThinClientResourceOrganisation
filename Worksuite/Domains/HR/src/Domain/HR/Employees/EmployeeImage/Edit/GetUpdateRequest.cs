using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.Employees.EmployeeImage.Edit
{
    public class GetUpdateRequest : IGetUpdateRequest
    {
        public GetUpdateRequest(IEntityRepository<Employee> theEmployeeRepository)
        {
            Guard.IsNotNull(theEmployeeRepository, "theEmployeeRepository");
            _employeeRepository = theEmployeeRepository;

        }

        public Response<UpdateRequest> execute(EmployeeIdentity request)
        {
            var employee = _employeeRepository
                              .Entities
                              .Single(e => e.id == request.employee_id)
                              ;

            return new Response<UpdateRequest>
            {
                result = new UpdateRequest
                {
                    employee_id = request.employee_id,
                    image_id = employee.image_id,
                }
            };
        }

        private IEntityRepository<Employee> _employeeRepository;
    }
}
