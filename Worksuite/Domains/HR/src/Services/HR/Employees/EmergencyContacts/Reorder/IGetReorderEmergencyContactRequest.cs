using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.Reorder
{
    public interface IGetReorderEmergencyContactRequest
                            : IQuery< ReorderEmergencyContactRequest, Response< ReorderEmergencyContactDetails > > {}
}