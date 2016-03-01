using WTS.WorkSuite.HR.HR.Employees.Notes.New;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.Employees.Notes.GetById
{
    public interface IGetNoteById : IQuery<NoteIdentity, Response<EmployeeNoteDetails>> { }
}