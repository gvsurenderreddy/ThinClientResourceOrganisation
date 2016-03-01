using System.Linq;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.Employees.Notes.addNote.get
{
    public class GetAddNoteRequestHandler : IGetAddNoteRequestHandler
    {
        public GetAddNoteResponse execute(GetAddNoteRequest request)
        {
            return new GetAddNoteResponse()
            {
                result = new AddNoteRequest()
                {
                    note = string.Empty,
                },
                service_statuses = Enumerable.Empty<IServiceStatus>()
            };
        }
       
    }
}
