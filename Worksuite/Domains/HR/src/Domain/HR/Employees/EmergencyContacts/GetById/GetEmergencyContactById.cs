using System.Linq;
using WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.Details;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.GetById
{
    public class GetEmergencyContactById : IGetEmergencyContactById
    {
        public GetEmergencyContactById(IQueryRepository<Employee> the_employee_repository)
        {
            employee_repository = Guard.IsNotNull(the_employee_repository, "the_employee_repository");
        }

        public Response<EmergencyContactDetails> execute(EmergencyContactIdentity request)
        {
            var employee = employee_repository.Entities.Single(e => e.id == request.employee_id);

            var emergency_contact = employee.EmergencyContacts.Single(a => a.id == request.emergency_contact_id);

            return new Response<EmergencyContactDetails>
            {
                result = new EmergencyContactDetails
                {
                    name = emergency_contact.name,
                    emergency_contact_id = emergency_contact.id,
                    employee_id = request.employee_id,
                    primary_phone_number = emergency_contact.primary_phone_number,
                    other_phone_number = emergency_contact.other_phone_number,
                    relationship = emergency_contact.relationship == null ? null : emergency_contact.relationship.description,
                    priority = emergency_contact.priority.ToString()
                }
            };
        }

        private readonly IQueryRepository<Employee> employee_repository;
    }
}