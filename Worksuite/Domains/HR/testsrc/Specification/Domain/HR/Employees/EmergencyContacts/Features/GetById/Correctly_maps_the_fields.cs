using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees.EmergencyContacts;
using WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.GetById;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees.EmergencyContacts;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Relationships;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmergencyContacts.Features.GetById
{
    [TestClass]
    public class Correctly_maps_the_fields : HRSpecification
    {
        [TestMethod]
        public void maps_the_emergency_contacts_name()
        {
            var emergency_contact = emergency_contact_builder.name("A contact");
            var employee = employee_helper
                           .add().emergency_contact(emergency_contact.entity)
                           .entity;

            var response = query.execute(new EmergencyContactIdentity { employee_id = employee.id, emergency_contact_id = emergency_contact.entity.id });

            Assert.IsTrue(response.result.name == emergency_contact_builder.entity.name);
        }

        [TestMethod]
        public void maps_the_emergency_contacts_relationship()
        {
            var relationship = relationship_helper.add().description("relationship").entity;

            var emergency_contact = emergency_contact_builder.name("A contact").relationship(relationship);
            var employee = employee_helper
                           .add().emergency_contact(emergency_contact.entity)
                           .entity;

            var response = query.execute(new EmergencyContactIdentity { employee_id = employee.id, emergency_contact_id = emergency_contact.entity.id });

            response.result.relationship.Should().Be(relationship.description);
        }

        [TestMethod]
        public void maps_the_emergency_contacts_primary_phone_number()
        {
            const string contact_number = "0011";
            var emergency_contact = emergency_contact_builder.name("A name").primary_phone_number(contact_number).entity;

            var employee = employee_helper
                           .add().emergency_contact(emergency_contact)
                           .entity;

            var response = query.execute(new EmergencyContactIdentity { employee_id = employee.id, emergency_contact_id = emergency_contact.id });

            response.result.primary_phone_number.Should().Be(contact_number);
        }

        [TestMethod]
        public void maps_the_emergency_contacts_other_phone_number()
        {
            const string contact_number = "0011";
            var emergency_contact = emergency_contact_builder.name("A name").other_phone_number(contact_number).entity;

            var employee = employee_helper
                           .add().emergency_contact(emergency_contact)
                           .entity;

            var response = query.execute(new EmergencyContactIdentity { employee_id = employee.id, emergency_contact_id = emergency_contact.id });

            response.result.other_phone_number.Should().Be(contact_number);
        }


        protected override void test_setup()
        {
            base.test_setup();

            query = DependencyResolver.resolve<IGetEmergencyContactById>();

            emergency_contact_builder = new EmergencyContactBuilder(new EmergencyContact());


            employee_helper = DependencyResolver.resolve<EmployeeHelper>();
            relationship_helper = DependencyResolver.resolve<RelationshipHelper>();

        }

        private RelationshipHelper relationship_helper;
        private IGetEmergencyContactById query;
        private EmergencyContactBuilder emergency_contact_builder;
        private EmployeeHelper employee_helper;

    }
}