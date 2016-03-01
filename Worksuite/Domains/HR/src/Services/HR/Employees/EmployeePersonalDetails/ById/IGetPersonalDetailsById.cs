using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.Employees.EmployeePersonalDetails.ById {

    public interface IGetPersonalDetailsById : IQuery< EmployeeIdentity, Response< EmployeePersonalDetails > > {}

}