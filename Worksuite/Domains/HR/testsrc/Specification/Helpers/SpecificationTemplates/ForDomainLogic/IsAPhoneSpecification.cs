using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Helpers.Specifications.ForResponseCommands;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic {

    public class IsAPhoneSpecification<P,Q,R,F>
                    : HRResponseCommandSpecification<P, Q, F>
            where Q : Response
            where F : IsAResponseCommandFixture<P, Q> {

        //done: numeric is valid
        //done: space is valid
        //done: plus sing [+] is valid
        //done: opening bracket [(] is valid
        //done: closing bracket [)] is valid
        //done: non numeric is invalid

        private Action<P, string> set_field { get; set; }
        private Func<P, string> get_field { get; set; }


        [TestMethod]
        public void a_numeric_character_are_valid()
        {
            set_field(fixture.request, get_field(fixture.request) + "1");

            fixture.execute_command();

            assert_response_does_not_have_errors(fixture.response);
        }

        [TestMethod]
        public void a_space_is_valid()
        {
            set_field(fixture.request, get_field(fixture.request) + " ");

            fixture.execute_command();

            assert_response_does_not_have_errors(fixture.response);
        }

        [TestMethod]
        public void a_plus_sign_is_valid()
        {
            set_field(fixture.request, get_field(fixture.request) + "+");

            fixture.execute_command();

            assert_response_does_not_have_errors(fixture.response);
        }

        [TestMethod]
        public void an_opening_bracket_is_valid()
        {
            set_field(fixture.request, get_field(fixture.request) + "(");

            fixture.execute_command();

            assert_response_does_not_have_errors(fixture.response);
        }

        [TestMethod]
        public void a_closing_bracket_is_valid()
        {
            set_field(fixture.request, get_field(fixture.request) + ")");

            fixture.execute_command();

            assert_response_does_not_have_errors(fixture.response);
        }

        [TestMethod]
        public void a_non_numeric_character_is_invalid()
        {
            set_field(fixture.request, fixture.request + "A");

            fixture.execute_command();

            assert_response_has_errors(fixture.response);
        }

        protected IsAPhoneSpecification
            ( Action<P,string> set_field_by, Func<P,string> get_field_by ) {
            
            set_field = set_field_by;
            get_field = get_field_by;
        }

        private void assert_response_has_errors(Q response)
        {
            response.has_errors.Should().BeTrue();
        }

        private void assert_response_does_not_have_errors(Q response)
        {
            response.has_errors.Should().BeFalse();
        }


    }
}
