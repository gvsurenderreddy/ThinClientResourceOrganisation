using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR.Employees;
using WTS.WorkSuite.HR.HR.Employees.EmployeeSkills;
using WTS.WorkSuite.HR.HR.Employees.EmployeeSkills.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmployeeSkills.Features.Remove
{
    [TestClass]
    public class Remove_an_employee_skill
                        : ReorderEmployeeSkillWorkSuiteSpecification
    {
        [TestMethod]
        public void should_raise_an_employee_skill_removed_event()
        {
            fixture
                .execute_command(new EmployeeSkillIdentity
                                        {
                                            employee_id = employee.id,
                                            employee_skill_id = employee_skill_four.id
                                        }
                                )
                ;

            fixture
                .get_last_employee_skill_removed_event_for(new EmployeeIdentity { employee_id = employee.id })
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

            fixture = DependencyResolver.resolve<RemoveEmployeeSkillFixture>();
            event_publisher = DependencyResolver.resolve<FakeEventPublisher<EmployeeSkillRemovedEvent>>();
        }

        private RemoveEmployeeSkillFixture fixture;
        private FakeEventPublisher<EmployeeSkillRemovedEvent> event_publisher;
    }
}