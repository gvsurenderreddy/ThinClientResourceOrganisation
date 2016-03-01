using System.Linq;
using WTS.WorkSuite.Library.DomainTypes.DefaultValues;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.Edit
{
    public class GetUpdateEmergencyContactRequest : IGetUpdateRequest
    {
        public GetUpdateEmergencyContactRequest(IEntityRepository<Employee> the_repository)
        {
            Guard.IsNotNull(the_repository, "the_repository");

            repository = the_repository;
        }

        public Response<UpdateRequest> execute(EmergencyContactIdentity request)
        {
            var employee = repository
                              .Entities
                              .Single(e => e.id == request.employee_id)
                              ;

            var emergency_contact = employee.EmergencyContacts.Single(a => a.id == request.emergency_contact_id);

            return new Response<UpdateRequest>
            {
                result = new UpdateRequest
                {
                    emergency_contact_id = request.emergency_contact_id,
                    employee_id = request.employee_id,
                    name = emergency_contact.name,
                    primary_phone_number = emergency_contact.primary_phone_number,
                    other_phone_number = emergency_contact.other_phone_number,
                    relationship_id = emergency_contact.relationship != null ? emergency_contact.relationship.id : NotSpecified.Id,
                    current_priority = emergency_contact.priority.ToString()
                }
            };
        }

        private IEntityRepository<Employee> repository;
    }
}