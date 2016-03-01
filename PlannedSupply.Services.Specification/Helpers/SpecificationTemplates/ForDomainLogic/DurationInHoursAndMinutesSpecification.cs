﻿using System;
using Content.Services.PlannedSupply.Messages;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Helpers.Specifications.ForResponseCommands;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Duration;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.ForDomainLogic
{
    public class DurationInHoursAndMinutesSpecification<P, Q, F>
                                     : PlannedSupplyResponseCommandSpecification<P, Q, F>
                             where Q : Response
                             where F : IsAResponseCommandFixture<P, Q>
    {

        protected DurationInHoursAndMinutesSpecification(Action<P, DurationRequest> Set_field_by)
            : this(Set_field_by, null) { }

        protected DurationInHoursAndMinutesSpecification(Action<P, DurationRequest> set_field_by, string the_expected_message)
        {
            set_field = set_field_by;
            expected_message = the_expected_message;
        }

        private Action<P, DurationRequest> set_field { get; set; }
        private string expected_message { get; set; }

        #region "duration_must_be_between_one_minute_and_twenty_four_hours"

        // 1 minutes more than 24 hour should report error.
        // zero hour and zero minute shoydl report error .

        [TestMethod]
        public void one_minute_more_than_twenty_four_should_report_error()
        {
            var the_value = new DurationRequest()
            {
                hours = "24",
                minutes = "1"
            };

            set_field(fixture.request, the_value);

            fixture.execute_command();
            var response = fixture.response;
            response.has_errors.Should().BeTrue();
            response.messages.Should().Contain(m => m.field_name == "duration" && m.message == ValidationMessages.error_00_0058);
        }

        [TestMethod]
        public void zero_hour_and_zero_minute_should_report_error()
        {
            var the_value = new DurationRequest()
            {
                hours = "0",
                minutes = "0"
            };
            set_field(fixture.request, the_value);
            fixture.execute_command();
            var response = fixture.response;
            response.has_errors.Should().BeTrue();
            response.messages.Should().Contain(m => m.field_name == "duration" && m.message == ValidationMessages.error_00_0058);
        }
        #endregion

        #region"valid_duration_requests_return_the_time_in_seconds"
        // done: one hour zero minutes return as a number of second (3600) .
        // done: zero hour 1 minute should return (60),
        // done: one hour and one minute should return (3660)

        [TestMethod]
        public void one_hour_zero_minute_should_return_three_thousand_six_hundrad()
        {
            confirm_duration_return_as_a_correct_secon("1", "0");
        }

        [TestMethod]
        public void zero_hour_and_one_minute_should_return_sixty_second()
        {
            confirm_duration_return_as_a_correct_secon("0", "1");
        }

        [TestMethod]
        public void one_hour_and_one_minute_should_return_three_thousand_six_hundard_sixty()
        {
            confirm_duration_return_as_a_correct_secon("1", "1");
        }

        private void confirm_duration_return_as_a_correct_secon
                                            (string hour, string minutes)
        {
            var the_value = new DurationRequest()
            {
                hours = hour,
                minutes = minutes
            };

            set_field(fixture.request, the_value);
            fixture.execute_command();
            var response = fixture.response;
            response.has_errors.Should().BeFalse();
        }

        #endregion

        #region"hour_must_be_between_zero_and_twentyfour_hour"

        // less than 0 should show error.
        // greater than 24 should show error.
        // text should show error .

        [TestMethod]
        public void hour_in_text_format_should_show_error()
        {
            confirm_hour_is_not_acceptable_as_it_is_not_a_number("test");
        }

        [TestMethod]
        public void hour_less_than_zero_should_show_error()
        {
            confirm_hour_is_not_acceptable_as_it_is_not_a_number("-1");
        }

        [TestMethod]
        public void hour_greater_than_24_should_show_error()
        {
            confirm_hour_is_not_acceptable_as_it_is_greater_than_24("25");
        }

        private void confirm_hour_is_not_acceptable_as_it_is_not_a_number
                                                           (string value)
        {
            var response = execute_update_shift_template_command(value);

            response.has_errors.Should().BeTrue();
            response.messages.Should().Contain(m => m.field_name == "duration" && m.message == ValidationMessages.error_00_0057);
        }

        private void confirm_hour_is_not_acceptable_as_it_is_greater_than_24
                                                           (string value)
        {
            var response = execute_update_shift_template_command(value);

            response.has_errors.Should().BeTrue();
            response.messages.Should().Contain(m => m.field_name == "duration" && m.message == ValidationMessages.error_00_0058);
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

        #region "minutes_must_be_between_zero_and_fiftynine"

        // -1 reports error .
        // 60 reports error .
        // text report error.
        [TestMethod]
        public void minutes_in_the_text_format_should_show_error()
        {
            confirm_minutes_is_not_correct_as_it_is_not_a_number("test");
        }

        [TestMethod]
        public void minutes_less_than_zero_should_show_error()
        {
            confirm_minutes_is_not_correct_as_it_is_not_a_number("-1");
        }

        [TestMethod]
        public void minutes_greater_than_59_should_show_error()
        {
            confirm_minutes_is_not_correct_as_it_is_not_a_number("60");
        }

        private void confirm_minutes_is_not_correct_as_it_is_not_a_number
                                                         (string value)
        {
            var response = execute_create_new_shift_template_command(value);

            response.has_errors.Should().BeTrue();
            response.messages.Should().Contain(m => m.field_name == "duration" && m.message == ValidationMessages.error_00_0057);
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
            response.messages.Should().Contain(m => m.field_name == "duration" && m.message == ValidationMessages.error_00_0057);
        }
        #endregion
    }
}