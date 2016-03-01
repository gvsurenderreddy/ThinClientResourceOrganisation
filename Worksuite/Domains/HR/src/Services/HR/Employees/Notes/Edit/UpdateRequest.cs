using WTS.WorkSuite.HR.HR.Employees.Notes.New;
using WTS.WorkSuite.Library.DomainTypes.FreeText;

namespace WTS.WorkSuite.HR.HR.Employees.Notes.Edit
{
    public class UpdateRequest : NoteIdentity
    {
        [FreeText]
        public string note { get; set; }
    }
}