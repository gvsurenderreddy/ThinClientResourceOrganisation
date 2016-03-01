using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR.Employees;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmployeeSkills.Features.New
{
    public class Adding_a_new_skill_to_an_employee_will_publish_auto_reordered_events
    {
        [TestClass]
        public class WhenAnEmployeeSkillIsAdded
                        : ReorderEmployeeSkillWorkSuiteSpecification
        {
            [TestMethod]
            public void that_should_raise_employee_skill_auto_reordered_events()
            {
                // Act
                var employee_identity = new EmployeeIdentity
                {
                    employee_id = employee.id
                };

                fixture.execute_command(employee_identity);

                fixture
                    .get_last_employee_skill_auto_reordered_event_for(employee_identity)
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

                fixture = DependencyResolver.resolve<NewEmployeeSkillFixture>();
            }

            private NewEmployeeSkillFixture fixture;
        }
    }
}