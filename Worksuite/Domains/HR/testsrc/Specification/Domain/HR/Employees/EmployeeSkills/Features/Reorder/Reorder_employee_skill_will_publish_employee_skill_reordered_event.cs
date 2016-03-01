using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.HR.Employees.EmployeeSkills;
using WTS.WorkSuite.HR.HR.Employees.EmployeeSkills.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmployeeSkills.Features.Reorder
{
    public class Reorder_employee_skill_will_publish_employee_skill_reordered_events
    {
        [TestClass]
        public class WhenAnEmployeeSkillIsReordered
                        : ReorderEmployeeSkillWorkSuiteSpecification
        {
            [TestMethod]
            public void that_should_raise_an_employee_skill_manual_reordered_event()
            {
                // Act
                var employee_skill_identity = new EmployeeSkillIdentity
                {
                    employee_id = employee.id,
                    employee_skill_id = employee_skill_two.id
                };

                fixture.execute_command(employee_skill_identity, 5);

                fixture
                    .get_last_shift_calendar_pattern_manual_reordered_event_for(employee_skill_identity)
                    .Match(

                        has_value:
                            created_event => Assert.IsTrue(true), // event was created

                        nothing:
                            Assert.Fail // event was not created
                    );
            }

            [TestMethod]
            public void that_should_raise_employee_skill_auto_reordered_events()
            {
                // Act
                var employee_skill_identity = new EmployeeSkillIdentity
                {
                    employee_id = employee.id,
                    employee_skill_id = employee_skill_two.id
                };

                fixture.execute_command(employee_skill_identity, 5);

                fixture
                    .get_last_shift_calendar_pattern_auto_reordered_event_for(employee_skill_identity)
                    .Match(

                        has_value:
                            created_event => Assert.IsTrue(true), // event was created

                        nothing:
                            Assert.Fail // event was not created
                    );
            }

            protected override void test_setup()
            {
                base.test_setup();

                fixture = new ReorderEmployeeSkillFixture();
                _event_publisher_manual_reordered_event = DependencyResolver.resolve<FakeEventPublisher<EmployeeSkillManualReorderedEvent>>();
                _event_publisher_auto_reordered_event = DependencyResolver.resolve<FakeEventPublisher<EmployeeSkillAutoReorderedEvent>>();
            }

            private ReorderEmployeeSkillFixture fixture;
            private FakeEventPublisher<EmployeeSkillManualReorderedEvent> _event_publisher_manual_reordered_event;
            private FakeEventPublisher<EmployeeSkillAutoReorderedEvent> _event_publisher_auto_reordered_event;
        }
    }
}