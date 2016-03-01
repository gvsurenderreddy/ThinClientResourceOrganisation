using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees.EmployeeDocuments.New;
using WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmployeeDocuments.Features.New;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmployeeDocuments.Fields.ContentType
{
    public class does_not_have_leading_and_trailing_whitespace
    {
        [TestClass]
        public class verify_on_create
                        : TextFieldHasLeadingAndTrailingWhitespaceStrippedSpecification<NewEmployeeDocumentRequest, NewEmployeeDocumentResponse, NewEmployeeDocumentFixture, EmployeeDocument>
        {

            public verify_on_create()
                : base((request) => request.content_type
                       , (value, request) => request.content_type = value
                       , (entity) => entity.content_type) { }
        }
    }
}
