using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.Employees.addEmployee.post
{
    public interface IAddEmployeeRequestHandler : IServiceStatusResponseCommand<AddEmployeeRequest, AddEmployeeResponse>
    {
    }
}
