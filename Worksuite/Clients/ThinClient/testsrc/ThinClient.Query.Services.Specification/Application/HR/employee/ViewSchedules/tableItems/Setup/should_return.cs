using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.ThinClient.Query.Identities;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.HR.employee.ViewSchedules.tableItems.Setup
{
    [TestClass]
    public class should_return : GetEmployeeViewScheduleTableItemsSpecification
    {
        [TestMethod]
        public void should_return_employee_id()
        {
            var request = new EmployeeIdentity {employee_id = 1};

            fixture.add().employee_id(0);
            fixture.add().employee_id(0);

            fixture.set_request(request);
            fixture.add().employee_id(request.employee_id);
            fixture.execute_query();

           Assert.AreEqual(fixture.response.result.employee_id, request.employee_id);
        }


    }
}
