namespace WTS.WorkSuite.HR.HR.Employees.EmployeeDocuments.Events
{
    public class EmployeeDocumentRemovedEvent
                        : EmployeeDocumentIdentity
    {
        public string name { get; set; }

        public string description { get; set; }
    }
}