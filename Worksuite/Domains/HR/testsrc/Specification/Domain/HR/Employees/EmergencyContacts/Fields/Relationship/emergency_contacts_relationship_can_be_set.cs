using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees.EmergencyContacts;
using WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.Edit;
using WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.GetById;
using WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.New;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees.EmergencyContacts;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Relationships;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmergencyContacts.Fields.Relationship
{

    [TestClass]
    public class relationship_can_be_set : HRSpecification
    {

        #region"Create"
        [TestMethod]
        public void to_an_existing_relationship_on_create()
        {
            var relationship = relationship_helper.add().description("relationship").entity;

            var create_response = create_command.execute(new NewEmergencyContactRequest
            {
                name = "name",
                primary_phone_number = "0123",
                relationship_id = relationship.id,
                employee_id = employee.id
            });

            var getbyid_response = get_by_id_query.execute(new EmergencyContactIdentity
            {
                emergency_contact_id = create_response.result.emergency_contact_id,
                employee_id = create_response.result.employee_id
            });

            Assert.IsTrue(getbyid_response.result.relationship == relationship.description);
        }

        [TestMethod]
        public void cannot_be_set_to_a_hidden_one_on_create()
        {

            var relationship = relationship_helper.add().is_hidden(true).description("relationship").entity;

            var create_response = create_command.execute(new NewEmergencyContactRequest
            {
                name = "name",
                primary_phone_number = "0123",
                relationship_id = relationship.id,
                employee_id = employee.id
            });

            Assert.IsTrue(create_response.has_errors);
        }
        #endregion

        #region"Update"
        [TestMethod]
        public void to_an_existing_relationship_on_update()
        {
            var relationship = relationship_helper.add().description("relationship").entity;

            var update_response = update_command.execute(new UpdateRequest
            {
                name = "name",
                primary_phone_number = "0123",
                other_phone_number = "098282",
                relationship_id = relationship.id,
                employee_id = employee.id,
                emergency_contact_id = emergency_contact.id
            });

            var getbyid_response = get_by_id_query.execute(new EmergencyContactIdentity
            {
                emergency_contact_id = update_response.result.emergency_contact_id,
                employee_id = update_response.result.employee_id
            });

            Assert.IsTrue(getbyid_response.result.relationship == relationship.description);
        }

        [TestMethod]
        public void cannot_be_set_to_a_hidden_one_on_update()
        {

            var relationship = relationship_helper.add().is_hidden(true).description("relationship").entity;

            var update_response = update_command.execute(new UpdateRequest
            {
                name = "name",
                primary_phone_number = "0123",
                other_phone_number = "098282",
                relationship_id = relationship.id,
                employee_id = employee.id,
                emergency_contact_id = emergency_contact.id
            });

            Assert.IsTrue(update_response.has_errors);
        }
        #endregion


        protected override void test_setup()
        {

            base.test_setup();

            get_by_id_query = DependencyResolver.resolve<IGetEmergencyContactById>();
            update_command = DependencyResolver.resolve<IUpdate>();
            create_command = DependencyResolver.resolve<INewEmergencyContact>();
            repository = DependencyResolver.resolve<IEntityRepository<Employee>>();

            emergency_contact_builder = new EmergencyContactBuilder(new EmergencyContact());
            employee_helper = DependencyResolver.resolve<EmployeeHelper>();
            relationship_helper = DependencyResolver.resolve<RelationshipHelper>();

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
        protected RelationshipHelper relationship_helper;

        private Employee employee;
        private EmergencyContact emergency_contact;
        protected IEntityRepository<Employee> repository;

    }
}