using WTS.WorkSuite.Core.DomainIdentity;

namespace WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.New
{
    public class GetNewEmergencyContactRequest : IGetNewEmergencyContactRequest
    {

        public NewEmergencyContactRequest execute(EmployeeIdentity request)
        {
            return new NewEmergencyContactRequest
                {
                    name = string.Empty,
                    employee_id = request.employee_id,
                };
        }
    }
}