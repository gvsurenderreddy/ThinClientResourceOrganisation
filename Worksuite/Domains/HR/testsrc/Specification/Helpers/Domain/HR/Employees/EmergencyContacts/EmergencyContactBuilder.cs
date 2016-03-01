using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WorkSuite.Library.Service.Specification.Helpers.IdentityProvider;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees.EmergencyContacts
{
    public class EmergencyContactBuilder : IEntityBuilder<EmergencyContact>
    {
        public EmergencyContact entity { get { return emergency_contact; } }

        public EmergencyContactBuilder(EmergencyContact the_emergency_contact)
        {
            Guard.IsNotNull(the_emergency_contact, "the_emergency_contact");

            var emergency_contact_identity_provider = new IntIdentityProvider<EmergencyContact>();

            emergency_contact = new EmergencyContact
            {
                id = emergency_contact_identity_provider.next(),
                name = the_emergency_contact.name,
                primary_phone_number = the_emergency_contact.primary_phone_number,
                relationship = the_emergency_contact.relationship,
                other_phone_number = the_emergency_contact.other_phone_number
            };
        }

        public EmergencyContactBuilder name(string value)
        {
            emergency_contact.name = value;
            return this;
        }

        public EmergencyContactBuilder primary_phone_number(string value)
        {
            emergency_contact.primary_phone_number = value;
            return this;
        }

        public EmergencyContactBuilder other_phone_number(string value)
        {
            emergency_contact.other_phone_number = value;
            return this;
        }


        public EmergencyContactBuilder relationship(Relationship value)
        {
            emergency_contact.relationship = value;
            return this;
        }

        public EmergencyContactBuilder priority(int value)
        {
            emergency_contact.priority = value;
            return this;
        }

        private readonly EmergencyContact emergency_contact;
    }
}