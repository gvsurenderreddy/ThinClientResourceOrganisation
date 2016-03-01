using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.Employees.EmergencyContacts;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.Library.DomainTypes.DefaultValues;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Relationships.Queries.GetDetailsOfEligibleRelationships
{
    [TestClass]
    public class Returns : GetEligibleRelationshipsFixture
    {
        //DONE: Unspecified at top if emergency contact has not been assigned a relationship.
        //DONE: Unspecified at second position if emergency contact has been assigned a relationship
        //DONE: always return the emergency contacts assigned relationhip if one exists regardless of it being hidden or not
        //DONE: do not return hidden relationships
        //DONE: Return all eligible relationships
        //DONE: return only non hidden when an unspecified emergency contact is specified
        //DONE: return an empty collection if no relationships exist
        //DONE: Return the collection after the unspecified entry in alphabetical order


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

            Assert.IsTrue(response.First().id == NotSpecified.Id);
        }

        [TestMethod]
        public void assigned_relationship_as_first_item_and_unspecified_at_second_position_if_emergency_contact_has_been_assigned_a_relationship_()
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
            Assert.IsTrue(response.ElementAt(1).id == NotSpecified.Id);
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

        [TestMethod]
        public void return_an_empty_collection_if_no_relationships_exist()
        {
            var emergency_contact = emergency_contact_builder.name("Name").entity;

            var employee = add_employee()
                              .forename("Fred")
                              .emergency_contact(emergency_contact)
                              .entity
                              ;

            var response = query.execute(new EmergencyContactIdentity { employee_id = employee.id, emergency_contact_id = emergency_contact.id }).result.ToList();

            Assert.AreEqual(0, response.Count());
        }

        [TestMethod]
        public void return_only_non_hidden_relationships_when_an_unspecified_emergency_contact_is_specified()
        {

            var hidden_1 = seed_a_hidden_relationship("hidden_1");
            var hidden_2 = seed_a_hidden_relationship("hidden_2");
            var hidden_3 = seed_a_hidden_relationship("hidden_3");

            seed_3_relationships();

            var employee = add_employee()
                              .forename("Fred")
                              .entity
                              ;

            var response = query.execute(new EmergencyContactIdentity { employee_id = employee.id, emergency_contact_id = NotSpecified.Id }).result.ToList();


            //Total should be 4
            //3 hidden were seeded : non valid (+0)
            //3 non hidden were seeded : valid (+3)
            //none was assigned to any contact: n/a (+0)
            //Unspecified should be returned : valid (+1)
            Assert.AreEqual(4, response.Count());
        }

        [TestMethod]
        public void the_collection_after_the_unspecified_entry_in_alphabetical_order()
        {
            var relationship_C = seed_a_non_hidden_relationship("C");
            var relationship_A = seed_a_non_hidden_relationship("A");
            var relationship_B = seed_a_non_hidden_relationship("B");

            var employee = add_employee()
                              .forename("Fred")
                              .entity
                              ;

            var response = query.execute(new EmergencyContactIdentity { employee_id = employee.id, emergency_contact_id = NotSpecified.Id }).result.ToList();


            Assert.AreEqual(relationship_A.description, response.ElementAt(1).description);
            Assert.AreEqual(relationship_B.description, response.ElementAt(2).description);
            Assert.AreEqual(relationship_C.description, response.ElementAt(3).description);
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