using WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.Details;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.GetById
{
    public interface IGetEmergencyContactById : IQuery<EmergencyContactIdentity, Response<EmergencyContactDetails>> { }
}