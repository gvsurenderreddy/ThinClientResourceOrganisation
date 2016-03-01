using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.ContactDetails.Features.Update.GetUpdateRequestCommand
{
    public class Correctly_maps_the_fields : IsAGetUpdateRequestWorkSuiteSpecification
    {
        // employee id
        // phone
        // email

        [TestMethod]
        public void map_the_employee_id_correctly()
        {
            update_request.result.employee_id.Should().Be(employee.entity.id);
        }


        [TestMethod]
        public void map_the_phone_correctly()
        {
            employee
                .forename("Fred")
                ;

            update_request.result.phone.Should().Be(employee.entity.phone_number);
        }

        [TestMethod]
        public void map_email_correctly()
        {
            employee.email("a@my.c");
            update_request.result.email.Should().Be(employee.entity.email);
        }

        [TestMethod]
        public void map_the_mobile_correctly()
        {
            employee
                .forename("Fred")
                ;

            update_request.result.mobile.Should().Be(employee.entity.mobile);
        }

        [TestMethod]
        public void map_the_other_correctly()
        {
            employee
                .forename("Fred")
                ;

            update_request.result.other.Should().Be(employee.entity.other);
        }

    }
}
