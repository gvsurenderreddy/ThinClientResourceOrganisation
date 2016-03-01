using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Library.DomainTypes.Tests.PostalAddresses.Validation.Helpers;
using WTS.WorkSuite.Library.DomainTypes.Tests.PostalAddresses.Validation.Helpers.WhenValidating;

namespace WTS.WorkSuite.Library.DomainTypes.Tests.PostalAddresses.Validation.Features {

    [TestClass]
    public class PostalAddressValidator_will 
                    : PostalAddressValidatorSpecification {


        [TestMethod]
        public void no_errors_are_reported_for_a_valid_address () {
            
            this
                .given
                .a_valid_postal_address(  )

                .when(  )
                .the_address_is_validated(  )

                .then( )
                .no_error_are_reported(  )
                ;


        }
    }
}