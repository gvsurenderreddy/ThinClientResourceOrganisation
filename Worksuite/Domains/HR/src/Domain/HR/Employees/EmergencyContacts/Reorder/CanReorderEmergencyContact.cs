using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.Reorder
{
    public class CanReorderEmergencyContact
                        : PermissionGranted<ReorderEmergencyContactRequest>, ICanReorderEmergencyContact {}
}