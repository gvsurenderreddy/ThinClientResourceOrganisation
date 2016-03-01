using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.Employees.EmploymentDetails.Edit
{
    public interface IGetUpdateEmploymentDetailsRequest : ICommand<EmployeeIdentity, Response<UpdateEmploymentDetailsRequest>> {}
}
