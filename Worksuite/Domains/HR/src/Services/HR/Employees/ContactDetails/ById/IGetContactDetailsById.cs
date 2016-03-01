using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.Employees.ContactDetails.ById
{

    public interface IGetContactDetailsById : IQuery<EmployeeIdentity, Response<EmployeeContactDetails>>
    {
    }
}
