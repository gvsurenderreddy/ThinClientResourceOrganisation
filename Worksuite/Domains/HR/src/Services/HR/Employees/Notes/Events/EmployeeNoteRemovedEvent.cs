using WTS.WorkSuite.HR.HR.Employees.Notes.New;
using WTS.WorkSuite.Library.DomainTypes.FreeText;

namespace WTS.WorkSuite.HR.HR.Employees.Notes.Events
{
    public class EmployeeNoteRemovedEvent
                        : NoteIdentity
    {
        [FreeText]
        public string notes { get; set; }
    }
}