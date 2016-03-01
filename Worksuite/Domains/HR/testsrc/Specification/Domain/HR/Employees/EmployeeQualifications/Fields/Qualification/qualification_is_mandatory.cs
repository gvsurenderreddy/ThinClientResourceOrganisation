using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.Employees.EmployeeQualifications.New;
using WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmployeeQualifications.Features.New;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;
using WTS.WorkSuite.Library.DomainTypes.DefaultValues;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmployeeQualifications.Fields.Qualification
{
    public class qualification_is_mandatory
    {
        [TestClass]
        public class verify_on_create
                        : MandatoryTextFieldSpecification<  NewEmployeeQualificationRequest,
                                                            NewEmployeeQualificationResponse,
                                                            NewEmployeeQualificationFixture
                                                         >
        {

            public verify_on_create()
                : base((request, value) => request.qualification_id = Null.Id) { }
        }
    }
}
