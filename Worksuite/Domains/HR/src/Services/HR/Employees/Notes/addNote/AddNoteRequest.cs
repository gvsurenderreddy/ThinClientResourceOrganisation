using WTS.WorkSuite.Library.DomainTypes.FreeText;

namespace WTS.WorkSuite.HR.HR.Employees.Notes.addNote
{
    public class AddNoteRequest
    {
        [FreeText]
        public string note { get; set; }
    }
}
