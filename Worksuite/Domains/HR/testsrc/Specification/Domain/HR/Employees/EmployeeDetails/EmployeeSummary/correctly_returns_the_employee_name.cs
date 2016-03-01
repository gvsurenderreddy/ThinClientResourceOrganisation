using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR.Employees;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmployeeDetails.EmployeeSummary
{
    [TestClass]
    public class correctly_returns_the_employee_name : EmployeeSummaryFixture
    {
        [TestMethod]
        public void maps_the_employees_name()
        {
            var employee = add_employee()
                              .forename("Fred")
                              .surname("Alpha")
                              .entity
                              ;

            Assert.IsTrue(query.execute(new EmployeeIdentity{employee_id = employee.id}).result.employee_name == employee.forename + ' ' + employee.surname);
        }

        [TestMethod]
        public void maps_the_employees_image_id()
        {
            var employee = add_employee()
                              .forename("Fred")
                              .surname("Alpha")
                              .entity
                              ;

            Assert.IsTrue(query.execute(new EmployeeIdentity { employee_id = employee.id }).result.image_id == employee.image_id);
        } 
    }
}