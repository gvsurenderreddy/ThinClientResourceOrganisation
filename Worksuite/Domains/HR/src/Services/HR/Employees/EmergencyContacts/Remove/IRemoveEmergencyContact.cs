using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.Remove {

    public interface IRemoveEmergencyContact 
                        : IResponseCommand<EmergencyContactIdentity, RemoveEmergencyContactResponse> { }
}