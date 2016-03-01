using System.Linq;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR.Employees.EmployeeImage.Details;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.Employees.EmployeeImage.GetById
{
    public class GetImageOfAnEmployee : IGetImageOfAnEmployee
    {
        public GetImageOfAnEmployee(IQueryRepository<Employee> theEmployeeRepository)
        {
            _employeeRepository = Guard.IsNotNull(theEmployeeRepository, "theEmployeeRepository");
        }

        public Response<EmployeeImageDetails> execute(EmployeeIdentity request)
        {
            var employee = _employeeRepository.Entities.Single(e => e.id == request.employee_id);


            return new Response<EmployeeImageDetails>
                {
                    result = new EmployeeImageDetails
                    {
                        image_id = employee.image_id,
                        employee_id = request.employee_id,
                    }
                };
        }

        private readonly IQueryRepository<Employee> _employeeRepository;
    }
}
