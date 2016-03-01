using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Helpers.Specifications.ForResponseCommands;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Date;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.ForDomainLogic
{
    public class DatePickerSanitisationSpecification<P, Q, F> : PlannedSupplyResponseCommandSpecification<P, Q, F>
        where Q : Response
        where F : IsAResponseCommandFixture<P, Q>
    {
        protected DatePickerSanitisationSpecification(Action<P, DateRequest> Set_field_by)
            : this(Set_field_by, null)
        {
        }

        protected DatePickerSanitisationSpecification(Action<P, DateRequest> set_field_by, string the_expected_message)
        {
            set_field = set_field_by;
            expected_message = the_expected_message;
        }

        private Action<P, DateRequest> set_field { get; set; }
        private string expected_message { get; set; }

        #region reports_an_error_when_date_picker_is_partially_specified

        // invalid year when it is empty string
        // invalid year when it is null
        // invalid year when it is empty string 

        [TestMethod]
        public void reports_a_partially_specified_error_when_the_year_is_set_to_an_empty_string()
        {
            var invalid_request = new DateRequest() { year = string.Empty, month = "12", day = "02" };
            set_field(fixture.request, invalid_request);

            fixture.execute_command();
            var response = fixture.response;
            response.has_errors.Should().BeTrue();
        }

        [TestMethod]
        public void reports_a_partially_specified_error_when_the_year_is_null()
        {

            var invalid_request = new DateRequest() { year = null, month = "12", day = "02" };
            set_field(fixture.request, invalid_request);

            fixture.execute_command();
            var response = fixture.response;
            response.has_errors.Should().BeTrue();

        }

        [TestMethod]
        public void reports_a_partially_specified_error_when_the_year_is_whitespace()
        {

            var invalid_request = new DateRequest() { year = "\t", month = string.Empty, day = "02" };
            set_field(fixture.request, invalid_request);

            fixture.execute_command();
            var response = fixture.response;
            response.has_errors.Should().BeTrue();

        }


        // invalid month when it is empty string
        // invalid month when it is null
        // invalid month when it is empty string

        [TestMethod]
        public void reports_a_partially_specified_error_when_the_month_is_set_to_an_empty_string()
        {
            var invalid_request = new DateRequest() { year = "2003", month = string.Empty, day = "02" };
            set_field(fixture.request, invalid_request);

            fixture.execute_command();
            var response = fixture.response;
            response.has_errors.Should().BeTrue();
        }

        [TestMethod]
        public void reports_a_partially_specified_error_when_the_month_is_null()
        {
            var invalid_request = new DateRequest() { year = "2003", month = null, day = "02" };
            set_field(fixture.request, invalid_request);

            fixture.execute_command();
            var response = fixture.response;
            response.has_errors.Should().BeTrue();
        }

        [TestMethod]
        public void reports_a_partially_specified_error_when_the_month_is_set_to_an_whitespace()
        {
            var invalid_request = new DateRequest() { year = "2003", month = "\t", day = "02" };
            set_field(fixture.request, invalid_request);

            fixture.execute_command();
            var response = fixture.response;
            response.has_errors.Should().BeTrue();
        }

        // invalid day when it is empty string
        // invalid day when it is null
        // invalid day when it is empty string
        [TestMethod]
        public void reports_a_partially_specified_error_when_the_day_is_set_to_an_empty_string()
        {
            var invalid_request = new DateRequest() { year = "2003", month = "12", day = string.Empty };
            set_field(fixture.request, invalid_request);

            fixture.execute_command();
            var response = fixture.response;
            response.has_errors.Should().BeTrue();
        }

        [TestMethod]
        public void reports_a_partially_specified_error_when_the_day_is_null()
        {
            var invalid_request = new DateRequest() { year = "2003", month = "12", day = null };
            set_field(fixture.request, invalid_request);

            fixture.execute_command();
            var response = fixture.response;
            response.has_errors.Should().BeTrue();
        }

        [TestMethod]
        public void reports_a_partially_specified_error_when_the_day_is_set_to_an_whitespace()
        {
            var invalid_request = new DateRequest() { year = "2003", month = string.Empty, day = "\t" };
            set_field(fixture.request, invalid_request);

            fixture.execute_command();
            var response = fixture.response;
            response.has_errors.Should().BeTrue();
        }

        // report error when the year and month are not specified
        // report error when the year and day are not specified
        // report error when the month and day are not specified

        [TestMethod]
        public void reports_a_partially_sepcified_error_when_the_year_and_month_are_not_specified()
        {
            var invalid_request = new DateRequest() { year = null, month = null, day = "\t" };
            set_field(fixture.request, invalid_request);

            fixture.execute_command();
            var response = fixture.response;
            response.has_errors.Should().BeTrue();
        }

        [TestMethod]
        public void reports_a_partially_sepcified_error_when_the_year_and_day_are_not_specified()
        {
            var invalid_request = new DateRequest() { year = null, month = "3", day = null };
            set_field(fixture.request, invalid_request);

            fixture.execute_command();
            var response = fixture.response;
            response.has_errors.Should().BeTrue();
        }

        [TestMethod]
        public void reports_a_partially_sepcified_error_when_the_month_and_day_are_not_specified()
        {
            var invalid_request = new DateRequest() { year = "2003", month = null, day = null };
            set_field(fixture.request, invalid_request);

            fixture.execute_command();
            var response = fixture.response;
            response.has_errors.Should().BeTrue();
        }

        [TestMethod]
        public void partially_specified_errors_are_reported_over_invalid_components()
        {
            var invalid_request = new DateRequest() { year = "XXXXX", month = "03", day = string.Empty };
            set_field(fixture.request, invalid_request);

            fixture.execute_command();
            var response = fixture.response;
            response.has_errors.Should().BeTrue();
        }

        #endregion

        #region  reports_an_error_when_the_components_are_invalid

        [TestMethod]
        public void reports_an_invalid_component_error_when_the_day_is_set_not_numeric()
        {
            var invalid_request = new DateRequest() { year = "2004", month = "12", day = "monday" };
            set_field(fixture.request, invalid_request);

            fixture.execute_command();
            var response = fixture.response;
            response.has_errors.Should().BeTrue();
        }

        [TestMethod]
        public void reports_an_invalid_component_error_when_the_month_is_not_numeric_or_a_valid_month_name()
        {
            var invalid_request = new DateRequest() { year = "2004", month = "XXXXXX", day = "monday" };
            set_field(fixture.request, invalid_request);

            fixture.execute_command();
            var response = fixture.response;
            response.has_errors.Should().BeTrue();
        }

        [TestMethod]
        public void reports_an_invalid_component_error_when_the_year_is_not_numeric_or_a_valid_month_name()
        {
            var invalid_request = new DateRequest() { year = "XXXXXXXX", month = "04", day = "monday" };
            set_field(fixture.request, invalid_request);

            fixture.execute_command();
            var response = fixture.response;
            response.has_errors.Should().BeTrue();
        }

        [TestMethod]
        public void reports_an_invalid_component_error_if_a_five_digit_year_is_supplied()
        {
            var invalid_request = new DateRequest() { year = "12345", month = "04", day = "monday" };
            set_field(fixture.request, invalid_request);

            fixture.execute_command();
            var response = fixture.response;
            response.has_errors.Should().BeTrue();
        }

        #endregion

        #region   reports_an_invalid_component_error_when_multiple_components_are_invalid

        [TestMethod]
        public void reports_an_invalid_component_error_when_the_month_and_day_are_invalid()
        {
            var invalid_request = new DateRequest() { year = "2004", month = "XXXXX", day = "XXXXX" };
            set_field(fixture.request, invalid_request);

            fixture.execute_command();
            var response = fixture.response;
            response.has_errors.Should().BeTrue();
        }

        [TestMethod]
        public void reports_an_invalid_component_error_when_the_year_and_day_are_invalid()
        {
            var invalid_request = new DateRequest() { year = "XXXXX", month = "03", day = "XXXXX" };
            set_field(fixture.request, invalid_request);

            fixture.execute_command();
            var response = fixture.response;
            response.has_errors.Should().BeTrue();
        }

        [TestMethod]
        public void reports_an_invalid_component_error_when_the_year_and_month_are_invalid()
        {
            var invalid_request = new DateRequest() { year = "XXXXX", month = "XXXXXX", day = "23" };
            set_field(fixture.request, invalid_request);

            fixture.execute_command();
            var response = fixture.response;
            response.has_errors.Should().BeTrue();
        }

        [TestMethod]
        public void reports_an_invalid_component_error_when_the_year_month_and_day_are_invalid()
        {
            var invalid_request = new DateRequest() { year = "XXXXX", month = "XXXXXX", day = "XXXXXXX" };
            set_field(fixture.request, invalid_request);

            fixture.execute_command();
            var response = fixture.response;
            response.has_errors.Should().BeTrue();
        }


        #endregion

        #region  dates_that_do_not_exist_report_an_invalid_date_error

        [TestMethod]
        public void reports_a_error_when_date_is_not_exist()
        {
            var invalid_request = new DateRequest() { year = "2015", month = "02", day = "31" };
            set_field(fixture.request, invalid_request);

            fixture.execute_command();
            var response = fixture.response;
            response.has_errors.Should().BeTrue();
        }

        #endregion
    }
}
