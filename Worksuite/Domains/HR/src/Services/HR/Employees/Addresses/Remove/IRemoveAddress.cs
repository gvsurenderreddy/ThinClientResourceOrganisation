using WTS.WorkSuite.HR.HR.Employees.Addresses.New;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.Employees.Addresses.Remove {

    public interface IRemoveAddress 
                        : ICommand<AddressIdentity, RemoveAddressResponse> { }
}