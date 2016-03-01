using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Helpers.Specifications.ForResponseCommands;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Duration;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.ForDomainLogic
{
    public class MandatoryDurationFieldSpecification<P, Q, F>
                                     : PlannedSupplyResponseCommandSpecification<P, Q, F>
        where Q : Response
        where F : IsAResponseCommandFixture<P, Q>
    {
        [TestMethod]
        public void can_not_be_null()
        {

            verify_for(new DurationRequest()
            {
                hours=null,
                minutes = null
                     
            });
        }

        [TestMethod]
        public void can_not_be_an_empty_string()
        {

            verify_for(new DurationRequest()
            {
                hours = string.Empty,
                minutes = string.Empty
            });

        }

        [TestMethod]
        public void can_not_be_just_white_space()
        {

            verify_for(new DurationRequest()
            {
                hours = "\t",
                minutes = "\t"
            });

        }

        protected MandatoryDurationFieldSpecification
            (Action<P, DurationRequest> set_field_by)
            : this(set_field_by, null) { }


        protected MandatoryDurationFieldSpecification
            (Action<P, DurationRequest> set_field_by
                , string the_expected_message)
        {

            set_field = set_field_by;
            expected_message = the_expected_message;
        }

        private void verify_for
            (DurationRequest value)
        {

            set_field(fixture.request,value);

            fixture.execute_command();

            assert_response_has_errors(fixture.response);
            assert_response_contains_expected_error(fixture.response);
        }

        private void assert_response_has_errors
            (Q response)
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

        private Action<P, DurationRequest> set_field { get; set; }
        private string expected_message { get; set; }
    }
}