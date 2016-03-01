using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.Edit
{
    public interface IGetUpdateRequest : IQuery<EmergencyContactIdentity, Response<UpdateRequest>> { }
}