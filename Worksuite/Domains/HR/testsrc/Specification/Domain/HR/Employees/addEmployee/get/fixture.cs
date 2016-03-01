using WTS.WorkSuite.HR.HR.Employees.addEmployee.get;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.addEmployee.get
{
    public class GetAddEmployeeRequestHandler_fixture
    {
        public void execute_command()
        {
            response = get_request_command.execute();
        }

        public GetAddEmployeeResponse response { get; private set; }

        public GetAddEmployeeRequestHandler_fixture(IGetAddEmployeeRequestHandler the_get_request_command)
        {
            get_request_command = Guard.IsNotNull(the_get_request_command, "the_get_request_command");
        }

        private readonly IGetAddEmployeeRequestHandler get_request_command;
    }
}
