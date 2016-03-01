using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.Employees.EmployeeSummary
{
    public class GetEmployeeSummary : IGetEmployeeSummary
    {
        public GetEmployeeSummary(IQueryRepository<Employee> the_repository)
        {
            Guard.IsNotNull(the_repository, "the_repository");

            repository = the_repository;
        }

        public Response<EmployeeSummaryDetails> execute(EmployeeIdentity request)
        {
            var employee = repository
                            .Entities
                            .Single(e => e.id == request.employee_id)
                            ;

            return new Response<EmployeeSummaryDetails>
            {
                result = new EmployeeSummaryDetails
                {
                    employee_id = request.employee_id,
                    employee_name = employee.forename.Trim() + ' ' + employee.surname.Trim(),
                    image_id=employee.image_id, 
                }
            };
        }

        private readonly IQueryRepository<Employee> repository;
    }
}