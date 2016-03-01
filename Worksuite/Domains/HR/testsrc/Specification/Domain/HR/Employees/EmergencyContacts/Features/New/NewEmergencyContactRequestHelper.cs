using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.New;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Relationships;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmergencyContacts.Features.New
{
    public class NewEmergencyContactRequestHelper : IRequestHelper<NewEmergencyContactRequest>
    {
        public NewEmergencyContactRequestHelper(EmployeeHelper the_employee_helper, RelationshipHelper the_relationship_helper)
        {
            employee_helper = Guard.IsNotNull(the_employee_helper, "the_employee_helper");
            relationship_helper = Guard.IsNotNull(the_relationship_helper, "the_relationship_helper");
        }

        public NewEmergencyContactRequest given_a_valid_request()
        {
            var relationship = relationship_helper.add().description("relationship").entity;

            //Create an Employee
            var employee = employee_helper.add().entity;

            return new NewEmergencyContactRequest
            {
                name = "a contact",
                employee_id = employee.id,
                primary_phone_number = "01234",
                other_phone_number = "01234",
                relationship_id = relationship.id
            };

        }


        private EmployeeHelper employee_helper;
        private RelationshipHelper relationship_helper;
    }
}