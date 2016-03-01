using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WorkSuite.Library.Service.Specification.Helpers.IdentityProvider;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees.EmployeeDocuments
{
    public class EmployeeDocumentBuilder : IEntityBuilder<EmployeeDocument>
    {
        public EmployeeDocument entity { get { return employee_document; } }

        public EmployeeDocumentBuilder()
        {
            var id = next_id();

            employee_document = new EmployeeDocument
            {
                id = id,
                document_id = id
            };
        }

        public EmployeeDocumentBuilder(EmployeeDocument the_employee_document)
        {
            Guard.IsNotNull(the_employee_document, "the_employee_document");

            var employee_document_identity_provider = new IntIdentityProvider<EmployeeDocument>();

            employee_document = new EmployeeDocument
            {
                id = employee_document_identity_provider.next(),
                content_type = the_employee_document.content_type,
                description = the_employee_document.description,
                md5_hash = the_employee_document.md5_hash,
                name = the_employee_document.name,
                document_id = the_employee_document.document_id
            };
        }

        public EmployeeDocumentBuilder name(string value)
        {
            employee_document.name = value;
            return this;
        }

        public EmployeeDocumentBuilder description(string value)
        {
            employee_document.description = value;
            return this;
        }

        public EmployeeDocumentBuilder content_type(string value)
        {
            employee_document.content_type = value;
            return this;
        }

        public EmployeeDocumentBuilder md5_hash(string value)
        {
            employee_document.md5_hash = value;
            return this;
        }

        public EmployeeDocumentBuilder document_id(int value)
        {
            employee_document.document_id = value;
            return this;
        }

        private int next_id()
        {
            var identity_provider = new IntIdentityProvider<EmployeeDocument>();

            return identity_provider.next();
        }

        private readonly EmployeeDocument employee_document;
    }
}