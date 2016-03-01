using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Persistence.Domain.HR.ReferenceData;
using WTS.WorkSuite.Service.HR.Employees.EmergencyContacts;

namespace WTS.WorkSuite.Service.Specification.Domain.HR.Employees.EmergencyContacts.Features.GetEligibleRelationships
{
    [TestClass]
    public class Returns : GetEligibleRelationshipsFixture
    {
        //DONE: Unspecified at top if emergency contact has not been assigned a relationship.
        //DONE: Unspecified at second position if emergency contact has been assigned a relationship
        //DONE: always return the emergency contacts assigned relationhip if one exists regardless of it being hidden or not
        //do not return hidden relationships


        [TestMethod]
        public void unspecified_at_top_of_collection_if_emergency_contact_has_not_been_assigned_a_relationship_()
        {
            var relationship = seed_a_non_hidden_relationship("non_hidden");

            var emergency_contact = emergency_contact_builder.name("A name").entity;

            var employee = add_employee()
                              .forename("Fred")
                              .emergency_contact(emergency_contact)
                              .entity
                              ;

            var response = query.execute(new EmergencyContactIdentity { employee_id = employee.id, emergency_contact_id = emergency_contact.id }).result;

            Assert.IsTrue(response.First().id == -1);
        }

        [TestMethod]
        public void unspecified_at_second_position_if_emergency_contact_has_been_assigned_a_relationship_()
        {
            var relationship = seed_a_non_hidden_relationship("non_hidden");

            var emergency_contact = emergency_contact_builder.name("A name").relationship(relationship).entity;

            var employee = add_employee()
                              .forename("Fred")
                              .emergency_contact(emergency_contact)
                              .entity
                              ;

            var response = query.execute(new EmergencyContactIdentity { employee_id = employee.id, emergency_contact_id = emergency_contact.id }).result.ToList();

            Assert.IsTrue(response.First().id == relationship.id);
            Assert.IsTrue(response.ElementAt(1).id == -1);
        }

        [TestMethod]
        public void wil_always_return_the_emergency_contacts_assigned_relationhip_if_one_exists_regardless_of_it_being_hidden_or_not()
        {
            var relationship = seed_a_hidden_relationship("hidden");

            var emergency_contact = emergency_contact_builder.name("A name").relationship(relationship).entity;

            var employee = add_employee()
                              .forename("Fred")
                              .emergency_contact(emergency_contact)
                              .entity
                              ;

            var response = query.execute(new EmergencyContactIdentity { employee_id = employee.id, emergency_contact_id = emergency_contact.id }).result.ToList();

            Assert.IsTrue(response.Any(r=>r.is_hidden));
        }


        [TestMethod]
        public void does_not_return_hidden_relationships()
        {
            var hidden_1 = seed_a_hidden_relationship("hidden_1");

            var hidden_2 = seed_a_hidden_relationship("hidden_2");

            var hidden_3 = seed_a_hidden_relationship("hidden_3");

            seed_3_relationships();

            var emergency_contact = emergency_contact_builder.name("A name").entity;

            var employee = add_employee()
                              .forename("Fred")
                              .emergency_contact(emergency_contact)
                              .entity
                              ;

            var response = query.execute(new EmergencyContactIdentity { employee_id = employee.id, emergency_contact_id = emergency_contact.id }).result.ToList();

            Assert.IsFalse(response.Any(r => r.is_hidden));
        }

        [TestMethod]
        public void all_eligible_relationships()
        {
            
            var hidden_1 = seed_a_hidden_relationship("hidden_1");
            var hidden_2 = seed_a_hidden_relationship("hidden_2");
            var hidden_3 = seed_a_hidden_relationship("hidden_3");

            seed_3_relationships();

            var emergency_contact = emergency_contact_builder.name("Name").relationship(hidden_1).entity;

            var employee = add_employee()
                              .forename("Fred")
                              .emergency_contact(emergency_contact)
                              .entity
                              ;

            var response = query.execute(new EmergencyContactIdentity { employee_id = employee.id, emergency_contact_id = emergency_contact.id }).result.ToList();


            //Total should be 5
            //3 non hidden were seeded : valid (+3)
            //3 hidden were seeded : non valid (+0)
            //1 of the hidden was assigned to a contact: valid (+1)
            //Unspecified should be returned : valid (+1)
            Assert.AreEqual(5, response.Count());
        }


        private void seed_3_relationships()
        {
            var relationship_1 = relationship_helper.add().description("relationship_1").entity;

            var relationship_2 = relationship_helper.add().description("relationship_2").entity;

            var relationship_3 = relationship_helper.add().description("relationship_3").entity;
        }

        private Relationship seed_a_hidden_relationship(string description)
        {
            return relationship_helper.add().is_hidden(true).description(description).entity;
        }

        private Relationship seed_a_non_hidden_relationship(string description)
        {
            return relationship_helper.add().description(description).entity;
        }
    }

}