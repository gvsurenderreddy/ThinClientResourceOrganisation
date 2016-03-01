using WTS.WorkSuite.HR.HR.Employees.Notes.New;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.Employees.Notes.Remove {

    public interface IRemove 
                        : IResponseCommand<NoteIdentity, RemoveResponse> { }
}