using WorkSuite.Library.Service.Specification.Helpers.IdentityProvider;
using WorkSuite.Library.Service.Specification.Helpers.Persistence;
using WTS.WorkSuite.SupplyShortage.Employees;

namespace WTS.WorkSuite.SupplyShortage.Services.Helpers.Domain.Employee
{
    public class FakeEmployeeSupplyShortageRepository : FakeEntityRepository<EmployeeSupplyShortage, int>
    {
        public FakeEmployeeSupplyShortageRepository( )
            : base(new IntIdentityProvider<EmployeeSupplyShortage>( ))
        {
        }
    }
}
