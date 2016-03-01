using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.Employees.Addresses.Reorder {

    public interface IReorderAddress 
                        : ICommand<ReorderAddressRequest, ReorderAddressResponse> { }
}
