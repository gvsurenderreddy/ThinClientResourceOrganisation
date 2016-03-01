using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.New
{
    public interface IGetNewEmergencyContactRequest : ICommand<EmployeeIdentity,NewEmergencyContactRequest> { }
}