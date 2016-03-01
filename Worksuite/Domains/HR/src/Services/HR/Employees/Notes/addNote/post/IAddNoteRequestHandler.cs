using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.Employees.Notes.addNote.post
{
    public interface IAddNoteRequestHandler: IServiceStatusResponseCommand< AddNoteRequest
        , AddNoteResponse > { }
}

