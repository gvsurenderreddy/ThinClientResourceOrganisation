using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.Employees {

    /// <summary>
    /// Mapper for mapping from Employee to EmployeeSummary.
    /// </summary>
    public interface IEmployeeDetailsDetailsMapper 
                        : IMapper<EmployeeDetail, Employee> { }
}