using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR.Employees;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmergencyContacts.Features.GetAll {

    [TestClass]
    public class Correctly_maps_the_fields : GetAllFixture
    {
        [TestMethod]
        public void maps_the_emergency_contacts_name()
        {
            var emergency_contact = emergency_contact_builder.name("A name").entity;
            var employee = add_employee()
                              .forename("Fred")
                              .emergency_contact(emergency_contact)
                              .entity
                              ;

            var response = query.execute(new EmployeeIdentity { employee_id = employee.id }).result.First();

            Assert.IsTrue(response.name == emergency_contact.name);
        }

        [TestMethod]
        public void maps_the_emergency_contacts_relationship()
        {
            var relationship = relationship_helper.add().description("relationship").entity;
            
            var emergency_contact = emergency_contact_builder.name("A name").relationship(relationship).entity;
            
            var employee = add_employee()
                              .forename("Fred")
                              .emergency_contact(emergency_contact)
                              .entity
                              ;

            var response = query.execute(new EmployeeIdentity { employee_id = employee.id }).result.First();

            response.relationship.Should().Be(relationship.description);
        }

        [TestMethod]
        public void maps_the_emergency_contacts_primary_phone_number()
        {
            const string contact_number = "0011";
            var emergency_contact = emergency_contact_builder.name("A name").primary_phone_number(contact_number).entity;

            var employee = add_employee()
                              .forename("Fred")
                              .emergency_contact(emergency_contact)
                              .entity
                              ;
            var resp = query.execute(new EmployeeIdentity {employee_id = employee.id});
            var response = resp.result.First();

            response.primary_phone_number.Should().Be(contact_number);
        }

        [TestMethod]
        public void maps_the_emergency_contacts_other_phone_number()
        {
            const string contact_number = "0011";
            var emergency_contact = emergency_contact_builder.name("A name").other_phone_number(contact_number).entity;

            var employee = add_employee()
                              .forename("Fred")
                              .emergency_contact(emergency_contact)
                              .entity
                              ;

            var response = query.execute(new EmployeeIdentity { employee_id = employee.id }).result.First();

            response.other_phone_number.Should().Be(contact_number);
        }
    }
 }