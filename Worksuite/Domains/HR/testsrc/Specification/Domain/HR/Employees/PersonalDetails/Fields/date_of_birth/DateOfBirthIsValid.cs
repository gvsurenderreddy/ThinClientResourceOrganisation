using System;
using System.Linq;
using Content.Services.HR.Messages;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees.EmployeePersonalDetails.Edit;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.Library.DomainTypes.Date;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.PersonalDetails.Fields.date_of_birth
{
    public class DateOfBirthIsValid
    {
        [TestClass]
        public class ReportsAnErrorWhenDateOfBirthIsPartiallySpecified 
                                  : UpdateEmployeeDetailsSpecification
        {
            [TestMethod]
            public void reports_a_partially_specified_error_when_the_day_is_set_to_an_empty_string()
            {
                var request = get_request_for(fixture.employee);

                request.date_of_birth = new DateRequest
                {
                    day = string.Empty,
                    month = "10",
                    year = "1989"
                };

                var response = command.execute(request);

                Assert.IsTrue(response.messages.Any(m => m.message == ValidationMessages.error_050320151200));
                Assert.IsTrue(response.messages.Select(m => m.field_name).Contains("date_of_birth.year"));
                Assert.IsTrue(response.messages.Select(m => m.field_name).Contains("date_of_birth.month"));
                Assert.IsTrue(response.messages.Select(m => m.field_name).Contains("date_of_birth.day"));

            }

            [TestMethod]
            public void reports_a_partially_specified_error_when_the_day_is_null()
            {
                var request = get_request_for(fixture.employee);

                request.date_of_birth = new DateRequest
                {
                    day = null,
                    month = "10",
                    year = "1989"
                };

                var response = command.execute(request);

                Assert.IsTrue(response.messages.Any(m => m.message == ValidationMessages.error_050320151200));
                Assert.IsTrue(response.messages.Select(m => m.field_name).Contains("date_of_birth.year"));
                Assert.IsTrue(response.messages.Select(m => m.field_name).Contains("date_of_birth.month"));
                Assert.IsTrue(response.messages.Select(m => m.field_name).Contains("date_of_birth.day"));
            }

            [TestMethod]
            public void reports_a_partially_specified_error_when_the_month_is_set_to_an_empty_string()
            {
                var request = get_request_for(fixture.employee);
                request.date_of_birth.month = string.Empty;

                var response = command.execute(request);

                Assert.IsTrue(response.messages.Any(m => m.message == ValidationMessages.error_050320151200));
                Assert.IsTrue(response.messages.Select(m => m.field_name).Contains("date_of_birth.year"));
                Assert.IsTrue(response.messages.Select(m => m.field_name).Contains("date_of_birth.month"));
                Assert.IsTrue(response.messages.Select(m => m.field_name).Contains("date_of_birth.day"));
            }

            [TestMethod]
            public void reports_a_partially_specified_error_when_the_month_is_null()
            {
                var request = get_request_for(fixture.employee);
                request.date_of_birth.month = null;

                var response = command.execute(request);

                Assert.IsTrue(response.messages.Any(m => m.message == ValidationMessages.error_050320151200));
                Assert.IsTrue(response.messages.Select(m => m.field_name).Contains("date_of_birth.year"));
                Assert.IsTrue(response.messages.Select(m => m.field_name).Contains("date_of_birth.month"));
                Assert.IsTrue(response.messages.Select(m => m.field_name).Contains("date_of_birth.day"));
            }

            [TestMethod]
            public void reports_a_partially_specified_error_when_the_year_is_set_to_an_empty_string()
            {
                var request = get_request_for(fixture.employee);
                request.date_of_birth.year = string.Empty;

                var response = command.execute(request);

                Assert.IsTrue(response.messages.Any(m => m.message == ValidationMessages.error_050320151200));
                Assert.IsTrue(response.messages.Select(m => m.field_name).Contains("date_of_birth.year"));
                Assert.IsTrue(response.messages.Select(m => m.field_name).Contains("date_of_birth.month"));
                Assert.IsTrue(response.messages.Select(m => m.field_name).Contains("date_of_birth.day"));
            }

            [TestMethod]
            public void reports_a_partially_specified_error_when_the_year_is_null()
            {
                var request = get_request_for(fixture.employee);
                request.date_of_birth.year = null;

                var response = command.execute(request);

                Assert.IsTrue(response.messages.Any(m => m.message == ValidationMessages.error_050320151200));
                Assert.IsTrue(response.messages.Select(m => m.field_name).Contains("date_of_birth.year"));
                Assert.IsTrue(response.messages.Select(m => m.field_name).Contains("date_of_birth.month"));
                Assert.IsTrue(response.messages.Select(m => m.field_name).Contains("date_of_birth.day"));
            }

            [TestMethod]
            public void reports_a_partially_sepcified_error_when_the_year_and_month_are_not_specified()
            {
                var request = get_request_for(fixture.employee);
                request.date_of_birth.year = null;
                request.date_of_birth.month = null;

                var response = command.execute(request);

                Assert.IsTrue(response.messages.Any(m => m.message == ValidationMessages.error_050320151200));
                Assert.IsTrue(response.messages.Select(m => m.field_name).Contains("date_of_birth.year"));
                Assert.IsTrue(response.messages.Select(m => m.field_name).Contains("date_of_birth.month"));
                Assert.IsTrue(response.messages.Select(m => m.field_name).Contains("date_of_birth.day"));
            }

            [TestMethod]
            public void reports_a_partially_sepcified_error_when_the_year_and_day_are_not_specified()
            {
                var request = get_request_for(fixture.employee);
                request.date_of_birth.year = null;
                request.date_of_birth.day = null;

                var response = command.execute(request);

                Assert.IsTrue(response.messages.Any(m => m.message == ValidationMessages.error_050320151200));
                Assert.IsTrue(response.messages.Select(m => m.field_name).Contains("date_of_birth.year"));
                Assert.IsTrue(response.messages.Select(m => m.field_name).Contains("date_of_birth.month"));
                Assert.IsTrue(response.messages.Select(m => m.field_name).Contains("date_of_birth.day"));
            }

            [TestMethod]
            public void reports_a_partially_sepcified_error_when_the_month_and_day_are_not_specified()
            {
                var request = get_request_for(fixture.employee);
                request.date_of_birth.month = null;
                request.date_of_birth.day = null;

                var response = command.execute(request);

                Assert.IsTrue(response.messages.Any(m => m.message == ValidationMessages.error_050320151200));
                Assert.IsTrue(response.messages.Select(m => m.field_name).Contains("date_of_birth.year"));
                Assert.IsTrue(response.messages.Select(m => m.field_name).Contains("date_of_birth.month"));
                Assert.IsTrue(response.messages.Select(m => m.field_name).Contains("date_of_birth.day"));
            }

            [TestMethod]
            public void date_of_birth_componant_is_not_mandatory_field()
            {
                var request = get_request_for(fixture.employee);
                request.date_of_birth.year = null;
                request.date_of_birth.month = null;
                request.date_of_birth.day = null;

                var response = command.execute(request);
                response.has_errors.Should().BeFalse();
            }
        }

        [TestClass]
        public class ReportsAnErrorWhenTheComponentsAreInvalid 
                                  : UpdateEmployeeDetailsSpecification
        {
            // done: day
            // done: month
            // done: year
            [TestMethod]
            public void reports_an_invalid_component_error_when_the_day_is_set_not_numeric()
            {
                var request = get_request_for(fixture.employee);

                request.date_of_birth.day = "monday";

                var response = command.execute(request);

                Assert.IsTrue(response.messages.Any(m => m.message == ValidationMessages.error_050320151200));
                Assert.IsTrue(response.messages.Select(m => m.field_name).Contains("date_of_birth.year"));
                Assert.IsTrue(response.messages.Select(m => m.field_name).Contains("date_of_birth.month"));
                Assert.IsTrue(response.messages.Select(m => m.field_name).Contains("date_of_birth.day"));
            }

            [TestMethod]
            public void reports_an_invalid_component_error_when_the_month_is_not_numeric_or_a_valid_month_name()
            {
                var request = get_request_for(fixture.employee);

                request.date_of_birth.month = "xxxxxx";

                var response = command.execute(request);

                Assert.IsTrue(response.messages.Any(m => m.message == ValidationMessages.error_050320151200));
                Assert.IsTrue(response.messages.Select(m => m.field_name).Contains("date_of_birth.year"));
                Assert.IsTrue(response.messages.Select(m => m.field_name).Contains("date_of_birth.month"));
                Assert.IsTrue(response.messages.Select(m => m.field_name).Contains("date_of_birth.day"));
            }


            [TestMethod]
            public void reports_an_invalid_component_error_when_the_year_is_not_numeric_or_a_valid_month_name()
            {
                var request = get_request_for(fixture.employee);

                request.date_of_birth.year = "xxxxxx";

                var response = command.execute(request);

                Assert.IsTrue(response.messages.Any(m => m.message == ValidationMessages.error_050320151200));
                Assert.IsTrue(response.messages.Select(m => m.field_name).Contains("date_of_birth.year"));
                Assert.IsTrue(response.messages.Select(m => m.field_name).Contains("date_of_birth.month"));
                Assert.IsTrue(response.messages.Select(m => m.field_name).Contains("date_of_birth.day"));
            }

            [TestMethod]
            public void reports_an_invalid_component_error_if_a_five_digit_year_is_supplied()
            {
                var request = get_request_for(fixture.employee);

                request.date_of_birth.year = "12345";

                var response = command.execute(request);

                Assert.IsTrue(response.messages.Any(m => m.message == ValidationMessages.error_050320151200));
                Assert.IsTrue(response.messages.Select(m => m.field_name).Contains("date_of_birth.year"));
                Assert.IsTrue(response.messages.Select(m => m.field_name).Contains("date_of_birth.month"));
                Assert.IsTrue(response.messages.Select(m => m.field_name).Contains("date_of_birth.day"));

            }
        }

        [TestClass]
        public class ReportsAnInvalidComponentErrorWhenMultipleComponentsAreInvalid 
                                  : UpdateEmployeeDetailsSpecification
        {
            // done: month day
            // done: year day
            // done: year month
            // done: year month day
            [TestMethod]
            public void reports_an_invalid_component_error_when_the_month_and_day_are_invalid()
            {
                var request = get_request_for(fixture.employee);

                request.date_of_birth.month = "xxxxxx";
                request.date_of_birth.day = "xxxxxx";

                var response = command.execute(request);

                Assert.IsTrue(response.messages.Any(m => m.message == ValidationMessages.error_050320151200));
                Assert.IsTrue(response.messages.Select(m => m.field_name).Contains("date_of_birth.year"));
                Assert.IsTrue(response.messages.Select(m => m.field_name).Contains("date_of_birth.month"));
                Assert.IsTrue(response.messages.Select(m => m.field_name).Contains("date_of_birth.day"));
            }

            [TestMethod]
            public void reports_an_invalid_component_error_when_the_year_and_day_are_invalid()
            {
                var request = get_request_for(fixture.employee);

                request.date_of_birth.year = "xxxxxx";
                request.date_of_birth.day = "xxxxxx";

                var response = command.execute(request);

                Assert.IsTrue(response.messages.Any(m => m.message == ValidationMessages.error_050320151200));
                Assert.IsTrue(response.messages.Select(m => m.field_name).Contains("date_of_birth.year"));
                Assert.IsTrue(response.messages.Select(m => m.field_name).Contains("date_of_birth.month"));
                Assert.IsTrue(response.messages.Select(m => m.field_name).Contains("date_of_birth.day"));
            }

            [TestMethod]
            public void reports_an_invalid_component_error_when_the_year_and_month_are_invalid()
            {
                var request = get_request_for(fixture.employee);

                request.date_of_birth.year = "xxxxxx";
                request.date_of_birth.month = "xxxxxx";

                var response = command.execute(request);

                Assert.IsTrue(response.messages.Any(m => m.message == ValidationMessages.error_050320151200));
                Assert.IsTrue(response.messages.Select(m => m.field_name).Contains("date_of_birth.year"));
                Assert.IsTrue(response.messages.Select(m => m.field_name).Contains("date_of_birth.month"));
                Assert.IsTrue(response.messages.Select(m => m.field_name).Contains("date_of_birth.day"));
            }

            [TestMethod]
            public void reports_an_invalid_component_error_when_the_year_month_and_day_are_invalid()
            {
                var request = get_request_for(fixture.employee);

                request.date_of_birth.year = "xxxxxx";
                request.date_of_birth.month = "xxxxxx";
                request.date_of_birth.day = "xxxxxx";

                var response = command.execute(request);

                Assert.IsTrue(response.messages.Any(m => m.message == ValidationMessages.error_050320151200));
                Assert.IsTrue(response.messages.Select(m => m.field_name).Contains("date_of_birth.year"));
                Assert.IsTrue(response.messages.Select(m => m.field_name).Contains("date_of_birth.month"));
                Assert.IsTrue(response.messages.Select(m => m.field_name).Contains("date_of_birth.day"));
            }
        }

        [TestClass]
        public class DatesThatDoNotExistReportAnInvalidDateError 
                                  : UpdateEmployeeDetailsSpecification
        {
            [TestMethod]
            public void reports_a_partially_specified_error_when_the_day_is_set_to_an_empty_string()
            {
                var request = get_request_for(fixture.employee);

                request.date_of_birth.day = "31";
                request.date_of_birth.month = "2";

                var response = command.execute(request);

                Assert.IsTrue(response.messages.Any(m => m.message == ValidationMessages.error_050320151200));
                Assert.IsTrue(response.messages.Select(m => m.field_name).Contains("date_of_birth.year"));
                Assert.IsTrue(response.messages.Select(m => m.field_name).Contains("date_of_birth.month"));
                Assert.IsTrue(response.messages.Select(m => m.field_name).Contains("date_of_birth.day"));
            }
        }

        [TestClass]
        public class ErrorPrecedenceIs  
                                  : UpdateEmployeeDetailsSpecification
        {
            [TestMethod]
            public void partially_specified_errors_are_reported_over_invalid_components()
            {
                var request = get_request_for(fixture.employee);

                request.date_of_birth.day = string.Empty;
                request.date_of_birth.year = "xxxx";

                var response = command.execute(request);

                Assert.IsTrue(response.messages.Any(m => m.message == ValidationMessages.error_050320151200));
                Assert.IsTrue(response.messages.Select(m => m.field_name).Contains("date_of_birth.year"));
                Assert.IsTrue(response.messages.Select(m => m.field_name).Contains("date_of_birth.month"));
                Assert.IsTrue(response.messages.Select(m => m.field_name).Contains("date_of_birth.day"));
            }
        }

        [TestClass]
        public class LeadingAndTrailingWhitespaceDoesNotCauseAnErrorToBeReported 
                                  : UpdateEmployeeDetailsSpecification
        {
            // done: day
            // done: month
            // done: year

            [TestMethod]
            public void white_space_is_accepted_on_the_day_component()
            {
                var date = DateTime.Today;

                var request = get_request_for(fixture.employee);
                request.date_of_birth = date.ToDateRequest();
                request.date_of_birth.day = add_leading_and_trailing_whitespace(request.date_of_birth.day);

                var response = command.execute(request);

                Assert.IsTrue(!response.has_errors);
                Assert.AreEqual(date, fixture.employee.dateofbirth);
            }

            [TestMethod]
            public void white_space_is_accepted_on_the_month_component()
            {
                var date = DateTime.Today;

                var request = get_request_for(fixture.employee);
                request.date_of_birth = date.ToDateRequest();
                request.date_of_birth.month = add_leading_and_trailing_whitespace(request.date_of_birth.month);

                var response = command.execute(request);

                Assert.IsTrue(!response.has_errors);
            }

            [TestMethod]
            public void white_space_is_accepted_on_the_year_component()
            {
                var date = DateTime.Today;

                var request = get_request_for(fixture.employee);
                request.date_of_birth = date.ToDateRequest();
                request.date_of_birth.year = add_leading_and_trailing_whitespace(request.date_of_birth.year);

                var response = command.execute(request);

                Assert.IsTrue(!response.has_errors);
                Assert.AreEqual(date, fixture.employee.dateofbirth);
            }

            private string add_leading_and_trailing_whitespace
                (string value)
            {
                return "\t" + value + " ";
            }
        }

        [TestClass]
        public class MonthNameAreAccepted 
                                 : UpdateEmployeeDetailsSpecification
        {
            [TestMethod]
            public void is_valid_when_month_is_name_is_written()
            {
                var request = get_request_for(fixture.employee);
                request.date_of_birth.month = "March";

                var response = command.execute(request);
                response.has_errors.Should().BeFalse();

            }

            [TestMethod]
            public void is_valid_when_first_three_letter_of_month_is_written()
            {
                var request = get_request_for(fixture.employee);
                request.date_of_birth.month = "MAR";

                var response = command.execute(request);
                response.has_errors.Should().BeFalse();

            }

            [TestMethod]
            public void report_error_when_month_name_letter_is_not_exist()
            {
                var request = get_request_for(fixture.employee);
                request.date_of_birth.month = "Mur";

                var response = command.execute(request);
                response.has_errors.Should().BeTrue();
                Assert.IsTrue(response.messages.Any(m => m.message == ValidationMessages.error_050320151200));
                Assert.IsTrue(response.messages.Select(m => m.field_name).Contains("date_of_birth.year"));
                Assert.IsTrue(response.messages.Select(m => m.field_name).Contains("date_of_birth.month"));
                Assert.IsTrue(response.messages.Select(m => m.field_name).Contains("date_of_birth.day"));

            }
        }

        public class UpdateEmployeeDetailsSpecification 
                                 : HRSpecification
        {
            protected UpdateEmployeePersonalDetailsRequest get_request_for
                (Employee input_employee)
            {
                return new UpdateEmployeePersonalDetailsRequest
                {
                    forename = "Sam",
                    surname = "John",
                    employee_id = input_employee.id,
                    date_of_birth = (new DateTime(2003, 08, 24)).ToDateRequest()
                };
            }

            protected override void test_setup()
            {
                command = DependencyResolver.resolve<UpdateEmployeePersonalDetails>();
                fixture = new EmployeeFixture();
            }

            protected UpdateEmployeePersonalDetails command;
            protected EmployeeFixture fixture;
        }

        public class EmployeeFixture
        {
            public EmployeeFixture()
            {
                helper = DependencyResolver.resolve<EmployeeHelper>();
                employee_builder = helper.add();
            }

            public EmployeeHelper helper;
            public EmployeeBuilder employee_builder;

            public Employee employee
            {
                get { return employee_builder.entity; }
            }
        }
    }
}