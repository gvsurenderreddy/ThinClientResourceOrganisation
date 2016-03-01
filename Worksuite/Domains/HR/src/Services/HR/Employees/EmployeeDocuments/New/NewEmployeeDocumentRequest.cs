using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.Library.DomainTypes.Documents;
using WTS.WorkSuite.Library.DomainTypes.FreeText;

namespace WTS.WorkSuite.HR.HR.Employees.EmployeeDocuments.New
{
    public class NewEmployeeDocumentRequest : EmployeeIdentity
    {
        public string name { get; set; }
        public string content_type { get; set; }
        public DocumentId document_id { get; set; }

        [FreeText]
        public string description { get; set; }
        public string md5_hash { get; set; }
    }
}