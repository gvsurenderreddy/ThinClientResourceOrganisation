using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.Employees.Notes.addNote.get
{
    public interface IGetAddNoteRequestHandler: IServiceStatusResponseCommand < GetAddNoteRequest,
        GetAddNoteResponse
        > { }
  
}
