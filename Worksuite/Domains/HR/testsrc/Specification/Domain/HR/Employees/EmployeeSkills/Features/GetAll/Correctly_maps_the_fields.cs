using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR.Employees;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmployeeSkills.Features.GetAll
{

    [TestClass]
    public class Correctly_maps_the_fields : GetAllFixture
    {

        [TestMethod]
        public void maps_the_employee_skills_relationship()
        {
            var skill = skill_helper.add().description("skill").entity;

            var employee_skill = employee_skill_builder.skill(skill).entity;

            var employee = add_employee()
                              .forename("Fred")
                              .employee_skill(employee_skill)
                              .entity
                              ;

            var response = query.execute(new EmployeeIdentity { employee_id = employee.id }).result.First();

            response.skill.Should().Be(skill.description);
        }
    }
}