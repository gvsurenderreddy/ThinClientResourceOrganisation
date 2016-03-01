using System.Linq;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.HR.Employees.EmployeeDocuments.New;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees.EmployeeDocuments;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmployeeDocuments.Features.New
{
    public class NewEmployeeDocumentRequestHelper : IRequestHelper<NewEmployeeDocumentRequest>
    {
        public NewEmployeeDocumentRequestHelper()
        {
            _document_identity_helper = DependencyResolver.resolve<DocumentIdentityHelper>();
            _employee_repository = DependencyResolver.resolve<FakeEmployeeRepository>();
        }

        public NewEmployeeDocumentRequest given_a_valid_request()
        {
            var document_identity = _document_identity_helper.get_identity();

            var employee = _employee_repository
                                .Entities
                                .Single(e => e.id == document_identity.employee_id)
                                ;

            var employee_document = employee
                                        .EmployeeDocuments
                                        .Single(ed => ed.document_id == document_identity.employee_document_id)
                                        ;

            return new NewEmployeeDocumentRequest
            {
                employee_id = document_identity.employee_id,
                document_id = document_identity.employee_document_id,
                name = employee_document.name,
                description = employee_document.description,
                content_type = employee_document.content_type,
                md5_hash = employee_document.md5_hash
            };
        }

        private DocumentIdentityHelper _document_identity_helper;
        private FakeEmployeeRepository _employee_repository;
    }
}