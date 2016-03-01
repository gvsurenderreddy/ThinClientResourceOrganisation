using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.Employees.Addresses.Reorder
{
    public interface IGetReorderAddressRequest : IQuery<ReorderAddressRequest, Response<ReorderAddressDetails>> { }
}
