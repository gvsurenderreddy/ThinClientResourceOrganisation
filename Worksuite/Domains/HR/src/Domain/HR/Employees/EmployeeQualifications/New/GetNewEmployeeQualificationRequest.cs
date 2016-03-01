using WTS.WorkSuite.Core.DomainIdentity;

namespace WTS.WorkSuite.HR.HR.Employees.EmployeeQualifications.New
{
    public class GetNewEmployeeQualificationRequest
                        : IGetNewEmployeeQualificationRequest
    {
        public NewEmployeeQualificationRequest execute( EmployeeIdentity request )
        {
            return new NewEmployeeQualificationRequest
            {
                employee_id = request.employee_id
            };
        }
    }
}