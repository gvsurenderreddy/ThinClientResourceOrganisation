using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Helpers.Specifications.ForResponseCommands;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic {

    public abstract class TextFieldOnlyContainsAlphabeticCharactersSpecification<P,Q,R,F>
                            : HRResponseCommandSpecification<P, Q, F> 
                    where Q : Response<R> 
                    where F : IsAResponseCommandFixture<P,Q>  {


        [TestMethod]
        public void a_numeric_character_is_invalid ( ) {
            set_field( fixture.request, fixture.request+"1" );

            fixture.execute_command();

            assert_response_has_errors( fixture.response );
        }

        [TestMethod]
        public void a_non_alpha_numeric_character_is_invalid ( ) {
            set_field( fixture.request, fixture.request+"_" );

            fixture.execute_command();

            assert_response_has_errors( fixture.response );
        }

        [TestMethod]
        public void lowercase_is_valid ( ) {
            set_field( fixture.request, get_field( fixture.request ).ToLower() );

            fixture.execute_command();

            assert_response_does_not_have_errors( fixture.response );
        }

        [TestMethod]
        public void uppercase_is_valid ( ) {
            set_field( fixture.request, get_field( fixture.request ).ToUpper() );

            fixture.execute_command();

            assert_response_does_not_have_errors( fixture.response );
        }


        protected TextFieldOnlyContainsAlphabeticCharactersSpecification
            ( Action<P,string> set_field_by, Func<P,string> get_field_by ) {
            
            set_field = set_field_by;
            get_field = get_field_by;
        }
        

        private void assert_response_has_errors ( Q response ) {
            response.has_errors.Should(  ).BeTrue(  );
        }

        private void assert_response_does_not_have_errors ( Q response ) {
            response.has_errors.Should(  ).BeFalse(  );
        }

        private Action<P,string> set_field { get; set; }
        private Func<P,string> get_field { get; set; }
    }

}