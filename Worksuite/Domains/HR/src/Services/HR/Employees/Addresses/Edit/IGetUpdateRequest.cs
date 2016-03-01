using WTS.WorkSuite.HR.HR.Employees.Addresses.New;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.Employees.Addresses.Edit
{
    public interface IGetUpdateRequest : IQuery<AddressIdentity, Response<UpdateAddressRequest>> { }
}