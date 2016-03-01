namespace WTS.WorkSuite.HR.HR.Employees.EmployeeDocuments
{
    public class EmployeeDocumentDetails : EmployeeDocumentIdentity
    {
        public string name { get; set; }
        public string description { get; set; }
        public string content_type { get; set; }
        public string md5_value { get; set; }
        public int document_id { get; set; }
    }
}