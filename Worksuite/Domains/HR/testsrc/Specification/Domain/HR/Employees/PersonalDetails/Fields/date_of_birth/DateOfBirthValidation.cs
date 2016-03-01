using System;
using System.Linq;
using Content.Services.HR.Messages;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Library.DomainTypes.Date;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.PersonalDetails.Fields.date_of_birth
{
    [TestClass]
    public class DateOfBirthValidation : DateOfBirthIsValid.UpdateEmployeeDetailsSpecification
    {
        [TestMethod]
        public void reports_a_date_in_the_futuer_error_when_the_date_is_in_the_future()
        {
            var request = get_request_for(fixture.employee);

            request.date_of_birth = DateTime.Now.AddDays(1).ToDateRequest();

            var response = command.execute(request);

            Assert.IsTrue(response.messages.Any(m => m.message == ValidationMessages.error_060320151023));
            Assert.IsTrue(response.messages.Select(m => m.field_name).Contains("date_of_birth.year"));
            Assert.IsTrue(response.messages.Select(m => m.field_name).Contains("date_of_birth.month"));
            Assert.IsTrue(response.messages.Select(m => m.field_name).Contains("date_of_birth.day"));
        }

        [TestMethod]
        public void is_valid_when_date_is_exactly_the_same_of_current_date()
        {
            var request = get_request_for(fixture.employee);

            request.date_of_birth = DateTime.Now.ToDateRequest();

            var response = command.execute(request);
            response.has_errors.Should().BeFalse();
        }

        [TestMethod]
        public void is_valid_when_date_is_in_the_past()
        {
            var request = get_request_for(fixture.employee);

            request.date_of_birth = DateTime.Now.AddDays(-1).ToDateRequest();

            var response = command.execute(request);
            response.has_errors.Should().BeFalse();
        }
    }
}
