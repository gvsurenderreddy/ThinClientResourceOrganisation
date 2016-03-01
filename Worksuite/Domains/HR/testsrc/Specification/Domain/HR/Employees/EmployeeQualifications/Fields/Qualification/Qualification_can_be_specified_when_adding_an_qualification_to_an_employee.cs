using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees.EmployeeQualifications.New;
using WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmployeeQualifications.Features.New;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmployeeQualifications.Fields.Qualification
{
    [TestClass]
    public class Qualification_can_be_specified_when_adding_an_qualification_to_an_employee
                        : FieldIsMappedCorrectlySpecification<NewEmployeeQualificationRequest, NewEmployeeQualificationResponse, NewEmployeeQualificationFixture, EmployeeQualification>
    {
        protected override bool validate(NewEmployeeQualificationRequest request, EmployeeQualification entity)
        {
            return request.qualification_id == entity.qualification.id;
        }
    }
}