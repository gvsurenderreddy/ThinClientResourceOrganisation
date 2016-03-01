using System.Linq;
using WTS.WorkSuite.Library.DomainTypes.DefaultValues;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.Reorder
{
    public class GetReorderEmergencyContactRequest
                            : IGetReorderEmergencyContactRequest
    {
        public GetReorderEmergencyContactRequest( IEntityRepository< Employee > the_employee_repository )
        {
            _employee_repository = Guard.IsNotNull(the_employee_repository, "the_employee_repository");
        }

        public Response<ReorderEmergencyContactDetails> execute( ReorderEmergencyContactRequest request )
        {
            var employee = _employee_repository
                                .Entities
                                .Single( e => e.id == request.employee_id )
                                ;
            var emergency_contact = employee
                                        .EmergencyContacts
                                        .Single( em => em.id == request.emergency_contact_id )
                                        ;

            return new Response<ReorderEmergencyContactDetails>
            {
                result = new ReorderEmergencyContactDetails
                {
                    emergency_contact_id = request.emergency_contact_id,
                    employee_id = request.employee_id,
                    priority = request.priority,
                    name = emergency_contact.name,
                    relationship = emergency_contact.relationship != null ? emergency_contact.relationship.description : NotSpecified.Description,
                    primary_phone_number = emergency_contact.primary_phone_number,
                    other_phone_number = emergency_contact.other_phone_number,
                    current_priority = emergency_contact.priority
                }
            };
        }

        private readonly IEntityRepository<Employee> _employee_repository;
    }
}