using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Helpers.Specifications.ForResponseCommands;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic {


    /// <summary>
    ///     All mandatory text fields should meet this specification.
    /// </summary>
    /// <typeparam name="P">
    ///     Request type
    /// </typeparam>
    /// <typeparam name="Q">
    ///     Response type
    /// </typeparam>    
    /// <typeparam name="F">
    ///     Test fixture used to 
    /// </typeparam>
    public abstract class MandatoryTextFieldSpecification<P,Q,F>
                            : HRResponseCommandSpecification<P, Q, F> 
                    where Q : Response 
                    where F : IsAResponseCommandFixture<P,Q>  {


        [TestMethod]
        public void can_not_be_null () {
            
            verify_for ( null );
        }

        [TestMethod]
        public void can_not_be_an_empty_string ( ) {

            verify_for ( string.Empty );

        }

        [TestMethod]
        public void can_not_be_just_white_space ( ) {

            verify_for ( "\r\n\t" );

        }



        protected MandatoryTextFieldSpecification 
                           ( Action<P,string> set_field_by ) 
                    : this ( set_field_by, null ) { }


        protected MandatoryTextFieldSpecification 
                    ( Action<P,string> set_field_by
                    , string the_expected_message ) {
            
            set_field = set_field_by;
            expected_message = the_expected_message;
        }


        // The response from the command should be set to has errors and 
        // contain an appropriate error message
        private void verify_for 
                        ( string value ) {

            set_field( fixture.request, value );

            fixture.execute_command();

            assert_response_has_errors( fixture.response );
            assert_response_contains_expected_error( fixture.response );
        }

        private void assert_response_has_errors 
                        ( Q response ) {

            response.has_errors.Should(  ).BeTrue(  );
        }

        private void assert_response_contains_expected_error 
                        ( Q response ) {
            
            if ( !string.IsNullOrWhiteSpace( expected_message) ) {
                response.messages.Should().Contain(e => e.message == expected_message);
            }
        }

        private Action<P,string> set_field { get; set; }
        private string expected_message { get; set; }
    }    
}