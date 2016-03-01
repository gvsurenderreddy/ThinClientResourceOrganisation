using System.Linq;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.Employees.addEmployee.get
{
    public class GetAddEmployeeRequestHandler : IGetAddEmployeeRequestHandler
    {
        public GetAddEmployeeResponse execute()
        {
            return new GetAddEmployeeResponse()
            {
                result = new AddEmployeeRequest()
                {
                    employee_reference = string.Empty,
                    forename = string.Empty,
                    surname = string.Empty
                },
                service_statuses = Enumerable.Empty<IServiceStatus>()
            };
        }
    }
}
