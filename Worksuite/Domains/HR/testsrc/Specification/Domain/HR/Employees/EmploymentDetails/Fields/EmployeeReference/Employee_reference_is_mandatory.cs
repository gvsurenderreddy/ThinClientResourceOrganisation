using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.Employees.EmploymentDetails.Edit;
using WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmploymentDetails.Features.Edit;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmploymentDetails.Fields.EmployeeReference
{

    public class Employee_reference_is_mandatory
    {

        [TestClass]
        public class verify_on_update
                            : MandatoryTextFieldSpecification<  UpdateEmploymentDetailsRequest,
                                                                UpdateEmploymentDetailsResponse,
                                                                UpdateEmploymentDetailsFixture
                                                             >
        {
            public verify_on_update() : base( ( request, value ) => request.employeeReference = value ) { }
        }
    }
}
