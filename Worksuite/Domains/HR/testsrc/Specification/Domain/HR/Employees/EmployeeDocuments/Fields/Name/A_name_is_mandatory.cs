using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.Employees.EmployeeDocuments.New;
using WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmployeeDocuments.Features.New;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmployeeDocuments.Fields.Name
{
        public class A_name_is_mandatory
        {

            [TestClass]
            public class verify_on_create
                            : MandatoryTextFieldSpecification<NewEmployeeDocumentRequest, NewEmployeeDocumentResponse, NewEmployeeDocumentFixture>
            {

                public verify_on_create()
                    : base((request, value) => request.name = value) { }
            }

        }
}
