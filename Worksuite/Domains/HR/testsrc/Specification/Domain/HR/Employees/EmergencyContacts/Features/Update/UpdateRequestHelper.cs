using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.Edit;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees.EmergencyContacts;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmergencyContacts.Features.Update
{

    public class UpdateRequestHelper : IRequestHelper<UpdateRequest>
    {

        public UpdateRequestHelper(EmployeeHelper the_helper, EmergencyContactBuilder the_emergency_contact_builder)
        {
            helper = Guard.IsNotNull(the_helper, "the_helper");
            emergency_contact_builder = Guard.IsNotNull(the_emergency_contact_builder, "the_emergency_contact_builder");
        }

        public UpdateRequest given_a_valid_request()
        {
            var emergency_contact = emergency_contact_builder.name("Seeded").entity;

            //Create an Employee
            var employee = helper.add().emergency_contact(emergency_contact).entity;

            return new UpdateRequest
            {
                name = "updated contact",
                primary_phone_number = "123",
                employee_id = employee.id,
                emergency_contact_id = emergency_contact.id
            };
        }

        private readonly EmployeeHelper helper;
        private readonly EmergencyContactBuilder emergency_contact_builder;
    }

}