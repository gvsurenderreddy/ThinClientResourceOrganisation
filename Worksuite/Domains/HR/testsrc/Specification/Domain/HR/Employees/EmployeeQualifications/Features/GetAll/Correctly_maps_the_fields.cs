using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees;
using WTS.WorkSuite.HR.HR.ReferenceData;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmployeeQualifications.Features.GetAll
{
    [TestClass]
    public class Correctly_maps_the_fields
                        : GetAllFixture
    {
        [TestMethod]
        public void maps_the_employee_qualification_relationship()
        {
            Qualification qualification = _qualification_helper
                                                .add()
                                                .description("A qualification")
                                                .entity
                                                ;
            EmployeeQualification employee_qualification = _employee_qualification_builder
                                                                .qualification(qualification)
                                                                .entity
                                                                ;
            Employee employee = add_employee()
                                    .employee_qualification(employee_qualification)
                                    .entity;

            var response = _get_all_employee_qualifications_query
                                        .execute(new EmployeeIdentity {employee_id = employee.id})
                                        .result
                                        .First()
                                        ;

            response.qualification.Should().Be( qualification.description );
        }
    }
}
