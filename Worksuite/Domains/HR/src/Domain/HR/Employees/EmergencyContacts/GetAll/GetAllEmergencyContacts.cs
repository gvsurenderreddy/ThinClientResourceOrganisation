using System.Collections.Generic;
using System.Linq;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.Details;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.GetAll
{
    public class GetAllEmergencyContacts : IGetAllEmergencyContacts
    {
        public GetAllEmergencyContacts(IQueryRepository<Employee> the_repository)
        {
            repository = Guard.IsNotNull(the_repository, "the_repository");
        }

        private readonly IQueryRepository<Employee> repository;
        private Employee employee;


        public Response<IEnumerable<EmergencyContactDetails>> execute(EmployeeIdentity request)
        {
            employee = repository
                      .Entities
                      .Single(e => e.id == request.employee_id);

            return new Response<IEnumerable<EmergencyContactDetails>>
            {
                result = employee.EmergencyContacts.OrderBy(ec => ec.priority).Select(ec => new EmergencyContactDetails
                {
                    employee_id = request.employee_id,
                    emergency_contact_id = ec.id,
                    name = ec.name,
                    primary_phone_number = ec.primary_phone_number,
                    other_phone_number = ec.other_phone_number,
                    relationship = ec.relationship == null ? null : ec.relationship.description,
                    priority = ec.priority.ToString()
                }),
            };
        }
    }
}