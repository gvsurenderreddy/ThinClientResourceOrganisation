using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.HR.Employees.EmployeeSkills;
using WTS.WorkSuite.HR.HR.Employees.EmployeeSkills.Remove;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmployeeSkills.Features.Remove
{
    [TestClass]
    public class GivenAnEmployeeHasEmployeeSkillsWorkSuite
                            : ReorderEmployeeSkillWorkSuiteSpecification
    {
        [TestMethod]
        public void when_an_employee_skill_is_deleted_then_it_should_not_be_in_the_employee_employee_skills()
        {
            // Act
            var response = remove_employee_skill_command.execute(new EmployeeSkillIdentity
            {
                employee_id = employee.id,
                employee_skill_id = employee_skill_two.id
            });

            // Assert
            Assert.IsFalse(response.has_errors);
            employee.EmployeeSkills.Should().NotContain(employee_skill_two);
        }

        [TestMethod]
        public void when_a_highest_priority_employee_skill_is_deleted_then_should_reorder_rest_of_the_employee_skills()
        {
            // Act
            var response = remove_employee_skill_command.execute(new EmployeeSkillIdentity
            {
                employee_id = employee.id,
                employee_skill_id = employee_skill_one.id
            }
                                                                   );

            // Assert
            Assert.IsFalse(response.has_errors);
            employee_skill_two.priority.Should().Be(1);
            employee_skill_three.priority.Should().Be(2);
            employee_skill_four.priority.Should().Be(3);
            employee_skill_five.priority.Should().Be(4);
            employee_skill_six.priority.Should().Be(5);
        }

        [TestMethod]
        public void
            when_an_employee_skill_is_deleted_from_somewhere_in_middle_of_the_order_then_should_reorder_all_the_employee_skills_below_deleted_employee_skill()
        {
            // Act
            var response = remove_employee_skill_command.execute(new EmployeeSkillIdentity
            {
                employee_id = employee.id,
                employee_skill_id = employee_skill_three.id
            }
                                                                   );

            // Assert
            Assert.IsFalse(response.has_errors);
            employee_skill_one.priority.Should().Be(1);
            employee_skill_two.priority.Should().Be(2);
            employee_skill_four.priority.Should().Be(3);
            employee_skill_five.priority.Should().Be(4);
            employee_skill_six.priority.Should().Be(5);
        }

        protected override void test_setup()
        {
            base.test_setup();

            remove_employee_skill_command = DependencyResolver.resolve<IRemoveEmployeeSkill>();
        }

        protected IRemoveEmployeeSkill remove_employee_skill_command;
    }
}