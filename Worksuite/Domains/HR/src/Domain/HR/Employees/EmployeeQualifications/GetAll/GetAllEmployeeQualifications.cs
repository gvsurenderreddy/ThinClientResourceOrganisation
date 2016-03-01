using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.Employees.EmployeeQualifications.GetAll
{
    public class GetAllEmployeeQualifications
                        : IGetAllEmployeeQualifications
    {
        public GetAllEmployeeQualificationsResponse execute( EmployeeIdentity request )
        {
            _employee = _employee_repository
                            .Entities
                            .Single( e => e.id == request.employee_id )
                            ;

            return new GetAllEmployeeQualificationsResponse
            {
                result = _employee.EmployeeQualifications.Select(eq => new EmployeeQualificationDetails
                {
                    employee_id = request.employee_id,
                    employee_qualification_id = eq.id,
                    qualification = eq.qualification == null ? null : eq.qualification.description
                })
            };
        }

        public GetAllEmployeeQualifications( IQueryRepository< Employee > the_employee_repository )
        {
            _employee_repository = Guard.IsNotNull( the_employee_repository, "the_employee_repository" );
        }

        private readonly IQueryRepository< Employee > _employee_repository;
        private Employee _employee;
    }
}