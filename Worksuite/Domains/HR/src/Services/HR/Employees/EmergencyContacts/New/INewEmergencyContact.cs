using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.New {

    public interface INewEmergencyContact 
                        : IResponseCommand<NewEmergencyContactRequest, NewEmergencyContactResponse> {}
}