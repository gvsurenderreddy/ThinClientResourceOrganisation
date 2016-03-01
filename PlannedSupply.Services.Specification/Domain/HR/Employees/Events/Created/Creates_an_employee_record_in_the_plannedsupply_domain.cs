using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.HR.Employees.Events.Created
{
    [TestClass]
    public class Creates_an_employee_record_in_the_plannedsupply_domain : EmployeeCreatedEventSpecification
    {

         [TestMethod]
        public void add_employee_personal_details_to_the_employee_planned_supply()
        {
            var created_event = fixture.create_event();

            fixture.event_handler.handle(created_event);

            fixture
                .get_employee_for(created_event)
                .Match(

                    has_value: employee_created => Assert.AreEqual(employee_created.employee_id, created_event.employee_id),

                    nothing: Assert.Fail // no employee created

                );
        }
    }
}
