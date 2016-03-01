using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees.EmergencyContacts;
using WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.Edit;
using WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.GetById;
using WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.New;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees.EmergencyContacts;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmergencyContacts.Fields.Name
{
    [TestClass]
    public class does_not_have_a_space_at_the_start_and_end : HRSpecification
    {
        #region"Create"
        [TestMethod]
        public void name_does_not_allow_white_space_saved_on_create()
        {
            var response = create_command.execute(new NewEmergencyContactRequest
            {
                name = " ",
                primary_phone_number = "1234",
                employee_id = employee.id
            });



            Assert.IsTrue(response.has_errors);
        }

        [TestMethod]
        public void name_does_not_have_space_at_the_start_and_end_of_it_on_create()
        {

            var response_old = create_command.execute(new NewEmergencyContactRequest
            {
                name = "  test ",
                primary_phone_number = "1234",
                employee_id = employee.id
            });

            var response = get_by_id_query.execute(new EmergencyContactIdentity
            {
                emergency_contact_id = response_old.result.emergency_contact_id,
                employee_id = response_old.result.employee_id
            });


            Assert.AreEqual("test", response.result.name);
        }
        #endregion

        #region"Update"
        [TestMethod]
        public void name_does_not_have_white_space_at_start_and_end_of_it_on_update()
        {

            var response = update_command.execute(new UpdateRequest
            {
                name = " name ",
                primary_phone_number = "123",
                emergency_contact_id = emergency_contact.id,
                employee_id = employee.id,
            });

            var emergency_contact_updated = get_by_id_query.execute(new EmergencyContactIdentity
            {
                emergency_contact_id = response.result.emergency_contact_id,
                employee_id = response.result.employee_id
            });


            Assert.AreEqual("name", emergency_contact_updated.result.name);
        }

        [TestMethod]
        public void name_does_not_allow_white_space_to_be_saved_on_update()
        {

            var response = update_command.execute(new UpdateRequest
            {
                name = "        ",
                emergency_contact_id = emergency_contact.id,
                employee_id = employee.id,
            });


            Assert.IsTrue(response.has_errors);
        }
        #endregion


        protected override void test_setup()
        {

            base.test_setup();

            get_by_id_query = DependencyResolver.resolve<IGetEmergencyContactById>();
            update_command = DependencyResolver.resolve<IUpdate>();
            create_command = DependencyResolver.resolve<INewEmergencyContact>();

            emergency_contact_builder = new EmergencyContactBuilder(new EmergencyContact());
            employee_helper = DependencyResolver.resolve<EmployeeHelper>();

            setup_employee_emergency_contact();
        }

        private void setup_employee_emergency_contact()
        {
            emergency_contact = emergency_contact_builder.name("A name").entity;
            employee = employee_helper
                           .add().emergency_contact(emergency_contact)
                           .entity;
        }

        private IGetEmergencyContactById get_by_id_query;
        private INewEmergencyContact create_command;
        private IUpdate update_command;

        private EmergencyContactBuilder emergency_contact_builder;
        private EmployeeHelper employee_helper;

        private Employee employee;
        private EmergencyContact emergency_contact;



    }
}
