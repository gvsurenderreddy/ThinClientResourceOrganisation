﻿using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR.Employees;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmployeeSkills.Features.GetAll
{
    [TestClass]
    public class Returns : GetAllFixture
    {
        [TestMethod]
        public void return_all_employee_skills()
        {

            var employee_skill_1 = employee_skill_builder.entity;

            var employee = add_employee().employee_skill(employee_skill_1).entity;

            var response = query.execute(new EmployeeIdentity { employee_id = employee.id }).result;
            Assert.IsTrue(response.Count() == 1);
        }

        [TestMethod]
        public void return_an_empty_set_when_there_are_no_employee_skills()
        {
            var employee = add_employee().entity;
            Assert.IsTrue(!query.execute(new EmployeeIdentity { employee_id = employee.id }).result.Any());
        }

    }

}