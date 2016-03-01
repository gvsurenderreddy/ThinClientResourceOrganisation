using WTS.WorkSuite.HR.HR.Employees.Notes.New;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.Employees.Notes.Edit
{
    public interface IGetUpdateRequest : IQuery<NoteIdentity, Response<UpdateRequest>> { }
}