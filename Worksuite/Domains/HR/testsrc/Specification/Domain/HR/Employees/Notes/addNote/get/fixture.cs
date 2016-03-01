using WTS.WorkSuite.HR.HR.Employees.Notes.addNote.get;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.Notes.addNote.get
{
    public class GetAddNoteRequestHandler_fixture
    {
         public void execute_command()
        {
            int new_employee_id = 1;

            request = new GetAddNoteRequest { employee_id = new_employee_id };

            response = get_request_command.execute(request);
        }

        public GetAddNoteResponse response { get; private set; }

        public GetAddNoteRequestHandler_fixture(IGetAddNoteRequestHandler the_get_request_command)
        {
            get_request_command = Guard.IsNotNull(the_get_request_command, "the_get_request_command");
        }

        public GetAddNoteRequest request;
        private readonly IGetAddNoteRequestHandler get_request_command;
    }
}
