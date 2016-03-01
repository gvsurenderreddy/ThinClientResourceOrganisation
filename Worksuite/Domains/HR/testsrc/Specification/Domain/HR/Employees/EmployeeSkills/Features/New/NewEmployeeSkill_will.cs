using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR.Employees;
using WTS.WorkSuite.HR.HR.Employees.EmployeeSkills.New;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Skills;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmployeeSkills.Features.New
{
    public class NewEmployeeSkill_will
    {
        [TestClass]
        public class Given_an_employee_when_an_employee_skill_is_added_then_it_should_be_in_the_employee_employee_skills
            : CommandCommitedChangesSpecification<NewEmployeeSkillRequest, NewEmployeeSkillResponse, NewEmployeeSkillFixture> { }

        [TestClass]
        public class GivenAnEmployeeHasEmployeeSkillsWorkSuite
                        : ReorderEmployeeSkillWorkSuiteSpecification
        {
            [TestMethod]
            public void when_an_employee_skill_is_added_to_the_employee_employee_skills_then_it_should_set_to_highest_priority()
            {
                //Arrange
                var skill = skill_helper.add().description("skill").entity;

                // Act
                var response = add_employee_skill_command.execute(
                    new NewEmployeeSkillRequest
                    {
                        employee_id = employee.id,
                        skill_id = skill.id
                    });

                var employee_skill_seven = employee.EmployeeSkills.Single(a => a.id == response.result.employee_skill_id);

                // Assert
                employee_skill_seven.priority.Should().Be(1);
                employee_skill_one.priority.Should().Be(2);
                employee_skill_two.priority.Should().Be(3);
                employee_skill_three.priority.Should().Be(4);
                employee_skill_four.priority.Should().Be(5);
                employee_skill_five.priority.Should().Be(6);
                employee_skill_six.priority.Should().Be(7);
            }

            [TestMethod]
            public void should_return_a_valid_new_employee_skill_request()
            {
                Assert.IsTrue(employee_skill_request.employee_id == employee.id);
            }

            protected override void test_setup()
            {
                base.test_setup();

                add_employee_skill_command = DependencyResolver.resolve<INewEmployeeSkill>();

                get_new_employee_skill_request = DependencyResolver.resolve<IGetNewEmployeeSkillRequest>();
                employee_skill_request = get_new_employee_skill_request
                                                        .execute(new EmployeeIdentity
                                                        {
                                                            employee_id = employee.id
                                                        })
                                                        ;
            }

            protected INewEmployeeSkill add_employee_skill_command;
            private IGetNewEmployeeSkillRequest get_new_employee_skill_request;
            private NewEmployeeSkillRequest employee_skill_request;
        }

        [TestClass]
        public class Adding_a_skill_to_an_employee
                        : HRSpecification
        {
            [TestMethod]
            public void should_raise_employee_skill_created_event()
            {
                fixture.execute_command(null);

                fixture
                    .get_employee_skill_created_event_for(fixture.create_new_request)
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

                fixture = DependencyResolver.resolve<NewEmployeeSkillFixture>();
            }

            private NewEmployeeSkillFixture fixture;
        }
    }
}