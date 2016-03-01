using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.ContactDetails.Features.Update.GetUpdateRequestCommand 
{

    [TestClass]
    public class GetUpdateRequestWorkSuiteWill : IsAGetUpdateRequestWorkSuiteSpecification
    {
        // done: return an update request for the specified employee

        [TestMethod]
        public void return_an_update_request_for_the_specified_employee()
        {
            update_request.result.employee_id.Should().Be(employee.entity.id);
        }
    }
}