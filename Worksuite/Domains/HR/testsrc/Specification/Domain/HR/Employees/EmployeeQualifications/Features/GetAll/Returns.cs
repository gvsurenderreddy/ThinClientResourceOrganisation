using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmployeeQualifications.Features.GetAll
{
    [TestClass]
    public class Returns
                    : GetAllFixture
    {
        [TestMethod]
        public void return_all_employee_qualifications()
        {
            EmployeeQualification employee_qualification = _employee_qualification_builder
                                                                .entity;

            Employee employee = add_employee()
                                .employee_qualification(employee_qualification)
                                .entity
                                ;

            var response =
                _get_all_employee_qualifications_query.execute( new EmployeeIdentity { employee_id = employee.id } ).result;

            Assert.IsTrue( response.Count() == 1 );
        }

        [TestMethod]
        public void return_an_empty_set_when_there_are_no_employee_qualifications()
        {
            var employee = add_employee()
                                .entity
                                ;

            var response =
                _get_all_employee_qualifications_query.execute(new EmployeeIdentity { employee_id = employee.id }).result;

            Assert.IsTrue(!response.Any());
        }
    }
}