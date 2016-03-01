using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.Reorder
{
    public interface IReorderEmergencyContact
                        :   ICommand<ReorderEmergencyContactRequest, ReorderEmergencyContactResponse> {}
}
