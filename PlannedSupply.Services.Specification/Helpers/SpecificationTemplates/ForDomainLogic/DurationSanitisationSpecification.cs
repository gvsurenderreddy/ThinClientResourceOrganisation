using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Helpers.Specifications.ForResponseCommands;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Duration;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.ForDomainLogic
{
    public class DurationSanitisationSpecification<P, Q, F>
                                 : PlannedSupplyResponseCommandSpecification<P, Q, F>
                         where Q : Response
                         where F : IsAResponseCommandFixture<P, Q>
    {
        protected DurationSanitisationSpecification(Action<P, DurationRequest> set_field_by)
            : this(set_field_by, null)
        {
        }

        protected DurationSanitisationSpecification(Action<P, DurationRequest> set_field_by,
            string the_expectde_message)
        {
            set_field = set_field_by;
            expected_messages = the_expectde_message;
        }

        private Action<P, DurationRequest> set_field { get; set; }
        private string expected_messages { get; set; }


        #region"hour_must_be_greater_than_zero_and_non_numeric"

        [TestMethod]
        public void hour_in_text_format_should_show_error()
        {
            var response = execute_update_shift_template_command("test");
            response.has_errors.Should().BeTrue();
        }

        [TestMethod]
        public void hour_less_than_zero_should_show_error()
        {
            var response = execute_update_shift_template_command("-1");
            response.has_errors.Should().BeTrue();
        }

        private Q execute_update_shift_template_command(string value)
        {
            var the_value = new DurationRequest()
            {
                hours = value,
                minutes = "24"
            };
            set_field(fixture.request, the_value);
            fixture.execute_command();
            var response = fixture.response;
            return response;
        }

        #endregion

        #region "minutes_must_be_between_zero_and_sixty"

        [TestMethod]
        public void minutes_in_the_text_format_should_show_error()
        {
            var response = execute_create_new_shift_template_command("test");
            response.has_errors.Should().BeTrue();
        }

        [TestMethod]
        public void minutes_less_than_zero_should_show_error()
        {
            var response = execute_create_new_shift_template_command("-1");

            response.has_errors.Should().BeTrue();
        }

        [TestMethod]
        public void minutes_greater_than_59_should_show_error()
        {
            var response = execute_create_new_shift_template_command("60");
            response.has_errors.Should().BeTrue();
        }

        private Q execute_create_new_shift_template_command(string value)
        {
            var the_value = new DurationRequest()
            {
                hours = "10",
                minutes = value
            };
            set_field(fixture.request, the_value);
            fixture.execute_command();
            var response = fixture.response;

            return response;
        }
        #endregion

        #region "hour_and_minutes_should_be_valid"

        [TestMethod]
        public void If_minutes_and_hour_are_not_valid_shoudl_show_error()
        {
            var the_value = new DurationRequest()
            {
                hours = "-1",
                minutes = "-1"
            };
            set_field(fixture.request, the_value);
            fixture.execute_command();
            var response = fixture.response;
            response.has_errors.Should().BeTrue();
        }

        #endregion
    }
}