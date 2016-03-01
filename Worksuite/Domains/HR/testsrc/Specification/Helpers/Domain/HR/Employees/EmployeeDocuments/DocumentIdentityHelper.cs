using System.Linq;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees.EmployeeDocuments;

namespace WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees.EmployeeDocuments
{
    public class DocumentIdentityHelper
    {
        public EmployeeDocumentIdentity get_identity()
        {
            return new EmployeeDocumentIdentity
            {
                employee_id = _employee.id,
                employee_document_id = _document.document_id
            };
        }

        public DocumentIdentityHelper()
        {
            _employee_helper = DependencyResolver.resolve<EmployeeHelper>();
            _document_builder = DependencyResolver.resolve<EmployeeDocumentBuilder>();

            var employee_builder = _employee_helper.add();

            employee_builder
                .employee_document(_document_builder
                                        .name("a contact")
                                        .description("a very descriptive description")
                                        .content_type("content/type")
                                        .md5_hash("erfsd453fs3dgfdd")
                                        .entity
                                  )
                ;

            _employee = employee_builder.entity;

            _document = _employee
                        .EmployeeDocuments
                        .Single()
                        ;
        }

        private Employee _employee;
        private EmployeeHelper _employee_helper;
        private EmployeeDocument _document;
        private EmployeeDocumentBuilder _document_builder;
    }
}