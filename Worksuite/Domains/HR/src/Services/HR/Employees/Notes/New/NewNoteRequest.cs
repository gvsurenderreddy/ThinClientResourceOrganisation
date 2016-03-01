using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.Library.DomainTypes.FreeText;

namespace WTS.WorkSuite.HR.HR.Employees.Notes.New
{
    public class NewNoteRequest : EmployeeIdentity
    {
        [FreeText]
        public string note { get; set; }
    }
}