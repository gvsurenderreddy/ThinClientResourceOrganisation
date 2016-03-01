namespace WTS.WorkSuite.HR.HR.Employees.EmployeeDocuments.Events
{
    public class EmployeeDocumentUploadedEvent
                        : EmployeeDocumentIdentity
    {
        public string name { get; set; }

        public string description { get; set; }
    }
}