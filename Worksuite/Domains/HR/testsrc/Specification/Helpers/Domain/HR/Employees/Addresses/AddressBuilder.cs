using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WorkSuite.Library.Service.Specification.Helpers.IdentityProvider;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees.Addresses
{
    public class AddressBuilder : IEntityBuilder<Address>
    {
        public Address entity { get { return address; } }

        public AddressBuilder(Address the_address)
        {
            Guard.IsNotNull(the_address, "the_address");

            var address_identity_provider = new IntIdentityProvider<Address>();

            address = new Address
            {
                id = address_identity_provider .next(),
                number_or_name = the_address.number_or_name,
                line_one = the_address.line_one,
                line_two = the_address.line_two,
                line_three = the_address.line_three,
                county = the_address.county,
                postcode = the_address.postcode,
            };
        }

        public AddressBuilder number_or_name(string value)
        {
            address.number_or_name = value;
            return this;
        }


        public AddressBuilder postcode(string value)
        {
            address.postcode = value;
            return this;
        }

        public AddressBuilder line1(string value)
        {
            address.line_one = value;
            return this;
        }

        public AddressBuilder priority(int value)
        {
            address.priority = value;
            return this;
        }


        private readonly Address address;
    }
}