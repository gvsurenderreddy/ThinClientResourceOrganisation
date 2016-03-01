using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.HR.Employees.EmployeeSkills;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmployeeSkills.Features.Remove
{
    public class Removing_a_skill_from_an_employee_will_publish_auto_reordered_events
    {
        [TestClass]
        public class WhenAnEmployeeSkillIsRemoved
                        : ReorderEmployeeSkillWorkSuiteSpecification
        {
            [TestMethod]
            public void that_should_raise_employee_skill_auto_reordered_events()
            {
                // Act
                var employee_skill_identity = new EmployeeSkillIdentity
                {
                    employee_id = employee.id,
                    employee_skill_id = employee_skill_one.id
                };

                fixture.execute_command(employee_skill_identity);

                fixture
                    .get_last_employee_skill_auto_reordered_event_for(employee_skill_identity)
                    .Match(

                        has_value:
                            reordered_skill_event => Assert.IsTrue(true), // event was created

                        nothing:
                            Assert.Fail // event was not created
                    );
            }

            protected override void test_setup()
            {
                base.test_setup();

                fixture = DependencyResolver.resolve<RemoveEmployeeSkillFixture>();
            }

            private RemoveEmployeeSkillFixture fixture;
        }
    }
}