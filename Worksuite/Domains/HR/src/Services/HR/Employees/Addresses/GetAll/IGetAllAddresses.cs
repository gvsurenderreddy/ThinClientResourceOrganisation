using System.Collections.Generic;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR.Employees.Addresses.Details;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.Employees.Addresses.GetAll
{
    public interface IGetAllAddresses : IQuery<EmployeeIdentity,Response<IEnumerable<AddressDetails>>> { }
}