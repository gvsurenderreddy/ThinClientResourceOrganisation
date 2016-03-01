using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Helpers.Specifications.ForResponseCommands;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.ForDomainLogic
{
    public abstract class TextFieldDoesNotExceedMaximumNumberOfCharactersSpecification<P, Q, F>
                : PlannedSupplyResponseCommandSpecification<P, Q, F>
        where Q : Response
        where F : IsAResponseCommandFixture<P, Q>
    {
        [TestMethod]
        public void verify()
        {
            set_field(fixture.request, fixture.request + field_value_that_is_too_large);

            fixture.execute_command();

            assert_response_has_errors(fixture.response);
            assert_response_contains_expected_error(fixture.response);
        }

        protected TextFieldDoesNotExceedMaximumNumberOfCharactersSpecification
            (Action<P, string> set_field_by, int max_character, string the_expected_message)
        {

            field_value_that_is_too_large = new String('x', max_character + 1);

            set_field = set_field_by;
            expected_message = the_expected_message;
        }

        private void assert_response_has_errors(Q response)
        {
            response.has_errors.Should().BeTrue();
        }

        private void assert_response_contains_expected_error
                        (Q response)
        {

            if (!string.IsNullOrWhiteSpace(expected_message))
            {
                response.messages.Should().Contain(e => e.message == expected_message);
            }
        }

        private Action<P, string> set_field { get; set; }
        private readonly string field_value_that_is_too_large;
        private string expected_message { get; set; }
    }
}