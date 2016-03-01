using WTS.WorkSuite.HR.HR.Employees.Addresses.Details;
using WTS.WorkSuite.HR.HR.Employees.Addresses.New;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.Employees.Addresses.GetById
{
    public interface IGetAddressById : IQuery<AddressIdentity, Response<AddressDetailsForEdit>> { }
}