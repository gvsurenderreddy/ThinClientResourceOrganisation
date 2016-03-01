﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Library.DomainTypes.Tests.PostalAddresses.Validation.Helpers;
using WTS.WorkSuite.Library.DomainTypes.Tests.PostalAddresses.Validation.Helpers.WhenValidating;

namespace WTS.WorkSuite.Library.DomainTypes.Tests.PostalAddresses.Validation.Fields.name_or_number {

    [TestClass]
    public class name_or_number_does_not_exceed_maximum_number_of_characters 
                    : PostalAddressValidatorSpecification {


        [TestMethod]
        public void reports_an_error_when_max_number_of_charaters_is_exceeded ( ) {            
            
            var test = given.a_string_that_is_the_maximum_address_line_length();

            this
                .given
                .name_or_number( test + "x" )

                .when(  )
                .the_address_is_validated(  )

                .then(  )
                .name_or_number_exceeds_it_maximum_size_error_is_reported()
                ;
        }

        [TestMethod]
        public void does_not_report_an_error_when_the_value_is_on_the_boundary_for_the_maximum_number_of_charaters ( ) {            
            
            var test = given.a_string_that_is_the_maximum_address_line_length();

            this
                .given
                .name_or_number( test  )

                .when(  )
                .the_address_is_validated(  )

                .then(  )
                .no_error_are_reported(  )
                ;
        }
    }

}