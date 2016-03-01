using System.Collections.Generic;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.New
{
    public interface INewEmergencyContactValidator
    {
        IEnumerable<ResponseMessage> validateEmergencyContact(NewEmergencyContactRequest request);  
    }
}