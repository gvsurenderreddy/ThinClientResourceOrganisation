using WTS.WorkSuite.Library.DomainTypes.Tests.PostalAddresses.Helpers;

namespace WTS.WorkSuite.Library.DomainTypes.Tests.PostalAddresses.Sanitiser.Helpers {

    internal class Given 
                    : GivenAPostalAddress<When> {

        public readonly string whitespace = "\t\n\r  ";

        public override When when () {
              
            return new When( postal_address );
        }         
    }

}